using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace movierev.Models
{
    public class Movie
    {
        public string UserId { get; set; }

        

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

     
        public string Image { get; set; }

        [Required]
        [Range(1, 10)]
        public int Rating { get; set; }

        [Required]
        [Range(1800, 2050, ErrorMessage = "Release year must be between 1800 and 2050")]
        public int ReleaseYear { get; set; }

        [Required]
        [Range(1, 60000, ErrorMessage = "Release year must be between 1 and 60000")]
        public int Duration { get; set; }
    }
   }
