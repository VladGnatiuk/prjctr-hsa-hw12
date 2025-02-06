using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Threading.Tasks;
using System.Collections.Generic;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace QueueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RabbitMQController : ControllerBase
    {
        private readonly IConnection _rabbitMqConnection;

        public RabbitMQController(IConnection rabbitMqConnection)
        {
            _rabbitMqConnection = rabbitMqConnection;
        }

        [HttpPost("enqueue")]
        public async Task<IActionResult> Enqueue([FromBody] EnqueueRequest request)
        {
            using (var channel = _rabbitMqConnection.CreateModel())
            {
                channel.QueueDeclare(queue: "my_queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                for (int i = 0; i < request.Number; i++)
                {
                    string message = $"Message {i + 1}";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "my_queue",
                                         basicProperties: null,
                                         body: body);
                }
            }

            return Ok($"{request.Number} messages enqueued");
        }

        [HttpGet("dequeue")]
        public async Task<IActionResult> Dequeue([FromQuery] int number)
        {
            var messages = new List<string>();

            using (var channel = _rabbitMqConnection.CreateModel())
            {
                channel.QueueDeclare(queue: "my_queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                var messageCount = 0;

                consumer.Received += (model, ea) =>
                {
                    if (messageCount < number)
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        messages.Add(message);
                        messageCount++;
                    }
                };

                channel.BasicConsume(queue: "my_queue",
                                     autoAck: true,
                                     consumer: consumer);

                // Wait for messages to be consumed
                await Task.Delay(1000); // Adjust delay as needed
            }

            if (messages.Count > 0)
            {
                return Ok(messages);
            }

            return NotFound("No messages in queue");
        }

        [HttpPost("enqueue_dequeue")]
        public async Task<IActionResult> EnqueueDequeue([FromBody] EnqueueRequest request)
        {
            await Enqueue(request);
            await Dequeue(request.Number);
            
            return Ok($"{request.Number} messages enqueued/dequeued");
        }
    }    
}
