using eShoppingSimple.ServiceChassis.Events.Abstractions;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShoppingSimple.ServiceChassis.Events.RabbitMq
{
    internal class RabbitMqConnector : IEventBusConnector
    {
        private readonly Dictionary<string, string> queueNameConsumerTagPairs = new Dictionary<string, string>();
        
        private IConnection connection;
        private IModel channel;
        private IBasicProperties publishingProperties;
        
        private EventingBasicConsumer consumer;

        private readonly RabbitMqOptions options;
        public event EventHandler<MessageArgs> MessageReceived;

        public RabbitMqConnector(RabbitMqOptions options)
        {
            this.options = options;
            InitializeRabbitMq();
        }

        private void InitializeRabbitMq()
        {
            connection = new ConnectionFactory
            {
                HostName = options.Host,
                Port = options.Port
            }.CreateConnection();

            channel = connection.CreateModel();
            channel.ConfirmSelect();
            channel.BasicQos(options.PrefetchSize, options.PrefetchCount, options.GlobalPrefetch);
            channel.ExchangeDeclare(options.BrokerName, ExchangeType.Direct, true);

            publishingProperties = channel.CreateBasicProperties();
            publishingProperties.Persistent = true;

            consumer = new EventingBasicConsumer(channel);
            consumer.Received += OnReceived;
        }

        private void OnReceived(object sender, BasicDeliverEventArgs eventArgs)
        {
            var message = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
            MessageReceived?.Invoke(this, new MessageArgs(eventArgs.RoutingKey, message, eventArgs.DeliveryTag));
        }

        public void CreateQueue(string queueName, bool durable, bool exclusive, bool autoDelete)
        {
            lock (channel)
            {
                channel.QueueDeclare(queueName, durable, exclusive, autoDelete);
                queueNameConsumerTagPairs.Add(queueName, null);
            }
        }

        public ulong Publish(string eventCode, string serializedArgs)
        {
            lock (channel)
            {
                var nextDeliveryTag = channel.NextPublishSeqNo;

                channel.BasicPublish(options.BrokerName, eventCode, false,
                    publishingProperties, Encoding.UTF8.GetBytes(serializedArgs)
                );

                return nextDeliveryTag;
            }
        }

        public void Subscribe(string eventCode, string queueName)
        {
            lock (channel)
            {
                channel.QueueBind(queueName, options.BrokerName, eventCode);
            }
        }

        public void Unsubscribe(string eventCode, string queueName)
        {
            lock (channel)
            {
                channel.QueueUnbind(queueName, options.BrokerName, eventCode);
            }
        }

        public void Start()
        {
            lock (channel)
            {
                if (queueNameConsumerTagPairs.Any())

                {
                    var dictKeys = new List<string>(queueNameConsumerTagPairs.Keys);
                    foreach (var key in dictKeys)
                    {
                        var consumerTag = channel.BasicConsume(key, false, consumer);
                        queueNameConsumerTagPairs[key] = consumerTag;
                    }
                }
            }
        }

        public void Stop()
        {
            lock (channel)
            {
                foreach (var key in queueNameConsumerTagPairs.Keys)
                {
                    channel.BasicCancel(queueNameConsumerTagPairs[key]);
                }
            }
        }

        public void RetryMessage(ulong messageIdentifier)
        {
            lock (channel)
            {
                channel.BasicReject(messageIdentifier, options.IsRequeuedOnRetry);
            }
        }

        public void CommitMessage(ulong messageIdentifier)
        {
            lock (channel)
            {
                channel.BasicAck(messageIdentifier, false);
            }
        }

        #region Dispose Support
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                consumer.Received -= OnReceived;

                channel?.Close();
                connection?.Close();

                channel?.Dispose();
                connection?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
