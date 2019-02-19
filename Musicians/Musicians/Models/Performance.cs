using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicians.Models
{
    public class Performance
    {
        public int PerformanceID { get; set; }
     //   public int MusicianID { get; set; }
      //  public int SongID { get; set; }

       // public ICollection<Musician> Musician { get; set; }
        public Musician Musician { get; set; }
        public ICollection<Song> Song { get; set; }

    }
}
