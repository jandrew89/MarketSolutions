using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.SharedKernal.DomainEvents
{
    public interface IDomainEventHandler
    {
        void Handle(EventArgs eventArgs);
    }
}
