using CineTeatroItalianoLobos.Entities;
using CineTeatroItalianoLobos.Services.Facades;
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
    public partial class TicketsFrm : Form
    {
        public TicketsFrm(ITicketsServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        private Venta venta = null;
        public TicketsFrm(ITicketsServicio servicio, Venta venta)
        {
            InitializeComponent();
            _servicio = servicio;
            this.venta = venta;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        const int cantidadPorPagina = 20;

        private int cantidadPaginas;
        private int paginaActual;


        private readonly ITicketsServicio _servicio;
        private List<Ticket> lista;
        private int cantidadRegistros;
        private void TicketsFrm_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
            if (venta != null)
            {
                Filtrar(venta);
            }
        }
        private void AsignarEventHandler(Panel botonesPanel)
        {
            foreach (var control in botonesPanel.Controls)
            {
                if (control is Button)
                {
                    ((Button)control).Click += Miclick;
                }
            }
        }

        private void RecargarGrilla()
        {
            try
            {
                cantidadRegistros = _servicio.GetCantidad();

                cantidadPaginas = HelperCalculos.CalcularCantidadDePaginas(cantidadRegistros, cantidadPorPagina);
                HelperForm.CrearBotonesPaginas(BotonesPanel, cantidadPaginas);
                AsignarEventHandler(BotonesPanel);
                paginaActual = 1;
                MostrarPaginado(cantidadPorPagina, paginaActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Miclick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            paginaActual = int.Parse(b.Text);
            MostrarPaginado(cantidadPorPagina, paginaActual);
        }

        private void MostrarPaginado(int cantidadPorPagina, int paginaActual)
        {
            lista = _servicio.GetLista(cantidadPorPagina, paginaActual);
            MostrarDatosEnGrilla();

        }
        private void MostrarDatosEnGrilla()
        {
            HelperGrid.LimpiarGrilla(DatosDataGridView);
            foreach (var ticket in lista)
            {
                DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);

                SetearFila(r, ticket);
                HelperGrid.AgregarFila(DatosDataGridView, r);
            }
            HelperForm.MostrarInfoPaginas(splitContainer1.Panel2, cantidadRegistros, cantidadPaginas, paginaActual);
        }

        private void SetearFila(DataGridViewRow r, Ticket ticket)
        {
            r.Cells[cmnEvento.Index].Value = ticket.Horario.Evento.NombreEvento;
            r.Cells[cmnFecha.Index].Value = ticket.FechaVenta.Year + "/" +
                ticket.FechaVenta.Month + "/" +
                ticket.FechaVenta.Day + " " + ticket.FechaVenta.Hour+":"+ticket.FechaVenta.Minute;
            r.Cells[cmnImporte.Index].Value = ticket.Importe;
            r.Cells[cmnLocalidad.Index].Value = new Button().Text="Detalles";
            r.Cells[cmnAnulada.Index].Value = ticket.Anulada;

            r.Tag = ticket;
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            TicketsFiltrarFrm frm = new TicketsFiltrarFrm();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                var evento = frm.GetEvento();
                Filtrar(evento);
            }
        }

        private void Filtrar(Evento evento)
        {
            lista = _servicio.GetLista(evento);
            cantidadRegistros = lista.Count();
            HelperForm.CrearBotonesPaginas(BotonesPanel, 0);
            paginaActual = 1;

            MostrarDatosEnGrilla();
        }
        private void Filtrar(Venta venta)
        {
            lista = _servicio.GetLista(venta);
            cantidadRegistros = lista.Count();
            HelperForm.CrearBotonesPaginas(BotonesPanel, 0);
            paginaActual = 1;

            MostrarDatosEnGrilla();
        }
        private void DatosDataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                Ticket t = (Ticket)r.Tag;
                TicketLocalidadDetalleFrm frm = new TicketLocalidadDetalleFrm(t.Localidad);
                frm.ShowDialog();
            }
        }
    }
}
