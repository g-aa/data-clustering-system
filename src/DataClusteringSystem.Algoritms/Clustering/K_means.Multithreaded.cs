using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DataClusteringSystem.Algoritms.Math;
using DataClusteringSystem.Data.Abstraction.Math;
using DataClusteringSystem.Data.Realization.Information;

namespace DataClusteringSystem.Algoritms.Clustering
{
    internal static partial class K_means
    {
        internal static ClusteringResult Multithreaded(IMathSet mathSet, ClusteringOptions options)
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
                Parallel.For(0, mathSet.RowsCount, (Int32 r) =>
                {
                    // поиск ближайшего кластера к точке:
                    Int32 closestIdx = -1;
                    Double minDistance = Double.MaxValue;
                    for (Int32 i = 0; i < currentCenters.Count; i++)
                    {
                        Double distance = func(mathSet[r], currentCenters[i]);
                        if (minDistance > distance)
                        {
                            closestIdx = i;
                            minDistance = distance;
                        }
                    }

                    // обновляем центр выбраного кластера:
                    lock (currentCenters)
                    {
                        currentCenters[closestIdx] = DataMiningMath.MeanPoint(mathSet[r], currentCenters[closestIdx]);
                    }
                });

                // кластеризация данных в соответствии с новыми центрами:
                Parallel.For(0, mathSet.RowsCount, (Int32 r) =>
                {
                    // поиск ближайшего кластера к точке:
                    IMathPoint closestCluster = null;
                    Double minDistance = Double.MaxValue;
                    for (Int32 i = 0; i < currentCenters.Count; i++)
                    {
                        Double distance = func(mathSet[r], currentCenters[i]);
                        if (minDistance > distance)
                        {
                            closestCluster = currentCenters[i];
                            minDistance = distance;
                        }
                    }

                    // обновить кластер у точки:
                    mathSet[r].Cluster = closestCluster.Cluster;
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
    }
}