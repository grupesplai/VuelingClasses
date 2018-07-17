using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

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
                    Console.WriteLine(Resources.RQ_TEXT + response.RequestMessage + " \n" +
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
        public static async Task<string> AddAlumno(AlumnoModel alumno) //post
        {
            string message;
            var alumJson = JsonConvert.SerializeObject(alumno);
            try
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("aplication/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "api/AlumnoAPI")
                {
                    Content = new StringContent(alumJson, Encoding.UTF8, "application/json")
                };
                await client.SendAsync(request);
                message = "Se ha guardado correctamente.";
            }
            catch(HttpRequestException e) 
            {
                message = "Ha ocurrido un problema. "+ e;
                throw e;
            }
            return message;
        }
        public static async Task<string> Delete(int id)
        {
            string message = "";
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.DeleteAsync("api/AlumnoAPI/" + id);
                if (response.IsSuccessStatusCode)
                    message = "Se ha eliminado correctamente.";
                else
                    message = "El alumno con esta Id no existe. ";
            }
            catch (Exception e)
            {
                throw e;
            }
            return message;
        }
        //https://www.c-sharpcorner.com/article/crud-Asp-Net-web-api-with-entity-framework-in-Asp-Net-mvc/

        public static AlumnoModel find(int id)
        {
            try
            {
                var myInstance = JsonConvert.DeserializeObject<MyClass>(
                                await response.Content.ReadAsStringAsync());
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/AlumnoAPI" + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<AlumnoModel>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
}
