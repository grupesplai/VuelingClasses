USE Covalco
GO 
--N convierte el texto en nvarchar
-- U user defined table
IF OBJECT_ID (N'Covalco.dbo.Alumno',N'U') IS NULL
BEGIN

	--CREA LA TABLA
CREATE TABLE dbo.Alumno
(
	Id INT IDENTITY NOT NULL PRIMARY KEY,
	Nombre [NVARCHAR] (50) NOT NULL,
	Apellidos [NVARCHAR] (50) NOT NULL,
	Dni [NVARCHAR](20) NOT NULL
);
END
-- cuando el sql quiere crear 