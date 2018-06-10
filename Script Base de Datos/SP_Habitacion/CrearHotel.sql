USE [GD1C2018]
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarHabitacion]    Script Date: 10/06/2018 10:39:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CrearHabitacion] (@numero_habitacion numeric(18,0), @piso numeric(18,0), @frente nvarchar(50),
													 @descripcion nvarchar(255), @tipo numeric(18,0), @idHotel numeric(18,0))
AS
BEGIN
	insert into CAIA_UNLIMITED.Habitacion (habi_numero, habi_piso, habi_frente, habi_habilitado, habi_descripcion, 
											thab_codigo, hote_id)
	values(@numero_habitacion, @piso, @frente, 1, @descripcion, @tipo, @idHotel)
					
END