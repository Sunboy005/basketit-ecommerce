using MediatR;
using Product.Microservice.Context;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Microservice.Features.ProductFeatures.Commands
{
    public class CreateProductCommand:IRequest<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
        {
            private readonly IApplicationContext _context;

            public CreateProductCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = new Model.Product();
                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                _context.Products.Add(product);
                await _context.SaveChanges();
                return product.Id;
            }
        }
    }
}
