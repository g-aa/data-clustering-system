using System;
using System.Collections.Generic;
using System.Text;

using DataMiningSystem.Data.Enumerations;

namespace DataMiningSystem.Data.Realization.Information
{
    [Serializable]
    public struct ClusteringOptions
    {
        private Int32 m_ClusterCount;
        public Int32 ClusterCount
        {
            get => this.m_ClusterCount;
            set
            {
                if (1 < value)
                {
                    this.m_ClusterCount = value;
                    return;
                }
                throw new ArgumentException("параметр ClusterCount может принимать значения больше 2");
            }
        }

        private Int32 m_MaxIterations;
        public Int32 MaxIterations
        {
            get => this.m_MaxIterations;
            set
            {
                if (19 < value)
                {
                    this.m_MaxIterations = value;
                    return;
                }
                throw new ArgumentException("параметр MaxIterations может принимать значения больше 20");
            }
        }

        public ModeType Mode { get; set; }

        public InitializationType Initialization { get; set; }

        public DistanceMetricType Distance { get; set; }

        public ClusteringOptions(Int32 clusters, Int32 iterations, ModeType algoritm, InitializationType initialization, DistanceMetricType distance)
            : this()
        {
            this.Mode = algoritm;
            this.ClusterCount = clusters;
            this.Distance = distance;
            this.Initialization = initialization;
            this.MaxIterations = iterations;
        }

        public static ClusteringOptions Default
        {
            get 
            {
                return new ClusteringOptions()
                {
                    Mode = ModeType.SINGLETHREADED,
                    ClusterCount = 2,
                    Distance = DistanceMetricType.SQEUCLIDEAN,
                    Initialization = InitializationType.RANDOM,
                    MaxIterations = 20
                };
            }
        }
    }
}
