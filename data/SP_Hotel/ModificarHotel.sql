USE [GD1C2018]
GO
/****** Object:  StoredProcedure [dbo].[sp_hotel]    Script Date: 07/06/2018 5:43:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ModificarHotel] (@idHotel numeric(18,0), @nombre_hotel nvarchar(255), @mail nvarchar(255), @estrellas numeric(18,0),
							@hote_telefono nvarchar(20), @calle nvarchar(255), @numero_calle numeric(18,0),
							@ciudad nvarchar(255), @pais nvarchar(255))
AS
BEGIN
	update CAIA_UNLIMITED.Direccion 
	set dire_dom_calle = @calle, dire_nro_calle = @numero_calle, dire_ciudad = @ciudad, dire_pais = @pais, dire_telefono = @hote_telefono
	where dire_id = (select H.dire_id 
						from CAIA_UNLIMITED.Hotel H join CAIA_UNLIMITED.Direccion D on (H.dire_id = D.dire_id) 
						where hote_id = @idHotel)

	update CAIA_UNLIMITED.Hotel
	set hote_nombre = @nombre_hotel, hote_mail = @mail, hote_cant_estrellas = @estrellas
	where hote_id = @idHotel
END