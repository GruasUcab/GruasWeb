CREATE DATABASE Ordenes;

-- Conéctate a la base de datos Usuarios
\c Ordenes;

create table "Poliza"(
	"Id" UUID primary key,
	"TipoCobertura" varchar(100) not null,
	"KilometrosIncluidos" numeric not null
);

create table "Asegurado" (
	"Id" UUID primary key,
	"Nombre" varchar(20) not null,
	"Telefono" numeric not null,
	"Email" varchar(30) not null,
	"PolizaId" UUID references "Poliza"("Id")
);

create table "OrdenDeServicios" (
	"Id" UUID primary key,
	"FechaCreacion" date not null,
	"Estado" varchar(20) check ("Estado" in ('Pendiente', 'Asignada','Completada','Cancelada')),
	"UbicacionIncidente" varchar(40) not null,
	"UbicacionDestino" varchar(40) not null,
	"KilometrosRecorridos" numeric not null,
	"CostoTotal" numeric not null,
	"ConductorId" UUID,
	"ProveedorId" UUID,
	"VehiculoId" UUID	
);

create table "CostoAdicional"(
	"Id" numeric primary key,
	"Nombre" varchar(20) not null,
	"Monto" numeric not null,
	"OrdenId" UUID references "OrdenDeServicios"("Id")
);


