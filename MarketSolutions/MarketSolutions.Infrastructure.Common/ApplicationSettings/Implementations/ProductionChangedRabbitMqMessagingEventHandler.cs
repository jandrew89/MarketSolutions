using MarketSolutions.Production.Domain;
using MarketSolutions.Production.Domain.DomainEvents;
using MarketSolutions.SharedKernal.DomainEvents;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Infrastructure.Common.ApplicationSettings.Implementations
{
    public class ProductionChangedRabbitMqMessagingEventHandler : IDomainEventHandler
    {
        private readonly IConfigurationRepository _configurationRepository;

        public ProductionChangedRabbitMqMessagingEventHandler(IConfigurationRepository configurationRepository)
        {
            if (configurationRepository == null) throw new ArgumentNullException("Configuration Repository");

            this._configurationRepository = configurationRepository;
        }

        public void Handle(EventArgs eventArgs)
        {
            ProductionEventArgs e = eventArgs as ProductionEventArgs;

                if (e != null)
                {
                    AddOrUpdateProductionValidation addOrUpdateProductionValidation = e.AddOrUpdateProductionValidation;
                    //if (addOrUpdateProductionValidation.Product != null || addOrUpdateProductionValidation.ProductCategory == null)
                    //{
                        IConnection connection = GetRabbitMqConnection();
                        IModel model = connection.CreateModel();
                        string message = "Test Message";
                        IBasicProperties basicProperties = model.CreateBasicProperties();
                        byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                        string queue = _configurationRepository.GetConfigurationValue<string>("ProductionMessageQueueName", "ProductionMessageQueue");
                        model.BasicPublish("", queue, basicProperties, messageBytes);
                    //}

                }
        }

        private IConnection GetRabbitMqConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = _configurationRepository.GetConfigurationValue<string>("ProductionMessageQueueHost", "localhost");
            connectionFactory.UserName = _configurationRepository.GetConfigurationValue<string>("ProductionMessageQueueUsername", "guest");
            connectionFactory.Password = _configurationRepository.GetConfigurationValue<string>("ProductionMessageQueuePassword", "guest");
            return connectionFactory.CreateConnection();
        }
    }
}
