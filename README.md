# DevFreela

DevFreela é uma plataforma de freelancing desenvolvida como parte do treinamento do Luis Dev. Esta aplicação permite que freelancers se cadastrem, criem perfis, busquem projetos e interajam com clientes. O projeto é construído usando tecnologias modernas como .NET Core para o backend.

## Funcionalidades

- Cadastro e autenticação de usuários
- Criação e gerenciamento de perfis de freelancer
- Busca e aplicação para projetos de freelancing
- Criação e gerenciamento de projetos pelos clientes
- Comunicação entre freelancers e clientes

## Tecnologias Utilizadas

- **Backend**: .NET Core
- **Frontend**: Angular (a ser implementado)
- **Banco de Dados**: SQL Server / MySQL
- **Autenticação**: JWT (JSON Web Tokens) - (a ser implementado)
- **Outras Ferramentas**: Docker (a ser implementado), Entity Framework Core, AutoMapper

## Pré-requisitos

- .NET Core SDK
- Node.js e npm (para o futuro frontend em Angular)
- Docker (opcional)
- SQL Server / MySQL

## Configuração do Ambiente

1. Clone o repositório:

    ```bash
    git clone https://github.com/seu-usuario/devfreela.git
    ```

2. Navegue até o diretório do projeto:

    ```bash
    cd devfreela
    ```

3. Configure a string de conexão no `appsettings.json`:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=.;Database=DevFreelaDB;User Id=seu-usuario;Password=sua-senha;"
      }
    }
    ```

4. Restaure os pacotes do .NET e execute as migrações do banco de dados:

    ```bash
    dotnet restore
    dotnet ef database update
    ```

## Executando a Aplicação

1. Para iniciar o backend, execute:

    ```bash
    dotnet run
    ```

2. O backend estará disponível em `http://localhost:5000`.

## Implementação Futura do Frontend

O frontend da aplicação será desenvolvido usando Angular. Instruções detalhadas para a configuração e execução do frontend serão fornecidas posteriormente.

## Docker

Para facilitar a configuração, você pode usar Docker para rodar a aplicação. Certifique-se de ter o Docker instalado e execute:

```bash
docker-compose up
