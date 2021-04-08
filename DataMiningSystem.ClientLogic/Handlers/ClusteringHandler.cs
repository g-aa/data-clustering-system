using DataMiningSystem.Algoritms.Facade;
using DataMiningSystem.Data.Abstraction.Math;
using DataMiningSystem.Data.Enumerations;
using DataMiningSystem.Data.Realization.Information;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMiningSystem.ClientLogic.Handlers
{
    public class ClusteringHandler
    {
        private Stopwatch m_sw;

        public Int64 CalculationTime { get; private set; }

        public ClusteringResult Result { get; private set; }

        public AlgorithmType Algorithm { get; set; }

        public ClusteringHandler()
        {
            this.m_sw = new Stopwatch();
            this.Algorithm = AlgorithmType.KMEANS;
        }

        public void Run(IMathSet mathSet, ClusteringOptions options)
        {
            this.m_sw.Restart();
            switch (this.Algorithm)
            {
                case AlgorithmType.KMEANS:
                    this.Result = ClusteringFacade.Kmeans(mathSet, options);
                    break;
                case AlgorithmType.KMEDOIDS:
                    this.Result = ClusteringFacade.Kmedoids(mathSet, options);
                    break;
                default:
                    throw new ArgumentException("выбран не используемый (не реализованный) алгоритм");
            }
            this.m_sw.Stop();
            this.CalculationTime = this.m_sw.ElapsedMilliseconds;
        }
    }
}
