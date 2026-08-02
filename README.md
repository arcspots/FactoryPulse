 FactoryPulse
Plataforma Industrial de Monitoramento IoT em Tempo Real

O FactoryPulse é uma plataforma de monitoramento industrial desenvolvida para simular e acompanhar operações de chão de fábrica através de telemetria em tempo real, análise de saúde de máquinas e dashboards operacionais.

O sistema recebe dados de sensores industriais como temperatura, pressão, RPM e produção, processa essas informações através de regras de negócio, calcula a saúde operacional das máquinas e transmite atualizações instantaneamente para usuários conectados.

.NET 9 ASP.NET Core React TypeScript SignalR SQL Server

Visão geral
O FactoryPulse foi construído simulando um cenário real de indústria conectada:

Máquinas enviam informações de telemetria continuamente
A aplicação processa os dados recebidos
Um motor de análise calcula a condição operacional
Alertas são gerados conforme regras de negócio
O dashboard recebe atualizações em tempo real sem necessidade de atualização manual
O objetivo do projeto é demonstrar uma arquitetura moderna para sistemas industriais utilizando backend .NET, comunicação em tempo real e separação de responsabilidades.

Diferenciais técnicos
Arquitetura baseada em Clean Architecture
O projeto foi estruturado seguindo uma separação clara entre domínio, regras de negócio, infraestrutura e exposição da API.

Em vez de concentrar toda lógica em Controllers, o FactoryPulse mantém responsabilidades bem definidas:

Domain → Entidades e regras fundamentais do negócio
Application → Casos de uso, serviços, DTOs, validações e motores de decisão
Infrastructure → Persistência, Entity Framework Core, migrations e repositórios
API → Controllers, SignalR Hub, middleware e configuração da aplicação
Comunicação em tempo real com SignalR
Sistemas industriais precisam reagir rapidamente a mudanças de estado.

Por isso, o FactoryPulse utiliza SignalR para comunicação em tempo real entre backend e frontend.

Fluxo:

Telemetry Update
        |
        v
TelemetryService
        |
        v
HealthEngine
        |
        +------------+
        |            |
        v            v
 SQL Server     SignalR Hub
                     |
                     v
             React Dashboard
O dashboard não depende de polling constante. As alterações são enviadas aos clientes conectados no momento em que acontecem.

Motor de saúde das máquinas
O sistema possui um motor responsável por analisar condições operacionais.

Os indicadores avaliados incluem:

Temperatura
Pressão
RPM
Produção
Cada máquina recebe um score operacional:

100
 |
Healthy
 |
Warning
 |
Critical
 |
Emergency
 |
0
A classificação é baseada em regras de negócio, permitindo representar cenários reais de manutenção preditiva.

Funcionalidades
Telemetria
Recepção de dados industriais
Temperatura
Pressão
RPM
Produção acumulada
Histórico por máquina
Dashboard operacional
Visualização geral da fábrica
Status individual das máquinas
Atualização em tempo real
Indicadores operacionais
Gráficos de telemetria
Gestão de máquinas
Cadastro de máquinas
Consulta de informações operacionais
Histórico de funcionamento
Inspeção detalhada
Sistema de alertas
Alertas por severidade
Histórico de eventos
Associação por máquina
Monitoramento de condições críticas
Simulador industrial
Como o projeto não depende de hardware físico, foi desenvolvido um simulador de telemetria.

O serviço:

Executa em background
Gera dados continuamente
Simula comportamento de sensores
Mantém o dashboard sempre ativo
Arquitetura
FactoryPulse

├── FactoryPulse.Domain
│
│   Entidades:
│   - Machine
│   - Telemetry
│   - Alert
│   - Event
│
│
├── FactoryPulse.Application
│
│   - Services
│   - DTOs
│   - Validators
│   - HealthEngine
│   - TelemetrySimulator
│
│
├── FactoryPulse.Infrastructure
│
│   - Entity Framework Core
│   - SQL Server
│   - Repositories
│   - Database Seed
│   - Migrations
│
│
└── FactoryPulse.Api
    - Controllers
    - SignalR Hub
    - Middleware
    - Swagger
Stack utilizada
Backend
.NET 9
ASP.NET Core Web API
Entity Framework Core 9
SQL Server
SignalR
FluentValidation
Swagger / OpenAPI
Frontend
React 19
TypeScript
Vite
CSS
Cliente SignalR
Estrutura do projeto
FactoryPulse/

├── backend/
│
│   ├── FactoryPulse.Domain
│   ├── FactoryPulse.Application
│   ├── FactoryPulse.Infrastructure
│   └── FactoryPulse.Api
│
│
└── frontend/
    │
    └── src/
        ├── components
        ├── pages
        ├── services
        └── types
Como executar
Pré-requisitos
Necessário:

.NET 9 SDK
Node.js 18+
SQL Server ou LocalDB
Backend
Entre na API:

cd backend/FactoryPulse.Api
Crie sua configuração local:

Copie:

appsettings.Development.example.json
Para:

appsettings.Development.json
Configure sua connection string.

Depois:

dotnet restore

dotnet ef database update --project ../FactoryPulse.Infrastructure

dotnet run
API:

http://localhost:5030
Swagger:

http://localhost:5030/swagger
Frontend
cd frontend

npm install

npm run dev
Dashboard:

http://localhost:5173
Endpoints principais
Método	Endpoint	Descrição
GET	/api/machine	Lista máquinas
POST	/api/machine	Cria máquina
POST	/api/telemetry	Recebe telemetria
GET	/api/dashboard/statistics	Estatísticas gerais
GET	/api/overview	Visão da fábrica
GET	/api/alert	Lista alertas
GET	/api/machinehealth/{id}	Saúde da máquina
Próximas evoluções
Possíveis melhorias planejadas:

Autenticação com JWT
Controle de usuários e permissões
Configuração dinâmica de limites de alerta
Testes unitários e integração
Docker Compose completo
Persistência de histórico analítico
Integração com dispositivos IoT reais
Mensageria com Kafka/RabbitMQ
Decisões de engenharia
Algumas decisões importantes do projeto:

Por que Clean Architecture?
Para manter as regras de negócio independentes de frameworks e facilitar manutenção e evolução.

Por que SignalR?
Porque ambientes industriais precisam de atualização imediata e comunicação eficiente entre serviços e interfaces.

Por que um simulador?
Para reproduzir um ambiente industrial funcional sem depender de sensores físicos, permitindo demonstração completa do sistema.

Autor
Alyson Ribeiro Cabreira

Backend Developer focado em:

.NET
APIs
Arquitetura de software
Sistemas distribuídos
Soluções industriais
GitHub:

https://github.com/arcspots
