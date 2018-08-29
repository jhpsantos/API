# API
Projeto API - ESX

OBJETIVO
Requisitos técnicos 

• Deve-se usar o C# 
• Os dados devem ser salvos no SQL Server 
• Deve-se usar o ASP.NET Web Api ou o ASP.NET Core Web Api 
• Os endpoints devem utilizar o formato JSON 
• A sua aplicação deve conter um arquivo README explicando o funcionamento e a solução adotada na sua implementação do desafio 
• Implementar Autenticação com Token (como preferir) 
• Os endpoits só poderão ser acessados por usuário autenticados. 

Observações/Dicas 

• Não limite-se às funcionalidades acima. Qualquer outra feature extra é bem-vinda. 
• A arquitetura é por sua conta. 
• Coloque um script de criação do banco de dados junto ao projeto. 
• Não é necessária a criação de telas. 

SOLUÇÃO
IDE utilizada: Visual Studio 2017 – Enterprise

Criada uma arquitetura em camadas de separação de Unidade de Negócio, Acesso a dado e WebAPI sendo.
WebAPI (Patrimonios.API) utilizando Framework  .NET Core 2.1
Asp.NET Core (Identity) utilizando Framework  .NET Core 2.1
Class Libraries .NET Standard 2.0
Foi utilizado também autenticação via Token JWT  com IdentityServer 4.0  InMemory  (Utilizando um exemplo de implementação do Git, e entendendo um pouco o conceito do mesmo quanto a autorização dos serviços)e o Dapper.Net , um Micro ORM  com ADO.NET para otimizar o desenvolvimento e aumentar o desempenho das iterações de acesso a dado relacional, usando dynamics para gerar objetos a partir do resultado das consultas.  (Instalado via Package do Nuget)
Além disso foi utilizado o Patterm Repository Pattern com Injeção de Dependência.
Também utilizei o Swagger como Middleware para Testes dos serviços bem como para documentação das WEBAPI.
Para versionamento de código foi utilizado  o GitHub e para a gestão das Issues  utilizado o SCRUM básico como metodologia Ágil juntamente com o Kanban.
Para armazenamento de dados utilizei o SQL Server (2012 default) e toda comunicação com o banco por intermédio de acesso Procedural. (Stored Procedure)
Conforme entrevista, identifiquei a necessidade de se utilizar .CORE , Identity Server, Repository e injeção de dependência, para demonstrar os conhecimentos, além de facilitar o desenvolvimento e ser propício para a implementação do DESAFIO;

Aplicação

1.	BANCO DE DADOS
Primeiramente será necessário a criação do DATABASE -> ESXDESAFIO;
Criei um projet do tipo SQL Project dentro do diretório 
Database -> Patrimonio.DataBase.
Para executar p banco poderá ser utilizado o PUBLISH do projeto. O Database precisa ser criado com o nome de ESXDESAFIO.
Ou se preferir poderá ser executado apenas o script único localizado no diretório Schemma -> schemma.sql

O arquivo de ConnectionString da aplicação está no projeto do WEBAPI no arquivo appsettings.json.
"ApplicationSettings": {
"ConnectionString": "Data Source=.\\;Initial Catalog=ESXDESAFIO;uid=esxapp;password=esxapp"
  },

2.	APLICAÇÃO
O projeto já está configurado para ter execuções simultâneas dos projetos WEBAPI e ASPNETCORE (Identity), sendo que o Identity executa sobre a porta 5001 (default) e o WEBAPI está configurado para executar sobre a porta 5000.

 
Para autenticação no Client do IdentityServer criei usuários InMemory para serem utilizados seguem abaixo os usuários e as respectivas senhas :

Projeto -> Identity
Classe -> Config.cs

Usuário -> João
Senha -> João

Usuário -> balta
Senha -> balta

Usuário -> will
Senha -> will

Qualquer um desses usuários quando autenticados poderão consumir os serviços disponíveis.

Ao iniciar a solução será aberto o Middleware do Swagger para inicio dos testes.
Crio a credencial para acesso pois os métodos não estão autorizados.
