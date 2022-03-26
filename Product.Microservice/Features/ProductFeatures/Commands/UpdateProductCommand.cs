using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.Microservice.Context;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Microservice.Features.ProductFeatures.Commands
{
    public class UpdateProductCommand:IRequest<string>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, string>
        {
            private readonly IApplicationContext _context;

            public UpdateProductCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product= await _context.Products.Where(a=>a.Id==request.Id).FirstOrDefaultAsync();
                if (product == null)
                {
                    return null;
                }
                else
                {
                    product.Name = request.Name;
                    product.Description = request.Description;  
                    product.Price = request.Price;
                    await _context.SaveChanges();
                    return product.Id;
                }
            }
        }
    }
}
