using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PruefungsPlaner.Algorithm.Backtrack
{
    class Algorithm : IAlgorithm
    { 
        public Model.Solution Run(Model.InputModel model)
        {            
            Console.WriteLine("PRÜFUNGSPLANER");
            Console.ReadKey();

            AlgorithmWorker worker1 = new AlgorithmWorker(this);
            Thread worker1Thread = new Thread(new ThreadStart(worker1.ThreadRun));
            AlgorithmWorker worker2 = new AlgorithmWorker(this);
            Thread worker2Thread = new Thread(new ThreadStart(worker2.ThreadRun));

            try
            {
                worker1Thread.Start();
                worker2Thread.Start();

                worker1Thread.Join();
                worker2Thread.Join();
            }
            catch (ThreadStateException)
            {
            }
            catch (ThreadInterruptedException)
            {
            }

            return worker1.bestCosts <= worker2.bestCosts ? worker1.solution : worker2.solution;
        }

        //++++++++++++++++++++++++++

        
        // static fields which need to be initiated (using the model)
        public static int DAYS;
        public static int COURSES;
        public static int CURRENTDAY = 0;

        // fields which need to be initiated (using the model)
        public readonly Model.Course[] courseList;
        public readonly int[,] courseCapacity;
        public readonly int[] courseAttendants;
        public readonly StudentSchedule[] students;
        public readonly List<TeacherSchedule> teachers;
        public readonly List<int> daysoff;

        // configuration constants
        public const int MAX_ITERATION = 120;
        public const int SINGLE_TIMEOUT = 10;
        public const int COMPLETE_TIMEOUT = 120;
        public const int MIN_ATTENDANCE_TIMEOUT = 30;
        public const int COFFEE_BREAK_AFTER = 4; 


        public Algorithm(Model.InputModel model)
        {
            DAYS = TimeSlotUtil.countDays(model);
            COURSES = model.Courses.Count;

            courseList = new Model.Course[COURSES];            
            courseList = model.Courses.ToArray();

            students = new StudentSchedule[model.Students.Count];
            for (int i = 0; i < students.Length; i++)
            {
                Model.Student s = model.Students.ElementAt(i);
                bool[] courses = new bool[COURSES];
                int[] examLength = new int[COURSES];
                for (int c = 0; c < COURSES; c++)
                {
                    Model.ExamConstraint ex = s.Exams.Find(x => x.Course == model.Courses.ElementAt(c));
                    courses[c] = ex != null;
                    examLength[c] = ex != null ? ex.PrepareTime + ex.ExamLength : 0;
                }

                students[i] = new StudentSchedule(s, courses, examLength);
            }

            teachers = new List<TeacherSchedule>();
            foreach(Model.Teacher t in model.Teachers)
            {
                teachers.Add(new TeacherSchedule(t, model.SlotModel));
            }
            teachers.Sort();

            courseAttendants = countCourseAttendants(students);
            courseCapacity = countCourseCapacity(teachers);           
            daysoff = getDaysOff();
        }

        private int[,] countCourseCapacity(List<TeacherSchedule> teachers)
        {
            // sichert dieser Code zu, eine Loesung zu finden, wenn es eine gibt?
            int[,] courseCap = new int[DAYS, COURSES];
            List<TeacherSchedule> ts = new List<TeacherSchedule>();
            ts.AddRange(teachers);
            for (Algorithm.CURRENTDAY = 0; Algorithm.CURRENTDAY < Algorithm.DAYS; Algorithm.CURRENTDAY++)
            {
                ts.Sort();
                List<Model.Course> courses = courseList.ToList<Model.Course>();
                List<Model.Course> cs = courseList.ToList<Model.Course>();
                courses.Sort(compareCoursesByTeacherCount);
                
                while(courses.Count != 0)
                {                    
                    Model.Course course = minCapacityCourse(courses, courseCap);
                    int c = cs.IndexOf(course);
                    courses.Remove(course);

                    TeacherSchedule t = ts.Find(x => (x.Schedule[CURRENTDAY] == -1) && course.TeacherList.Contains(x.Teacher));                    
                    if (t != null)
                    {
                        int slots = t.SlotsOnDay(CURRENTDAY);
                        if (slots != 0)
                        {
                            t.Schedule[CURRENTDAY] = c;
                            t.Scheduled++;
                            t.DaysAvailable--;
                            courseCap[CURRENTDAY, c] = slots - (slots / ((COFFEE_BREAK_AFTER + 1) * (course.DefaultExamLength + course.PrepareTime))) * (course.DefaultExamLength - course.PrepareTime);//slots;
                            //courseCap[CURRENTDAY, c] = Math.Min(courseCap[CURRENTDAY, c], courseAttendants[c]);
                            //courseCap[CURRENTDAY, c] *= 2;
                        }
                    }
                }                                
            }
            return courseCap;
        }

        private Model.Course minCapacityCourse(List<Model.Course> courses, int[,] courseCap)
        {
            List<Model.Course> cs = courseList.ToList<Model.Course>();
            int minCap = int.MaxValue;
            Model.Course min = null;
            foreach (Model.Course c in courses)
            {
                int cap = getCourseCapacityAllDays(cs.IndexOf(c), courseCap);
                if (cap < minCap)
                {
                    minCap = cap;
                    min = c;
                }
            }
            return min;
        }

        private int getCourseCapacityAllDays(int course, int[,] courseCap)
        {
            int sum = 0;
            for (int day = 0; day < DAYS; day++)
            {
                sum += courseCap[day, course];
            }
            return sum;
        }

        private int compareCoursesByTeacherCount(Model.Course c1, Model.Course c2)
        {            
            if (c1.TeacherList.Count < c2.TeacherList.Count)
            {
                return -1;
            }
            if (c1.TeacherList.Count > c2.TeacherList.Count)
            {
                return 1;
            }
            return 0;
        }

        private int[] countCourseAttendants(StudentSchedule[] students)
        {
            int[] courseAtt = new int[COURSES];
            foreach (StudentSchedule stud in students)
            {
                bool[] courses = stud.Courses;
                for (int i = 0; i < courses.Length; i++)
                {
                    if (courses[i])
                    {
                        Model.ExamConstraint ex = stud.Student.Exams.Find(x => x.Course == courseList[i]);
                        if (ex != null)
                        {
                            courseAtt[i] += ex.ExamLength + ex.PrepareTime;
                        }
                    }
                }
            }
            return courseAtt;
        }

        private List<int> getDaysOff()
        {
            List<int> days = new List<int>();
            for (int d = 0; d < DAYS; d++)
            {
                bool zero = true;
                for (int c = 0; c < COURSES && zero; c++)
                {
                    zero &= (courseCapacity[d, c] == 0);
                }
                if (zero)
                {
                    days.Add(d);
                }
            }
            return days;
        }

        public bool checkCapacity()
        {
            for (int c = 0; c < COURSES; c++)
            {
                int sum = 0;
                for (int d = 0; d < DAYS; d++)
                {
                    sum += courseCapacity[d, c];                    
                }
                if (courseAttendants[c] > sum)
                {
                    return false;
                }
            }
            return true;
        }

        public bool checkCourseCountPerStudent()
        {
            foreach (StudentSchedule stud in students)
            {
                if (stud.CourseCount > DAYS)
                    return false;
            }
            return true;
        }        
    }
}
