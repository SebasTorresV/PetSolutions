using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace PetApp
{
    public partial class frmNewUser : Form
    {
        public frmNewUser()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtén las contraseñas ingresadas en los campos de texto.
            string contraseñaTextoClaro1 = txtPass1.Text;
            string contraseñaTextoClaro2 = txtPass2.Text;

            // Verifica si las contraseñas coinciden.
            if (contraseñaTextoClaro1 != contraseñaTextoClaro2)
            {
                MessageBox.Show("Las contraseñas no coinciden. Por favor, verifique.");
                return; // Salir del método si las contraseñas no coinciden.
            }

            // Validar formato de correo electrónico utilizando una expresión regular.
            string correoElectronico = txtEmail.Text.Trim();
            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            if (!Regex.IsMatch(correoElectronico, emailPattern))
            {
                MessageBox.Show("Formato de correo electrónico no válido. Por favor, ingrese un correo electrónico válido.");
                return; // Salir del método si el formato del correo electrónico es inválido.
            }

            using (var db = new PetAppContext())
            {
                // Convierte la contraseña de texto claro en bytes utilizando UTF-8.
                byte[] contraseñaBytes = Encoding.UTF8.GetBytes(contraseñaTextoClaro1);

                var nuevoUsuario = new Usuarios()
                {
                    Email = correoElectronico, // Utiliza el correo electrónico validado.
                    Contrasena = contraseñaBytes // Almacena la contraseña como bytes.
                };

                db.Usuarios.Add(nuevoUsuario);
                db.SaveChanges();

                MessageBox.Show("Nuevo usuario registrado exitosamente.");

                // Los TextBox quedan en blanco para poder agregar otro usuario
                txtEmail.Text = "";
                txtPass1.Text = "";
                txtPass2.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}