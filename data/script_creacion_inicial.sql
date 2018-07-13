USE [GD1C2018]
GO

SET QUOTED_IDENTIFIER OFF
SET ANSI_NULLS ON 

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'CAIA_UNLIMITED')
BEGIN
EXEC ('CREATE SCHEMA [CAIA_UNLIMITED] AUTHORIZATION [gd]')
END

create table CAIA_UNLIMITED.Mantenimiento(
	mant_fecha_inicio datetime not null,
	mant_fecha_fin datetime not null,
	mant_descripcion nvarchar(255) not null,
	hote_id numeric(18,0) not null
)
go

create table CAIA_UNLIMITED.Hotel(
	hote_id numeric(18,0) identity(0,1) not null,
	hote_nombre nvarchar(255),
	hote_cant_estrellas numeric(18,0) not null,
	hote_recarga_estrella numeric(18,0),
	hote_fecha_creacion datetime,
	hote_mail nvarchar(255),
	dire_id numeric(18,0) not null
)
go

create table CAIA_UNLIMITED.Regimen(
	regi_codigo numeric(18,0) identity(0,1) not null,
	regi_descripcion nvarchar(255) not null,
	regi_precio_base numeric(18,2) not null,
	regi_estado bit not null
)
go

create table CAIA_UNLIMITED.Usuario(
	usur_id numeric(18,0) identity(0,1) not null,
	usur_username nvarchar(255) not null,
	usur_password varbinary(100) not null,
	usur_nombre nvarchar(255),
	usur_apellido nvarchar(255),
	usur_documento_tipo nvarchar(3),
	usur_documento numeric(18,0),
	usur_mail nvarchar(255),
	usur_nacimiento datetime,
	usur_habilitado bit not null,
	usur_intentos numeric(18,0) not null,
	dire_id numeric(18,0)
)
go

create table CAIA_UNLIMITED.Direccion(
	dire_id numeric(18,0) identity(0,1) not null,
	dire_telefono nvarchar(20),
	dire_dom_calle nvarchar(255) not null,
	dire_nro_calle numeric(18,0) not null,
	dire_piso numeric(18,0),
	dire_dpto nvarchar(50),
	dire_ciudad nvarchar(255),
	dire_pais nvarchar(255)
)
go

create table CAIA_UNLIMITED.Huesped(
	hues_mail nvarchar(255) not null,
	hues_nombre nvarchar(255) not null,
	hues_apellido nvarchar(255) not null,
	hues_documento numeric(18,0) not null,
	hues_nacionalidad nvarchar(255) not null,
	hues_nacimiento datetime,
	hues_documento_tipo nvarchar(3) not null,
	hues_habilitado bit not null,
	dire_id numeric(18,0) not null
)
go

create table CAIA_UNLIMITED.Reserva(
	rese_codigo numeric(18,0) not null,
	rese_fecha_realizacion datetime not null,
	rese_fecha_desde datetime not null,
	rese_cantidad_noches numeric(18,0) not null,
	rese_usur_creacion numeric(18,0),
	rese_usur_modificacion numeric(18,0),
	esre_codigo numeric(18,0),
	regi_codigo numeric(18,0) not null
)
go

create table CAIA_UNLIMITED.Estado_Reserva(
	esre_codigo numeric(18,0) identity(0,1) not null,
	esre_detalle nvarchar(255) not null
)
go

create table CAIA_UNLIMITED.Reserva_Cancelada(
	reca_rese numeric(18,0) not null,
	reca_motivo nvarchar(255) not null,
	reca_fecha_cancelacion datetime not null,
	reca_usuario numeric(18,0) 
)
go

create table CAIA_UNLIMITED.Pago(
	pago_codigo numeric(18,0) identity(0,1) not null,
	pago_monto numeric(18,2) not null,
	pago_nombre nvarchar(255),
	pago_apellido nvarchar(255),
	pago_nro_tarjeta nvarchar(20),
	pago_codigo_seguridad nvarchar(4),
	pago_banco nvarchar(20),
	pago_fecha_vencimiento datetime
)
go

create table CAIA_UNLIMITED.Rol(
	rol_codigo numeric(18,0) identity(0,1) not null,
	rol_nombre nvarchar(255) not null,
	rol_estado bit not null
)
go

create table CAIA_UNLIMITED.Funcionalidad(
	func_codigo numeric(18,0) identity(0,1) not null,
	func_detalle nvarchar(255) not null
)
go

create table CAIA_UNLIMITED.Habitacion(
	hote_id numeric(18,0) not null,
	habi_numero numeric(18,0) not null,
	habi_piso numeric(18,0) not null,
	habi_frente nvarchar(50) not null,
	habi_descripcion nvarchar(255),
	habi_habilitado bit not null,
	thab_codigo numeric(18,0) not null
)
go

create table CAIA_UNLIMITED.Tipo_Habitacion(
	thab_codigo numeric(18,0) not null,
	thab_descripcion nvarchar(255) not null,
	thab_porcentual numeric(18,2) not null
)
go

create table CAIA_UNLIMITED.Estadia(
	esta_codigo numeric(18,0) identity(0,1) not null,
	esta_fecha_inicio datetime not null,
	esta_fecha_fin datetime null,
	rese_codigo numeric(18,0) not null,
	usur_checkin numeric(18,0),
	usur_checkout numeric(18,0)
)
go

create table CAIA_UNLIMITED.Factura(
	fact_nro numeric(18,0) not null,
	fact_fecha datetime not null,
	fact_total numeric(18,2) not null,
	esta_codigo numeric(18,0) not null,
	pago_codigo numeric(18,0) null,
	hues_mail nvarchar(255) null,
	hues_documento numeric(18,0) not null
)
go

create table CAIA_UNLIMITED.Item_Factura(
	item_cantidad numeric(18,0) not null,
	item_monto numeric(18,2) not null,
	fact_nro numeric(18,0) not null,
	cons_codigo numeric(18,0)
)
go

create table CAIA_UNLIMITED.Consumible(
	cons_codigo numeric(18,0) not null,
	cons_descripcion nvarchar(255) not null,
	cons_precio numeric(18,2) not null
)
go

create table CAIA_UNLIMITED.Rol_X_Usuario(
	rol_usur_codigo numeric(18,0) not null,
	rol_usur_id numeric(18,0) not null
)
go

create table CAIA_UNLIMITED.Funcionalidad_X_Rol(
	func_rol_codigo_rol numeric(18,0) not null,
	func_rol_codigo_func numeric(18,0) not null
)
go

create table CAIA_UNLIMITED.Regimen_X_Hotel(
	regi_hote_codigo numeric(18,0) not null,
	regi_hote_id numeric(18,0) not null
)
go

create table CAIA_UNLIMITED.Usuario_X_Hotel(
	usur_hote_idusur numeric(18,0) not null,
	usur_hote_idhote numeric(18,0) not null
)
go

create table CAIA_UNLIMITED.Reserva_X_Huesped(
	rese_hues_codigo numeric(18,0) not null,
	rese_hues_mail nvarchar(255) not null,
	rese_hues_documento numeric(18,0) not null
)
go

create table CAIA_UNLIMITED.Consumible_X_Estadia(
	cons_esta_codigo_cons numeric(18,0) not null,
	cons_esta_codigo_esta numeric(18,0) not null,
	cons_esta_cantidad numeric(18,0)
)
go

create table CAIA_UNLIMITED.Habitacion_X_Reserva(
	habi_rese_numero numeric(18,0) not null,
	habi_rese_id numeric(18,0) not null,
	habi_rese_codigo numeric(18,0) not null
)
go

alter table CAIA_UNLIMITED.Direccion
	add constraint PK_Direccion primary key (dire_id)
go

alter table CAIA_UNLIMITED.Hotel
	add constraint PK_Hotel primary key (hote_id),
	constraint FK_Hotel_Direccion foreign key (dire_id)
	references CAIA_UNLIMITED.Direccion (dire_id)
go

alter table CAIA_UNLIMITED.Regimen 
	add constraint PK_Regimen primary key (regi_codigo)
go

alter table CAIA_UNLIMITED.Tipo_Habitacion
	add constraint PK_Tipo_Habitacion primary key (thab_codigo)
go

alter table CAIA_UNLIMITED.Habitacion
	add constraint PK_Habitacion primary key (hote_id, habi_numero),
	constraint FK_Habitacion_Hotel foreign key (hote_id)
	references CAIA_UNLIMITED.Hotel (hote_id),
	constraint FK_Habitacioin_Tipo foreign key (thab_codigo)
	references CAIA_UNLIMITED.Tipo_Habitacion (thab_codigo)
go

alter table CAIA_UNLIMITED.Rol
	add constraint PK_Rol primary key (rol_codigo)
