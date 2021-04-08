using System;
using System.Collections.Generic;
using System.Text;

using DataMiningSystem.Data.Abstraction.Math;

namespace DataMiningSystem.Data.Realization.Information
{
    public class ClusteringResult
    {
        public List<IMathPoint> Centers { get; }

        public IMathSet MathSet { get; }

        public Int32 IterationCounter { get; }

        public ClusteringResult(List<IMathPoint> centers, IMathSet mathSet, Int32 iteration)
        {
            this.Centers = centers;
            this.MathSet = mathSet;
            this.IterationCounter = iteration;
        }
    }
}
