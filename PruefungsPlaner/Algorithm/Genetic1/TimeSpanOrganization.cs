using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PruefungsPlaner.Model;

namespace PruefungsPlaner.Algorithm.Genetic1
{

    class StudentExam{
        public Student Student;
        public ExamConstraint Exam;
    }

    class TimeSpanOrganization:ICloneable
    {
        SlotTimeSpan timeSpan;

        public StudentExam[] timeSlots;


        public int StartSlot
        {
            get{
                return timeSpan.StartSlot;
            }
        }
        public StudentExam GetExamAt(int timeSlot)
        {
            if ((timeSpan.StartSlot < timeSlot) || (timeSpan.EndSlot < timeSlot))
                return null;
            else
                return timeSlots[timeSlot - timeSpan.StartSlot];

        }

        public TimeSpanOrganization(SlotTimeSpan span)
        {
            timeSpan=span;
            timeSlots=new StudentExam[span.EndSlot-span.StartSlot+1];
        }

        public void Insert(int slot,StudentExam exam)
        {
            for(int i=slot;i<slot+exam.Exam.ExamLength;i++)
            {
                timeSlots[i] = exam;
            }            
        }

        public void Remove(StudentExam exam)
        {
            for (int i = 0; i < timeSlots.Length; i++)
            {
                if (timeSlots[i] == exam)
                {
                    timeSlots[i] = null;
                }
            }
        }

        public List<StudentExam> getAllExams()
        {
            List<StudentExam> list = new List<StudentExam>();
            
            for (int i = 0; i < timeSlots.Length; i++)
            {
                var se=timeSlots[i];
                if ( se == null) continue;
                if (list.Count == 0)
                {
                    list.Add(se);
                    continue;
                }
                if (list[list.Count - 1] != se)
                {
                    list.Add(se);
                }
            }
            return list;
        }

        public void Compact()
        {
        }

        public int[] GetFreeSlots(int length, int prepareTime)
        {
            List<int> slots=new List<int>();
            int freeSlotsInARow=0;
            bool firstInTimeSpan=true;
            for(int i=0;i<timeSlots.Length;i++)
            {
                if(timeSlots[i]==null)
                {
                    freeSlotsInARow++;
                }
                else
                {
                    firstInTimeSpan=false;
                    freeSlotsInARow=0;
                }

                if((freeSlotsInARow>=length)&&(firstInTimeSpan))
                {//first in this session, we need no preperation time
                    slots.Add(i-length+1);
                }
                else
                {//ok, not the first one, we need preparation time
                    if(freeSlotsInARow>=length+prepareTime)
                    {
                        slots.Add(i-length+1);
                    }
                }
            }
            return slots.ToArray();
        }
        
        public object Clone()
        {
            var clone = new TimeSpanOrganization(timeSpan);
            timeSlots.CopyTo(clone.timeSlots,0);
            return clone;
        }
    }
}
