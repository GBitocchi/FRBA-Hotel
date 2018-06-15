CREATE PROCEDURE [dbo].[sp_CrearCliente] (@nombre nvarchar(255), @apellido nvarchar(255), @documento numeric(18,0), @tipo nvarchar(3), @mail nvarchar(255), @fecha_nacimiento datetime,@nacionalidad nvarchar(255),@calle nvarchar(255),@calle_nro numeric(18,0),@piso numeric(18,0),@dpto nvarchar(50),@ciudad nvarchar(255),@pais nvarchar(255), @telefono nvarchar(20))
AS
BEGIN
	insert into CAIA_UNLIMITED.Direccion (dire_ciudad, dire_pais, dire_dom_calle, dire_nro_calle,
											dire_telefono)
	values (@ciudad, @pais, @calle, @calle_nro, @telefono)
	insert into CAIA_UNLIMITED.Huesped (hues_mail,hues_nombre,hues_apellido,hues_documento,hues_nacionalidad,hues_nacimiento,hues_documento_tipo,hues_habilitado,dire_id)
	values(@mail, @nombre,@apellido,@documento,@nacionalidad,@fecha_nacimiento, @tipo,1,(select dire_id from CAIA_UNLIMITED.Direccion
												where dire_telefono = @hote_telefono and
												dire_dom_calle = @calle and dire_ciudad = @ciudad
												and dire_pais = @pais and dire_nro_calle = @numero_calle))
					
END