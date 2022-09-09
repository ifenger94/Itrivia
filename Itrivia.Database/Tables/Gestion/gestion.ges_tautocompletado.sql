CREATE TABLE [gestion].[ges_tautocompletado]
  (
     [id]                 [INT] IDENTITY(1, 1) NOT NULL,
     [baja]               [BIT] NOT NULL,
     [alta_fecha]         [DATETIME] NOT NULL,
     [modi_fecha]         [DATETIME] NULL,
     [usuario]     [VARCHAR](50) NOT NULL,
     [enunciado]    [VARCHAR] (100 )NOT NULL,
     [respuesta]  [VARCHAR] (50 )NOT NULL
     CONSTRAINT [PK_ges_tautocompletado] PRIMARY KEY CLUSTERED ( [id] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
  )
ON [PRIMARY]

GO

ALTER TABLE [gestion].[ges_tautocompletado]
  ADD CONSTRAINT [DF_taut] DEFAULT ((0)) FOR [baja]

GO
