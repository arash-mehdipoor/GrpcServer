using Grpc.Core;
using GrpcServer.Protos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrpcServer.GRPC
{
    public class ProductWebService : ProductService.ProductServiceBase
    {
        public class Product
        {
            public string Name { get; set; }
            public string BrandName { get; set; }
            public int Price { get; set; }
        }
        static List<Product> Products = new List<Product>()
        {
            new Product(){BrandName="Brand 1",Name= "Product 1",Price = 125000}
        };

        public override Task<ResponseAddProduct> AddProduct(RequestProductDTO request, ServerCallContext context)
        {
            Products.Add(new Product()
            {
                Name = request.Name,
                BrandName = request.BrandName,
                Price = request.Price
            });
            Console.WriteLine("Product Name: {0}", request.Name);
            Console.WriteLine("Product BrandName: {0}", request.BrandName);
            Console.WriteLine("Product Price: {0}", request.Price );

            return Task.FromResult(new ResponseAddProduct() { IsSuccess = true });
        }
    }
}
