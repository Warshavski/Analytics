CREATE TABLE [dbo].[subdivison] (
    [id_subdivision]    BIGINT NOT NULL,
	[id_user]			BIGINT NOT NULL,
    [address]			NVARCHAR (100) NULL,
    [name_short]		NVARCHAR (20)  NULL,
    [name_full]			NVARCHAR (100)  NULL,
    PRIMARY KEY CLUSTERED ([id_subdivision] ASC),
	FOREIGN KEY (id_user)		 REFERENCES dbo.[user] (id_user)
);

