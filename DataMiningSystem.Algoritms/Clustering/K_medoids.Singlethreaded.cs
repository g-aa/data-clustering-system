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
    internal static partial class K_medoids
    {
        internal static ClusteringResult Singlethreaded(IMathSet mathSet, ClusteringOptions options)
        {
            // выбор метрики для расчета:
            Func<IMathPoint, IMathPoint, Double> func = DataMiningMath.UsedMetrics(options.Distance);

            // построение всех medoids для входного набора данных:
            Double[,] allMedoids = new Double[mathSet.RowsCount, mathSet.RowsCount];
            for (Int32 row = 0; row < mathSet.RowsCount; row++)
            {
                for (Int32 col = 0; col < mathSet.RowsCount; col++)
                {
                    if (row != col)
                    {
                        allMedoids[row, col] = func(mathSet[row], mathSet[col]);
                    }
                }
            }

            // выбор центров кластеризации (случайная инициализация):
            Random random = new Random();
            Dictionary<String, Int32> cIndexes = new Dictionary<String, Int32>(options.ClusterCount);
            Dictionary<String, List<Int32>> cDistributions = new Dictionary<String, List<Int32>>();
            for (Int32 i = 0; i < options.ClusterCount; i++)
            {
                String name = "Cluster " + (i + 1);
                cIndexes.Add(name, random.Next(mathSet.RowsCount));
                cDistributions.Add(name, new List<Int32>());
            }

            // первый этап предварительное связывание точек с центрами:
            Double newCost = 0;
            for (Int32 row = 0; row < mathSet.RowsCount; row++)
            {
                String name = "";
                Double minDistance = Double.MaxValue;

                // обход центров кластеризации:
                foreach (KeyValuePair<String, Int32> cluster in cIndexes)
                {
                    if (minDistance > allMedoids[row, cluster.Value])
                    {
                        name = cluster.Key;
                        minDistance = allMedoids[row, cluster.Value];
                    }
                }

                // подсчет текущей стоймости:
                newCost += minDistance;

                // добавить точку в распределение:
                cDistributions[name].Add(row);
            }

            // основной цикл обработки:
            Int32 iteration = 0;
            Double prevCost;
            while (iteration++ <= options.MaxIterations)
            {
                // выбрать новые центры из ранее полученного распределения:
                prevCost = newCost;
                newCost = 0;
                Dictionary<String, Int32> newIndexes = new Dictionary<string, int>(options.ClusterCount);
                Dictionary<String, List<Int32>> newDistribution = new Dictionary<String, List<Int32>>();
                foreach (KeyValuePair<string, int> cIndex in cIndexes)
                {
                    // newIndexes.Add(cIndex.Key, random.Next(mathSet.RowsCount));
                    newIndexes.Add(cIndex.Key, cDistributions[cIndex.Key][random.Next(cDistributions[cIndex.Key].Count)]);
                    newDistribution.Add(cIndex.Key, new List<Int32>());
                }

                // повторное связывание:
                for (Int32 row = 0; row < mathSet.RowsCount; row++)
                {
                    String name = "";
                    Double minDistance = Double.MaxValue;

                    // обход центров кластеризации:
                    foreach (KeyValuePair<String, Int32> cluster in newIndexes)
                    {
                        if (minDistance > allMedoids[row, cluster.Value])
                        {
                            name = cluster.Key;
                            minDistance = allMedoids[row, cluster.Value];
                        }
                    }

                    // подсчет текущей стоймости:
                    newCost += minDistance;

                    // добавить точку в распределение:
                    newDistribution[name].Add(row);
                }

                // проверка на выход из цикла:
                Double dCost = newCost - prevCost;
                if (dCost > 0)
                {
                    break;
                }
                cDistributions = newDistribution;
                cIndexes = newIndexes;
            }

            // маркировка данных по кластерам:
            foreach (KeyValuePair<string, List<int>> distribution in cDistributions)
            {
                foreach (Int32 index in distribution.Value)
                {
                    mathSet[index].Cluster = distribution.Key;
                }
            }

            // получение центро клстеризации:
            List<IMathPoint> centers = new List<IMathPoint>();
            foreach (KeyValuePair<string, int> index in cIndexes)
            {
                centers.Add(mathSet[index.Value]);
            }

            return new ClusteringResult(centers, mathSet, iteration);
        }
    }
}
