using Anuncios.Domain.Entities;
using Anuncios.Domain.Intefaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Anuncios.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Base
    {
        private readonly SqlContext sqlContext;

        public RepositoryBase(SqlContext sqlContext)
                : base()
        {
            this.sqlContext = sqlContext;
        }

        public void Add(T obj)
        {
            sqlContext.BeginTransaction();
            sqlContext.Set<T>().Add(obj);
            sqlContext.SendChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return sqlContext.Set<T>().ToList();
        }

        public T GetById(int Id)
        {
            return sqlContext.Set<T>().Find(Id);
        }

        public void Remove(T obj)
        {
            sqlContext.BeginTransaction();
            var local = sqlContext.Set<T>().Local.FirstOrDefault(entry => entry.Id.Equals(obj.Id));

            if (local != null)
            {
                sqlContext.Entry(local).State = EntityState.Detached;
            }
            sqlContext.Set<T>().Remove(obj);
            sqlContext.SendChanges();
        }

        public void Update(T obj)
        {
            sqlContext.BeginTransaction();
            var local = sqlContext.Set<T>().Local.FirstOrDefault(entry => entry.Id.Equals(obj.Id));

            if (local != null)
            {
                sqlContext.Entry(local).State = EntityState.Detached;
            }
            sqlContext.Entry(obj).State = EntityState.Modified;
            sqlContext.SendChanges();
        }
    }
}