go

alter table CAIA_UNLIMITED.Funcionalidad
	add constraint PK_Funcionalidad primary key (func_codigo)
go

alter table CAIA_UNLIMITED.Usuario 
	add constraint PK_Usuario primary key (usur_id),
	constraint FK_Usuario_Direccion foreign key (dire_id)
	references CAIA_UNLIMITED.Direccion (dire_id)
go

alter table CAIA_UNLIMITED.Huesped
	add constraint PK_Huesped primary key (hues_mail, hues_documento),
	constraint FK_Huespedo_Direccion foreign key (dire_id)
	references CAIA_UNLIMITED.Direccion (dire_id)
go

alter table CAIA_UNLIMITED.Estado_Reserva
	add constraint PK_Estado_Reserva primary key (esre_codigo)
go

alter table CAIA_UNLIMITED.Reserva
	add constraint PK_Reserva primary key (rese_codigo),
	constraint FK_Reserva_Estado foreign key (esre_codigo)
	references CAIA_UNLIMITED.Estado_Reserva (esre_codigo),
	constraint FK_Reserva_Usuario_Creacion foreign key (rese_usur_creacion)
	references CAIA_UNLIMITED.Usuario (usur_id),
	constraint FK_Reserva_Regimen foreign key (regi_codigo)
	references CAIA_UNLIMITED.Regimen (regi_codigo),
	constraint FK_Reserva_Usuario_Modificacion foreign key (rese_usur_modificacion)
	references CAIA_UNLIMITED.Usuario (usur_id)
go

alter table CAIA_UNLIMITED.Estadia
	add constraint PK_Estadia primary key (esta_codigo),
	constraint FK_Estadia_Reserva foreign key (rese_codigo)
	references CAIA_UNLIMITED.Reserva (rese_codigo),
	constraint FK_Estadia_Usuario_CheckIn foreign key (usur_checkin)
	references CAIA_UNLIMITED.Usuario (usur_id),
	constraint FK_Estadia_Usuario_CheckOut foreign key (usur_checkout)
	references CAIA_UNLIMITED.Usuario (usur_id)
go

alter table CAIA_UNLIMITED.Consumible
	add constraint PK_Consumible primary key (cons_codigo)
go

alter table CAIA_UNLIMITED.Pago
	add constraint PK_Pago primary key (pago_codigo)
go

alter table CAIA_UNLIMITED.Factura
	add constraint PK_Factura primary key (fact_nro),
	constraint FK_Factura_Estadia foreign key (esta_codigo)
	references CAIA_UNLIMITED.Estadia (esta_codigo),
	constraint FK_Factura_Pago foreign key (pago_codigo)
	references CAIA_UNLIMITED.Pago (pago_codigo),
	constraint FK_Factura_Huesped foreign key (hues_mail, hues_documento)
	references CAIA_UNLIMITED.Huesped (hues_mail, hues_documento)
	on update cascade
go

alter table CAIA_UNLIMITED.Item_Factura
	add constraint FK_Item_Factura_Factura foreign key (fact_nro)
	references CAIA_UNLIMITED.Factura (fact_nro),
	constraint FK_Item_Factuta_Consumible foreign key (cons_codigo)
	references CAIA_UNLIMITED.Consumible (cons_codigo)
go

alter table CAIA_UNLIMITED.Mantenimiento
	add constraint FK_Mantenimiento_Hotel foreign key (hote_id)
	references CAIA_UNLIMITED.Hotel (hote_id)
go

alter table CAIA_UNLIMITED.Rol_X_Usuario
	add constraint PK_Rol_X_Usuario primary key (rol_usur_codigo, rol_usur_id),
	constraint FK_RolUsuario_Rol foreign key (rol_usur_codigo)
	references CAIA_UNLIMITED.Rol (rol_codigo),
	constraint FK_RolUsuario_Usur foreign key (rol_usur_id)
	references CAIA_UNLIMITED.Usuario (usur_id)
go

alter table CAIA_UNLIMITED.Funcionalidad_X_Rol
	add constraint PK_Funcionalidad_X_Rol primary key (func_rol_codigo_rol, func_rol_codigo_func),
	constraint FK_FuncionalidadRol_Rol foreign key (func_rol_codigo_rol)
	references CAIA_UNLIMITED.Rol (rol_codigo),
	constraint FK_FuncionalidadRol_Func foreign key (func_rol_codigo_func)
	references CAIA_UNLIMITED.Funcionalidad (func_codigo)
go

alter table CAIA_UNLIMITED.Regimen_X_Hotel
	add constraint PK_Regimen_X_Hotel primary key (regi_hote_id, regi_hote_codigo),
	constraint FK_RegimenHotel_Regi foreign key (regi_hote_codigo)
	references CAIA_UNLIMITED.Regimen (regi_codigo),
	constraint FK_RegimenHotel_Hote foreign key (regi_hote_id)
	references CAIA_UNLIMITED.Hotel (hote_id)
go

alter table CAIA_UNLIMITED.Usuario_X_Hotel
	add constraint PK_Usuario_X_Hotel primary key (usur_hote_idusur, usur_hote_idhote),
	constraint FK_UsuarioHotel_Usur foreign key (usur_hote_idusur)
	references CAIA_UNLIMITED.Usuario (usur_id),
	constraint FK_UsuarioHotel_Hote foreign key (usur_hote_idhote)
	references CAIA_UNLIMITED.Hotel (hote_id)
go

alter table CAIA_UNLIMITED.Reserva_X_Huesped
	add constraint PK_Reserva_X_Huesped primary key (rese_hues_codigo, rese_hues_mail, rese_hues_documento),
	constraint FK_ReservaHuesped_Rese foreign key (rese_hues_codigo)
	references CAIA_UNLIMITED.Reserva (rese_codigo),
	constraint FK_ReservaHuesped_Hues foreign key (rese_hues_mail, rese_hues_documento)
	references CAIA_UNLIMITED.Huesped (hues_mail, hues_documento)
	on update cascade
go

alter table CAIA_UNLIMITED.Consumible_X_Estadia
	add constraint PK_Consumible_X_Estadia primary key (cons_esta_codigo_cons, cons_esta_codigo_esta),
	constraint FK_ConsumibleEstadia_Cons foreign key (cons_esta_codigo_cons)
	references CAIA_UNLIMITED.Consumible (cons_codigo),
	constraint FK_ConsumibleEstadia_Esta foreign key (cons_esta_codigo_esta)
	references CAIA_UNLIMITED.Estadia (esta_codigo)
go

alter table CAIA_UNLIMITED.Habitacion_X_Reserva
	add constraint PK_Habitacion_X_Reserva primary key (habi_rese_numero, habi_rese_id, habi_rese_codigo),
	constraint FK_HabitacionReserva_Habi foreign key (habi_rese_id, habi_rese_numero)
	references CAIA_UNLIMITED.Habitacion (hote_id, habi_numero)
	on update cascade,
	constraint FK_HabitacionReserva_Rese foreign key (habi_rese_codigo)
	references CAIA_UNLIMITED.Reserva (rese_codigo)
go

alter table CAIA_UNLIMITED.Reserva_Cancelada
	add constraint FK_ReservaCancelada_Reserva foreign key (reca_rese)
	references CAIA_UNLIMITED.Reserva (rese_codigo),	
	constraint FK_ReservaCancelada_Usuario foreign key (reca_usuario)
	references CAIA_UNLIMITED.Usuario (usur_id)
go

--Estados Reserva
insert into CAIA_UNLIMITED.Estado_Reserva (esre_detalle)
values ('Reserva correcta'), ('Reserva modificada'), ('Reserva cancelada por recepcion'),
		('Reserva cancelada por cliente'), ('Reserva cancelada por Non-Show'),
		('Reserva con ingreso')


--Consumibles
insert into CAIA_UNLIMITED.Consumible (cons_codigo, cons_descripcion, cons_precio)
select distinct Consumible_Codigo, Consumible_Descripcion, Consumible_Precio from gd_esquema.Maestra
where Consumible_Codigo is not null

--Regimen
insert into CAIA_UNLIMITED.Regimen (regi_descripcion, regi_precio_base, regi_estado)
select distinct Regimen_Descripcion, Regimen_Precio, 1 from gd_esquema.Maestra

--Direccion
insert into CAIA_UNLIMITED.Direccion (dire_dom_calle, dire_ciudad, dire_nro_calle)
select distinct Hotel_Calle, Hotel_Ciudad, Hotel_Nro_Calle from gd_esquema.Maestra

insert into CAIA_UNLIMITED.Direccion (dire_dom_calle, dire_nro_calle, dire_dpto, dire_piso)
select distinct Cliente_Dom_Calle, Cliente_Nro_Calle, Cliente_Depto, Cliente_Piso from gd_esquema.Maestra

