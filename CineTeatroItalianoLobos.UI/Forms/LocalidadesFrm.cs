using CineTeatroItalianoLobos.Entities;
using CineTeatroItalianoLobos.Services.Facades;
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
    public partial class LocalidadesFrm : Form
    {
        public LocalidadesFrm(ILocalidadesServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        const int cantidadPorPagina = 20;
        private bool filtroOn = false;

        private int cantidadPaginas;
        private int paginaActual;


        private readonly ILocalidadesServicio _servicio;
        private List<Localidad> lista;
        private int cantidadRegistros;
        private void LocalidadesFrm_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
            ////Inserta 117 butacas en 20 filas
            //bool primerFila = true;
            //int fila = 1;
            //int cambiarFila = 0;
            //for (int numero = 1; numero < 118; numero++)
            //{
            //    cambiarFila++;
            //    Localidad localidad = new Localidad()
            //    {
            //        Fila = fila,
            //        UbicacionId = 1,
            //        PlantaId = 1,
            //        Numero = numero,
            //    };
            //    if (cambiarFila == 17)
            //    {
            //        fila++;
            //        cambiarFila = 0;
            //    }
            //    if (primerFila && cambiarFila==15)
            //    {
            //        fila++;
            //        cambiarFila = 0;
            //        primerFila = false;
            //    }
            //    _servicio.Guardar(localidad);
            //}
            ////Inserta 14 palcos en planta baja
            //for (int numero = 1; numero < 15; numero++)
            //{
            //    Localidad localidad = new Localidad()
            //    {
            //        Fila = 1,
            //        UbicacionId = 2,
            //        PlantaId = 1,
            //        Numero = numero,
            //    };
            //    _servicio.Guardar(localidad);
            //}
            ////Inserta 20 palcos en primer piso
            //for (int numero = 1; numero < 21; numero++)
            //{
            //    Localidad localidad = new Localidad()
            //    {
            //        Fila = 1,
            //        UbicacionId = 2,
            //        PlantaId = 2,
            //        Numero = numero,
            //    };
            //    _servicio.Guardar(localidad);
            //}
        }
        private void AsignarEventHandler(Panel botonesPanel)
        {
            foreach (var control in botonesPanel.Controls)
            {
                if (control is Button)
                {
                    ((Button)control).Size = new Size(50, 50);
                    ((Button)control).Click += Miclick;
                }
            }
        }

        private void RecargarGrilla()
        {
            try
            {
                cantidadRegistros = _servicio.GetCantidad();

                cantidadPaginas = HelperCalculos.CalcularCantidadDePaginas(cantidadRegistros, cantidadPorPagina);
                HelperForm.CrearBotonesPaginas(BotonesPanel, cantidadPaginas);
                AsignarEventHandler(BotonesPanel);
                paginaActual = 1;
                MostrarPaginado(cantidadPorPagina, paginaActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Miclick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            paginaActual = int.Parse(b.Text);
            MostrarPaginado(cantidadPorPagina, paginaActual);
        }

        private void MostrarPaginado(int cantidadPorPagina, int paginaActual)
        {
            lista = _servicio.GetLista(cantidadPorPagina, paginaActual);
            MostrarDatosEnGrilla();

        }
        private void MostrarDatosEnGrilla()
        {
            HelperGrid.LimpiarGrilla(DatosDataGridView);
            foreach (var localidad in lista)
            {
                DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);

                HelperGrid.SetearFila(r, localidad);
                HelperGrid.AgregarFila(DatosDataGridView, r);
            }
            HelperForm.MostrarInfoPaginas(splitContainer1.Panel2, cantidadRegistros, cantidadPaginas, paginaActual);
        }




        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            LocalidadesAEFrm frm = new LocalidadesAEFrm(_servicio) { Text = "Nueva Localidad" };
            DialogResult dr = frm.ShowDialog(this);
            RecargarGrilla();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            Localidad localidad = (Localidad)r.Tag;
            LocalidadesAEFrm frm = new LocalidadesAEFrm(_servicio) { Text = "Editar Localidad" };
            frm.SetLocalidad(localidad);
            DialogResult dr = frm.ShowDialog(this);
            RecargarGrilla();
            //MostrarPaginado(cantidadPaginas, paginaActual);
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            Localidad localidad = (Localidad)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el registro {localidad.Numero}?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                if (!_servicio.EstaRelacionado(localidad))
                {
                    _servicio.Borrar(localidad.LocalidadId);
                    HelperGrid.BorrarFila(DatosDataGridView, r);

                    cantidadRegistros = _servicio.GetCantidad();
                    CantidadDeRegistrosLabel.Text = cantidadRegistros.ToString();

                    MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(@"Registro relacionado... Baja denegada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            LocalidadesFiltrarFrm frm = new LocalidadesFiltrarFrm();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                var planta = frm.GetPlanta();
                var ubicacion = frm.GetUbicacion();
                lista = _servicio.GetLista(planta,ubicacion);
                cantidadRegistros = lista.Count();

                HelperForm.CrearBotonesPaginas(BotonesPanel, 0);
                paginaActual = 1;

                MostrarDatosEnGrilla();
            }
        }
    }
}


