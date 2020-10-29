using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMVC.Common
{
    public class SpotDto
    {
        public int spotNr { get; set; }
        public int rowspan { get; set; }
        public string infotext { get; set; }

        public SpotDto(int spotNr, int rowspan, string infotext)
        {
            this.spotNr = spotNr;
            this.rowspan = rowspan;
            this.infotext = infotext;
        }
    }
}
