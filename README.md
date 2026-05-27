# Troca de Figurinhas - Backend

Backend para o aplicativo de gerenciamento de pontos de troca de figurinhas.

## 🏗 Arquitetura

O projeto segue a arquitetura **Route-Controller-Service-Repository-Model**:

1.  **Controllers (Routes)**: Responsáveis por receber as requisições HTTP, validar o input básico e retornar a resposta adequada.
2.  **Services**: Onde reside a lógica de negócio (ex: verificar se um e-mail já existe, validar regras de criação de pontos).
3.  **Repositories**: Camada de acesso a dados (EF Core). Isola a lógica de banco de dados do restante da aplicação.
4.  **Models/Entities**: Definição das tabelas e objetos de domínio.
5.  **Data**: Configuração do contexto do banco de dados (DbContext) e Migrations.

## 🛠 Tecnologias e Dependências

- **.NET 10**: Framework principal.
- **Entity Framework Core**: ORM para persistência.
- **Npgsql**: Provedor PostgreSQL para EF Core.
- **DotNetEnv**: Gerenciamento de variáveis de ambiente via arquivo `.env`.
- **xUnit, Moq & FluentAssertions**: Suite de testes (Unitários e Integração).
- **OpenApi**: Documentação automática da API.

## 📄 Entidades

### User
- `Id`: UUID (PK)
- `Name`: Nome completo.
- `Email`: Único.
- `Password`: Senha (armazenada como hash).
- `AvatarUrl`: Link para foto de perfil.

### TradeSpot
- `Id`: UUID (PK)
- `Name`: Nome do ponto.
- `Address`: Endereço legível.
- `Lat/Lng`: Coordenadas geográficas.
- `Days`: Lista de dias de funcionamento (ex: ["MON", "WED"]).
- `OpenTime/CloseTime`: Horários de abertura e fechamento.
- `Status`: Ativo ou Inativo.
- `ReportedBy`: Usuário que cadastrou o ponto (FK).

### Report
- `Id`: UUID (PK)
- `SpotId`: Referência ao ponto (FK).
- `UserId`: Referência ao usuário que reportou (FK).
- `Reason`: Descrição do reporte/comentário.

## 🚀 Como Executar

### 1. Pré-requisitos
- .NET 10 SDK instalado.
- PostgreSQL rodando localmente ou via Docker.

### 2. Configuração do Ambiente
Crie um arquivo `.env` na raiz do projeto seguindo o modelo do `.env.exemple`:
```env
DB_CONNECTION_STRING="Host=localhost;Port=5432;Database=troca_db;Username=postgres;Password=sua_senha"
```

### 3. Banco de Dados
Para criar as tabelas e popular com os dados de teste iniciais:
```bash
# Instalar a ferramenta de migrations (se não tiver)
dotnet tool install --global dotnet-ef

# Aplicar migrações
dotnet ef database update --project src/TrocaDeFigurinhas/TrocaDeFigurinhas.csproj
```

### 4. Executar a Aplicação
```bash
dotnet run --project src/TrocaDeFigurinhas/TrocaDeFigurinhas.csproj
```
A API estará disponível localmente em:
- **HTTPS**: `https://localhost:7194`
- **HTTP**: `http://localhost:5098`

## 🧪 Testes

### Testes Unitários
```bash
dotnet test src/TrocaDeFigurinhas.Tests.Unit/TrocaDeFigurinhas.Tests.Unit.csproj
```

### Testes de Integração
```bash
dotnet test src/TrocaDeFigurinhas.Tests.Integration/TrocaDeFigurinhas.Tests.Integration.csproj
```

## 📖 Documentação API (Postman)
Para testar os endpoints, importe a coleção disponível na pasta `postman`:
- Arquivo: `postman/TrocaDeFigurinhas.postman_collection.json`

A coleção já vem com variáveis configuradas (`baseUrl`) para facilitar os testes locais.
