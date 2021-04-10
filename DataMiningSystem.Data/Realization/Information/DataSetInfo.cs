using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMiningSystem.Data.Realization.Information
{
    [Serializable]
    public class DataSetInfo
    {
        public DateTime CreationDate { get; set; }
        public Int32 Dimension { get; set; }
        public Int32 PointsCount { get; set; }
        public String[] Classes { get; set; }
        public String[] Clusters { get; set; }
        public Dictionary<String, Int32> ClassesDistribution { get; set; }
        public Dictionary<String, Int32> ClustersDistribution { get; set; }

        public DataSetInfo()
        {
            this.Classes = new String[0];
            this.Clusters = new String[0];
            this.ClassesDistribution = new Dictionary<String, Int32>();
            this.ClustersDistribution = new Dictionary<String, Int32>();
        }

        public DataSetInfo(DataSetInfo info)
        {
            this.Classes = info.Classes;
            this.ClassesDistribution = info.ClassesDistribution;
            this.Clusters = info.Clusters;
            this.ClustersDistribution = info.ClustersDistribution;
            this.CreationDate = info.CreationDate;
            this.Dimension = info.Dimension;
            this.PointsCount = info.PointsCount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("информация о наборе данных:");
            // sb.AppendLine(string.Format("\t- дата создания: {0}", this.CreationDate.ToString()));
            sb.AppendLine(string.Format(" - число строк: {0}", this.PointsCount));
            sb.AppendLine(string.Format(" - число колонок: {0}", this.Dimension));
            sb.AppendLine(string.Format(" - классы: {0}", string.Join(", ", this.Classes)));
            // sb.AppendLine(string.Format("\t- кластеры: {0}", string.Join(", ", this.Clusters)));
            sb.AppendLine(string.Format(
                " - распределение данных по классам: {0}",
                string.Join(", ", this.ClassesDistribution.Select(kvp => 
                { 
                    return string.Format("{0} - {1}", kvp.Key, kvp.Value); 
                }))
            ));
            sb.AppendLine(string.Format(
                " - распределение данных по кластерам: {0}",
                string.Join(", ", this.ClustersDistribution.Select(kvp =>
                {
                    return string.Format("{0} - {1}", kvp.Key, kvp.Value);
                }))
            ));
            return sb.ToString();
        }
    }
}
