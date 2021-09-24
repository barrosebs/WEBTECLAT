USE [WEBTECLAT]
GO

/****** Object:  Table [dbo].[TBProduct]    Script Date: 23/09/2021 23:46:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TBProduct](
	[idProduct] [int] IDENTITY(1,1) NOT NULL,
	[nameProduct] [nchar](100) NOT NULL,
	[priceProduct] [decimal](18, 2) NOT NULL,
	[imageProduct] [image] NULL,
	[descriptopnProduct] [nchar](100) NULL,
	[amountProduct] [int] NOT NULL,
	[createdDateProduct] [datetime2](7) NOT NULL,
	[idCategoryProduct] [int] NOT NULL,
 CONSTRAINT [PK_TBProduct] PRIMARY KEY CLUSTERED 
(
	[idProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[TBProduct]  WITH CHECK ADD  CONSTRAINT [FK_TBProduct_TBCategory] FOREIGN KEY([idCategoryProduct])
REFERENCES [dbo].[TBCategory] ([idCategory])
GO

ALTER TABLE [dbo].[TBProduct] CHECK CONSTRAINT [FK_TBProduct_TBCategory]
GO

