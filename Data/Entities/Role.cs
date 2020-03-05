using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealprepFull.Data.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public AppRole() {}

        public AppRole(string name)
        {
            Name = name;
        }
    }
}
