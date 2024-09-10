CREATE DATABASE Practica01
USE Practica01

CREATE TABLE Articulos(
id_art INT IDENTITY(1,1),
nombre VARCHAR(30),
precio DECIMAL(10,2),
CONSTRAINT pk_articulos PRIMARY KEY (id_art)
);
---- insert articulos
INSERT INTO Articulos (nombre, precio) VALUES ('Lapicera', 1500.00)
INSERT INTO Articulos (nombre, precio) VALUES ('Cartuchera', 6500.00)
INSERT INTO Articulos (nombre, precio) VALUES ('Mochila', 10500.00)

CREATE TABLE Formas_pago(
id_forma_pago INT IDENTITY(1,1),
nombre VARCHAR(20),
CONSTRAINT pk_formas_pago PRIMARY KEY (id_forma_pago)
);
--- insert formas pago
INSERT INTO Formas_pago (nombre) VALUES ('Efectivo');
INSERT INTO Formas_pago (nombre) VALUES ('Debito');
INSERT INTO Formas_pago (nombre) VALUES ('Crédito');


CREATE TABLE Facturas(
id_factura INT IDENTITY(1,1),
fecha DATETIME,
id_forma_pago INT,
cliente VARCHAR(30),
CONSTRAINT pk_facturas PRIMARY KEY (id_factura),
CONSTRAINT fk_facturas_formas_pago FOREIGN KEY (id_forma_pago)
		REFERENCES Formas_pago (id_forma_pago)
);
------ insert facturas
INSERT INTO Facturas (fecha, id_forma_pago, cliente) VALUES ('01/09/2024', 1, 'Sofia')
INSERT INTO Facturas (fecha, id_forma_pago, cliente) VALUES ('05/09/2024', 2, 'Anita')
INSERT INTO Facturas (fecha, id_forma_pago, cliente) VALUES ('10/09/2024', 3, 'Igna')

CREATE TABLE Detalles_facturas(
id_detalles INT IDENTITY(1,1),
id_factura INT,
id_art INT,
cantidad INT,
precio DECIMAL(10,2),
CONSTRAINT pk_detalles PRIMARY KEY (id_detalles),
CONSTRAINT fk_detalles_facturas FOREIGN KEY (id_factura)
		REFERENCES Facturas (id_factura),
CONSTRAINT fk_detalles_articulos FOREIGN KEY (id_art)
		REFERENCES Articulos (id_art)
);

--- insert detalles facturas
INSERT INTO Detalles_facturas (id_factura, id_art, cantidad, precio) VALUES (1, 1, 3, 200.00) 
INSERT INTO Detalles_facturas (id_factura, id_art, cantidad, precio) VALUES (1, 2, 5, 5000.00) 
INSERT INTO Detalles_facturas (id_factura, id_art, cantidad, precio) VALUES (2, 2, 3, 4000.00) 
INSERT INTO Detalles_facturas (id_factura, id_art, cantidad, precio) VALUES (2, 3, 3, 1200.00) 
INSERT INTO Detalles_facturas (id_factura, id_art, cantidad, precio) VALUES (3, 3, 1, 2200.00) 
INSERT INTO Detalles_facturas (id_factura, id_art, cantidad, precio) VALUES (3, 1, 4, 9200.00) 


-----------------------------	 PRCEDIMIENTOS ALMACENADOS -----------------------------------------
--- insertar articulo
CREATE PROCEDURE SP_AGREGAR_ARTICULO
    @nombre VARCHAR(30),
    @precio DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Articulos (nombre, precio) 
    VALUES (@nombre, @precio);
END;

--- consultar articulos 
CREATE PROCEDURE SP_CONSULTAR_ARTICULOS
AS 
BEGIN
SELECT * FROM Articulos
END;

--- insertar forma de pago
CREATE PROCEDURE SP_AGREGAR_FORMA_PAGO
    @nombre VARCHAR(20)
AS
BEGIN
    INSERT INTO Formas_pago(nombre) 
    VALUES (@nombre);
END;

--- consultar formas de pago
CREATE PROCEDURE SP_CONSULTAR_FORMAS_PAGO
AS 
BEGIN
SELECT * FROM Formas_pago
END;

--- insertar facturas
CREATE PROCEDURE SP_AGREGAR_FACTURAS
    @fecha DATETIME,
    @id_forma_pago INT,
	@cliente VARCHAR(30),
	@id_factura INT OUTPUT ---- SERA EL PARAMETRO DE SALIDA

AS
BEGIN
    INSERT INTO Facturas (fecha, id_forma_pago, cliente) 
    VALUES (@fecha, @id_forma_pago, @cliente);
SET @id_factura = SCOPE_IDENTITY();
END;

--- consultar facturas
CREATE PROCEDURE SP_CONSULTAR_FACTURAS
AS 
BEGIN
SELECT * FROM Facturas
END;

--- insertar detalle factura
CREATE PROCEDURE SP_AGREGAR_DETALLE
	@id_factura INT,
	@id_art INT,
	@cantidad INT,
	@precio DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Detalles_facturas(id_factura, id_art, cantidad, precio) 
    VALUES (@id_factura, @id_art, @cantidad, @precio);
END;

--- consultar detalles facturas
CREATE PROCEDURE SP_CONSULTAR_DETALLES
AS 
BEGIN
SELECT * FROM Detalles_facturas
END;
