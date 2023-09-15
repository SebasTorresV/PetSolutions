CREATE PROCEDURE [dbo].[sp_Login]
    @Option int = 0,
    @Email nvarchar(200),
    @Password nvarchar(70)
AS
    --Login
    if @Option=1
            begin
                Select count(*) from
            Usuarios
            Where @Email = @Email
    and PWDCOMPARE(@Password,Contrasena) = 1

    End

    --Creación de Usuarios
    if @Option=2
        Begin
        insert into Usuarios
        (Email,Contrasena)
        values(@Email,PWDENCRYPT(@Password))
        End

RETURN 0