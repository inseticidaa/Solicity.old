﻿CREATE TABLE [dbo].[TB_REQUESTS]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [AuthorId] INT NOT NULL, 
    [TeamId] INT NOT NULL, 
    [RequestTypeId] INT NOT NULL, 
    [Title] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(MAX) NOT NULL,
    [Resolved] BIT NOT NULL DEFAULT 0,
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    [UdpatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    [DeletedAt] DATETIME NULL
)