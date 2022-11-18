﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C8KJ98_ADT_2022_23_1.Models;
using C8KJ98_ADT_2022_23_1.Data;

namespace C8KJ98_ADT_2022_23_1.Repository
{
    class FansRepository : Repository<Fans>, IFansRepository
    {
        public FansRepository(TalkWithYourFavoriteArtistDbContext DbContext) : base(DbContext) { }
        public override Fans GetOne(int id)
        {
            return context
                .Fans
                .SingleOrDefault(fan => fan.Id == id);
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
        public void UpdateEmail(int id, string newEmail)
        {
            var Fan = this.GetOne(id);
            if (Fan == null)
            {
                throw new Exception("This id doesn't match to any Fan in our Database");
            }
            else
            {
                Fan.Email = newEmail;
                this.context.SaveChanges();
            }
        }
        public void UpdatePhone(int id, int NewPhoneNumber)
        {
            var Fan = this.GetOne(id);
            if (Fan == null)
            {
                throw new Exception("This id doesn't match to any Fan in our Database");
            }
            else
            {
                Fan.PhoneNumber = NewPhoneNumber;
                this.context.SaveChanges();
            }
        }


    }
}