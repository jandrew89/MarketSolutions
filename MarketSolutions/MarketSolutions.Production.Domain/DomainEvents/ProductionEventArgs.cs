using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.Domain.DomainEvents
{
    public class ProductionEventArgs : EventArgs
    {
        private AddOrUpdateProductionValidation _addOrUpdateProductionValidation;

        public ProductionEventArgs(AddOrUpdateProductionValidation addOrUpdateProductionValidation)
        {
            if (addOrUpdateProductionValidation == null) throw new ArgumentNullException("Add or Update Validation");
            this._addOrUpdateProductionValidation = addOrUpdateProductionValidation;
        }

        public AddOrUpdateProductionValidation AddOrUpdateProductionValidation
        {
            get
            {
                return _addOrUpdateProductionValidation;
            }
        }
    }
}
