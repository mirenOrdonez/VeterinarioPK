using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeterinarioBasico
{
    public partial class VentanaLogin : Form
    {
        Conexion conexion = new Conexion();
        DataTable misDatos = new DataTable();


        public VentanaLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conexion.loginCliente(username.Text, password.Text))
            {
                this.Hide();
                VentanaPrincipalCliente v = new VentanaPrincipalCliente(username.Text);
                v.Show();
            }
            else if (conexion.loginTrabajador(username.Text, password.Text))
            {
                this.Hide();
                VentanaPrincipalTrabajador v = new VentanaPrincipalTrabajador();
                v.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña erróneos.");
            }
            
        }

        //Para que se muestre la contraseña o no.
        private void button3_Click(object sender, EventArgs e)
        {
            if (password.UseSystemPasswordChar == false)
            {
                password.UseSystemPasswordChar = true;
            }
            else
            {
                password.UseSystemPasswordChar = false;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VentanaRegistro v = new VentanaRegistro();
            v.Show();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
