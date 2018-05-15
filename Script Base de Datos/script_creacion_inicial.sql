USE [GD1C2018]

SET QUOTED_IDENTIFIER OFF

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'CAIA_UNLIMITED')
BEGIN
EXEC ('CREATE SCHEMA [CAIA_UNLIMITED] AUTHORIZATION [gd]')
END

--Provisorio

if OBJECT_ID('[CAIA_UNLIMITED].[Rol_X_Usuario]', 'U') is not null
drop table CAIA_UNLIMITED.Rol_X_Usuario

if OBJECT_ID('[CAIA_UNLIMITED].[Funcionalidad_X_Rol]', 'U') is not null
drop table CAIA_UNLIMITED.Funcionalidad_X_Rol

if OBJECT_ID('[CAIA_UNLIMITED].[Regimen_X_Hotel]', 'U') is not null
drop table CAIA_UNLIMITED.Regimen_X_Hotel

if OBJECT_ID('[CAIA_UNLIMITED].[Usuario_X_Hotel]', 'U') is not null
drop table CAIA_UNLIMITED.Usuario_X_Hotel

if OBJECT_ID('[CAIA_UNLIMITED].[Reserva_X_Huesped]', 'U') is not null
drop table CAIA_UNLIMITED.Reserva_X_Huesped

if OBJECT_ID('[CAIA_UNLIMITED].[Consumible_X_Estadia]', 'U') is not null
drop table CAIA_UNLIMITED.Consumible_X_Estadia

if OBJECT_ID('[CAIA_UNLIMITED].[Item_Factura]', 'U') is not null
drop table CAIA_UNLIMITED.Item_Factura

if OBJECT_ID('[CAIA_UNLIMITED].[Factura]', 'U') is not null
drop table CAIA_UNLIMITED.Factura

if OBJECT_ID('[CAIA_UNLIMITED].[Estadia]', 'U') is not null
drop table CAIA_UNLIMITED.Estadia

if OBJECT_ID('[CAIA_UNLIMITED].[Reserva]', 'U') is not null
drop table CAIA_UNLIMITED.Reserva

if OBJECT_ID('[CAIA_UNLIMITED].[Huesped]', 'U') is not null
drop table CAIA_UNLIMITED.Huesped

if OBJECT_ID('[CAIA_UNLIMITED].[Usuario]', 'U') is not null
drop table CAIA_UNLIMITED.Usuario

if OBJECT_ID('[CAIA_UNLIMITED].[Habitacion]', 'U') is not null
drop table CAIA_UNLIMITED.Habitacion

if OBJECT_ID('[CAIA_UNLIMITED].[Hotel]', 'U') is not null
drop table CAIA_UNLIMITED.Hotel

if OBJECT_ID('[CAIA_UNLIMITED].[Tipo_Habitacion]', 'U') is not null
drop table CAIA_UNLIMITED.Tipo_Habitacion

if OBJECT_ID('[CAIA_UNLIMITED].[Rol]', 'U') is not null
drop table CAIA_UNLIMITED.Rol

if OBJECT_ID('[CAIA_UNLIMITED].[Funcionalidad]', 'U') is not null
drop table CAIA_UNLIMITED.Funcionalidad

if OBJECT_ID('[CAIA_UNLIMITED].[Regimen]', 'U') is not null
drop table CAIA_UNLIMITED.Regimen

if OBJECT_ID('[CAIA_UNLIMITED].[Direccion]', 'U') is not null
drop table CAIA_UNLIMITED.Direccion

if OBJECT_ID('[CAIA_UNLIMITED].[Estado_Reserva]', 'U') is not null
drop table CAIA_UNLIMITED.Estado_Reserva

if OBJECT_ID('[CAIA_UNLIMITED].[Pago]', 'U') is not null
drop table CAIA_UNLIMITED.Pago

if OBJECT_ID('[CAIA_UNLIMITED].[Consumible]', 'U') is not null
drop table CAIA_UNLIMITED.Consumible

create table CAIA_UNLIMITED.Hotel(
	hote_id numeric(18,0) identity(0,1) not null,
	hote_nombre nvarchar(255),
	hote_cant_estrellas numeric(18,0) not null,
	hote_recarga_estrella numeric(18,0) not null,
	hote_habilitado bit not null,
	hote_fecha_creacion datetime,
	hote_mail nvarchar(255),
	hote_fecha_inicio datetime,
	hote_fecha_fin datetime,
	dire_id numeric(18,0) not null
)

create table CAIA_UNLIMITED.Regimen(
	regi_codigo numeric(18,0) identity(0,1) not null,
	regi_descripcion nvarchar(255) not null,
	regi_precio_base numeric(18,2) not null,
	regi_estado bit not null
)

