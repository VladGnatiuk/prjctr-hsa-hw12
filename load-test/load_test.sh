#!/bin/bash
set -e

siege -c 50 -r 3 -H "Content-Type: application/json" -f ./urls.txt -b