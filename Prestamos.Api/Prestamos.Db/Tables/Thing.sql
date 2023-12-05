CREATE TABLE [dbo].[Thing]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Description] VARCHAR(50) NOT NULL, 
    [CreationDate] DATETIME NOT NULL,
    [CategoryID] INT NOT NULL
)
GO
    ALTER TABLE [dbo].[Thing] ADD CONSTRAINT [FK_Thing_CategoryID] FOREIGN KEY([CategoryID])
    REFERENCES [dbo].[Category] ([Id])
GO