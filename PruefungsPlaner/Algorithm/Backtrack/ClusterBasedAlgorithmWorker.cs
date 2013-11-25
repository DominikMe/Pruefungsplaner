//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace PruefungsPlaner.Algorithm.Backtrack
//{
//    class ClusterBasedAlgorithmWorker
//    {
//        public double bestCosts = double.MaxValue;
//        public Model.Solution solution;

//        //
//        private Algorithm algo;

//        // private variables which change when computing the solution
//        private DateTime singleStartTime;
//        private DateTime completeStartTime;
//        private DateTime minAttendanceStartTime;
//        private double minAttendanceLeft = 0;
//        private double minAttendanceRight = 1;
//        private int[,] count;        

//        public ClusterBasedAlgorithmWorker(Algorithm algo, double quality = 1)
//        {
//            if (quality < 0 || quality > 1)
//            {
//                throw new ArgumentException();
//            }
//            this.minAttendanceRight = quality;
//            this.algo = algo;
//        }

//        public void ThreadRun()
//        {
//            solution = calculateSolution();
//        }

//        private bool alive(int day, int course, int student, params StudentSchedule[] studs)
//        {
//            StudentSchedule stud = studs[0];
//            if (studs.ToList().Count(x => !stud.equalCourses(x)) != 0)
//            {
//                throw new ArgumentException("Only Students with same courses allowed!");
//            }

//            if (algo.daysoff.Contains(day) && (course != -2))
//            {
//                return false;
//            }                        
//            if (course == -2)
//            {
//                int offs = stud.Schedule.Count(x => x == -2);
//                return offs < Algorithm.DAYS - stud.CourseCount;
//            }
//            // assert student takes that course
//            if (!stud.Courses[course])
//            {
//                return false;
//            }

//            int increase = studs.Sum(s => s.ExamLength[course]);
//            // assert course capacity is not exceeded            
//            if ((count[day, course] + increase) > algo.courseCapacity[day, course])
//            {
//                return false;
//            }
//            // assert course attendance is over acceptable minimum
//            if (student == (algo.students.Length - 1))
//            {
//                double min = (minAttendanceRight + minAttendanceLeft) / 2;
//                int C = (int)(algo.courseCapacity[day, course] * min);
//                if ((algo.courseAttendants[course] >= C) && (count[day, course] + increase) < C)
//                {
//                    return false;
//                }
//                for (int c = 0; c < Algorithm.COURSES; c++)
//                {
//                    C = (int)(algo.courseCapacity[day, c] * min);
//                    if ((algo.courseAttendants[c] >= C) && (count[day, c] != 0) && (count[day, c] < C))
//                    {
//                        return false;
//                    }
//                }
//            }
//            return true;
//        }

//        private void noSolution(String msg = null)
//        {
//            Console.WriteLine("No solution possible!! " + msg);
//        }

//        private double calculateCosts()
//        {
//            if (algo.students == null)
//            {
//                return double.MaxValue;
//            }
//            double score = 0;
//            for (int day = 0; day < Algorithm.DAYS; day++)
//            {
//                for (int course = 0; course < Algorithm.COURSES; course++)
//                {
//                    if (count[day, course] != 0)
//                    {
//                        score += Math.Pow((algo.courseCapacity[day, course] / count[day, course]) - 1, 4);
//                    }
//                }
//            }
//            return score;
//        }

//        private Model.Solution calculateSolution()
//        {
//            if (!algo.checkCapacity())
//            {
//                noSolution("The Course Capacity is not big enough for all students!");
//                Console.ReadKey();
//                return null;
//            }
//            if (!algo.checkCourseCountPerStudent())
//            {
//                noSolution("There are students with more courses than there are days available!");
//                Console.ReadKey();
//                return null;
//            }

//            StudentSchedule[] solution = null;
//            StudentSchedule[] finalSolution = null;

//            int i = 0;
//            bool rand = false;
//            completeStartTime = DateTime.Now;
//            minAttendanceStartTime = DateTime.Now;

