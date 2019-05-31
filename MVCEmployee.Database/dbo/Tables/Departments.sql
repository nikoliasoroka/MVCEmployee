CREATE TABLE [dbo].[Departments] (
    [DeptId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Departments] PRIMARY KEY CLUSTERED ([DeptId] ASC)
);



