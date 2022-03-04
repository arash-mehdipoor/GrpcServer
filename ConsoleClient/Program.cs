using Grpc.Net.Client;
using GrpcServer.Protos;
using System;

namespace ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var chanel = GrpcChannel.ForAddress("https://localhost:5001/");

            var productClient = new ProductService.ProductServiceClient(chanel);

            var response = productClient.AddProduct(new RequestProductDTO()
            {
                Name = "Product 2",
                BrandName = "Brand 2",
                Price = 225000
            });

            Console.WriteLine("Status: {0}", response.IsSuccess);
        }
    }
}
