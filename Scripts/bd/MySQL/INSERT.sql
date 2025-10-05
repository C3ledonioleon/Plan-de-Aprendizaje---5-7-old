
-- Inserts para Usuario
INSERT INTO Usuario (Apodo, Contrasenia) VALUES
('juan123', 'pass1'),
('maria88', 'pass2'),
('carlos22', 'pass3'),
('sofia07', 'pass4'),
('luisito', 'pass5'),
('pele', 'adminpass');

-- Inserts para Cliente
INSERT INTO Cliente (DNI, Nombre, Telefono) VALUES
('12345678', 'Juan Pérez', '111-1111'),
('23456789', 'María López', '222-2222'),
('34567890', 'Carlos García', '333-3333'),
('45678901', 'Sofía Fernández', '444-4444'),
('56789012', 'Luis Gómez', '555-5555'),
('67890123', 'Ana Torres', '666-6666');

-- Inserts para Local
INSERT INTO Local (Nombre, Direccion, CapacidadTotal) VALUES
('Teatro Colón', 'Cerrito 628', 2500),
('Luna Park', 'Av. Madero 420', 8000),
('Gran Rex', 'Av. Corrientes 857', 3200),
('Movistar Arena', 'Humboldt 450', 15000),
('Teatro Opera', 'Av. Corrientes 860', 2000),
('Estadio River Plate', 'Av. Figueroa Alcorta 7597', 70000);

-- Inserts para Sector
INSERT INTO Sector (Nombre, Capacidad, IdLocal) VALUES
('VIP', 500, 1),
('Platea Baja', 1000, 2),
('Campo', 3000, 3),
('Platea Alta', 2000, 4),
('General', 10000, 5),
('Palco', 200, 6);

-- Inserts para Evento
INSERT INTO Evento (Nombre, Descripcion, FechaInicio, FechaFin, Estado) VALUES
('Concierto Rock', 'Banda nacional de rock en vivo', '2025-10-01 20:00:00', '2025-10-01 23:00:00', 'Publicado'),
('Opera Clásica', 'Obra de Verdi en 3 actos', '2025-10-05 19:00:00', '2025-10-05 22:00:00', 'Publicado'),
('Festival Pop', 'Festival con varios artistas pop', '2025-10-10 18:00:00', '2025-10-10 23:59:00', 'Publicado'),
('Obra de Teatro', 'Comedia romántica', '2025-10-15 21:00:00', '2025-10-15 23:30:00', 'Publicado'),
('Concierto Internacional', 'Artista internacional en vivo', '2025-10-20 20:00:00', '2025-10-20 23:30:00', 'Publicado'),
('Festival de Jazz', 'Encuentro de jazz nacional e internacional', '2025-10-25 19:00:00', '2025-10-25 23:59:00', 'Publicado');

-- Inserts para Funcion
INSERT INTO Funcion (IdEvento, IdLocal, FechaHora, Estado) VALUES
(1, 1, '2025-10-01 20:00:00', 'Pendiente'),
(2, 1, '2025-10-05 19:00:00', 'Pendiente'),
(3, 2, '2025-10-10 18:00:00', 'Pendiente'),
(4, 3, '2025-10-15 21:00:00', 'Pendiente'),
(5, 4, '2025-10-20 20:00:00', 'Pendiente'),
(6, 5, '2025-10-25 19:00:00', 'Pendiente');

-- Inserts para Tarifa
INSERT INTO Tarifa (IdFuncion, IdSector, Precio, Stock, Estado) VALUES
(1, 1, 5000.00, 200, 'Activa'),
(2, 2, 3500.00, 300, 'Activa'),
(3, 3, 2500.00, 500, 'Activa'),
(4, 4, 4000.00, 250, 'Activa'),
(5, 5, 10000.00, 100, 'Activa'),
(6, 6, 1500.00, 50, 'Activa');

-- Inserts para Orden
INSERT INTO Orden (IdTarifa, IdCliente, Total, Fecha, Estado) VALUES
(1, 1, 10000.00, '2025-09-20 12:00:00', 'Creada'),
(2, 2, 7000.00, '2025-09-21 14:00:00', 'Pagada'),
(3, 3, 5000.00, '2025-09-22 16:00:00', 'Creada'),
(4, 4, 4000.00, '2025-09-23 18:00:00', 'Cancelada'),
(5, 5, 20000.00, '2025-09-24 20:00:00', 'Pagada'),
(6, 6, 1500.00, '2025-09-25 22:00:00', 'Creada');

-- Inserts para Entrada
INSERT INTO Entrada (Precio, IdOrden, IdTarifa, Estado) VALUES
(5000.00, 1, 1, 'Activa'),
(3500.00, 2, 2, 'Activa'),
(2500.00, 3, 3, 'Activa'),
(4000.00, 4, 4, 'Anulada'),
(10000.00, 5, 5, 'Activa'),
(1500.00, 6, 6, 'Activa');



