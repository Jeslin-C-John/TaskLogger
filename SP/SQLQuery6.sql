USE [TaskLogger]
GO

/****** Object:  StoredProcedure [dbo].[signup]    Script Date: 13-12-2022 09:55:42 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[signup]
(
@name varchar(50),  
@email varchar(50),  
@password varchar(100)
)
AS
BEGIN
INSERT INTO dbo.users (name,email,password) VALUES( @name, @email,@password)
END
GO


