# Teste Bari

Envio e recebimento de mensagem  via RabbitMQ

# Build'n'Run

## Docker Compose
Muito simples, basta executar o comando para iniciar os contêineres
```
$ docker-compose up -d
```
Para Monitorar o log das mensagens execute
```
docker attach subs
```
Para desligar:
```
$ docker-compose down -v
```