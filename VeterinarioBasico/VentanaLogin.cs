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
    public partial class VentanaLogin : Form
    {
        Conexion conexion = new Conexion();

        public VentanaLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conexion.loginCliente(username.Text, password.Text))
            {
                this.Hide();
                VentanaPrincipal v = new VentanaPrincipal();
                v.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña erróneos.");
            }
            
            
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked = true)
            {
                password.UseSystemPasswordChar = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VentanaRegistro v = new VentanaRegistro();
            v.Show();
        }
    }
}
