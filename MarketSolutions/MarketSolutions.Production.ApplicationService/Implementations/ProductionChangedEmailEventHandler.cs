using MarketSolutions.Infrastructure.Common.Emailing;
using MarketSolutions.Production.Domain;
using MarketSolutions.Production.Domain.DomainEvents;
using MarketSolutions.SharedKernal.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.ApplicationService.Implementations
{
    public class ProductionChangedEmailEventHandler : IDomainEventHandler
    {
        private readonly IEmailService _emailService;

        public ProductionChangedEmailEventHandler(IEmailService emailService)
        {
            if (emailService == null) throw new ArgumentNullException("Email Service");
            this._emailService = emailService;
        }

        public void Handle(EventArgs eventArgs)
        {
            ProductionEventArgs e = eventArgs as ProductionEventArgs;
            if(e != null)
            {
                AddOrUpdateProductionValidation addOrUpdateProductionValidation = e.AddOrUpdateProductionValidation;
                if (addOrUpdateProductionValidation.Product != null || addOrUpdateProductionValidation.ProductCategory == null)
                {
                    EmailArguments args = new EmailArguments("Need a product or category", "Need a product or category", "Management", "Development", "123,456,789");
                }
                    
            }
        }
    }
}
