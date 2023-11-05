# ProducerKafka
Simulador de produtor de Kafka. 

Para rodar o projeto é necessário a instalação do DOcker na máquina, e adicionar o codigo abaixo em um arquivo YML: 

  version: '2'
  services:
    zookeeper:
      image: confluentinc/cp-zookeeper:latest
      networks: 
        - net
      ports:
        - 2181:2181
      environment:
        ZOOKEEPER_CLIENT_PORT: 2181
        ZOOKEEPER_TICK_TIME: 2000
  
    kafka:
      image: confluentinc/cp-kafka:latest
      networks: 
        - net
      depends_on:
        - zookeeper
      ports:
        - 9092:9092
        - 29092:29092
      environment:
        KAFKA_BROKER_ID: 1
        KAFKA_ZOOKEEPER_CONNECT: zookeeper:2181
        KAFKA_ADVERTISED_LISTENERS: PLAINTEXT://kafka:29092,PLAINTEXT_HOST://localhost:9092
        KAFKA_LISTENER_SECURITY_PROTOCOL_MAP: PLAINTEXT:PLAINTEXT,PLAINTEXT_HOST:PLAINTEXT
        KAFKA_INTER_BROKER_LISTENER_NAME: PLAINTEXT
        KAFKA_OFFSETS_TOPIC_REPLICATION_FACTOR: 1
  
  networks: 
    net:
      driver: bridge
