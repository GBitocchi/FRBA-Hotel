USE [GD1C2018]
GO
/****** Object:  StoredProcedure [dbo].[sp_AlmacenarHotel]    Script Date: 10/06/2018 10:27:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ModificarHabitacion] (@numero_habitacion numeric(18,0), @piso numeric(18,0), @frente nvarchar(50),
													 @descripcion nvarchar(255), @viejo_numero numeric(18,0), @idHotel numeric(18,0))
AS
BEGIN
	update CAIA_UNLIMITED.Habitacion set habi_numero = @numero_habitacion, habi_piso = @piso, habi_frente = @frente, habi_descripcion = @descripcion
	where habi_numero = @viejo_numero and hote_id = @idHotel
					
END