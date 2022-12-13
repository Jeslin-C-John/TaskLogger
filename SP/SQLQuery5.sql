USE [TaskLogger]
GO

/****** Object:  StoredProcedure [dbo].[login]    Script Date: 13-12-2022 09:55:31 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--ALTER PROCEDURE dbo.insertuser
--(
--@name varchar(50),  
--@password varchar(50)
--)
--AS
--BEGIN
--INSERT INTO dbo.userlist (name,password) VALUES( @name, @password)
--END

CREATE PROCEDURE [dbo].[login]
(
@email varchar(50),  
@password varchar(100)
)
AS
BEGIN
SELECT id,name FROM dbo.users WHERE email=@email AND password=@password
END
GO


