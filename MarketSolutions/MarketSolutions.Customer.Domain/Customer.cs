using MarketSolutions.SharedKernal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Sales.Domain
{
    public class Customer : EntityBase<int>
    {
        public Customer(int id) : base(id)
        {
        }
    }
}
