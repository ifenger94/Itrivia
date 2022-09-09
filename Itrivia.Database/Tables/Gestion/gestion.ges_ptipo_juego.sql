CREATE TABLE [gestion].[ges_ptipo_juego]
  (
     [id]         [INT] IDENTITY(1, 1) NOT NULL,
     [baja]       [BIT] NOT NULL,
     [alta_fecha] [DATETIME] NOT NULL,
     [modi_fecha] [DATETIME] NULL,
     [usuario]     [VARCHAR](50) NOT NULL,
     [nombre]     [VARCHAR](50) NOT NULL,
     [codigo]     [VARCHAR](50) NOT NULL,
     CONSTRAINT [PK_ges_ptipo_juego] PRIMARY KEY CLUSTERED ( [id] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
  )
ON [PRIMARY]

GO

ALTER TABLE [gestion].[ges_ptipo_juego]
  ADD CONSTRAINT [DF_ptipo_juego] DEFAULT ((0)) FOR [baja]

GO

CREATE UNIQUE NONCLUSTERED INDEX [IQ_ptipjuego_cod]
  ON [gestion].[ges_ptipo_juego]([codigo] ASC)
  WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO 
