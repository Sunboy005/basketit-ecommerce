﻿using System;

namespace Customer.Microservice.Model
{
    public class Customer
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }
}
