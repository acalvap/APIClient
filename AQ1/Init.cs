using System;

namespace ApiClient.AQ1
{
    public class Init
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Api.AQ1.Client => ::");

            DateTime MetricDay = new DateTime(2023, 1, 1, 00, 00, 00);

            // Taura => 10.62.10.115 => 2022/06/04
            ConnectEndpoints Taura = null;
            try
            {
                Taura = new ConnectEndpoints(nameof(Taura), true, "10.62.10.115", "192.168.1.160", "BDEtc");
                Taura.Connect("customer-api", "read_only", "ipspapi23", MetricDay);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in [" + nameof(Taura) + "]..." +
                    "\nDownloaded: ¿Zones? " + Taura.zonesDownloaded + " - ¿AmountFed? " + Taura.amountFedDownloaded + " - ¿DissolveOxygen? " + Taura.dissolveOxygenDownloaded + " - ¿TemperatureWater? " + Taura.temperatureWaterDownloaded +
                    "\nSaved: ¿Zones? " + Taura.zonesSaved + " - ¿AmountFed? " + Taura.amountFedSaved + " - ¿DissolveOxygen? " + Taura.dissolveOxygenSaved + " - ¿TemperatureWater? " + Taura.temperatureWaterSaved
                    );
            }

            // Cuba => 10.61.10.181 => 2023/01/23
            ConnectEndpoints Cuba = null;
            try
            {
                Cuba = new ConnectEndpoints(nameof(Cuba), true, "10.61.10.181", "192.168.1.160", "BDEtc");
                Cuba.Connect("customer-api", "read_only", "ipspapi23", MetricDay);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in [" + nameof(Cuba) + "]..." +
                    "\nDownloaded: ¿Zones? " + Cuba.zonesDownloaded + " - ¿AmountFed? " + Cuba.amountFedDownloaded + " - ¿DissolveOxygen? " + Cuba.dissolveOxygenDownloaded + " - ¿TemperatureWater? " + Cuba.temperatureWaterDownloaded +
                    "\nSaved: ¿Zones? " + Cuba.zonesSaved + " - ¿AmountFed? " + Cuba.amountFedSaved + " - ¿DissolveOxygen? " + Cuba.dissolveOxygenSaved + " - ¿TemperatureWater? " + Cuba.temperatureWaterSaved
                    );
            }

            // Churute => 10.46.10.241 => 2023/01/10
            ConnectEndpoints Churute = null;
            try
            {
                Churute = new ConnectEndpoints(nameof(Churute), true, "10.46.10.241", "192.168.1.160", "BDEtc");
                Churute.Connect("customer-api", "read_only", "ipspapi23", MetricDay);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in [" + nameof(Churute) + "]..." +
                    "\nDownloaded: ¿Zones? " + Churute.zonesDownloaded + " - ¿AmountFed? " + Churute.amountFedDownloaded + " - ¿DissolveOxygen? " + Churute.dissolveOxygenDownloaded + " - ¿TemperatureWater? " + Churute.temperatureWaterDownloaded +
                    "\nSaved: ¿Zones? " + Churute.zonesSaved + " - ¿AmountFed? " + Churute.amountFedSaved + " - ¿DissolveOxygen? " + Churute.dissolveOxygenSaved + " - ¿TemperatureWater? " + Churute.temperatureWaterSaved
                    );
            }

            // California => 10.10.36.241
            ConnectEndpoints California = null;
            try
            {
                California = new ConnectEndpoints(nameof(California), true, "10.10.36.241", "192.168.1.160", "BDEtc");
                California.Connect("customer-api", "read_only", "ipspapi23", MetricDay);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in [" + nameof(California) + "]..." +
                    "\nDownloaded: ¿Zones? " + California.zonesDownloaded + " - ¿AmountFed? " + California.amountFedDownloaded + " - ¿DissolveOxygen? " + California.dissolveOxygenDownloaded + " - ¿TemperatureWater? " + California.temperatureWaterDownloaded +
                    "\nSaved: ¿Zones? " + California.zonesSaved + " - ¿AmountFed? " + California.amountFedSaved + " - ¿DissolveOxygen? " + California.dissolveOxygenSaved + " - ¿TemperatureWater? " + California.temperatureWaterSaved
                    );
            }

            // Japón => 10.49.10.108
            ConnectEndpoints Japon = null;
            try
            {
                Japon = new ConnectEndpoints(nameof(Japon), true, "10.49.10.108", "192.168.1.160", "BDEtc");
                Japon.Connect("customer-api", "read_only", "ipspapi23", MetricDay);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in [" + nameof(Japon) + "]..." +
                    "\nDownloaded: ¿Zones? " + Japon.zonesDownloaded + " - ¿AmountFed? " + Japon.amountFedDownloaded + " - ¿DissolveOxygen? " + Japon.dissolveOxygenDownloaded + " - ¿TemperatureWater? " + Japon.temperatureWaterDownloaded +
                    "\nSaved: ¿Zones? " + Japon.zonesSaved + " - ¿AmountFed? " + Japon.amountFedSaved + " - ¿DissolveOxygen? " + Japon.dissolveOxygenSaved + " - ¿TemperatureWater? " + Japon.temperatureWaterSaved
                    );
            }

            Console.ReadLine();
        }

    }
}
