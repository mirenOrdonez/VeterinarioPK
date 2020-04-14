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
    public partial class VentanaRegistro : Form
    {
        Conexion conexion = new Conexion();

        public VentanaRegistro()
        {
            InitializeComponent();
        }

        private void registrar_Click(object sender, EventArgs e)
        {

            if (conexion.registraUsuario(dni.Text, nombreCliente.Text, apellido1.Text, apellido2.Text,
                direccion.Text, telefono.Text, email.Text, usuario.Text, password.Text))
            {
                MessageBox.Show("Registro completado. Debe validarse la cuenta para poder ingresar.");
                this.Hide();
                VentanaLogin v = new VentanaLogin();
                v.Show();
            }
        }
    }
}
