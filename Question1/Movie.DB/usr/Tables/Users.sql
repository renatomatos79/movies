CREATE TABLE [usr].[Users] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (60)  NOT NULL,
    [Login]      VARCHAR (60)  NOT NULL,
    [Saltkey]    CHAR (8)      NOT NULL,
    [Password]   VARCHAR (MAX) NOT NULL,
    [Active]     BIT           NOT NULL,
    [DtCreated]  DATETIME      NOT NULL,
    [CreatedBy]  INT           NULL,
    [DtModified] DATETIME      NULL,
    [ModifiedBy] INT           NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Users_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [usr].[Users] ([ID]),
    CONSTRAINT [FK_Users_ModifiedBy] FOREIGN KEY ([ModifiedBy]) REFERENCES [usr].[Users] ([ID]),
    CONSTRAINT [IX_Users] UNIQUE NONCLUSTERED ([Login] ASC)
);

