using System;
using System.Collections.Generic;

using DataClusteringSystem.Data.Abstraction.Math;

namespace DataClusteringSystem.Data.Realization.Information
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