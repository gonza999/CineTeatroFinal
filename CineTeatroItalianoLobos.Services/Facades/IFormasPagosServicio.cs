using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Services.Facades
{
    public interface IFormasPagosServicio
    {
        List<FormaPago> GetLista(int registros, int pagina);
        FormaPago GetTEntityPorId(int id);
        void Guardar(FormaPago formaPago);
        bool Existe(FormaPago formaPago);
        bool EstaRelacionado(FormaPago formaPago);
        int GetCantidad();
        void Borrar(int id);
        FormaPago GetFormaPago(string nombreFormaPago);
        List<FormaPago> BuscarFormaPago(string formaPago);
    }
}
