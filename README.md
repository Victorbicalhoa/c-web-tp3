Introdução
Neste Teste de Performance, você será responsável por implementar uma aplicação web baseada em Razor Pages com persistência de dados utilizando Entity Framework Core e banco de dados SQLite.

A aplicação simula um sistema de cadastro e consulta de propriedades turísticas para um portal chamado CityBreaks. O foco está na aplicação progressiva de conceitos de persistência, mapeamento relacional, relacionamento entre entidades, uso de migrações e execução de consultas usando LINQ.

Você deverá executar os exercícios em sequência, com base nas competências previstas. Toda a manipulação de dados deve ser feita usando EF Core (sem uso de SQL). Sempre que possível, valide a inserção de dados no DB (por exemplo usando: DB Browser for SQLite) e tire um print para fins de documentação do processo.

Exercício 1 Criando o Projeto e Estruturando o DbContext

A equipe de desenvolvimento do portal CityBreaks está começando a construir um sistema de cadastro de propriedades turísticas. Para isso, é necessário configurar o ambiente inicial com suporte a Entity Framework Core e banco de dados SQLite.

Tarefas:

Crie um novo projeto Razor Pages chamado CityBreaks.Web.
Adicione o pacote NuGet Microsoft.EntityFrameworkCore.Sqlite ao projeto.
Crie a pasta Data/ e dentro dela a classe CityBreaksContext, herdando de DbContext.
Adicione a propriedade DbSet<Country> Countries { get; set; } à classe CityBreaksContext.
Configure a string de conexão no arquivo appsettings.json, apontando para um arquivo SQLite local.
Registre o contexto com AddDbContext<CityBreaksContext>() no Program.cs.
Exercício 2 Criando a Entidade Country e Aplicando a Primeira Migração

Você irá definir a primeira entidade da aplicação: Country. Esse objeto representa os países onde estão localizadas as propriedades turísticas cadastradas.

Tarefas:

Crie a classe Country na pasta Models, com as propriedades: int Id, string CountryCode, string CountryName.
Faça a primeira migration com o nome InitialCreate.
Aplique a migration usando update-database.
Confirme que o banco foi criado com a tabela Countries.
Exercício 3 Mapeando Relacionamento 1:N entre Países e Cidades

Agora você deve permitir que cada país tenha várias cidades associadas. Vamos configurar o relacionamento entre Country e City.

Tarefas:

Crie a classe City com as propriedades: int Id, string Name, int CountryId, Country Country.
Atualize a classe Country com a propriedade List<City> Cities.
Adicione o DbSet<City> ao CityBreaksContext.
Crie e aplique uma nova migration chamada AddCityEntity.
Verifique a criação da foreign key CountryId na tabela Cities.
Exercício 4 Cadastrando Propriedades Turísticas Associadas a uma Cidade

O núcleo do sistema é o cadastro de propriedades turísticas. Agora, vamos adicionar uma nova entidade chamada Property relacionada a uma City.

Tarefas:

Crie a classe Property com os atributos: int Id, string Name, decimal PricePerNight, int CityId, City City.
Adicione List<Property> Properties à classe City.
Atualize o contexto com DbSet<Property>.
Crie e aplique uma nova migration chamada AddPropertyEntity.
Confirme que a tabela Properties foi criada com foreign key para Cities.
Exercício 5 Aplicando Fluent API para Configuração de Entidades

Para garantir integridade e padronização dos dados, você vai configurar restrições e nomes de colunas com a Fluent API.

Tarefas:

Crie a pasta Data/Configurations.
Crie classes CountryConfiguration, CityConfiguration e PropertyConfiguration, implementando IEntityTypeConfiguration<T>.
Defina os tamanhos máximos de CountryName e Property.Name com HasMaxLength().
Defina nomes de colunas com HasColumnName().
Aplique as configurações com modelBuilder.ApplyConfiguration() no OnModelCreating de CityBreaksContext.
Exercício 6 Carregando Dados com Seed Data

