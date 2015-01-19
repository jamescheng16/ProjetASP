using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iBuy.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }

        public string Mail { get; set; }

        public decimal PhoneNumber { get; set; }
    }

}