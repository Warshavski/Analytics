CREATE TABLE [dbo].[supplier](
	[id_supplier]	INT    NOT NULL,
	[inn]			NVARCHAR (50)	NOT NULL,
	[name_short]	NVARCHAR (50)	NULL,
    [name_full]		NVARCHAR (200)	NULL, 
    CONSTRAINT [PK_Supplier] PRIMARY KEY ([id_supplier])
);