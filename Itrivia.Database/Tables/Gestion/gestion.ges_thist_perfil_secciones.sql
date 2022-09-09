CREATE TABLE [gestion].[ges_thist_perfil_secciones]
  (
     [id]         [INT] IDENTITY(1, 1) NOT NULL,
     [baja]       [BIT] NOT NULL,
     [alta_fecha] [DATETIME] NOT NULL,
     [modi_fecha] [DATETIME] NULL,
     [usuario]     [VARCHAR](50) NOT NULL,
     [id_perfil]  [INT] NOT NULL,
     [id_seccion]  [INT] NOT NULL,
     CONSTRAINT [PK_ges_thist_perfil_secciones] PRIMARY KEY CLUSTERED ( [id] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
  )
ON [PRIMARY]

GO

ALTER TABLE [gestion].[ges_thist_perfil_secciones]
  ADD CONSTRAINT [DF_thistps_baja] DEFAULT ((0)) FOR [baja]

GO

ALTER TABLE [gestion].[ges_thist_perfil_secciones]
ADD  CONSTRAINT [FK_hist_perfil_desafio_tsecciones] FOREIGN KEY([id_seccion])
REFERENCES [gestion].[ges_tsecciones] ([id])
GO


CREATE UNIQUE NONCLUSTERED INDEX [IQ_thistps_id]
  ON [gestion].[ges_thist_perfil_secciones]([id_perfil],[id_seccion] ASC)
  WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO 
