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
    public partial class VentanaPrincipalTrabajador : Form
    {
        Conexion conexion = new Conexion();
        DataTable datosTrabajador = new DataTable();
        public VentanaPrincipalTrabajador()
        {
            InitializeComponent();
        }

        //Método para que se cierre la aplicación cuando se cierre la V.ppal
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            Application.Exit();
        }

        public void mostrarDatosTrabajador()
        {

        }
    }
}
