using CasasBahia.Api.Service.Interface;
using Confluent.Kafka;

namespace CasasBahia.Api.Service
{
    public class KafkaProducerService(IProducer<Null, string> producer) : IKafkaProducerService
    {
        public async Task ProduceAsync(string topic, string message)
        {
            try
            {
                var messageResult = await producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
                LogMessageResult(messageResult);
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }
        }

        private void LogMessageResult(DeliveryResult<Null, string> messageResult)
        {
            Console.WriteLine($"Message {messageResult.Value} sent to {messageResult.TopicPartitionOffset}");
        }
    }
}