//            while ((i < Algorithm.MAX_ITERATION) && (DateTime.Now.Subtract(completeStartTime).TotalSeconds < Algorithm.COMPLETE_TIMEOUT))
//            {
//                singleStartTime = DateTime.Now;
//                solution = Utils.CopyStudentsInOrder(algo.students);
//                count = new int[Algorithm.DAYS, Algorithm.COURSES];
//                int[] perm = Utils.getPermutation(Algorithm.COURSES, true);//rand);//(i != 0)));
//                rand = true;
//                StudentSchedule.CourseOrder = perm;

//                bool success = false;
//                try
//                {
//                    solution = backtrack_solve(0, 0, solution);
//                    success = true;
//                }
//                catch (TimeoutException)
//                {
//                    noSolution("Timeout!");
//                }
//                catch (MinAttendanceException)
//                {
//                    noSolution("Minimum Attendance <" + minAttendanceRight + "> too strict!");
//                    rand = false;
//                }
//                //Utils.print(solution, DAYS);
//                if (success)
//                {
//                    double costs = calculateCosts();
//                    if (costs < bestCosts)
//                    {
//                        bestCosts = costs;
//                        finalSolution = Utils.CopyStudents(solution);
//                        Utils.print(solution, Algorithm.DAYS);
//                        Console.WriteLine("Costs: " + costs + "\n");
//                    }
//                    else
//                    {
//                        Console.Write(".");
//                    }
//                    i++;

//                    minAttendanceLeft = (minAttendanceRight + minAttendanceLeft) / 2;
//                    Console.WriteLine("New interval: " + minAttendanceLeft + ", " + minAttendanceRight);
//                }
//            }
//            if (finalSolution != null)
//            {
//                Console.WriteLine();
//                Utils.print(finalSolution, Algorithm.DAYS);
//                Console.WriteLine("\nBest Costs: " + bestCosts);

//                /*Console.Write("\nPretty Print? (y/n) > ");
//                char c = Console.ReadKey().KeyChar;
//                if (c == 'y')
//                {
//                    Utils.pretty_print(finalSolution, Algorithm.DAYS, Algorithm.COURSES, algo.courseList);
//                }
//                Console.ReadKey();*/

//                return buildSolution(finalSolution);                
//            }
//            else return null;
//        }


//        private StudentSchedule[] backtrack_solve(int day, StudentSchedule[] solution)
//        {
//            DateTime now = DateTime.Now;
//            if (now.Subtract(singleStartTime).TotalSeconds > Algorithm.SINGLE_TIMEOUT)
//            {
//                throw new TimeoutException();
//            }

//            if (now.Subtract(minAttendanceStartTime).TotalSeconds > Algorithm.MIN_ATTENDANCE_TIMEOUT)
//            {
//                double mean = (minAttendanceRight + minAttendanceLeft) / 2;
//                minAttendanceRight = mean;
//                /*if (bestCosts == ulong.MaxValue)
//                {
//                    minAttendanceRight = mean;
//                }
//                else
//                {
//                    minAttendanceLeft = mean;
//                }*/
//                Console.WriteLine("New interval: " + minAttendanceLeft + ", " + minAttendanceRight);
//                minAttendanceStartTime = DateTime.Now;
//                throw new MinAttendanceException();
//            }

//            int i = day;

//            List<StudentSchedule> workingSet = solution.ToList<StudentSchedule>().FindAll(x => x.Schedule[day] == -1);
//            StudentSchedule first = workingSet.First();
//            List<StudentSchedule> sameAs_first = workingSet.FindAll(x => x.equalCourses(first));

//            for (int t = sameAs_first.Count; t >= 1; t--)
//            {
//                List<StudentSchedule> studs = new List<StudentSchedule>();
//                studs.AddRange(sameAs_first.Take(t));

//                for (int k = 0; k < Algorithm.COURSES + 1; k++)
//                {
//                    // -2 means a day off                
//                    int _k = (k == Algorithm.COURSES) ? -2 : StudentSchedule.CourseOrder[k];
//                    if (alive(i, _k, j, stud))
//                    {
//                        stud.Schedule[i] = _k;
//                        if (_k != -2)
//                        {
//                            stud.Courses[_k] = false;
//                            count[i, _k] += stud.ExamLength[_k];
//                        }

