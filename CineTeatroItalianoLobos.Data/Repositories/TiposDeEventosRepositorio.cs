using CineTeatroItalianoLobos.DataComun.Facades;
using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CineTeatroItalianoLobos.Data.Repositories
{
    public class TiposDeEventosRepositorio : IRepositorioTipoEventos
    {
        private readonly CineTeatroDbContext _context;

        public TiposDeEventosRepositorio(CineTeatroDbContext context)
        {
            _context=context;
        }
        public void Borrar(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<TipoEvento> BuscarTipoEvento(string tipoevento)
        {
            throw new System.NotImplementedException();
        }

        public bool EstaRelacionado(TipoEvento TEntity)
        {
            throw new System.NotImplementedException();
        }

        public bool Existe(TipoEvento TEntity)
        {
            throw new System.NotImplementedException();
        }

        public int GetCantidad()
        {
            try
            {
                return _context.TiposEventos.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TipoEvento> GetLista(int registros, int pagina)
        {
            try
            {
                return _context.TiposEventos
                    .OrderBy(te => te.Descripcion)
                    .Skip(registros * (pagina - 1))
                    .Take(registros)
                    .AsNoTracking()
                    .ToList();

            }
            catch (Exception e)
            {

                throw new Exception("Error al leer");

            }
        }

        public TipoEvento GetTEntityPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public TipoEvento GetTipoEvento(string nombreTipoEvento)
        {
            throw new System.NotImplementedException();
        }

        public void Guardar(TipoEvento TEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}
