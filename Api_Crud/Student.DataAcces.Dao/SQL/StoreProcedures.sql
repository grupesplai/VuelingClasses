--GetAll
USE VuelingApiD
GO

CREATE PROCEDURE dbo.getall
AS
SELECT * 
FROM dbo.Alumnos
GO

--GetOne
USE VuelingApiD
GO

CREATE PROCEDURE dbo.getone @Id int
AS
SELECT * 
FROM dbo.Alumnos
 WHERE Id = @Id
GO