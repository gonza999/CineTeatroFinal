﻿using CineTeatroItalianoLobos.Entities;
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
    public partial class EventosFrm : Form
    {
        private readonly IHorariosServicio _servicioHorarios;
        public EventosFrm(IEventosServicios servicio,IHorariosServicio servicioHorarios)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioHorarios = servicioHorarios;
        }
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
           Close();
        }
        const int cantidadPorPagina = 20;
        private bool filtroOn = false;

        private int cantidadPaginas;
        private int paginaActual;


        private readonly IEventosServicios _servicio;
        private List<Evento> lista;
        private int cantidadRegistros;
        private void EventosFrm_Load(object sender, EventArgs e)
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
            foreach (var evento in lista)
            {
                DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);

                HelperGrid.SetearFila(r, evento);
                HelperGrid.AgregarFila(DatosDataGridView, r);
            }
            HelperForm.MostrarInfoPaginas(splitContainer1.Panel2, cantidadRegistros, cantidadPaginas, paginaActual);
        }
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EventosAEFrm frm = new EventosAEFrm(_servicio,_servicioHorarios) { Text = "Nueva Evento" };
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
            Evento evento = (Evento)r.Tag;
            EventosAEFrm frm = new EventosAEFrm(_servicio,_servicioHorarios) { Text = "Editar Evento" };
            frm.SetEvento(evento);
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
            Evento evento = (Evento)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el registro de {evento.NombreEvento}?",
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
                if (!_servicio.EstaRelacionado(evento))
                {
                    _servicio.Borrar(evento.EventoId);
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

        private void EventosFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (string.IsNullOrEmpty(BuscarTxt.Text)
                    || string.IsNullOrWhiteSpace(BuscarTxt.Text))
                {
                    return;
                }
                lista = _servicio.BuscarEvento(BuscarTxt.Text);

                cantidadRegistros = lista.Count();

                HelperForm.CrearBotonesPaginas(BotonesPanel, 0);
                paginaActual = 1;

                MostrarDatosEnGrilla();


            }
        }

        private void DatosDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            Evento evento = (Evento)r.Tag;
            var listaHorarios = _servicioHorarios.GetLista(evento);
            evento.Horarios = listaHorarios;
            if (e.ColumnIndex == 5 && !evento.Suspendido)
            {
                DialogResult dr = MessageBox.Show($"¿Desea suspender el evento permanentemente {evento.NombreEvento}?",
    "Confirmar Baja",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question,
    MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }
                evento.Suspendido = true;
                r.Cells[cmnSuspendido.Index].Value = evento.Suspendido;
                _servicio.Suspender(evento);
            }
            if (e.ColumnIndex == 4)
            {
                HorariosFrm frmHorarios = new HorariosFrm(_servicioHorarios,_servicio,evento);
                frmHorarios.ShowDialog(this);
            }
        }
        private void BuscarXTipoDocumentoTsb_Click(object sender, EventArgs e)
        {
            EventosFiltrarFrm frm = new EventosFiltrarFrm();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                var distribucion = frm.GetDistribucion();
                var tipoEvento = frm.GetTipoEvento();
                var clasificacion = frm.GetClasificacion();
                lista = _servicio.GetLista(distribucion, tipoEvento,clasificacion);
                cantidadRegistros = lista.Count();

                HelperForm.CrearBotonesPaginas(BotonesPanel, 0);
                paginaActual = 1;

                MostrarDatosEnGrilla();
            }
        }
    }
}
