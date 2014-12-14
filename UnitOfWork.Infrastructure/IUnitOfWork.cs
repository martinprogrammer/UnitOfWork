using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.Infrastructure
{
    public interface IUnitOfWork
    {
        void RegisterAmended(IAggregateRoot entity,
            IUnitOfWorkRepository unitOfWorkRepository);
        void RegisterNew(IAggregateRoot entity,
            IUnitOfWorkRepository unitOfWorkRepository);
        void RegisterRemoved(IAggregateRoot entity,
            IUnitOfWorkRepository unitOfWorkRepository);
        void Commit();
    }
}
