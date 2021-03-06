
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/13/2015 12:02:07
-- Generated from EDMX file: C:\Users\Ramona\Desktop\PacmanServer\PacmanREST-master\PacmanREST\Models\PacmanModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [pacmanAndroidNew_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FencePacman_carer_db]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fences] DROP CONSTRAINT [FK_FencePacman_carer_db];
GO
IF OBJECT_ID(N'[dbo].[FK_FencePacman_patient_db]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fences] DROP CONSTRAINT [FK_FencePacman_patient_db];
GO
IF OBJECT_ID(N'[dbo].[FK_FenceFencePoint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FencePoints] DROP CONSTRAINT [FK_FenceFencePoint];
GO
IF OBJECT_ID(N'[dbo].[FK_Pacman_location_dbPacman_patient_db]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pacman_location_db] DROP CONSTRAINT [FK_Pacman_location_dbPacman_patient_db];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Pacman_carer_db]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pacman_carer_db];
GO
IF OBJECT_ID(N'[dbo].[Pacman_carer_patient_db]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pacman_carer_patient_db];
GO
IF OBJECT_ID(N'[dbo].[Pacman_fence_db]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pacman_fence_db];
GO
IF OBJECT_ID(N'[dbo].[Pacman_location_db]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pacman_location_db];
GO
IF OBJECT_ID(N'[dbo].[Pacman_patient_db]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pacman_patient_db];
GO
IF OBJECT_ID(N'[dbo].[Fences]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fences];
GO
IF OBJECT_ID(N'[dbo].[FencePoints]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FencePoints];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Pacman_carer_db'
CREATE TABLE [dbo].[Pacman_carer_db] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [phone] int  NOT NULL,
    [email] nvarchar(max)  NULL,
    [address] nvarchar(50)  NULL,
    [device_id] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Pacman_carer_patient_db'
CREATE TABLE [dbo].[Pacman_carer_patient_db] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [id_carer] int  NOT NULL,
    [id_patient] int  NOT NULL
);
GO

-- Creating table 'Pacman_fence_db'
CREATE TABLE [dbo].[Pacman_fence_db] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [radius] decimal(18,0)  NOT NULL,
    [description] nvarchar(50)  NULL,
    [id_carer] int  NOT NULL,
    [id_patient] int  NOT NULL,
    [Latitude] float  NOT NULL,
    [Longitude] float  NOT NULL
);
GO

-- Creating table 'Pacman_location_db'
CREATE TABLE [dbo].[Pacman_location_db] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [coordinates_x] decimal(18,0)  NOT NULL,
    [coordinates_y] decimal(18,0)  NOT NULL,
    [id_patient] int  NULL,
    [id_carer] int  NULL
);
GO

-- Creating table 'Pacman_patient_db'
CREATE TABLE [dbo].[Pacman_patient_db] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [phone] nvarchar(15)  NULL,
    [device_id] nvarchar(max)  NULL
);
GO

-- Creating table 'Fences'
CREATE TABLE [dbo].[Fences] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CarerID] int  NOT NULL,
    [PatientID] int  NOT NULL
);
GO

-- Creating table 'FencePoints'
CREATE TABLE [dbo].[FencePoints] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FenceID] int  NOT NULL,
    [Latitude] decimal(18,0)  NOT NULL,
    [Longitude] decimal(18,0)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Pacman_carer_db'
ALTER TABLE [dbo].[Pacman_carer_db]
ADD CONSTRAINT [PK_Pacman_carer_db]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Pacman_carer_patient_db'
ALTER TABLE [dbo].[Pacman_carer_patient_db]
ADD CONSTRAINT [PK_Pacman_carer_patient_db]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Pacman_fence_db'
ALTER TABLE [dbo].[Pacman_fence_db]
ADD CONSTRAINT [PK_Pacman_fence_db]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Pacman_location_db'
ALTER TABLE [dbo].[Pacman_location_db]
ADD CONSTRAINT [PK_Pacman_location_db]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Pacman_patient_db'
ALTER TABLE [dbo].[Pacman_patient_db]
ADD CONSTRAINT [PK_Pacman_patient_db]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Fences'
ALTER TABLE [dbo].[Fences]
ADD CONSTRAINT [PK_Fences]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FencePoints'
ALTER TABLE [dbo].[FencePoints]
ADD CONSTRAINT [PK_FencePoints]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CarerID] in table 'Fences'
ALTER TABLE [dbo].[Fences]
ADD CONSTRAINT [FK_FencePacman_carer_db]
    FOREIGN KEY ([CarerID])
    REFERENCES [dbo].[Pacman_carer_db]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FencePacman_carer_db'
CREATE INDEX [IX_FK_FencePacman_carer_db]
ON [dbo].[Fences]
    ([CarerID]);
GO

-- Creating foreign key on [PatientID] in table 'Fences'
ALTER TABLE [dbo].[Fences]
ADD CONSTRAINT [FK_FencePacman_patient_db]
    FOREIGN KEY ([PatientID])
    REFERENCES [dbo].[Pacman_patient_db]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FencePacman_patient_db'
CREATE INDEX [IX_FK_FencePacman_patient_db]
ON [dbo].[Fences]
    ([PatientID]);
GO

-- Creating foreign key on [FenceID] in table 'FencePoints'
ALTER TABLE [dbo].[FencePoints]
ADD CONSTRAINT [FK_FenceFencePoint]
    FOREIGN KEY ([FenceID])
    REFERENCES [dbo].[Fences]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FenceFencePoint'
CREATE INDEX [IX_FK_FenceFencePoint]
ON [dbo].[FencePoints]
    ([FenceID]);
GO

-- Creating foreign key on [id_patient] in table 'Pacman_location_db'
ALTER TABLE [dbo].[Pacman_location_db]
ADD CONSTRAINT [FK_Pacman_location_dbPacman_patient_db]
    FOREIGN KEY ([id_patient])
    REFERENCES [dbo].[Pacman_patient_db]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pacman_location_dbPacman_patient_db'
CREATE INDEX [IX_FK_Pacman_location_dbPacman_patient_db]
ON [dbo].[Pacman_location_db]
    ([id_patient]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------