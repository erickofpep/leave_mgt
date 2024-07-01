﻿using Microsoft.AspNetCore.Identity;

namespace leave_mgt.Data
{
    public class Employee : IdentityUser
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
