CREATE TABLE [gestion].[ges_tdesafios]
  (
     [id]          [INT] IDENTITY(1, 1) NOT NULL,
     [baja]        [BIT] NOT NULL,
     [alta_fecha]  [DATETIME] NOT NULL,
     [modi_fecha]  [DATETIME] NULL,
     [usuario]     [VARCHAR](50) NOT NULL,
     [nombre]      [VARCHAR](50) NOT NULL,
     [descripcion] [VARCHAR](150) NULL,
     [id_seccion]  [INT] NOT NULL,
     [experiencia] [INT] NOT NULL,
     [cant_etapas] [INT] NOT NULL,
     [activated]   [BIT] NOT NULL,
     CONSTRAINT [PK_ges_tdesafios] PRIMARY KEY CLUSTERED ( [id] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
  )
ON [PRIMARY]

GO

ALTER TABLE [gestion].[ges_tdesafios]
  ADD CONSTRAINT [DF_tdes_baja] DEFAULT ((0)) FOR [baja]
GO

ALTER TABLE [gestion].[ges_tdesafios]
  ADD CONSTRAINT [DF_tdes_activated] DEFAULT ((0)) FOR [activated]
GO

ALTER TABLE [gestion].[ges_tdesafios]  
ADD  CONSTRAINT [FK_tdesafios_tsecciones] FOREIGN KEY([id_seccion])
REFERENCES [gestion].[ges_tsecciones] ([id])

GO

CREATE UNIQUE NONCLUSTERED INDEX [IQ_tdes_nom]
  ON [gestion].[ges_tdesafios]([nombre] ASC)
  WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO 
