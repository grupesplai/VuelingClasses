using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CobalcoWebApiClient
{
    class HttpApiController
    {
        static HttpClient client;

        static HttpApiController() {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:7214/");
        }
        public HttpApiController() { }


        public async Task<List<AlumnoModel>> GetCall()
        {
            IEnumerable<AlumnoModel> alumnoList = new List<AlumnoModel>();
            
            HttpResponseMessage response = client.GetAsync("api/AlumnoAPI").Result;
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("resquest message" + response.RequestMessage + " \n" + response.Content.Headers);
                    var alumnoJsonString = await response.Content.ReadAsStringAsync(); // este resultado se va a serializar
                                                                                       //cuando llame a un get va a encapsular en un request.message
                    Console.WriteLine("Your response data is: " + alumnoJsonString.ToString());

                    //deserialize data
                    var deserialize = JsonConvert.DeserializeObject<IEnumerable<AlumnoModel>>(alumnoJsonString);
                    alumnoList = deserialize;
                }
            }
            catch (JsonException e)
            {
                Console.WriteLine("Se ha producido un error con el json: " + e);
                throw e;
            }
            
            return alumnoList.ToList();
        }
    }
}
