CREATE DATABASE [Acme_Corporation]
GO
USE [Acme_Corporation]
GO
/****** Object:  StoredProcedure [dbo].[SP_CsvImporter]    Script Date: 5/08/2021 10:58:18 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author, Kmilo Londono>
-- Create date: <Create Date, 03/08/2021>
-- Description:	<Description, Load CSV information into database>
-- =============================================
CREATE PROCEDURE [dbo].[SP_CsvImporter] 
	@sourceroute NVARCHAR(MAX)
AS
BEGIN
	DECLARE @SQL NVARCHAR(MAX)

	TRUNCATE TABLE [dbo].[CsvImporter]

	SET @SQL = CONCAT( 'BULK INSERT [dbo].[CsvImporter]
		FROM ''', @sourceroute,
		''' WITH
		(
			FIELDTERMINATOR = '';'',
			ROWTERMINATOR = ''\n'',
			FIRSTROW = 2
		)')
		
		EXEC SP_EXECUTESQL @SQL
END
GO