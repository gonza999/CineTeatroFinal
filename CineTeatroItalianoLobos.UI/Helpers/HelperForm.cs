﻿using System.Drawing;
using System.Windows.Forms;

namespace CineTeatroItalianoLobos.UI.Helpers
{
    public class HelperForm
    {
        public static void MostrarInfoPaginas(SplitterPanel panel, int cantidadRegistros, int cantidadPaginas,
            int paginaActual)
        {
            ((Label)panel.Controls["CantidadDeRegistrosLabel"]).Text = cantidadRegistros.ToString();
            ((Label)panel.Controls["CantidadDePaginasLabel"]).Text = cantidadPaginas.ToString();
            ((Label)panel.Controls["PaginaActualLabel"]).Text = paginaActual.ToString();

        }
        public static void CrearBotonesPaginas(Panel panel, int paginas)
        {
            panel.Controls.Clear();
            for (int i = 0; i < paginas; i++)
            {
                Button b = new Button()
                {
                    Text = (i + 1).ToString(),
                    Location = new Point(16 + 45 * i, 16),
                    Size = new Size(25, 25),
                    BackColor=Color.Gray
                };
                //b.Click += Miclick;//Le agrego un manejador al evento clic de los botones
                panel.Controls.Add(b);//Agregro el botón a la colección de controles del panel
            }

        }

    }
}
