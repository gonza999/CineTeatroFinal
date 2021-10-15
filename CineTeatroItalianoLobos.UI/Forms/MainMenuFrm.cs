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

        private void clasificacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClasificacionesFrm frm = new ClasificacionesFrm(DI.Create<IClasificacionesServicio>());
            frm.ShowDialog(this);
        }

        private void ubicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UbicacionesFrm frm = new UbicacionesFrm(DI.Create<IUbicacionesServicio>());
            frm.ShowDialog(this);
        }

        private void formasDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormasVentasFrm frm = new FormasVentasFrm(DI.Create<IFormasVentasServicio>());
            frm.ShowDialog(this);
        }
    }
}
