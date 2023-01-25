using System;
using System.Globalization;

namespace ApiClient.AQ1
{
    public class Init
    {

        private readonly static bool isSSLHostEndpoint = true;
        private readonly static string HostDatabase = "192.168.1.160";
        private readonly static string DatabaseName = "BDEtc";

        public static void Main(string[] args)
        {
            Console.WriteLine("Api.AQ1.Client => ::");

            // Downloaded zones...
            // Taura => 10.62.10.115 => 2022/06/04
            ConnectEndpoints Taura = null;
            try
            {
                Taura = new ConnectEndpoints(nameof(Taura), isSSLHostEndpoint, "10.62.10.115", HostDatabase, DatabaseName);
                Taura.DownloadedZones("customer-api", "read_only", "ipspapi23");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in [" + nameof(Taura) + "]...");
                Console.WriteLine(e.InnerException + "\n" + e.StackTrace);
            }

            // Cuba => 10.61.10.181 => 2023/01/23
            ConnectEndpoints Cuba = null;
            try
            {
                Cuba = new ConnectEndpoints(nameof(Cuba), isSSLHostEndpoint, "10.61.10.181", HostDatabase, DatabaseName);
                Cuba.DownloadedZones("customer-api", "read_only", "ipspapi23");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in [" + nameof(Cuba) + "]...");
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }

            // Churute => 10.46.10.241 => 2023/01/10
            ConnectEndpoints Churute = null;
            try
            {
                Churute = new ConnectEndpoints(nameof(Churute), isSSLHostEndpoint, "10.46.10.241", HostDatabase, DatabaseName);
                Churute.DownloadedZones("customer-api", "read_only", "ipspapi23");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in [" + nameof(Churute) + "]...");
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }

            // California => 10.10.36.241
            ConnectEndpoints California = null;
            try
            {
                California = new ConnectEndpoints(nameof(California), isSSLHostEndpoint, "10.10.36.241", HostDatabase, DatabaseName);
                California.DownloadedZones("customer-api", "read_only", "ipspapi23");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in [" + nameof(California) + "]...");
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }

            // Japón => 10.49.10.108
            ConnectEndpoints Japon = null;
            try
            {
                Japon = new ConnectEndpoints(nameof(Japon), isSSLHostEndpoint, "10.49.10.108", HostDatabase, DatabaseName);
                Japon.DownloadedZones("customer-api", "read_only", "ipspapi23");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in [" + nameof(Japon) + "]...");
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }

            // Downloaded metrics...
            DateTime MetricDay = new DateTime(2023, 1, 1, 00, 00, 00);
            DateTime EndMetricDay = MetricDay.AddDays(15);
            while (MetricDay.CompareTo(EndMetricDay) < 0)
            {
                Console.WriteLine("Downloading " + MetricDay.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture) + " ...");

                // Taura => 10.62.10.115 => 2022/06/04
                Taura = null;
                try
                {
                    Taura = new ConnectEndpoints(nameof(Taura), isSSLHostEndpoint, "10.62.10.115", HostDatabase, DatabaseName);
                    Taura.Connect("customer-api", "read_only", "ipspapi23", MetricDay);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error in [" + nameof(Taura) + "]..." +
                        "\nDownloaded: ¿Zones? " + Taura.zonesDownloaded + " - ¿AmountFed? " + Taura.amountFedDownloaded + " - ¿DissolveOxygen? " + Taura.dissolveOxygenDownloaded + " - ¿TemperatureWater? " + Taura.temperatureWaterDownloaded +
                        "\nSaved: ¿Zones? " + Taura.zonesSaved + " - ¿AmountFed? " + Taura.amountFedSaved + " - ¿DissolveOxygen? " + Taura.dissolveOxygenSaved + " - ¿TemperatureWater? " + Taura.temperatureWaterSaved
                        );
                    Console.WriteLine(e.InnerException + "\n" + e.StackTrace);
                }

