CREATE PROCEDURE [dbo].[autologin]
(
@email varchar(50) 
)
AS
BEGIN
SELECT id,name FROM dbo.users WHERE email=@email
END