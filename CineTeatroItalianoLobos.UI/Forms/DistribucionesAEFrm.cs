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
    public partial class DistribucionesAEFrm : Form
    {
        public DistribucionesAEFrm(IDistribucionesServicio servicio, ILocalidadesServicio servicioLocalidades)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioLocalidades = servicioLocalidades;
        }

        private Operacion operacion;
        private IDistribucionesServicio _servicio;
        private ILocalidadesServicio _servicioLocalidades;
        private Distribucion distribucion;
        private List<DistribucionLocalidad> distribucionLocalidades = new List<DistribucionLocalidad>();
        public Distribucion GetDistribucion()
        {
            return distribucion;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                distribucion = new Distribucion();

                distribucion.Descripcion = DistribucionTxt.Text;
                distribucion.DistribucionesLocalidades.Clear();
                distribucion.DistribucionesLocalidades = distribucionLocalidades;

                Ubicacion palcos = new Ubicacion();
                palcos.UbicacionId = 2;
                List<Localidad> listaLocalidades = _servicioLocalidades.GetLista(palcos);
                foreach (var l in listaLocalidades)
                {
                    DistribucionLocalidad distribucionPalcos = new DistribucionLocalidad();
                    distribucionPalcos.Precio = decimal.Parse(PalcosTxt.Text);
                    distribucionPalcos.LocalidadId = l.LocalidadId;
                    distribucion.DistribucionesLocalidades.Add(distribucionPalcos);
                }
                try
                {
                    if (_servicio.Existe(distribucion))
                    {
                        errorProvider1.SetError(DistribucionTxt, "Distribucion existente");
                        return;
                    }
                    _servicio.Guardar(distribucion);
                    MessageBox.Show("Registro guardado", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult dr = MessageBox.Show("¿Desea dar de alta otro registro?", "Confirmar",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.No)
                    {
                        DialogResult = DialogResult.Cancel;
                    }
                    distribucion = null;
                    InicializarControles();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message,"Error");
                }
            }
        }

        private void InicializarControles()
        {
            DistribucionTxt.Clear();
            DistribucionTxt.Focus();
            PalcosTxt.Clear();
            distribucion = null;
            DatosDataGridView.Rows.Clear();
            FilaCmb.SelectedIndex = 0;
            distribucionLocalidades.Clear();
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(DistribucionTxt.Text.Trim()) &&
                string.IsNullOrWhiteSpace(DistribucionTxt.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(DistribucionTxt, "Debe ingresar un nombre de distribucion");
            }
            decimal precio;
            if (string.IsNullOrEmpty(PalcosTxt.Text.Trim()) &&
           string.IsNullOrWhiteSpace(PalcosTxt.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(PalcosTxt, "Debe ingresar un precio de palco");
            }
            precio = 0;
            if (!decimal.TryParse(PalcosTxt.Text, out precio))
            {
                valido = false;
                errorProvider1.SetError(PalcosTxt, "Debe ingresar un precio de palco valido");
            }
            if (precio < 0)
            {
                valido = false;
                errorProvider1.SetError(PalcosTxt, "El precio no debe ser menor a cero");

            }
            if (DatosDataGridView.Rows.Count != FilaCmb.Items.Count-1)
            {
                valido = false;
                errorProvider1.SetError(btnAgregar, "Debe ingresar un precio a cada fila");
            }
            return valido;
        }

        public void SetDistribucion(Distribucion distribucion)
        {
            this.distribucion = distribucion;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            operacion = Operacion.Nuevo;
            DatosDataGridView.Rows.Clear();
            HelperCombos.CargarDatosComboFilas(ref FilaCmb);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DistribucionLocalidad distribucionLocalidad = new DistribucionLocalidad();
            if (ValidarPrecio())
            {
                if (ValidarFila())
                {
                    if (FilaCmb.SelectedIndex!=0)
                    {
                        int fila = int.Parse((string)FilaCmb.SelectedValue);
                        var listaLocalidades = _servicioLocalidades.GetLista(fila);
                        foreach (var l in listaLocalidades)
                        {
                            distribucionLocalidad = new DistribucionLocalidad();
                            distribucionLocalidad.Precio = decimal.Parse(ButacasTxt.Text);
                            distribucionLocalidad.LocalidadId = l.LocalidadId;
                            distribucionLocalidad.Localidad = l;
                            distribucionLocalidades.Add(distribucionLocalidad); 
                        }
                        DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);
                        HelperGrid.SetearFila(r, distribucionLocalidad);
                        HelperGrid.AgregarFila(DatosDataGridView, r);
                    }
                }

            }
        }
        private bool ValidarPrecio()
        {
            errorProvider1.Clear();
            bool valido = true;
            decimal precio;
            if (!decimal.TryParse(ButacasTxt.Text, out precio))
            {
                valido = false;
                errorProvider1.SetError(ButacasTxt, "Debe ingresar un precio valido");
            }

            return valido;
        }
        private bool ValidarFila()
        {
            errorProvider1.Clear();
            bool valido = true;
            foreach (var dl in distribucionLocalidades)
            {
                if (FilaCmb.SelectedIndex!=0)
                {

                    if (dl.Localidad.Fila == int.Parse((string)FilaCmb.SelectedValue))
                    {
                        valido = false;
                        errorProvider1.SetError(FilaCmb, "Ya le han asignado precio a esta fila");
                    }
                }
                else
                {
                    valido = false;
                }
            }
            return valido;
        }

        private void DatosDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                DataGridViewRow r = DatosDataGridView.Rows[e.RowIndex];
                DistribucionLocalidad distribucionLocalidad = (DistribucionLocalidad)r.Tag;
                distribucionLocalidades.RemoveAll(delegate (DistribucionLocalidad dl)
                {
                    return dl.Localidad.Fila == distribucionLocalidad.Localidad.Fila;
                });
                DatosDataGridView.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
