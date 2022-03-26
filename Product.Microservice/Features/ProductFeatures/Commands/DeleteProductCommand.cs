using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.Microservice.Context;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Microservice.Features.ProductFeatures.Commands
{
    public class DeleteProductCommand: IRequest<string>
    {
        public string Id { get; set; }
        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, string>
        {
            private readonly IApplicationContext _context;
            public DeleteProductCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (product == null)   
                    return null;
                _context.Products.Remove(product);
                await _context.SaveChanges();
                return product.Id;
            }
        }
    }
}
