namespace CasasBahia.Api.Service.Interface;

public interface IKafkaProducerService
{
    Task ProduceAsync(string topic, string message);
}