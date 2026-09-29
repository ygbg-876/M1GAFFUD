CREATE PROCEDURE [dbo].[spUsers_Authenticate]
    @username nvarchar(50),
    @password nvarchar(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT [Id], [UserName], [Password]
    FROM dbo.Users
    WHERE UserName = @username AND Password = @password;
END