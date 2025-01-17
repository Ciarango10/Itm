-- Transforma uno o mas valores de tipo de datos a otro.
-- CAST()
SELECT 'El codigo ' + CAST(IdCancion AS VARCHAR(5))
+ ' corresponde a la cancion ' + Titulo + ' y tiene una duracion de ' + CAST(Milisegundos as VARCHAR(7))
FROM Cancion;
-- CONVERT()
SELECT 'El Album con codigo ' + CONVERT(VARCHAR(5),IdAlbum) + ' y titulo ' + Titulo +
' fue lanzado al publico el ' + CONVERT(VARCHAR(10),Lanzamiento)
FROM Album;
-- PARSE()
SELECT PARSE('7345' AS money USING 'en-US') AS Moneda;