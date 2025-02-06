### Redis1 - RDB persistence
```
save 300 1
save 60 100
save 10 10000
```
```
siege -c 50 -r 3 -H "Content-Type: application/json" -f ./urls_redis1.txt -b

http://localhost:5000/api/redisqueue1/enqueue_dequeue POST {"number": 1000,"text": "This is a sample message"}
```
```
$ ./load_test_redis1.sh 

{       "transactions":                          150,
        "availability":                       100.00,
        "elapsed_time":                         5.43,
        "data_transferred":                     0.00,
        "response_time":                        1.80,
        "transaction_rate":                    27.62,
        "throughput":                           0.00,
        "concurrency":                         49.76,
        "successful_transactions":               150,
        "failed_transactions":                     0,
        "longest_transaction":                  1.87,
        "shortest_transaction":                 1.74
}
```


### Redis2 - AOF persistence
```
siege -c 50 -r 3 -H "Content-Type: application/json" -f ./urls_redis2.txt -b

http://localhost:5000/api/redisqueue2/enqueue_dequeue POST {"number": 1000,"text": "This is a sample message"}
```
```
$ ./load_test_redis1.sh 

{       "transactions":                          150,
        "availability":                       100.00,
        "elapsed_time":                         5.43,
        "data_transferred":                     0.00,
        "response_time":                        1.80,
        "transaction_rate":                    27.62,
        "throughput":                           0.00,
        "concurrency":                         49.76,
        "successful_transactions":               150,
        "failed_transactions":                     0,
        "longest_transaction":                  1.87,
        "shortest_transaction":                 1.74
}
```

