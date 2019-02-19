using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicians.Models
{
    public class Location
    {
        public int LocationID { get; set; }
     //   public int MusicianID { get; set; }

        public int PhoneNum { get; set; }
        public string Address { get; set; }

        public ICollection<Musician> Musician { get; set; }

    }
}
