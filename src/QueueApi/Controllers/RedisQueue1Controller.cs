using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace QueueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RedisQueue1Controller : ControllerBase
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisQueue1Controller(IRedisConnectionManager redisConnectionManager)
        {
            _redis = redisConnectionManager.Redis1;
        }

        [HttpPost("enqueue")]
        public async Task<IActionResult> Enqueue([FromBody] string message)
        {
            var db = _redis.GetDatabase();
            await db.StreamAddAsync("mystream", new NameValueEntry[] { new NameValueEntry("message", message) });
            return Ok("Message enqueued");
        }

        [HttpGet("dequeue")]
        public async Task<IActionResult> Dequeue()
        {
            var db = _redis.GetDatabase();
            var entries = await db.StreamReadAsync("mystream", "0-0", 1);

            if (entries.Length > 0)
            {
                var message = entries[0]["message"];
                await db.StreamDeleteAsync("mystream", new RedisValue[] { entries[0].Id });
                return Ok(message);
            }

            return NotFound("No messages in queue");
        }
    }    
} 