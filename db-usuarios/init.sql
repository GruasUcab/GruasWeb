CREATE DATABASE Usuarios;

-- Conéctate a la base de datos Usuarios
\c Usuarios;

-- Crea tablas o inserta datos iniciales
create table "Departamento" (
	"Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	"Nombre" varchar(20) not null,
	"Descripcion" varchar(100)
);


create table Usuario (
	"Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	"Nombre" varchar(20) NOT NULL,
	"Apellido" varchar(20) NOT NULL,
	"Email" varchar(20) NOT NULL,
	"Clave" varchar(16) NOT NULL,
	"Activo" boolean NOT NULL,
	"TipoUsuario" varchar(20) check (tipo_usuario in ('Operador', 'Conductor', 'Proveedor', 'Administrador') ),
	"DepartamentoId" UUID references "Departamento"("Id")
);
