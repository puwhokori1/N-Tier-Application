
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/03/2012 09:51:18
-- Generated from EDMX file: C:\Dev\Steve\PluralsightCourses\020 - N Tier Applications\m02\before\PluralSightBook\PluralSightBookWebsite\Code\PSBData.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------


-- Creating table 'Friends'
CREATE TABLE [dbo].[Friends] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [EmailAddress] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------
-- Creating primary key on [Id] in table 'Friends'
ALTER TABLE [dbo].[Friends]
ADD CONSTRAINT [PK_Friends]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------
-- Creating foreign key on [UserId] in table 'Friends'
ALTER TABLE [dbo].[Friends]
ADD CONSTRAINT [FK_Friendaspnet_Membership]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[aspnet_Membership]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Friendaspnet_Membership'
CREATE INDEX [IX_FK_Friendaspnet_Membership]
ON [dbo].[Friends]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------