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
    public partial class HorariosFrm : Form
    {
        private readonly IEventosServicios _servicioEventos;
        private Evento evento = null;
        public HorariosFrm(IHorariosServicio servicio, IEventosServicios servicioEventos,
            Evento evento = null)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioEventos = servicioEventos;
            this.evento = evento;
        }
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        const int cantidadPorPagina = 20;
        private bool filtroOn = false;

        private int cantidadPaginas;
        private int paginaActual;


        private readonly IHorariosServicio _servicio;
        private List<Horario> lista;
        private int cantidadRegistros;
        private void HorariosFrm_Load(object sender, EventArgs e)
        {
            if (evento == null)
            {
                RecargarGrilla();
            }
            else
            {
                lista = _servicio.BuscarHorario(evento.EventoId);
                cantidadRegistros = lista.Count();

                HelperForm.CrearBotonesPaginas(BotonesPanel, 0);
                paginaActual = 1;

                MostrarDatosEnGrilla();
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
            foreach (var horario in lista)
            {
                DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);

                SetearFila(r, horario);
                HelperGrid.AgregarFila(DatosDataGridView, r);
            }
            HelperForm.MostrarInfoPaginas(splitContainer1.Panel2, cantidadRegistros, cantidadPaginas, paginaActual);
        }

        private void SetearFila(DataGridViewRow r, Horario horario)
        {
            r.Cells[cmnEvento.Index].Value = horario.Evento.NombreEvento;
            r.Cells[cmnFecha.Index].Value = horario.Fecha.Year+"/"+
                horario.Fecha.Month + "/"+
                horario.Fecha.Day;
            r.Cells[cmnHora.Index].Value = horario.Hora.TimeOfDay.Hours + ":" +
                       horario.Hora.TimeOfDay.Minutes + ":" +
                        horario.Hora.TimeOfDay.Seconds;
            r.Tag = horario;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EventosFrm frm = new EventosFrm(_servicioEventos, _servicio) { Text = "Eventos" };
            DialogResult dr = frm.ShowDialog(this);
            RecargarGrilla();
        }
        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            Horario horario = (Horario)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el registro?",
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
                if (!_servicio.EstaRelacionado(horario))
                {
                    _servicio.Borrar(horario.HorarioId);
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
        private void BuscarXEventoTsb_Click(object sender, EventArgs e)
        {
            HorariosBuscarXEventoFrm frm = new HorariosBuscarXEventoFrm();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                lista = _servicio.BuscarHorario(frm.GetEvento().EventoId);
                cantidadRegistros = lista.Count();

                HelperForm.CrearBotonesPaginas(BotonesPanel, 0);
                paginaActual = 1;

                MostrarDatosEnGrilla();
            }
        }
    }
}
