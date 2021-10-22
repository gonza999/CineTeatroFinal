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
    public partial class EmpleadosFrm : Form
    {
        public EmpleadosFrm(IEmpleadosServicio servicio)
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


        private readonly IEmpleadosServicio _servicio;
        private List<Empleado> lista;
        private int cantidadRegistros;
        private void EmpleadosFrm_Load(object sender, EventArgs e)
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
            foreach (var empleado in lista)
            {
                DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);

                HelperGrid.SetearFila(r, empleado);
                HelperGrid.AgregarFila(DatosDataGridView, r);
            }
            HelperForm.MostrarInfoPaginas(splitContainer1.Panel2, cantidadRegistros, cantidadPaginas, paginaActual);
        }




        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EmpleadosAEFrm frm = new EmpleadosAEFrm(_servicio) { Text = "Nueva Empleado" };
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
            Empleado empleado = (Empleado)r.Tag;
            EmpleadosAEFrm frm = new EmpleadosAEFrm(_servicio) { Text = "Editar Empleado" };
            frm.SetEmpleado(empleado);
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
            Empleado empleado = (Empleado)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el registro de {empleado.Nombre} {empleado.Apellido}?",
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
                if (!_servicio.EstaRelacionado(empleado))
                {
                    _servicio.Borrar(empleado.EmpleadoId);
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

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void EmpleadosFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (string.IsNullOrEmpty(BuscarTxt.Text)
                    || string.IsNullOrWhiteSpace(BuscarTxt.Text))
                {
                    return;
                }
                if (tsbBuscar.Text== "Buscar x Apellido")
                {
                    lista = _servicio.BuscarEmpleado(BuscarTxt.Text,0);
                }
                else if (tsbBuscar.Text == "Buscar x Nombre")
                {
                    lista = _servicio.BuscarEmpleado(BuscarTxt.Text, 1);
                }

                cantidadRegistros = lista.Count();

                HelperForm.CrearBotonesPaginas(BotonesPanel, 0);
                paginaActual = 1;

                MostrarDatosEnGrilla();


            }
        }

        private void BuscarXNombreTsb_Click(object sender, EventArgs e)
        {
            string ActualBuscarText = tsbBuscar.Text;
                tsbBuscar.Text = BuscarXNombreTsb.Text;
                BuscarXNombreTsb.Text = ActualBuscarText;
        }

        private void BuscarXTipoDocumentoTsb_Click(object sender, EventArgs e)
        {
            EmpleadosBuscarXTipoDocFrm frm = new EmpleadosBuscarXTipoDocFrm();
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.OK)
            {
                lista = _servicio.BuscarEmpleado(frm.GetFiltro(), 2);
                cantidadRegistros = lista.Count();

                HelperForm.CrearBotonesPaginas(BotonesPanel, 0);
                paginaActual = 1;

                MostrarDatosEnGrilla();
            }
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