--Tipo_Habitacion
insert into CAIA_UNLIMITED.Tipo_Habitacion (thab_codigo, thab_descripcion, thab_porcentual)
select distinct Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual
from gd_esquema.Maestra

--Hotel
insert into CAIA_UNLIMITED.Hotel (hote_cant_estrellas, hote_recarga_estrella, dire_id)
select distinct Hotel_CantEstrella, Hotel_Recarga_Estrella, dire_id
from gd_esquema.Maestra join CAIA_UNLIMITED.Direccion on (Hotel_Calle = dire_dom_calle and
															Hotel_Ciudad = dire_ciudad and
															Hotel_Nro_Calle = dire_nro_calle)

--Habitacion
insert into CAIA_UNLIMITED.Habitacion (habi_numero, habi_piso, habi_frente, hote_id, thab_codigo, habi_habilitado)
select distinct Habitacion_Numero, Habitacion_Piso, Habitacion_Frente, hote_id, thab_codigo, 1
from gd_esquema.Maestra join CAIA_UNLIMITED.Tipo_Habitacion on (thab_codigo = Habitacion_Tipo_Codigo and
																thab_descripcion = Habitacion_Tipo_Descripcion and
																thab_porcentual = Habitacion_Tipo_Porcentual)
						join CAIA_UNLIMITED.Direccion D on (dire_ciudad = Hotel_Ciudad and
															dire_dom_calle = Hotel_Calle and
															dire_nro_calle = Hotel_Nro_Calle)
						join CAIA_UNLIMITED.Hotel H on (H.dire_id = D.dire_id) 

--Insertamos Usuarios
insert into CAIA_UNLIMITED.Usuario (usur_username, usur_password, usur_habilitado, usur_intentos) values('admin', HASHBYTES('SHA2_256', 'w23e'), 1, 0)
insert into CAIA_UNLIMITED.Usuario (usur_username, usur_password, usur_habilitado, usur_intentos) values('guest', HASHBYTES('SHA2_256', 'w23e'), 0, 0)

--Reserva
insert into CAIA_UNLIMITED.Reserva (rese_codigo, rese_fecha_realizacion, rese_fecha_desde, rese_cantidad_noches, regi_codigo, rese_usur_creacion, esre_codigo)
select distinct Reserva_Codigo, Reserva_Fecha_Inicio, Reserva_Fecha_Inicio, Reserva_Cant_Noches, L.regi_codigo, 0, 5
from gd_esquema.Maestra join CAIA_UNLIMITED.Direccion D on (Hotel_Calle = dire_dom_calle and
															Hotel_Nro_Calle = dire_nro_calle and
															Hotel_Ciudad = dire_ciudad)
						join CAIA_UNLIMITED.Hotel H on (H.dire_id = D.dire_id)
						join CAIA_UNLIMITED.Habitacion R on (H.hote_id  = R.hote_id and
															Habitacion_Numero = habi_numero)
						join CAIA_UNLIMITED.Regimen L on (regi_descripcion = Regimen_Descripcion)

--Huesped
insert into CAIA_UNLIMITED.Huesped (hues_mail, hues_nombre, hues_apellido, hues_documento, hues_documento_tipo, 
											hues_nacimiento, hues_nacionalidad, hues_habilitado, dire_id)
select distinct Cliente_Mail, Cliente_Nombre, Cliente_Apellido, Cliente_Pasaporte_Nro, 'PAS', Cliente_Fecha_Nac, Cliente_Nacionalidad, 1, dire_id
from gd_esquema.Maestra join CAIA_UNLIMITED.Direccion on (dire_dom_calle = Cliente_Dom_Calle and
															dire_nro_calle = Cliente_Nro_Calle and
															dire_piso = Cliente_Piso and
															dire_dpto = Cliente_Depto)

--Estadia
insert into CAIA_UNLIMITED.Estadia (esta_fecha_inicio, esta_fecha_fin, rese_codigo)
select distinct Estadia_Fecha_Inicio, DATEADD(day,Estadia_Cant_Noches, Estadia_Fecha_Inicio), rese_codigo
from gd_esquema.Maestra join CAIA_UNLIMITED.Reserva on (Reserva_Codigo = rese_codigo)
where Estadia_Fecha_Inicio is not null

--Factura
insert into CAIA_UNLIMITED.Factura (fact_nro, fact_fecha, fact_total, esta_codigo, hues_documento, hues_mail)
select Factura_Nro, Factura_Fecha, sum(Factura_Total), esta_codigo, hues_documento, hues_mail
from gd_esquema.Maestra join CAIA_UNLIMITED.Reserva R on (Reserva_Codigo = rese_codigo)
						join CAIA_UNLIMITED.Estadia E on (R.rese_codigo = E.rese_codigo)
						join CAIA_UNLIMITED.Huesped on (hues_documento = Cliente_Pasaporte_Nro and
														hues_mail = Cliente_Mail)
where Factura_Nro is not null
group by Factura_Nro, Factura_Fecha, esta_codigo, hues_documento, hues_mail

update CAIA_UNLIMITED.Estadia
set usur_checkin = (select usur_id from CAIA_UNLIMITED.Usuario where usur_username = 'admin'), usur_checkout = (select usur_id from CAIA_UNLIMITED.Usuario where usur_username = 'admin')
where  exists (select fact_nro from CAIA_UNLIMITED.Factura F where (esta_codigo = F.esta_codigo) and fact_nro is not null)



--Item_Factura
insert into CAIA_UNLIMITED.Item_Factura (item_cantidad, item_monto, fact_nro, cons_codigo)
select sum(Item_Factura_Cantidad), Item_Factura_Monto, Factura_Nro, Consumible_Codigo
from gd_esquema.Maestra
where Factura_Nro is not null
group by Item_Factura_Monto, Factura_Nro, Consumible_Codigo

--Regimen por Hotel
insert into CAIA_UNLIMITED.Regimen_X_Hotel(regi_hote_codigo, regi_hote_id)
select distinct regi_codigo, hote_id
from CAIA_UNLIMITED.Regimen join gd_esquema.Maestra on (regi_descripcion = Regimen_Descripcion and
														regi_precio_base = Regimen_Precio)
							join CAIA_UNLIMITED.Direccion D on (Hotel_Calle = dire_dom_calle and
																Hotel_Ciudad = dire_ciudad and
																Hotel_Nro_Calle = dire_nro_calle)
							join CAIA_UNLIMITED.Hotel H on (H.dire_id = D.dire_id)


--Consumible por estadia
insert into CAIA_UNLIMITED.Consumible_X_Estadia (cons_esta_codigo_cons, cons_esta_codigo_esta,cons_esta_cantidad)
select distinct cons_codigo, esta_codigo, sum(Item_Factura_Cantidad)
from CAIA_UNLIMITED.Consumible join gd_esquema.Maestra on (Consumible_Codigo = cons_codigo)
								join CAIA_UNLIMITED.Reserva R on (Reserva_Codigo = rese_codigo)
								join CAIA_UNLIMITED.Estadia E on (E.rese_codigo = R.rese_codigo)
where cons_codigo is not null
group by cons_codigo, esta_codigo



--Reserva por huesped
insert into CAIA_UNLIMITED.Reserva_X_Huesped (rese_hues_codigo, rese_hues_documento, rese_hues_mail)
select distinct rese_codigo, hues_documento, hues_mail
from CAIA_UNLIMITED.Reserva join gd_esquema.Maestra on (Reserva_Codigo = rese_codigo)
							join CAIA_UNLIMITED.Huesped on (Cliente_Mail = hues_mail and 
															Cliente_Pasaporte_Nro = hues_documento)

--Habitacion por reserva
insert into CAIA_UNLIMITED.Habitacion_X_Reserva (habi_rese_id, habi_rese_numero, habi_rese_codigo)
select distinct A.hote_id, A.habi_numero, rese_codigo
from gd_esquema.Maestra join CAIA_UNLIMITED.Direccion D on (Hotel_Calle = dire_dom_calle and
																Hotel_Ciudad = dire_ciudad and
																Hotel_Nro_Calle = dire_nro_calle)
							join CAIA_UNLIMITED.Hotel H on (H.dire_id = D.dire_id)
							join CAIA_UNLIMITED.Habitacion A on (A.hote_id = H.hote_id and A.habi_numero = Habitacion_Numero)
							join CAIA_UNLIMITED.Reserva R on (Reserva_Codigo = rese_codigo)


insert into CAIA_UNLIMITED.Rol (rol_nombre, rol_estado) values('Administrador General', 1), ('Recepcionista', 1), ('Guest', 1)

