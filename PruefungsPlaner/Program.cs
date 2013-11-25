using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PruefungsPlaner.Model;

namespace PruefungsPlaner
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new GUI.GUI());
            
            ////var model = InputModel.FromFile(@"C:\Users\Chris\documents\visual studio 2010\Projects\PruefungsPlaner\PruefungsPlaner\Data\InputData2010-05.xml");
            //var model = InputModel.FromFile(@"..\..\Data\InputData2010-05.xml");
            //Console.WriteLine("Model loaded");

            ////InputModel dmodel = Algorithm.Backtrack.ModelDoubler.doubleModel(model);
            //Algorithm.Backtrack.Algorithm solver = new Algorithm.Backtrack.Algorithm(model);

            //Solution sol = solver.Run(model);
            //Console.WriteLine("Output to xml");
            //Console.ReadLine();
            //new Output(sol, model);
        }
    }
}
