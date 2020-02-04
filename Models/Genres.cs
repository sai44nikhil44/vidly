using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace vidly.Models
{
    public class Genres
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(255)]
        public string GenreName { get; set; }
    }
}