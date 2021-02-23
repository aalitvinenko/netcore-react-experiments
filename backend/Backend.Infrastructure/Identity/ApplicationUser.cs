﻿using Microsoft.AspNetCore.Identity;

namespace Backend.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string LastName { get; set; }
    }
}