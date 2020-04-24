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
    public partial class VentanaNuevaCita : Form
    {
        public VentanaNuevaCita()
        {
            InitializeComponent();
        }

        private void servicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool is_activated = servicio.GetItemChecked(1);
            string valor = servicio.GetItemText(1);

        }
    }
}
