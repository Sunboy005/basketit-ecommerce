using Customer.Microservice.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Customer.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly string connectionString= "Server=(localdb)\\MSSQLLocalDB; Database=CustomerDB";
        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IEnumerable<Model.Customer>> GetCustomers()
        {
            IEnumerable<Model.Customer> customerList = new List<Model.Customer>();
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Select * From Customer";
                customerList = await connection.QueryAsync<Model.Customer>(sqlQuery);
            }
            return customerList;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<Model.Customer> GetCustomerByID(string id)
        {
            Model.Customer customer = new Model.Customer();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Select * From Customer Where Id=@id";
                customer = await connection.QuerySingleAsync<Model.Customer>(sqlQuery, new {Id=id});
            }
            return customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> AddCustomer ([FromForm] Model.Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Insert into Customer (FirstName, LastName, Address,Telephone, Email) Values (@FirstName, @LastName, @Address, @Telephone, @Email)";
                 await connection.ExecuteAsync(sqlQuery, customer);
            }
            return Ok();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(string id, [FromBody] Model.Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Update Customer Set FirstName=@FirstName, LastName= @LastName, Address= @Address,Telephone= @Telephone, Email= @Email WHERE Id=@Id";
                await connection.ExecuteAsync(sqlQuery, customer);
            }
            return Ok();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Delete Customer WHERE Id=@Id";
                await connection.ExecuteAsync(sqlQuery, id);
            }
            return Ok();
        }
    }
}
