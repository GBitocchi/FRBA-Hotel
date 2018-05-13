USE [GD1C2018]

SET QUOTED_IDENTIFIER OFF

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'CAIA_UNLIMITED')
BEGIN
EXEC ('CREATE SCHEMA [CAIA_UNLIMITED] AUTHORIZATION [gd]')
END

#Provisorio

if OBJECT_ID('[CAIA_UNLIMITED].[Hotel]', 'U') is not null
drop table CAIA_UNLIMITED.Hotel

if OBJECT_ID('[CAIA_UNLIMITED].[Regimen]', 'U') is not null
drop table CAIA_UNLIMITED.Regimen

if OBJECT_ID('[CAIA_UNLIMITED].[Usuario]', 'U') is not null
drop table CAIA_UNLIMITED.Usuario

if OBJECT_ID('[CAIA_UNLIMITED].[Rol_X_Usuario]', 'U') is not null
drop table CAIA_UNLIMITED.Rol_X_Usuario

if OBJECT_ID('[CAIA_UNLIMITED].[Rol]', 'U') is not null
drop table CAIA_UNLIMITED.Rol

if OBJECT_ID('[CAIA_UNLIMITED].[Funcionalidad_X_Rol]', 'U') is not null
drop table CAIA_UNLIMITED.Funcionalidad_X_Rol

if OBJECT_ID('[CAIA_UNLIMITED].[Funcionalidad]', 'U') is not null
drop table CAIA_UNLIMITED.Funcionalidad

if OBJECT_ID('[CAIA_UNLIMITED].[Regimen_X_Hotel]', 'U') is not null
drop table CAIA_UNLIMITED.Regimen_X_Hotel

if OBJECT_ID('[CAIA_UNLIMITED].[Direccion]', 'U') is not null
drop table CAIA_UNLIMITED.Direccion

if OBJECT_ID('[CAIA_UNLIMITED].[Habitacion]', 'U') is not null
drop table CAIA_UNLIMITED.Habitacion

if OBJECT_ID('[CAIA_UNLIMITED].[Tipo_Habitacion]', 'U') is not null
drop table CAIA_UNLIMITED.Tipo_Habitacion

if OBJECT_ID('[CAIA_UNLIMITED].[Usuario_X_Hotel]', 'U') is not null
drop table CAIA_UNLIMITED.Usuario_X_Hotel

if OBJECT_ID('[CAIA_UNLIMITED].[Huesped]', 'U') is not null
drop table CAIA_UNLIMITED.Huesped

if OBJECT_ID('[CAIA_UNLIMITED].[Reserva_X_Huesped]', 'U') is not null
drop table CAIA_UNLIMITED.Reserva_X_Huesped

if OBJECT_ID('[CAIA_UNLIMITED].[Reserva]', 'U') is not null
drop table CAIA_UNLIMITED.Reserva

if OBJECT_ID('[CAIA_UNLIMITED].[Estado_Reserva]', 'U') is not null
drop table CAIA_UNLIMITED.Estado_Reserva

if OBJECT_ID('[CAIA_UNLIMITED].[Estadia]', 'U') is not null
drop table CAIA_UNLIMITED.Estadia

if OBJECT_ID('[CAIA_UNLIMITED].[Factura]', 'U') is not null
drop table CAIA_UNLIMITED.Factura

if OBJECT_ID('[CAIA_UNLIMITED].[Pago]', 'U') is not null
drop table CAIA_UNLIMITED.Pago

if OBJECT_ID('[CAIA_UNLIMITED].[Item_Factura]', 'U') is not null
drop table CAIA_UNLIMITED.Item_Factura

if OBJECT_ID('[CAIA_UNLIMITED].[Consumible_X_Estadia]', 'U') is not null
drop table CAIA_UNLIMITED.Consumible_X_Estadia

if OBJECT_ID('[CAIA_UNLIMITED].[Consumible]', 'U') is not null
drop table CAIA_UNLIMITED.Consumible

create table CAIA_UNLIMITED.Hotel(
	hote_id numeric(18,0) not null,
	hote_cant_estrellas numeric(18,0) not null,
	hote_recarga_estrella numeric(18,0) not null,
	hote_habilitado bit not null,
	hote_fecha_creacion datetime,
	hote_mail nvarchar(255) not null,
	hote_fecha_inicio datetime,
	hote_fecha_fin datetime
)

create table CAIA_UNLIMITED.Regimen(
	regi_codigo numeric(18,0) not null,
	regi_descripcion nvarchar(255) not null,
	regi_precio_base numeric(18,2) not null,
	regi_estado bit not null
)

create table CAIA_UNLIMITED.Usuario(
	usur_username nvarchar(255) not null,
	usur_password nvarchar(255) not null,
	usur_nombre nvarchar(255) not null,
	usur_apellido nvarchar(255) not null,
	usur_documento_tipo nvarchar(3) not null,
	usur_documento numeric(18,0) not null,
	usur_mail nvarchar(255),
	usur_nacimiento datetime
)

create table CAIA_UNLIMITED.Direccion(
	dire_id numeric(18,0) not null,
	dire_telefono nvarchar(20) not null,
	dire_dom_calle nvarchar(255) not null,
	dire_nro_calle numeric(18,0) not null,
	dire_piso numeric(18,0),
	dire_dpto nvarchar(50),
	dire_ciudad nvarchar(255) not null
)

create table CAIA_UNLIMITED.Huesped(
	hues_mail nvarchar(255) not null,
	hues_nombre nvarchar(255) not null,
	hues_apellido nvarchar(255) not null,
	hues_documento numeric(18,0) not null,
	hues_nacionalidad nvarchar(255) not null,
	hues_nacimiento datetime not null,
	hues_documento_tipo nvarchar(3) not null,
	hues_habilitado bit not null
)

create table CAIA_UNLIMITED.Reserva(
	rese_codigo numeric(18,0) not null,
	rese_fecha_realizacion datetime not null,
	rese_fecha_desde datetime not null,
	rese_cantidad_noches numeric(18,0) not null
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
	rol_codigo numeric(18,2) not null,
	rol_nombre nvarchar(255) not null,
	rol_estado bit not null
)

create table CAIA_UNLIMITED.Funcionalidad(
	func_codigo numeric(18,0) not null,
	func_detalle nvarchar(255) not null
)

create table CAIA_UNLIMITED.Habitacion(
	habi_numero numeric(18,0) not null,
	habi_piso numeric(18,0) not null,
	habi_frente nvarchar(50) not null,
	habi_tipo_descripcion nvarchar(255) not null,
	habi_tipo_porcentual numeric(18,2) not null
)

create table CAIA_UNLIMITED.Tipo_Habitacion(
	thab_codigo numeric(18,0) not null,
	thab_detalle nvarchar(255) not null
)

create table CAIA_UNLIMITED.Estadia(
	esta_codigo numeric(18,0) not null,
	esta_fecha_inicio datetime not null,
	esta_cantidad_noches numeric(18,0) not null
)

create table CAIA_UNLIMITED.Factura(
	fact_nro numeric(18,0) not null,
	fact_fecha datetime not null,
	fact_total numeric(18,2) not null
)

create table CAIA_UNLIMITED.Item_Factura(
	item_cantidad numeric(18,0) not null,
	item_monto numeric(18,2) not null
)

create table CAIA_UNLIMITED.Consumible(
	cons_codig numeric(18,0) not null,
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

