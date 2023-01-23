using System.Collections.Generic;

namespace APIClient.AQ1.Model
{
    public class ZoneMetric
    {
        public string zone { get; set; }
        public List<Metric> metric { get; set; }
    }
}
