CREATE DATABASE Munix

USE Munix

CREATE TABLE Clients
(
    Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    FirstName varchar(50) NOT NULL,
    LastName varchar(50) NOT NULL,
    Email varchar(50) NOT NULL,
    Status SMALLINT NOT NULL,
    Created datetime NOT NULL,
    Updated datetime NULL,
    Deleted datetime NULL,
)


CREATE TABLE CurrencyTypes
(
    Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [Name] varchar(50) NOT NULL,
    Initials varchar(3) NOT NULL,
    [Current] decimal(18,2) NOT NULL,
    CultureInfoName varchar(10) NOT NULL,
    Created datetime NOT NULL,
    Updated datetime NULL,
    Deleted datetime NULL,
)

CREATE TABLE Wallets
(
    Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    ClientId UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES Clients(Id),
    CurrencyTypeId UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES CurrencyTypes(Id),
    [Status] smallint NOT NULL,
    Created datetime NOT NULL,
    Updated datetime NULL,
    Deleted datetime NULL,
)