                // Cuba => 10.61.10.181 => 2023/01/23
                Cuba = null;
                try
                {
                    Cuba = new ConnectEndpoints(nameof(Cuba), isSSLHostEndpoint, "10.61.10.181", HostDatabase, DatabaseName);
                    Cuba.Connect("customer-api", "read_only", "ipspapi23", MetricDay);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error in [" + nameof(Cuba) + "]..." +
                        "\nDownloaded: ¿Zones? " + Cuba.zonesDownloaded + " - ¿AmountFed? " + Cuba.amountFedDownloaded + " - ¿DissolveOxygen? " + Cuba.dissolveOxygenDownloaded + " - ¿TemperatureWater? " + Cuba.temperatureWaterDownloaded +
                        "\nSaved: ¿Zones? " + Cuba.zonesSaved + " - ¿AmountFed? " + Cuba.amountFedSaved + " - ¿DissolveOxygen? " + Cuba.dissolveOxygenSaved + " - ¿TemperatureWater? " + Cuba.temperatureWaterSaved
                        );
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }

                // Churute => 10.46.10.241 => 2023/01/10
                Churute = null;
                try
                {
                    Churute = new ConnectEndpoints(nameof(Churute), isSSLHostEndpoint, "10.46.10.241", HostDatabase, DatabaseName);
                    Churute.Connect("customer-api", "read_only", "ipspapi23", MetricDay);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error in [" + nameof(Churute) + "]..." +
                        "\nDownloaded: ¿Zones? " + Churute.zonesDownloaded + " - ¿AmountFed? " + Churute.amountFedDownloaded + " - ¿DissolveOxygen? " + Churute.dissolveOxygenDownloaded + " - ¿TemperatureWater? " + Churute.temperatureWaterDownloaded +
                        "\nSaved: ¿Zones? " + Churute.zonesSaved + " - ¿AmountFed? " + Churute.amountFedSaved + " - ¿DissolveOxygen? " + Churute.dissolveOxygenSaved + " - ¿TemperatureWater? " + Churute.temperatureWaterSaved
                        );
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }

                // California => 10.10.36.241
                California = null;
                try
                {
                    California = new ConnectEndpoints(nameof(California), isSSLHostEndpoint, "10.10.36.241", HostDatabase, DatabaseName);
                    California.Connect("customer-api", "read_only", "ipspapi23", MetricDay);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error in [" + nameof(California) + "]..." +
                        "\nDownloaded: ¿Zones? " + California.zonesDownloaded + " - ¿AmountFed? " + California.amountFedDownloaded + " - ¿DissolveOxygen? " + California.dissolveOxygenDownloaded + " - ¿TemperatureWater? " + California.temperatureWaterDownloaded +
                        "\nSaved: ¿Zones? " + California.zonesSaved + " - ¿AmountFed? " + California.amountFedSaved + " - ¿DissolveOxygen? " + California.dissolveOxygenSaved + " - ¿TemperatureWater? " + California.temperatureWaterSaved
                        );
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }

                // Japón => 10.49.10.108
                Japon = null;
                try
                {
                    Japon = new ConnectEndpoints(nameof(Japon), isSSLHostEndpoint, "10.49.10.108", HostDatabase, DatabaseName);
                    Japon.Connect("customer-api", "read_only", "ipspapi23", MetricDay);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error in [" + nameof(Japon) + "]..." +
                        "\nDownloaded: ¿Zones? " + Japon.zonesDownloaded + " - ¿AmountFed? " + Japon.amountFedDownloaded + " - ¿DissolveOxygen? " + Japon.dissolveOxygenDownloaded + " - ¿TemperatureWater? " + Japon.temperatureWaterDownloaded +
                        "\nSaved: ¿Zones? " + Japon.zonesSaved + " - ¿AmountFed? " + Japon.amountFedSaved + " - ¿DissolveOxygen? " + Japon.dissolveOxygenSaved + " - ¿TemperatureWater? " + Japon.temperatureWaterSaved
                        );
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }

                MetricDay = MetricDay.AddDays(1);
            }

            Console.ReadLine();
        }

    }
}
