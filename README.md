# CsvImporter
## Trabajando con Block en Azure
En este proyecto se pretende trabajar con Shared Access Signatures (SAS) y tiene como objetivo generar la descarga de un archivo compartido en un blob de Azure con el fin de guardar la información en una base de datos local, teniedo como primisa los recuersos consumidos (CPU, RAM, ETC) a la hora de realizar el proceso.

Las herramietnas utilizadas para llegar a la finalizacion del trabajo son:
* Visual Studio 2019.
* SQLServer 2018.

Para el desarrollo del proyecto se utilizaron las implementaciones del estandar .NET como lo es .NET Core, para el desarrollo de su lógica se trabajo con Entity Framework. A nivel de base de datos se realiza la creacion de la base de datos y del Store Procedure el cual va ser el encargado de realizar la carga por medio de un BULK.

### Pre-requisitos
* Visual Studio 2019 (Recomendado)
* SQL Server Management Studio 2019 (Recomendado)

### Instalación

1. Descargar el archivo "CredateDB_Acme_Corporation.sql" y en SQL Server Management Studio 2019 (recomendado) realizar la ejecucion del script.
2. Descargar la solución CsvImporter y abrirlo en el Framework Visual Studio 2019 (Recomendado).
3. Una vez abierto la solución, a travez del adimistrador del paquetes NuGet:
 --> Instalar en el proyecto CsvImporter  Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkSqlServer, Microsoft.EntityFramework.Desing y Azure.Storage.Blobs
 --> Instalar en el proyecto CsvImporterModel  Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkSqlServer, Microsoft.EntityFramework.Desing
 
Cuando finalice la instalación de los paquetes requeridos, dirijase a la Consola del Administrardor de paquetes, elija el CsvImporterModel y ejecute las siguientes lineas de comando:
--> update-database -context AcmeCorporationDbContext
Verifique que se ejecuto correctamente dirigiendose a la base de datos "Acme_Corporation" y observe que se creo la tabla "CsvImporter".

En el proyecto "CsvImporter" y "TestCsvImporter" abra el file appSettings.Json y edite el parametro "TargetRoute" dando la ubicacion donde quiere que se descargue en su maquina el archivo para ser procesado

Cuando esta tabla ya se encuentre creada, el proyecto esta listo para ejecutarse.

### Ejecutando las pruebas

Para ejecutar las pruebas del proyecto o de alguno de alguna de las dos funcionalidades especificas, dirijase al proyecto "TestCsvImporter" y elija cual de las tres pruebas va a realizar:
--> Main(): Ejecuta el el proyecto completo
