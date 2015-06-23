using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last.fmInfo.Entity
{
    class User
    {
        public string UserName { get; set; }
        public List<ArtistChart> ArtistsCharts { get; set; }
    }
}
