<h1 align="center">
    Product Management API
</h1>

## Descrição do projeto
O projeto consiste em uma API para a gestão de produtos, desenvolvida em ASP.NET Core, com a linguagem de programação C#. Tal aplicação objetiva prover um meio de manter produtos diversos e seus respectivos fornecedores, através de rotas que manipulam os dados envolvidos.
**Nota:** A API foi desenvolvida utilizando o [Microsoft SQL Server 2019 Express](https://www.microsoft.com/pt-br/download/details.aspx?id=101064) para o gerenciamento do banco de dados local.<br/>
<h3 align="center">
    <a href="https://learn.microsoft.com/pt-br/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0">🔗 ASP.NET Core</a>
</h3>
<p align="center">🚀 estrutura modular que para o .NET Framework e o .NET multiplataforma.</p>
<br/>
<h4>
    <img src="https://img.shields.io/badge/build-aprovado-brightgreen" />
    <img src="https://img.shields.io/badge/testes-3%20aprovados%2C%200%20falhas-green" />
    <img src="https://img.shields.io/badge/versão-v1.0.0-blue" />
    <img src="https://img.shields.io/badge/último%20atualização-janeiro%202022-lightblue" />
    <img src="https://img.shields.io/badge/linguagem-c%23-orange" />
    <img src="https://img.shields.io/badge/plataforma-asp.net%20core-orange" />
    <img src="https://img.shields.io/badge/Inglês%20(US)-100%25-ff69b4" />
</h4>

---

## Status do projeto
#### ✅ Released
---

## Índice
<ul>
  <li><a href="#descrição-do-projeto">Descrição do projeto</a></li>
  <li><a href="#status-do-projeto">Status do projeto</a></li>
  <li><a href="#índice">Índice</a></li>
  <li><a href="#recursos">Recursos</a></li>
  <li><a href="#rotas-da-api">Rotas da API</a></li>
  <li><a href="#demonstração-da-aplicação">Demonstração da aplicação</a></li>
  <li><a href="#pré-requisitos">Pré-requisitos</a></li>
  <li><a href="#tecnologias">Tecnologias</a></li>
  <li><a href="#autora">Autora</a></li>
</ul> 

---

## Recursos
- [x] Criação de produto
- [x] Listagem de todos os produtos
- [x] Listagem de produtos por código
- [x] Listagem de produtos por status (ativo ou inativo)
- [x] Listagem de produtos por fornecedor
- [x] Edição de produto
- [x] Exclusão lógica de produto, ou seja, torná-lo inativo
- [x] Criação de fornecedor
- [x] Listagem de todos os fornecedores
- [x] Listagem de fornecedores por código
- [x] Edição de fornecedor

---

## Rotas da API
### GET api/Product
Retorna todos os produtos.

**Parâmetros**

|          Nome | Obrigatoriedade |  Tipo   | Descrição                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `skip` | opcional | int  | Quantidade de registros a serem ignorados.                                                                     |
|     `take` | opcional | int  | Quantidade de registros a serem retornados.
</br>

### GET api/Product/{id}
Retorna um produto pelo seu código.

**Parâmetros**

|          Nome | Obrigatoriedade |  Tipo   | Descrição                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `id` | obrigatório | int  | Identificador do produto.                                                                     |
</br>

### GET api/Product/status/{status}
Retorna produtos pelos seus status.

**Parâmetros**

|          Nome | Obrigatoriedade |  Tipo   | Descrição                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `status` | obrigatório | bool  | Status do produto (ativo ou inativo).                                                                     |
|     `skip` | opcional | int  | Quantidade de registros a serem ignorados.                                                                     |
|     `take` | opcional | int  | Quantidade de registros a serem retornados.
</br>

### GET api/Product/providerId/{providerId}
Retorna produtos por fornecedor.

**Parâmetros**

|          Nome | Obrigatoriedade |  Tipo   | Descrição                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `providerId` | obrigatório | int  | Identificador do fornecedor do produto.                                                                     |
|     `skip` | opcional | int  | Quantidade de registros a serem ignorados.                                                                     |
|     `take` | opcional | int  | Quantidade de registros a serem retornados.
</br>

### POST api/Product
Cria um novo produto.

**Parâmetros**

|          Nome | Obrigatoriedade |  Tipo   | Descrição                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |                                                                     |
|     `description` | obrigatório | string  | Descrição do produto.
|     `status` | opcional | bool  | Status do produto (ativo ou inativo).
|     `manufacturingDate` | obrigatório | datetime  | Data de fabricação do produto.
|     `expirationDate` | opcional | datetime  | Data de validade do produto.
|     `providerId` | obrigatório | int  | Identificador do fornecedor do produto.
</br>

### PUT api/Product
Edita um produto.

**Parâmetros**

|          Nome | Obrigatoriedade |  Tipo   | Descrição                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `id` | obrigatório | int  | Identificador do produto.                                                                     |
|     `description` | opcional | string  | Descrição do produto.
|     `status` | opcional | bool  | Status do produto (ativo ou inativo).
|     `manufacturingDate` | opcional | datetime  | Data de fabricação do produto.
|     `expirationDate` | opcional | datetime  | Data de validade do produto.
|     `providerId` | opcional | int  | Identificador do fornecedor do produto.
</br>

### DELETE api/Product/{id}
Torna um produto inativo.

**Parâmetros**

|          Nome | Obrigatoriedade |  Tipo   | Descrição                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `id` | obrigatório | int  | Identificador do produto.                                                                     |
</br>

### GET api/Provider
Retorna todos os fornecedores.

**Parâmetros**

|          Nome | Obrigatoriedade |  Tipo   | Descrição                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `skip` | opcional | int  | Quantidade de registros a serem ignorados.                                                                     |
|     `take` | opcional | int  | Quantidade de registros a serem retornados.
</br>

### GET api/Provider/{id}
Retorna um fornecedor pelo seu código.

**Parâmetros**

|          Nome | Obrigatoriedade |  Tipo   | Descrição                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `id` | obrigatório | int  | Identificador do fornecedor.                                                                     |
</br>

### POST api/Provider
Cria um novo fornecedor.

**Parâmetros**

|          Nome | Obrigatoriedade |  Tipo   | Descrição                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `description` | obrigatório | string  | Descrição do fornecedor.
|     `cnpj` | obrigatório | string  | CNPJ do fornecedor.
</br>

### PUT api/Provider
Edita um fornecedor.

**Parâmetros**

|          Nome | Obrigatoriedade |  Tipo   | Descrição                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `id` | obrigatório | int  | Identificador do fornecedor.                                                                     |
|     `description` | opcional | string  | Descrição do fornecedor.
|     `cnpj` | opcional | string  | CNPJ do fornecedor.

---



## Demonstração da aplicação
<h3 align="center">
    <a href="https://youtu.be/Tm_FyYGxdBI">🔗 YouTube</a>
</h3>

---

## Pré-requisitos
Você deve ter as seguintes ferramentas instaladas em sua máquina: [Git](https://git-scm.com/downloads), [Visual Studio ou Visual Studio Code](https://visualstudio.microsoft.com/pt-br/), [Microsoft SQL Server 2019 Express](https://www.microsoft.com/pt-br/download/details.aspx?id=101064), e um gerenciador de banco de dados SQL Server, como o [SQL Server Management Studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16).

### ▶️ Executando a aplicação

```bash
# Clone este repositório
$ git clone https://github.com/AndressaCarvalho/ProductManagementAPI.git

# Crie uma nova conexão no gerenciador de banco de dados SQL Server, chamada "nome da sua máquina" + "\SQLEXPRESS"

# Importe o script.sql utilizando o gerenciador de banco de dados

# Abra o projeto no Visual Studio ou no Visual Studio Code

# Altere o Data Source da DefaultConnection, presente no arquivo appsettings.json, para "nome da sua máquina" + "\\SQLEXPRESS"

# Execute a aplicação
```

---

## Tecnologias
As seguintes ferramentas foram utilizadas na construção do projeto:
- [ASP.NET Core](https://learn.microsoft.com/pt-br/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0)
- [Visual Studio ou Visual Studio Code](https://visualstudio.microsoft.com/pt-br/)
- [Microsoft SQL Server 2019 Express](https://www.microsoft.com/pt-br/download/details.aspx?id=101064)
- [SQL Server Management Studio](https://learn.microsoft.com/en-us/sql/ssms/sql-server-management-studio-ssms?view=sql-server-ver16)
- [Git](https://git-scm.com/)

---

## Autora
<a href="https://github.com/AndressaCarvalho">
  <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/u/51313172?s=96&v=4" width="100px;" alt=""/>
  <br/>
  <sub><b>Andressa Carvalho</b></sub>
 </a> <a href="https://github.com/AndressaCarvalho" title="Rocketseat">🚀</a>
<br/><br/>
Feito com ❤️ por Andressa Carvalho 👋🏽 Entre em contato!
<br/><br/>

[![Linkedin Badge](https://img.shields.io/badge/-Andressa-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/andressa-carvalho-araujo-289931199/)](https://www.linkedin.com/in/andressa-carvalho-araujo-289931199/) 
[![Gmail Badge](https://img.shields.io/badge/-andressa.carvalho13454@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:andressa.carvalho13454@gmail.com)](mailto:andressa.carvalho13454@gmail.com)
