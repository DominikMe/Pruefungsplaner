using System;
namespace PruefungsPlaner.Model
{
    public class SlotTimeSpan
    {
        public int StartSlot;
        public int EndSlot;
        public bool Inside(int timeSlot)
        {
            return (timeSlot <= EndSlot) && (timeSlot >= StartSlot);
        }
    }

    public class TimeSlotModel
    {

        private DateTime startTime;
        private int slotLength;
        public TimeSlotModel(int slotLengthInMinutes, DateTime startTime)
        {
            slotLength = slotLengthInMinutes;
            this.startTime = startTime;
        }

        public SlotTimeSpan CreateSlotTimeSpan(DateTime start, DateTime end)
        {
            return new SlotTimeSpan { StartSlot = TimeToSlot(start), EndSlot = TimeToSlot(end) };
        }

        public int TimeToSlot(DateTime time)
        {
            return (int)Math.Floor((double)((double)(time.Subtract(startTime).TotalMinutes) / (double)slotLength));            
        }

        public DateTime SlotToTime(int timeSlot)
        {
            return startTime.AddMinutes(slotLength * timeSlot);
        }
    }
}
