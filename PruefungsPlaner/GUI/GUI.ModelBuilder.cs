using PruefungsPlaner.Model;
using System.Windows.Forms;

namespace PruefungsPlaner.GUI
{
    partial class GUI
    {
        private InputModel buildModel()
        {
            InputModel model = new InputModel();
            model.TaskTitle = tbExaminationTitle.Text;
            foreach(DataGridViewRow row in dgvCourses.Rows)
            {
                if (!row.IsNewRow)
                {
                    Course course = new Course();
                    course.Name = row.Cells[0].Value as string;
                    course.DefaultExamLength = int.Parse(row.Cells[1].Value as string, System.Globalization.NumberStyles.None);
                    course.PrepareTime = int.Parse(row.Cells[2].Value as string, System.Globalization.NumberStyles.None);                    
                    model.Courses.Add(course);
                }
            }

            foreach (DataGridViewRow row in dgvStudentsCourses.Rows)
            {
                Student stud = new Student();
                stud.Name = row.Cells[0].Value as string;
                for (int i = 1; i < dgvStudentsCourses.ColumnCount; i++)
                {
                    string course = dgvStudentsCourses.Columns[i].HeaderText;
                    if ((bool) row.Cells[i].Value)
                    {
                        Course c = model.Courses.Find(x => x.Name.Equals(course));
                        ExamConstraint exam = new ExamConstraint();
                        exam.Course = c;
                        stud.Exams.Add(exam);                        
                    }
                }
                //TODO Custom attributes
                model.Students.Add(stud);
            }

            foreach (GroupBox teacher in teacherTimeSpans)
            {
                foreach (DataGridViewRow row in ((DataGridView) teacher.Controls[0]).Rows)
                {
                    Teacher t = new Teacher();
                    t.Name = teacher.Text;
                    SlotTimeSpan span = new SlotTimeSpan();

                    stud.Name = row.Cells[0].Value as string;
                    for (int i = 1; i < dgvStudentsCourses.ColumnCount; i++)
                    {
                        string course = dgvStudentsCourses.Columns[i].HeaderText;
                        if ((bool)row.Cells[i].Value)
                        {
                            Course c = model.Courses.Find(x => x.Name.Equals(course));
                            ExamConstraint exam = new ExamConstraint();
                            exam.Course = c;
                            stud.Exams.Add(exam);
                        }
                    }
                    //TODO Custom attributes
                    model.Students.Add(stud);
                }
            }

            return null;
        }
    }
}
