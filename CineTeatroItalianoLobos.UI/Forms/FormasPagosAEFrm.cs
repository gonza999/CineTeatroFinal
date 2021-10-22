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
    public partial class FormasPagosAEFrm : Form
    {
        public FormasPagosAEFrm(IFormasPagosServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private Operacion operacion;
        private IFormasPagosServicio _servicio;
        private FormaPago formaPago;
        public FormaPago GetFormaPago()
        {
            return formaPago;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (formaPago == null)
                {
                    formaPago = new FormaPago();
                }

                formaPago.Descripcion = FormaPagoTxt.Text;
                try
                {
                    if (_servicio.Existe(formaPago))
                    {
                        errorProvider1.SetError(FormaPagoTxt, "Forma de Pago existente");
                        return;
                    }
                    _servicio.Guardar(formaPago);
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

                    formaPago = null;
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
            FormaPagoTxt.Clear();
            FormaPagoTxt.Focus();
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool esValido = true;
            if (string.IsNullOrEmpty(FormaPagoTxt.Text) ||
                string.IsNullOrWhiteSpace(FormaPagoTxt.Text))
            {
                esValido = false;
                errorProvider1.SetError(FormaPagoTxt, "Debe ingresar una Forma de Pago");

            }

            return esValido;
        }

        public void SetFormaPago(FormaPago formaPago)
        {
            this.formaPago = formaPago;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            operacion = Operacion.Nuevo;
            if (formaPago != null)
            {
                FormaPagoTxt.Text = formaPago.Descripcion;
                operacion = Operacion.Editar;

            }
        }

    }
}
