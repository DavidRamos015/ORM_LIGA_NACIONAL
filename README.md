 O R M

LIGA NACIONAL
==================

Ejemplo de un ORM usando 
Ninject,
FluentNHibernate,
AcklenAvenue.Data.NHibernate 
Ninject.Web.Common


Para esta  solución he creado 3 proyectos para configurar  SQLServer,  MySql (se pueden configurar mas) usando un ORM para hacer un mapeo relacional  el cual nos deja elegir libremente algunas las bases de datos soportadas(mySql,MSSQL,Oracle,SqlLite,DB2 UDB,FireBird,PostgreSQL,Access)
https://community.jboss.org/wiki/DatabasesSupportedByNHibernate?_sscc=t

•	LigaNacional.Data: Contiene cierta información y configuración de funciones generales para los demás proyectos, en este se puede configurar el tipo de conexión a usar.
Remota/Local para realizar ciertas pruebas (LigaNacional.Data.Helper.Utility.cs)

•	LigaNacional.Domain: Contiene la definición de las clases(tablas ) y sus propiedades(campos)  con cual trabaja el enfoque Code First  también se define la clase IRepository.cs  y Repository.cs (LigaNacional.Data) sobre este repositorio operan todas las consultas y manejo de datos que podemos hacer hacia la bdd a traves de expresiones lambda

•	LigaNacional.DatabaseDeployer:Se encarga de crear las tablas, campos, relaciones he inicializar datos que necesitemos (LigaNacional.DatabaseDeployer.Seeder.UsuarioSeeder.cs)

En un próximo ejemplo hare un ejemplo sobre como implementarlo en un Proyecto MVC4 o una WebApi 



Paquetes requeridos
Install-Package Ninject
Install-Package Ninject.Web.Common
Install-Package NHibernate 
Install-Package FluentNHibernate 
Install-Package AcklenAvenue.Data.NHibernate 
Install-Package MySql.Data 

Tutorial sobre como instalar paquetes con nutget

http://msdn.microsoft.com/es-es/magazine/hh547106.aspx
http://eduardosojo.com/2011/07/19/usuando-nuget-que-es-nuget/
