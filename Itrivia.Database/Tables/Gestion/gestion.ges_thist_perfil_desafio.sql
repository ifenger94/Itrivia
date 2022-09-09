CREATE TABLE [gestion].[ges_thist_perfil_desafios]
  (
     [id]         [INT] IDENTITY(1, 1) NOT NULL,
     [baja]       [BIT] NOT NULL,
     [alta_fecha] [DATETIME] NOT NULL,
     [modi_fecha] [DATETIME] NULL,
     [usuario]     [VARCHAR](50) NOT NULL,
     [id_perfil]  [INT] NOT NULL,
     [id_desafio] [INT] NOT NULL,
     CONSTRAINT [PK_ges_thist_perfil_desafios] PRIMARY KEY CLUSTERED ( [id] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
  )
ON [PRIMARY]

GO

ALTER TABLE [gestion].[ges_thist_perfil_desafios]
  ADD CONSTRAINT [DF_thistpd_baja] DEFAULT ((0)) FOR [baja]

GO

ALTER TABLE [gestion].[ges_thist_perfil_desafios]
ADD CONSTRAINT [FK_hist_perfil_desafio_desafios] FOREIGN KEY([id_desafio]) REFERENCES [gestion].[ges_tdesafios] ([id])

GO

ALTER TABLE [gestion].[ges_thist_perfil_desafios]
ADD CONSTRAINT [FK_hist_perfil] FOREIGN KEY([id_perfil]) REFERENCES [gestion].[ges_tperfiles] ([id])

GO

CREATE UNIQUE NONCLUSTERED INDEX [IQ_thistps_id]
  ON [gestion].[ges_thist_perfil_desafios]([id_perfil],[id_desafio] ASC)
  WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO 
