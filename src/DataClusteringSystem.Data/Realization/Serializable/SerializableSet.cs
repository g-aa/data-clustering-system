using System;
using System.Collections.Generic;

namespace DataClusteringSystem.Data.Realization.Serializable
{
    [Serializable]
    public class SerializableSet
    {
        public String SetName { get; set; }
        public List<String> Titles { get; set; } 
        public List<SerializablePoint> Points { get; set; }

        public SerializableSet()
        {
            this.SetName = String.Empty;
            this.Titles = new List<String>();
            this.Points = new List<SerializablePoint>();
        }
    }
}