﻿CREATE TABLE [dbo].[FeedBackForm] (
    [Id]              BIGINT         IDENTITY (1, 1) NOT NULL,
    [FirstName]       NVARCHAR (MAX) NULL,
    [LastName]        NVARCHAR (MAX) NULL,
    [EmailAddress]    NVARCHAR (MAX) NULL,
    [FeedbackMessage] NVARCHAR (MAX) NULL,
    [ATTRIBUTE1] NVARCHAR(100) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

