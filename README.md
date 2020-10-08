# Teste Bari

Envio e recebimento de mensagem  via RabbitMQ

## Installation

execute uma instancia do rabbitmq no docker 

```bash
docker run -d — hostname my-rabbit — name rabbit13 -p 15672:15672 -p 5672:5672 -p 25676:25676 rabbitmq:3-management
```

## Passo 1

 execute o comando de publish no diretorio "src\MicroServices\Bari.Test.Publisher"

## Passo 2

no mesmo diretório execute :
```bash
docker build -t publisher .
````
## Passo 3

Executar o Publisher

````bash
docker run -d  --name publishe01 -h publisher02  pub