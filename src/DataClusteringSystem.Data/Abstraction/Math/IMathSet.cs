using System;

using DataClusteringSystem.Data.Realization.Information;
using DataClusteringSystem.Data.Realization.Serializable;

namespace DataClusteringSystem.Data.Abstraction.Math
{
    public interface IMathSet
    {
        IMathPoint this[Int32 row] { get; set; }

        Int32 RowsCount { get; }

        Int32 CoordinatesCount { get; }

        String[] Classes { get; }

        SerializableSet SerializableSet { get; }

        DataSetInfo SetInformation { get; }

        void Add(IMathPoint mathPoint);

        IMathPoint Remove(Int32 row);
        
        void ForEach(Action<IMathPoint> action);
    }
}