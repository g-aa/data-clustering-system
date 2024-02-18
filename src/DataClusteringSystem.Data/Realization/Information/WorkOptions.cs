﻿using System;

using DataClusteringSystem.Data.Enumerations;

namespace DataClusteringSystem.Data.Realization.Information
{
    [Serializable]
    public struct WorkOptions
    {
        public string DataSetName { get; set; }
        public AlgorithmType Algorithm { get; set; }
        public ClusteringOptions Options { get; set; }

        public WorkOptions(string dsName, AlgorithmType aType, ClusteringOptions cOptions)
        {
            this.DataSetName = dsName;
            this.Algorithm = aType;
            this.Options = cOptions;
        }

        public static WorkOptions Default
        {
            get
            {
                return new WorkOptions()
                {
                    Algorithm = AlgorithmType.KMEANS,
                    DataSetName = string.Empty,
                    Options = ClusteringOptions.Default
                };
            }
        }
    }
}