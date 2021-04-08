using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataMiningSystem.Data.Realization.Serializable;

namespace DataMiningSystem.Data.Abstraction.Math
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
