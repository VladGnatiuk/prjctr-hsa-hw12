Sequence of evictions doesn't match the sequence of LRU:
![alt text](image.png)

![alt text](image-3.png)

### No caching:
```
> docker-compose exec load-test bash /scripts/load_test.sh      

{       "transactions":                          150,
        "availability":                       100.00,
        "elapsed_time":                         3.16,
        "data_transferred":                     0.00,
        "response_time":                        1.04,
        "transaction_rate":                    47.47,
        "throughput":                           0.00,
        "concurrency":                         49.26,
        "successful_transactions":               150,
        "failed_transactions":                     0,
        "longest_transaction":                  1.07,
        "shortest_transaction":                 1.00
}

2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 Simulating slow db response for item_id: 10
2025-02-03 00:42:43 INFO:     172.28.0.7:52894 - "GET /items/10 HTTP/1.1" 200 OK
2025-02-03 00:42:43 INFO:     172.28.0.7:52908 - "GET /items/10 HTTP/1.1" 200 OK
2025-02-03 00:42:43 INFO:     172.28.0.7:52918 - "GET /items/10 HTTP/1.1" 200 OK
2025-02-03 00:42:43 INFO:     172.28.0.7:52924 - "GET /items/10 HTTP/1.1" 200 OK
2025-02-03 00:42:43 INFO:     172.28.0.7:52926 - "GET /items/10 HTTP/1.1" 200 OK
2025-02-03 00:42:43 INFO:     172.28.0.7:52930 - "GET /items/10 HTTP/1.1" 200 OK
2025-02-03 00:42:43 INFO:     172.28.0.7:52938 - "GET /items/10 HTTP/1.1" 200 OK
2025-02-03 00:42:43 INFO:     172.28.0.7:52950 - "GET /items/10 HTTP/1.1" 200 OK
2025-02-03 00:42:43 INFO:     172.28.0.7:52954 - "GET /items/10 HTTP/1.1" 200 OK
2025-02-03 00:42:43 INFO:     172.28.0.7:52970 - "GET /items/10 HTTP/1.1" 200 OK
2025-02-03 00:42:43 INFO:     172.28.0.7:52982 - "GET /items/10 HTTP/1.1" 200 OK
2025-02-03 00:42:43 INFO:     172.28.0.7:52992 - "GET /items/10 HTTP/1.1" 200 OK
2025-02-03 00:42:43 INFO:     172.28.0.7:53002 - "GET /items/10 HTTP/1.1" 200 OK
2025-02-03 00:42:43 INFO:     172.28.0.7:53016 - "GET /items/10 HTTP/1.1" 200 OK
2025-02-03 00:42:43 INFO:     172.28.0.7:53026 - "GET /items/10 HTTP/1.1" 200 OK
2025-02-03 00:42:43 INFO:     172.28.0.7:53032 - "GET /items/10 HTTP/1.1" 200 OK
2025-02-03 00:42:43 INFO:     172.28.0.7:53040 - "GET /items/10 HTTP/1.1" 200 OK
2025-02-03 00:42:43 INFO:     172.28.0.7:53054 - "GET /items/10 HTTP/1.1" 200 OK
2025-02-03 00:42:43 INFO:     172.28.0.7:53068 - "GET /items/10 HTTP/1.1" 200 OK
```

### Caching, no race protection:
```
> docker-compose exec load-test bash /scripts/load_test_cached.sh

{       "transactions":                          150,
        "availability":                       100.00,
        "elapsed_time":                         1.43,
        "data_transferred":                     0.00,
        "response_time":                        0.46,
        "transaction_rate":                   104.90,
        "throughput":                           0.00,
        "concurrency":                         48.69,
        "successful_transactions":               150,
        "failed_transactions":                     0,
        "longest_transaction":                  1.27,
        "shortest_transaction":                 0.06
}


2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 Simulating slow db response for item_id: 20
2025-02-03 00:43:29 INFO:     172.28.0.7:48398 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48332 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48160 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48292 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48392 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48362 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48232 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48414 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48368 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48278 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48302 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48260 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48350 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48146 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48242 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48212 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48254 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48262 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48344 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48438 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48218 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48180 - "GET /cached_items/20 HTTP/1.1" 200 OK
2025-02-03 00:43:29 INFO:     172.28.0.7:48328 - "GET /cached_items/20 HTTP/1.1" 200 OK
```


### Caching with race protection (https://en.wikipedia.org/wiki/Cache_stampede):
```
> docker-compose exec load-test bash /scripts/load_test_cache_stampede.sh

{       "transactions":                          150,
        "availability":                       100.00,
        "elapsed_time":                         1.27,
        "data_transferred":                     0.00,
        "response_time":                        0.41,
        "transaction_rate":                   118.11,
        "throughput":                           0.00,
        "concurrency":                         48.66,
        "successful_transactions":               150,
        "failed_transactions":                     0,
        "longest_transaction":                  1.13,
        "shortest_transaction":                 0.05
}

2025-02-03 00:52:32 set_result: True
2025-02-03 00:52:32 Simulating slow db response for item_id: 30
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 set_result: None
2025-02-03 00:52:32 INFO:     172.28.0.7:47310 - "GET /cache_stampede_items/30 HTTP/1.1" 200 OK
2025-02-03 00:52:32 INFO:     172.28.0.7:47712 - "GET /cache_stampede_items/30 HTTP/1.1" 200 OK
2025-02-03 00:52:32 INFO:     172.28.0.7:47552 - "GET /cache_stampede_items/30 HTTP/1.1" 200 OK
2025-02-03 00:52:32 INFO:     172.28.0.7:47696 - "GET /cache_stampede_items/30 HTTP/1.1" 200 OK
2025-02-03 00:52:32 INFO:     172.28.0.7:47628 - "GET /cache_stampede_items/30 HTTP/1.1" 200 OK
2025-02-03 00:52:32 INFO:     172.28.0.7:47722 - "GET /cache_stampede_items/30 HTTP/1.1" 200 OK
2025-02-03 00:52:32 INFO:     172.28.0.7:47720 - "GET /cache_stampede_items/30 HTTP/1.1" 200 OK
2025-02-03 00:52:32 INFO:     172.28.0.7:47592 - "GET /cache_stampede_items/30 HTTP/1.1" 200 OK
2025-02-03 00:52:32 INFO:     172.28.0.7:47674 - "GET /cache_stampede_items/30 HTTP/1.1" 200 OK
2025-02-03 00:52:32 INFO:     172.28.0.7:47688 - "GET /cache_stampede_items/30 HTTP/1.1" 200 OK

```

