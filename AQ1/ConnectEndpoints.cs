using APIClient.AQ1.Model;
using APIClient.CommonUtils.Resources;
using APIClient.CommonUtils.Services;
using APICliente.AQ1.EndPoint;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ApiClient.AQ1
{
    public class ConnectEndpoints
    {
        private string Zone;
        private bool isSSLHostEndpoint;
        private string HostEndpoint;
        private string HostDatabase;
        private string DatabaseName;

        public bool zonesDownloaded, amountFedDownloaded, dissolveOxygenDownloaded, temperatureWaterDownloaded = false;
        public bool zonesSaved, amountFedSaved, dissolveOxygenSaved, temperatureWaterSaved = false;

        public ConnectEndpoints(string zone, bool isSSLHostEndpoint, string HostEndpoint, string HostDatabase, string DatabaseName)
        {
            this.Zone = zone;
            this.isSSLHostEndpoint = isSSLHostEndpoint;
            this.HostEndpoint = HostEndpoint;
            this.HostDatabase = HostDatabase;
            this.DatabaseName = DatabaseName;
        }
        public void Connect(string Path, string Username, string Password, DateTime MetricDay)
        {
            Console.WriteLine("Connecting host [" + this.HostEndpoint + "]...");
            Console.WriteLine("Start ===============> " + DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture));


            ConnectDB.Connect(this.HostDatabase, this.DatabaseName, null, null);
            
            /** Create Host & URI */
            Host Host = new Host(this.isSSLHostEndpoint, null, null, this.HostEndpoint);
            URI Uri = new URI(Host, Path);

            /** Login JWT */
            Response TokenZone = new JWT(Uri.Get()).Login<Response>(Username, Password);

            /** Zones */
            List<Zone> Zones = new EndpointZone(Uri.Get()).Connect(TokenZone.access);
            this.zonesDownloaded = true;
            foreach (Zone zone in Zones)
            {
                zone.zone = this.Zone;
            }
            ConnectDB.BulkCopy<Zone>("Zone", Zones);
            this.zonesSaved = true;

            List<ZoneMetric> amountFedALL = new List<ZoneMetric>();
            List<ZoneMetric> dissolveOxygenALL = new List<ZoneMetric>();
            List<ZoneMetric> temperatureWaterALL = new List<ZoneMetric>();

            DateTime EndMetricDay = MetricDay.AddDays(1);
            while (MetricDay.CompareTo(EndMetricDay)<0)
            {
                Console.WriteLine("Downloading " + MetricDay.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture) + " ...");

                amountFedDownloaded = false;
                dissolveOxygenDownloaded = false;
                temperatureWaterDownloaded = false;
                amountFedSaved = false;
                dissolveOxygenSaved = false;
                temperatureWaterSaved = false;

                /** Login JWT */
                Response Token = new JWT(Uri.Get()).Login<Response>(Username, Password);

                /** Hourly */
                DateTime StartHourly = new DateTime(MetricDay.Year, MetricDay.Month, MetricDay.Day, 00, 00, 01);
                DateTime EndHourly = new DateTime(MetricDay.Year, MetricDay.Month, MetricDay.Day + 1, 00, 00, 00);

                List<ZoneMetric> AmountFedTmp = new EndpointAmountFed(Uri.Get()).Connect(Token.access, StartHourly, EndHourly);
                amountFedALL.AddRange(AmountFedTmp);
                this.amountFedDownloaded = true;

                /** 5m */
                DateTime Start5m = new DateTime(MetricDay.Year, MetricDay.Month, MetricDay.Day, 00, 00, 01);
                DateTime End5m = new DateTime(MetricDay.Year, MetricDay.Month, MetricDay.Day, 00, 05, 00);

                while (Start5m.CompareTo(EndHourly) <= 0)
                {
                    List<ZoneMetric> dissolveOxygenTmp = new EndpointDissolveOxygen(Uri.Get()).Connect(Token.access, Start5m, End5m);
                    dissolveOxygenALL.AddRange(dissolveOxygenTmp);

                    List<ZoneMetric> temperatureWaterTmp = new EndpointTemperatureWater(Uri.Get()).Connect(Token.access, Start5m, End5m);
                    temperatureWaterALL.AddRange(temperatureWaterTmp);

                    Start5m = Start5m.AddMinutes(5);
                    End5m = End5m.AddMinutes(5);
                }
                this.dissolveOxygenDownloaded = true;
                this.temperatureWaterDownloaded = true;

                MetricDay = MetricDay.AddDays(1);
            }

            List<MetricByZone> metricsAmountFedBD = new List<MetricByZone>();
            List<MetricByZone> metricsDissolveOxygenBD = new List<MetricByZone>();
            List<MetricByZone> metricsTemperatureWaterBD = new List<MetricByZone>();

            foreach (ZoneMetric temp in amountFedALL)
                foreach (Metric metric in temp.metric)
                    metricsAmountFedBD.Add(new MetricByZone
                    {
                        zone = temp.zone,
                        time = DateTime.Parse(metric.time),
                        value = metric.value
                    });
            ConnectDB.BulkCopy<MetricByZone>("AmountFedByZone", metricsAmountFedBD);
            this.amountFedSaved = true;

            foreach (ZoneMetric zone in dissolveOxygenALL)
                foreach (Metric metric in zone.metric)
                    metricsDissolveOxygenBD.Add(new MetricByZone
                    {
                        zone = zone.zone,
                        time = DateTime.Parse(metric.time),
                        value = metric.value
                    });
            ConnectDB.BulkCopy<MetricByZone>("DissolveOxygenByZone", metricsDissolveOxygenBD);
            this.dissolveOxygenSaved = true;

            foreach (ZoneMetric zone in temperatureWaterALL)
                foreach (Metric metric in zone.metric)
                    metricsTemperatureWaterBD.Add(new MetricByZone
                    {
                        zone = zone.zone,
                        time = DateTime.Parse(metric.time),
                        value = metric.value
                    });
            ConnectDB.BulkCopy<MetricByZone>("TemperatureWaterByZone", metricsTemperatureWaterBD);
            this.temperatureWaterSaved = true;


            Console.WriteLine("End ===============> " + DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture));
        }

    }
}
