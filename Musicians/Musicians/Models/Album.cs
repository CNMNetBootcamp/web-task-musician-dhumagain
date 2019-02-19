using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicians.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        public DateTime CopyrightDate { get; set; }
        public string AlbumTitle { get; set; }
        public string Format { get; set; }
        public string AlbumIdentifier { get; set; }
        public string Producer { get; set; }

        public Musician Musician { get; set; }

    }
}
