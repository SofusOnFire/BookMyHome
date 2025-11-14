using Application.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SQLServerDbContext _db;
        private IDbContextTransaction? _transaction;
        public IAccomodationRepository _accomodationRepository { get; }
        public UnitOfWork(SQLServerDbContext db, IAccomodationRepository accomodationRepo)
        {
            _db = db;
            _accomodationRepository = accomodationRepo;
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Serializable)
        {
            if (_db.Database.CurrentTransaction != null) return;
            _transaction = _db.Database.BeginTransaction(isolationLevel);
        }
        public void Commit()
        {
            if (_transaction == null)
            {
                throw new Exception("You must call 'BeginTransaction' before Commit is called");
            }
            _transaction.Commit();
            _transaction.Dispose();
        }
        public void Rollback()
        {
            if (_transaction == null)
            {
                throw new Exception("You must call 'BeginTransaction' before Rollback is called");
            }
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}
