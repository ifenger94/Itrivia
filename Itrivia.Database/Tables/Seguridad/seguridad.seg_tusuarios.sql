CREATE TABLE [seguridad].[seg_tusuarios]
  (
     [id]         [INT] IDENTITY(1, 1) NOT NULL,
     [baja]       [BIT] NOT NULL,
     [alta_fecha] [DATETIME] NOT NULL,
     [modi_fecha] [DATETIME] NULL,
     [usuario]     [VARCHAR](50) NOT NULL,
     [nombre]     [VARCHAR](50) NOT NULL,
     [apellido]   [VARCHAR](50) NOT NULL,
     [password]   [VARCHAR](150) NOT NULL,
     [email]      [VARCHAR](50) NOT NULL,
     [id_rol]     [INT] NOT NULL,
     [id_perfil]  [INT] NULL,
     [id_imagen]  [INT] NULL,
     CONSTRAINT [PK_seg_tusuarios] PRIMARY KEY CLUSTERED ( [id] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
  )
ON [PRIMARY]

GO

ALTER TABLE [seguridad].[seg_tusuarios]
  ADD CONSTRAINT [DF_tus_baja] DEFAULT ((0)) FOR [baja]

GO

ALTER TABLE [seguridad].[seg_tusuarios]
ADD CONSTRAINT [FK_tusuarios_troles] FOREIGN KEY([id_rol]) REFERENCES [seguridad].[seg_proles] ([id])

GO

ALTER TABLE [seguridad].[seg_tusuarios]
ADD CONSTRAINT [FK_tusuarios_tperfiles] FOREIGN KEY([id_perfil]) REFERENCES [gestion].[ges_tperfiles] ([id])

GO

ALTER TABLE [seguridad].[seg_tusuarios]
ADD CONSTRAINT [FK_tusuarios_pimagenes] FOREIGN KEY([id_imagen]) REFERENCES [parametros].[par_pimagenes] ([id])

GO

CREATE UNIQUE NONCLUSTERED INDEX [IQ_tuser_idperfil]
  ON [seguridad].[seg_tusuarios]([id_perfil] ASC) WHERE [id_perfil] IS NOT NULL
  WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO 


