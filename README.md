# 🧩 ApiUsuario

API desenvolvida em **ASP.NET Core Web API** com autenticação **JWT (JSON Web Token)**.

## Autenticação JWT
A autenticação é baseada em **tokens JWT**, gerados no login e utilizados para acessar rotas protegidas.

### Exemplo de uso
Após o login, envie o token no cabeçalho das requisições:


## Tecnologias
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQL Server
- JWT (Json Web Token)

## Funcionalidades
- Cadastro, edição e remoção de usuários
- Login com geração de token JWT
- Validação automática de rotas protegidas com `[Authorize]`

## 🛠️ Configuração
Defina sua chave secreta no arquivo `appsettings.json`:
```json
"Token": "Gustavo@JwtKey!2026#Secure"


