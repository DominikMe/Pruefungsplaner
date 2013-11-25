using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruefungsPlaner.Model
{
    public class Student
    {
        public string Name;
        public List<ExamConstraint> Exams=new List<ExamConstraint>();

    }
}
