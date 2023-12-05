CREATE TABLE [dbo].[Loan]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Date] DATETIME NOT NULL, 
    [ReturnDate] DATETIME NULL, 
    [Status] NCHAR(10) NOT NULL,
    [PersonID] INT NOT NULL,
    [ThingID] INT NOT NULL, 
)

GO
    ALTER TABLE [dbo].[Loan] ADD CONSTRAINT [FK_Loan_Person_PersonID] FOREIGN KEY([PersonID])
    REFERENCES [dbo].[Person] ([Id])
GO
GO
    ALTER TABLE [dbo].[Loan] ADD CONSTRAINT [FK_Loan_Thing_ThingID] FOREIGN KEY([ThingID])
    REFERENCES [dbo].[Thing] ([Id])
GO
