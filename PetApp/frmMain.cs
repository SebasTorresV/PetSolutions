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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmNewUser = new frmNewUser();
            frmNewUser.MdiParent = this;
            frmNewUser.Show();
        }

        private void mascotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmNewPet = new frmNewPet();
            frmNewPet.MdiParent = this;
            frmNewPet.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmMantoUsuarios = new frmMantoUsuarios();
            frmMantoUsuarios.MdiParent = this;
            frmMantoUsuarios.Show();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmNewCustomer = new frmMantoUsuarios();
            frmNewCustomer.MdiParent = this;
            frmNewCustomer.Show();
        }
    }
}
