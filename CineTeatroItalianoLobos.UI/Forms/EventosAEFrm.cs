using CineTeatroItalianoLobos.Entities;
using CineTeatroItalianoLobos.Services;
using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.UI.Enums;
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
    public partial class EventosAEFrm : Form
    {
        private List<Horario> lista = new List<Horario>();
        private readonly IHorariosServicio _servicioHorarios;
        private List<Horario> listaHorarios = new List<Horario>();

        public EventosAEFrm(IEventosServicios servicio,IHorariosServicio servicioHorarios)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioHorarios = servicioHorarios;
        }

        private Operacion operacion;
        private IEventosServicios _servicio;
        private Evento evento;
        public Evento GetEvento()
        {
            return evento;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (evento == null)
                {
                    evento = new Evento();
                }

                evento.NombreEvento = EventoTxt.Text;
                evento.Descripcion = DescripcionTxt.Text;
                evento.Suspendido = false;
                evento.TipoEvento = (TipoEvento)TipoEventoCmb.SelectedItem;
                evento.Clasificacion = (Clasificacion)ClasificacionCmb.SelectedItem;
                evento.Distribucion = (Distribucion)DistribucionCmb.SelectedItem;
                evento.FechaEvento = FechaPicker.Value;
                listaHorarios.Clear();
                evento.Horarios.Clear();
                foreach (DataGridViewRow r in DatosDgv.Rows)
                {
                    Horario horario = (Horario)r.Tag;
                    listaHorarios.Add(horario);
                }
                foreach (var h in listaHorarios)
                {
                    h.Evento = evento;
                    evento.Horarios.Add(h);
                    if (listaHorariosBorrados.Contains(h))
                    {
                        listaHorariosBorrados.Remove(h);
                    }
                }

                try
                {
                    if (_servicio.Existe(evento))
                    {
                        errorProvider1.SetError(EventoTxt, "Evento existente");
                        return;
                    }
                    _servicio.Guardar(evento,listaHorariosBorrados);
                    MessageBox.Show("Registro Guardado", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (operacion == Operacion.Editar)
                    {
                        DialogResult = DialogResult.OK;
                        return;

                    }
                    DialogResult dr = MessageBox.Show("¿Desea dar de alta otro registro?", "Confirmar",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.No)
                    {
                        DialogResult = DialogResult.Cancel;
                    }

                    evento = null;
                    InicializarControles();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }

        private void InicializarControles()
        {
            EventoTxt.Clear();
            DescripcionTxt.Clear();
            FechaPicker.Value = DateTime.Today;
            HoraPicker.Value = DateTime.Today;
            DatosDgv.Rows.Clear();
            listaHorarios.Clear();
            HelperCombos.CargarDatosComboClasificacion(ref ClasificacionCmb);
            HelperCombos.CargarDatosComboTipoEventos(ref TipoEventoCmb);
            HelperCombos.CargarDatosComboDistribucion(ref DistribucionCmb);
            EventoTxt.Focus();
            evento = null;
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(EventoTxt.Text.Trim()) &&
                string.IsNullOrWhiteSpace(EventoTxt.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(EventoTxt, "Debe ingresar una evento");
            }
            if (string.IsNullOrEmpty(DescripcionTxt.Text.Trim()) &&
                string.IsNullOrWhiteSpace(DescripcionTxt.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(DescripcionTxt, "Debe ingresar una descripcion");
            }
            if (ClasificacionCmb.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ClasificacionCmb, "Debe seleccionar una clasificacion");

            }
            if (TipoEventoCmb.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(TipoEventoCmb, "Debe seleccionar un tipo de evento");

            }
            if (DistribucionCmb.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(DistribucionCmb, "Debe seleccionar una Distribucion");

            }
            if (DatosDgv.Rows.Count == 0)
            {
                valido = false;
                errorProvider1.SetError(AgregarFechaBtn, "Debe agregar mínimo una fecha");
            }
            return valido;
        }

        public void SetEvento(Evento evento)
        {
            this.evento = evento;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            operacion = Operacion.Nuevo;
            HelperCombos.CargarDatosComboClasificacion(ref ClasificacionCmb);
            HelperCombos.CargarDatosComboTipoEventos(ref TipoEventoCmb);
            HelperCombos.CargarDatosComboDistribucion(ref DistribucionCmb);
            if (evento != null)
            {
                EventoTxt.Text = evento.NombreEvento;
                DescripcionTxt.Text = evento.Descripcion;
                ClasificacionCmb.SelectedValue = evento.Clasificacion.ClasificacionId;
                TipoEventoCmb.SelectedValue = evento.TipoEvento.TipoEventoId;
                DistribucionCmb.SelectedValue = evento.Distribucion.DistribucionId;
                MostrarGrilla(evento);
                operacion = Operacion.Editar;

            }
        }

        private void AgregarFechaBtn_Click(object sender, EventArgs e)
        {
            if (ValidarFechas(null))
            {
                Horario horario = new Horario();
                horario.Evento = evento;
                if (evento!=null)
                {
                     horario.EventoId = evento.EventoId;
                }
                horario.Fecha = FechaPicker.Value;
                horario.Hora = HoraPicker.Value;
                if (ValidarFechas(horario))
                {
                    AgregarFila(horario);
                }
            }
        }
        private void MostrarGrilla(Evento evento)
        {
            try
            {
                lista = _servicioHorarios.GetLista(evento);
                evento.Horarios.Clear();
                evento.Horarios = lista;
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {

                //MessageBox.Show(this, ex.Message, "Error",
                //    MessageBoxButtons.OK);
            }
        }

        private void MostrarDatosEnGrilla()
        {
            DatosDgv.Rows.Clear();
            foreach (var horario in lista)
            {
                if (ValidarObjeto())
                {
                    AgregarFila(horario);
                }
            }
        }
        private bool ValidarObjeto()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (_servicio.Existe(evento))
            {
                errorProvider1.SetError(EventoTxt, "No pueden haber dos eventos diferentes el mismo día");
                valido = false;
            }
            foreach (var h in evento.Horarios)
            {
                if (_servicioHorarios.Existe(h))
                {
                    valido = false;
                    errorProvider1.Clear();
                    errorProvider1.SetError(FechaPicker, "No pueden suceder dos eventos distintos en la misma fecha");
                    evento.Horarios.Remove(h);
                    break;
                }
            }


            return valido;
        }

        public void AgregarFila(Horario horario)
        {
            DataGridViewRow r = HelperGrid.CrearFila(DatosDgv);
            HelperGrid.SetearFila(r, horario);
            horario.Evento = evento;
            listaHorarios.Add(horario);
            HelperGrid.AgregarFila(DatosDgv,r);
        }
        private bool ValidarFechas(Horario horario)
        {
            errorProvider1.Clear();
            bool valido = true;

            if (FechaPicker.Value.Date < DateTime.Today)
            {
                valido = false;
                errorProvider1.SetError(FechaPicker, "La fecha del evento no puede ser anterior a la actual");
            }
            foreach (var h in listaHorarios)
            {
                if ((h.Hora.TimeOfDay == HoraPicker.Value.TimeOfDay) && h.Fecha.Date == FechaPicker.Value.Date)
                {
                    valido = false;
                    errorProvider1.SetError(FechaPicker, "No se pueden agregarle horarios iguales al mismo evento");
                }
              
            }
            if (horario != null)
            {
                var lista = _servicio.GetLista();
                if (_servicioHorarios.Existe(horario))
                {
                    valido = false;
                    errorProvider1.Clear();
                    errorProvider1.SetError(FechaPicker, "No pueden suceder dos eventos distintos en la misma fecha");
                }
            }

            return valido;
        }
        private List<Horario> listaHorariosBorrados = new List<Horario>();
        private void DatosDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                DataGridViewRow r = DatosDgv.Rows[e.RowIndex];
                Horario horario = (Horario)r.Tag;
                DatosDgv.Rows.RemoveAt(e.RowIndex);
                if (horario.HorarioId>0)
                {
                    horario = _servicioHorarios.GetTEntityPorId(horario.HorarioId);
                    listaHorariosBorrados.Add(horario);
                }
                //_servicioHorarios.Borrar(horario.HorarioId);
                listaHorarios.Remove(horario);
                if (evento != null)
                {
                    evento.Horarios.Remove(horario);

                }
            }
        }
    }
}
