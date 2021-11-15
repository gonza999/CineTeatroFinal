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
    public partial class HorariosBuscarXEventoFrm : Form
    {
        public HorariosBuscarXEventoFrm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HelperCombos.CargarDatosComboEventos(ref EventoCmb);
        }
        private Evento evento;
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (EventoCmb.SelectedIndex != 0)
            {
                evento = (Evento)EventoCmb.SelectedItem;
                DialogResult = DialogResult.OK;
            }
            else
            {
                errorProvider1.Clear();
                errorProvider1.SetError(EventoCmb, "Debe seleccionar un evento");
            }
        }
        public Evento GetEvento()
        {
            return evento;
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
