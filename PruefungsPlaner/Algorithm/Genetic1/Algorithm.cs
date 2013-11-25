using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PruefungsPlaner.Model;

namespace PruefungsPlaner.Algorithm.Genetic1
{
    class Algorithm : IAlgorithm
    {
        public Model.Solution Run(InputModel model)
        {
            return new Solution();
        }
    }
}
