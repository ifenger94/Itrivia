CREATE TABLE [gestion].[ges_tselec_pares]
  (
     [id]         [INT] IDENTITY(1, 1) NOT NULL,
     [baja]       [BIT] NOT NULL,
     [alta_fecha] [DATETIME] NOT NULL,
     [modi_fecha] [DATETIME] NULL,
     [usuario]     [VARCHAR](50) NOT NULL,
     [opcion1]    [VARCHAR] (100) NOT NULL,
     [respuesta1] [VARCHAR] (100) NOT NULL,
     [opcion2]    [VARCHAR] (100) NOT NULL,
     [respuesta2] [VARCHAR] (100) NOT NULL,
     [opcion3]    [VARCHAR] (100) NOT NULL,
     [respuesta3] [VARCHAR] (100) NOT NULL,
     [opcion4]    [VARCHAR] (100) NOT NULL,
     [respuesta4] [VARCHAR] (100) NOT NULL
     CONSTRAINT [PK_ges_tselec_pares] PRIMARY KEY CLUSTERED ( [id] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
  )
ON [PRIMARY]

GO

ALTER TABLE [gestion].[ges_tselec_pares]
  ADD CONSTRAINT [DF_tselpar] DEFAULT ((0)) FOR [baja]

GO 
