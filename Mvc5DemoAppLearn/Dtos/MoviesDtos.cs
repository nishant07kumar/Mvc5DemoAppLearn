using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc5DemoAppLearn.Dtos
{
    public class MoviesDtos
    {
        public int Id { get; set; }

        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Movie Name is required.")]
        public string MovieName { get; set; }

        [Required(ErrorMessage = "Quntity is required.")]
        [Range(minimum: 0, maximum: 100, ErrorMessage = "QuntityInStock should be in limit of 0 and 100.")]
        public int QuntityInStock { get; set; }


        [Required(ErrorMessage = "ReleaseDate is required.")]
        public DateTime ReleaseDate { get; set; }


        [Required(ErrorMessage = "Date Added is required.")]
        public DateTime DateAdded { get; set; }


        [Required(ErrorMessage = "Genre is required.")]
        public int GenreID { get; set; }

    }
}