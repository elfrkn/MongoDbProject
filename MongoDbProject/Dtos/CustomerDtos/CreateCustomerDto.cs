﻿namespace MongoDbProject.Dtos.CustomerDtos
{
    public class CreateCustomerDto
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerMail { get; set; }
    }
}