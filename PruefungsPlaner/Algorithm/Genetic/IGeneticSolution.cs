using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PruefungsPlaner.Model;

namespace PruefungsPlaner.Algorithm.Genetic
{
    
    public class GeneticSolutionBase<B>where B:GeneticSolutionBase<B>
    {

        protected class CostCalc { 
            public Func<int> Calc;
            public double CostFactor;
        }

        public InputModel Model;

        public GeneticSolutionBase(InputModel m)
        {
            Model = m;
        }

        private bool costsInCache = false;
        private double costCache = 0;

        private List<CostCalc> costCalculations;
        protected List<CostCalc> setUpCostCalc()
        {
            return new List<CostCalc>();
        }

        public double GetCosts()
        {
            if (costsInCache)
                return costCache;
            double costs = 0;
            foreach (var c in costCalculations)
            {
                costs += c.Calc() * c.CostFactor;
            }
            costCache = costs;
            costsInCache = true;
            return costCache;
        }


        virtual protected B Mutate() {return null;}
        virtual protected B Combine(B v) {return null;}
    }
}
