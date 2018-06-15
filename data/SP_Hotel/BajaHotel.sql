
USE [GD1C2018]
GO
/****** Object:  StoredProcedure [dbo].[sp_AlmacenarHotel]    Script Date: 07/06/2018 15:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_BajaHotel] (@id_hotel numeric(18,0), @fecha_inicio smalldatetime, @fecha_fin smalldatetime, @descripcion nvarchar(255))
AS
BEGIN	
	update CAIA_UNLIMITED.Hotel set hote_habilitado = 0 where hote_id = @id_hotel
	insert into CAIA_UNLIMITED.Mantenimiento (hote_id, mant_fecha_inicio, mant_fecha_fin, mant_descripcion)
	values (@id_hotel, @fecha_inicio, @fecha_fin, @descripcion)			
END