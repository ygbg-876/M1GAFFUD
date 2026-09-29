CREATE PROCEDURE [dbo].[spItems_Detail]
    @id int
AS
BEGIN
    SET NOCOUNT ON;
    SELECT [Id], [Name], [Code], [Brand], [UnitPrice]
    FROM dbo.Items
    WHERE [Id] = @id;
END