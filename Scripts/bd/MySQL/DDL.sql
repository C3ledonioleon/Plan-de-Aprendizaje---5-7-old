
-- Eliminar la base de datos si existe
DROP DATABASE IF EXISTS SVE;

-- Crear la base de datos
CREATE DATABASE SVE;

-- Usar la base de datos
USE SVE;


CREATE TABLE Usuario (
    IdUsuario INT AUTO_INCREMENT PRIMARY KEY,
    Apodo VARCHAR(100) NOT NULL,
    Contrasenia VARCHAR(100) NOT NULL
);

-- Tabla Cliente
CREATE TABLE Cliente (
    IdCliente INT AUTO_INCREMENT PRIMARY KEY,
    DNI VARCHAR(20) NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20)
);

-- Tabla Local
CREATE TABLE Local (
    IdLocal INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Direccion VARCHAR(200) NOT NULL,
    CapacidadTotal INT NOT NULL
);

-- Tabla Sector
CREATE TABLE Sector (
    IdSector INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Capacidad INT NOT NULL,
    IdLocal INT NOT NULL,
    FOREIGN KEY (IdLocal) REFERENCES Local(IdLocal)
);

-- Tabla Evento
CREATE TABLE Evento (
    IdEvento INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion TEXT,
    FechaInicio DATETIME NOT NULL,
    FechaFin DATETIME NOT NULL,
    Estado ENUM('Inactivo', 'Publicado', 'Cancelado') NOT NULL
);

-- Tabla Funcion
CREATE TABLE Funcion (
    IdFuncion INT AUTO_INCREMENT PRIMARY KEY,
    IdEvento INT NOT NULL,
    IdLocal INT NOT NULL,
    FechaHora DATETIME NOT NULL,
    Estado ENUM('Pendiente','Cancelada','Finalizada') NOT NULL,
    FOREIGN KEY (IdEvento) REFERENCES Evento(IdEvento),
    FOREIGN KEY (IdLocal) REFERENCES Local(IdLocal)
);

-- Tabla Tarifa
CREATE TABLE Tarifa (
    IdTarifa INT AUTO_INCREMENT PRIMARY KEY,
    IdFuncion INT NOT NULL,
    IdSector INT NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL,
    Estado ENUM('Activa','Inactiva') NOT NULL,
    FOREIGN KEY (IdFuncion) REFERENCES Funcion(IdFuncion),
    FOREIGN KEY (IdSector) REFERENCES Sector(IdSector)
);

-- Tabla Orden
CREATE TABLE Orden (
    IdOrden INT AUTO_INCREMENT PRIMARY KEY,
    IdTarifa INT NOT NULL,
    IdCliente INT NOT NULL,
    Total DECIMAL(10,2) NOT NULL,
    Fecha DATETIME NOT NULL,
    Estado ENUM('Creada','Pagada','Cancelada') NOT NULL,
    FOREIGN KEY (IdTarifa) REFERENCES Tarifa(IdTarifa),
    FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
);

-- Tabla Entrada
CREATE TABLE Entrada (
    IdEntrada INT AUTO_INCREMENT PRIMARY KEY,
    Precio DECIMAL(10,2) NOT NULL,
    IdOrden INT NOT NULL,
    IdTarifa INT NOT NULL,
    Estado ENUM('Activa','Anulada') NOT NULL,
    FOREIGN KEY (IdOrden) REFERENCES Orden(IdOrden),
    FOREIGN KEY (IdTarifa) REFERENCES Tarifa(IdTarifa)
);