insert into CAIA_UNLIMITED.Rol_X_Usuario (rol_usur_id, rol_usur_codigo) values(0, 0)

insert into CAIA_UNLIMITED.Funcionalidad (func_detalle) values('ABM_ROL'), ('ABM_USUARIO'), ('ABM_CLIENTE'), ('ABM_HOTEL'), ('ABM_HABITACION'), ('ABM_ESTADIA'), ('RESERVA'), ('CANCELAR_RESERVA'), ('ESTADIA'), ('CONSUMIBLES'), ('FACTURAR'), ('LISTADO_ESTADISTICO') 

insert into CAIA_UNLIMITED.Funcionalidad_X_Rol (func_rol_codigo_rol, func_rol_codigo_func) 
values (0, 0), (0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7), (0, 8), (0, 9), (0, 10), (0, 11), (2, 6), (2, 7), (1, 2), (1, 6), (1, 7), (1, 8), (1, 9), (1, 10), (1, 11)

insert into CAIA_UNLIMITED.Usuario_X_Hotel (usur_hote_idusur, usur_hote_idhote)
select distinct 0, hote_id
from CAIA_UNLIMITED.Hotel

update CAIA_UNLIMITED.Huesped set hues_habilitado = 0
where hues_mail in (select h1.hues_mail from CAIA_UNLIMITED.Huesped h1 group by h1.hues_mail having count(*)>1)
go


--HOTEL

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_AlmacenarHotel] (@nombre_hotel nvarchar(255), @mail nvarchar(255), @estrellas numeric(18,0),
							@hote_telefono nvarchar(20), @calle nvarchar(255), @numero_calle numeric(18,0),
							@ciudad nvarchar(255), @pais nvarchar(255), @fecha datetime)
AS
BEGIN
SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_AlmacenarHotel;
		 
    	insert into CAIA_UNLIMITED.Direccion (dire_ciudad, dire_pais, dire_dom_calle, dire_nro_calle,
											dire_telefono)
		values (@ciudad, @pais, @calle, @numero_calle, @hote_telefono)
		insert into CAIA_UNLIMITED.Hotel (hote_nombre, hote_mail, hote_cant_estrellas, hote_fecha_creacion, dire_id, hote_recarga_estrella)
		values (@nombre_hotel, @mail, @estrellas, convert(datetime, @fecha, 120), (select dire_id from CAIA_UNLIMITED.Direccion
													where dire_telefono = @hote_telefono and
													dire_dom_calle = @calle and dire_ciudad = @ciudad
													and dire_pais = @pais and dire_nro_calle = @numero_calle), 10)		
    lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_AlmacenarHotel;
  END CATCH
END
GO

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_AgregarRegimenXHotel] (@codigo_regimen numeric(18,0), 
																@id_hotel numeric(18,0))
AS
BEGIN
	insert into CAIA_UNLIMITED.Regimen_X_Hotel (regi_hote_codigo, regi_hote_id)
	values (@codigo_regimen, @id_hotel)
END
GO

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_EliminarRegimenes] (@hotel numeric(18,0))
AS
BEGIN
	delete from CAIA_UNLIMITED.Regimen_X_Hotel
	where regi_hote_id = @hotel
END
GO

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_BajaHotel] (@id_hotel numeric(18,0), @fecha_inicio datetime, @fecha_fin datetime, @descripcion nvarchar(255))
AS
BEGIN	
SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_BajaHotel;
		 
		insert into CAIA_UNLIMITED.Mantenimiento (hote_id, mant_fecha_inicio, mant_fecha_fin, mant_descripcion)
		values (@id_hotel, convert(datetime, @fecha_inicio, 120), convert(datetime, @fecha_fin, 120), @descripcion)		
		
    lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_BajaHotel;
  END CATCH

END
GO

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_CrearDireccion] (@hote_telefono nvarchar(20), @calle nvarchar(255), @numero_calle numeric(18,0), 
														@ciudad nvarchar(255), @pais nvarchar(255))
AS
BEGIN
	INSERT INTO CAIA_UNLIMITED.Direccion (dire_dom_calle, dire_nro_calle, dire_telefono, dire_ciudad, dire_pais)
	VALUES(@calle, @numero_calle, @hote_telefono, @ciudad, @pais)
END
GO

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_ModificarHotel] (@idHotel numeric(18,0), @nombre_hotel nvarchar(255), @mail nvarchar(255), @estrellas numeric(18,0),
							@hote_telefono nvarchar(20), @calle nvarchar(255), @numero_calle numeric(18,0),
							@ciudad nvarchar(255), @pais nvarchar(255), @fecha datetime)
AS
BEGIN
SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_ModificarHotel;
		 
	update CAIA_UNLIMITED.Hotel
	set hote_nombre = @nombre_hotel, hote_mail = @mail, hote_cant_estrellas = @estrellas, hote_fecha_creacion = convert(datetime, @fecha, 120), dire_id = (select D.dire_id from CAIA_UNLIMITED.Direccion D where D.dire_dom_calle = @calle and D.dire_nro_calle = @numero_calle and D.dire_ciudad = @ciudad and D.dire_pais = @pais and D.dire_dpto is null and D.dire_piso is null and D.dire_telefono = @hote_telefono)
	where hote_id = @idHotel
		
    lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_ModificarHotel;
  END CATCH

END
GO

--HABITACION

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_CrearHabitacion] (@numero_habitacion numeric(18,0), @piso numeric(18,0), @frente nvarchar(50),
													 @descripcion nvarchar(255), @tipo numeric(18,0), @idHotel numeric(18,0))
AS
BEGIN
	insert into CAIA_UNLIMITED.Habitacion (habi_numero, habi_piso, habi_frente, habi_habilitado, habi_descripcion, 
											thab_codigo, hote_id)
	values(@numero_habitacion, @piso, @frente, 1, @descripcion, @tipo, @idHotel)
					
END
GO

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_ModificarHabitacion] (@numero_habitacion numeric(18,0), @piso numeric(18,0), @frente nvarchar(50),
													 @descripcion nvarchar(255), @viejo_numero numeric(18,0), @idHotel numeric(18,0))
AS
BEGIN
	update CAIA_UNLIMITED.Habitacion set habi_numero = @numero_habitacion, habi_piso = @piso, habi_frente = @frente, habi_descripcion = @descripcion
	where habi_numero = @viejo_numero and hote_id = @idHotel
					
END
GO

--FACTURA

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_AlmacenarFactura] (@numero numeric(18,0), @total numeric(18,2), 
															@estadia numeric(18,0), @mail nvarchar(255),
															@documento numeric(18,0), @fecha datetime)
AS
BEGIN
	insert into CAIA_UNLIMITED.Factura (fact_nro, fact_total, fact_fecha, esta_codigo, hues_mail, hues_documento)
	values (@numero, @total, convert(datetime,  @fecha, 120), @estadia, @mail, @documento)
END
GO

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_AlmacenarItem] (@consumible numeric(18,0), @cantidad numeric(18,0),
														@monto numeric(18,2), @numero_factura numeric(18,0))
AS 
BEGIN
	insert into CAIA_UNLIMITED.Item_Factura (cons_codigo, item_cantidad, item_monto, fact_nro)
	values (@consumible, @cantidad, @monto, @numero_factura)
END
GO

--PAGO

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_AlmacenarPagoTarjeta] (@nombre nvarchar(255), @apellido nvarchar(255), 
														@numero_tarjeta nvarchar(20), @codigo_seguridad nvarchar(4),
														@banco nvarchar(20), @fecha_vencimiento smalldatetime,
														@monto numeric(18,2), @numero_factura numeric(18,0))
AS
BEGIN
SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_AlmacenarPagoTarjeta;
		 
		insert into CAIA_UNLIMITED.Pago (pago_nombre, pago_apellido, pago_nro_tarjeta, pago_codigo_seguridad,
											pago_banco, pago_fecha_vencimiento, pago_monto)
		values (@nombre, @apellido, @numero_tarjeta, @codigo_seguridad, @banco, convert(datetime, @fecha_vencimiento, 120), @monto)
		update CAIA_UNLIMITED.Factura set pago_codigo = SCOPE_IDENTITY()
		where fact_nro = @numero_factura
		
    lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_AlmacenarPagoTarjeta;
  END CATCH

END
GO

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_AlmacenarPagoEfectivo] (@monto numeric(18,2), @numero_factura numeric(18,0))
AS
BEGIN
SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_AlmacenarPagoEfectivo;
		 
	insert into CAIA_UNLIMITED.Pago (pago_monto)
	values (@monto)
	update CAIA_UNLIMITED.Factura set pago_codigo = SCOPE_IDENTITY()
	where fact_nro = @numero_factura
		
    lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_AlmacenarPagoEfectivo;
  END CATCH

