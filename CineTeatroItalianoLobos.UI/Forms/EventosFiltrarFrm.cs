using CineTeatroItalianoLobos.Entities;
using CineTeatroItalianoLobos.UI.Helpers;
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
    public partial class EventosFiltrarFrm : Form
    {
        public EventosFiltrarFrm()
        {
            InitializeComponent();
        }
        private Distribucion distribucion = null;
        private TipoEvento tipoEvento = null;
        private Clasificacion clasificacion = null;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HelperCombos.CargarDatosComboDistribucion(ref DistribucionCmb);
            HelperCombos.CargarDatosComboTipoEventos(ref TipoEventoCmb);
            HelperCombos.CargarDatosComboClasificacion(ref ClasificacionCmb);
        }
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (DistribucionCmb.SelectedIndex != 0)
            {
                distribucion = (Distribucion)DistribucionCmb.SelectedItem;
            }
            if (TipoEventoCmb.SelectedIndex != 0)
            {
                tipoEvento = (TipoEvento)TipoEventoCmb.SelectedItem;
            }
            if (ClasificacionCmb.SelectedIndex != 0)
            {
                clasificacion = (Clasificacion)ClasificacionCmb.SelectedItem;
            }
            DialogResult = DialogResult.OK;
        }
        public Distribucion GetDistribucion()
        {
            return distribucion;
        }
        public TipoEvento GetTipoEvento()
        {
            return tipoEvento;
        }
        public Clasificacion GetClasificacion()
        {
            return clasificacion;
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
