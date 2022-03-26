﻿using Dapper;
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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
