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
        public Artists AddNewArtist(string name, int duration, int price, string category);
        public void DeleteArtist(int id);
        Artists GetArtist(int id);
        IEnumerable<Artists> GetAllArtists();
        void UpdateArtistCost(int artistId, int cost);

        IEnumerable<KeyValuePair<string, int>> ArtistEarnings();
        KeyValuePair<string, int> MostPaidArtist();
        KeyValuePair<string, int> LessPaidArtist();
    }
}
