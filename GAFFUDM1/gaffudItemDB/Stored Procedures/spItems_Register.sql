CREATE PROCEDURE [dbo].[spUsers_Register]
    @username nvarchar(50),
    @password nvarchar(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Users ([UserName], [Password])
    VALUES (@username, @password);
END