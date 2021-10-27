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

        public static void CargarDatosComboPlantas(ref ComboBox plantaCmb)
        {
            IPlantasServicio servicio = DI.Create<IPlantasServicio>();
            List<Planta> lista = servicio.GetLista();
            var defaultPlanta = new Planta()
            {
                PlantaId = 0,
                Descripcion = "<Seleccione Planta>"
            };
            lista.Insert(0, defaultPlanta);
            plantaCmb.DataSource = lista;
            plantaCmb.DisplayMember = "Descripcion";
            plantaCmb.ValueMember = "PlantaId";
            plantaCmb.SelectedIndex = 0;
        }

        public static void CargarDatosComboUbicacion(ref ComboBox ubicacionCmb)
        {
            IUbicacionesServicio servicio = DI.Create<IUbicacionesServicio>();
            List<Ubicacion> lista = servicio.GetLista();
            var defaultUbicacion = new Ubicacion()
            {
                UbicacionId = 0,
                Descripcion = "<Seleccione Ubicación>"
            };
            lista.Insert(0, defaultUbicacion);
            ubicacionCmb.DataSource = lista;
            ubicacionCmb.DisplayMember = "Descripcion";
            ubicacionCmb.ValueMember = "UbicacionId";
            ubicacionCmb.SelectedIndex = 0;
        }
    }
}
