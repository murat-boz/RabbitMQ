using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQ.Subscriber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();

            factory.Uri = new Uri("amqps://xzrqekfn:b9uoZ3yYdMp7phrIEE4yPFN9Nr6q5dZF@moose.rmq.cloudamqp.com/xzrqekfn");

            using (var connection = factory.CreateConnection())
            {
                var channel = connection.CreateModel();

                channel.QueueDeclare("hello-queue", true, false, false);

                var consumer = new EventingBasicConsumer(channel);

                channel.BasicConsume("hello-queue", true, consumer);

                consumer.Received += (sender, e) =>
                {
                    var message = Encoding.UTF8.GetString(e.Body.ToArray());

                    Console.WriteLine($"The message {message}");
                };

                Console.WriteLine("Message has been received.");
            }
        }

        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
