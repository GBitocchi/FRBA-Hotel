create table Hotel (hote_cant_estrella int not null, 
					hote_recarga_estrella int not null,
					hote_habilitado bit not null,
					hote_fecha_creacion smalldatetime not null,
					hote_mail nvarchar(50) not null,
					hote_fecha_inicio datetime,
					hote_fecha_fin datetime, 
					hote_id numeric(18,0) not null primary key,
                    dire_id numeric(18,0) not null foreign key)

create table Habitacion (habi_numero numeric(18,0) not null primary key,
						habi_piso numeric(18,0) not null,
						habi_frente nvarchar(50) not null,
						habi_tipo_descripcion nvarchar(255) not null,
						habi_porcentual numeric(18,2) not null,
						thab_codigo numeric(18,0) not null,
						hote_id numeric(18,0) not null)

create table Tipo_Habitacion (thab_codigo numeric(18,0) not null primary key,
								thab_detalle nvarchar(255) not null)

create table Factura (fact_nro numeric(18,0) not null primary key,
						fact_fecha datetime not null,
						fact_total numeric(18,2) not null,
						pago_codigo numeric(18,0),
						esta_codigo numeric(18,0))

create table Pago (pago_codigo numeric(18,0) not null primary key,
                    pago_monto numeric(18,2) not null,
                    pago_nombre nvarchar(255),
                    pago_apellido nvarchar(255),
                    pago_nro_tarjeta nvarchar(20),
                    pago_codigo_seguridad nvarchar(4),
                    pago_banco nvarchar(20),
                    pago_fecha_vencimiento smalldatetime)

create table Item_Factura (item_cantidad numeric(18,0) not null,
                            item_monto numeric(18,2) not null,
                            fact_nro numeric(18,0) not null foreign key,
                            cons_codigo numeric(18,0) not null foreign key)

create table Consumible (cons_codigo numeric(18,0) not null primary key,
                            cons_descripcion nvarchar(255) not null,
                            cons_precio numeric(18,2) not null)

create table Direccion (dire_telefono nvarchar(20) not null,
                        dire_dom_calle nvarchar(255) not null,
                        dire_nro_calle numeric(18,0) not null,
                        dire_piso numeric(18,0),
                        dire_dpto nvarchar(50),
                        dire_ciudad nvarchar(255),
                        dire_id numeric(18,0) not null primary key)

create table Estadia (esta_fecha_inicio datetime not null,
                       esta_cantidad_noches numeric(18,0) not null,
                       esta_codigo numeric(18,0) not null primary key,
                       rese_codigo numeric(18,0) not null foreign key)

create table Huesped (hues_nombre nvarchar(255) not null,
                        hues_apellido nvarchar(255) not null,
                        hues_documento numeric(18,0) not null,
                        hues_mail nvarchar(255) not null primary key,
                        hues_nacionalidad nvarchar(255) not null,
                        hues_nacimiento datetime not null,
                        hues_documento_tipo nvarchar(3) not null,
                        hues_habilitado bit not null,
                        dire_id numeric(18,0) not null foreign key)

create table Reserva_X_Huesped (hues_mail nvarchar(255) not null foreign key,
                                rese_codigo numeric(18,0) not null foreign key)

create table Estado_Reserva (esre_codigo numeric(18,0) not null primary key,
                                esre_detalle nvarchar(255) not null)

create table Consumible_X_Estadia (esta_codigo numeric(18,0) not null foreign key,
                                    cons_codigo numeric(18,0) not null foreign key)

create table Regimen_X_Hotel (hote_id numeric(18,0) not null foreign key,
                                regi_codigo numeric(18,0) not null foreign key)

create table Regimen (regi_codigo numeric(18,0) not null primary key,
                        regi_descripcion nvarchar(255) not null,
                        regi_precio_base numeric(18,2) not null,
                        regi_estado bit not null)

create table Rol_X_Usuario (rol_codigo numeric(18,0) not null foreign key,
                            usur_username nvarchar(20) not null foreign key)

create table Rol (rol_nombre nvarchar(255) not null,
                    rol_estado bit not null,
                    rol_codigo numeric(18,0) not null primary key)

create table Funcionalidad_X_Rol (rol_codigo numeric(18,0) not null foreign key,
                                    func_codigo numeric(18,0) not null foreign key)

create table Funcionalidad (func_detalle nvarchar(255) not null,
                            func_codigo numeric(18,0) not null primary key)

create table Usuario_X_Hotel (usur_username nvarchar(20) not null foreign key,
                                hote_id numeric(18,0) not null foreign key)

create table Reserva (rese_fecha_realizacion datetime not null,
                        rese_fecha_desde datetime not null,
                        rese_codigo numeric(18,0) not null primary key,
                        rese_cantidad_noches numeric(18,0) not null,
                        esre_codigo numeric(18,0) not null foreign key,
                        habi_numero numeric(18,0) not null foreign key)

create table Usuario (usur_username nvarchar(20) not null primary key,
                        usur_password nvarchar(20) not null,
                        usur_nombre nvarchar(20) not null,
                        usur_documento numeric(18,0) not null,
                        usur_mail nvarchar(50) not null,
                        usur_nacimiento datetime not null,
                        usur_apellido nvarchar(20) not null,
                        dire_id numeric(18,0) not null foreign key)