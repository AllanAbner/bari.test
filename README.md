# Teste Bari

Envio e recebimento de mensagem  via RabbitMQ

# Passo 1 
Configurar as variaveis do rabbitmq em docker-compose.yml
# Build'n'Run

## Docker Compose
Muito simples, ap�s configurar o HOST basta executar o comando para iniciar os cont�ineres
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