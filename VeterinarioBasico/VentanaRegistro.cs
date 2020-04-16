using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

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
            //Pasamos la contraseña por el BCrypt para que en la BBDD no se pueda leer.
            String textoPassword = password.Text;
            string myHash = BCrypt.Net.BCrypt.HashPassword(textoPassword, BCrypt.Net.BCrypt.GenerateSalt());
            if (conexion.registraUsuario(dni.Text, nombreCliente.Text, apellido1.Text, apellido2.Text,
                direccion.Text, telefono.Text, email.Text, usuario.Text, myHash))
            {
                
                MessageBox.Show("Registro completado. Debe validarse la cuenta para poder ingresar.");
                this.Hide();
                VentanaLogin v = new VentanaLogin();
                v.Show();
            }
        }
    }
}
