USE [TaskLogger]
GO

/****** Object:  StoredProcedure [dbo].[updatetask]    Script Date: 13-12-2022 09:55:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[updatetask]
(
@taskid INT,
@date varchar(50),
@hours INT,
@status INT
)
AS
BEGIN
UPDATE dbo.tasks SET date = @date,hours = @hours, status = @status  WHERE taskid = @taskid
END
GO


