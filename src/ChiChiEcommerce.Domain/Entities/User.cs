using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChiChiEcommerce.Domain.Entities
{
    public class User
    {
        public int Userid { get; set; }  
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
        public string Role { get; set; }
    }
}