END
GO



--------Huesped

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_CrearHuesped] (@nombre nvarchar(255), @apellido nvarchar(255), @documento numeric(18,0), @tipo nvarchar(3), @mail nvarchar(255), @fecha_nacimiento datetime,@nacionalidad nvarchar(255),@calle nvarchar(255),@calle_nro numeric(18,0),@piso numeric(18,0),@dpto nvarchar(50),@ciudad nvarchar(255),@pais nvarchar(255), @telefono nvarchar(20))
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_CrearHuesped;

		if((SELECT COUNT(*) FROM CAIA_UNLIMITED.Direccion WHERE (CASE WHEN (dire_telefono IS NULL AND @telefono IS NULL) OR (dire_telefono = @telefono) THEN 1 ELSE 0 END) = 1 AND dire_dom_calle = @calle AND dire_nro_calle = @calle_nro AND (CASE WHEN (dire_piso IS NULL AND @piso IS NULL) OR (dire_piso = @piso) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (dire_dpto IS NULL AND @dpto IS NULL) OR (dire_dpto = @dpto) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (dire_ciudad IS NULL AND @ciudad IS NULL) OR (dire_ciudad = @ciudad) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (dire_pais IS NULL AND @pais IS NULL)  OR (dire_pais = @pais) THEN 1 ELSE 0 END) = 1) = 0)
        	BEGIN
			insert into CAIA_UNLIMITED.Direccion (dire_ciudad, dire_pais, dire_dom_calle, dire_nro_calle,dire_telefono,dire_piso,dire_dpto)
			values (@ciudad, @pais, @calle, @calle_nro, @telefono,@piso,@dpto)
        	END
	
		insert into CAIA_UNLIMITED.Huesped (hues_mail,hues_nombre,hues_apellido,hues_documento,hues_nacionalidad,hues_nacimiento,hues_documento_tipo,hues_habilitado,dire_id)
		values(@mail, @nombre,@apellido,@documento,@nacionalidad,convert(datetime,@fecha_nacimiento,120), @tipo,1,(SELECT dire_id FROM CAIA_UNLIMITED.Direccion WHERE dire_telefono = @telefono AND dire_dom_calle = @calle AND dire_nro_calle = @calle_nro AND (dire_piso = @piso or @piso is null) AND dire_dpto = @dpto AND dire_ciudad = @ciudad  AND dire_pais = @pais ))

	lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_CrearHuesped;

    RAISERROR ('sp_CrearHuesped: %d: %s', 16, 1, @error, @message);
  END CATCH
END
GO

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_BajaHuesped] (@email nvarchar(255))
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_BajaHuesped;

		update CAIA_UNLIMITED.Huesped 
		set hues_habilitado = 0 where hues_mail = @email

	lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_BajaHuesped;

    RAISERROR ('sp_BajaHuesped: %d: %s', 16, 1, @error, @message);
  END CATCH
END
GO

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_ModificarHuesped] (@nombre nvarchar(255), @apellido nvarchar(255), @documento numeric(18,0), @tipo nvarchar(3), @mail nvarchar(255), @fecha_nacimiento datetime,@nacionalidad nvarchar(255),@calle nvarchar(255),@calle_nro numeric(18,0),@piso numeric(18,0),@dpto nvarchar(50),@ciudad nvarchar(255),@pais nvarchar(255), @telefono nvarchar(20),@estado bit, @documentoViejo numeric(18,0), @tipoViejo nvarchar(3), @mailViejo nvarchar(255))
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_ModificarHuesped;

		update CAIA_UNLIMITED.Direccion 
		set dire_dom_calle = @calle, dire_nro_calle = @calle_nro, dire_ciudad = @ciudad, dire_pais = @pais, dire_telefono = @telefono,dire_piso=@piso, dire_dpto=@dpto
		where dire_id = (select H.dire_id 
				 from CAIA_UNLIMITED.Huesped H join CAIA_UNLIMITED.Direccion D on (H.dire_id = D.dire_id) 
				 where hues_mail = @mail)

		update CAIA_UNLIMITED.Huesped
		set hues_mail = @mail,hues_nombre=@nombre,hues_apellido=@apellido,hues_documento=@documento,hues_nacionalidad=@nacionalidad,hues_nacimiento=convert(datetime,@fecha_nacimiento,120),hues_documento_tipo=@tipo, hues_habilitado=@estado
		where hues_mail = @mailViejo and hues_documento=@documentoViejo and hues_documento_tipo=@tipoViejo

	lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_ModificarHuesped;

    RAISERROR ('sp_ModificarHuesped: %d: %s', 16, 1, @error, @message);
  END CATCH
END
GO

----Rol
GO
CREATE TYPE [CAIA_UNLIMITED].FuncionalidadesList AS TABLE ( Funcionalidades numeric(18,0))
GO
CREATE TYPE [CAIA_UNLIMITED].RolesLista AS TABLE ( Roles numeric(18,0))
GO
CREATE TYPE [CAIA_UNLIMITED].HotelesLista AS TABLE ( Hoteles numeric(18,0))

GO
CREATE PROCEDURE [CAIA_UNLIMITED].[sp_CrearRol] (@nombre_rol nvarchar(255),@lista_Funcionalidades FuncionalidadesList READONLY,@estado_rol bit)
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @codigoRol numeric(18,0);
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_CrearRol;

    	insert into CAIA_UNLIMITED.Rol (rol_nombre,rol_estado)
	values (@nombre_rol,@estado_rol)
	select @codigoRol = Scope_Identity()
	insert into CAIA_UNLIMITED.Funcionalidad_X_Rol(func_rol_codigo_func,func_rol_codigo_rol)
	SELECT Funcionalidades, @codigoRol FROM @lista_Funcionalidades	

    lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_CrearRol;

    RAISERROR ('sp_CrearRol: %d: %s', 16, 1, @error, @message);
  END CATCH
END

GO
CREATE PROCEDURE [CAIA_UNLIMITED].[sp_ModificarRol] (@codigo_rol numeric(18,0),@nombre_rol nvarchar(255),@lista_Funcionalidades FuncionalidadesList READONLY,@estado_rol bit)
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_ModificarRol;

    	update CAIA_UNLIMITED.Rol set rol_estado = @estado_rol, rol_nombre = @nombre_rol
	where rol_codigo = @codigo_rol

	DELETE FROM CAIA_UNLIMITED.Funcionalidad_X_Rol
	WHERE func_rol_codigo_rol = @codigo_rol

	insert into CAIA_UNLIMITED.Funcionalidad_X_Rol(func_rol_codigo_func,func_rol_codigo_rol)
	SELECT Funcionalidades, @codigo_rol FROM @lista_Funcionalidades

    lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_ModificarRol;

    RAISERROR ('sp_ModificarRol: %d: %s', 16, 1, @error, @message);
  END CATCH
END

