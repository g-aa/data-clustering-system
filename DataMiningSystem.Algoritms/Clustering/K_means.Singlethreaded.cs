using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataMiningSystem.Algoritms.Math;
using DataMiningSystem.Data.Abstraction.Math;
using DataMiningSystem.Data.Enumerations;
using DataMiningSystem.Data.Realization.Information;
using DataMiningSystem.Data.Realization.Serializable;

namespace DataMiningSystem.Algoritms.Clustering
{
    internal static partial class K_means
    {
        internal static ClusteringResult Singlethreaded(IMathSet mathSet, ClusteringOptions options)
        {
            // выбор метрики для расчета:
            Func<IMathPoint, IMathPoint, Double> func = DataMiningMath.UsedMetrics(options.Distance);

            // инициализация центров кластеров для текущего шага расчета:
            List<IMathPoint> currentCenters = InitCenters(mathSet, options);

            // инициализация центров кластеров для предыдущего шага расчета:
            List<IMathPoint> prevCenters = new List<IMathPoint>(options.ClusterCount);

            // основной цикл обработки:
            Int32 iteration = 0;
            while (iteration++ <= options.MaxIterations)
            {
                // вычисление самого удачного центра для кластеров на рассматриваемой иттерации:
                mathSet.ForEach((IMathPoint point) => {
                    // поиск ближайшего кластера к точке:
                    Int32 closestIdx = -1;
                    Double minDistance = Double.MaxValue;
                    for (Int32 i = 0; i < currentCenters.Count; i++)
                    {
                        Double distance = func(point, currentCenters[i]);
                        if (minDistance > distance)
                        {
                            closestIdx = i;
                            minDistance = distance;
                        }
                    }

                    // обновляем центр выбраного кластера:
                    currentCenters[closestIdx] = DataMiningMath.MeanPoint(point, currentCenters[closestIdx]);
                });

                // кластеризация данных в соответствии с новыми центрами:
                mathSet.ForEach((IMathPoint point) => {
                    // поиск ближайшего кластера к точке:
                    IMathPoint closestCluster = null;
                    Double minDistance = Double.MaxValue;
                    for (Int32 i = 0; i < currentCenters.Count; i++)
                    {
                        Double distance = func(point, currentCenters[i]);
                        if (minDistance > distance)
                        {
                            closestCluster = currentCenters[i];
                            minDistance = distance;
                        }
                    }

                    // обновить кластер у точки:
                    point.Cluster = closestCluster.Cluster;
                });

                // проверка на выход из цикла:
                if (prevCenters.Count != 0)
                {
                    Boolean flag = true; // флаг прерывания расчета
                    // обход центров кластеризации:
                    for (Int32 i = 0; i < currentCenters.Count; i++)
                    {
                        // обход координат:
                        for (Int32 c = 0; c < currentCenters[i].CoordinatesCount; c++)
                        {
                            if (currentCenters[i][c] != prevCenters[i][c])
                            {
                                flag = false;
                                break;
                            }
                        }
                    }

                    if (flag)
                    {
                        break;
                    }
                }
                prevCenters = new List<IMathPoint>(currentCenters);
            }
            return new ClusteringResult(currentCenters, mathSet, iteration);
        }

        internal static List<IMathPoint> InitCenters(IMathSet mathSet, ClusteringOptions options)
        {
            IMathPoint minPoint = DataMiningMath.GetLimitPoint(mathSet, (Double c, Double p) => c > p);
            IMathPoint maxPoint = DataMiningMath.GetLimitPoint(mathSet, (Double c, Double p) => c < p);

            if (options.Initialization == InitializationType.RANDOM)
            {
                return GetRandomClusterCenters(minPoint, maxPoint, options);
            }
            else
            {
                throw new ArgumentException("поддерживаемый метод инициализации центров кластеризации: random");
            }
        }

        internal static List<IMathPoint> GetRandomClusterCenters(IMathPoint minPoint, IMathPoint maxPoint, ClusteringOptions options)
        {
            Random rnd = new Random();
            List<IMathPoint> startClusterPoints = new List<IMathPoint>(options.ClusterCount);

            // обход центров кластеризации:
            for (Int32 i = 0; i < options.ClusterCount; i++)
            {
                startClusterPoints.Add((IMathPoint)minPoint.Clone());

                // обход координат центра кластеризации:
                for (Int32 c = 0; c < startClusterPoints[i].CoordinatesCount; c++)
                {
                    startClusterPoints[i][c] = rnd.NextDouble() * (maxPoint[c] - minPoint[c]) + minPoint[c];
                }
                startClusterPoints[i].Class = string.Format("class {0}", i + 1);
                startClusterPoints[i].Cluster = string.Format("cluster {0}", i + 1);
            }
            return startClusterPoints;
        }
    }
}
