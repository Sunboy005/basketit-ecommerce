using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.Microservice.Context;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Microservice.Features.ProductFeatures.Queries
{
    public class GetAllProductQuery:IRequest<IEnumerable<Model.Product>>
    {
        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Model.Product>>
        {
            private readonly IApplicationContext _context;

            public GetAllProductQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Model.Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
            {
                var productList = await _context.Products.ToListAsync();
                if (productList == null)
                {
                    return null;
                }
                return productList.AsReadOnly();
            }
        }
    }
}
