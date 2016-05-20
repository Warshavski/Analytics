CREATE TABLE [dbo].[subdivision_user]
(
	[id_subdivision]	BIGINT NOT NULL,
	[id_user]			BIGINT NOT NULL,
	PRIMARY KEY (id_subdivision, id_user),
	FOREIGN KEY (id_user)		 REFERENCES dbo.[user] (id_user),
	FOREIGN KEY (id_subdivision) REFERENCES dbo.subdivison (id_subdivision) 
)
GO

CREATE INDEX ix_subdivision_user_id_user on subdivision_user(id_user)
GO
