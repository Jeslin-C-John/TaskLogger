USE [TaskLogger]
GO

/****** Object:  Table [dbo].[tasks]    Script Date: 13-12-2022 09:53:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tasks](
	[taskid] [int] IDENTITY(1,1) NOT NULL,
	[empid] [int] NULL,
	[date] [date] NULL,
	[hours] [int] NULL,
	[status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[taskid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tasks]  WITH CHECK ADD FOREIGN KEY([empid])
REFERENCES [dbo].[users] ([id])
GO

