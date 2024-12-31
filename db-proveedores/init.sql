CREATE DATABASE Usuarios;

-- Conéctate a la base de datos Usuarios
\c Usuarios;

create table Proveedor(
	id_proveedor numeric primary key,
	nombre varchar(20) not null,
	tipo varchar(20) check (tipo in ('Interno','Externo')),
	direccion varchar(50) not null,
	email varchar(30) not null,
	activo boolean
);

create table vehiculo(
	id_vehiculo numeric primary key,
	placa varchar(10) not null,
	modelo varchar(15) not null,
	capacidad numeric not null,
	activo boolean,
	id_proveedor numeric references proveedor(id_proveedor)
);

create table Conductor (
	id_conductor numeric primary key,
	nombre varchar(20) not null,
	telefono numeric not null,
	licencia numeric not null,
	activo boolean	
);