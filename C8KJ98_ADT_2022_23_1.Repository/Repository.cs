using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using C8KJ98_ADT_2022_23_1.Data;

namespace C8KJ98_ADT_2022_23_1.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected TalkWithYourFavoriteArtistDbContext context;
        protected Repository(TalkWithYourFavoriteArtistDbContext ctx)
        {
            this.context = ctx;
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);

            context.SaveChanges();
        }
        public IQueryable<T> GetAll()
        {
            return this.context.Set<T>();
        }
        public abstract T GetOne(int id);
        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);

            context.SaveChanges();
        }
    }
}
