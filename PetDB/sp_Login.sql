CREATE PROCEDURE [dbo].[sp_Login]
    @Option int = 0,
    @Email nvarchar(200),
    @Password nvarchar(70)
AS
BEGIN
    -- Autenticación de inicio de sesión
    IF @Option = 1
    BEGIN
        -- Si el usuario existe, verifica la contraseña
        IF EXISTS (
            SELECT 1
            FROM Usuarios
            WHERE Email = @Email
            AND Contrasena = PWDENCRYPT(@Password)
        )
        BEGIN
            RETURN 1 -- Usuario y contraseña válidos
        END
    END

    -- Creación de Usuarios (tu código actual)
    IF @Option = 2
    BEGIN
        INSERT INTO Usuarios (Email, Contrasena)
        VALUES (@Email, PWDENCRYPT(@Password))
        RETURN 0
    END

END

RETURN 0