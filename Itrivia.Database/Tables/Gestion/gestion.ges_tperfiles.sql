CREATE TABLE [gestion].[ges_tperfiles]
  (
     [id]         [INT] IDENTITY(1, 1) NOT NULL,
     [baja]       [BIT] NOT NULL,
     [alta_fecha] [DATETIME] NOT NULL,
     [modi_fecha] [DATETIME] NULL,
     [usuario]     [VARCHAR](50) NOT NULL,
     [exp]        [INT] NOT NULL
     CONSTRAINT [PK_ges_tperfiles] PRIMARY KEY CLUSTERED ( [id] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
  )
ON [PRIMARY]

GO

ALTER TABLE [gestion].[ges_tperfiles]
  ADD CONSTRAINT [DF_tperfil_baja] DEFAULT ((0)) FOR [baja]

GO