create table CAIA_UNLIMITED.Usuario(
	usur_username nvarchar(255) not null,
	usur_password nvarchar(255) not null,
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

create table CAIA_UNLIMITED.Direccion(
	dire_id numeric(18,0) identity(0,1) not null,
	dire_telefono nvarchar(20),
	dire_dom_calle nvarchar(255) not null,
	dire_nro_calle numeric(18,0) not null,
	dire_piso numeric(18,0),
	dire_dpto nvarchar(50),
	dire_ciudad nvarchar(255)
)

create table CAIA_UNLIMITED.Huesped(
	hues_mail nvarchar(255) not null,
	hues_nombre nvarchar(255) not null,
	hues_apellido nvarchar(255) not null,
	hues_documento numeric(18,0) not null,
	hues_nacionalidad nvarchar(255) not null,
	hues_nacimiento datetime not null,
	hues_documento_tipo nvarchar(3) not null,
	hues_habilitado bit not null,
	dire_id numeric(18,0) not null
)

create table CAIA_UNLIMITED.Reserva(
	rese_codigo numeric(18,0) not null,
	rese_fecha_realizacion datetime not null,
	rese_fecha_desde datetime not null,
	rese_cantidad_noches numeric(18,0) not null,
	esre_codigo numeric(18,0),
	hote_id numeric(18,0) not null,
	habi_numero numeric(18,0) not null
)

create table CAIA_UNLIMITED.Estado_Reserva(
	esre_codigo numeric(18,0) not null,
	esre_detalle nvarchar(255) not null
)

create table CAIA_UNLIMITED.Pago(
	pago_codigo numeric(18,0) not null,
	pago_monto numeric(18,2) not null,
	pago_nombre nvarchar(255),
	pago_apellido nvarchar(255),
	pago_nro_tarjeta nvarchar(20),
	pago_codigo_seguridad nvarchar(4),
	pago_banco nvarchar(20),
	pago_fecha_vencimiento smalldatetime
)

create table CAIA_UNLIMITED.Rol(
	rol_codigo numeric(18,0) identity(0,1) not null,
	rol_nombre nvarchar(255) not null,
	rol_estado bit not null
)

create table CAIA_UNLIMITED.Funcionalidad(
	func_codigo numeric(18,0) identity(0,1) not null,
	func_detalle nvarchar(255) not null
)

create table CAIA_UNLIMITED.Habitacion(
	habi_numero numeric(18,0) not null,
	habi_piso numeric(18,0) not null,
	habi_frente nvarchar(50) not null,
	hote_id numeric(18,0) not null,
	thab_codigo numeric(18,0) not null
)

create table CAIA_UNLIMITED.Tipo_Habitacion(
	thab_codigo numeric(18,0) not null,
	thab_descripcion nvarchar(255) not null,
	thab_porcentual numeric(18,2) not null
)

create table CAIA_UNLIMITED.Estadia(
	esta_codigo numeric(18,0) identity(0,1) not null,
	esta_fecha_inicio datetime not null,
	esta_cantidad_noches numeric(18,0) not null,
	rese_codigo numeric(18,0) not null
)

create table CAIA_UNLIMITED.Factura(
	fact_nro numeric(18,0) not null,
	fact_fecha datetime not null,
	fact_total numeric(18,2) not null,
	esta_codigo numeric(18,0) not null,
	pago_codigo numeric(18,0) null,
	hues_mail nvarchar(255) null
)

create table CAIA_UNLIMITED.Item_Factura(
	item_cantidad numeric(18,0) not null,
	item_monto numeric(18,2) not null,
	fact_nro numeric(18,0) not null,
	cons_codigo numeric(18,0) not null
)

create table CAIA_UNLIMITED.Consumible(
	cons_codigo numeric(18,0) not null,
	cons_descripcion nvarchar(255) not null,
	cons_precio numeric(18,2) not null
)

create table CAIA_UNLIMITED.Rol_X_Usuario(
	rol_usur_codigo numeric(18,0) not null,
	rol_usur_username nvarchar(255) not null
)

create table CAIA_UNLIMITED.Funcionalidad_X_Rol(
	func_rol_codigo_rol numeric(18,0) not null,
	func_rol_codigo_func numeric(18,0) not null
)

create table CAIA_UNLIMITED.Regimen_X_Hotel(
	regi_hote_codigo numeric(18,0) not null,
	regi_hote_id numeric(18,0) not null
)

create table CAIA_UNLIMITED.Usuario_X_Hotel(
	usur_hote_username nvarchar(255) not null,
	usur_hote_id numeric(18,0) not null
)

create table CAIA_UNLIMITED.Reserva_X_Huesped(
	rese_hues_codigo numeric(18,0) not null,
	rese_hues_mail nvarchar(255) not null
)

create table CAIA_UNLIMITED.Consumible_X_Estadia(
	cons_esta_codigo_cons numeric(18,0) not null,
	cons_esta_codigo_esta numeric(18,0) not null
)

alter table CAIA_UNLIMITED.Direccion
	add constraint PK_Direccion primary key (dire_id)

alter table CAIA_UNLIMITED.Hotel
	add constraint PK_Hotel primary key (hote_id),
	constraint FK_Hotel_Direccion foreign key (dire_id)
	references CAIA_UNLIMITED.Direccion (dire_id)

alter table CAIA_UNLIMITED.Regimen 
	add constraint PK_Regimen primary key (regi_codigo)

alter table CAIA_UNLIMITED.Tipo_Habitacion
	add constraint PK_Tipo_Habitacion primary key (thab_codigo)

alter table CAIA_UNLIMITED.Habitacion
	add constraint PK_Habitacion primary key (hote_id, habi_numero),
	constraint FK_Habitacion_Hotel foreign key (hote_id)
	references CAIA_UNLIMITED.Hotel (hote_id),
	constraint FK_Habitacioin_Tipo foreign key (thab_codigo)
	references CAIA_UNLIMITED.Tipo_Habitacion (thab_codigo)

alter table CAIA_UNLIMITED.Rol
	add constraint PK_Rol primary key (rol_codigo)

alter table CAIA_UNLIMITED.Funcionalidad
	add constraint PK_Funcionalidad primary key (func_codigo)

alter table CAIA_UNLIMITED.Usuario 
	add constraint PK_Usuario primary key (usur_username),
	constraint FK_Usuario_Direccion foreign key (dire_id)
	references CAIA_UNLIMITED.Direccion (dire_id)

alter table CAIA_UNLIMITED.Huesped
	add constraint PK_Huesped primary key (hues_mail),
	constraint FK_Huespedo_Direccion foreign key (dire_id)
	references CAIA_UNLIMITED.Direccion (dire_id)

alter table CAIA_UNLIMITED.Estado_Reserva
	add constraint PK_Estado_Reserva primary key (esre_codigo)

alter table CAIA_UNLIMITED.Reserva
	add constraint PK_Reserva primary key (rese_codigo),
	constraint FK_Reserva_Estado foreign key (esre_codigo)
	references CAIA_UNLIMITED.Estado_Reserva (esre_codigo),
	constraint FK_Reserva_Habitacion foreign key (hote_id, habi_numero)
	references CAIA_UNLIMITED.Habitacion (hote_id, habi_numero)

alter table CAIA_UNLIMITED.Estadia
	add constraint PK_Estadia primary key (esta_codigo),
	constraint FK_Estadia_Reserva foreign key (rese_codigo)
	references CAIA_UNLIMITED.Reserva (rese_codigo)

alter table CAIA_UNLIMITED.Consumible
	add constraint PK_Consumible primary key (cons_codigo)

alter table CAIA_UNLIMITED.Pago
	add constraint PK_Pago primary key (pago_codigo)

alter table CAIA_UNLIMITED.Factura
	add constraint PK_Factura primary key (fact_nro),
	constraint FK_Factura_Estadia foreign key (esta_codigo)
	references CAIA_UNLIMITED.Estadia (esta_codigo),
	constraint FK_Factura_Pago foreign key (pago_codigo)
	references CAIA_UNLIMITED.Pago (pago_codigo),
	constraint FK_Factura_Huesped foreign key (hues_mail)
	references CAIA_UNLIMITED.Huesped (hues_mail)

alter table CAIA_UNLIMITED.Item_Factura
	add constraint FK_Item_Factura_Factura foreign key (fact_nro)
	references CAIA_UNLIMITED.Factura (fact_nro),
	constraint FK_Item_Factuta_Consumible foreign key (cons_codigo)
	references CAIA_UNLIMITED.Consumible (cons_codigo)

alter table CAIA_UNLIMITED.Rol_X_Usuario
	add constraint PK_Rol_X_Usuario primary key (rol_usur_codigo, rol_usur_username),
	constraint FK_RolUsuario_Rol foreign key (rol_usur_codigo)
	references CAIA_UNLIMITED.Rol (rol_codigo),
	constraint FK_RolUsuario_Usur foreign key (rol_usur_username)
	references CAIA_UNLIMITED.Usuario (usur_username)

alter table CAIA_UNLIMITED.Funcionalidad_X_Rol
	add constraint PK_Funcionalidad_X_Rol primary key (func_rol_codigo_rol, func_rol_codigo_func),
	constraint FK_FuncionalidadRol_Rol foreign key (func_rol_codigo_rol)
	references CAIA_UNLIMITED.Rol (rol_codigo),
	constraint FK_FuncionalidadRol_Func foreign key (func_rol_codigo_func)
	references CAIA_UNLIMITED.Funcionalidad (func_codigo)

alter table CAIA_UNLIMITED.Regimen_X_Hotel
	add constraint PK_Regimen_X_Hotel primary key (regi_hote_codigo, regi_hote_id),
	constraint FK_RegimenHotel_Regi foreign key (regi_hote_codigo)
	references CAIA_UNLIMITED.Regimen (regi_codigo),
	constraint FK_RegimenHotel_Hote foreign key (regi_hote_id)
	references CAIA_UNLIMITED.Hotel (hote_id)

alter table CAIA_UNLIMITED.Usuario_X_Hotel
	add constraint PK_Usuario_X_Hotel primary key (usur_hote_username, usur_hote_id),
	constraint FK_UsuarioHotel_Usur foreign key (usur_hote_username)
	references CAIA_UNLIMITED.Usuario (usur_username),
	constraint FK_UsuarioHotel_Hote foreign key (usur_hote_id)
	references CAIA_UNLIMITED.Hotel (hote_id)

alter table CAIA_UNLIMITED.Reserva_X_Huesped
	add constraint PK_Reserva_X_Huesped primary key (rese_hues_codigo, rese_hues_mail),
	constraint FK_ReservaHuesped_Rese foreign key (rese_hues_codigo)
	references CAIA_UNLIMITED.Reserva (rese_codigo),
	constraint FK_ReservaHuesped_Hues foreign key (rese_hues_mail)
	references CAIA_UNLIMITED.Huesped (hues_mail)

alter table CAIA_UNLIMITED.Consumible_X_Estadia
	add constraint PK_Consumible_X_Estadia primary key (cons_esta_codigo_cons, cons_esta_codigo_esta),
	constraint FK_ConsumibleEstadia_Cons foreign key (cons_esta_codigo_cons)
	references CAIA_UNLIMITED.Consumible (cons_codigo),
	constraint FK_ConsumibleEstadia_Esta foreign key (cons_esta_codigo_esta)
	references CAIA_UNLIMITED.Estadia (esta_codigo)

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
insert into CAIA_UNLIMITED.Hotel (hote_cant_estrellas, hote_recarga_estrella, hote_habilitado, dire_id)
select distinct Hotel_CantEstrella, Hotel_Recarga_Estrella, 1, dire_id
from gd_esquema.Maestra join CAIA_UNLIMITED.Direccion on (Hotel_Calle = dire_dom_calle and
															Hotel_Ciudad = dire_ciudad and
															Hotel_Nro_Calle = dire_nro_calle)

--Habitacion
insert into CAIA_UNLIMITED.Habitacion (habi_numero, habi_piso, habi_frente, hote_id, thab_codigo)
select distinct Habitacion_Numero, Habitacion_Piso, Habitacion_Frente, hote_id, thab_codigo
from gd_esquema.Maestra join CAIA_UNLIMITED.Tipo_Habitacion on (thab_codigo = Habitacion_Tipo_Codigo and
																thab_descripcion = Habitacion_Tipo_Descripcion and
																thab_porcentual = Habitacion_Tipo_Porcentual)
						join CAIA_UNLIMITED.Direccion D on (dire_ciudad = Hotel_Ciudad and
															dire_dom_calle = Hotel_Calle and
															dire_nro_calle = Hotel_Nro_Calle)
						join CAIA_UNLIMITED.Hotel H on (H.dire_id = D.dire_id) 

--Reserva
insert into CAIA_UNLIMITED.Reserva (rese_codigo, rese_fecha_realizacion, rese_fecha_desde, rese_cantidad_noches, hote_id, habi_numero)
select distinct Reserva_Codigo, Reserva_Fecha_Inicio, Reserva_Fecha_Inicio, Reserva_Cant_Noches, H.hote_id, habi_numero
from gd_esquema.Maestra join CAIA_UNLIMITED.Direccion D on (Hotel_Calle = dire_dom_calle and
															Hotel_Nro_Calle = dire_nro_calle and
															Hotel_Ciudad = dire_ciudad)
						join CAIA_UNLIMITED.Hotel H on (H.dire_id = D.dire_id)
						join CAIA_UNLIMITED.Habitacion R on (H.hote_id  = R.hote_id and
															Habitacion_Numero = habi_numero)

--Estadia
insert into CAIA_UNLIMITED.Estadia (esta_fecha_inicio, esta_cantidad_noches, rese_codigo)
select distinct Estadia_Fecha_Inicio, Estadia_Cant_Noches, rese_codigo
from gd_esquema.Maestra join CAIA_UNLIMITED.Reserva on (Reserva_Codigo = rese_codigo)
where Estadia_Cant_Noches is not null and Estadia_Cant_Noches is not null

--Factura
insert into CAIA_UNLIMITED.Factura (fact_nro, fact_fecha, fact_total, esta_codigo)
select distinct Factura_Nro, Factura_Fecha, Factura_Total, esta_codigo
from gd_esquema.Maestra join CAIA_UNLIMITED.Reserva R on (Reserva_Codigo = rese_codigo)
						join CAIA_UNLIMITED.Estadia E on (R.rese_codigo = E.rese_codigo)
where Factura_Nro is not null

--Item_Factura
insert into CAIA_UNLIMITED.Item_Factura (item_cantidad, item_monto, fact_nro, cons_codigo)
select distinct Item_Factura_Cantidad, Item_Factura_Monto, fact_nro, cons_codigo
from gd_esquema.Maestra join CAIA_UNLIMITED.Factura on (Factura_Nro = fact_nro)
						join CAIA_UNLIMITED.Consumible on (cons_codigo = Consumible_Codigo)

--Huesped (Revisar campos repetidos 
--insert into CAIA_UNLIMITED.Huesped (hues_mail, hues_nombre, hues_apellido, hues_documento, hues_documento_tipo, hues_nacimiento, hues_nacionalidad, hues_habilitado, dire_id)
--select distinct Cliente_Mail, Cliente_Nombre, Cliente_Apellido, Cliente_Pasaporte_Nro, 'PAS', Cliente_Fecha_Nac, Cliente_Nacionalidad, 1, dire_id
--from gd_esquema.Maestra join CAIA_UNLIMITED.Direccion on (dire_dom_calle = Cliente_Dom_Calle and
--															dire_nro_calle = Cliente_Nro_Calle and
--															dire_piso = Cliente_Piso and
--															dire_dpto = Cliente_Depto)
--where Cliente_Mail not in (select hues_mail from CAIA_UNLIMITED.Huesped)

insert into CAIA_UNLIMITED.Regimen_X_Hotel(regi_hote_codigo, regi_hote_id)
select distinct regi_codigo, hote_id
from CAIA_UNLIMITED.Regimen join gd_esquema.Maestra on (regi_descripcion = Regimen_Descripcion and
														regi_precio_base = Regimen_Precio)
							join CAIA_UNLIMITED.Direccion D on (Hotel_Calle = dire_dom_calle and
																Hotel_Ciudad = dire_ciudad and
																Hotel_Nro_Calle = dire_nro_calle)
							join CAIA_UNLIMITED.Hotel H on (H.dire_id = D.dire_id)

insert into CAIA_UNLIMITED.Consumible_X_Estadia (cons_esta_codigo_cons, cons_esta_codigo_esta)
select distinct cons_codigo, esta_codigo
from CAIA_UNLIMITED.Consumible join gd_esquema.Maestra on (Consumible_Codigo = cons_codigo)
								join CAIA_UNLIMITED.Reserva R on (Reserva_Codigo = rese_codigo)
								join CAIA_UNLIMITED.Estadia E on (E.rese_codigo = R.rese_codigo)
where cons_codigo is not null

insert into CAIA_UNLIMITED.Usuario (usur_username, usur_password, usur_habilitado, usur_intentos) values('admin', HASHBYTES('SHA2_256', 'w23e'), 1, 0)

insert into CAIA_UNLIMITED.Rol (rol_nombre, rol_estado) values('Administrador General', 1)

insert into CAIA_UNLIMITED.Rol_X_Usuario (rol_usur_username, rol_usur_codigo) values('admin', 0)

insert into CAIA_UNLIMITED.Funcionalidad (func_detalle) values('ABM_ROL'), ('ABM_USUARIO'), ('ABM_CLIENTE'), ('ABM_HOTEL'), ('ABM_HABITACION'), ('ABM_ESTADIA'), ('RESERVA'), ('CANCELAR_RESERVA'), ('ESTADIA'), ('CONSUMIBLES'), ('FACTURAR'), ('LISTADO_ESTADISTICO') 

insert into CAIA_UNLIMITED.Funcionalidad_X_Rol (func_rol_codigo_rol, func_rol_codigo_func) 
values (0, 0), (0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7), (0, 8), (0, 9), (0, 10), (0, 11)