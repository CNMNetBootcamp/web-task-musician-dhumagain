using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicians.Models
{
    public class Instrument
    {
        public int InstrumentID { get; set; }
        public string MusicalFlat { get; set; }
        public string InstrumentName { get; set; }
        public Play Play { get; set; }


    }
}
