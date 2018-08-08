using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace RabbitMQSend
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: "hello",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                    );
                
                    Console.WriteLine("Nombre: ");
                    string alumnoName = Console.ReadLine();
                    Console.WriteLine("Apeliidos: ");
                    string alumnoLastName = Console.ReadLine();

                    Alumno alumno = new Alumno() { name = alumnoName, lastName = alumnoLastName };

                    string jsonfield = JsonConvert.SerializeObject(alumno);
                    byte[] body = Encoding.UTF8.GetBytes(jsonfield);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: "hello",
                        basicProperties: null,
                        body: body
                        );
                Console.WriteLine("[x] Sent {0}", jsonfield);
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
