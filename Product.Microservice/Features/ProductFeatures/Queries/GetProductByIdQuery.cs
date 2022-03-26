using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.Microservice.Context;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Microservice.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery:IRequest<Model.Product>
    {
        public string Id { get; set; }
        public class GetProductByIDQueryHandler : IRequestHandler<GetProductByIdQuery, Model.Product>
        {
            private readonly IApplicationContext _context;
            public GetProductByIDQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<Model.Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (product == null)
                {
                    return null;
                }
                return product; 
            }
        }

    }
}
