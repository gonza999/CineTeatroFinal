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
    public partial class LocalidadesFiltrarFrm : Form
    {
        public LocalidadesFiltrarFrm()
        {
            InitializeComponent();
        }
        private Planta planta = null;
        private Ubicacion ubicacion = null;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HelperCombos.CargarDatosComboPlantas(ref PlantaCmb);
            HelperCombos.CargarDatosComboUbicacion(ref UbicacionCmb);
        }
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (PlantaCmb.SelectedIndex!=0)
            {
                planta = (Planta)PlantaCmb.SelectedItem;
            }
            if (UbicacionCmb.SelectedIndex != 0)
            {
                ubicacion = (Ubicacion)UbicacionCmb.SelectedItem;
            }
            DialogResult = DialogResult.OK;
        }
        public Planta GetPlanta()
        {
            return planta;
        }
        public Ubicacion GetUbicacion()
        {
            return ubicacion;
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
