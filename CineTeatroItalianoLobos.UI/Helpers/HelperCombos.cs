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

        public static void CargarDatosComboFilas(ref ComboBox filaCmb)
        {
            ILocalidadesServicio servicio = DI.Create<ILocalidadesServicio>();
            List<string> lista = servicio.GetFilas();
            var defaultUFila = "<Seleccione Fila>";
            lista.Insert(0, defaultUFila);
            filaCmb.DataSource = lista;
            filaCmb.SelectedIndex = 0;
        }

        public static void CargarDatosComboClasificacion(ref ComboBox clasificacionCmb)
        {
            IClasificacionesServicio servicio = DI.Create<IClasificacionesServicio>();
            List<Clasificacion> lista = servicio.GetLista();
            var defaultClasificacion = new Clasificacion()
            {
                ClasificacionId = 0,
                Descripcion = "<Seleccione Clasificacion>"
            };
            lista.Insert(0, defaultClasificacion);
            clasificacionCmb.DataSource = lista;
            clasificacionCmb.DisplayMember = "Descripcion";
            clasificacionCmb.ValueMember = "ClasificacionId";
            clasificacionCmb.SelectedIndex = 0;
        }

        public static void CargarDatosComboTipoEventos(ref ComboBox tipoEventoCmb)
        {
            ITiposDeEventosServicios servicio = DI.Create<ITiposDeEventosServicios>();
            List<TipoEvento> lista = servicio.GetLista();
            var defaultTipoEvento = new TipoEvento()
            {
                TipoEventoId = 0,
                Descripcion = "<Seleccione Tipo de Evento>"
            };
            lista.Insert(0, defaultTipoEvento);
            tipoEventoCmb.DataSource = lista;
            tipoEventoCmb.DisplayMember = "Descripcion";
            tipoEventoCmb.ValueMember = "TipoEventoId";
            tipoEventoCmb.SelectedIndex = 0;
        }

        public static void CargarDatosComboDistribucion(ref ComboBox distribucionCmb)
        {
            IDistribucionesServicio servicio = DI.Create<IDistribucionesServicio>();
            List<Distribucion> lista = servicio.GetLista();
            var defaultDistribucion = new Distribucion()
            {
                DistribucionId = 0,
                Descripcion = "<Seleccione Distribucion>"
            };
            lista.Insert(0, defaultDistribucion);
            distribucionCmb.DataSource = lista;
            distribucionCmb.DisplayMember = "Descripcion";
            distribucionCmb.ValueMember = "DistribucionId";
            distribucionCmb.SelectedIndex = 0;
        }
    }
}
