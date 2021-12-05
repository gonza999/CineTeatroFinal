using CineTeatroItalianoLobos.Entities;
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
    public partial class ListaVentasFiltrarFrm : Form
    {
        public ListaVentasFiltrarFrm()
        {
            InitializeComponent();
        }
        private Empleado empleado = null;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HelperCombos.CargarDatosComboEmpleados(ref EmpleadoCmb);
        }
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                empleado = (Empleado)EmpleadoCmb.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }

        private bool Validar()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (EmpleadoCmb.SelectedIndex==0)
            {
                errorProvider1.SetError(EmpleadoCmb,"Debe seleccionar un empleado");
                valido = false;
            }
            return valido;
        }

        public Empleado GetEmpleado()
        {
            return empleado;
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

