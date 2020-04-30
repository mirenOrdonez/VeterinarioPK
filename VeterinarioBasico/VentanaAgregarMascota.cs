using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeterinarioBasico
{
    public partial class VentanaAgregarMascota : Form
    {
        Conexion conexion = new Conexion();
        public VentanaAgregarMascota()
        {
            InitializeComponent();
        }

        private void registrar_Click(object sender, EventArgs e)
        {
            if (conexion.registraMascota(nombreMascota.Text, especieMascota.Text, razaMascota.Text,
                colorMascota.Text, fecNacMascota.Text))
            {

                MessageBox.Show("Registro completado.");
                this.Hide();
            }
        }
    }
}
