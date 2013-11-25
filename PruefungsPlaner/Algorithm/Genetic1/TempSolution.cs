using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PruefungsPlaner.Model;


namespace PruefungsPlaner.Algorithm.Genetic1
{
    class TempSolution : PruefungsPlaner.Algorithm.Genetic.GeneticSolutionBase<TempSolution>
    {

        public TempSolution(InputModel m)
            : base(m)
        {
        }
        new List<CostCalc> setUpCostCalc()
        {
            return new List<CostCalc> { 
                new CostCalc { Calc = CalcCosts_NumberOfUsedTimeSlots, CostFactor = 2 },
                new CostCalc { Calc = CalcCosts_OneStudentMultipleExamsOneDay, CostFactor = 30 },
                new CostCalc { Calc = CalcCosts_OneStudentTwoExamsSameTime, CostFactor = 50 },
                new CostCalc { Calc = CalcCosts_OneTimeSlotDifferentCourses, CostFactor = 2 }
            };

        }

        private int CalcCosts_OneTimeSlotDifferentCourses()
        {
            int costs=0;
            foreach (var a in schedules)
            {
                
                foreach (var s in a.Value)
                {
                    Course course=null;

                    foreach (var c in s.getAllExams())
                    {
                        if (course == null)
                            course = c.Exam.Course;
                        else
                            if (course != c.Exam.Course)
                                costs++;
                    }
                }
            }
            return costs;
        }


        private IEnumerable<StudentExam> allExamsInTimeSlot(int timeSlot)
        {

            foreach (var a in schedules)
            {
                foreach (var s in a.Value)
                {
                   yield return s.GetExamAt(timeSlot);
                }                   
            }            
        }

        private IEnumerable<TimeSpanOrganization> allTimeSlotOrganisations()
        {
            
            foreach (var a in schedules)
            {
                foreach (var s in a.Value)
                {
                    yield return s;
                }
            }
        }

        private int CalcCosts_OneStudentTwoExamsSameTime()
        {
            int costs = 0;
            for (int i = 0; i < Model.MaxTimeSlot; i++)
            {
                HashSet<Student> studentsInExamsThisTime = new HashSet<Student>();
                foreach (var se in allExamsInTimeSlot(i))
                {
                    if (studentsInExamsThisTime.Contains(se.Student))
                        costs++;
                    else
                        studentsInExamsThisTime.Add(se.Student);
                }
            }
            return costs;
        }

        private int CalcCosts_NumberOfUsedTimeSlots()
        {//what was this about?
            return 0;
        }

        private int CalcCosts_OneStudentMultipleExamsOneDay()
        {
            int costs=0;
            Dictionary<int, List<TimeSpanOrganization>> dayToScheduleList = new Dictionary<int, List<TimeSpanOrganization>>();
            foreach (var a in allTimeSlotOrganisations())
            {
                DateTime time = Model.SlotModel.SlotToTime(a.StartSlot);
                int dayNumber = time.DayOfYear + time.Year * 366;
                List<TimeSpanOrganization> list;
                if (dayToScheduleList.ContainsKey(dayNumber))
                    list = dayToScheduleList[dayNumber];
                else
                {
                    list = new List<TimeSpanOrganization>();
                    dayToScheduleList.Add(dayNumber, list);
                }
            }

            foreach (var a in dayToScheduleList)
            {
                HashSet<Student> studentsInExamsOnThisDay = new HashSet<Student>();
                foreach (var tso in a.Value)
                {
                    foreach(var se in tso.getAllExams())
                    if (studentsInExamsOnThisDay.Contains(se.Student))
                        costs++;
                    else
                        studentsInExamsOnThisDay.Add(se.Student);
                }
            }
            return costs;
        }

        

        public Dictionary<Teacher, List<TimeSpanOrganization>> schedules;

        public static TempSolution CreateInitialSolution(InputModel model)
        {
            TempSolution solution = new TempSolution(model);
            solution.schedules = new Dictionary<Teacher, List<TimeSpanOrganization>>();
            foreach (var teacher in model.Teachers)
            {
                List<TimeSpanOrganization> teachersTimeSpanOrgList=new List<TimeSpanOrganization>();
                foreach (var span in teacher.TimeSpans)
                {
                    teachersTimeSpanOrgList.Add(new TimeSpanOrganization(span));
                }
                solution.schedules.Add(teacher,teachersTimeSpanOrgList);
            }

            foreach (var student in model.Students)
            {
                foreach (var exam in student.Exams)
                {
                    StudentExam se = new StudentExam { Student = student, Exam = exam };
                    //now find a place where it could fit
                    bool found = false;
                    foreach (var teacher in se.Exam.Course.TeacherList)
                    {
                        var timeSlots = solution.schedules[teacher];
                        foreach (var ts in timeSlots)
                        {
                            var a = ts.GetFreeSlots(se.Exam.ExamLength, se.Exam.PrepareTime);
                            
                            foreach (int b in a)
                            {
                                ts.Insert(b, se);
                                found = true;
                            }
                            if (found) break;
                        }
                        if (found) break;
                    }
                }
            }
            return solution;
        }

        protected override TempSolution Combine(TempSolution v)
        {
            // TODO 


            return base.Combine(v);
        }

        protected override TempSolution Mutate()
        {
            // TODO
            return base.Mutate();
        }
    }
}
