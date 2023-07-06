CREATE PROCEDURE sp_CrearUsuario
(
    @Username nvarchar(100),
    @Passwd nvarchar(100),
	@Rol nvarchar(100)
)

AS
BEGIN

INSERT INTO Usuario (
	Username,
	Passwd,
	Rol
)

VALUES 
(
	@Username,
	@Passwd,
	@Rol
)
END
