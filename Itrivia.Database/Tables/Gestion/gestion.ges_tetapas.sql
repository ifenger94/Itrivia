CREATE TABLE [gestion].[ges_tetapas]
  (
     [id]                [INT] IDENTITY(1, 1) NOT NULL,
     [baja]              [BIT] NOT NULL,
     [alta_fecha]        [DATETIME] NOT NULL,
     [modi_fecha]        [DATETIME] NULL,
     [usuario]     [VARCHAR](50) NOT NULL,
     [nombre]            [VARCHAR](50) NOT NULL,
     [id_desafio]        [INT] NOT NULL,
     [id_tipo_juego]        [INT] NOT NULL,
     [id_autocompletado]        [INT] NULL,
     [id_mchoice]        [INT]  NULL,
     [id_spares]        [INT]  NULL

     CONSTRAINT [PK_ges_tetapas] PRIMARY KEY CLUSTERED ( [id] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
  )
ON [PRIMARY]

GO

ALTER TABLE [gestion].[ges_tetapas]
  ADD CONSTRAINT [DF_tetp_baja] DEFAULT ((0)) FOR [baja]

GO

ALTER TABLE [gestion].[ges_tetapas]
ADD CONSTRAINT [FK_ttetapas_tdesafios] FOREIGN KEY([id_desafio]) REFERENCES [gestion].[ges_tdesafios] ([id])

GO

ALTER TABLE [gestion].[ges_tetapas]
ADD CONSTRAINT [FK_ttiposjuegos_tdesafios] FOREIGN KEY([id_tipo_juego]) REFERENCES [gestion].[ges_ptipo_juego] ([id])

GO

ALTER TABLE [gestion].[ges_tetapas]
ADD CONSTRAINT [FK_tetapa_tautocomp] FOREIGN KEY([id_autocompletado]) REFERENCES [gestion].[ges_tautocompletado] ([id])

GO

ALTER TABLE [gestion].[ges_tetapas]
ADD CONSTRAINT [FK_tetapa_tmultchoice] FOREIGN KEY([id_mchoice]) REFERENCES [gestion].[ges_tmultiplechoice] ([id])

GO

ALTER TABLE [gestion].[ges_tetapas]
ADD CONSTRAINT [FK_tetapa_tspares] FOREIGN KEY([id_spares]) REFERENCES [gestion].[ges_tselec_pares] ([id])