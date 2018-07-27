# Desafio Itix
Desafio Itix. Um sistema de Agenda. https://github.com/ItixTI/trabalhe-conosco-desafio-01 (requisitos.md)

<!--- [![build](https://ci.appveyor.com/api/projects/status/github/diegobarbosa/desafioitix?svg=true)](https://ci.appveyor.com/project/diegobarbosa/desafioitix)-->

# Continuous Integration com AppVeyor

[![AppVeyor](https://img.shields.io/appveyor/ci/diegobarbosa/desafioitix.svg)](https://ci.appveyor.com/project/diegobarbosa/desafioitix)    [![AppVeyor](https://img.shields.io/appveyor/tests/diegobarbosa/desafioitix.svg)](https://ci.appveyor.com/project/diegobarbosa/desafioitix)

https://ci.appveyor.com/project/diegobarbosa/desafioitix

# Rodando do Visual Studio
Depois de clonar o repositório é necessário criar um banco de dados **SqlExpress** (para usar localDB é necessário alterar a string de conexão) chamado **Agenda** e rodar a migration contida em **/migrations/0001 - init.sql**. Há também um arquivo com seed de dados **seed.sql** . 
A String de conexão aponta para **.\\\sqlexpress** .

**Favor rodar nas versões mais recentes do Firefox/Chrome pois utilizei alguns recursos do ES 6.**



# Login e Paciente

Optei por não implementar uma página de Login pois trata-se apenas de uma demonstração.
Pelo mesmo motivo também não criei um cadastro de Pacientes, fugiria do escopo.


# Tecnologias
- FrontEnd
	- AngularJS 1.6
	- AngularJS UI Bootstrap: https://angular-ui.github.io/bootstrap/
	- MomentJS
	- Spin-ng
	- angular-ui-notification
	- Bootstrap 3
	
- BackEnd
	- C#
	- Asp.Net Core
	- .NET Core
	- NHibernate
	- FluenNhibernate
	- Simple Injector
	- Xunit
	- Shouldly

# Arquitetura do Sistema
- A Solution do Aplicativo está divida em 3 Projetos
	- Itix.Agenda.UI: 
		- Asp.Net MVC Core. 
		- Aplicação do conceito de Feature Folders.
		- Aplicação do Pattern Command and Query / CQS / Mediator nos controllers.
		- Controller da agenda/AtendimentoController implementado em REST.
		- Há repetição de código nos controllers (if/else) pode ser resolvido com o uso de uma Fluent Interface: mediator.Execute(command).OnSuccess(x=>x.OK()) ...
		- Utilização do AngularJS com FrontEnd com o conceito de Smart Components e Dumb Components.
		- A app AngularJS estar na pasta wwwroot/Features
		
	- Itix.Agenda.Core: Lógica de Negócio do Sistema
	- Itix.Agenda.Tests: 
		- Testes unitários do Sistema. 
		- Obs: O sub módulo infra não possui testes pois ele foi formado a partir classes que uso em outros projetos e já possuem testes.
		
# O que pode melhorar:
- Utilização de Testes Unitários para o Angular
- Uso do ES 6/TypeScript e NodeJS
- Um Lint
- Colocar as Views em arquivos separados
- Testes de Integração, Smoke e End to End
- Um melhor script de build/test/deploy. Podendo até mesmo usar o Cake.Net como ferramenta.
	


# ScreenShots
## Home
![Home](/screenshots/home.png?raw=true "Home")

## Marcar Consulta
![Marcar Consulta](/screenshots/marcar-consulta.png?raw=true "Marcar Consulta")