GO
CREATE PROCEDURE [CAIA_UNLIMITED].[sp_CrearUsuarios] (@username nvarchar(255),@password varbinary(100),@name nvarchar(255),@apellido nvarchar(255),@nacionalidad nvarchar(255),@tipoDocumento nvarchar(3),@documento numeric(18,0),@fechaNacimiento datetime,@pais nvarchar(255),@ciudad nvarchar(255),@calle nvarchar(255),@numeroCalle numeric(18,0),@piso numeric(18,0),@departamento nvarchar(50),@telefono nvarchar(20),@mail nvarchar(255),@lista_Roles RolesLista READONLY,@lista_Hoteles HotelesLista READONLY)
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @userid numeric(18,0);
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_CrearUsuarios;

	if((SELECT COUNT(*) FROM CAIA_UNLIMITED.Direccion WHERE (CASE WHEN (dire_telefono IS NULL AND @telefono IS NULL) OR (dire_telefono = @telefono) THEN 1 ELSE 0 END) = 1 AND dire_dom_calle = @calle AND dire_nro_calle = @numeroCalle AND (CASE WHEN (dire_piso IS NULL AND @piso IS NULL) OR (dire_piso = @piso) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (dire_dpto IS NULL AND @departamento IS NULL) OR (dire_dpto = @departamento) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (dire_ciudad IS NULL AND @ciudad IS NULL) OR (dire_ciudad = @ciudad) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (dire_pais IS NULL AND @pais IS NULL)  OR (dire_pais = @pais) THEN 1 ELSE 0 END) = 1) = 0)
		BEGIN
			insert into CAIA_UNLIMITED.Direccion (dire_telefono,dire_dom_calle,dire_nro_calle,dire_piso,dire_dpto,dire_ciudad,dire_pais)
			values (@telefono,@calle,@numeroCalle,@piso,@departamento,@ciudad,@pais)
		END

	insert into CAIA_UNLIMITED.Usuario (usur_username,usur_password,usur_nombre,usur_apellido,usur_documento,usur_documento_tipo,usur_mail,usur_nacimiento,usur_habilitado,usur_intentos,dire_id)
	values (@username,@password,@name,@apellido,@documento,@tipoDocumento,@mail,convert(datetime,@fechaNacimiento,120),1,0,(SELECT dire_id FROM CAIA_UNLIMITED.Direccion WHERE (CASE WHEN (dire_telefono IS NULL AND @telefono IS NULL) OR (dire_telefono = @telefono) THEN 1 ELSE 0 END) = 1 AND dire_dom_calle = @calle AND dire_nro_calle = @numeroCalle AND (CASE WHEN (dire_piso IS NULL AND @piso IS NULL) OR (dire_piso = @piso) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (dire_dpto IS NULL AND @departamento IS NULL) OR (dire_dpto = @departamento) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (dire_ciudad IS NULL AND @ciudad IS NULL) OR (dire_ciudad = @ciudad) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (dire_pais IS NULL AND @pais IS NULL) OR (dire_pais = @pais) THEN 1 ELSE 0 END) = 1))
	SELECT @userid = SCOPE_IDENTITY();

	insert into CAIA_UNLIMITED.Rol_X_Usuario(rol_usur_codigo,rol_usur_id)
	SELECT Roles, @userid FROM @lista_Roles

	insert into CAIA_UNLIMITED.Usuario_X_Hotel(usur_hote_idhote,usur_hote_idusur)
	SELECT Hoteles, @userid FROM @lista_Hoteles	

    lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_CrearUsuarios;

    RAISERROR ('sp_CrearUsuarios: %d: %s', 16, 1, @error, @message);
  END CATCH
END

GO
CREATE PROCEDURE [CAIA_UNLIMITED].[sp_ModificarUsuarios] (@idDireccion numeric(18,0),@password varbinary(100),@estado bit,@username nvarchar(255),@name nvarchar(255),@apellido nvarchar(255),@nacionalidad nvarchar(255),@tipoDocumento nvarchar(3),@documento numeric(18,0),@fechaNacimiento datetime,@pais nvarchar(255),@ciudad nvarchar(255),@calle nvarchar(255),@numeroCalle numeric(18,0),@piso numeric(18,0),@departamento nvarchar(50),@telefono nvarchar(20),@mail nvarchar(255),@lista_Roles RolesLista READONLY,@lista_Hoteles HotelesLista READONLY)
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @userid numeric(18,0);
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_ModificarUsuarios;

    	update CAIA_UNLIMITED.Direccion set dire_telefono = @telefono,dire_dom_calle = @calle,dire_nro_calle = @numeroCalle,dire_piso = @piso,dire_dpto = @departamento,dire_ciudad = @ciudad,dire_pais = @pais
	where dire_id = @idDireccion

	SELECT @userid = u.usur_id FROM CAIA_UNLIMITED.Usuario u where u.usur_username = @username

	if(@estado = 1)
		BEGIN
			update CAIA_UNLIMITED.Usuario set usur_password = @password,usur_nombre = @name,usur_apellido = @apellido,usur_documento = @documento,usur_documento_tipo = @tipoDocumento,usur_mail = @mail,usur_nacimiento = convert(datetime,@fechaNacimiento,120),usur_habilitado = 1
			where usur_id = @userid
		END
	else
		BEGIN
			update CAIA_UNLIMITED.Usuario set usur_password = @password,usur_nombre = @name,usur_apellido = @apellido,usur_documento = @documento,usur_documento_tipo = @tipoDocumento,usur_mail = @mail,usur_nacimiento = convert(datetime,@fechaNacimiento,120),usur_habilitado = 0
			where usur_id = @userid
		END

	DELETE FROM CAIA_UNLIMITED.Rol_X_Usuario 
	WHERE rol_usur_id = @userid

	DELETE FROM CAIA_UNLIMITED.Usuario_X_Hotel
	WHERE usur_hote_idusur = @userid

	insert into CAIA_UNLIMITED.Rol_X_Usuario(rol_usur_codigo,rol_usur_id)
	SELECT Roles, @userid FROM @lista_Roles

	insert into CAIA_UNLIMITED.Usuario_X_Hotel(usur_hote_idhote,usur_hote_idusur)
	SELECT Hoteles, @userid FROM @lista_Hoteles

    lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_ModificarUsuarios;

    RAISERROR ('sp_ModificarUsuarios: %d: %s', 16, 1, @error, @message);
  END CATCH
END

GO
CREATE PROCEDURE [CAIA_UNLIMITED].[sp_EliminarUsuarios] (@username nvarchar(255),@mail nvarchar(255),@documento numeric(18,0))
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_EliminarUsuarios;

    	UPDATE CAIA_UNLIMITED.Usuario SET usur_habilitado = 0 
	WHERE usur_username = @username

    lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_EliminarUsuarios;

    RAISERROR ('sp_EliminarUsuarios: %d: %s', 16, 1, @error, @message);
  END CATCH
END

GO
CREATE TYPE [CAIA_UNLIMITED].HabitacionesLista AS TABLE ( Habitacion numeric(18,0))
GO
CREATE PROCEDURE [CAIA_UNLIMITED].[sp_CrearReservaHuesped] (@hotel numeric(18,0),@fechaRealizacion datetime,@fechaDesde datetime,@cantidadNoches numeric(18,0),@regimen numeric(18,0),@estado nvarchar(255),@lista_Habitaciones HabitacionesLista READONLY)
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @trancount int;
  DECLARE @returnreserva numeric(18,0);
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_CrearReservaHuesped;
	SET @returnreserva = (SELECT MAX(rese_codigo) FROM CAIA_UNLIMITED.Reserva)+1	
    	insert into CAIA_UNLIMITED.Reserva (rese_codigo,rese_fecha_realizacion,rese_fecha_desde,rese_cantidad_noches,esre_codigo,regi_codigo,rese_usur_creacion)
	values(@returnreserva,convert(datetime,@fechaRealizacion,120),convert(datetime,@fechaDesde,120),@cantidadNoches,(SELECT esre_codigo FROM CAIA_UNLIMITED.Estado_Reserva WHERE esre_detalle = @estado),@regimen,1)	
	insert into CAIA_UNLIMITED.Habitacion_X_Reserva(habi_rese_numero,habi_rese_id,habi_rese_codigo)
	SELECT Habitacion, @hotel,@returnreserva FROM @lista_Habitaciones
    lbexit:
      IF @trancount = 0
      COMMIT;	
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_CrearReservaHuesped;

    RAISERROR ('sp_CrearReservaHuesped: %d: %s', 16, 1, @error, @message);
  END CATCH
 RETURN @returnreserva 
END
GO
CREATE PROCEDURE [CAIA_UNLIMITED].[sp_CrearReservaUsuario] (@usuarioCreacion nvarchar(255),@hotel numeric(18,0),@fechaRealizacion datetime,@fechaDesde datetime,@cantidadNoches numeric(18,0),@regimen numeric(18,0),@estado nvarchar(255),@lista_Habitaciones HabitacionesLista READONLY)
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @trancount int;
  DECLARE @creacionDelUsuario numeric(18,0);
  DECLARE @returnreserva numeric(18,0);
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_CrearReservaUsuario;
	SET @returnreserva = (SELECT MAX(rese_codigo) FROM CAIA_UNLIMITED.Reserva)+1
	SET @creacionDelUsuario = (SELECT usur_id FROM CAIA_UNLIMITED.Usuario WHERE usur_username = @usuarioCreacion)	
    insert into CAIA_UNLIMITED.Reserva (rese_codigo,rese_usur_creacion,rese_fecha_realizacion,rese_fecha_desde,rese_cantidad_noches,esre_codigo,regi_codigo)
	values(@returnreserva,@creacionDelUsuario,convert(datetime,@fechaRealizacion,120),convert(datetime,@fechaDesde,120),@cantidadNoches,(SELECT esre_codigo FROM CAIA_UNLIMITED.Estado_Reserva WHERE esre_detalle = @estado),@regimen)	
	insert into CAIA_UNLIMITED.Habitacion_X_Reserva(habi_rese_numero,habi_rese_id,habi_rese_codigo)
	SELECT Habitacion, @hotel,@returnreserva FROM @lista_Habitaciones
    lbexit:
      IF @trancount = 0
      COMMIT;	
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_CrearReservaUsuario;

    RAISERROR ('sp_CrearReservaUsuario: %d: %s', 16, 1, @error, @message);
  END CATCH
 RETURN @returnreserva 
