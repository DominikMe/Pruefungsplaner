using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PruefungsPlaner.Model;
namespace PruefungsPlaner.Algorithm
{
    interface IAlgorithm
    {
        Solution Run(InputModel model); 
    }
}
