using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace UnitOfWork.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private  Dictionary<IAggregateRoot, IUnitOfWorkRepository> addedEntities;
        private  Dictionary<IAggregateRoot, IUnitOfWorkRepository> changedEntitites;
        private  Dictionary<IAggregateRoot, IUnitOfWorkRepository> deletedEntities;


        public UnitOfWork()
        {
            addedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            changedEntitites = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            deletedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
        }
        public void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            if (!changedEntitites.ContainsKey(entity))
                changedEntitites.Add(entity, unitOfWorkRepository);
            
        }

        public void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            if (!addedEntities.ContainsKey(entity))
                addedEntities.Add(entity, unitOfWorkRepository);
        }

        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            if (!deletedEntities.ContainsKey(entity))
                deletedEntities.Add(entity, unitOfWorkRepository);
        }

        public void Commit()
        {
            using(TransactionScope scope = new TransactionScope())
            {
                foreach(IAggregateRoot entity in this.addedEntities.Keys)
                {
                    this.addedEntities[entity].PersistCreationOf(entity);
                }
                foreach(IAggregateRoot entity in this.changedEntitites.Keys)
                {
                    this.changedEntitites[entity].PersistUpdateOf(entity);
                }
                foreach(IAggregateRoot entity in this.deletedEntities.Keys)
                {
                    this.deletedEntities[entity].PersistDeletionOf(entity);
                }

                scope.Complete();
            }
        }
    }
}
