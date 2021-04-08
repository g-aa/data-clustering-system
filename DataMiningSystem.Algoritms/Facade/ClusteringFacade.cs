using System;
using System.Collections.Generic;
using System.Text;

using DataMiningSystem.Algoritms.Clustering;
using DataMiningSystem.Data.Abstraction.Math;
using DataMiningSystem.Data.Enumerations;
using DataMiningSystem.Data.Realization.Information;
using DataMiningSystem.Data.Realization.Serializable;

namespace DataMiningSystem.Algoritms.Facade
{
    public static class ClusteringFacade
    {
        public static ClusteringResult Kmeans(IMathSet mathSet, ClusteringOptions options)
        {
            if (mathSet != null)
            {
                if (options.ClusterCount <= mathSet.RowsCount) 
                {
                    switch (options.Mode)
                    {
                        case ModeType.SINGLETHREADED:
                            return K_means.Singlethreaded(mathSet, options);
                        case ModeType.MULTITHREADED:
                            return K_means.Multithreaded(mathSet, options);
                        default:
                            throw new ArgumentException("был выбран неприемлемый параметр из enum AlgoritmType");
                    }
                }
                throw new ArgumentException("количество точек с данными в input Set должно быть больше или равно количества кластеров в options");
            }
            throw new ArgumentNullException("входной набор данных inputSet равен null");
        }

        public static ClusteringResult Kmedoids(IMathSet mathSet, ClusteringOptions options)
        {
            if (mathSet != null)
            {
                if (options.ClusterCount <= mathSet.RowsCount)
                {
                    switch (options.Mode)
                    {
                        case ModeType.SINGLETHREADED:
                            return K_medoids.Singlethreaded(mathSet, options);
                        case ModeType.MULTITHREADED:
                            return K_medoids.Multithreaded(mathSet, options);
                        default:
                            throw new ArgumentException("был выбран неприемлемый параметр из enum AlgoritmType");
                    }
                }
                throw new ArgumentException("количество точек с данными в input Set должно быть больше или равно количества кластеров в options");
            }
            throw new ArgumentNullException("входной набор данных inputSet равен null");
        }
    }
}
