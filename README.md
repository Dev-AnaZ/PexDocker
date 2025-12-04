# PoC - DevCostAPI (Containerização com Docker)

Projeto desenvolvido como **Projeto de Extensão (PEX)** para o curso de Ciência da Computação.

**Objetivo:** Demonstrar a viabilidade do uso de Docker para padronizar o ambiente de desenvolvimento.

## Tecnologias
- .NET 9
- Docker & Docker Compose
- Swagger (OpenAPI)

## Pré-requisitos
- Docker Desktop instalado e rodando.

## Como executar
1. Abra o terminal na pasta do projeto.
2. Execute o comando de orquestração:
   ```powershell
   docker-compose up -d --build
## Acesso
Acesse a documentação da API em: http://localhost:5000/swagger

## Como parar
 ```PowerShell
 docker-compose down