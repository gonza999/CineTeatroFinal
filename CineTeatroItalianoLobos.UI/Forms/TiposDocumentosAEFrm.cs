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
    public partial class TiposDocumentosAEFrm : Form
    {
        public TiposDocumentosAEFrm(ITiposDocumentosServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private Operacion operacion;
        private ITiposDocumentosServicio _servicio;
        private TipoDocumento tipoDocumento;
        public TipoDocumento GetTipo()
        {
            return tipoDocumento;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoDocumento == null)
                {
                    tipoDocumento = new TipoDocumento();
                }

                tipoDocumento.Descripcion = TipoDeDocumentoTxt.Text;
                try
                {
                    if (_servicio.Existe(tipoDocumento))
                    {
                        errorProvider1.SetError(TipoDeDocumentoTxt, "Tipo de documento existente");
                        return;
                    }
                    _servicio.Guardar(tipoDocumento);
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

                    tipoDocumento = null;
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
            TipoDeDocumentoTxt.Clear();
            TipoDeDocumentoTxt.Focus();
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool esValido = true;
            if (string.IsNullOrEmpty(TipoDeDocumentoTxt.Text) ||
                string.IsNullOrWhiteSpace(TipoDeDocumentoTxt.Text))
            {
                esValido = false;
                errorProvider1.SetError(TipoDeDocumentoTxt, "Debe ingresar un tipo de documento");

            }

            return esValido;
        }

        public void SetTipo(TipoDocumento tipoDocumento)
        {
            this.tipoDocumento = tipoDocumento;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            operacion = Operacion.Nuevo;
            if (tipoDocumento != null)
            {
                TipoDeDocumentoTxt.Text = tipoDocumento.Descripcion;
                operacion = Operacion.Editar;

            }
        }

    }
}
