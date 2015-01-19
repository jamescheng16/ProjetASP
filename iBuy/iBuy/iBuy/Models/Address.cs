using System.Collections;
using System.Collections.Generic;

namespace iBuy.Models
{
    public class Address
    {
        // Id
        public int Id { get; set; }

        // Address's name
        public string City { get; set; }

        // Address' postal code
        public decimal PostalCode { get; set; }

        public virtual ICollection<Announce> Announces { get; set; }

    }

}