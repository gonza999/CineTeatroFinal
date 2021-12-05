using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineTeatroItalianoLobos.UI.Forms
{
    public partial class TicketLocalidadDetalleFrm : Form
    {
        private Localidad localidad;
        public TicketLocalidadDetalleFrm(Localidad localidad)
        {
            InitializeComponent();
            this.localidad = localidad;
        }

        private void TicketLocalidadDetalleFrm_Load(object sender, EventArgs e)
        {
            PlantaLbl.Text = localidad.Planta.Descripcion;
            UbicacionLbl.Text = localidad.Ubicacion.Descripcion;
            FilaLbl.Text = localidad.Fila.ToString();
            NumeroLbl.Text = localidad.Numero.ToString();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
