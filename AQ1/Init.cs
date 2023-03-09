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

            //Descargar();
            DescargarXRango();

            Console.ReadLine();
        }

        public static void Descargar()
        {
            //Constants
            string Path = "customer-api";
            string Username = "read_only";
            string Password = "ipspapi23";

            // Downloaded zones...
            ConnectEndpoints Taura; // Taura => 10.62.10.115
            ConnectEndpoints Cuba; // Cuba => 10.61.10.181
            ConnectEndpoints Churute; // Churute => 10.46.10.241
            ConnectEndpoints California; // California => 10.10.36.241
            ConnectEndpoints Japon; // Japón => 10.49.10.108

            Taura = new ConnectEndpoints(nameof(Taura), isSSLHostEndpoint, "10.62.10.115", HostDatabase, DatabaseName);
            Cuba = new ConnectEndpoints(nameof(Cuba), isSSLHostEndpoint, "10.61.10.181", HostDatabase, DatabaseName);
            Churute = new ConnectEndpoints(nameof(Churute), isSSLHostEndpoint, "10.46.10.241", HostDatabase, DatabaseName);
            California = new ConnectEndpoints(nameof(California), isSSLHostEndpoint, "10.10.36.241", HostDatabase, DatabaseName);
            Japon = new ConnectEndpoints(nameof(Japon), isSSLHostEndpoint, "10.49.10.108", HostDatabase, DatabaseName);
            /*try
            {
                Taura.DownloadedZones(Path, Username, Password);
                Cuba.DownloadedZones(Path, Username, Password);
                Churute.DownloadedZones(Path, Username, Password);
                California.DownloadedZones(Path, Username, Password);
                Japon.DownloadedZones(Path, Username, Password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException + "\n" + e.StackTrace);
            }*/

            // Downloaded metrics...
            DateTime MetricDay = DateTime.Today.AddDays(-1);
            try
            {
                Taura.Connect(Path, Username, Password, MetricDay);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException + "\n" + e.StackTrace);
            }

            try
            {
                Cuba.Connect(Path, Username, Password, MetricDay);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }

            try
            {
                Churute.Connect(Path, Username, Password, MetricDay);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }

            try
            {
                California.Connect(Path, Username, Password, MetricDay);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }

            try
            {
                Japon.Connect(Path, Username, Password, MetricDay);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }
        }

        public static void DescargarXRango()
        {
            //Constants
            string Path = "customer-api";
            string Username = "read_only";
            string Password = "ipspapi23";

            // Downloaded zones...
            ConnectEndpoints Taura; // Taura => 10.62.10.115
            ConnectEndpoints Cuba; // Cuba => 10.61.10.181
            ConnectEndpoints Churute; // Churute => 10.46.10.241
            ConnectEndpoints California; // California => 10.10.36.241
            ConnectEndpoints Japon; // Japón => 10.49.10.108

            Taura = new ConnectEndpoints(nameof(Taura), isSSLHostEndpoint, "10.62.10.115", HostDatabase, DatabaseName);
            Cuba = new ConnectEndpoints(nameof(Cuba), isSSLHostEndpoint, "10.61.10.181", HostDatabase, DatabaseName);
            Churute = new ConnectEndpoints(nameof(Churute), isSSLHostEndpoint, "10.46.10.241", HostDatabase, DatabaseName);
            California = new ConnectEndpoints(nameof(California), isSSLHostEndpoint, "10.10.36.241", HostDatabase, DatabaseName);
            Japon = new ConnectEndpoints(nameof(Japon), isSSLHostEndpoint, "10.49.10.108", HostDatabase, DatabaseName);
            /*try
            {
                Taura.DownloadedZones(Path, Username, Password);
                Cuba.DownloadedZones(Path, Username, Password);
                Churute.DownloadedZones(Path, Username, Password);
                California.DownloadedZones(Path, Username, Password);
                Japon.DownloadedZones(Path, Username, Password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException + "\n" + e.StackTrace);
            }*/

            // Downloaded metrics...
            DateTime MetricDay = new DateTime(2023, 3, 3, 00, 00, 00);
            DateTime EndMetricDay = new DateTime(2023, 3, 6, 00, 00, 00);
            while (MetricDay.CompareTo(EndMetricDay) <= 0)
            {
                try
                {
                    Taura.Connect(Path, Username, Password, MetricDay);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException + "\n" + e.StackTrace);
                }

                try
                {
                    Cuba.Connect(Path, Username, Password, MetricDay);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }

                try
                {
                    Churute.Connect(Path, Username, Password, MetricDay);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }

                try
                {
                    California.Connect(Path, Username, Password, MetricDay);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }

                try
                {
                    Japon.Connect(Path, Username, Password, MetricDay);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n" + e.StackTrace);
                }

                MetricDay = MetricDay.AddDays(1);
            }
        }

    }
}
