CREATE TABLE [mov].[Movies] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Title]       VARCHAR (125) NOT NULL,
    [MovieTypeID] INT           NOT NULL,
    [imdbID]      VARCHAR (40)  NOT NULL,
    [Poster]      VARCHAR (MAX) NOT NULL,
    [Year]        INT           NOT NULL,
    [Active]      BIT           NOT NULL,
    [DtCreated]   DATETIME      NOT NULL,
    [CreatedBy]   INT           NOT NULL,
    [DtModified]  DATETIME      NULL,
    [ModifiedBy]  INT           NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Movies_MovieTypes] FOREIGN KEY ([MovieTypeID]) REFERENCES [mov].[MovieTypes] ([ID]),
    CONSTRAINT [FK_Movies_Users] FOREIGN KEY ([CreatedBy]) REFERENCES [usr].[Users] ([ID]),
    CONSTRAINT [FK_Movies_Users1] FOREIGN KEY ([ModifiedBy]) REFERENCES [usr].[Users] ([ID]),
    CONSTRAINT [IX_Movies] UNIQUE NONCLUSTERED ([imdbID] ASC)
);



