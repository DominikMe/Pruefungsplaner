using System;

namespace PruefungsPlaner.Algorithm.Backtrack
{

    class StudentSchedule
    {
        public readonly bool[] Courses;
        public readonly int[] Schedule;
        public readonly int[] ExamLength;
        // for allowing random solutions
        public static int[] CourseOrder { get; set; }
        public readonly Model.Student Student;
        public readonly int CourseCount;

        public StudentSchedule(Model.Student student, bool[] courses, int[] examLength)
        {
            this.Student = student;
            if ((courses.Length != Algorithm.COURSES) || (examLength.Length != Algorithm.COURSES))
            {
                throw new ArgumentException();
            }
            this.Courses = courses;
            this.ExamLength = examLength;
            this.CourseCount = 0;
            foreach(bool b in this.Courses)
            {
                this.CourseCount += b ? 1 : 0;
            }
            Schedule = new int[Algorithm.DAYS];
            for (int i = 0; i < Schedule.Length; i++)
            {
                Schedule[i] = -1;
            }
        }

        public bool equalCourses(StudentSchedule student)
        {
            for (int i = 0; i < this.Courses.Length; i++)
            {
                if (this.Courses[i] != student.Courses[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}