using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruefungsPlaner.Algorithm.Backtrack
{
    class AlgorithmWorker
    {
        public double bestCosts = double.MaxValue;
        public Model.Solution solution;

        //
        private Algorithm algo;

        // private variables which change when computing the solution
        private DateTime singleStartTime;
        private DateTime completeStartTime;
        private DateTime minAttendanceStartTime;
        private int[,] count;        

        public AlgorithmWorker(Algorithm algo)
        {            
            this.algo = algo;
        }

        public void ThreadRun()
        {
            solution = calculateSolution();
        }

        private bool alive(int day, int course, int student, StudentSchedule stud)
        {
            if (algo.daysoff.Contains(day) && (course != -2))
            {
                return false;
            }
            if (course == -2)
            {
                int offs = stud.Schedule.Count(x => x == -2);
                return offs < Algorithm.DAYS - stud.CourseCount;
            }
            // assert student takes that course
            if (!stud.Courses[course])
            {
                return false;
            }

            // assert course capacity is not exceeded            
            if ((count[day, course] + stud.ExamLength[course]) > algo.courseCapacity[day, course])
            {
                return false;
            }
            return true;
        }

        private void noSolution(String msg = null)
        {
            Console.WriteLine("No solution possible!! " + msg);
        }

        private double calculateCosts()
        {
            if (algo.students == null)
            {
                return double.MaxValue;
            }
            double score = 0;
            for (int day = 0; day < Algorithm.DAYS; day++)
            {
                for (int course = 0; course < Algorithm.COURSES; course++)
                {
                    if (count[day, course] != 0)
                    {
                        score += Math.Pow((algo.courseCapacity[day, course] / count[day, course]) - 1, 4);
                    }
                }
            }
            return score;
        }

        private Model.Solution calculateSolution()
        {
            if (!algo.checkCapacity())
            {
                noSolution("The Course Capacity is not big enough for all students!");
                Console.ReadKey();
                return null;
            }
            if (!algo.checkCourseCountPerStudent())
            {
                noSolution("There are students with more courses than there are days available!");
                Console.ReadKey();
                return null;
            }

            StudentSchedule[] solution = null;
            StudentSchedule[] finalSolution = null;

            int i = 0;            
            completeStartTime = DateTime.Now;
            minAttendanceStartTime = DateTime.Now;

            while ((i < Algorithm.MAX_ITERATION) && (DateTime.Now.Subtract(completeStartTime).TotalSeconds < Algorithm.COMPLETE_TIMEOUT))
            {
                singleStartTime = DateTime.Now;
                solution = Utils.CopyStudentsInOrder(algo.students);
                count = new int[Algorithm.DAYS, Algorithm.COURSES];
                int[] perm = Utils.getPermutation(Algorithm.COURSES, true);//rand);//(i != 0)));                
                StudentSchedule.CourseOrder = perm;
                
                try
                {
                    solution = backtrack_solve(0, 0, solution);                    
                }
                catch (TimeoutException)
                {
                    noSolution("Timeout!");
                }               
                if (solution != null)
                {
                    double costs = calculateCosts();
                    if (costs < bestCosts)
                    {
                        bestCosts = costs;
                        finalSolution = Utils.CopyStudents(solution);
                        Utils.print(solution, Algorithm.DAYS);
                        Console.WriteLine("Costs: " + costs + "\n");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                    i++;
                }
            }
            if (finalSolution != null)
            {
                Console.WriteLine();
                Utils.print(finalSolution, Algorithm.DAYS);
                Console.WriteLine("\nBest Costs: " + bestCosts);
                
                return SolutionBuilder.buildSolution(finalSolution, algo);                
            }
            else return null;
        }

        private StudentSchedule[] backtrack_solve(int day, int student, StudentSchedule[] solution)
        {
            DateTime now = DateTime.Now;
            if (now.Subtract(singleStartTime).TotalSeconds > Algorithm.SINGLE_TIMEOUT)
            {
                throw new TimeoutException();
            }           
            int i = day;
            int j = student;

            StudentSchedule stud = solution[j];


            for (int k = 0; k < Algorithm.COURSES + 1; k++)
            {
                // -2 means a day off                
                int _k = (k == Algorithm.COURSES) ? -2 : StudentSchedule.CourseOrder[k];
                if (alive(i, _k, j, stud))
                {
                    stud.Schedule[i] = _k;
                    if (_k != -2)
                    {
                        stud.Courses[_k] = false;
                        count[i, _k] += stud.ExamLength[_k];
                    }

                    //solution complete?
                    if ((i == Algorithm.DAYS - 1) && (j == solution.Length - 1))
                    {
                        //Console.WriteLine("Complete!");
                        return solution;
                    }

                    if (j < solution.Length - 1)
                    {
                        return backtrack_solve(i, j + 1, solution);
                    }
                    else if (i < Algorithm.DAYS - 1)
                    {
                        return backtrack_solve(i + 1, 0, solution);
                    }
                }
            }
            StudentSchedule pre = null;
            int c = -1;
            int d = -1;
            if (j > 0)
            {
                pre = solution[j - 1];
                c = pre.Schedule[i];
                d = i;
            }
            else if (i > 0)
            {
                pre = solution[solution.Length - 1];
                c = pre.Schedule[i - 1];
                d = i - 1;
            }
            else
            {
                // no solution
                noSolution();
                return null;
            }
            if (c != -2)
            {
                pre.Courses[c] = true;
                count[d, c] -= pre.ExamLength[c];
            }
            else { }
            pre.Schedule[d] = -1;

            //print();
            //Console.WriteLine("...");

            return null;
        }
        
    }
}
