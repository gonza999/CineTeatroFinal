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
    public partial class TiposDeEventosFrm : Form
    {
        public TiposDeEventosFrm(ITiposDeEventosServicios servicio)
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


        private readonly ITiposDeEventosServicios _servicio;
        private List<TipoEvento> lista;
        private int cantidadRegistros;
        private void TiposDeEventosFrm_Load(object sender, EventArgs e)
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
            foreach (var tipoEvento in lista)
            {
                DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);

                HelperGrid.SetearFila(r, tipoEvento);
                HelperGrid.AgregarFila(DatosDataGridView, r);
            }
            HelperForm.MostrarInfoPaginas(splitContainer1.Panel2, cantidadRegistros, cantidadPaginas, paginaActual);
        }




        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            //FrmPaisesEdit frm = new FrmPaisesEdit(_servicio) { Text = "Nuevo País" };
            //DialogResult dr = frm.ShowDialog(this);
            //RecargarGrilla();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            //if (DatosDataGridView.SelectedRows.Count == 0)
            //{
            //    return;
            //}

            //DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            //Pais pais = (Pais)r.Tag;
            //FrmPaisesEdit frm = new FrmPaisesEdit(_servicio) { Text = "Editar País" };
            //frm.SetTipo(pais);
            //DialogResult dr = frm.ShowDialog(this);
            //MostrarPaginado(cantidadPaginas, paginaActual);
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            //if (DatosDataGridView.SelectedRows.Count == 0)
            //{
            //    return;
            //}

            //DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            //Pais pais = (Pais)r.Tag;
            //DialogResult dr = MessageBox.Show($"¿Desea dar de baja el registro de {pais.NombrePais}?",
            //    "Confirmar Baja",
            //    MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question,
            //    MessageBoxDefaultButton.Button2);
            //if (dr == DialogResult.No)
            //{
            //    return;
            //}

            //try
            //{
            //    _servicio.Borrar(pais.PaisId);
            //    HelperGrid.BorrarFila(DatosDataGridView, r);

            //    cantidadRegistros = _servicio.GetCantidad();
            //    CantidadDeRegistrosLabel.Text = cantidadRegistros.ToString();

            //    MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show(@"Registro relacionado... Baja denegada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var listaGrupos = _servicio.GetGrupos();
            //    FrmCiudadesPorPais frm = new FrmCiudadesPorPais(DI.Create<IPaisesServicios>()) { Text = "Cant. de Ciudades por Países" };
            //    frm.SetGrupo(listaGrupos);
            //    frm.ShowDialog(this);

            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine(exception);
            //    throw;
            //}
        }

        //private void tsbImprimir_Click(object sender, EventArgs e)
        //{
        //    ReportePaises rpt = DI.Create<IManejadorDeReportes>().GetReportePaises(lista);
        //    FrmVisorReportes frm = new FrmVisorReportes();
        //    frm.SetReporte(rpt);
        //    frm.ShowDialog(this);

        //}

   
    }
}
