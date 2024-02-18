using System;

using DataClusteringSystem.Data.Realization.Serializable;

namespace DataClusteringSystem.Data.Abstraction.Math
{
    public interface IMathPoint : ICloneable
    {
        Double this[Int32 col] { get; set; }

        String Class { get; set; }

        String Cluster { get; set; }

        Int32 CoordinatesCount { get; }

        SerializablePoint SerializablePoint { get; }
    }
}