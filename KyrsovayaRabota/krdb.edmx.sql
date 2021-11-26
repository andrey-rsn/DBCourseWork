
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/23/2021 16:27:10
-- Generated from EDMX file: G:\VisualProjects\KyrsovayaWorkDB\KyrsovayaRabota\KyrsovayaRabota\DbContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [KyrsovayaRabotaDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SE_DET]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SE] DROP CONSTRAINT [FK_SE_DET];
GO
IF OBJECT_ID(N'[dbo].[FK_UZ_SE1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UZ] DROP CONSTRAINT [FK_UZ_SE1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DET]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DET];
GO
IF OBJECT_ID(N'[dbo].[SE]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SE];
GO
IF OBJECT_ID(N'[dbo].[Table_1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Table_1];
GO
IF OBJECT_ID(N'[dbo].[Table_2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Table_2];
GO
IF OBJECT_ID(N'[dbo].[Table_3]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Table_3];
GO
IF OBJECT_ID(N'[dbo].[UZ]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UZ];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DET'
CREATE TABLE [dbo].[DET] (
    [CodeDET] nvarchar(50)  NOT NULL,
    [NameDET] nvarchar(50)  NOT NULL,
    [b] float  NOT NULL,
    [y] float  NOT NULL,
    [h] float  NOT NULL,
    [da] float  NOT NULL,
    [a1] float  NOT NULL,
    [a] float  NOT NULL,
    [a_min] float  NOT NULL,
    [a_max] float  NOT NULL,
    [F_pred] float  NOT NULL,
    [n1] float  NOT NULL,
    [n2] float  NOT NULL
);
GO

-- Creating table 'SE'
CREATE TABLE [dbo].[SE] (
    [CodeSE] nvarchar(50)  NOT NULL,
    [NameSE] nvarchar(50)  NOT NULL,
    [e] float  NOT NULL,
    [del_tk] float  NOT NULL,
    [m] float  NOT NULL,
    [z1] float  NOT NULL,
    [C1] float  NOT NULL,
    [PsiP] float  NOT NULL,
    [Ip] float  NOT NULL,
    [q] float  NOT NULL,
    [z0] float  NOT NULL,
    [z2] float  NOT NULL,
    [TrType] char(10)  NOT NULL,
    [bo] float  NOT NULL,
    [br] float  NOT NULL,
    [N] float  NOT NULL,
    [F_okr] float  NOT NULL,
    [u] float  NOT NULL,
    [DET_id] varchar(50)  NOT NULL
);
GO

-- Creating table 'Table_1'
CREATE TABLE [dbo].[Table_1] (
    [m] int  NOT NULL,
    [TrType] nchar(10)  NOT NULL,
    [Ip] float  NOT NULL,
    [q] float  NOT NULL,
    [e] float  NOT NULL,
    [id] int  NOT NULL
);
GO

-- Creating table 'Table_2'
CREATE TABLE [dbo].[Table_2] (
    [m] int  NOT NULL,
    [n1_l] float  NOT NULL,
    [n1_h] float  NOT NULL,
    [z1] float  NOT NULL,
    [is_suitable] bit  NOT NULL,
    [id] int  NOT NULL
);
GO

-- Creating table 'Table_3'
CREATE TABLE [dbo].[Table_3] (
    [m] int  NOT NULL,
    [b] float  NOT NULL,
    [id] int  NOT NULL
);
GO

-- Creating table 'UZ'
CREATE TABLE [dbo].[UZ] (
    [CodeUz] nvarchar(50)  NOT NULL,
    [NameUz] nvarchar(50)  NOT NULL,
    [NP] float  NOT NULL,
    [SE_id] nvarchar(50)  NOT NULL,
    [i] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CodeDET] in table 'DET'
ALTER TABLE [dbo].[DET]
ADD CONSTRAINT [PK_DET]
    PRIMARY KEY CLUSTERED ([CodeDET] ASC);
GO

-- Creating primary key on [CodeSE] in table 'SE'
ALTER TABLE [dbo].[SE]
ADD CONSTRAINT [PK_SE]
    PRIMARY KEY CLUSTERED ([CodeSE] ASC);
GO

-- Creating primary key on [id] in table 'Table_1'
ALTER TABLE [dbo].[Table_1]
ADD CONSTRAINT [PK_Table_1]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Table_2'
ALTER TABLE [dbo].[Table_2]
ADD CONSTRAINT [PK_Table_2]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Table_3'
ALTER TABLE [dbo].[Table_3]
ADD CONSTRAINT [PK_Table_3]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [CodeUz] in table 'UZ'
ALTER TABLE [dbo].[UZ]
ADD CONSTRAINT [PK_UZ]
    PRIMARY KEY CLUSTERED ([CodeUz] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CodeSE] in table 'SE'
ALTER TABLE [dbo].[SE]
ADD CONSTRAINT [FK_SE_DET]
    FOREIGN KEY ([CodeSE])
    REFERENCES [dbo].[DET]
        ([CodeDET])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SE_id] in table 'UZ'
ALTER TABLE [dbo].[UZ]
ADD CONSTRAINT [FK_UZ_SE1]
    FOREIGN KEY ([SE_id])
    REFERENCES [dbo].[SE]
        ([CodeSE])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UZ_SE1'
CREATE INDEX [IX_FK_UZ_SE1]
ON [dbo].[UZ]
    ([SE_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------