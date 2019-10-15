﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBackend.DAL.Entities
{
    public class DbUser : IdentityUser<long>
    {
        public ICollection<DbUserRole> UserRoles { get; set; }

    }
}
