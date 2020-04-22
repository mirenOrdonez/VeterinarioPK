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
    public partial class VentanaPrincipalTrabajador : Form
    {
        Conexion conexion = new Conexion();
        DataTable misDatos = new DataTable();

        String usuarioLogin;
        public VentanaPrincipalTrabajador(String trabajadorQueHaceLogin)
        {
            InitializeComponent();
            usuarioLogin = trabajadorQueHaceLogin;
            mostrarDatosTrabajador();
        }

        //Método para que se cierre la aplicación cuando se cierre la V.ppal
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            Application.Exit();
        }

        private Image convierteBlobAImagen(byte[] img)
        {
            MemoryStream ms = new System.IO.MemoryStream(img);
            return (Image.FromStream(ms));
        }

        public void mostrarDatosTrabajador()
        {
            misDatos = conexion.datosTrabajador(usuarioLogin);
            pictureBox1.Image = convierteBlobAImagen((byte[])misDatos.Rows[0]["imagenTrabajador"]);
            nombreTrabajador.Text = misDatos.Rows[0]["nombreTrabajador"].ToString();
            apellido1Trabajador.Text = misDatos.Rows[0]["apellido1Trabajador"].ToString();
            apellido2Trabajador.Text = misDatos.Rows[0]["apellido2Trabajador"].ToString();
        }
    }
}
