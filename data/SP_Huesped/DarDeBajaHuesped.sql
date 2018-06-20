CREATE PROCEDURE [dbo].[sp_DarDeBajaCliente] (@nombre nvarchar(255), @apellido nvarchar(255), @documento numeric(18,0), @tipo nvarchar(3), @mail nvarchar(255), @fecha_nacimiento datetime,@nacionalidad nvarchar(255),@calle nvarchar(255),@calle_nro numeric(18,0),@piso numeric(18,0),@dpto nvarchar(50),@ciudad nvarchar(255),@pais nvarchar(255), @telefono nvarchar(20))
AS
BEGIN	
	update CAIA_UNLIMITED.Huesped set hues_habilitado = 0 where hues_mail = @mail
		
END