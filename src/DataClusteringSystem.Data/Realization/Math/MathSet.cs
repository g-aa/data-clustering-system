using System;
using System.Collections.Generic;
using System.Linq;

using DataClusteringSystem.Data.Abstraction.Math;
using DataClusteringSystem.Data.Realization.Information;
using DataClusteringSystem.Data.Realization.Serializable;

namespace DataClusteringSystem.Data.Realization.Math
{
    public class MathSet : IMathSet
    {
        private readonly List<IMathPoint> m_points;
        public IMathPoint this[int row]
        {
            get => this.m_points[row];
            set
            {
                this.CheckInputPoint(value);
                this.m_points[row] = value;
                if (!this.m_classes.Contains(value.Class))
                {
                    this.m_classes.Add(value.Class);
                }
            }
        }

        public int RowsCount
        {
            get => this.m_points.Count;
        }

        private readonly int m_coordinatesCount;
        public int CoordinatesCount
        {
            get => this.m_coordinatesCount;
        }

        private readonly List<string> m_classes;
        public string[] Classes
        {
            get => this.m_classes.ToArray();
        }

        public MathSet(uint coordinatesCount)
        {
            if (0 < coordinatesCount)
            {
                this.m_coordinatesCount = (int)coordinatesCount;
                this.m_classes = new List<string>();
                this.m_points = new List<IMathPoint>();

                return;
            }

            throw new ArgumentException("количество координат у точки не может быть меньше единицы");
        }

        public void Add(IMathPoint mathPoint)
        {
            this.CheckInputPoint(mathPoint);
            if (!this.m_points.Equals(mathPoint))
            {
                this.m_points.Add(mathPoint);
                if (!this.m_classes.Contains(mathPoint.Class))
                {
                    this.m_classes.Add(mathPoint.Class);
                }
            }
        }

        public IMathPoint Remove(Int32 row)
        {
            IMathPoint point = this.m_points[row];
            this.m_points.RemoveAt(row);
            return point;
        }

        public SerializableSet SerializableSet
        {
            get
            {
                SerializableSet outSet = new SerializableSet();
                this.ForEach((IMathPoint p) => { outSet.Points.Add(p.SerializablePoint); });
                return outSet;
            }
        }

        public DataSetInfo SetInformation
        {
            get
            {
                return new DataSetInfo()
                {
                    Classes = this.m_classes.ToArray(),
                    ClassesDistribution = this.m_points.GroupBy(p => p.Class).ToDictionary(kvp => kvp.Key, kvp => kvp.Count()),
                    ClustersDistribution = this.m_points.GroupBy(p => p.Cluster).ToDictionary(kvp => kvp.Key, kvp => kvp.Count()),
                    PointsCount = this.RowsCount,
                    Dimension = this.CoordinatesCount
                };
            }
        }

        private void CheckInputPoint(IMathPoint mathPoint)
        {
            if (mathPoint != null)
            {
                if (mathPoint.CoordinatesCount.Equals(this.m_coordinatesCount))
                {
                    return;
                }
                throw new ArgumentException("количество координат новой точки не соответствует количеству координат точек из набора");
            }
            throw new ArgumentNullException("входной параметр IMathPoint равен null");
        }

        public void ForEach(Action<IMathPoint> action)
        {
            this.m_points.ForEach(action);
        }
    }
}