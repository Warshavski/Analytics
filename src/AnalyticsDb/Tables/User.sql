CREATE TABLE [dbo].[user](
	[id_user]	BIGINT  IDENTITY (1, 1) NOT NULL,
	[name]		NVARCHAR (100) NOT NULL,
	[login]		NVARCHAR (50) NOT NULL,
    [password]	NVARCHAR (30) NOT NULL, 
    CONSTRAINT [PK_User] PRIMARY KEY ([id_user])
);