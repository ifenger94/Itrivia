CREATE TABLE [parametros].[par_petiquetas]( 
 [id] [int] IDENTITY(1,1) NOT NULL,
 [baja] [bit] NOT NULL,
 [alta_fecha] [datetime] NOT NULL,
 [modi_fecha] [datetime] NULL,
 [usuario] [varchar](50) NOT NULL,
 [codigo] [varchar](32) NOT NULL,
 [nombre] [varchar](100) NOT NULL,
 [espanol] [varchar](500) NOT NULL,
 [ingles] [varchar](500) NOT NULL,

CONSTRAINT [PK_par_petiquetas] PRIMARY KEY CLUSTERED 
(
 [id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [parametros].[par_petiquetas] ADD  CONSTRAINT [DF_plbl_baja]  DEFAULT ((0)) FOR [baja]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IQ_plbl_codigo] ON [parametros].[par_petiquetas]([codigo] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