END
GO
CREATE PROCEDURE [CAIA_UNLIMITED].[sp_ModificarReservaUsuario] (@usuarioModificacion nvarchar(255),@codigoReserva numeric(18,0),@hotel numeric(18,0),@fechaRealizacion datetime,@fechaDesde datetime,@cantidadNoches numeric(18,0),@regimen numeric(18,0),@estado nvarchar(255),@lista_Habitaciones HabitacionesLista READONLY)
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @trancount int;
  DECLARE @modificacionDelUsuario numeric(18,0);
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_ModificarReservaUsuario;
	
	SET @modificacionDelUsuario = (SELECT usur_id FROM CAIA_UNLIMITED.Usuario WHERE usur_username = @usuarioModificacion)

	DELETE FROM CAIA_UNLIMITED.Habitacion_X_Reserva
	WHERE habi_rese_codigo = @codigoReserva
	update CAIA_UNLIMITED.Reserva set rese_fecha_realizacion = convert(datetime,@fechaRealizacion,120), rese_usur_modificacion = @modificacionDelUsuario,rese_fecha_desde = convert(datetime,@fechaDesde,120),rese_cantidad_noches = @cantidadNoches,esre_codigo = (SELECT esre_codigo FROM CAIA_UNLIMITED.Estado_Reserva WHERE esre_detalle = @estado),regi_codigo = @regimen
	WHERE rese_codigo = @codigoReserva

	insert into CAIA_UNLIMITED.Habitacion_X_Reserva(habi_rese_numero,habi_rese_id,habi_rese_codigo)
	SELECT Habitacion, @hotel,@codigoReserva FROM @lista_Habitaciones

    lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_ModificarReservaUsuario;

    RAISERROR ('sp_ModificarReservaUsuario: %d: %s', 16, 1, @error, @message);
  END CATCH
END

GO
CREATE PROCEDURE [CAIA_UNLIMITED].[sp_ModificarReservaHuesped] (@codigoReserva numeric(18,0),@hotel numeric(18,0),@fechaRealizacion datetime,@fechaDesde datetime,@cantidadNoches numeric(18,0),@regimen numeric(18,0),@estado nvarchar(255),@lista_Habitaciones HabitacionesLista READONLY)
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_ModificarReservaHuesped;

	DELETE FROM CAIA_UNLIMITED.Habitacion_X_Reserva
	WHERE habi_rese_codigo = @codigoReserva
	update CAIA_UNLIMITED.Reserva set rese_fecha_realizacion = convert(datetime,@fechaRealizacion,120),rese_fecha_desde = convert(datetime,@fechaDesde,120),rese_cantidad_noches = @cantidadNoches,esre_codigo = (SELECT esre_codigo FROM CAIA_UNLIMITED.Estado_Reserva WHERE esre_detalle = @estado),regi_codigo = @regimen, rese_usur_modificacion = 1
	WHERE rese_codigo = @codigoReserva

	insert into CAIA_UNLIMITED.Habitacion_X_Reserva(habi_rese_numero,habi_rese_id,habi_rese_codigo)
	SELECT Habitacion, @hotel,@codigoReserva FROM @lista_Habitaciones

    lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_ModificarReservaHuesped;

    RAISERROR ('sp_ModificarReservaHuesped: %d: %s', 16, 1, @error, @message);
  END CATCH
END

GO
CREATE PROCEDURE [CAIA_UNLIMITED].[sp_CrearCliente] (@codigoReserva numeric(18,0),@name nvarchar(255),@apellido nvarchar(255),@tipoDocumento nvarchar(3),@documento numeric(18,0),@pais nvarchar(255),@ciudad nvarchar(255),@telefono nvarchar(20),@mail nvarchar(255),@calle nvarchar(255),@numeroCalle numeric(18,0))
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_CrearCliente;

	if((SELECT COUNT(*) FROM CAIA_UNLIMITED.Direccion WHERE (CASE WHEN (dire_telefono IS NULL AND @telefono IS NULL) OR (dire_telefono = @telefono) THEN 1 ELSE 0 END) = 1 AND dire_dom_calle = @calle AND dire_nro_calle = @numeroCalle AND (CASE WHEN (dire_ciudad IS NULL AND @ciudad IS NULL) OR (dire_ciudad = @ciudad) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (dire_pais IS NULL AND @pais IS NULL) OR (dire_pais = @pais) THEN 1 ELSE 0 END) = 1) = 0)
		BEGIN
			insert into CAIA_UNLIMITED.Direccion (dire_telefono,dire_dom_calle,dire_nro_calle,dire_ciudad,dire_pais)
			values (@telefono,@calle,@numeroCalle,@ciudad,@pais)
		END
	
	insert into CAIA_UNLIMITED.Huesped (hues_mail,hues_nombre,hues_apellido,hues_documento,hues_documento_tipo,hues_habilitado,hues_nacionalidad,dire_id)
	values (@mail,@name,@apellido,@documento,@tipoDocumento,1,@pais,(SELECT dire_id FROM CAIA_UNLIMITED.Direccion WHERE (CASE WHEN (dire_telefono IS NULL AND @telefono IS NULL) OR (dire_telefono = @telefono) THEN 1 ELSE 0 END) = 1 AND dire_dom_calle = @calle AND dire_nro_calle = @numeroCalle AND (CASE WHEN (dire_ciudad IS NULL AND @ciudad IS NULL) OR (dire_ciudad = @ciudad) THEN 1 ELSE 0 END) = 1 AND (CASE WHEN (dire_pais IS NULL AND @pais IS NULL) OR (dire_pais = @pais) THEN 1 ELSE 0 END) = 1))
	
	insert into CAIA_UNLIMITED.Reserva_X_Huesped(rese_hues_codigo,rese_hues_mail,rese_hues_documento)
	values(@codigoReserva,@mail,@documento)
    lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_CrearCliente;

    RAISERROR ('sp_CrearCliente: %d: %s', 16, 1, @error, @message);
  END CATCH
END

GO
CREATE PROCEDURE [CAIA_UNLIMITED].[sp_CrearClienteExistente] (@codigoReserva numeric(18,0),@documento numeric(18,0),@mail nvarchar(255))
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_CrearClienteExistente;
	insert into CAIA_UNLIMITED.Reserva_X_Huesped(rese_hues_codigo,rese_hues_mail,rese_hues_documento)
	values(@codigoReserva,@mail,@documento)
    lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_CrearClienteExistente;

    RAISERROR ('sp_CrearClienteExistente: %d: %s', 16, 1, @error, @message);
  END CATCH
END

GO
CREATE PROCEDURE [CAIA_UNLIMITED].[sp_ModificarClienteExistente] (@codigoReserva numeric(18,0),@documento numeric(18,0),@mail nvarchar(255))
AS
BEGIN	
  SET NOCOUNT ON;


  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_ModificarClienteExistente;
	DELETE FROM CAIA_UNLIMITED.Reserva_X_Huesped
	WHERE rese_hues_codigo = @codigoReserva

	insert into CAIA_UNLIMITED.Reserva_X_Huesped(rese_hues_codigo,rese_hues_mail,rese_hues_documento)
	values(@codigoReserva,@mail,@documento)
    lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_ModificarClienteExistente;

    RAISERROR ('sp_ModificarClienteExistente: %d: %s', 16, 1, @error, @message);
  END CATCH
END

