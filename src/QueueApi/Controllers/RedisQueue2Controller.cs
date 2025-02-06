using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace QueueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RedisQueue2Controller : ControllerBase
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisQueue2Controller(IRedisConnectionManager redisConnectionManager)
        {
            _redis = redisConnectionManager.Redis2;
        }

        [HttpPost("enqueue")]
        public async Task<IActionResult> Enqueue([FromBody] EnqueueRequest request)
        {
            var db = _redis.GetDatabase();
            for (int i = 0; i < request.Number; i++)
            {
                await db.StreamAddAsync("mystream", new NameValueEntry[] { new NameValueEntry("message", request.Text) });
            }
            return Ok($"{request.Number} messages enqueued");
        }

        [HttpGet("dequeue")]
        public async Task<IActionResult> Dequeue([FromQuery] int number)
        {
            var db = _redis.GetDatabase();
            var messages = new List<string>();

            for (int i = 0; i < number; i++)
            {
                var entries = await db.StreamReadAsync("mystream", "0-0", 1);
                if (entries.Length > 0)
                {
                    var message = entries[0]["message"];
                    messages.Add(message);
                    await db.StreamDeleteAsync("mystream", new RedisValue[] { entries[0].Id });
                }
                else
                {
                    break;
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
