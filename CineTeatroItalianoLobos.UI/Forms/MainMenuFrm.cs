using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.UI.Forms;
using CineTeatroItalianoLobos.UI.Ninject;
using System;
using System.Windows.Forms;

namespace CineTeatroItalianoLobos.UI
{
    public partial class MainMenuFrm : Form
    {
        public MainMenuFrm()
        {
            InitializeComponent();
        }

        private void tiposDeEventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TiposDeEventosFrm frm = new TiposDeEventosFrm(DI.Create<ITiposDeEventosServicios>());
            frm.ShowDialog(this);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
