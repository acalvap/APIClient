using APIClient.AQ1.Model;
using APIClient.CommonUtils.Services;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace APICliente.AQ1.EndPoint
{
    public class EndpointZone
    {
        private readonly string API_CALL = "zone/index";
        private readonly string URI;

        public EndpointZone(string URI)
        {
            this.URI = URI + API_CALL;
        }
        public List<Zone> Connect(string JWT)
        {
            ConnectRest.JWT = JWT;
            List<Zone> Zones = JsonConvert.DeserializeObject<List<Zone>>(ConnectRest.GET<string>(this.URI));

            return Zones;
        }
    }
}
