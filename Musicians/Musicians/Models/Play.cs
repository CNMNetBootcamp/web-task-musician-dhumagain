using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicians.Models
{
    public class Play
    {
        public int PlayID { get; set; }

        public Musician Musician { get; set; }

        public ICollection<Instrument> Instrument { get; set; }
        
        
    }
}
