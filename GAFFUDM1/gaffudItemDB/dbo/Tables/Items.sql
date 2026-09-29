CREATE TABLE [dbo].[Items]
(
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (100)  NOT NULL,
    [Code]      NVARCHAR (50)   NOT NULL,
    [Brand]     NVARCHAR (50)   NOT NULL,
    [UnitPrice] DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);