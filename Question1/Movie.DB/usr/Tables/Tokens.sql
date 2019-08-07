CREATE TABLE [usr].[Tokens] (
    [Token]        VARCHAR (40) NOT NULL,
    [UserID]       INT          NOT NULL,
    [Active]       BIT          NOT NULL,
    [DtExpiration] DATETIME     NOT NULL,
    [DtCreated]    DATETIME     NOT NULL,
    CONSTRAINT [PK_Tokens] PRIMARY KEY CLUSTERED ([Token] ASC),
    CONSTRAINT [FK_Tokens_Users] FOREIGN KEY ([UserID]) REFERENCES [usr].[Users] ([ID])
);

