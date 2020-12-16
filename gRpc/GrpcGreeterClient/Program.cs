using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var rely = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });

            Console.WriteLine($"Greeting: {rely.Message}");
            Console.WriteLine($"Press any key to exit...");
            Console.ReadKey();

        }
    }
}
