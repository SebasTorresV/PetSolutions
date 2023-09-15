using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

            using (var db = new PetAppContext())
            {
                // Convierte la contraseña de texto claro en bytes utilizando UTF-8.
                byte[] contraseñaBytes = Encoding.UTF8.GetBytes(contraseñaTextoClaro1);

                var nuevoUsuario = new Usuarios()
                {
                    Email = txtEmail.Text,
                    Contrasena = contraseñaBytes // Almacena la contraseña como bytes.
                };

                db.Usuarios.Add(nuevoUsuario);
                db.SaveChanges();

                MessageBox.Show("Nuevo usuario registrado exitosamente.");
                //LOs TextBox quedan en blanco para poder agregar otro usuario
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
