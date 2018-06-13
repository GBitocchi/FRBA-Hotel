CREATE PROCEDURE [dbo].[sp_CrearRegimen] (@codigo numeric(18,0),@descripcion nvarchar(255),@precio_base numeric(18,2),@estado bit)
AS
BEGIN
	
	insert into CAIA_UNLIMITED.Regimen (regi_codigo,regi_descripcion,regi_precio_base,regi_estado)
	values(@codigo,@descripcion,@precio_base,@estado)
					
END