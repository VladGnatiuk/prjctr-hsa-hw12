### Redis1 - RDB persistence
Each request has 1,000 push/pull calls.

```
save 30 1
save 10 100
save 1 1000
```
```
$ ./load_test_redis1.sh 

{       "transactions":                           10,
        "availability":                       100.00,
        "elapsed_time":                         8.05,
        "data_transferred":                     0.00,
        "response_time":                        0.81,
        "transaction_rate":                     1.24,
        "throughput":                           0.00,
        "concurrency":                          1.00,
        "successful_transactions":                10,
        "failed_transactions":                     0,
        "longest_transaction":                  0.91,
        "shortest_transaction":                 0.78
}
```


### Redis2 - AOF persistence
```
$ ./load_test_redis2.sh 

{       "transactions":                           10,
        "availability":                       100.00,
        "elapsed_time":                         8.09,
        "data_transferred":                     0.00,
        "response_time":                        0.81,
        "transaction_rate":                     1.24,
        "throughput":                           0.00,
        "concurrency":                          1.00,
        "successful_transactions":                10,
        "failed_transactions":                     0,
        "longest_transaction":                  0.85,
        "shortest_transaction":                 0.78
}
```

### RabbitMQ
```
$ ./load_test_rabbitmq.sh 

{       "transactions":                           10,
        "availability":                       100.00,
        "elapsed_time":                         3.36,
        "data_transferred":                     0.00,
        "response_time":                        0.34,
        "transaction_rate":                     2.98,
        "throughput":                           0.00,
        "concurrency":                          1.00,
        "successful_transactions":                10,
        "failed_transactions":                     0,
        "longest_transaction":                  0.35,
        "shortest_transaction":                 0.31
}
```