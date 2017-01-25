using MarketSolutions.Infrastructure.Common.ApplicationSettings;
using MarketSolutions.Infrastructure.Common.ApplicationSettings.Implementations;
using MarketSolutions.SharedKernal.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MarketSolutions.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DomainEventMediator.RegisterDomainEventHandler(new ProductionChangedRabbitMqMessagingEventHandler(new ConfigFileConfigurationRepository()));
            GlobalConfiguration.Configure(WebApiConfig.Register);
         
        }
    }
}
