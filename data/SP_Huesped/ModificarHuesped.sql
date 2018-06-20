
CREATE PROCEDURE [dbo].[sp_ModificarCliente] (@nombre nvarchar(255), @apellido nvarchar(255), @documento numeric(18,0), @tipo nvarchar(3), @mail nvarchar(255), @fecha_nacimiento datetime,@nacionalidad nvarchar(255),@calle nvarchar(255),@calle_nro numeric(18,0),@piso numeric(18,0),@dpto nvarchar(50),@ciudad nvarchar(255),@pais nvarchar(255), @telefono nvarchar(20))
AS
BEGIN
	update CAIA_UNLIMITED.Direccion 
	set dire_dom_calle = @calle, dire_nro_calle = @calle_nro, dire_ciudad = @ciudad, dire_pais = @pais, dire_telefono = @telefono
	where dire_id = (select H.dire_id 
						from CAIA_UNLIMITED.Huesped H join CAIA_UNLIMITED.Direccion D on (H.dire_id = D.dire_id) 
						where hues_mail = @mail)

	update CAIA_UNLIMITED.Huesped
	set hues_mail = @mail,hues_nombre=@nombre,hues_apellido=@apellido,hues_documento=@documento,hues_nacionalidad=@nacionalidad,hues_nacimiento=@fecha_nacimiento,hues_documento_tipo=@tipo
	where hues_mail = @mail
END