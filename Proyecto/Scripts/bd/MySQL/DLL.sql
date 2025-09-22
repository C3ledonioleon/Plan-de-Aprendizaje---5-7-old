	-- Creación de la base de datos
	CREATE DATABASE IF NOT EXISTS SVE;
	USE SVE;

	-- Tabla Local
	CREATE TABLE Local (
		IdLocal INT PRIMARY KEY AUTO_INCREMENT,
		Nombre VARCHAR(100) NOT NULL,
		Direccion VARCHAR(200) NOT NULL,
		CapacidadTotal INT NOT NULL
	);

	-- Tabla Sector
	CREATE TABLE Sector (
		IdSector INT PRIMARY KEY AUTO_INCREMENT,
		Nombre VARCHAR(100) NOT NULL,
		Capacidad INT NOT NULL,
		IdLocal INT,
		FOREIGN KEY (IdLocal) REFERENCES Local(IdLocal)
	);

	-- Tabla Evento
	CREATE TABLE Evento (
		IdEvento INT PRIMARY KEY AUTO_INCREMENT,
		Nombre VARCHAR(150) NOT NULL,
		Genero VARCHAR(50),
		FechaInicio DATE,
		FechaFin DATE
	);

	-- Tabla Funcion
	CREATE TABLE Funcion (
		IdFuncion INT PRIMARY KEY AUTO_INCREMENT,
		Fecha DATE NOT NULL,
		IdEvento INT,
		IdLocal INT,
		FOREIGN KEY (IdEvento) REFERENCES Evento(IdEvento),
		FOREIGN KEY (IdLocal) REFERENCES Local(IdLocal)
	);

	-- Tabla Tarifa (resuelve M:N entre Funcion y Sector)
	CREATE TABLE Tarifa (
		IdTarifa INT PRIMARY KEY AUTO_INCREMENT,
		MedioPago VARCHAR(50),
		Stock INT NOT NULL,
		IdSector INT,
		IdFuncion INT,
		FOREIGN KEY (IdSector) REFERENCES Sector(IdSector),
		FOREIGN KEY (IdFuncion) REFERENCES Funcion(IdFuncion)
	);

	-- Tabla Cliente
	CREATE TABLE Cliente (
		IdCliente INT PRIMARY KEY AUTO_INCREMENT,
		Nombre VARCHAR(100) NOT NULL,
		DNI VARCHAR(20) UNIQUE NOT NULL,
		Email VARCHAR(100) NOT NULL,
		Telefono VARCHAR(20)
	);

	-- Tabla Orden
	CREATE TABLE Orden (
		IdOrden INT PRIMARY KEY AUTO_INCREMENT,
		FechaOrden DATE NOT NULL,
		IdCliente INT,
		FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
	);

	-- Tabla Entrada (resuelve M:N entre Orden y Tarifa)
	CREATE TABLE Entrada (
		IdEntrada INT PRIMARY KEY AUTO_INCREMENT,
		Precio DECIMAL(10,2) NOT NULL,
		IdOrden INT,
		IdTarifa INT,
		FOREIGN KEY (IdOrden) REFERENCES Orden(IdOrden),
		FOREIGN KEY (IdTarifa) REFERENCES Tarifa(IdTarifa)
	);
