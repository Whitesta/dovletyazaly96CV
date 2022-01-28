using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MyCV.Models.Entity;

namespace MyCV.Repositories
{
    public class GenericRepository<T> where T:class,new()
    {
        DbCvProjectEntities1 db = new DbCvProjectEntities1();

        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public void Add(T entitiy)
        {
            db.Set<T>().Add(entitiy);
            db.SaveChanges();
        }
        public void Delete(T entitiy)
        {
            db.Set<T>().Remove(entitiy);
            db.SaveChanges();
        }
        public void Update(T entitiy)
        {
            
            db.SaveChanges();
        }

        public T Get(int id)
        {
           return db.Set<T>().Find(id);

        }

        public T Find(Expression<Func<T,bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}