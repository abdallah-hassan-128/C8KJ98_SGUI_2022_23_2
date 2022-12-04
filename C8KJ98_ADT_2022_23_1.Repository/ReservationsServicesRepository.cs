using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C8KJ98_ADT_2022_23_1.Models;
using C8KJ98_ADT_2022_23_1.Data;

namespace C8KJ98_ADT_2022_23_1.Repository
{
   public class ReservationsServicesRepository : Repository<ReservationsServices>, IReservationsServicesRepository
    {
        public ReservationsServicesRepository(TalkWithYourFavoriteArtistDbContext DbContext) : base(DbContext) { }
        public override ReservationsServices GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(connection => connection.Id == id);

        }

    }
}
