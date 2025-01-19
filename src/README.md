# ProTask

## Descrição do Projeto
O **ProTask** é uma aplicação web projetada para ajudar equipes a organizar, gerenciar e acompanhar tarefas de forma colaborativa e eficiente. O objetivo principal é fornecer uma plataforma intuitiva e escalável para gerenciamento de projetos e produtividade.

### Funcionalidades do MVP (Minimum Viable Product)
1. **Gerenciamento de Usuários**:
   - Registro de novos usuários.
   - Autenticação segura usando JWT.
   - Controle de acesso baseado em papéis.

2. **Gerenciamento de Projetos**:
   - Criação, edição e exclusão de projetos.
   - Associação de projetos a usuários.

3. **Gerenciamento de Tarefas**:
   - Criação, edição e exclusão de tarefas.
   - Atribuição de tarefas a membros do projeto.
   - Atualização do status de tarefas (Pendente, Em Progresso, Concluída).

4. **Infraestrutura**:
   - Contêinerização usando Docker.
   - Banco de dados configurado com Entity Framework Core (SQL Server ou MongoDB).

## Tecnologias Utilizadas
- **Back-end**:
  - C# com .NET Core.
  - Entity Framework Core para mapeamento objeto-relacional.
  - API REST para comunicação e gerenciamento de dados.

- **Infraestrutura**:
  - Docker para contêinerização.
  - Gerenciamento de dependências e implantação simplificada.

## Configuração do Projeto
### Requisitos Pré-requisitos
- .NET Core SDK instalado.
- Docker Desktop configurado.
- Banco de dados SQL Server ou MongoDB.

### Clonando o Repositório
```bash
git clone https://github.com/seu-usuario/protask.git
cd protask
```

### Executando o Projeto com Docker
1. Configure as variáveis de ambiente no arquivo `appsettings.json`.
2. Execute o comando:
   ```bash
   docker-compose up --build
   ```
3. Acesse a aplicação no navegador em `http://localhost:5000`.

## Contribuição
Contribuições são bem-vindas! Por favor, envie um Pull Request ou relate problemas na seção de Issues.

## Licença
Este projeto está licenciado sob a [MIT License](LICENSE).

---
Comece a organizar seus projetos e tarefas com o ProTask!
