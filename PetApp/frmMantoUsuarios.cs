using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetApp
{
    public partial class frmMantoUsuarios : Form
    {
        public frmMantoUsuarios()
        {
            InitializeComponent();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {




            if (grpEdit.Visible == true)
            {
                grpEdit.Visible = false;
                btnEditar.Text = "Editar";
            }
            else
            {
                grpEdit.Visible = true;
                btnEditar.Text = "Cancelar";
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            grpEdit.Visible = false;
            btnEditar.Text = "Editar";

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void grdData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmMantoUsuarios_Load(object sender, EventArgs e)
        {

            using (var db = new PetAppContext())
            {
                // Consulta los usuarios desde la base de datos
                var usuarios = db.Usuarios.ToList();

                // Configura el origen de datos del DataGridView
                grdData.DataSource = usuarios;


            }
        }
    }
}