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
    public partial class PlantasAEFrm : Form
    {
        public PlantasAEFrm(IPlantasServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private Operacion operacion;
        private IPlantasServicio _servicio;
        private Planta planta;
        public Planta GetPlanta()
        {
            return planta;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (planta == null)
                {
                    planta = new Planta();
                }

                planta.Descripcion = PlantaTxt.Text;
                try
                {
                    if (_servicio.Existe(planta))
                    {
                        errorProvider1.SetError(PlantaTxt, "Planta existente");
                        return;
                    }
                    _servicio.Guardar(planta);
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

                    planta = null;
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
            PlantaTxt.Clear();
            PlantaTxt.Focus();
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool esValido = true;
            if (string.IsNullOrEmpty(PlantaTxt.Text) ||
                string.IsNullOrWhiteSpace(PlantaTxt.Text))
            {
                esValido = false;
                errorProvider1.SetError(PlantaTxt, "Debe ingresar una Planta");

            }

            return esValido;
        }

        public void SetPlanta(Planta planta)
        {
            this.planta = planta;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            operacion = Operacion.Nuevo;
            if (planta != null)
            {
                PlantaTxt.Text = planta.Descripcion;
                operacion = Operacion.Editar;

            }
        }
    }
}
