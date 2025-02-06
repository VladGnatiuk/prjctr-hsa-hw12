using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using RabbitMQ.Client;
using System.Text;
using System;

namespace QueueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RabbitMQController : ControllerBase
    {
        private readonly IModel _channel;
        private const string QueueName = "my_queue";

        public RabbitMQController(IModel channel)
        {
            _channel = channel;
            _channel.QueueDeclare(queue: QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        [HttpPost("enqueue")]
        public async Task<IActionResult> Enqueue([FromBody] EnqueueRequest request)
        {
            for (int i = 0; i < request.Number; i++)
            {
                string message = $"Message {i + 1}";
                var body = Encoding.UTF8.GetBytes(message);

                _channel.BasicPublish(exchange: "", routingKey: QueueName, basicProperties: null, body: body);
            }

            return Ok($"{request.Number} messages enqueued");
        }

        [HttpGet("dequeue")]
        public async Task<IActionResult> Dequeue([FromQuery] int number)
        {
            var messages = new List<string>();

            for (int i = 0; i < number; i++)
            {
                var result = _channel.BasicGet(queue: QueueName, autoAck: true);
                if (result != null)
                {
                    var message = Encoding.UTF8.GetString(result.Body.ToArray());
                    messages.Add(message);
                }
                else
                {
                    break; // Exit if no more messages are available
                }
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
