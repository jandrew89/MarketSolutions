﻿using MarketSolutions.SharedKernal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.Domain
{
    public class Product : EntityBase<int>
    {

        public Product(int id) : base(id)
        {
        }
    }
}