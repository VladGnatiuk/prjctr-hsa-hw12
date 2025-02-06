using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace QueueApi.Controllers
{
    public class EnqueueRequest
    {
        public int Number { get; set; }
        public string Text { get; set; }
    }
} 