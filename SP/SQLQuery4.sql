USE [TaskLogger]
GO

/****** Object:  StoredProcedure [dbo].[deletetask]    Script Date: 13-12-2022 09:55:04 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[deletetask]
(
@taskid INT
)
AS
BEGIN
DELETE FROM dbo.tasks WHERE taskid = @taskid
END
GO


