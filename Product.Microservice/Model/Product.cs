using System;

namespace Product.Microservice.Model
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }    
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
