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
        private List<Button> butacasControles = new List<Button>();
        private List<Button> palcosBajosControles = new List<Button>();
        private List<Button> palcosAltosControles = new List<Button>();

        private List<Localidad> listaButacas = new List<Localidad>();
        private List<Localidad> listaPalcosBajos = new List<Localidad>();
        private List<Localidad> listaPalcosAltos = new List<Localidad>();

        private bool modoCompras = false;
        public ListaLocalidadesFrm(ILocalidadesServicio servicio, bool modo)
        {
            InitializeComponent();
            _servicio = servicio;
            modoCompras = modo;
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

        private void ListaLocalidadesFrm_Load(object sender, EventArgs e)
        {
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
                        foreach (var p in listaButacas)
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
                        foreach (var p in listaButacas)
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

        private void Miclick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
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

        private void HorarioCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            BloquearLocalidades();
            VerificarOcupado();
        }

        private void VerificarOcupado()
        {
            return;
        }
    }
}
