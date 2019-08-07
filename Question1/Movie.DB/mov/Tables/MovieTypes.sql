CREATE TABLE [mov].[MovieTypes] (
    [ID]         INT          IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (60) NOT NULL,
    [Active]     BIT          NOT NULL,
    [DtCreated]  DATETIME     NOT NULL,
    [CreatedBy]  INT          NOT NULL,
    [DtModified] DATETIME     NULL,
    [ModifiedBy] INT          NULL,
    CONSTRAINT [PK_MovieType] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_MovieTypes_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [usr].[Users] ([ID]),
    CONSTRAINT [FK_MovieTypes_ModifiedBy] FOREIGN KEY ([ModifiedBy]) REFERENCES [usr].[Users] ([ID]),
    CONSTRAINT [IX_MovieTypes] UNIQUE NONCLUSTERED ([Name] ASC)
);

