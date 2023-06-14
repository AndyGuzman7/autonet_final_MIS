USE BDDAUTONET2023;
ALTER PROCEDURE uspHistoryAndStocks(@idSpare TINYINT)
AS 
BEGIN

SELECT O.registerDate AS Fecha,  (SELECT S.nameProduct FROM Spare S WHERE S.idSpare =@idSpare ) AS NombreSpare ,SUM(O.total) AS 'Cantidad Vendida', (SELECT S.unitPrice FROM Spare S WHERE S.idSpare = @idSpare) AS 'Precio Unitario'
FROM OrderSpare O
WHERE O.idSpare = @idSpare
GROUP BY O.registerDate

END


uspHistoryAndStocks 1, '10-02-2023', '10-02-2023'

