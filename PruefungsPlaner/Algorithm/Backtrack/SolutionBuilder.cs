using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruefungsPlaner.Algorithm.Backtrack
{
    class SolutionBuilder
    {
        private static object Lock = new object();

        public static Model.Solution buildSolution(StudentSchedule[] solution, Algorithm algo)
        {
            lock (Lock)
            {
                Model.Solution sol = new Model.Solution();
                for (int day = 0; day < Algorithm.DAYS; day++)
                {
                    if (algo.daysoff.Contains(day))
                    {
                        continue;
                    }
                    int[] courseTimeSlots = new int[Algorithm.COURSES];
                    int[] courseScheduled = new int[Algorithm.COURSES];

                    TeacherSchedule[] courseTeachers = new TeacherSchedule[Algorithm.COURSES];
                    foreach (TeacherSchedule t in algo.teachers)
                    {
                        int c = t.Schedule[day];
                        if (c != -1)
                        {
                            courseTeachers[c] = t;
                            courseTimeSlots[c] = t.Available[day].ElementAt(0).StartSlot;
                        }
                    }
                    foreach (StudentSchedule stud in solution)
                    {
                        int c = stud.Schedule[day];
                        if (c >= 0)
                        {
                            Model.Exam exam = new Model.Exam();
                            exam.Student = stud.Student;
                            exam.Course = algo.courseList[c];
                            exam.Teacher = courseTeachers[c].Teacher;


                            Model.ExamConstraint ex = stud.Student.Exams.Find(x => x.Course == exam.Course);
                            if (courseTeachers[c].Available[day].Find(x => x.Inside(courseTimeSlots[c])) == null)
                            {
                                Model.SlotTimeSpan span = courseTeachers[c].Available[day].Find(x => x.StartSlot - courseTimeSlots[c] >= 0);
                                // behind all spans
                                if (span == null)
                                {
                                    exam.TimeSlot = courseTimeSlots[c];
                                }
                                // between two spans
                                else
                                {
                                    exam.TimeSlot = span.StartSlot;
                                }
                            }
                            // inside one span
                            else
                            {
                                exam.TimeSlot = courseTimeSlots[c];
                            }
                            courseTimeSlots[c] = exam.TimeSlot + ex.ExamLength + ex.PrepareTime;
                            courseScheduled[c]++;

                            if (courseScheduled[c] % Algorithm.COFFEE_BREAK_AFTER == 0)
                            {
                                courseTimeSlots[c] += exam.Course.DefaultExamLength - exam.Course.PrepareTime;
                            }

                            sol.Exams.Add(exam);
                        }
                    }
                }
                return sol;
            }            
        }
    }
}
