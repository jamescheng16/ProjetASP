using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iBuy.Models
{
    public class User : ApplicationUser
    {
        public override string Id { get; set; }

        public virtual ICollection<Announce> Announces { get; set; } 
    }

}