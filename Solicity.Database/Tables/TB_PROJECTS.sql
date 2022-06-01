﻿CREATE TABLE [dbo].[TB_PROJECTS]
(
	[Id] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(MAX) NOT NULL, 
    [Enabled] BIT NOT NULL DEFAULT 1,
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    [UdpatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    [DeletedAt] DATETIME NULL,
)
