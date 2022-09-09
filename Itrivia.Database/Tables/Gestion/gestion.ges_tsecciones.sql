CREATE TABLE [gestion].[ges_tsecciones]
  (
     [id]            [INT] IDENTITY(1, 1) NOT NULL,
     [baja]          [BIT] NOT NULL,
     [alta_fecha]    [DATETIME] NOT NULL,
     [modi_fecha]    [DATETIME] NULL,
     [nombre]        [VARCHAR](50) NOT NULL,
     [usuario]     [VARCHAR](50) NOT NULL,
     [descripcion]   [VARCHAR](150) NULL,
     [id_categoria]  [INT] NOT NULL,
     [url_imagen]    [VARCHAR](150) NULL,
     [cant_desafios] [INT] NOT NULL,
     [activated]          [BIT] NOT NULL,
     CONSTRAINT [PK_ges_tsecciones] PRIMARY KEY CLUSTERED ( [id] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
  )
ON [PRIMARY]

GO

ALTER TABLE [gestion].[ges_tsecciones]
  ADD CONSTRAINT [DF_tsec_baja] DEFAULT ((0)) FOR [baja]

GO

ALTER TABLE [gestion].[ges_tsecciones]
  ADD CONSTRAINT [DF_tsec_activated] DEFAULT ((0)) FOR [activated]

GO

ALTER TABLE [gestion].[ges_tsecciones]
ADD CONSTRAINT [FK_tsecciones_tcategorias] FOREIGN KEY([id_categoria]) REFERENCES [gestion].[ges_tcategorias] ([id])

GO

CREATE UNIQUE NONCLUSTERED INDEX [IQ_tsec_nom]
  ON [gestion].[ges_tsecciones]([nombre] ASC)
  WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO 
