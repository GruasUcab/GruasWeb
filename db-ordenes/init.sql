CREATE DATABASE Usuarios;

-- Conéctate a la base de datos Usuarios
\c Usuarios;

create table poliza(
	id_poliza numeric primary key,
	tipo_cobertura varchar(100) not null,
	kilometros_incluidos numeric not null
);

create table Asegurado (
	id_asegurado numeric primary key,
	nombre varchar(20) not null,
	telefono numeric not null,
	email varchar(30) not null,
	id_poliza numeric references poliza(id_poliza)
);

create table Orden_servicio (
	id_orden numeric primary key,
	fecha_creacion date not null,
	estado varchar(20) check (estado in ('Pendiente', 'Asignada','Completada','Cancelada')),
	ubicacion_incidente varchar(40) not null,
	ubicacion_destino varchar(40) not null,
	kilometros_recorridos numeric not null,
	costo_total numeric not null,
	id_conductor numeric,
	id_proveedor numeric,
	id_vehiculo numeric	
);

create table Costo_adicional(
	id_costo numeric primary key,
	nombre varchar(20) not null,
	monto numeric not null,
	id_orden numeric references Orden_servicio(id_orden)
);

