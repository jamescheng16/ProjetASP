using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Owin.BuilderProperties;

namespace iBuy.Models
{
    public class Announce
    {
        // Attribut Id
        public int Id { get; set; }

        // An annouce's description
        public string Description { get; set; }

        // The title
        public string Title { get; set; }

        // Price for the article
        public float Price { get; set; }

        // Publish time
        public DateTime Date { get; set; }

        // Is a professional annouce
        public bool Isprof { get; set; }

        // A demand or an offer
        public int Type { get; set; }

        // The annoucement's address
        public Address Address { get; set; }

        // Publisher
        public User User { get; set; }

        // Category
        public Category Category { get; set; }
    }
}