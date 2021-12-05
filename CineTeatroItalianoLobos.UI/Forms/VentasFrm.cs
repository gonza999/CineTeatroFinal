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
    public partial class VentasFrm : Form
    {
        private List<Localidad> listaVendidas = new List<Localidad>();
        private Horario horario;

        private List<Ticket> listaTickets = new List<Ticket>();
        private readonly IVentasServicio _servicio;
        public VentasFrm(IVentasServicio servicio,List<Localidad> listaVendidas, Horario horario)
        {
            InitializeComponent();
            this.horario = horario;
            this.listaVendidas = listaVendidas;
            _servicio = servicio;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HelperCombos.CargarDatosComboEmpleados(ref EmpleadoCmb);
            HelperCombos.CargarDatosComboFormasPagos(ref FormaDePagoCmb);
            HelperCombos.CargarDatosComboFormasVentas(ref FormaDeVentaCmb);
            CantidadLocalidadesTxt.Text = listaVendidas.Count.ToString();
            CalcularImporteTotal();
        }

        private decimal importeTotal = 0;
        private void CalcularImporteTotal()
        {
            foreach (var l in listaVendidas)
            {    
                importeTotal += CalcularImporte(l);
            }
            ImporteTotalTxt.Text = importeTotal.ToString("c");
        }

        private void VenderBtn_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult dr = MessageBox.Show($"¿Está seguro que quiere vender las localidades?",
                       "Confirmar Venta",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question,
                       MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }

                ConstruirTickets();

                Venta venta = new Venta();
                //venta.Tickets = listaTickets;
                venta.VentasTickets = ConstruirVentasTickets();
                venta.Total += importeTotal;
                venta.Empleado = (Empleado)EmpleadoCmb.SelectedItem;
                venta.EmpleadoId = ((Empleado)EmpleadoCmb.SelectedItem).EmpleadoId;
                venta.Fecha = DateTime.Now;
                venta.Estado = false;
                try
                {
                    _servicio.Guardar(venta);
                    MessageBox.Show("Registro guardado", "Mensaje",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }

        private List<VentaTicket> ConstruirVentasTickets()
        {
            List<VentaTicket> listaVentaTickets = new List<VentaTicket>();
            foreach (var t in listaTickets)
            {
                VentaTicket ventaTicket = new VentaTicket()
                {
                    Ticket=t
                };
                listaVentaTickets.Add(ventaTicket);
            }
            return listaVentaTickets;
        }

        private void ConstruirTickets()
        {
            listaTickets.Clear();
            foreach (var l in listaVendidas)
            {
                Ticket ticket = new Ticket()
                {
                    FechaVenta = DateTime.Now,
                    FormaPago = (FormaPago)FormaDePagoCmb.SelectedItem,
                    FormaPagoId = ((FormaPago)FormaDePagoCmb.SelectedItem).FormaPagoId,
                    FormaVenta = (FormaVenta)FormaDeVentaCmb.SelectedItem,
                    FormaVentaId = ((FormaVenta)FormaDeVentaCmb.SelectedItem).FormaVentaId,
                    Horario = horario,
                    HorarioId = horario.HorarioId,
                    Localidad = l,
                    LocalidadId = l.LocalidadId,
                    Anulada = false,
                    Importe = CalcularImporte(l)
                };
                listaTickets.Add(ticket);
            }
        }

        private decimal CalcularImporte(Localidad l)
        {
            decimal precio = 0;
            decimal precioMayor = 0;
            foreach (var dl in horario.Evento.Distribucion.DistribucionesLocalidades)
            {
                if (dl.Localidad.LocalidadId == l.LocalidadId
                    && dl.Localidad.UbicacionId == l.UbicacionId)
                {
                    precio = dl.Precio;
                    if (precioMayor < precio)
                    {
                        precioMayor = precio;
                    }
                }
            }
            return precioMayor;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (EmpleadoCmb.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(EmpleadoCmb,"Debe seleccionar un Empleado");
            }
            if (FormaDeVentaCmb.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(FormaDeVentaCmb, "Debe seleccionar una Forma de Venta");
            }
            if (FormaDePagoCmb.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(FormaDePagoCmb, "Debe seleccionar una Forma de Pago");
            }
            return valido;
        }

        private void CancelButton_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
