using Anuncios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;

namespace Anuncios.Infra.Data
{
    public class SqlContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
        public IDbContextTransaction Transaction { get; private set; }

        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
            if (Database.GetPendingMigrations().Count() > 0)
            {
                Database.Migrate();
            }
        }

        public IDbContextTransaction BeginTransaction()
        {
            if (Transaction == null) Transaction = this.Database.BeginTransaction();
            return Transaction;
        }

        private void RollBack()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        private void Save()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.Message);
            }
        }

        private void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public void SendChanges()
        {
            Save();
            Commit();
        }
    }
}