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
    public partial class VentanaPrincipalCliente : Form
    {
        Conexion conexion = new Conexion();
        DataTable misDatos = new DataTable();
        DataTable miMascota = new DataTable();

        String usuarioLogin;

        public VentanaPrincipalCliente(String usuarioQueHaceLogin)
        {
            InitializeComponent();
            usuarioLogin = usuarioQueHaceLogin;
            muestraDatosCliente();
            muestraDatosMascota();

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

        public void muestraDatosCliente()
        {
            misDatos = conexion.datosCliente(usuarioLogin);
            nombre.Text = misDatos.Rows[0]["nombreCliente"].ToString();
            pictureBox1.Image = convierteBlobAImagen((byte[])misDatos.Rows[0]["imagenCliente"]);
            apellido1.Text = misDatos.Rows[0]["apellido1"].ToString();
            apellido2.Text = misDatos.Rows[0]["apellido2"].ToString();
            email.Text = misDatos.Rows[0]["email"].ToString();
            direccion.Text = misDatos.Rows[0]["direccion"].ToString();
        }

        public void muestraDatosMascota()
        {
            miMascota = conexion.datosMascota(usuarioLogin);
            nombreMascota.Text = miMascota.Rows[0]["nombreMascota"].ToString();
            tipoMascota.Text = miMascota.Rows[0]["tipo"].ToString();
            razaMascota.Text = miMascota.Rows[0]["raza"].ToString();
            fecNacMascota.Text = miMascota.Rows[0]["fecNacimiento"].ToString();
            pictureBox2.Image = convierteBlobAImagen((byte[])miMascota.Rows[0]["imagenMascota"]);
        }


        //Botón para suscripción revista.
        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Suscripción realizada correctamente. Se enviará mensualmente nuestra revista a su domicilio.");
        }
    }
}
