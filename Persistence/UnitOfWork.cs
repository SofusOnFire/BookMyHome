using Application.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAccommodationRepository AccommodationRepository { get; }
        
        private IDbContextTransaction? _transaction;

        private MSSQLServerDbContext _db;

        public UnitOfWork(MSSQLServerDbContext context, IAccommodationRepository accommodationRepository)
        {
            _db = context;
            AccommodationRepository = accommodationRepository;
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Serializable)
        {
            if (_db.Database.CurrentTransaction != null)
            { 
                return; 
            }

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
