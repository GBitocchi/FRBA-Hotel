CREATE PROCEDURE [dbo].[sp_ModificarRegimen] (@codigo numeric(18,0),@descripcion nvarchar(255),@precio_base numeric(18,2),@estado bit)
AS
BEGIN
	update CAIA_UNLIMITED.Regimen
	set regi_descripcion=@descripcion,regi_precio_base=@precio_base,regi_estado=@estado
	where regi_codigo=@codigo
END