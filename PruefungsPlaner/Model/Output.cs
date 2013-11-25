using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PruefungsPlaner.Model
{
    class Output
    {
        public readonly XDocument doc;
        private static XNamespace ss = "urn:schemas-microsoft-com:office:spreadsheet";
        private static XElement emptyCell = new XElement(ss + "Cell");
        private const int cols = 5;
        private int rows = 0;

        public Output(Solution solution, InputModel model)
        {
            if (solution == null)
            {
                //throw new ArgumentException();
                solution = new Solution();
            }
            List<Exam> exams = new List<Exam>();
            exams.AddRange(solution.Exams);

            doc = XDocument.Load(@"..\..\OutputTemplate.xml");
            Console.WriteLine("NS:" + doc.Root.GetDefaultNamespace().NamespaceName);
            //Console.WriteLine(doc);            

            
            Console.WriteLine(doc.Root.Element(ss + "Worksheet"));

            XElement table = new XElement(ss + "Table");
           
            doc.Root.Element(ss + "Worksheet").Add(table);
            addColumn(table, 1, 40);
            addColumn(table, 2, 9);
            addColumn(table, 3, 40);
            addColumn(table, 4, 10);
            addColumn(table, 5, 200);

            TimeSlotModel tmodel = model.SlotModel;
            int daysY = daysInYear(tmodel.SlotToTime(0).Year);
            DateTime fDay = tmodel.SlotToTime(0);
            int firstDay = fDay.DayOfYear;
            int lastDay = tmodel.SlotToTime(model.MaxTimeSlot).DayOfYear;
            lastDay = lastDay < firstDay ? lastDay + daysY : lastDay;

            addRow(table, cell(model.TaskTitle, "bold"));
               

            for (int day = firstDay; day <= lastDay; day++)
            {
                List<Exam> exdayReducible = exams.FindAll(x => tmodel.SlotToTime(x.TimeSlot).DayOfYear == (day % daysY));
                if (exdayReducible.Count == 0)
                {
                    continue;
                }

                String dateString = String.Format("{0:D}", fDay.AddDays(day - firstDay));
                addRow(table);
                addRow(table);
                addRow(table, cell(dateString, "bold+underline"));               

                while(exdayReducible.Count != 0)
                {
                    Exam e1 = exdayReducible[0];
                    List<Exam> excourse = exdayReducible.FindAll(x => x.Course == e1.Course);
                    List<Exam> excourseReducible = excourse.ToList();

                    addRow(table);
                    addRow(table, cell(e1.Course.Name, "bold"));

                    while(excourseReducible.Count != 0)
                    {
                        Exam e2 = excourseReducible[0];
                        List<Exam> exteacher = excourseReducible.FindAll(x => x.Teacher == e2.Teacher);
                                                
                        addRow(table, cell(e1.Teacher.Name));

                        int lastSlot = e2.TimeSlot;
                        foreach (Exam e in exteacher)
                        {
                            if (e.TimeSlot - lastSlot >= e.Course.DefaultExamLength - e.Course.PrepareTime)
                            {
                                //Coffee Break
                                addRow(table);
                            }

                            String additional = e.GetConstraints().AdditionalDescription;
                            additional = additional != null ? " [" + additional + "]" : "";
                            XElement name = cell(e.Student.Name + additional);

                            lastSlot = e.TimeSlot + e.GetConstraints().ExamLength;
                            DateTime t1 = tmodel.SlotToTime(e.TimeSlot);
                            DateTime t2 = tmodel.SlotToTime(lastSlot);
                            addRow(table, time(t1), cell("-"), time(t2), emptyCell, name);
                        }
                        excourseReducible.RemoveAll(a => exteacher.Contains(a));
                    }
                    exdayReducible.RemoveAll(a => excourse.Contains(a));
                }
            }
            

            table.SetAttributeValue(ss + "ExpandedRowCount", rows);
            table.SetAttributeValue(ss + "ExpandedColumnCount", cols);

            /*XElement dat = new XElement(ss + "Data", "Horst");
            dat.SetAttributeValue(ss + "Type", "String");
            row = new XElement(ss + "Row", new XElement(ss + "Cell", dat));
            table.Add(row);*/



            doc.Save(@"..\..\TestOutput.xml");
        }        

        private XElement cell(string s, string style = null)
        {
            XAttribute stringAttr = new XAttribute(ss + "Type", "String");
            if (style != null)
            {
                return new XElement(ss + "Cell", new XAttribute(ss + "StyleID", style), new XElement(ss + "Data", stringAttr, s));
            }
            else
            {
                return new XElement(ss + "Cell", new XElement(ss + "Data", stringAttr, s));
            }
        }       

        private XElement time(DateTime t, string style = null)
        {
            XAttribute timeAttr = new XAttribute(ss + "Type", "DateTime");
            return new XElement(ss + "Cell", new XAttribute(ss + "StyleID", "time"), new XElement(ss + "Data", timeAttr, "1899-12-31T" + String.Format("{0:t}", t) + ":00.000"));
        }

        private void addRow(XElement table, params XElement[] row)
        {
            XElement[] cells = new XElement[cols];
            
            for (int i = 0;i<cols;i++)
            {
                cells[i] = i<row.Length?row[i]:emptyCell;

            }

            table.Add(new XElement(ss + "Row", cells));
            rows++;
        }

        private void addColumn(XElement table, int index, int width)
        {
            table.Add(new XElement(ss + "Column", new XAttribute(ss + "Index", index), new XAttribute(ss + "Width", width)));
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
