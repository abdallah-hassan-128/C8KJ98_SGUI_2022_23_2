using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8KJ98_ADT_2022_23_1.Logic
{
    public class ArtistEarnings
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int FinishedJobs { get; set; }
        public int OverallEarnings { get; set; }
        public override string ToString()
        {
            return "Artist's name : " + this.ArtistName + ", ID : " + ArtistId + ",FinishedJobs : " + FinishedJobs + ",OverallEarnings : " + OverallEarnings;
        }
    }
}
