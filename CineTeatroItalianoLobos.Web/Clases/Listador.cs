using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Clases
{
    public class Listador<T> : PaginadorGenerico where T : class
    {
        public IEnumerable<T> Registros { get; set; }
    }
}