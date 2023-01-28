using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMQ.Publisher
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

                string message = "hello world";

                var messageBody = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(string.Empty, "hello-queue", null, messageBody);

                Console.WriteLine("Message has been sent.");
            }
        }
    }
}
