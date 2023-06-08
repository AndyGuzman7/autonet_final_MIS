INSERT INTO Factory(NombreFabrica, Pais, FechaCreacion, UsuarioCreacion)
VALUES
    ('Mann', 'Alemania', GETDATE(), 1),
    ('Bosch', 'Alemania', GETDATE(), 1),
    ('K&N', 'Estados Unidos', GETDATE(), 1),
    ('Fram', 'Estados Unidos', GETDATE(), 1),
    ('Purolator', 'Estados Unidos', GETDATE(), 1),
    ('Mobil', 'Estados Unidos', GETDATE(), 1),
    ('NGK', 'Japón', GETDATE(), 1),
    ('Denso', 'Japón', GETDATE(), 1),
    ('Delphi', 'Estados Unidos', GETDATE(), 1),
    ('Gates', 'Estados Unidos', GETDATE(), 1),
    ('Continental', 'Alemania', GETDATE(), 1),
    ('Dayco', 'Estados Unidos', GETDATE(), 1),
    ('Exide', 'Estados Unidos', GETDATE(), 1),
    ('Optima', 'Estados Unidos', GETDATE(), 1),
    ('Interstate', 'Estados Unidos', GETDATE(), 1),
    ('Philips', 'Países Bajos', GETDATE(), 1),
    ('Sylvania', 'Estados Unidos', GETDATE(), 1),
    ('Osram', 'Alemania', GETDATE(), 1),
    ('Monroe', 'Estados Unidos', GETDATE(), 1),
    ('KYB', 'Japón', GETDATE(), 1),
    ('Bilstein', 'Alemania', GETDATE(), 1),
    ('Moog', 'Estados Unidos', GETDATE(), 1),
    ('TRW', 'Estados Unidos', GETDATE(), 1),
    ('Wagner', 'Estados Unidos', GETDATE(), 1),
    ('Akebono', 'Japón', GETDATE(), 1),
    ('Brembo', 'Italia', GETDATE(), 1),
    ('Centric', 'Estados Unidos', GETDATE(), 1),
    ('Raybestos', 'Estados Unidos', GETDATE(), 1),
    ('Rain-X', 'Estados Unidos', GETDATE(), 1),
    ('Spectra Premium', 'Canadá', GETDATE(), 1),
    ('CSF', 'China', GETDATE(), 1),
    ('Airtex', 'Estados Unidos', GETDATE(), 1),
    ('GMB', 'Japón', GETDATE(), 1),
    ('Stant', 'Estados Unidos', GETDATE(), 1),
    ('Motorad', 'Estados Unidos', GETDATE(), 1),
    ('Walker', 'Estados Unidos', GETDATE(), 1),
    ('Exedy', 'Japón', GETDATE(), 1),
    ('Valeo', 'Francia', GETDATE(), 1),
    ('Luk', 'Alemania', GETDATE(), 1),
    ('Michelin', 'Francia', GETDATE(), 1),
    ('Bridgestone', 'Japón', GETDATE(), 1),
    ('Goodyear', 'Estados Unidos', GETDATE(), 1),
    ('Fel-Pro', 'Estados Unidos', GETDATE(), 1),
    ('Victor Reinz', 'Alemania', GETDATE(), 1);

INSERT INTO ProductCategory ([spareCategory], [status], [registerDate], [updateDate], [idEmploye])
VALUES
    ('Filtros', 1, GETDATE(), GETDATE(), 1),
    ('Frenos', 1, GETDATE(), GETDATE(), 1),
    ('Suspensión', 1, GETDATE(), GETDATE(), 2),
    ('Iluminación', 0, GETDATE(), GETDATE(), 3),
    ('Electrónica', 1, GETDATE(), GETDATE(), 2),
  
    ('Transmisión', 1, GETDATE(), GETDATE(), 1),
    ('Neumáticos', 0, GETDATE(), GETDATE(), 3),
    ('Motor', 1, GETDATE(), GETDATE(), 2),
    ('Aceites y Fluidos', 1, GETDATE(), GETDATE(), 1),
    ('Dirección', 0, GETDATE(), GETDATE(), 3),
   
    ('Categoría 50', 1, GETDATE(), GETDATE(), 2);




INSERT INTO Suppliers ([contactName], [address], [phone], [nit], [updateDate], [idEmploye], [status], [registerDate])
VALUES
    ('John Smith', '123 Main St, City', '1234567890', '123456789', GETDATE(), 1, 1, GETDATE()),
    ('Jane Doe', '456 Elm St, City', '2345678901', '987654321', GETDATE(), 2, 1, GETDATE()),
    ('Michael Johnson', '789 Oak St, City', '3456789012', '246813579', GETDATE(), 3, 0, GETDATE()),
    ('Emily Wilson', '321 Pine St, City', '4567890123', '135792468', GETDATE(), 1, 1, GETDATE()),
    ('David Lee', '654 Birch St, City', '5678901234', '864209753', GETDATE(), 2, 1, GETDATE()),
    ('Sarah Brown', '987 Cedar St, City', '6789012345', '753951864', GETDATE(), 3, 0, GETDATE()),
    ('Matthew Taylor', '159 Maple St, City', '7890123456', '642079358', GETDATE(), 1, 1, GETDATE()),
    ('Olivia Davis', '852 Walnut St, City', '8901234567', '925836471', GETDATE(), 2, 1, GETDATE()),
    ('Daniel Wilson', '369 Pine St, City', '9012345678', '468135792', GETDATE(), 3, 0, GETDATE()),
    ('Sophia Anderson', '753 Oak St, City', '0123456789', '357924680', GETDATE(), 1, 1, GETDATE());

