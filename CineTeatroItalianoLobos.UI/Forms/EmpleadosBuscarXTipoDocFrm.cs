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
    public partial class EmpleadosBuscarXTipoDocFrm : Form
    {
        public EmpleadosBuscarXTipoDocFrm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HelperCombos.CargarDatosComboTipoDocumentos(ref TipoDocumentoCmb);
        }
        public string filtro;
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (TipoDocumentoCmb.SelectedIndex!=0)
            {
                var tipoDoc = (TipoDocumento)TipoDocumentoCmb.SelectedItem;
                filtro = tipoDoc.Descripcion;
                DialogResult = DialogResult.OK;
            }
            else
            {
                errorProvider1.Clear();
                errorProvider1.SetError(TipoDocumentoCmb,"Debe seleccionar un tipo de documento");
            }
        }
        public string GetFiltro()
        {
            return filtro;
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
