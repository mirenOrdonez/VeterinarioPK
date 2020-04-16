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
    public partial class VentanaPrincipal : Form
    {
        Conexion conexion = new Conexion();
        DataTable misDatos = new DataTable();
        

        public VentanaPrincipal()
        {
            InitializeComponent();
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

        public void muestraDatos(String usuario)
        {
            misDatos = conexion.datosCliente(usuario);
            nombre.Text = misDatos.Rows[0]["nombre"].ToString();
            pictureBox1.Image = convierteBlobAImagen((byte[])misDatos.Rows[0]["imagen"]);
        }
    }
}
