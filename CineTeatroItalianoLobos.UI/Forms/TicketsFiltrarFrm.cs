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
    public partial class TicketsFiltrarFrm : Form
    {
        public TicketsFiltrarFrm()
        {
            InitializeComponent();
        }
        private Evento evento = null;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HelperCombos.CargarDatosComboEventos(ref EventoCmb);
        }
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                evento = (Evento)EventoCmb.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }

        private bool Validar()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (EventoCmb.SelectedIndex == 0)
            {
                errorProvider1.SetError(EventoCmb, "Debe seleccionar un evento");
                valido = false;
            }
            return valido;
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

