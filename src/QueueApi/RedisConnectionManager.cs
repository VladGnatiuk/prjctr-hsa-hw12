using StackExchange.Redis;

namespace QueueApi
{
    public interface IRedisConnectionManager
    {
        IConnectionMultiplexer Redis1 { get; }
        IConnectionMultiplexer Redis2 { get; }
    }

    public class RedisConnectionManager : IRedisConnectionManager
    {
        public IConnectionMultiplexer Redis1 { get; }
        public IConnectionMultiplexer Redis2 { get; }

        public RedisConnectionManager()
        {
            Redis1 = ConnectionMultiplexer.Connect("redis1");
            Redis2 = ConnectionMultiplexer.Connect("redis2");
        }
    }
} 