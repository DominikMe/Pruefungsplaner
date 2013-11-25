using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PruefungsPlaner.Model
{
    public class InputModel
    {
        public string TaskTitle;
        public List<Student> Students=new List<Student>();
        public List<Course> Courses = new List<Course>();
        public List<Teacher> Teachers = new List<Teacher>();
        public TimeSlotModel SlotModel;

        private int maxTimeSlot = -1;
        public int MaxTimeSlot
        {
            get {
                if (maxTimeSlot == -1)
                {
                    foreach (var t in Teachers)
                    {
                        foreach (var ts in t.TimeSpans)
                        {
                            if (maxTimeSlot < ts.EndSlot)
                            {
                                maxTimeSlot = ts.EndSlot;
                            }
                        }
                    }
                }
                return maxTimeSlot;
            }
        }

        public static InputModel FromFile(string xmlFilePath)
        {
            InputModel m = new InputModel();
            m.Load(xmlFilePath);
            return m;
        }

        private void Load(string xmlFilePath)
        {
            XDocument doc = XDocument.Load(xmlFilePath);

            TaskTitle = doc.Root.Element("Settings").Element("TaskTitle").Value;
            int timeSlotLength = int.Parse(doc.Root.Element("Settings").Element("TimeSlotLength").Value);
            DateTime startTime = DateTime.Parse(doc.Root.Element("Settings").Element("StartTime").Value);
            SlotModel = new TimeSlotModel(timeSlotLength, startTime);

            Dictionary<string,Teacher> teachersHash=new Dictionary<string,Teacher>();
            
            foreach (XElement teacher in doc.Root.Element("TeacherList").Elements("Teacher"))
            {
                Teacher t = new Teacher();
                Teachers.Add(t);

                string id =teacher.Attribute("id").Value;
                teachersHash.Add(id.Trim(), t);
                t.Name=teacher.Element("Name").Value;
                foreach (var timeSpan in teacher.Element("AvailableTimeSpanList").Elements("TimeSpan"))
                {
                    t.TimeSpans.Add(SlotModel.CreateSlotTimeSpan(DateTime.Parse(timeSpan.Element("StartTime").Value),DateTime.Parse(timeSpan.Element("EndTime").Value)));
                }                
            }

            Dictionary<string, Course> coursesHash = new Dictionary<string, Course>();

            foreach (XElement course in doc.Root.Element("CourseList").Elements("Course"))
            {
                Course c = new Course();
                Courses.Add(c);
                string id =course.Attribute("id").Value;
                coursesHash.Add(id.Trim(), c);

                c.Name=course.Element("Name").Value;
                foreach (var teacherRef in course.Element("TeacherList").Elements("TeacherRef").Select<XElement,string>(x=>x.Value))
                {
                    c.TeacherList.Add(teachersHash[teacherRef.Trim()]);                        
                }
                c.DefaultExamLength = int.Parse(course.Element("DefaultExamLength").Value);
                c.PrepareTime= int.Parse(course.Element("PrepareTime").Value);
            }

            foreach (var student in doc.Root.Element("StudentList").Elements("Student"))
            {
                Student s = new Student();
                Students.Add(s);
                s.Name = student.Element("Name").Value;
                foreach (var exam in student.Element("ExamList").Elements("Exam"))
                {
                    ExamConstraint examConstraint = new ExamConstraint();
                    examConstraint.Course = coursesHash[exam.Element("CourseRef").Value.Trim()];
                    if (exam.Element("AdditionalInformation") != null)
                    {
                        if (exam.Element("AdditionalInformation").Element("ExamLength") != null)
                            examConstraint.CustomExamLength=int.Parse(exam.Element("AdditionalInformation").Element("ExamLength").Value);                        
                        if (exam.Element("AdditionalInformation").Element("Description") != null)
                            examConstraint.AdditionalDescription= exam.Element("AdditionalInformation").Element("Description").Value;
                    }
                    s.Exams.Add(examConstraint);
                }

            }
            
        }
    }
}
