using APIClient.AQ1.Model;
using APIClient.CommonUtils.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace APICliente.AQ1.EndPoint
{
    public class EndpointDissolveOxygen
    {
        private readonly string API_CALL = "zone/5m/do";
        private readonly string URI;
        public EndpointDissolveOxygen(string URI)
        {
            this.URI = URI + API_CALL;
        }
        public List<ZoneMetric> Connect(string JWT, DateTime Start, DateTime End)
        {
            ConnectRest.JWT = JWT;
            string PStart = nameof(Start).ToLower() + "=" + Start.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            string PEnd = nameof(End).ToLower() + "=" + End.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            List<ZoneMetric> ZonesMetrics = JsonConvert.DeserializeObject<List<ZoneMetric>>(ConnectRest.GET<string>(this.URI, 0, PStart, PEnd));

            return ZonesMetrics;
        }
    }
}
