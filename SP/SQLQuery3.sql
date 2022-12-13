USE [TaskLogger]
GO

/****** Object:  StoredProcedure [dbo].[addtask]    Script Date: 13-12-2022 09:54:44 AM ******/
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

CREATE PROCEDURE [dbo].[addtask]
(
@empid INT,
@date varchar(50),
@hours INT,
@status INT
)
AS
BEGIN
INSERT INTO dbo.tasks (empid,date,hours,status) VALUES(@empid,@date,@hours,@status)
END
GO


