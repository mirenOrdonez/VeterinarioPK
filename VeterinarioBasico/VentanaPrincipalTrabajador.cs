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
            dataGridView1.DataSource = conexion.buscarMascota();
            dataGridView2.DataSource = conexion.citasTrabajador(trabajadorQueHaceLogin);
            //Para ajustar las dimensiones de la tabla
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
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

        //Método que muestra los datos del trabajador. TABCONTROL 1= "MI PERFIL"
        public void mostrarDatosTrabajador()
        {
            misDatos = conexion.datosTrabajador(usuarioLogin);
            pictureBox1.Image = convierteBlobAImagen((byte[])misDatos.Rows[0]["imagenTrabajador"]);
            nombreTrabajador.Text = misDatos.Rows[0]["nombreTrabajador"].ToString();
            apellido1Trabajador.Text = misDatos.Rows[0]["apellido1Trabajador"].ToString();
            apellido2Trabajador.Text = misDatos.Rows[0]["apellido2Trabajador"].ToString();
        }

        //Muestra los datos de la mascota seleccionada en el buscador. 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nombreMascota.Text = dataGridView1.Rows[e.RowIndex].Cells["nombreMascota"].Value.ToString();
            pictureBox5.Image = convierteBlobAImagen((byte[])dataGridView1.Rows[e.RowIndex].Cells["imagenMascota"].Value);
            razaMascota.Text = dataGridView1.Rows[e.RowIndex].Cells["razaMascota"].Value.ToString();
            especieMascota.Text = dataGridView1.Rows[e.RowIndex].Cells["especieMascota"].Value.ToString();
            colorMascota.Text = dataGridView1.Rows[e.RowIndex].Cells["colorMascota"].Value.ToString();
            fecNacMascota.Text = dataGridView1.Rows[e.RowIndex].Cells["fecNacMascota"].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            VentanaAgregarMascota v = new VentanaAgregarMascota();
            v.Show();
        }
    }
}
