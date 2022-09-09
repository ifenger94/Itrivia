CREATE TABLE [seguridad].[seg_proles]
  (
     [id]         [INT] IDENTITY(1, 1) NOT NULL,
     [baja]       [BIT] NOT NULL,
     [alta_fecha] [DATETIME] NOT NULL,
     [modi_fecha] [DATETIME] NULL,
     [usuario]     [VARCHAR](50) NOT NULL,
     [nombre]     [VARCHAR](50) NOT NULL,
     [codigo]     [VARCHAR](50) NOT NULL
     CONSTRAINT [PK_seg_proles] PRIMARY KEY CLUSTERED ( [id] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
  )
ON [PRIMARY]

GO

ALTER TABLE [seguridad].[seg_proles]
  ADD CONSTRAINT [DF_trol_baja] DEFAULT ((0)) FOR [baja]

GO

CREATE UNIQUE NONCLUSTERED INDEX [IQ_trol_cod]
  ON [seguridad].[seg_proles]([codigo] ASC)
  WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO 
