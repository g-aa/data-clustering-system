using System;
using System.Collections.Generic;
using System.Text;

namespace DataMiningSystem.Data.Realization.Serializable
{
    [Serializable]
    public class SerializablePoint
    {
        public Double[] Coordinates { get; set; }
        public String Class { get; set; }
        public String Cluster { get; set; }

        public SerializablePoint()
        {
            this.Coordinates = new Double[0];
        }
    }
}
