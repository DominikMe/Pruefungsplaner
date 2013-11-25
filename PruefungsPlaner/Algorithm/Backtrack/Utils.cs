using System;
using System.Collections.Generic;

namespace PruefungsPlaner.Algorithm.Backtrack
{
    class Utils
    {
        private static Random rand = null;

        private Utils()
        {
        }

        /*
        * Returns a random permutation of 0..k if random is true, returns 0..k otherwise. 
        * 
        */
        public static int[] getPermutation(int k, bool random)
        {
            // permutation of 0..k-1
            int[] perm = new int[k];
            if (random)
            {
                // random order of choosing courses per student
                bool[] chosen = new bool[k];
                if (rand == null)
                {
                    rand = new Random();
                }
                for (int i = 0; i < k; i++)
                {
                    int z;
                    do
                    {
                        z = rand.Next(k);
                    }
                    while (chosen[z]);

                    perm[i] = z;
                    chosen[z] = true;
                }
            }
            else
            {
                for (int i = 0; i < k; i++)
                {
                    perm[i] = i;
                }
            }
            return perm;
        }

        public static StudentSchedule[] CopyStudents(StudentSchedule[] students)
        {
            // deep copy of student array
            StudentSchedule[] stud = new StudentSchedule[students.Length];
            for (int s = 0; s < students.Length; s++)
            {
                StudentSchedule copy = students[s];
                stud[s] = new StudentSchedule(copy.Student, (bool[])copy.Courses.Clone(), (int[])copy.ExamLength.Clone());
                for (int l = 0; l < copy.Schedule.Length; l++)
                {
                    stud[s].Schedule[l] = copy.Schedule[l];
                }
            }
            return stud;
        }

        public static StudentSchedule[] CopyStudentsInOrder(StudentSchedule[] students)
        {            
            StudentSchedule[] stud = new StudentSchedule[students.Length];
            int i = 0;
            List<StudentSchedule> qstud = new List<StudentSchedule>();
            qstud.AddRange(Utils.CopyStudents(students));            
            while (qstud.Count != 0)
            {
                StudentSchedule head = qstud[0];
                stud[i++] = head;
                qstud.RemoveAt(0);
                for (int s = 0; s < qstud.Count; s++ )
                {
                    StudentSchedule st = qstud[s];
                    if (head.equalCourses(qstud[s]))
                    {
                        stud[i++] = st;
                        qstud.RemoveAt(s);
                        s--;
                    }
                }
            }
            return stud;
        }

        public static void print(StudentSchedule[] studs, int days)
        {
            if (studs == null)
            {
                throw new ArgumentNullException();
            }
            
            for (int i = 0; i < days; i++)
            {
                Console.Write("DAY " + i + ": ");
                for (int j = 0; j < studs.Length; j++)
                {
                    char c;
                    int k = studs[j].Schedule[i];
                    if (k == -2)
                    {
                        c = '-';
                    }
                    else c = (char)((int)'0' + k);
                    Console.Write("{0} ", c);
                }
                Console.Write("\n");
            }
        }

        /*public static void pretty_print(StudentSchedule[] studs, int days, int courses, Model.Course[] courseList)
        {
            // expects a valid solution, no value < 0 as course allowed
            if (studs == null)
            {
                throw new ArgumentNullException();
            }

            string[] tage = new string[] { "MONTAG", "DIENSTAG", "DONNERSTAG", "FREITAG" };

            for (int i = 0; i < days; i++)
            {
                Console.Write("\n");
                Console.WriteLine(tage[i]);
                Console.Write("\n");
                IList<StudentSchedule>[] kurse = new IList<StudentSchedule>[courses];
                for (int c = 0; c < courses; c++)
                {
                    kurse[c] = new List<StudentSchedule>();
                }
                for (int j = 0; j < studs.Length; j++)
                {
                    int k = studs[j].Schedule[i];
                    if (k >= 0)
                    {
                        kurse[k].Add(studs[j]);
                    }
                    //Console.Write(students[j].schedule[i] + " ");
                }

                for (int c = 0; c < courses; c++)
                {
                    Console.Write("\n");
                    Console.WriteLine("* " + courseList[c].Name);
                    Console.Write("\n");
                    foreach (StudentSchedule stud in kurse[c])
                    {
                        Console.WriteLine(stud.Student.Name);
                    }
                }
                Console.Write("\n");
            }
        }*/   
    }
}
