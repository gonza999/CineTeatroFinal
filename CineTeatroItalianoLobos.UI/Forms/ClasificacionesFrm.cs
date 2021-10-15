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
    public partial class ClasificacionesFrm : Form
    {
        public ClasificacionesFrm(IClasificacionesServicio servicio)
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


        private readonly IClasificacionesServicio _servicio;
        private List<Clasificacion> lista;
        private int cantidadRegistros;
        private void ClasificacionesFrm_Load(object sender, EventArgs e)
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
            foreach (var clasificacion in lista)
            {
                DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);

                HelperGrid.SetearFila(r, clasificacion);
                HelperGrid.AgregarFila(DatosDataGridView, r);
            }
            HelperForm.MostrarInfoPaginas(splitContainer1.Panel2, cantidadRegistros, cantidadPaginas, paginaActual);
        }




        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ClasificacionesAEFrm frm = new ClasificacionesAEFrm(_servicio) { Text = "Nueva Clasificacion" };
            DialogResult dr = frm.ShowDialog(this);
            RecargarGrilla();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            Clasificacion clasificacion = (Clasificacion)r.Tag;
            ClasificacionesAEFrm frm = new ClasificacionesAEFrm(_servicio) { Text = "Editar Clasificacion" };
            frm.SetClasificacion(clasificacion);
            DialogResult dr = frm.ShowDialog(this);
            RecargarGrilla();
            //MostrarPaginado(cantidadPaginas, paginaActual);
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            Clasificacion clasificacion = (Clasificacion)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el registro de {clasificacion.Descripcion}?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                if (!_servicio.EstaRelacionado(clasificacion))
                {
                    _servicio.Borrar(clasificacion.ClasificacionId);
                    HelperGrid.BorrarFila(DatosDataGridView, r);

                    cantidadRegistros = _servicio.GetCantidad();
                    CantidadDeRegistrosLabel.Text = cantidadRegistros.ToString();

                    MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(@"Registro relacionado... Baja denegada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            RecargarGrilla();
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
