using CineTeatroItalianoLobos.Entities;
using System.Windows.Forms;

namespace CineTeatroItalianoLobos.UI.Helpers
{
    public class HelperGrid
    {
        public static void LimpiarGrilla(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
        }

        public static DataGridViewRow CrearFila(DataGridView dataGridView)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dataGridView);
            return r;
        }

        public static void AgregarFila(DataGridView dataGridView, DataGridViewRow r)
        {
            dataGridView.Rows.Add(r);
        }

        public static void BorrarFila(DataGridView dataGridView, DataGridViewRow r)
        {
            dataGridView.Rows.Remove(r);
        }

        public static void SetearFila(DataGridViewRow r, object obj)
        {
            switch (obj)
            {
                case TipoEvento _:
                    r.Cells[0].Value = ((TipoEvento)obj).Descripcion;
                    break;
                case Clasificacion _:
                    r.Cells[0].Value = ((Clasificacion)obj).Descripcion;
                    break;
                case Ubicacion _:
                    r.Cells[0].Value = ((Ubicacion)obj).Descripcion;
                    break;
                case FormaVenta _:
                    r.Cells[0].Value = ((FormaVenta)obj).Descripcion;
                    break;
                default:
                    break;
            }
            r.Tag = obj;
        }

    }
}
