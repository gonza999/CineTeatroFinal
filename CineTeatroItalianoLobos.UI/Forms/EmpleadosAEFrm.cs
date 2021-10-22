using CineTeatroItalianoLobos.Entities;
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
    public partial class EmpleadosAEFrm : Form
    {

        public EmpleadosAEFrm(IEmpleadosServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private Operacion operacion;
        private IEmpleadosServicio _servicio;
        private Empleado empleado;
        public Empleado GetEmpleado()
        {
            return empleado;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (empleado == null)
                {
                    empleado = new Empleado();
                }

                empleado.Nombre = NombreTxt.Text;
                empleado.Apellido = ApellidoTxt.Text;
                empleado.Mail = MailTxt.Text;
                empleado.TelefonoFijo = TelefonoFijoTxt.Text;
                empleado.TelefonoMovil = TelefonoMovilTxt.Text;
                empleado.NroDocumento = NroDocumentoTxt.Text;
                empleado.TipoDocumentoId = ((TipoDocumento)TipoDocumentoCmb.SelectedItem).TipoDocumentoId;
                empleado.TipoDocumento = (TipoDocumento)TipoDocumentoCmb.SelectedItem;
                try
                {
                    if (_servicio.Existe(empleado))
                    {
                        errorProvider1.SetError(NombreTxt, "Empleado existente");
                        return;
                    }
                    _servicio.Guardar(empleado);
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

                    empleado = null;
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
            NombreTxt.Clear();
            NombreTxt.Focus();
            ApellidoTxt.Clear();
            MailTxt.Clear();
            TelefonoFijoTxt.Clear();
            TelefonoMovilTxt.Clear();
            NroDocumentoTxt.Clear();
            TipoDocumentoCmb.SelectedIndex = 0;
            errorProvider1.Clear();
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool esValido = true;
            if (string.IsNullOrEmpty(NombreTxt.Text) ||
                string.IsNullOrWhiteSpace(NombreTxt.Text))
            {
                esValido = false;
                errorProvider1.SetError(NombreTxt, "Debe ingresar un nombre");

            }
            if (string.IsNullOrEmpty(ApellidoTxt.Text) ||
               string.IsNullOrWhiteSpace(ApellidoTxt.Text))
            {
                esValido = false;
                errorProvider1.SetError(ApellidoTxt, "Debe ingresar un apellido");

            }
            if (string.IsNullOrEmpty(NroDocumentoTxt.Text) ||
              string.IsNullOrWhiteSpace(NroDocumentoTxt.Text))
            {
                esValido = false;
                errorProvider1.SetError(NroDocumentoTxt, "Debe ingresar un número de documento");

            }
            if (TipoDocumentoCmb.SelectedIndex==0)
            {
                esValido = false;
                errorProvider1.SetError(TipoDocumentoCmb, "Debe seleccionar un tipo de documento");
            }

            return esValido;
        }

        public void SetEmpleado(Empleado empleado)
        {
            this.empleado = empleado;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            operacion = Operacion.Nuevo;
            HelperCombos.CargarDatosComboTipoDocumentos(ref TipoDocumentoCmb);
            if (empleado != null)
            {
                NombreTxt.Text = empleado.Nombre;
                ApellidoTxt.Text = empleado.Apellido;
                MailTxt.Text = empleado.Mail;
                NroDocumentoTxt.Text = empleado.NroDocumento;
                TelefonoFijoTxt.Text = empleado.TelefonoFijo;
                TelefonoMovilTxt.Text = empleado.TelefonoMovil;
                TipoDocumentoCmb.SelectedValue = empleado.TipoDocumentoId;
                operacion = Operacion.Editar;

            }
        }
    }
}
