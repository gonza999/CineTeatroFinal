﻿using CineTeatroItalianoLobos.Entities;
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

                //case Cliente _:
                //    r.Cells[0].Value = ((Cliente)obj).ApeNombre;
                //    r.Cells[1].Value = ((Cliente)obj).Ciudad.NombreCiudad;
                //    r.Cells[2].Value = ((Cliente)obj).Pais.NombrePais;

                //    break;

                //case Proveedor _:
                //    r.Cells[0].Value = ((Proveedor)obj).NombreProveedor;
                //    r.Cells[1].Value = ((Proveedor)obj).Ciudad.NombreCiudad;
                //    r.Cells[2].Value = ((Proveedor)obj).Pais.NombrePais;

                //    break;
                //case Producto _:
                //    r.Cells[0].Value = ((Producto)obj).NombreProducto;
                //    r.Cells[1].Value = ((Producto)obj).Categoria.NombreCategoria;
                //    r.Cells[2].Value = ((Producto)obj).PrecioUnitario;
                //    r.Cells[3].Value = ((Producto)obj).UnidadesEnStock;
                //    r.Cells[4].Value = ((Producto)obj).Suspendido;
                //    break;
                //case Orden _:
                //    r.Cells[0].Value = ((Orden)obj).OrdenId;
                //    r.Cells[1].Value = ((Orden)obj).FechaCompra;
                //    r.Cells[2].Value = ((Orden)obj).Cliente.ApeNombre;
                //    r.Cells[3].Value = ((Orden)obj).TotalVenta;
                //    break;
                //case DetalleOrden _:
                //    r.Cells[0].Value = ((DetalleOrden)obj).Producto.NombreProducto;
                //    r.Cells[1].Value = ((DetalleOrden)obj).PrecioUnitario.ToString("C");
                //    r.Cells[2].Value = ((DetalleOrden)obj).Cantidad;
                //    r.Cells[3].Value = ((DetalleOrden)obj).PrecioUnitario * (decimal)((DetalleOrden)obj).Cantidad;

                //    break;

                default:
                    break;
            }
            r.Tag = obj;
        }

    }
}
