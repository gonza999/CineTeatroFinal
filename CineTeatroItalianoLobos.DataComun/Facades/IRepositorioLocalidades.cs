﻿using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioLocalidades:IRepositorio<Localidad>
    {
      
        List<Localidad> GetLista(Ubicacion ubicacion);

        List<Localidad> GetLista(int fila);
        List<string> GetFilas();
        int GetCantidad(Func<Localidad, bool> p);
        int GetCantidad();
        List<Localidad> Find(Func<Localidad, bool> p, int? cantidadPorPagina, int? paginaActual);
        List<Localidad> GetLista(Planta planta, Ubicacion ubicacion);
        bool Existe(Localidad localidad, Horario horario);
        List<Localidad> GetLista();
    }
}
