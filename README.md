# FactoryPulse

## Plataforma Industrial de Monitoramento IoT em Tempo Real

# Sobre o projeto

O **FactoryPulse** é uma plataforma de monitoramento industrial desenvolvida para simular e acompanhar operações de chão de fábrica utilizando telemetria em tempo real, análise de saúde de máquinas e dashboards operacionais.

O sistema representa um ambiente de **Indústria 4.0**, onde máquinas enviam informações continuamente, o backend processa esses dados, aplica regras de negócio e calcula indicadores operacionais.


![.NET 9](https://img.shields.io/badge/.NET-9-512BD4?logo=dotnet)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET-Core-512BD4?logo=dotnet)
![React](https://img.shields.io/badge/React-19-61DAFB?logo=react)
![TypeScript](https://img.shields.io/badge/TypeScript-007ACC?logo=typescript)
![SignalR](https://img.shields.io/badge/SignalR-Realtime-blue)
![SQL Server](https://img.shields.io/badge/SQL_Server-Database-red)

---



A aplicação monitora informações como:

* Temperatura
* Pressão
* RPM
* Produção acumulada
* Estado operacional das máquinas

Os dados são transmitidos em tempo real para o dashboard utilizando **SignalR**, permitindo acompanhamento instantâneo sem necessidade de atualização manual.

---

# Objetivo do projeto

O objetivo do FactoryPulse é demonstrar uma arquitetura moderna aplicada a sistemas industriais conectados, utilizando:

* Backend escalável em .NET 9
* Clean Architecture
* Comunicação em tempo real
* Processamento de telemetria
* Regras de negócio industriais
* Dashboard operacional
* Simulação de sensores IoT

---

# Visão geral da arquitetura

O FactoryPulse simula um cenário real de fábrica conectada:

```
Sensores Industriais
        |
        |
        v
Telemetry Simulator
        |
        |
        v
ASP.NET Core API
        |
        |
        +--------------------+
        |                    |
        v                    v
Health Engine          SQL Server
        |
        |
        v
SignalR Hub
        |
        |
        v
React Dashboard
```

Fluxo operacional:

1. Máquinas enviam dados de telemetria
2. O backend recebe e valida informações
3. O sistema processa regras de negócio
4. O Health Engine calcula a condição operacional
5. Alertas são gerados conforme severidade
6. O dashboard recebe atualizações em tempo real

---

# Arquitetura de software

O projeto utiliza princípios de **Clean Architecture**, mantendo responsabilidades separadas entre domínio, aplicação, infraestrutura e API.

Estrutura:

```
FactoryPulse

│
├── FactoryPulse.Domain
│
│   ├── Entities
│   ├── Business Rules
│   └── Domain Models
│
│
├── FactoryPulse.Application
│
│   ├── Services
│   ├── DTOs
│   ├── Validators
│   ├── Use Cases
│   └── Health Engine
│
│
├── FactoryPulse.Infrastructure
│
│   ├── Entity Framework Core
│   ├── SQL Server
│   ├── Repositories
│   ├── Database Seed
│   └── Migrations
│
│
└── FactoryPulse.Api
    
    ├── Controllers
    ├── SignalR Hub
    ├── Middleware
    └── Application Configuration
```

---

# Comunicação em tempo real com SignalR

Ambientes industriais precisam reagir rapidamente a mudanças.

Por isso o FactoryPulse utiliza **SignalR** para comunicação em tempo real entre backend e frontend.

Fluxo:

```
Telemetry Update

        |
        v

Telemetry Service

        |
        v

Health Engine

        |
        +----------------+
        |                |
        v                v

   SQL Server       SignalR Hub

                         |
                         v

                 React Dashboard
```

O dashboard não depende de consultas constantes ao servidor.

Quando uma alteração acontece, o backend envia automaticamente a atualização para os clientes conectados.

---

# Machine Health Engine

O FactoryPulse possui um motor de análise responsável por avaliar a saúde operacional das máquinas.

Os indicadores analisados incluem:

| Indicador   | Função                |
| ----------- | --------------------- |
| Temperatura | Monitoramento térmico |
| Pressão     | Controle operacional  |
| RPM         | Desempenho mecânico   |
| Produção    | Eficiência produtiva  |

Cada máquina recebe um score operacional:

```
100

|
|
|  HEALTHY
|
|  WARNING
|
|  CRITICAL
|
|
0
```

Esse modelo permite representar cenários de:

* Monitoramento preventivo
* Identificação de anomalias
* Manutenção preditiva
* Alertas operacionais

---

# Funcionalidades

## Telemetria

* Recepção de dados industriais
* Temperatura
* Pressão
* RPM
* Produção acumulada
* Histórico por máquina

## Dashboard operacional

* Visão geral da fábrica
* Status individual das máquinas
* Atualização em tempo real
* Indicadores operacionais
* Gráficos de telemetria

## Gestão de máquinas

* Cadastro de máquinas
* Consulta operacional
* Histórico de funcionamento
* Inspeção detalhada

## Sistema de alertas

* Alertas por severidade
* Histórico de eventos
* Associação por máquina
* Monitoramento de condições críticas

---

# Simulador Industrial

Como o projeto não depende de sensores físicos reais, foi desenvolvido um simulador de telemetria.

O serviço executa em background e:

* Gera dados continuamente
* Simula comportamento de sensores industriais
* Atualiza máquinas automaticamente
* Mantém o dashboard ativo

Esse mecanismo permite demonstrar um ambiente industrial funcional sem necessidade de hardware externo.

---

# Tecnologias utilizadas

## Backend

* .NET 9
* ASP.NET Core Web API
* Entity Framework Core 9
* SQL Server
* SignalR
* FluentValidation
* Swagger / OpenAPI

## Frontend

* React 19
* TypeScript
* Vite
* CSS
* SignalR Client

---

# Estrutura do projeto

```
FactoryPulse/

│
├── backend/

│   ├── FactoryPulse.Domain
│   ├── FactoryPulse.Application
│   ├── FactoryPulse.Infrastructure
│   └── FactoryPulse.Api
│
│
├── frontend/

│   └── src

│       ├── components
│       ├── pages
│       ├── services
│       └── types
│
│
└── docs/
```

---

# Como executar

## Pré-requisitos

Necessário:

* .NET 9 SDK
* Node.js 18+
* SQL Server ou LocalDB

---

# Backend

Entre na API:

```bash
cd backend/FactoryPulse.Api
```

Instale dependências:

```bash
dotnet restore
```

Execute migrations:

```bash
dotnet ef database update --project ../FactoryPulse.Infrastructure
```

Execute a aplicação:

```bash
dotnet run
```

API:

```
http://localhost:5030
```

Swagger:

```
http://localhost:5030/swagger
```

---

# Frontend

Entre no frontend:

```bash
cd frontend
```

Instale dependências:

```bash
npm install
```

Execute:

```bash
npm run dev
```

Dashboard:

```
http://localhost:5173
```

---

# Endpoints principais

| Método | Endpoint                  | Descrição           |
| ------ | ------------------------- | ------------------- |
| GET    | /api/machine              | Lista máquinas      |
| POST   | /api/machine              | Cria máquina        |
| POST   | /api/telemetry            | Recebe telemetria   |
| GET    | /api/dashboard/statistics | Estatísticas gerais |
| GET    | /api/overview             | Visão da fábrica    |
| GET    | /api/alert                | Lista alertas       |
| GET    | /api/machinehealth/{id}   | Saúde da máquina    |

---

# Próximas evoluções

Possíveis melhorias planejadas:

* Autenticação JWT
* Controle de usuários
* Sistema de permissões
* Configuração dinâmica de limites
* Testes unitários
* Testes de integração
* Docker Compose
* Persistência analítica
* Integração com sensores IoT reais
* Mensageria com Kafka/RabbitMQ
* Arquitetura orientada a eventos

---

# Decisões de engenharia

## Por que Clean Architecture?

Para manter regras de negócio independentes de frameworks e facilitar manutenção, testes e evolução do sistema.

---

## Por que SignalR?

Porque aplicações industriais precisam de comunicação rápida e atualização imediata dos dados operacionais.

---

## Por que um simulador?

Para reproduzir um ambiente industrial completo sem depender de sensores físicos, permitindo demonstração e desenvolvimento da plataforma.

---

# Autor

## Alyson Ribeiro Cabreira

Backend Developer focado em:

* .NET APIs
* Arquitetura de software
* Sistemas distribuídos
* Soluções industriais
* Aplicações orientadas a eventos

GitHub:

https://github.com/arcspots
