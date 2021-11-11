using CineTeatroItalianoLobos.Entities;
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
    public partial class DistribucionesDetallesFrm : Form
    {
        public DistribucionesDetallesFrm()
        {
            InitializeComponent();
        }
        private Distribucion distribucion;
        internal void SetDistribucion(Distribucion distribucion)
        {
            this.distribucion = distribucion;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DistribucionesDetallesFrm_Load(object sender, EventArgs e)
        {
            ConstruirPreciosLabelsYText();
        }
        private int x = 0;
        private int y = -30;
        private void ConstruirPreciosLabelsYText()
        {
            ButacasPanel.Controls.Clear();
            bool filaHecha = true;
            List<int> fila = new List<int>();
            foreach (var dl in distribucion.DistribucionesLocalidades)
            {
                if (dl.Localidad.UbicacionId==1)
                {
                    if (!fila.Contains(dl.Localidad.Fila))
                    {
                        fila.Add(dl.Localidad.Fila);
                        filaHecha = false;
                    }
                    else
                    {
                        filaHecha = true;
                    }
                    if (!filaHecha)
                    {
                        y += 30;
                        Label label = new Label()
                        {
                            Text = $"Fila {dl.Localidad.Fila}",
                            Location = new Point(x, y),
                            Font = new Font("Arial", 12, FontStyle.Bold),
                            Size = new Size(70, 28)
                        };
                        TextBox textBox = new TextBox()
                        {
                            Text = $"${dl.Precio}",
                            BackColor = Color.FromArgb(255, 224, 192),
                            Size = new Size(102, 20),
                            Enabled = false,
                            Location = new Point(label.Location.X + 102, label.Location.Y),
                            TextAlign=HorizontalAlignment.Right
                        };
                        textBox.BringToFront();
                        ButacasPanel.Controls.Add(label);
                        ButacasPanel.Controls.Add(textBox); 
                    }
                }
                else
                {
                    PalcosTxt.Text = $"${dl.Precio}";
                }
            }
        }
    }
}
