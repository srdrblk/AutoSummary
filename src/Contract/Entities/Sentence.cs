using System;
using System.Collections.Generic;

namespace Contract
{
    public class Sentence
    {
        public string Line { get; private set; }
        public int NumberOfLines { get; private set; }

        public double Score { get; private set; }

        public Sentence(string line, int numberOfLine, List<string> subsetsOfTitle)
        {
            Line = line;
            NumberOfLines = numberOfLine;
            CalculateUsedScore(subsetsOfTitle);
        }


        private void CalculateUsedScore(List<string> subsetsOfTitle)
        {
            foreach (var subsetOfTitle in subsetsOfTitle)
            {
                if (Line.Contains(subsetOfTitle))
                {
                    Score++;
                }
            }
        }
    }
}
