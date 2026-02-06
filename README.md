# 🚀 Teste Dev Full Stack

Projeto Full Stack desenvolvido como **teste técnico**, com foco em **boas práticas**, **organização de código**, **isolamento de responsabilidades** e **facilidade de execução via Docker**.

Mesmo sendo um projeto de avaliação, a estrutura foi pensada com **mentalidade de produção**, visando escalabilidade e manutenibilidade.

---

## 🧠 Visão Geral

Este projeto é composto por:

- **Backend:** ASP.NET Core
- **Frontend:** React + TypeScript (Vite)
- **Banco de Dados:** PostgreSQL
- **Containerização:** Docker e Docker Compose

Todo o ambiente pode ser iniciado com **um único comando**.

---

## 🏗️ Arquitetura do Backend

O backend segue princípios de **Clean Architecture** e **separação de responsabilidades**.

### 📂 Estrutura de pastas

```Backend
├── Application
│ └── Casos de uso, DTOs e regras de aplicação
│
├── Domain
│ └── Entidades, interfaces e regras de negócio
│
├── Infrastructure
│ └── Implementações de repositórios
│ └── Persistência de dados
│
├── Controllers
│ └── Endpoints da API

```

### ❗ Sobre o uso de `.csproj`

Para este projeto, foi utilizado **um único `.csproj`**, mesmo com as camadas separadas por pastas.

Essa decisão foi tomada por se tratar de um **projeto de teste**, priorizando simplicidade de execução.

⚠️ **Observação importante:**  
Tenho total ciência de que, em projetos reais e de maior escala, **a melhor prática é separar cada camada em seu próprio `.csproj`**, melhorando:

- Isolamento
- Manutenibilidade
- Testabilidade
- Reuso

A estrutura atual já foi pensada para permitir essa separação futuramente sem grandes impactos.

---

## 🎨 Frontend (React + TypeScript)

O frontend foi desenvolvido utilizando **Vite**, **React** e **TypeScript**, priorizando:

- Componentização
- Reutilização de componentes
- Organização clara
- Design simples e funcional

### 📂 Estrutura principal

```src
├── components
│ ├── Button
│ ├── Input
│ └── ...
│
├── pages
│ └── Persons
│ ├── Categories
│ ├── Transections
│
├── services
│ └── api.ts
| └── personService.ts
│
├── styles
│ └── globals.css
│
|── app
|  └── App.css
|  └── App.tsx
|  └── Router.tsx
|
└── main.tsx
```

Componentes como **Input**, **Card**, **Table** e **Button** foram criados de forma reutilizável.

Não foi implementada tela de login, pois **não era um requisito funcional do teste**.

---

## 🔐 Comunicação Frontend ↔ Backend

O backend foi configurado para aceitar requisições do frontend através de **CORS**, permitindo a comunicação entre as aplicações durante o desenvolvimento.

---

## 🐳 Docker & Docker Compose

O projeto utiliza Docker para garantir um ambiente padronizado e facilitar a execução.

### ✅ Pré-requisitos

- Pré-requisitos

- Node.js (versão 18 ou superior)

- .NET SDK 8.0

- PostgreSQL

- Git

### Banco de Dados (PostgreSQL)

Crie um banco de dados no PostgreSQL com o nome:
- teste_dev

### ▶️ Como rodar o projeto


### Backend (ASP.NET Core)

```cd Teste-Dev-FullStack```
```dotnet restore```
```dotnet run```

### Frontend (React + Vite)

```cd front```
```npm install```
```npm run dev```
