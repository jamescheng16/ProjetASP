using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;



namespace WebApplication1.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }

        //The Display attribute specifies what to display for the name of a field (in this case "Release Date" instead of "ReleaseDate")
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]

        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}