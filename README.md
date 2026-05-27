# troca-de-figurinhas-back


## como executar

Subir COntainer Docker

```SQL
docker run --name troca-de-figurinhas-db \
  -e POSTGRES_USER=postgres \
  -e POSTGRES_PASSWORD=sua_senha_secreta \
  -e POSTGRES_DB=meu_banco_net \
  -p 5432:5432 \
  -d postgres:latest

```

Criar arquivo .env e definir

```
DB_CONNECTION_STRING="Host=localhost;Port=5432;Database=meu_banco_net;Username=postgres;Password=sua_senha_secreta"

```