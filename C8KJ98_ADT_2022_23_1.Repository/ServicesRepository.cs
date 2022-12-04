using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C8KJ98_ADT_2022_23_1.Data;
using C8KJ98_ADT_2022_23_1.Models;

namespace C8KJ98_ADT_2022_23_1.Repository
{
    public class ServicesRepository : Repository<Services>, IServicesRepository
    {
        public ServicesRepository(TalkWithYourFavoriteArtistDbContext DbContext) : base(DbContext) { }
        public override Services GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(service => service.Id == id);

        }
        public void UpdateName(int id, string newName)
        {
            var service = this.GetOne(id);
            if (service == null)
            {
                throw new Exception("This id doesn't match to any service in our Database");
            }
            else
            {
                service.Name = newName;
                this.context.SaveChanges();
            }
        }
        public void UpdatePrice(int id, int newPrice)
        {
            var service = this.GetOne(id);
            if (service == null)
            {
                throw new Exception("This id doesn't match to any service in our Database");
            }
            else
            {
                service.Price = newPrice;
                this.context.SaveChanges();
            }
        }
        public void UpdateRating(int id, int newRating)
        {
            var service = this.GetOne(id);
            if (service == null)
            {
                throw new Exception("This id doesn't match to any service in our Database");
            }
            else
            {
                service.Rating = newRating;
                this.context.SaveChanges();
            }
        }

    }
}
