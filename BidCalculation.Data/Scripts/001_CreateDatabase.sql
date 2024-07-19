﻿CREATE DATABASE BidCalculation;
GO

USE [BidCalculation]
GO

/****** Object:  Table [dbo].[VehicleTypes]    Script Date: 18/07/2024 06:07:27 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VehicleTypes](
	[id] [tinyint] NOT NULL,
	[type] [char](6) NOT NULL,
 CONSTRAINT [PK_VehicleTypes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Vehicles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[vehicle_price] [money] NOT NULL,
	[vehicle_type] [tinyint] NOT NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_VehicleTypes] FOREIGN KEY([vehicle_type])
REFERENCES [dbo].[VehicleTypes] ([id])
GO

ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_VehicleTypes]
GO

INSERT INTO [dbo].[VehicleTypes] VALUES (1,'COMMON'), (2,'LUXURY')