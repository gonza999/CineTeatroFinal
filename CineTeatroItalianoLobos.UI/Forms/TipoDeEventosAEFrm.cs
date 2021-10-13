using CineTeatroItalianoLobos.Entities;
using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.UI.Enums;
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
    public partial class TipoDeEventosAEFrm : Form
    {
        public TipoDeEventosAEFrm(ITiposDeEventosServicios servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private Operacion operacion;
        private ITiposDeEventosServicios _servicio;
        private TipoEvento tipoEvento;
        public TipoEvento GetTipo()
        {
            return tipoEvento;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoEvento == null)
                {
                    tipoEvento = new TipoEvento();
                }

                tipoEvento.Descripcion = TipoDeEventoTxt.Text;
                try
                {
                    if (_servicio.Existe(tipoEvento))
                    {
                        errorProvider1.SetError(TipoDeEventoTxt, "Tipo de evento existente");
                        return;
                    }
                    _servicio.Guardar(tipoEvento);
                    MessageBox.Show("Registro guardado", "Mensaje",
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

                    tipoEvento = null;
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
            TipoDeEventoTxt.Clear();
            TipoDeEventoTxt.Focus();
        }

        private bool ValidarDatos()
        {
            bool esValido = true;
            if (string.IsNullOrEmpty(TipoDeEventoTxt.Text))
            {
                esValido = false;
                errorProvider1.SetError(TipoDeEventoTxt, "Debe ingresar un tipo de evento");

            }

            return esValido;
        }

        public void SetTipo(TipoEvento tipoEvento)
        {
            this.tipoEvento = tipoEvento;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            operacion = Operacion.Nuevo;
            if (tipoEvento != null)
            {
                TipoDeEventoTxt.Text = tipoEvento.Descripcion;
                operacion = Operacion.Editar;

            }
        }

    }
}
