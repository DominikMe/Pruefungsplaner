using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruefungsPlaner.Model
{
    public class Course
    {
        public string Name { get; set; }
        public int DefaultExamLength { get; set; }//in time slots
        public int PrepareTime { get; set; } //in time slots
        public List<Teacher> TeacherList=new List<Teacher>();
    }
}
