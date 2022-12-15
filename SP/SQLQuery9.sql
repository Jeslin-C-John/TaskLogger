USE [TaskLogger]
GO

/****** Object:  StoredProcedure [dbo].[usercheck]    Script Date: 15-12-2022 11:53:32 AM ******/
DROP PROCEDURE [dbo].[usercheck]
GO

/****** Object:  StoredProcedure [dbo].[usercheck]    Script Date: 15-12-2022 11:53:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[usercheck]
(
@email varchar(50)
)
AS
BEGIN
SELECT id FROM dbo.users WHERE email=@email
END
GO