GO
CREATE PROCEDURE [CAIA_UNLIMITED].[sp_ModificarCliente] (@codigoReserva numeric(18,0),@name nvarchar(255),@apellido nvarchar(255),@tipoDocumento nvarchar(3),@documento numeric(18,0),@pais nvarchar(255),@ciudad nvarchar(255),@telefono nvarchar(20),@mail nvarchar(255),@calle nvarchar(255),@numeroCalle numeric(18,0))
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_ModificarCliente;
	update CAIA_UNLIMITED.Direccion set dire_telefono = @telefono,dire_dom_calle = @calle,dire_nro_calle = @numeroCalle,dire_ciudad = @ciudad,dire_pais =@pais
	WHERE dire_id = (SELECT d.dire_id FROM CAIA_UNLIMITED.Direccion d JOIN CAIA_UNLIMITED.Huesped h on d.dire_id = h.dire_id JOIN CAIA_UNLIMITED.Reserva_X_Huesped rh on (rh.rese_hues_mail = h.hues_mail AND rh.rese_hues_documento = h.hues_documento) WHERE rh.rese_hues_codigo = @codigoReserva)
	
	update CAIA_UNLIMITED.Huesped set hues_mail = @mail, hues_nombre = @name, hues_apellido = @apellido, hues_documento = @documento, hues_documento_tipo = @tipoDocumento, hues_habilitado = 1, hues_nacionalidad = @pais, dire_id = (SELECT d.dire_id FROM CAIA_UNLIMITED.Direccion d JOIN CAIA_UNLIMITED.Huesped h on d.dire_id = h.dire_id JOIN CAIA_UNLIMITED.Reserva_X_Huesped rh on (rh.rese_hues_mail = h.hues_mail AND rh.rese_hues_documento = h.hues_documento) WHERE rh.rese_hues_codigo = @codigoReserva)
	WHERE hues_mail = (SELECT hues_mail FROM CAIA_UNLIMITED.Huesped h JOIN CAIA_UNLIMITED.Reserva_X_Huesped rh on (rh.rese_hues_mail = h.hues_mail AND rh.rese_hues_documento = h.hues_documento) WHERE rh.rese_hues_codigo = @codigoReserva) AND hues_documento = (SELECT hues_documento FROM CAIA_UNLIMITED.Huesped h JOIN CAIA_UNLIMITED.Reserva_X_Huesped rh on (rh.rese_hues_mail = h.hues_mail AND rh.rese_hues_documento = h.hues_documento) WHERE rh.rese_hues_codigo = @codigoReserva)
	
	DELETE FROM CAIA_UNLIMITED.Reserva_X_Huesped
	WHERE rese_hues_codigo = @codigoReserva

	insert into CAIA_UNLIMITED.Reserva_X_Huesped(rese_hues_codigo,rese_hues_mail,rese_hues_documento)
	values(@codigoReserva,@mail,@documento)
    lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_ModificarCliente;

    RAISERROR ('sp_ModificarCliente: %d: %s', 16, 1, @error, @message);
  END CATCH
END

GO
CREATE PROCEDURE [CAIA_UNLIMITED].[sp_eliminarHabitaciones] (@codigoReserva numeric(18,0),@hotel numeric(18,0))
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_eliminarHabitaciones;	
	DELETE FROM CAIA_UNLIMITED.Habitacion_X_Reserva
	WHERE habi_rese_id = @hotel AND habi_rese_codigo = @codigoReserva 
    lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_eliminarHabitaciones;

    RAISERROR ('sp_eliminarHabitaciones: %d: %s', 16, 1, @error, @message);
  END CATCH
END
GO

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_CheckearEfectivizados] (@fechaRealizacion datetime,@hotel numeric(18,0))
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_CheckearEfectivizados;

		insert into CAIA_UNLIMITED.Reserva_Cancelada (reca_rese,reca_motivo,reca_fecha_cancelacion)
		SELECT r.rese_codigo, 'No se ha presentado el huesped',convert(datetime,@fechaRealizacion,120) FROM CAIA_UNLIMITED.Reserva r JOIN CAIA_UNLIMITED.Habitacion_X_Reserva hr on (hr.habi_rese_codigo = r.rese_codigo AND hr.habi_rese_id = @hotel) where r.rese_codigo not in (SELECT rc.reca_rese FROM CAIA_UNLIMITED.Reserva_Cancelada rc) AND r.esre_codigo not in (SELECT er.esre_codigo FROM CAIA_UNLIMITED.Estado_Reserva er where esre_detalle = 'Reserva cancelada por Non-Show') AND r.rese_codigo not in (SELECT e.rese_codigo FROM CAIA_UNLIMITED.Estadia e where e.rese_codigo = r.rese_codigo AND e.esta_fecha_inicio = r.rese_fecha_desde) AND @fechaRealizacion>r.rese_fecha_desde

		update CAIA_UNLIMITED.Reserva set esre_codigo = (SELECT esre_codigo FROM CAIA_UNLIMITED.Estado_Reserva where esre_detalle = 'Reserva cancelada por Non-Show')
		WHERE rese_codigo in (SELECT reca_rese FROM CAIA_UNLIMITED.Reserva_Cancelada where reca_motivo = 'No se ha presentado el huesped')
	lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_CheckearEfectivizados;

    RAISERROR ('sp_CheckearEfectivizados: %d: %s', 16, 1, @error, @message);
  END CATCH
END
GO

-----------Registrar consumible

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_RegistrarConsumible] (@codigo_estadia numeric(18,0), @codigo_consumible numeric(18,0),@cantidad numeric(18,0))
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_RegistrarConsumible;

		insert into CAIA_UNLIMITED.Consumible_X_Estadia(cons_esta_codigo_cons, cons_esta_codigo_esta,cons_esta_cantidad)
		values (@codigo_consumible, @codigo_estadia,@cantidad)
	lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_RegistrarConsumible;

    RAISERROR ('sp_RegistrarConsumible: %d: %s', 16, 1, @error, @message);
  END CATCH
END
GO

-----------Cancelar reserva

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_CancelarReservaUsuario] (@codigo_reserva numeric(18,0), @motivo nvarchar(255), @fecha_cancelacion datetime, @usuario nvarchar(255),@estado nvarchar(255))
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_CancelarReservaUsuario;

		insert into CAIA_UNLIMITED.Reserva_Cancelada(reca_rese,reca_motivo,reca_fecha_cancelacion,reca_usuario)
		values (@codigo_reserva,@motivo,convert(datetime,@fecha_cancelacion,120),@usuario)
		update CAIA_UNLIMITED.Reserva 

		set esre_codigo=(SELECT esre_codigo FROM CAIA_UNLIMITED.Estado_Reserva where esre_detalle = @estado)where rese_codigo = @codigo_reserva

	lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_CancelarReservaUsuario;

    RAISERROR ('sp_CancelarReservaUsuario: %d: %s', 16, 1, @error, @message);
  END CATCH
END
GO


CREATE PROCEDURE [CAIA_UNLIMITED].[sp_CancelarReservaHuesped] (@codigo_reserva numeric(18,0), @motivo nvarchar(255), @fecha_cancelacion datetime)
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_CancelarReservaHuesped;

		insert into CAIA_UNLIMITED.Reserva_Cancelada(reca_rese,reca_motivo,reca_fecha_cancelacion,reca_usuario)
		values (@codigo_reserva,@motivo,convert(datetime,@fecha_cancelacion,120),1)
		update CAIA_UNLIMITED.Reserva 
		set esre_codigo=(SELECT esre_codigo FROM CAIA_UNLIMITED.Estado_Reserva where esre_detalle = 'Reserva cancelada por cliente')  where rese_codigo = @codigo_reserva
	lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_CancelarReservaHuesped;

    RAISERROR ('sp_CancelarReservaHuesped: %d: %s', 16, 1, @error, @message);
  END CATCH
END
GO

------------Registrar estadia

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_RegistrarIngreso](@fecha_inicio datetime, @usuario numeric(18,0),@codigo_reserva numeric(18,0))
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_RegistrarIngreso;

		insert into CAIA_UNLIMITED.Estadia(esta_fecha_inicio,rese_codigo,usur_checkin)
		values (convert(datetime,@fecha_inicio,120),@codigo_reserva,@usuario)
		update CAIA_UNLIMITED.Reserva 
		set esre_codigo=(SELECT esre_codigo FROM CAIA_UNLIMITED.Estado_Reserva where esre_detalle = 'Reserva con ingreso') where rese_codigo = @codigo_reserva
	lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_RegistrarIngreso;

    RAISERROR ('sp_RegistrarIngreso: %d: %s', 16, 1, @error, @message);
  END CATCH
END
GO

CREATE PROCEDURE [CAIA_UNLIMITED].[sp_RegistrarEgreso](@fecha_egreso datetime, @usuario numeric(18,0),@estadia_Id numeric (18,0))
AS
BEGIN	
  SET NOCOUNT ON;
  DECLARE @trancount int;
  SET @trancount = @@trancount;
  BEGIN TRY
    IF @trancount = 0
      BEGIN TRANSACTION
      ELSE
        SAVE TRANSACTION sp_RegistrarEgreso;

		update CAIA_UNLIMITED.Estadia 
		set esta_fecha_fin=convert(datetime,@fecha_egreso,120), usur_checkout= @usuario where esta_codigo = @estadia_Id
	lbexit:
      IF @trancount = 0
      COMMIT;
  END TRY
  BEGIN CATCH
    DECLARE @error int,
            @message varchar(4000),
            @xstate int;

    SELECT
      @error = ERROR_NUMBER(),
      @message = ERROR_MESSAGE(),
      @xstate = XACT_STATE();

    IF @xstate = -1
      ROLLBACK;
    IF @xstate = 1 AND @trancount = 0
      ROLLBACK
    IF @xstate = 1 AND @trancount > 0
      ROLLBACK TRANSACTION sp_RegistrarEgreso;

    RAISERROR ('sp_RegistrarEgreso: %d: %s', 16, 1, @error, @message);
  END CATCH
END
