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
    public partial class ListaLocalidadesFrm : Form
    {
        public ListaLocalidadesFrm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {

            ClosePbx.BorderStyle = BorderStyle.Fixed3D;
        }

        private void ClosePbx_MouseLeave(object sender, EventArgs e)
        {
            ClosePbx.BorderStyle = BorderStyle.FixedSingle;
        }

        private void ListaLocalidadesFrm_Load(object sender, EventArgs e)
        {
            HelperCombos.CargarDatosComboEventos(ref EventoCmb);
        }

        private void EventoCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EventoCmb.SelectedIndex!=0)
            {
                HorarioCmb.Enabled = true;
            }
            else
            {
                HorarioCmb.Enabled = false;
            }
        }
    }
}
