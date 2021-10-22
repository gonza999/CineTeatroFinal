using CineTeatroItalianoLobos.Entities;
using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.UI.Ninject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CineTeatroItalianoLobos.UI.Helpers
{
    public class HelperCombos
    {
        public static void CargarDatosComboTipoDocumentos(ref ComboBox combo)
        {
            ITiposDocumentosServicio servicio = DI.Create<ITiposDocumentosServicio>();
            List<TipoDocumento> lista = servicio.GetLista();
            var defaultTipoDocumento = new TipoDocumento()
            {
                TipoDocumentoId = 0,
                Descripcion = "<Seleccione Tipo de Documento>"
            };
            lista.Insert(0, defaultTipoDocumento);
            combo.DataSource = lista;
            combo.DisplayMember = "Descripcion";
            combo.ValueMember = "TipoDocumentoId";
            combo.SelectedIndex = 0;


        }

    }
}
