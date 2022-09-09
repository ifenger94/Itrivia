CREATE TABLE [parametros].[par_pimagenes]
  (
     [id]         [INT] IDENTITY(1, 1) NOT NULL,
     [baja]       [BIT] NOT NULL,
     [alta_fecha] [DATETIME] NOT NULL,
     [modi_fecha] [DATETIME] NULL,
     [usuario]     [VARCHAR](50) NOT NULL,
     [codigo]     [VARCHAR](50) NULL,
     [url_imagen] [VARCHAR](300) NULL
     CONSTRAINT [PK_par_pimagenes] PRIMARY KEY CLUSTERED ( [id] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
  )
ON [PRIMARY]

GO

ALTER TABLE [parametros].[par_pimagenes]
  ADD CONSTRAINT [DF_pimg_baja] DEFAULT ((0)) FOR [baja]

GO

CREATE UNIQUE NONCLUSTERED INDEX [IQ_pimg_cod]
  ON [parametros].[par_pimagenes]([codigo] ASC)
  WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO 
