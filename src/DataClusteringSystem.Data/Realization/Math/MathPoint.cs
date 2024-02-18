using System;
using System.Collections.Generic;

using DataClusteringSystem.Data.Abstraction.Math;
using DataClusteringSystem.Data.Realization.Serializable;

namespace DataClusteringSystem.Data.Realization.Math
{
    public class MathPoint : IMathPoint
    {
        private readonly List<double> m_coordinates;
        public double this[int col]
        {
            get => this.m_coordinates[col];
            set => this.m_coordinates[col] = value;
        }
        public int CoordinatesCount
        {
            get => this.m_coordinates.Count;
        }

        private string m_class;
        public string Class
        {
            get => this.m_class;
            set => this.m_class = value != null ? value : this.m_class;
        }

        private string m_cluster;
        public string Cluster
        {
            get => this.m_cluster;
            set => this.m_cluster = value != null ? value : this.m_cluster;
        }

        public MathPoint(double[] coordinates, string classType, string clusterType)
        {
            if (coordinates != null)
            {
                this.m_coordinates = new List<double>(coordinates);
                this.Class = classType;
                this.Cluster = clusterType;
                return;
            }
            throw new ArgumentNullException("входной параметр coordinates равен null");
        }

        public MathPoint(IMathPoint point)
        {
            if (point != null)
            {
                this.m_coordinates = new List<double>(point.CoordinatesCount);
                for (int c = 0; c < point.CoordinatesCount; c++)
                {
                    this.m_coordinates.Add(point[c]);
                }

                this.m_class = point.Class;
                this.m_cluster = point.Cluster;
                return;
            }
            throw new ArgumentNullException("входной параметр point равен null");
        }

        public MathPoint(SerializablePoint point)
        {
            if (point != null)
            {
                this.m_coordinates = new List<double>(point.Coordinates.Length);
                Array.ForEach(point.Coordinates, (double d) => { this.m_coordinates.Add(d); });
                this.Class = point.Class;
                this.Cluster = point.Cluster;
                return;
            }
            throw new ArgumentNullException("входной параметр point равен null");
        }

        public object Clone()
        {
            return new MathPoint(this);
        }

        public SerializablePoint SerializablePoint
        {
            get
            {
                return new SerializablePoint()
                {
                    Coordinates = this.m_coordinates.ToArray(),
                    Class = this.m_class,
                    Cluster = this.m_cluster
                };
            }
        }

        public override string ToString()
        {
            return string.Format("point [x: {0}; class: {1}; cluster: {2}]", string.Join(", ", this.m_coordinates), this.m_class, this.m_cluster);
        }
    }
}