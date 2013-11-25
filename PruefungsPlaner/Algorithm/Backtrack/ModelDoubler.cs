using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PruefungsPlaner.Model;

namespace PruefungsPlaner.Algorithm.Backtrack
{
    class ModelDoubler
    {
        public static InputModel doubleModel(InputModel model)
        {
            InputModel dmodel = new InputModel();
            dmodel.TaskTitle = "Gedoppelt: " + model.TaskTitle;
            dmodel.SlotModel = model.SlotModel;
            dmodel.Courses = model.Courses;
            
            dmodel.Students = model.Students.ToList();
            foreach (Student s in model.Students)
            {
                Student ds = new Student();
                ds.Name = s.Name + "(2)";
                ds.Exams = s.Exams.ToList();
                dmodel.Students.Add(ds);
            }

            dmodel.Teachers = model.Teachers.ToList();
            /*foreach (Teacher t in model.Teachers)
            {
                Teacher dt = new Teacher();
                dt.Name = t.Name + "(2)";
                dt.TimeSpans = t.TimeSpans.ToList();
                dmodel.Teachers.Add(dt);
            }*/

            return dmodel;
        }
    }
}
