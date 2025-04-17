using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChiChiEcommerce.Domain.Entities
{
    public class Shop
    {
        public int Shopid { get; set; } 
        public string Name { get; set; } 
        public int Ownerid { get; set; } 
        public User Owner { get; set; }   
    }
}