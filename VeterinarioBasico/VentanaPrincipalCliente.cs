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

        public VentanaPrincipalCliente(String clienteQueHaceLogin)
        {
            InitializeComponent();
            usuarioLogin = clienteQueHaceLogin;
            muestraDatosCliente();
            muestraDatosMascota();
            dataGridView1.DataSource = conexion.citasCliente(clienteQueHaceLogin);
            //Para ajustar las dimensiones de la tabla
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

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

        //Método para el TABCONTROL "Mi perfil"
        private void muestraDatosCliente()
        {
            misDatos = conexion.datosCliente(usuarioLogin);
            nombre.Text = misDatos.Rows[0]["nombreCliente"].ToString();
            pictureBox1.Image = convierteBlobAImagen((byte[])misDatos.Rows[0]["imagenCliente"]);
            apellido1.Text = misDatos.Rows[0]["apellido1Cliente"].ToString();
            apellido2.Text = misDatos.Rows[0]["apellido2Cliente"].ToString();
            email.Text = misDatos.Rows[0]["emailCliente"].ToString();
            direccion.Text = misDatos.Rows[0]["direccionCliente"].ToString();
        }

        //Método para el TABCONTROL "Mi mascota"
        private void muestraDatosMascota()
        {
            miMascota = conexion.datosMascota(usuarioLogin);
            nombreMascota.Text = miMascota.Rows[0]["nombreMascota"].ToString();
            tipoMascota.Text = miMascota.Rows[0]["especieMascota"].ToString();
            razaMascota.Text = miMascota.Rows[0]["razaMascota"].ToString();
            fecNacMascota.Text = miMascota.Rows[0]["fecNacMascota"].ToString();
            pictureBox2.Image = convierteBlobAImagen((byte[])miMascota.Rows[0]["imagenMascota"]);
        }


        //Botón para suscripción revista.
        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Suscripción realizada correctamente. Se enviará mensualmente nuestra revista a su domicilio.");
        }

        //Botón que lleva a form para el pago. 
        private void button7_Click(object sender, EventArgs e)
        {
            VentanaPago v = new VentanaPago();
            v.Show();
        }

        //Botón que lleva al form para nueva cita.
        private void button4_Click(object sender, EventArgs e)
        {
            VentanaNuevaCita v = new VentanaNuevaCita();
            v.Show();
        }

        //Abre FORM para agregar mascota.
        private void button5_Click(object sender, EventArgs e)
        {
            VentanaAgregarMascota v = new VentanaAgregarMascota();
            v.Show();
        }

        //Para las facturas.
        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Todavía no existe ningún pago realizado.");
        }
    }
}
