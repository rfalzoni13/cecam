# cecam
Este é o projeto de testes Cecam, e aqui vão as instruções!

O projeto possui uma estrutura baseada em DDD, com a camada Web feita em ASP.NET Web Forms em .NET Framework 4.7.2..

O projeto esta configurado com Entity Framework Code First com Migrations, para habilitar para o banco, deve-se seguir as instruções.

1) Após fazer o clone do projeto no local de sua preferência, crie um banco de dados local com o nome de Cecam e abra-o com o Visual Studio e no Web.Config, cole
a Connection String (pode-se utilizar o Server Manager para auxiliar).
2) Após esta etapa, com o NuGEt Package Manager Console, vá até o projeto Cecam.Infra.Data e rode os comandos (sem aspas) "Enable-Migrations", "Add-Migration_Create_Database" e por fim "Update-Database". Isto irá gerar a tabela exemplo "Company" no banco de dados.
3) Por fim, aponte o projeto Cecam.Web como projeto principal e dê um Clean e Rebuild na Solution para que os pacotes NuGet sejam restaurados e também seja verificado se a Solution está compilando normalmente.
4) Por fim, com tudo certo, rode o projeto!

Enjoy!
