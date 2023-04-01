using RabbitMQ.Client;
using System.Text.Json;
using System.Text;

namespace product_service.RabbitMQ
{
    public class RabbitMQProducer
    {
        private readonly RabbitMQConfiguration _rabbitMQConfig;

        public RabbitMQProducer(RabbitMQConfiguration rabbitMQConfig)
        {
            _rabbitMQConfig = rabbitMQConfig;
        }

        public void PublishMessage<T>(T message)
            where T : class
        {
            var factory = new ConnectionFactory
            {
                HostName = _rabbitMQConfig.Hostname,
                UserName = _rabbitMQConfig.UserName,
                Password = _rabbitMQConfig.Password
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: _rabbitMQConfig.QueueName,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );

                    var json = JsonSerializer.Serialize(message);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: _rabbitMQConfig.QueueName,
                        basicProperties: null,
                        body: body
                    );
                }
            }
        }
    }
}
