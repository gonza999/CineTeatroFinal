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
    public partial class LocalidadesAEFrm : Form
    {
        public LocalidadesAEFrm(ILocalidadesServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private Operacion operacion;
        private ILocalidadesServicio _servicio;
        private Localidad localidad;
        public Localidad GetLocalidad()
        {
            return localidad;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (localidad == null)
                {
                    localidad = new Localidad();
                }

                localidad.Numero = Convert.ToInt32(NumeroNud.Value);
                //localidad.Planta = (Planta)PlantaCmb.SelectedItem;
                localidad.PlantaId = ((Planta)PlantaCmb.SelectedItem).PlantaId;
                //localidad.Ubicacion = (Ubicacion)UbicacionCmb.SelectedItem;
                localidad.UbicacionId = ((Ubicacion)UbicacionCmb.SelectedItem).UbicacionId;
                localidad.Fila = Convert.ToInt32(FilaNud.Value);
                try
                {
                    if (_servicio.Existe(localidad))
                    {
                        errorProvider1.SetError(NumeroNud, "Localidad existente");
                        return;
                    }
                    _servicio.Guardar(localidad);
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

                    localidad = null;
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
            NumeroNud.Value = 0;
            FilaNud.Value = 0;
            HelperCombos.CargarDatosComboPlantas(ref PlantaCmb);
            HelperCombos.CargarDatosComboUbicacion(ref UbicacionCmb);
            PlantaCmb.Focus();
            localidad = null;
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (PlantaCmb.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(PlantaCmb, "Debe seleccionar una planta");

            }

            if (UbicacionCmb.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(UbicacionCmb, "Debe seleccionar una Ubicacion");

            }
            if (NumeroNud.Value < 0)
            {
                valido = false;
                errorProvider1.SetError(NumeroNud, "Numero mal ingresado");
            }
            if (FilaNud.Value <= 0)
            {
                valido = false;
                errorProvider1.SetError(FilaNud, "Fila mal ingresado");
            }
            return valido;
        }

        public void SetLocalidad(Localidad localidad)
        {
            this.localidad = localidad;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HelperCombos.CargarDatosComboPlantas(ref PlantaCmb);
            HelperCombos.CargarDatosComboUbicacion(ref UbicacionCmb);
            operacion = Operacion.Nuevo;
            if (localidad != null)
            {
                NumeroNud.Value = localidad.Numero;
                PlantaCmb.SelectedValue = localidad.Planta.PlantaId;
                UbicacionCmb.SelectedValue = localidad.Ubicacion.UbicacionId;
                FilaNud.Value = localidad.Fila;
                operacion = Operacion.Editar;

            }
        }
    }
}
