CREATE DATABASE Usuarios;

-- Conéctate a la base de datos Usuarios
\c Usuarios;

-- Crea tablas o inserta datos iniciales
CREATE TABLE Departamento (
    id_departamento SERIAL PRIMARY KEY,
    nombre VARCHAR(20) NOT NULL,
    descripcion VARCHAR(100)
);

CREATE TABLE Usuario (
    id_usuario SERIAL PRIMARY KEY,
    nombre VARCHAR(20) NOT NULL,
    apellido VARCHAR(20) NOT NULL,
    email VARCHAR(20) NOT NULL,
    clave VARCHAR(16) NOT NULL,
    activo BOOLEAN NOT NULL,
    tipo_usuario VARCHAR(20) CHECK (tipo_usuario IN ('Operador', 'Conductor', 'Proveedor', 'Administrador')),
    departamento INTEGER REFERENCES Departamento(id_departamento)
);
