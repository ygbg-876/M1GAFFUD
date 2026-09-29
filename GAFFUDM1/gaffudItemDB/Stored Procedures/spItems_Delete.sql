CREATE PROCEDURE [dbo].[spItems_Delete]
    @id int
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.Items WHERE [Id] = @id;
END