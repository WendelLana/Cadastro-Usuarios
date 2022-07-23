Avaliação disciplina Programação Avançada em C#
Wendel Fernandes de Lana

Query para criação do banco de dados:
CREATE DATABASE [wendel-d3-avaliacao];

USE [wendel-d3-avaliacao];

CREATE TABLE UserLogin (
IdUser int IDENTITY(1,1) PRIMARY KEY,
Name varchar(50) NOT NULL,
Email varchar(50) NOT NULL,
Password varchar(50) NOT NULL
);

INSERT INTO UserLogin (Name, Email, Password) VALUES ('Admin', 'admin@email.com', 'admin123');
