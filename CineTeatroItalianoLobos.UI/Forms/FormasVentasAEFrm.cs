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
    public partial class FormasVentasAEFrm : Form
    {
        public FormasVentasAEFrm(IFormasVentasServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private Operacion operacion;
        private IFormasVentasServicio _servicio;
        private FormaVenta formaVenta;
        public FormaVenta GetFormaVenta()
        {
            return formaVenta;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (formaVenta == null)
                {
                    formaVenta = new FormaVenta();
                }

                formaVenta.Descripcion = FormaVentaTxt.Text;
                try
                {
                    if (_servicio.Existe(formaVenta))
                    {
                        errorProvider1.SetError(FormaVentaTxt, "Forma de Venta existente");
                        return;
                    }
                    _servicio.Guardar(formaVenta);
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

                    formaVenta = null;
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
            FormaVentaTxt.Clear();
            FormaVentaTxt.Focus();
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool esValido = true;
            if (string.IsNullOrEmpty(FormaVentaTxt.Text) ||
                string.IsNullOrWhiteSpace(FormaVentaTxt.Text))
            {
                esValido = false;
                errorProvider1.SetError(FormaVentaTxt, "Debe ingresar una Forma de Venta");

            }

            return esValido;
        }

        public void SetFormaVenta(FormaVenta formaVenta)
        {
            this.formaVenta = formaVenta;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            operacion = Operacion.Nuevo;
            if (formaVenta != null)
            {
                FormaVentaTxt.Text = formaVenta.Descripcion;
                operacion = Operacion.Editar;

            }
        }

    }
}
