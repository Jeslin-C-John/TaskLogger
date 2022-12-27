USE [TaskLogger]
GO

/****** Object:  StoredProcedure [dbo].[viewtask]    Script Date: 27-12-2022 01:29:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[viewupdate]
(
@taskid INT
)
AS
BEGIN
SELECT tasks.date, tasks.hours, tasks.status 
	FROM dbo.tasks
	WHERE  tasks.taskid = @taskid
	END
GO


