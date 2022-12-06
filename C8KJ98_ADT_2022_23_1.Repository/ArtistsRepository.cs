using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C8KJ98_ADT_2022_23_1.Models;
using C8KJ98_ADT_2022_23_1.Data;

namespace C8KJ98_ADT_2022_23_1.Repository
{
    public class ArtistsRepository : Repository<Artists>, IArtistsRepository
    {
        public ArtistsRepository(TalkWithYourFavoriteArtistDbContext DbContext) : base(DbContext) { }
        public override Artists GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(artist => artist.Id == id);

        }
       
        public void UpdatePrice(int id, int newprice)
        {
            var artist = this.GetOne(id);
            if (artist == null)
            {
                throw new Exception("This id doesn't match to any artist in our Database");
            }
            else
            {
                artist.Price = newprice;
                this.context.SaveChanges();
            }
        }
    }
}
