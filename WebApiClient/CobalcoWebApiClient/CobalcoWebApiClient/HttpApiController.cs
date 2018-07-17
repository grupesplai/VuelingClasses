using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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


        public async Task<List<AlumnoModel>> GetCall() //getAll
        {
            IEnumerable<AlumnoModel> alumnoList = new List<AlumnoModel>();

            HttpResponseMessage response = client.GetAsync("api/AlumnoAPI").Result;
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("resquest message" + response.RequestMessage + " \n" +
                        response.Content.Headers);
                    var alumnoJsonString = await response.Content.ReadAsStringAsync();
                    // este resultado se va a serializar

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
        public static string AddAlumno(AlumnoModel alumno) //post
        {
            string message;
            try
            {
                var alumJson = JsonConvert.SerializeObject(alumno);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("aplication/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "api/AlumnoAPI")
                {
                    Content = new StringContent(alumJson, Encoding.UTF8, "application/json")
                };
                client.SendAsync(request);
                message = "Se ha guardado correctamente.";
            }
            catch(HttpRequestException e) 
            {
                message = "Ha ocurrido un problema. "+ e;
                throw e;
            }
            return message;
        }
        public static string Delete(int id)
        {
            string message ="no";
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("api/AlumnoAPI/" + id).Result;
                if( response.IsSuccessStatusCode)
                    message = "Se ha eliminado correctamente.";
                else
                    message = "Ha ocurrido un problema. ";
            }
            catch(Exception e)
            {
                throw e;
            }
            return message;
        }
    }
}
