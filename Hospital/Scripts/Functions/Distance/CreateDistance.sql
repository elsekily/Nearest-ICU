USE [Hospitals]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER   FUNCTION [dbo].[Distance](@userLatitude FLOAT, @userLongitude FLOAT, @locationLatitude FLOAT, @locationLongitude FLOAT) RETURNS FLOAT AS BEGIN    RETURN Round((((Acos(Sin((@userLatitude * PI() / 180)) * Sin((@locationLatitude * PI() / 180)) + Cos((@userLatitude * PI() / 180)) * Cos((@locationLatitude * PI()/ 180)) * Cos(((@userLongitude - @locationlongitude) * PI() / 180)))) * 180 / PI()) * 60 * 1.1515 * 1.609344), 2) END 
GO


