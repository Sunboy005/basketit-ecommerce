using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Product.Microservice.Context
{
    public interface IApplicationContext
    {
        DbSet<Model.Product> Products { get; set; }

        Task<int> SaveChanges();
    }
}