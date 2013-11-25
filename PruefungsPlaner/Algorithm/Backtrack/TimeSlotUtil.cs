using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruefungsPlaner.Algorithm.Backtrack
{
    class TimeSlotUtil
    {
        /*private Model.InputModel model;

        TimeSlotUtil(Model.InputModel model)
        {
            this.model = model;
        }*/

        public static int countDays(Model.InputModel model)
        {
            DateTime startTime = model.SlotModel.SlotToTime(0);
            int lastSlot = 0;
            foreach (Model.Teacher t in model.Teachers)
            {
                foreach (Model.SlotTimeSpan span in t.TimeSpans)
                {
                    lastSlot = Math.Max(lastSlot, span.StartSlot);
                }
            }
            return diffDays(startTime, model.SlotModel.SlotToTime(lastSlot)) + 1;
        }

        public static int TimeSpanToDay(Model.TimeSlotModel tmodel, Model.SlotTimeSpan tspan)
        {
            DateTime startTime = tmodel.SlotToTime(0);
            return diffDays(startTime, tmodel.SlotToTime(tspan.StartSlot));
        }

        private static int diffDays(DateTime d1, DateTime d2)
        {
            if (d1 > d2)
            {
                throw new ArgumentException();
            }
            int days = (d2.DayOfYear - d1.DayOfYear);
            if (days < 0)
            {
                days %= daysInYear(d1.Year);
            }
            return days;
        }

        private static int daysInYear(int year)
        {
            int d = 0;
            for (int m = 1; m <= 12; m++)
            {
                d += DateTime.DaysInMonth(year, m);
            }
            return d;
        }
    }
}
