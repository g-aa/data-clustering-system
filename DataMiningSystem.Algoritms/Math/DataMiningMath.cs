using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataMiningSystem.Data.Abstraction.Math;
using DataMiningSystem.Data.Enumerations;

namespace DataMiningSystem.Algoritms.Math
{
    static internal class DataMiningMath
    {
        internal static Func<IMathPoint, IMathPoint, Double> UsedMetrics(DistanceMetricType metric)
        {
            switch (metric)
            {
                case DistanceMetricType.SQEUCLIDEAN:
                    return DataMiningMath.Euclidean;
                case DistanceMetricType.CITYBLOCK:
                    return DataMiningMath.Cityblock;
                case DistanceMetricType.COSINE:
                    return DataMiningMath.Cosine;
                case DistanceMetricType.CORRELATION:
                    return DataMiningMath.Correlation;
                case DistanceMetricType.HAMMING:
                    return DataMiningMath.Hamming;
                default:
                    throw new ArgumentException("был выбран неприемлемый параметр из enum DistanceMetricType");
            }
        }

        internal static void MetricEquals(IMathPoint p, IMathPoint c)
        {
            if (p != null && c != null)
            {
                if (p.CoordinatesCount.Equals(c.CoordinatesCount))
                {
                    return;
                }
                throw new ArgumentException("несоответствие размерностей обрабатываемых точек");
            }
            throw new ArgumentNullException("входной параметр IMathPoint равен null");
        }

        private static Double Euclidean(IMathPoint p, IMathPoint c)
        {
            DataMiningMath.MetricEquals(p, c);

            Double result = 0;
            for (Int32 i = 0; i < c.CoordinatesCount; i++)
            {
                result += (p[i] - c[i]) * (p[i] - c[i]);
            }
            return result;
        }

        private static Double Cityblock(IMathPoint p, IMathPoint c)
        {
            DataMiningMath.MetricEquals(p, c);

            Double result = 0;
            for (Int32 i = 0; i < c.CoordinatesCount; i++)
            {
                result += p[i] < c[i] ? c[i] - p[i] : p[i] - c[i];
            }
            return result;
        }

        private static Double Cosine(IMathPoint p, IMathPoint c)
        {
            DataMiningMath.MetricEquals(p, c);

            Double pc = 0, pp = 0, cc = 0;
            for (Int32 i = 0; i < c.CoordinatesCount; i++)
            {
                pc += p[i] * c[i];
                pp += p[i] * p[i];
                cc += c[i] * c[i];
            }
            return 1 - (pc / System.Math.Sqrt(pp * cc));
        }

        private static Double Correlation(IMathPoint p, IMathPoint c)
        {
            throw new NotImplementedException("метод Metrics.Distance.Correlation не реализован");
        }

        private static Double Hamming(IMathPoint p, IMathPoint c)
        {
            throw new NotImplementedException("метод Metrics.Distance.Hamming не реализован");
        }

        internal static IMathPoint MeanPoint(IMathPoint p, IMathPoint c)
        {
            DataMiningMath.MetricEquals(p, c);

            IMathPoint meanPoint = c.Clone() as IMathPoint;
            for (Int32 i = 0; i < c.CoordinatesCount; i++)
            {
                meanPoint[i] = 0.5 * (p[i] + c[i]);
            }
            return meanPoint;
        }

        internal static IMathPoint GetLimitPoint(IMathSet mathSet, Func<Double, Double, Boolean> comparisonFunc)
        {
            if (1 < mathSet.RowsCount)
            {
                IMathPoint limitPoint = mathSet[0].Clone() as IMathPoint;
                for (Int32 r = 0; r < mathSet.RowsCount; r++)
                {
                    for (Int32 c = 0; c < mathSet[r].CoordinatesCount; c++)
                    {
                        if (comparisonFunc(limitPoint[c], mathSet[r][c]))
                        {
                            limitPoint[c] = mathSet[r][c];
                        }
                    }
                }
                return limitPoint;
            }
            throw new ArgumentException("входной набор IMathSet должен содержать минимум 2 точки с данными");
        }

        internal static IMathPoint GetLimitPointParallel(IMathSet mathSet, Func<Double, Double, Boolean> comparisonFunc)
        {
            if (1 < mathSet.RowsCount)
            {
                IMathPoint limitPoint = mathSet[0].Clone() as IMathPoint;
                Parallel.For(0, mathSet.RowsCount, (Int32 r) =>
                {
                    for (Int32 c = 0; c < mathSet[r].CoordinatesCount; c++)
                    {
                        if (comparisonFunc(limitPoint[c], mathSet[r][c]))
                        {
                            lock (limitPoint)
                            {
                                limitPoint[c] = mathSet[r][c];
                            }
                        }
                    }
                });
                return limitPoint;
            }
            throw new ArgumentException("входной набор IMathSet должен содержать минимум 2 точки");
        }
    }
}
