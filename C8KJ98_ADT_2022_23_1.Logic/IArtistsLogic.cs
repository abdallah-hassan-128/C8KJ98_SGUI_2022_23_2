using C8KJ98_ADT_2022_23_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8KJ98_ADT_2022_23_1.Logic
{
    public interface IArtistsLogic
    {
        public Artists AddNewArtist(Artists newartist);
        public void DeleteArtist(int id);
        Artists GetArtist(int id);
        IEnumerable<Artists> GetAllArtists();
        void UpdateArtistCost(Artists value);

        IEnumerable<KeyValuePair<string, int>> ArtistEarnings();
        List<KeyValuePair<string, int>> MostPaidArtist();
        List<KeyValuePair<string, int>> LessPaidArtist();
    }
}
