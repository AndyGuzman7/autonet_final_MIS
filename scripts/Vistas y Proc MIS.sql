-- IdOrden, cantidadVenta, Cliente, empleado y fecha
-- idProductCat, nombre
-- IdCat, nombre producto, cant vendida y total vendido (Bs.)
CREATE VIEW vwReporteVentas
AS
SELECT O.idOrder AS 'N° Orden', O.total AS 'Total de la Venta', CONCAT(C.firstName, ' ', C.lastName) AS 'Cliente',
		E.nameUser AS 'Encargado de Venta', O.registerDate AS 'Fecha Venta'
FROM [Order] O
LEFT JOIN Client C ON C.idClient = O.idClient
LEFT JOIN Employee E ON E.idEmployee = O.idEmployee
WHERE O.status = 1

SELECT *
FROM vwReporteVentas
ORDER BY 5

CREATE VIEW vwCategorias
AS
SELECT P.idSpareCategory AS 'N° Categoria', P.spareCategory AS 'Nombre Categoria'
FROM ProductCategory P

DROP VIEW vwCategorias

SELECT * FROM vwCategorias

CREATE PROCEDURE uspReporteVentasPorCategoria (@id TINYINT)
AS 
BEGIN
SELECT P.spareCategory AS 'Categoria Producto', ISNULL(S.nameProduct, 'Sin productos') AS 'Producto', 
		ISNULL(SUM(OS.quantity), 0) AS 'Cantidad Total Vendida', 
		ISNULL(SUM(OS.total), 0) AS 'Total Vendido Bs.'
FROM ProductCategory P
LEFT JOIN Spare S ON S.idSpareCategory = P.idSpareCategory
LEFT JOIN OrderSpare OS ON S.idSpare = OS.idSpare
WHERE P.idSpareCategory = @id
GROUP BY P.spareCategory, S.nameProduct
END

DROP PROCEDURE uspReporteVentasPorCategoria

EXEC uspReporteVentasPorCategoria 2