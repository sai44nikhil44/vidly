using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleasedDate { get; set; }
        public DateTime AddedDate { get; set; }
        public int NumberInStock { get; set; }
        public Genres Genres { get; set; }
    }
}