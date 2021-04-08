using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMiningSystem.Data.Realization.Information;
using DataMiningSystem.Data.Realization.Serializable;

namespace DataMiningSystem.Data.Abstraction.Math
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