UPDATE Suppliers SET phone= 7898673, nit = 323434

INSERT INTO Client ([firstName], [lastName], [nit], [status], [registerDate], [updateDate], [idEmployee])
VALUES
    ('John', 'Doe', '123456789', 1, GETDATE(), GETDATE(), 1),
    ('Jane', 'Smith', '987654321', 1, GETDATE(), GETDATE(), 2),
    ('Michael', 'Johnson', '246813579', 0, GETDATE(), GETDATE(), 3),
    ('Emily', 'Wilson', '135792468', 1, GETDATE(), GETDATE(), 1),
    ('David', 'Lee', '864209753', 1, GETDATE(), GETDATE(), 2),
    ('Sarah', 'Brown', '753951864', 0, GETDATE(), GETDATE(), 3),
    ('Matthew', 'Taylor', '642079358', 1, GETDATE(), GETDATE(), 1),
    ('Olivia', 'Davis', '925836471', 1, GETDATE(), GETDATE(), 2),
    ('Daniel', 'Wilson', '468135792', 0, GETDATE(), GETDATE(), 3),
    ('Sophia', 'Anderson', '357924680', 1, GETDATE(), GETDATE(), 1);

INSERT INTO Spare (idFactory, idSpareCategory, description, nameProduct, currentBalance, unitPrice, weight, [productCode], [status], [registerDate], [updateDate], [idEmploye])
VALUES
    (1, 1, 'Filtro de aire', 'Filtro de aire XYZ', 100, 12.99, 0.5, 'FA-001', 1, GETDATE(), GETDATE(), 1),
    (2, 2, 'Bujía de encendido', 'Bujía de encendido ABC', 50, 6.99, 0.2, 'BE-002', 1, GETDATE(), GETDATE(), 1),
    (3, 3, 'Correa de distribución', 'Correa de distribución F', 30, 19.99, 0.8, 'CD-003', 1, GETDATE(), GETDATE(), 1),
    (4, 4, 'Filtro de aceite', 'Filtro de aceite GHI', 80, 8.99, 0.4, 'FO-004', 1, GETDATE(), GETDATE(), 1),
    (5, 5, 'Pastillas de freno', 'Pastillas de freno JKL', 60, 24.99, 1.2, 'PF-005', 1, GETDATE(), GETDATE(), 1),
    (6, 6, 'Bobina de encendido', 'Bobina de encendido MNO', 40, 14.99, 0.6, 'BE-006', 1, GETDATE(), GETDATE(), 1),
    (7, 7, 'Radiador', 'Radiador PQR', 20, 49.99, 4.5, 'RA-007', 1, GETDATE(), GETDATE(), 1),
    (8, 8, 'Sensor de oxígeno', 'Sensor de oxígeno STU', 35, 39.99, 0.3, 'SO-008', 1, GETDATE(), GETDATE(), 1),
    (9, 9, 'Termostato', 'Termostato VWX', 25, 9.99, 0.1, 'TE-009', 1, GETDATE(), GETDATE(), 1),
    (10, 10, 'Sensor de velocidad', 'Sensor de velocidad YZA', 15, 29.99, 0.2, 'SV-010', 1, GETDATE(), GETDATE(), 1);

INSERT INTO [BDDAUTONET2023].[dbo].[Spare] ([idFactory], [idSpareCategory], [description], [nameProduct], [currentBalance], [unitPrice], [weight], [productCode], [status], [registerDate], [updateDate], [idEmploye])
VALUES
    (11, 11, 'Amortiguador trasero', 'Amortiguador trasero XYZ', 10, 79.99, 3.5, 'AT-011', 1, GETDATE(), GETDATE(), 1),
    (12, 12, 'Lámpara delantera', 'Lámpara delantera ABC', 40, 12.99, 0.2, 'LD-012', 1, GETDATE(), GETDATE(), 1),
    (13, 1, 'Filtro de combustible', 'Filtro de combustible DEF', 30, 18.99, 0.3, 'FC-013', 1, GETDATE(), GETDATE(), 1),
    (14, 2, 'Batería de auto', 'Batería de auto GHI', 20, 99.99, 10.0, 'BA-014', 1, GETDATE(), GETDATE(), 1),
    (15, 3, 'Aceite de motor', 'Aceite de motor JKL', 100, 9.99, 1.0, 'AM-015', 1, GETDATE(), GETDATE(), 1),
    (16, 4, 'Correa de alternador', 'Correa de alternador MNO', 35, 14.99, 0.5, 'CA-016', 1, GETDATE(), GETDATE(), 1),
    (17, 5, 'Sensor de temperatura', 'Sensor de temperatura PQR', 25, 24.99, 0.2, 'ST-017', 1, GETDATE(), GETDATE(), 1),
    (18, 6, 'Juego de bujías', 'Juego de bujías STU', 50, 39.99, 0.8, 'JB-018', 1, GETDATE(), GETDATE(), 1),
    (19, 7, 'Filtro de habitáculo', 'Filtro de habitáculo VWX', 15, 19.99, 0.4, 'FH-019', 1, GETDATE(), GETDATE(), 1),
    (20, 8, 'Alternador', 'Alternador YZA', 10, 149.99, 5.0, 'AL-020', 1, GETDATE(), GETDATE(), 1);
