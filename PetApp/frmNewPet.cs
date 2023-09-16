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
    public partial class frmNewPet : Form
    {
        public frmNewPet()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtén los valores ingresados en los campos de texto y controles de fecha.
            string alias = txtAlias.Text;
            string especie = txtespecie.Text;
            string raza = txtRaza.Text;
            string color = txtColor.Text;
            DateTime fechaNacimiento = dtFechaNacimiento.Value;

            // Verifica si alguno de los campos obligatorios está vacío.
            if (string.IsNullOrEmpty(alias) || string.IsNullOrEmpty(especie) || string.IsNullOrEmpty(raza) 
                || string.IsNullOrEmpty(color))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método si faltan campos obligatorios.
            }

            // A continuación, puedes usar estos valores para crear una nueva mascota
            // y agregarla a tu base de datos o realizar otras acciones necesarias.
            // Por ejemplo:

            using (var db = new PetAppContext())
            {
                var nuevaMascota = new Mascota()
                {
                    Alias = alias,
                    Especie = especie,
                    Raza = raza,
                    ColorPelo = color,
                    FechaNacimiento = fechaNacimiento
                };

                db.Mascota.Add(nuevaMascota);
                db.SaveChanges();

                MessageBox.Show("Nueva mascota registrada exitosamente.");
            }

            // Limpia los campos de texto después de guardar la mascota.
            txtAlias.Clear();
            txtespecie.Clear();
            txtRaza.Clear();
            txtColor.Clear();
            dtFechaNacimiento.Value = DateTime.Now; // Puedes configurar la fecha actual o algún valor predeterminado.
        }
    }
}

