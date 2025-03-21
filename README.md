CRUD: .NET CORE 8 MVC 
Projeto para realização do desafio proposto pela empresa FSBR.

Ferramentas Utilizadas : Visual Studio 2022
			       : SQL Server Management Studio 20
Tecnologias Utilizadas :  C#; .Net 8.0; EntityFramework Core; SQL Server;
Versões do Entity usados no projeto:
Microsoft.EntityFrameworkCore.SqlServer Version="8.0.14"
Microsoft.EntityFrameworkCore.Tools        Version="8.0.14"
Microsoft.EntityFrameworkCore.Design      Version="8.0.14"
Microsoft.EntityFrameworkCore                 Version="8.0.14"
Link do Projeto: https://github.com/Luizgcsneto/projeto-loja-produtos.
Após baixar o projeto e abrir no Visual Studio realizar esses passos.
No projeto WebLojaProdutos localizando o arquivo de appsettings.json mudar ConnectionStrings " DefaultConnection" colocar o servidor e o nome do banco que desejar, no meu teste deixei o nome "crud_mvc_loja" após os ajustes ir na opção de Tools ->  Nuget Package Manager -> Package Manager Console na opção de Default project apontar para o projeto Infrastructure e rodar os seguintes comandos.
"Add-Migration NomeDaMigration -Context ContextBase" 
"Update-Database -Context ContextBase" 

