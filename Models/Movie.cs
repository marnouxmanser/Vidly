using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Display(Name ="Genre")]
        public Genre Genre { get; set; }
        
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }
        
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        
        [Display(Name = "Number In Stock")]
        [Range(1, 20,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        
        public int NumberInStock { get; set; }
    }
}