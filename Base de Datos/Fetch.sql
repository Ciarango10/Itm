SELECT * FROM Album 
ORDER BY Titulo ASC
OFFSET 0 ROWS -- APARTIR DE LA FILA 1
FETCH NEXT 5 ROWS ONLY; -- MUESTRA LAS SIGUIENTES 5 FILAS
GO
SELECT * FROM Album 
ORDER BY Titulo DESC
OFFSET 3 ROWS -- APARTIR DE LA FILA 4
FETCH NEXT 4 ROWS ONLY; -- MUESTRA LAS SIGUIENTES 4 FILAS