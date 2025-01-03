CREATE DATABASE Proveedores;

-- Conéctate a la base de datos Usuarios
\c Proveedores;

create table "Proveedor"(
	"Id" UUID primary key,
	"Nombre" varchar(20) not null,
	"Tipo" varchar(20) check (tipo in ('Interno','Externo')),
	"Direccion" varchar(50) not null,
	"Email" varchar(30) not null,
	"Activo" boolean
);

create table "Vehiculo"(
	"Id" UUID primary key,
	"Placa" varchar(10) not null,
	"Modelo" varchar(15) not null,
	"Capacidad" numeric not null,
	"Activo" boolean,
	"IdProveedor" UUID references "Proveedor"("Id")
);

create table "Conductor" (
	"Id" UUID primary key,
	"Nombre" varchar(20) not null,
	"Apellido" varchar(20) not null,
	"Telefono" numeric not null,
	"Licencia" varchar(20) not null,
	"Activo" boolean,	
	"ProveedorId" UUID references "Proveedor"("Id")
);