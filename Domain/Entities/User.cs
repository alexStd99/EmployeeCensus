﻿namespace EmployeeCensus.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastActionTime { get; set; }
    }
}