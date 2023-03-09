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
            Console.Write("Downloading ===> [" + this.Zone + "] " + MetricDay.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));

            /** Create Host & URI */
            Host Host = new Host(this.isSSLHostEndpoint, null, null, this.HostEndpoint);
            URI Uri = new URI(Host, Path);


            /*====================================== Hourly ======================================*/
            DateTime StartHourly = new DateTime(MetricDay.Year, MetricDay.Month, MetricDay.Day, 00, 00, 01);
            DateTime EndHourly;
            try
            {
                try
                {
                    EndHourly = new DateTime(MetricDay.Year, MetricDay.Month, MetricDay.Day + 1, 00, 00, 00);
                }
                catch
                {
                    EndHourly = new DateTime(MetricDay.Year, MetricDay.Month + 1, 1, 00, 00, 00);
                }
            }
            catch
            {
                EndHourly = new DateTime(MetricDay.Year + 1, 1, 1, 00, 00, 00);
            }

            Response tokenAmountFed = new JWT(Uri.Get()).Login<Response>(Username, Password);
            List<ZoneMetric> amountFed = new EndpointAmountFed(Uri.Get()).Connect(tokenAmountFed.access, StartHourly, EndHourly);

            List<MetricByZone> metricsAmountFedBD = new List<MetricByZone>();
            foreach (ZoneMetric temp in amountFed)
                foreach (Metric metric in temp.metric)
                    metricsAmountFedBD.Add(new MetricByZone
                    {
                        zone = temp.zone,
                        time = DateTime.Parse(metric.time),
                        value = metric.value
                    });
            ConnectDB.Connect(this.HostDatabase, this.DatabaseName, null, null);
            ConnectDB.BulkCopy<MetricByZone>("AmountFedByZone", metricsAmountFedBD);
            ConnectDB.Close();
            /*========================================================================================*/


            /*==================================== 5m ===================================*/
            DateTime Start5m = new DateTime(MetricDay.Year, MetricDay.Month, MetricDay.Day, 00, 00, 01);
            DateTime End5m = new DateTime(MetricDay.Year, MetricDay.Month, MetricDay.Day, 00, 05, 00);

            while (Start5m.CompareTo(EndHourly) <= 0)
            {
                
                //Dissolve Oxygen
                Response tokenDissolveOxygen = new JWT(Uri.Get()).Login<Response>(Username, Password);
                List<ZoneMetric> dissolveOxygen = new EndpointDissolveOxygen(Uri.Get()).Connect(tokenDissolveOxygen.access, Start5m, End5m);

                List<MetricByZone> metricsDissolveOxygenBD = new List<MetricByZone>();
                foreach (ZoneMetric zone in dissolveOxygen)
                    foreach (Metric metric in zone.metric)
                        metricsDissolveOxygenBD.Add(new MetricByZone
                        {
                            zone = zone.zone,
                            time = DateTime.Parse(metric.time),
                            value = metric.value
                        });
                ConnectDB.Connect(this.HostDatabase, this.DatabaseName, null, null);
                ConnectDB.BulkCopy<MetricByZone>("DissolveOxygenByZone", metricsDissolveOxygenBD);
                ConnectDB.Close();


                //Temperature Water
                Response tokenTemperatureWater = new JWT(Uri.Get()).Login<Response>(Username, Password);
                List<ZoneMetric> temperatureWater = new EndpointTemperatureWater(Uri.Get()).Connect(tokenTemperatureWater.access, Start5m, End5m);

                List<MetricByZone> metricsTemperatureWaterBD = new List<MetricByZone>();
                foreach (ZoneMetric zone in temperatureWater)
                    foreach (Metric metric in zone.metric)
                        metricsTemperatureWaterBD.Add(new MetricByZone
                        {
                            zone = zone.zone,
                            time = DateTime.Parse(metric.time),
                            value = metric.value
                        });
                ConnectDB.Connect(this.HostDatabase, this.DatabaseName, null, null);
                ConnectDB.BulkCopy<MetricByZone>("TemperatureWaterByZone", metricsTemperatureWaterBD);
                ConnectDB.Close();


                Start5m = Start5m.AddMinutes(5);
                End5m = End5m.AddMinutes(5);

            }
            /*========================================================================================*/

            Console.WriteLine(" <=== end");
        }

        public void DownloadedZones(string Path, string Username, string Password)
        {
            /** Create Host & URI */
            Host Host = new Host(this.isSSLHostEndpoint, null, null, this.HostEndpoint);
            URI Uri = new URI(Host, Path);

            /** Login JWT */
            Response TokenZone = new JWT(Uri.Get()).Login<Response>(Username, Password);
            if (TokenZone == null || TokenZone.access == null)
                throw new Exception("Connect to JWT is refused");

            /** Zones */
            List<Zone> Zones = new EndpointZone(Uri.Get()).Connect(TokenZone.access);
            this.zonesDownloaded = true;

            ConnectDB.Connect(this.HostDatabase, this.DatabaseName, null, null);

            foreach (Zone zone in Zones)
            {
                zone.zone = this.Zone;
            }
            ConnectDB.BulkCopy<Zone>("Zone", Zones);
            this.zonesSaved = true;
        }

    }
}
