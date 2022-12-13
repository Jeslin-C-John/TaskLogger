USE [TaskLogger]
GO

/****** Object:  StoredProcedure [dbo].[viewtask]    Script Date: 13-12-2022 09:56:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[viewtask]
(
@empid INT,
@startdate varchar(10),
@enddate varchar(10)
)
AS
BEGIN
SELECT tasks.taskid, tasks.date, tasks.hours, tasks.status 
	FROM dbo.tasks
	WHERE  tasks.empid = @empid
	AND tasks.date BETWEEN @startdate AND @enddate
END
GO


