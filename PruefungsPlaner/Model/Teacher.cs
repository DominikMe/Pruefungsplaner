using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruefungsPlaner.Model
{
    public class Teacher
    {
        public string Name { get; set; }
        public List<SlotTimeSpan> TimeSpans = new List<SlotTimeSpan>();

    }
}
