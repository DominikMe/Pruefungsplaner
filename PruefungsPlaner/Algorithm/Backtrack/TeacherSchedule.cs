using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruefungsPlaner.Algorithm.Backtrack
{
    class TeacherSchedule : IComparable<TeacherSchedule>
    {
        public readonly Model.Teacher Teacher;
        public int[] Schedule;
        public int Scheduled;
        public readonly List<Model.SlotTimeSpan>[] Available;
        public int DaysAvailable;

        public TeacherSchedule(Model.Teacher teacher, Model.TimeSlotModel tmodel)
        {
            this.Teacher = teacher;
            Schedule = new int[Algorithm.DAYS];
            for (int i = 0; i < Schedule.Length; i++)
            {
                Schedule[i] = -1;
            }
            Available = new List<Model.SlotTimeSpan>[Algorithm.DAYS];
            foreach (Model.SlotTimeSpan tspan in Teacher.TimeSpans)
            {
                int day = TimeSlotUtil.TimeSpanToDay(tmodel, tspan);
                if (Available[day] == null)
                {
                    DaysAvailable++;
                    Available[day] = new List<Model.SlotTimeSpan>();
                }
                Available[day].Add(tspan);
                Available[day].OrderBy(x => x.StartSlot);
            }
        }

        public int SlotsOnDay(int day)
        {
            if (Available[day] == null)
            {
                return 0;
            }
            int sum = 0;
            foreach (Model.SlotTimeSpan tspan in Available[day])
            {
                sum += tspan.EndSlot - tspan.StartSlot;
            }
            return sum;
        }

        public int CompareTo(TeacherSchedule other)
        {
            if (this.Scheduled < other.Scheduled)
            {
                return -1;
            }
            if (this.Scheduled > other.Scheduled)
            {
                return 1;
            }

            if (this.DaysAvailable < other.DaysAvailable)
            {
                return -1;
            }
            if (this.DaysAvailable > other.DaysAvailable)
            {
                return 1;
            }

            if (this.SlotsOnDay(Algorithm.CURRENTDAY) > other.SlotsOnDay(Algorithm.CURRENTDAY))
            {
                return -1;
            }
            if (this.SlotsOnDay(Algorithm.CURRENTDAY) < other.SlotsOnDay(Algorithm.CURRENTDAY))
            {
                return 1;
            }

            return 0;
        }
    }
}
