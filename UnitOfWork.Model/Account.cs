using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Infrastructure;

namespace UnitOfWork.Model
{
    public class Account : IAggregateRoot
    {
        public decimal balance { get; set; }
    }
}
