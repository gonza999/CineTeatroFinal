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
    public partial class UbicacionesAEFrm : Form
    {
        public UbicacionesAEFrm(IUbicacionesServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private Operacion operacion;
        private IUbicacionesServicio _servicio;
        private Ubicacion ubicacion;
        public Ubicacion GetUbicacion()
        {
            return ubicacion;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (ubicacion == null)
                {
                    ubicacion = new Ubicacion();
                }

                ubicacion.Descripcion = UbicacionTxt.Text;
                try
                {
                    if (_servicio.Existe(ubicacion))
                    {
                        errorProvider1.SetError(UbicacionTxt, "Ubicacion existente");
                        return;
                    }
                    _servicio.Guardar(ubicacion);
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

                    ubicacion = null;
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
            UbicacionTxt.Clear();
            UbicacionTxt.Focus();
        }

        private bool ValidarDatos()
        {
            bool esValido = true;
            if (string.IsNullOrEmpty(UbicacionTxt.Text) ||
                string.IsNullOrWhiteSpace(UbicacionTxt.Text))
            {
                esValido = false;
                errorProvider1.SetError(UbicacionTxt, "Debe ingresar una Ubicacion");

            }

            return esValido;
        }

        public void SetUbicacion(Ubicacion ubicacion)
        {
            this.ubicacion = ubicacion;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            operacion = Operacion.Nuevo;
            if (ubicacion != null)
            {
                UbicacionTxt.Text = ubicacion.Descripcion;
                operacion = Operacion.Editar;

            }
        }
    }
}
