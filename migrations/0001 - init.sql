USE [agenda]
GO


CREATE TABLE [dbo].[atendimento](
	[id_atendimento] [int] IDENTITY(1,1) NOT NULL,
	[paciente_nome] [varchar](100) NOT NULL,
	[paciente_data_nascimento] [date] NOT NULL,
	[data_inicial] [datetime] NOT NULL,
	[data_final] [datetime] NOT NULL,
	[observacao] [varchar](500)  NULL,
	[status] [varchar](10) NOT NULL,
	[data_cadastro] [datetime] NOT NULL,
	[data_cancelamento] [datetime] NULL
 CONSTRAINT [PK_atendimento] PRIMARY KEY CLUSTERED 
(
	[id_atendimento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO




