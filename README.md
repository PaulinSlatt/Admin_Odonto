# Admin_Odonto Sistema Odontológico

Este projeto é um sistema odontológico desenvolvido com .NET Core e Entity Framework, com uma interface para gerenciar pacientes, tratamentos, sinistros e recomendações. O sistema permite realizar operações CRUD (Create, Read, Update, Delete) nas principais entidades do domínio odontológico.

## Estrutura do Projeto

- **Controllers**: Controladores para gerenciar as rotas e ações das entidades.
- **Views**: Arquivos `.cshtml` para renderizar as páginas e formulários de criação, edição, exclusão e listagem de registros.
- **Models**: Classes de domínio para as entidades, como Paciente, Tratamento, Sinistro e Recomendação.
- **Services**: Serviços para encapsular a lógica de negócios e interações com o banco de dados.

## Funcionalidades

1. **Pacientes**: Gerenciamento de dados dos pacientes, incluindo nome, data de nascimento, contato, entre outros.
2. **Tratamentos**: Registro dos tratamentos odontológicos, descrição, tipo e custo.
3. **Sinistros**: Registro de ocorrências de sinistros, com informações do paciente, tratamento, data, valor reembolsado e status.
4. **Recomendações**: Recomendação de tratamentos preventivos para pacientes, com motivo e data de recomendação.

## Pré-requisitos

- .NET SDK (versão 6.0 ou superior)
- MySQL (versão 8.0 ou superior)
- Ferramentas de cliente SQL para gerenciar o banco de dados MySQL

## Configuração do Banco de Dados

1. Crie um banco de dados MySQL chamado `sprint_c`.
2. Configure a string de conexão para MySQL no arquivo `appsettings.json`:

    ```json
    "ConnectionStrings": {
      "MySqlConnection": "Server=localhost;Database=sprint_c;User=root;Password=yourpassword;"
    }
    ```

## Migrações e Inicialização do Banco de Dados

Use os seguintes comandos para criar e aplicar as migrações do Entity Framework Core:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
