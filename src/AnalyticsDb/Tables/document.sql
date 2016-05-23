CREATE TABLE [dbo].[document] (
    [id_document]			INT NOT NULL,
	[id_subdivision]		BIGINT NOT NULL,
	[id_supplier]			INT NOT NULL,
    [date_create]			DATETIME NOT NULL,
    [date_edit]				DATETIME NULL,
    [date_pay]				DATETIME NULL,
	[date_payfact]			DATETIME NULL,
	[days_delay]			INT NULL,
	[price_sum_nds]			MONEY NULL,
	[price_sum_order]		MONEY NULL,
	[price_sum_retail]		MONEY NULL,
	[price_sum_discount]	MONEY NULL,
	[comment]				NVARCHAR(255) NULL
    CONSTRAINT [PK_Dosument]	PRIMARY KEY ([id_document]),
	CONSTRAINT [FK_Supplier]	FOREIGN KEY ([id_supplier])		 REFERENCES dbo.[supplier] ([id_supplier]),
	CONSTRAINT [FK_Subdivision] FOREIGN KEY ([id_subdivision])	 REFERENCES dbo.[subdivision] ([id_subdivision])
);

