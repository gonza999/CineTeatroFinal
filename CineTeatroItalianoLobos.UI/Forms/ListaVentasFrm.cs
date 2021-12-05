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
    public partial class ListaVentasFrm : Form
    {
        public ListaVentasFrm(IVentasServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        const int cantidadPorPagina = 20;
        private bool filtroOn = false;

        private int cantidadPaginas;
        private int paginaActual;


        private readonly IVentasServicio _servicio;
        private List<Venta> lista;
        private int cantidadRegistros;
        private void VentasFrm_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
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
            foreach (var venta in lista)
            {
                DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);

                SetearFila(r, venta);
                HelperGrid.AgregarFila(DatosDataGridView, r);
            }
            HelperForm.MostrarInfoPaginas(splitContainer1.Panel2, cantidadRegistros, cantidadPaginas, paginaActual);
        }

        private void SetearFila(DataGridViewRow r, Venta venta)
        {

            r.Cells[0].Value = venta.Fecha.Year + "/" +
                venta.Fecha.Month + "/" +
                venta.Fecha.Day; ;
            r.Cells[1].Value = venta.VentasTickets.Count();
            r.Cells[2].Value = new Button().Text = "Detalles";
            var nombreEvento = "";
            foreach (var vt in venta.VentasTickets)
            {
                nombreEvento=vt.Ticket.Horario.Evento.NombreEvento;
            }
            r.Cells[3].Value = nombreEvento;
            r.Cells[4].Value = venta.Total.ToString("c");
            r.Cells[5].Value = venta.Empleado.Apellido + " " + venta.Empleado.Nombre;
            r.Cells[6].Value = venta.Estado;
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            ListaVentasFiltrarFrm frm = new ListaVentasFiltrarFrm();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                var empleado = frm.GetEmpleado();
                lista = _servicio.GetLista(empleado);
                cantidadRegistros = lista.Count();
                HelperForm.CrearBotonesPaginas(BotonesPanel, 0);
                paginaActual = 1;

                MostrarDatosEnGrilla();
            }
        }
    }
}
