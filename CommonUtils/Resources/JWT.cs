using APIClient.CommonUtils.Services;
using Newtonsoft.Json;
using System;

namespace APIClient.CommonUtils.Resources
{
    public class JWT
    {
        private readonly string API_CALL = "token/";
        private readonly string URI;
        public JWT(string URI)
        {
            this.URI = URI + API_CALL;
        }
        public Response Login(string username, string password)
        {
            Request request = new Request() { username = username, password = password };
            Response response = JsonConvert.DeserializeObject<Response>(ConnectRest.POST<String>(this.URI, request));
            return response;
        }
    }

    public class Request : IRequest
    {
        public string username;
        public string password;
    }
    public class Response : IResponse
    {
        public string refresh;
        public string access;
    }
}
