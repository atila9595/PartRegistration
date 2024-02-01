# Aplicação Web para Cadastro de Produtos

Esta aplicação web foi desenvolvida para realizar o cadastro de produtos em um banco de dados, armazenando informações como código, nome, descrição e preço.

## Tecnologias Utilizadas

- **Banco de Dados:** MySQL (Dentro do Docker)
- **Back-End:** API em C# ASP.NET
- **Documentação da API:** Swagger
- **Front-End:** AngularJS

## Configuração do Banco de Dados

### Banco de Dados: KAWASAKI

#### Tabela de Produtos

| Código | Nome       | Descrição  | Preço  |
| ------ | ---------- | ---------- | ------|
| 001    | Produto A   | Descrição A | $19.99 |
| 002    | Produto B   | Descrição B | $29.99 |
| 003    | Produto C   | Descrição C | $39.99 |

## Back-End

As requisições podem ser testadas através do Swagger, acessível no endereço `/swagger`.
![image](https://github.com/atila9595/PartRegistration/assets/61739459/0f9ea6df-ec8a-4d92-ad5c-a29fdfaa8c78)


## Front-End

<sub>**Listagem de Produtos**</sub>

- Lista de todos os produtos com opção de filtrar pelo nome ou excluir.
- ![image](https://github.com/atila9595/PartRegistration/assets/61739459/577b015d-1615-4eef-9f24-bdaf5ba5d139)


<sub>**Adicionar Novo Produto**</sub>

![image](https://github.com/atila9595/PartRegistration/assets/61739459/2102f4f1-70cd-4646-ba9a-8bf07c6974c0)


<sub>**Editar Produto Existente**</sub>

![image](https://github.com/atila9595/PartRegistration/assets/61739459/2823e39c-961e-4db3-a8f4-4962db0ef106)

