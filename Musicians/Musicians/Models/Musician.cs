using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Musicians.Models
{
    public class Musician
    {
        //  [Key,]
        public int MusicianID { get; set; }
        public int Ssn { get; set; }
        public string Name  { get; set; }

        public Location Location { get; set; }       
        
        public ICollection<Play> Play { get; set; }
        public ICollection<Performance> Performance { get; set; }

        //  public ICollection<Album> Album { get; set; } //think as bucket, what does it need to contain



    }
}
