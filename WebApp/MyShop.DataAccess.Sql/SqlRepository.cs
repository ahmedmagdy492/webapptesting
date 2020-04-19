using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.Sql
{
    public class SqlRepository<T> : IRepository<T> where T : BaseModel
    {
        internal DataContext db;
        internal DbSet<T> Entity;

        public SqlRepository(DataContext context)
        {
            db = context;
            Entity = db.Set<T>();
        }
        public IQueryable<T> Collection()
        {
            return Entity;
        }

        public void Commit()
        {
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            var entity = Entity.Find(id);
            if(db.Entry(entity).State == EntityState.Detached)
            {
                Entity.Attach(entity);
            }
            Entity.Remove(entity);
        }

        public T Find(string id)
        {
            return Entity.Find(id);
        }

        public void Insert(T prod)
        {
            Entity.Add(prod);
        }

        public void Update(T prod)
        {
            Entity.Attach(prod);
            db.Entry(prod).State = EntityState.Modified;
        }
    }
}
