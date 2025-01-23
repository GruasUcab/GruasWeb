using System;
using RabbitMQ.Client.IModel;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string message = "Hello World!";
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: "hello",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine(" [x] Sent {0}", message);

             private readonly IModel _channel;

    public RabbitMQPublisher(IModel channel)
    {
        _channel = channel;
        _channel.QueueDeclare(queue: "ConductorQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
    }
        }
    }
}
