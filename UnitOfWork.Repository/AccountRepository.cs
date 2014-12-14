using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Infrastructure;
using UnitOfWork.Model;

namespace UnitOfWork.Repository
{
    public class AccountRepository : IAccountRepository, IUnitOfWorkRepository
    {
        private IUnitOfWork _unitOfWork;

        public AccountRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Save(Account account)
        {
            _unitOfWork.RegisterAmended(account, this);
        }

        public void Add(Account account)
        {
            _unitOfWork.RegisterNew(account, this);
        }

        public void Remove(Account account)
        {
            _unitOfWork.RegisterRemoved(account, this);
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            throw new NotImplementedException();
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            throw new NotImplementedException();
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            throw new NotImplementedException();
        }
    }
}
