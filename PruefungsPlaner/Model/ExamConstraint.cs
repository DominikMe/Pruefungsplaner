using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruefungsPlaner.Model
{
    public class ExamConstraint
    {
        public Course Course;
        public int? CustomExamLength;
        public int ExamLength
        {
            get { return CustomExamLength ?? Course.DefaultExamLength; }
        }

        public int? CustomPrepareTime;
        public int PrepareTime
        {
            get { return CustomPrepareTime ?? Course.PrepareTime; }
        }

        public string AdditionalDescription;
        public string Description
        {
            get
            {
                if (AdditionalDescription == null)
                    return Course.Name;
                else
                    return Course.Name + "[" + AdditionalDescription + "]";
            }
        }
    }
}
