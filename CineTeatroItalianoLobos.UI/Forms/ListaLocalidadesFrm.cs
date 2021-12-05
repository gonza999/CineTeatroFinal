using CineTeatroItalianoLobos.Entities;
using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.UI.Helpers;
using CineTeatroItalianoLobos.Web.Models.Evento;
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
    public partial class ListaLocalidadesFrm : Form
    {
        private readonly ILocalidadesServicio _servicio;
        private readonly IDistribucionesServicio _servicioDistribuciones;
        private readonly IVentasServicio _servicioVentas;

        private List<Button> butacasControles = new List<Button>();
        private List<Button> palcosBajosControles = new List<Button>();
        private List<Button> palcosAltosControles = new List<Button>();

        private List<Localidad> listaButacas = new List<Localidad>();
        private List<Localidad> listaPalcosBajos = new List<Localidad>();
        private List<Localidad> listaPalcosAltos = new List<Localidad>();

        private bool modoCompras = false;
        public ListaLocalidadesFrm(ILocalidadesServicio servicio,
            IDistribucionesServicio servicioDistribuciones,
            IVentasServicio servicioVentas, bool modo)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioDistribuciones = servicioDistribuciones;
            modoCompras = modo;
            _servicioVentas = servicioVentas;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {

            ClosePbx.BorderStyle = BorderStyle.Fixed3D;
        }

        private void ClosePbx_MouseLeave(object sender, EventArgs e)
        {
            ClosePbx.BorderStyle = BorderStyle.FixedSingle;
        }
        private Color seleccionadoColor = Color.White;
        private void ListaLocalidadesFrm_Load(object sender, EventArgs e)
        {
            VerModoCompras();
            Ubicacion ubicacion = new Ubicacion() { UbicacionId = 1 };
            listaButacas = _servicio.GetLista(ubicacion);
            ubicacion.UbicacionId = 2;
            Planta planta = new Planta()
            {
                PlantaId = 1
            };
            listaPalcosBajos = _servicio.GetLista(planta, ubicacion);
            planta.PlantaId = 2;
            listaPalcosAltos = _servicio.GetLista(planta, ubicacion);

            evento.EventoId = 0;
            HelperCombos.CargarDatosComboHorario(ref HorarioCmb, evento);
            HelperCombos.CargarDatosComboEventos(ref EventoCmb);
            ConstruirListaLocalidades();
            BloquearLocalidades();
        }

        private void VerModoCompras()
        {
            if (modoCompras)
            {
                SeleccionadoBtn.Visible = true;
                SeleccionadoLbl.Visible = true;
                ImporteLocalidadLbl.Visible = true;
                ImporteLocalidadTxt.Visible = true;
                ImporteTotalLbl.Visible = true;
                ImporteTotalTxt.Visible = true;
                VenderBtn.Visible = true;
            }
        }

        private void BloquearLocalidades()
        {
            if (modoCompras)
            {
                if (HorarioCmb.SelectedIndex == 0)
                {
                    CambiarEstadoDeBotones(false);
                }
                else
                {
                    CambiarEstadoDeBotones(true);
                }
            }
            else
            {
                CambiarEstadoDeBotones(false);
            }
        }
        private void VerificarOcupado()
        {
            foreach (var b in butacasControles)
            {
                if (_servicio.Existe((Localidad)b.Tag, horario))
                {
                    b.Enabled = false;
                    b.BackColor = Color.Red;
                }
                else
                {
                    b.BackColor = Color.FromArgb(255, 224, 192);
                }
            }
            foreach (var p in palcosBajosControles)
            {
                if (_servicio.Existe((Localidad)p.Tag, horario))
                {
                    p.Enabled = false;
                    p.BackColor = Color.Red;
                }
                else
                {
                    p.BackColor = Color.FromArgb(255, 192, 128);
                }
            }
            foreach (var p in palcosAltosControles)
            {
                if (_servicio.Existe((Localidad)p.Tag, horario))
                {
                    p.Enabled = false;
                    p.BackColor = Color.Red;
                }
                else
                {
                    p.BackColor = Color.FromArgb(192, 255, 192);
                }
            }
        }
        private void CambiarEstadoDeBotones(bool disponible)
        {
            foreach (var b in butacasControles)
            {
                b.Enabled = disponible;
            }
            foreach (var p in palcosBajosControles)
            {
                p.Enabled = disponible;
            }
            foreach (var p in palcosAltosControles)
            {
                p.Enabled = disponible;
            }
        }

        private void ConstruirListaLocalidades()
        {
            butacasControles.Clear();
            palcosAltosControles.Clear();
            palcosBajosControles.Clear();
            var controles = ObjetosPnl.Controls;
            foreach (var control in controles)
            {
                if (control is Button)
                {
                    //Butacas
                    if (((Button)control).BackColor == Color.FromArgb(255, 224, 192))
                    {
                        foreach (var b in listaButacas)
                        {
                            if (b.Numero.ToString() == ((Button)control).Text)
                            {
                                ((Button)control).Tag = b;
                            }
                        }
                        butacasControles.Add(((Button)control));
                    }
                    //Palcos Bajos
                    if (((Button)control).BackColor == Color.FromArgb(255, 192, 128))
                    {
                        foreach (var p in listaPalcosBajos)
                        {
                            if (p.Numero.ToString() == ((Button)control).Text)
                            {
                                ((Button)control).Tag = p;
                            }
                        }
                        palcosBajosControles.Add(((Button)control));
                    }
                    //Palcos Altos
                    if (((Button)control).BackColor == Color.FromArgb(192, 255, 192))
                    {
                        foreach (var p in listaPalcosAltos)
                        {
                            if ((p.Numero + 14).ToString() == ((Button)control).Text)
                            {
                                ((Button)control).Tag = p;
                            }
                        }
                        palcosAltosControles.Add(((Button)control));
                    }
                    ((Button)control).Click += Miclick;
                }
            }
        }
        private decimal importeTotal = 0;
        private List<Localidad> listaVendidas = new List<Localidad>();
        private void Miclick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            var localidad = (Localidad)b.Tag;
            var precio = MostrarPrecio(localidad);
            if (b.BackColor != seleccionadoColor)
            {
                b.BackColor = seleccionadoColor;
                importeTotal += precio;
                listaVendidas.Add(localidad);
            }
            else
            {
                listaVendidas.Remove(localidad);
                importeTotal -= precio;
                if (localidad.UbicacionId == 1)
                {
                    b.BackColor = Color.FromArgb(255, 224, 192);
                }
                else if (localidad.UbicacionId == 2 && localidad.PlantaId == 1)
                {
                    b.BackColor = Color.FromArgb(255, 192, 128);
                }
                else if (localidad.UbicacionId == 2 && localidad.PlantaId == 2)
                {
                    b.BackColor = Color.FromArgb(192, 255, 192);
                }
            }
            ImporteTotalTxt.Text = importeTotal.ToString("c");
            if (listaVendidas.Count > 0)
            {
                VenderBtn.Enabled = true;
            }
            else
            {
                VenderBtn.Enabled = false;
            }
        }

        private Evento evento = new Evento();
        private void EventoCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EventoCmb.SelectedIndex != 0)
            {
                HorarioCmb.Enabled = true;
                BloquearLocalidades();
                evento = (Evento)EventoCmb.SelectedItem;
                HelperCombos.CargarDatosComboHorario(ref HorarioCmb, evento);
            }
            else
            {
                HorarioCmb.SelectedIndex = 0;
                HorarioCmb.Enabled = false;
                BloquearLocalidades();
            }
        }
        private Horario horario = new Horario();
        private void HorarioCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            BloquearLocalidades();
            horario = (Horario)HorarioCmb.SelectedItem;
            if (HorarioCmb.SelectedIndex != 0)
            {
                VerificarOcupado();
            }
        }
        private decimal MostrarPrecio(Localidad localidad)
        {
            decimal precio = 0;
            foreach (var dl in evento.Distribucion.DistribucionesLocalidades)
            {
                if (dl.Localidad.LocalidadId == localidad.LocalidadId
                    && dl.Localidad.UbicacionId == localidad.UbicacionId)
                {
                    ImporteLocalidadTxt.Text = dl.Precio.ToString("c");
                    precio = dl.Precio;
                }
            }
            return precio;
        }

        private void VenderBtn_Click(object sender, EventArgs e)
        {
            VentasFrm frm = new VentasFrm(_servicioVentas, listaVendidas, horario);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                Close();
            }
        }
    }
}