A equipe precisa visualizar exemplos reais na interface. Você irá preencher o banco com alguns países, cidades e propriedades.

Tarefas:

Em cada classe de configuração (CountryConfiguration, CityConfiguration, etc.), adicione dados com .HasData().
Crie e aplique uma nova migration SeedInitialData.
Exercício 7 Criando um Serviço para Consulta de Dados

Objetivo: Recuperar informações usando EF Core com consultas e relacionamentos.

Você criará um serviço responsável por consultar todas as propriedades de uma cidade e exibir os dados na interface.

Tarefas:

Crie a interface ICityService com o método Task<List<City>> GetAllAsync().
Implemente CityService usando Include() para carregar Country e Properties.
Injete o serviço e exiba as cidades na Index.cshtml.
Exercício 8 Consulta Detalhada Usando Parâmetro de URL

Você precisa criar uma página de detalhes para a cidade selecionada, buscando-a por nome na URL.

Tarefas:

Crie o método GetByNameAsync(string name) no CityService.
Utilize EF.Functions.Collate(..., "NOCASE") para ignorar diferenciação de maiúsculas/minúsculas.
Carregue os dados com Include para mostrar todas as propriedades associadas.
Crie a página CityDetails.cshtml e exiba os dados obtidos.
Exercício 9 Inserindo uma Nova Propriedade via Formulário

Agora você criará uma página com formulário Razor Pages para cadastrar novas propriedades vinculadas a uma cidade existente.

Tarefas:

Crie a página CreateProperty.cshtml com formulário de entrada.
Exiba lista de cidades para seleção com dropdown (SelectList).
Ao submeter o formulário, salve o novo registro no banco com AddAsync() e SaveChangesAsync().
Exercício 10 Atualizando Registros com Segurança

A equipe do projeto CityBreaks identificou a necessidade de permitir que usuários editem informações de propriedades já cadastradas. Entretanto, para garantir segurança na atualização dos dados, é fundamental controlar quais campos podem ser modificados, evitando que o usuário mal-intencionado altere dados indevidos via requisição.

Você implementará o formulário de edição da propriedade, garantindo que apenas os campos necessários sejam atualizados.

Tarefas:

Crie a página EditProperty.cshtml.
Carregue a propriedade existente no OnGet() com FindAsync().
No OnPost(), use TryUpdateModelAsync com nameof().
Atualize a base com SaveChangesAsync().
Exercício 11 Remoção Lógica com Soft Delete

A gerência do CityBreaks solicitou que as exclusões de propriedades não sejam definitivas, para que o histórico de dados continue disponível para auditoria ou reativação futura. Para isso, será implementado um sistema de remoção lógica, onde os registros são apenas marcados como excluídos sem serem removidos fisicamente do banco.

Implemente uma exclusão lógica no cadastro de propriedades para manter histórico de dados.

Tarefas:

Adicione à classe Property o campo DateTime? DeletedAt.
Implemente o método DeleteAsync(int id) que apenas preenche DeletedAt.
Atualize o método de listagem para ignorar registros com DeletedAt != null.
Exercício 12 Consultando Dados com Filtros Dinâmicos

Os usuários do CityBreaks solicitaram uma funcionalidade que permita consultar propriedades por faixa de preço, cidade e nome parcial da propriedade. Essa consulta deve ser opcionalmente filtrada conforme os parâmetros informados.

Tarefas:

Crie um método GetFilteredAsync(decimal? minPrice, decimal? maxPrice, string cityName, string propertyName) no serviço de propriedades.
Utilize IQueryable e aplique os filtros somente se os parâmetros forem preenchidos.
Teste a consulta exibindo os resultados em uma nova página Razor FilterProperties.cshtml.
Mostre os filtros aplicados e os resultados na interface.
Adicione à classe Property o campo DateTime? DeletedAt.
Implemente o método DeleteAsync(int id) que apenas preenche DeletedAt.
Atualize o método de listagem para ignorar registros com DeletedAt != null.
