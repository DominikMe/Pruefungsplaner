using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruefungsPlaner.Model
{
    class Exam
    {
        public Teacher Teacher;
        public int TimeSlot;
        public Student Student;
        public Course Course;
        public ExamConstraint GetConstraints()
        {
            return Student.Exams.Find(x => x.Course == Course);
        }
    }
}
