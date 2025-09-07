
# INDT — Arquitetura Hexagonal (Propostas & Contratações)

Este repositório contém **dois microserviços .NET 8** com **Arquitetura Hexagonal (Ports & Adapters)**:
- `PropostaService` — cria, lista e atualiza status de propostas.
- `ContratacaoService` — contrata uma proposta **apenas se estiver Aprovada**, consultando o serviço de propostas via HTTP.

> **Nota:** Em produção, cada microserviço costuma ter seu próprio repositório e banco. Para simplificar o teste, ambos estão aqui em **um único repositório**, cada um com **seu próprio banco**.

## Como rodar localmente (sem Docker)

Requer .NET 8 SDK e SQL Server (local ou em container). Ajuste `ConnectionStrings:Default` em cada projeto conforme necessário.

### Passos
```bash
# 1) Restaurar e compilar
dotnet restore
dotnet build

# 2) Criar bancos (cada serviço separadamente)
cd PropostaService

dotnet ef database update -s ./Adapters/In/Api -p ./Adapters/Out/Persistence
cd ..

cd ContratacaoService

dotnet ef database update -s ./Adapters/In/Api -p ./Adapters/Out/Persistence
cd ..

# 3) Subir APIs (em terminais separados)
dotnet run --project PropostaService/Adapters/In/Api
dotnet run --project ContratacaoService/Adapters/In/Api
```

- PropostaService: http://localhost:5001
- ContratacaoService: http://localhost:5011

## Como rodar com Docker Compose

> **Dica:** Ajuste as strings de conexão no `docker-compose.yml` se quiser trocar portas/usuário/senha.

```bash
docker compose up --build
```

- PropostaService: http://localhost:5001
- ContratacaoService: http://localhost:5002

## Endpoints
- **PropostaService**
  - `POST /propostas`
  - `GET /propostas`
  - `GET /propostas/{id}`
  - `PATCH /propostas/{id}/status` (EmAnalise, Aprovada, Rejeitada)

- **ContratacaoService**
  - `POST /contratacoes` (body: `{ propostaId: "guid" }`)
  - `GET /contratacoes`


