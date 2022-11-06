using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C8KJ98_ADT_2022_23_1.Data;
using C8KJ98_ADT_2022_23_1.Models;
namespace C8KJ98_ADT_2022_23_1.Repository
{
    public class ReservationsRepository : Repository<Reservations>, IReservationsRepository
    {
        public ReservationsRepository(TalkWithYourFavoriteArtistDbContext DbContext) : base(DbContext) { }
        public void UpdateDate(int id, DateTime newDate)
        {
            var reservation = this.GetOne(id);
            if (reservation == null)
            {
                throw new Exception("This id doesn't match to any order in our Database");

            }
            else
            {
                reservation.DateTime = newDate;
                this.context.SaveChanges();
            }

        }
        public override Reservations GetOne(int id)
        {
            return context
                .Reservations
                .SingleOrDefault(reservation => reservation.Id == id);
        }

    }
}
