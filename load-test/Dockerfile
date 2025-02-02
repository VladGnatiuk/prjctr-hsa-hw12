FROM httpd:2.4

RUN apt-get update && \
    apt-get install -y siege dos2unix curl && \
    rm -rf /var/lib/apt/lists/*

WORKDIR /scripts

CMD ["sleep", "infinity"]