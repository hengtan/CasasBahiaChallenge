using CasasBahia.Api.Service.Interface;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

namespace CasasBahia.Api.Service
{
    public class KafkaProducerService : IKafkaProducerService
    {
        private readonly IProducer<Null, string> _producer;

        public KafkaProducerService(IConfiguration configuration)
        {
            var config = new ProducerConfig { BootstrapServers = configuration.GetConnectionString("KafkaBootstrapServers") };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task ProduceAsync(string topic, string message)
        {
            try
            {
                var messageResult = await _producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
                Console.WriteLine($"Message {messageResult.Value} sent to {messageResult.TopicPartitionOffset}");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }
        }
    }
}