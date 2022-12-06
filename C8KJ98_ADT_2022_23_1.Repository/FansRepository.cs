using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C8KJ98_ADT_2022_23_1.Models;
using C8KJ98_ADT_2022_23_1.Data;

namespace C8KJ98_ADT_2022_23_1.Repository
{
    public class FansRepository : Repository<Fans>, IFansRepository
    {
        public FansRepository(TalkWithYourFavoriteArtistDbContext DbContext) : base(DbContext) { }
        public override Fans GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(fan => fan.Id == id);

        }
        public void UpdateCity(int id, string newcity)
        {
            var Fan = this.GetOne(id);
            if (Fan == null)
            {
                throw new Exception("This id doesn't match to any Fan in our Database");
            }
            else
            {
                Fan.City = newcity;
                this.context.SaveChanges();
            }
        }
        


    }
}
