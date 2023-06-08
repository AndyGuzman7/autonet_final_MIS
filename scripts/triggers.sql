USE BDDAUTONET2023;


GO
CREATE TRIGGER UpdateQuantityToSalesSpare
ON OrderSpare
AFTER INSERT
AS
BEGIN
	DECLARE @idSpare tinyint;
	DECLARE @quantityNew tinyint;
	SELECT @idSpare = idSpare, @quantityNew = quantity
	FROM inserted;

	DECLARE @quantityOld tinyint;
	SELECT @quantityOld = currentBalance
	FROM Spare
	WHERE idSpare = @idSpare;

	DECLARE @quantity tinyint;
	SET @quantity = @quantityOld - @quantityNew

	UPDATE Spare SET currentBalance = @quantity WHERE idSpare = @idSpare;

END;

GO
CREATE TRIGGER UpdateQuantityToInsertSpare
ON SuppliersSpare
AFTER INSERT
AS
BEGIN
	DECLARE @idSpare tinyint;
	DECLARE @quantityNew tinyint;
	SELECT @idSpare = idSpare, @quantityNew = quantity
	FROM inserted;

	DECLARE @quantityOld tinyint;
	SELECT @quantityOld = currentBalance
	FROM Spare
	WHERE idSpare = @idSpare;

	DECLARE @quantity tinyint;
	SET @quantity = @quantityNew + @quantityOld;

	UPDATE Spare SET currentBalance = @quantity WHERE idSpare = @idSpare;

END;



SELECT name AS 'Nombre del Trigger', OBJECT_NAME(parent_id) AS 'Tabla', create_date AS 'Fecha de Creación'
FROM sys.triggers;


SELECT OBJECT_DEFINITION(OBJECT_ID('NombreDelTrigger')) AS 'Definición del Trigger';



SELECT
    Object_name(so .parent_object_id) Parent_Name,
    so .name ObjectName,
    so .type_desc [Type Description],
    so .create_date [Create Date],
    sm.definition [Text]
FROM   sys .objects so
INNER JOIN sys. sql_modules sm
ON so.object_id = sm.object_id
WHERE  so .type = 'TR' 