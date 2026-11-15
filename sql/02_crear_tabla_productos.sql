-- Script 2: crea la tabla Productos
USE Programacion3;
GO

CREATE TABLE Productos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL CHECK (Stock >= 0)
);
GO
