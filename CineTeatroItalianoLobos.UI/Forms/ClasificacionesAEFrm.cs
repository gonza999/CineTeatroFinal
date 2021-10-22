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
    public partial class ClasificacionesAEFrm : Form
    {
        public ClasificacionesAEFrm(IClasificacionesServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private Operacion operacion;
        private IClasificacionesServicio _servicio;
        private Clasificacion clasificacion;
        public Clasificacion GetClasificacion()
        {
            return clasificacion;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (clasificacion == null)
                {
                    clasificacion = new Clasificacion();
                }

                clasificacion.Descripcion = ClasificacionTxt.Text;
                try
                {
                    if (_servicio.Existe(clasificacion))
                    {
                        errorProvider1.SetError(ClasificacionTxt, "Clasificacion existente");
                        return;
                    }
                    _servicio.Guardar(clasificacion);
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

                    clasificacion = null;
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
            ClasificacionTxt.Clear();
            ClasificacionTxt.Focus();
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool esValido = true;
            if (string.IsNullOrEmpty(ClasificacionTxt.Text) ||
                string.IsNullOrWhiteSpace(ClasificacionTxt.Text))
            {
                esValido = false;
                errorProvider1.SetError(ClasificacionTxt, "Debe ingresar una Clasificacion");

            }

            return esValido;
        }

        public void SetClasificacion(Clasificacion clasificacion)
        {
            this.clasificacion = clasificacion;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            operacion = Operacion.Nuevo;
            if (clasificacion != null)
            {
                ClasificacionTxt.Text = clasificacion.Descripcion;
                operacion = Operacion.Editar;

            }
        }

    }
}
