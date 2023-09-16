using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetApp
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Obtén los valores de los campos de texto.
            string username = txtUser.Text;
            string password = txtPass.Text;
            string verification = TxTVeri.Text;

            // Verifica si los campos están vacíos.
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(verification))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return; // Sal del método si falta información.
            }

            // Verifica si la contraseña y la verificación coinciden.
            if (password != verification)
            {
                MessageBox.Show("La contraseña y la verificación no coinciden. Por favor, verifique.");
                return; // Sal del método si la contraseña y la verificación no coinciden.
            }

            using (var db = new PetAppContext())
            {
                // Verifica si el usuario con el correo electrónico proporcionado existe en la base de datos.
                var usuarioExistente = db.Usuarios.FirstOrDefault(u => u.Email == username);

                if (usuarioExistente == null)
                {
                    MessageBox.Show("El usuario con el correo electrónico proporcionado no existe.");
                    return; // Sal del método si el usuario no existe.
                }

                // Crea parámetros para el procedimiento almacenado.
                var option = new SqlParameter("@Option", 1);
                var usernameParam = new SqlParameter("@Email", username);

                // No es necesario convertir la contraseña a UTF-16, simplemente pásala como texto.
                var passwordParam = new SqlParameter("@Contrasena", password);

                // Ejecuta el procedimiento almacenado para autenticar al usuario.
                var respuesta = db.Database.SqlQuery<int>("exec sp_Login @Option, @Email, @Contrasena", option, usernameParam, passwordParam).SingleOrDefault();

                // Maneja el resultado de la autenticación.
                if (respuesta == 1)
                {
                    MessageBox.Show("Inicio de sesión correcto");

                    // Despliega el formulario principal solo cuando el inicio de sesión es exitoso.
                    var frmMain = new frmMain();
                    this.Hide();
                    frmMain.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecta");
                }
            }
        }
    }
}