-- Inserts Local
INSERT INTO Local (Nombre, Direccion, CapacidadTotal) VALUES
('Luna Park', 'Av. Corrientes 857, CABA', 8000),
('Teatro Colón', 'Cerrito 628, CABA', 2500),
('Movistar Arena', 'Humboldt 450, CABA', 15000),
('Estadio Único', 'Av. 32 y 25, La Plata', 40000),
('Orfeo Superdomo', 'Av. Cardeñosa 3450, Córdoba', 14000);

-- Inserts Sector
INSERT INTO Sector (Nombre, Capacidad, IdLocal) VALUES
('Platea Baja', 2000, 1),
('Platea Alta', 3000, 1),
('VIP', 500, 2),
('Campo', 10000, 3),
('Palco', 200, 2);

-- Inserts Evento
INSERT INTO Evento (Nombre, Genero, FechaInicio, FechaFin) VALUES
('Coldplay World Tour', 'Rock', '2025-11-10', '2025-11-15'),
('Romeo y Julieta', 'Teatro', '2025-09-01', '2025-09-20'),
('Lollapalooza', 'Festival', '2025-03-15', '2025-03-17'),
('Cirque du Soleil', 'Circo', '2025-08-05', '2025-08-10'),
('La Traviata', 'Ópera', '2025-07-01', '2025-07-05');

-- Inserts Funcion
INSERT INTO Funcion (Fecha, IdEvento, IdLocal) VALUES
('2025-11-10', 1, 1),
('2025-11-12', 1, 1),
('2025-09-05', 2, 2),
('2025-03-15', 3, 3),
('2025-08-07', 4, 4);

-- Inserts Tarifa
INSERT INTO Tarifa (MedioPago, Stock, IdSector, IdFuncion) VALUES
('Tarjeta Crédito', 2000, 1, 1),
('Efectivo', 1500, 2, 1),
('Tarjeta Débito', 500, 3, 3),
('Transferencia', 8000, 4, 4),
('Tarjeta Crédito', 150, 5, 3);

-- Inserts Cliente
INSERT INTO Cliente (Nombre, DNI, Email, Telefono) VALUES
('Juan Pérez', '30123456', 'juan.perez@gmail.com', '1134567890'),
('María López', '40234567', 'maria.lopez@hotmail.com', '1145678901'),
('Carlos Gómez', '25345678', 'carlos.gomez@yahoo.com', '1156789012'),
('Ana Torres', '33567890', 'ana.torres@gmail.com', '1167890123'),
('Pedro Fernández', '37234567', 'pedro.fernandez@gmail.com', '1178901234');

-- Inserts Orden
INSERT INTO Orden (FechaOrden, IdCliente) VALUES
('2025-09-20', 1),
('2025-09-21', 2),
('2025-09-21', 3),
('2025-09-22', 4),
('2025-09-22', 5);

-- Inserts Entrada
INSERT INTO Entrada (Precio, IdOrden, IdTarifa) VALUES
(25000.00, 1, 1),
(18000.00, 2, 2),
(15000.00, 3, 3),
(20000.00, 4, 4),
(30000.00, 5, 5);