//                        //solution complete?
//                        if ((i == Algorithm.DAYS - 1) && (j == solution.Length - 1))
//                        {
//                            //Console.WriteLine("Complete!");

//                            return solution;
//                        }

//                        if (j < solution.Length - 1)
//                        {
//                            backtrack_solve(i, j + 1, solution);
//                        }
//                        else if (i < Algorithm.DAYS - 1)
//                        {
//                            backtrack_solve(i + 1, 0, solution);
//                        }
//                    }
//                }
//            }
//            if (stud.Schedule[i] == -1)
//            {
//                //Console.WriteLine("back");

//                // backtrack = revoke predecessor's choice
//                StudentSchedule pre = null;
//                int c = -1;
//                int d = -1;
//                if (j > 0)
//                {
//                    pre = solution[j - 1];
//                    c = pre.Schedule[i];
//                    d = i;
//                }
//                else if (i > 0)
//                {
//                    pre = solution[solution.Length - 1];
//                    c = pre.Schedule[i - 1];
//                    d = i - 1;
//                }
//                else
//                {
//                    // no solution
//                    noSolution();
//                    return null;
//                }
//                if (c != -2)
//                {
//                    pre.Courses[c] = true;
//                    count[d, c] -= pre.ExamLength[c];
//                }
//                else { }
//                pre.Schedule[d] = -1;

//                //print();
//                //Console.WriteLine("...");
//            }
//            return solution;
//        }

//        private Model.Solution buildSolution(StudentSchedule[] solution)
//        {
//            Model.Solution sol = new Model.Solution();
//            for (int day = 0; day < Algorithm.DAYS; day++)
//            {
//                if (algo.daysoff.Contains(day))
//                {
//                    continue;
//                }
//                int[] courseTimeSlots = new int[Algorithm.COURSES];
//                int[] courseScheduled = new int[Algorithm.COURSES];

//                TeacherSchedule[] courseTeachers = new TeacherSchedule[Algorithm.COURSES];
//                foreach (TeacherSchedule t in algo.teachers)
//                {
//                    int c = t.Schedule[day];
//                    if (c != -1)
//                    {
//                        courseTeachers[c] = t;
//                        courseTimeSlots[c] = t.Available[day].ElementAt(0).StartSlot;
//                    }
//                }
//                foreach (StudentSchedule stud in solution)
//                {
//                    int c = stud.Schedule[day];
//                    if (c >= 0)
//                    {
//                        Model.Exam exam = new Model.Exam();
//                        exam.Student = stud.Student;
//                        exam.Course = algo.courseList[c];
//                        exam.Teacher = courseTeachers[c].Teacher;


//                        Model.ExamConstraint ex = stud.Student.Exams.Find(x => x.Course == exam.Course);
//                        if (courseTeachers[c].Available[day].Find(x => x.Inside(courseTimeSlots[c])) == null)
//                        {
//                            Model.SlotTimeSpan span = courseTeachers[c].Available[day].Find(x => x.StartSlot - courseTimeSlots[c] >= 0);
//                            // behind all spans
//                            if (span == null)
//                            {
//                                exam.TimeSlot = courseTimeSlots[c];
//                            }
//                            // between two spans
//                            else
//                            {
//                                exam.TimeSlot = span.StartSlot;
//                            }
//                        }
//                        // inside one span
//                        else
//                        {
//                            exam.TimeSlot = courseTimeSlots[c];
//                        }
//                        courseTimeSlots[c] = exam.TimeSlot + ex.ExamLength + ex.PrepareTime;
//                        courseScheduled[c]++;

//                        if (courseScheduled[c] % Algorithm.COFFEE_BREAK_AFTER == 0)
//                        {
//                            courseTimeSlots[c] += exam.Course.DefaultExamLength - exam.Course.PrepareTime;
//                        }

//                        sol.Exams.Add(exam);
//                    }
//                }
//            }
//            return sol;
//        }
//    }
//}
