
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/05/2021 20:20:18
-- Generated from EDMX file: C:\Users\User\Desktop\GoogleMap\GoogleMap\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TestDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[google_map]', 'U') IS NOT NULL
    DROP TABLE [dbo].[google_map];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'google_map'
CREATE TABLE [dbo].[google_map] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Rating] int  NULL,
    [Address] nvarchar(50)  NULL,
    [Lat] float  NOT NULL,
    [Long] float  NULL,
    [Zoom] int  NULL,
    [Phone] int  NULL,
    [PhoneNumber] int NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'google_map'
ALTER TABLE [dbo].[google_map]
ADD CONSTRAINT [PK_google_map]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------