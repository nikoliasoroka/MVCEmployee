CREATE TABLE [dbo].[Employees] (
    [EmpId]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NULL,
    [Address]     NVARCHAR (MAX) NULL,
    [PhoneNumber] INT            NULL,
    [DeptId]      INT            NOT NULL,
    CONSTRAINT [PK_dbo.Employees] PRIMARY KEY CLUSTERED ([EmpId] ASC),
    CONSTRAINT [FK_dbo.Employees_dbo.Departments_DeptId] FOREIGN KEY ([DeptId]) REFERENCES [dbo].[Departments] ([DeptId]) ON DELETE CASCADE
);






GO
CREATE NONCLUSTERED INDEX [IX_DeptId]
    ON [dbo].[Employees]([DeptId] ASC);

