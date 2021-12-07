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

        public static void CargarDatosComboFormasPagos(ref ComboBox formaDePagoCmb)
        {
            IFormasPagosServicio servicio = DI.Create<IFormasPagosServicio>();
            List<FormaPago> lista = servicio.GetLista();
            var defaultFormaPago = new FormaPago()
            {
                FormaPagoId = 0,
                Descripcion = "<Seleccione Forma de Pago>"
            };
            lista.Insert(0, defaultFormaPago);
            formaDePagoCmb.DataSource = lista;
            formaDePagoCmb.DisplayMember = "Descripcion";
            formaDePagoCmb.ValueMember = "FormaPagoId";
            formaDePagoCmb.SelectedIndex = 0;
        }

        public static void CargarDatosComboFormasVentas(ref ComboBox formaDeVentaCmb)
        {
            IFormasVentasServicio servicio = DI.Create<IFormasVentasServicio>();
            List<FormaVenta> lista = servicio.GetLista();
            var defaultFormaVenta = new FormaVenta()
            {
                FormaVentaId = 0,
                Descripcion = "<Seleccione Forma de Venta>"
            };
            lista.Insert(0, defaultFormaVenta);
            formaDeVentaCmb.DataSource = lista;
            formaDeVentaCmb.DisplayMember = "Descripcion";
            formaDeVentaCmb.ValueMember = "FormaVentaId";
            formaDeVentaCmb.SelectedIndex = 0;
        }

        public static void CargarDatosComboEmpleados(ref ComboBox empleadoCmb)
        {
            IEmpleadosServicio servicio = DI.Create<IEmpleadosServicio>();
            List<Empleado> lista = servicio.GetLista();
            var defaultEmpleado = new Empleado()
            {
                EmpleadoId = 0,
                Apellido = "<Seleccione Empleado>"
            };
            lista.Insert(0, defaultEmpleado);
            empleadoCmb.DataSource = lista;
            empleadoCmb.DisplayMember = "Apellido";
            empleadoCmb.ValueMember = "EmpleadoId";
            empleadoCmb.SelectedIndex = 0;
        }

        internal static void CargarDatosComboEventos(ref ComboBox eventoCmb, bool modoCompras)
        {
            IEventosServicios servicio = DI.Create<IEventosServicios>();
            List<Evento> lista = servicio.GetLista();
            var listaSuspendidos=new List<Evento>();
            if (modoCompras)
            {
                foreach (var e in lista)
                {
                    if (e.Suspendido)
                    {
                        listaSuspendidos.Add(e);
                    }
                }
                foreach (var e in listaSuspendidos)
                {
                    lista.Remove(e);
                }
            }
            else
            {
                foreach (var e in lista)
                {
                    if (e.Suspendido)
                    {
                        e.NombreEvento = e.NombreEvento + " (Suspendido)";
                    }
                }
            }
            var defaultEvento = new Evento()
            {
                EventoId = 0,
                NombreEvento = "<Seleccione Evento>"
            };
            lista.Insert(0, defaultEvento);
            eventoCmb.DataSource = lista;
            eventoCmb.DisplayMember = "NombreEvento";
            eventoCmb.ValueMember = "EventoId";
            eventoCmb.SelectedIndex = 0;
        }

        public static void CargarDatosComboEventos(ref ComboBox eventoCmb)
        {
            IEventosServicios servicio = DI.Create<IEventosServicios>();
            List<Evento> lista = servicio.GetLista();
            var defaultEvento = new Evento()
            {
                EventoId = 0,
                NombreEvento = "<Seleccione Evento>"
            };
            lista.Insert(0, defaultEvento);
            eventoCmb.DataSource = lista;
            eventoCmb.DisplayMember = "NombreEvento";
            eventoCmb.ValueMember = "EventoId";
            eventoCmb.SelectedIndex = 0;
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

        public static void CargarDatosComboHorario(ref ComboBox horarioCmb, Evento evento)
        {
            IHorariosServicio servicio = DI.Create<IHorariosServicio>();
            List<Horario> lista = servicio.GetLista(evento);
            foreach (var h in lista)
            {
                h.SetearFechaYHora();
            }
            var defaultHorario = new Horario()
            {
                HorarioId = 0,
                FechaYHora = "<Seleccione Horario>"
            };
            lista.Insert(0, defaultHorario);
            defaultHorario.FechaYHora = "<Seleccione Horario>";
            horarioCmb.DataSource = lista;
            horarioCmb.DisplayMember = "FechaYHora";
            horarioCmb.ValueMember = "HorarioId";
            horarioCmb.SelectedIndex = 0;
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
