using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicians.Models
{
    public class Song
    {
        public int SongID { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }


        public Performance Performance { get; set; }
       //public ICollection<Performance> Performance { get; set; } 
    }
}
