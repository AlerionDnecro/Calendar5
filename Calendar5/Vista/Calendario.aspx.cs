using Calendar5.Conexion;
using Calendar5.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using System.Xml.Serialization;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Calendar5.Vista
{
    public partial class Calendario : System.Web.UI.Page
    {
        ObservableCollection<CitaSimple> _ListaSimpleCitas;
        /// <summary>
        /// Lista simple de las Citas.
        /// </summary>
        public ObservableCollection<CitaSimple> ListaSimpleCitas
        {
            get { return _ListaSimpleCitas; }
            set { _ListaSimpleCitas = value; }
        }

        public string JSArray
        {
            get
            {
                return string.Format("[{0}]", string.Join(",", list));
            }
        }

        //[JsonProperty]
        public Calendar Calend
        {
            get;
            set;
        }
        
        //[JsonProperty]
        public static string serializedCalend
        {
            get;
            set;
        }
        public static List<string> ListSerializedDates
        {
            get;
            set;
        }
        public List<Calendar> list = new List<Calendar>();
        protected void Page_Load(object sender, EventArgs e)
        {

            //const event = {
            //title: title,
            //    start: startDate || '2020-12-22T02:30:00',
            //    end: endDate || '2020-12-12T14:30:00',
            //    color: color || '#7858d7'
            //}

            //List<Calendar> list = new List<Calendar>();
            //list.Add(new Calendar("PRUEBA", "2022-05-07T02:30:00", "2022-05-07T14:30:00", "#7858d7"));
            //control.Attributes.Add("addEvent", list.ToString());

            //List<Calendar> list = new List<Calendar>();
            //list.Add(new Calendar("PRUEBA", "2022-07-15T05:30:00.000Z", "2022-07-15T05:30:00.000Z", "#7858d7"));
            //calendar1.Attributes.Add("addEvent", list.ToString());



            //HtmlInputText tb1 = this.txt;
            //Response.Write(tb1.Value);
            //string theValue = Request.Form["calendar1"].ToString();

            //Calend = GetCalendario();
            //serializedCalend = JsonConvert.SerializeObject(Calend);
            ////ScriptManager.RegisterStartupScript(this, typeof(Page), "initializeCalendar", "addEventCalendar()", true);
            ///
            /// 
            /// EJEMPLO DATOSMEDIX
            ////FiltrarListaSimpleCita(new CitaSimple.Criterio(CManejoSesion.CUsuario.CEmpresa.UIDEmpresa, Guid.Empty, CModulo.UIDModulo, TxtFolio.Text, uidssucursal, uidsespecialidad, uidsconsultorio, uidsturno, uidsdoctores, Guid.Empty, fecha1, fecha2, TxtNombres.Text, TxtPrimerApe.Text, TxtSegundoApe.Text, uidstipocita, uidsstatus, int.MinValue, int.MinValue, false, false));
            ///EJEMPLO 1
            /// FiltrarListaSimpleCita(new CitaSimple.Criterio(new Guid("ed0ff78d-f09d-41f1-8a75-80204feddf18"), Guid.Empty, new Guid("7dc31f3d-eb64-47cd-9056-3b926ec4a549"), "", "", "", "", "", "", Guid.Empty, DateTime.MinValue, DateTime.MinValue, "", "", "", "", "", int.MinValue, int.MinValue, false, false));
            /// STAGGING CLINICA MEDIMAR TODAS LAS CITAS
            ///FiltrarListaSimpleCita(new CitaSimple.Criterio(new Guid("9d978144-e341-4df3-9ef3-600cfb5f3d73"), Guid.Empty, new Guid("7dc31f3d-eb64-47cd-9056-3b926ec4a549"), "", "", "", "", "", "", Guid.Empty, DateTime.MinValue, DateTime.MinValue, "", "", "", "", "", int.MinValue, int.MinValue, false, false));
            /// STAGGING CLINICA MEDIMAR TODAS LAS CITAS DEL AÑO PRESENTE
            FiltrarListaSimpleCita(new CitaSimple.Criterio(new Guid("9d978144-e341-4df3-9ef3-600cfb5f3d73"), Guid.Empty, new Guid("7dc31f3d-eb64-47cd-9056-3b926ec4a549"), "", "", "", "", "", "", Guid.Empty, new DateTime(int.Parse(DateTime.Now.Year.ToString()), 5, 1, 00, 00, 00), DateTime.MinValue, "", "", "", "", "", int.MinValue, int.MinValue, false, false));

            GetListCalendario();
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {

            
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "initializeCalendar", "addEventCalendar(" + JsonConvert.SerializeObject(Calend) + ")", true);
            //Register script if you are using ScriptManager
            //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "JSScript", "addEventCalendar(" + JsonConvert.SerializeObject(Calend) + ");", true);
        }
        public static Calendar GetCalendario()
        {
            return new Calendar { title = "PRUEBA", start = "2022-07-15T05:30:00.000Z", end = "2022-07-15T05:30:00.000Z", color = "#7858d7" };
        }
        //public static List<Calendar> GetCalendario()
        //{
        //    return new Calendar { title = "PRUEBA", start = "2022-07-15T05:30:00.000Z", end = "2022-07-15T05:30:00.000Z", color = "#7858d7" };
        //}
        public  void GetListCalendario()
        {
            ////FILTRADO DE LISTA POR CODIGO
            //DateTime datePast = new DateTime(int.Parse(DateTime.Now.Year.ToString()), 1, 1, 00, 00, 00);
            ////DateTime datePast = DateTime.Now.AddMonths(-3);
            //ObservableCollection<CitaSimple> ListaSimpleCitas = new ObservableCollection<CitaSimple>((from d in _ListaSimpleCitas where d.DtmFechaHoraInicio >= datePast select d).ToList() as List<CitaSimple>);

            ///SIN FILTRADO DE LISTA POR CODIGO
            ObservableCollection<CitaSimple> ListaSimpleCitas = _ListaSimpleCitas;

            ///PROCESO DE CONVERSION
            List <Calendar> lista = new List<Calendar>();
            foreach (CitaSimple item in ListaSimpleCitas)
            {
                if ((item.DtmFechaHoraInicio-item.DtmFechaHoraFin).TotalMinutes < 30)
                {
                    item.DtmFechaHoraFin = item.DtmFechaHoraInicio.AddMinutes(30);
                }
                lista.Add(new Calendar { title = item.StrNombresPaciente, start = item.DtmFechaHoraInicio.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"), end = item.DtmFechaHoraFin.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"), color = "#7858d7" });
            }
            ListSerializedDates = new List<string>();
            foreach (Calendar item in lista)
            {
                ListSerializedDates.Add(JsonConvert.SerializeObject(item));
            }
            //return lista;
        }
        [WebMethod]
        [ScriptMethod()]
        public static List<string> GetCalendarioSerializado()
        {
             //new JsonResult(new { title = "PRUEBA", start = "2022-07-15T05:30:00.000Z", end = "2022-07-15T05:30:00.000Z", color = "#7858d7" });

            return ListSerializedDates;

            //string seri = JsonConvert.SerializeObject(GetCalendario());
            //return seri;
        }
        public void FiltrarListaSimpleCita(CitaSimple.Criterio criterio)
        {
            _ListaSimpleCitas = ObtenerListaSimpleCitas(criterio);
        }
        public static ObservableCollection<CitaSimple> ObtenerListaSimpleCitas(CitaSimple.Criterio criterio)
        {
            try
            {
                // Crear comando de consulta
                SqlCommand comando = ConvertirCriterioCitaSimpleAComando(criterio);
                // Asignar nombre del Stored Procedure
                comando.CommandText = "medsp_ObtenerListaSimpleCitas";
                // Crear objeto de comunicación con la BD
                BDConector conector = new BDConector();
                // Crear tabla que almacenará temporalmente los resultados.
                DataTable tabla = conector.ConsultarDB(comando);
                // Crear lista de CitaSimple
                ObservableCollection<CitaSimple> lista = new ObservableCollection<CitaSimple>();
                // Agregar los elementos de la tabla a la lista
                foreach (DataRow registro in tabla.Rows)
                {
                    lista.Add(ConvertirDataRowACitaSimple(registro));
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo realizar la consulta a la Base de Datos.\n" + ex.Message);
            }
        }
        static SqlCommand ConvertirCriterioCitaSimpleAComando(CitaSimple.Criterio criterio)
        {
            try
            {
                // Crear SqlCommand
                SqlCommand comando = new SqlCommand();
                // Asignarle el tipo StoredProcedure
                comando.CommandType = CommandType.StoredProcedure;
                // Leer parámetros del criterio
                if (criterio.UIDEmpresa != Guid.Empty && criterio.UIDEmpresa != new Guid()) // UID de la empresa
                {
                    comando.Parameters.Add("@UIDEmpresa", SqlDbType.UniqueIdentifier);
                    comando.Parameters["@UIDEmpresa"].Value = criterio.UIDEmpresa;
                }
                if (criterio.UIDCita != Guid.Empty && criterio.UIDCita != new Guid()) // UID de la Cita
                {
                    comando.Parameters.Add("@UIDCita", SqlDbType.UniqueIdentifier);
                    comando.Parameters["@UIDCita"].Value = criterio.UIDCita;
                }
                if (criterio.UIDModulo != Guid.Empty && criterio.UIDModulo != new Guid()) // UID de la Cita
                {
                    comando.Parameters.Add("@UIDModulo", SqlDbType.UniqueIdentifier);
                    comando.Parameters["@UIDModulo"].Value = criterio.UIDModulo;
                }
                if (criterio.IntFolioCita != 0) // Número de Folio de la Cita.
                {
                    comando.Parameters.Add("@IntFolioCita", SqlDbType.Int);
                    comando.Parameters["@IntFolioCita"].Value = criterio.IntFolioCita;
                }
                if (criterio.StrUIDsSucursal != string.Empty && criterio.StrUIDsSucursal != "") // UID de la Sucursal.
                {
                    comando.Parameters.Add("@UIDsSucursal", SqlDbType.VarChar);
                    comando.Parameters["@UIDsSucursal"].Value = criterio.StrUIDsSucursal;
                }
                if (criterio.StrUIDsEspecialidad != string.Empty && criterio.StrUIDsEspecialidad != "") // UID de la Especialidad.
                {
                    comando.Parameters.Add("@UIDsEspecialidad", SqlDbType.VarChar);
                    comando.Parameters["@UIDsEspecialidad"].Value = criterio.StrUIDsEspecialidad;
                }
                if (criterio.StrUIDsConsultorios != string.Empty && criterio.StrUIDsConsultorios != "") // UID del Consultorio.
                {
                    comando.Parameters.Add("@UIDsConsultorio", SqlDbType.VarChar);
                    comando.Parameters["@UIDsConsultorio"].Value = criterio.StrUIDsConsultorios;
                }
                if (criterio.StrUIDsTurno != string.Empty && criterio.StrUIDsTurno != "") // UIDs del Turno.
                {
                    comando.Parameters.Add("@UIDsTurno", SqlDbType.VarChar);
                    comando.Parameters["@UIDsTurno"].Value = criterio.StrUIDsTurno;
                }
                if (criterio.StrUIDsDoctores != string.Empty && criterio.StrUIDsDoctores != "") // UID del Doctor.
                {
                    comando.Parameters.Add("@UIDsDoctores", SqlDbType.VarChar);
                    comando.Parameters["@UIDsDoctores"].Value = criterio.StrUIDsDoctores;
                }
                if (criterio.UIDPaciente != Guid.Empty && criterio.UIDPaciente != new Guid())
                {
                    comando.Parameters.Add("@UIDPaciente", SqlDbType.UniqueIdentifier);
                    comando.Parameters["@UIDPaciente"].Value = criterio.UIDPaciente;
                }
                if (criterio.StrUIDsTipoCita != null)
                {
                    if (criterio.StrUIDsTipoCita != string.Empty && criterio.StrUIDsTipoCita != "")
                    {
                        comando.Parameters.Add("@UIDsTipoCita", SqlDbType.VarChar);
                        comando.Parameters["@UIDsTipoCita"].Value = criterio.StrUIDsTipoCita;
                    }
                }
                if (criterio.StrUIDsStatus != string.Empty && criterio.StrUIDsStatus != "")
                {
                    comando.Parameters.Add("@UIDsStatus", SqlDbType.VarChar);
                    comando.Parameters["@UIDsStatus"].Value = criterio.StrUIDsStatus;
                }
                if (criterio.DtmFechaInicio != DateTime.MinValue) // Fecha de Inicio de la Cita
                {
                    comando.Parameters.Add("@DtmFechaInicio", SqlDbType.DateTime);
                    comando.Parameters["@DtmFechaInicio"].Value = criterio.DtmFechaInicio;
                }
                if (criterio.DtmFechaInicio2 != DateTime.MinValue)
                {
                    comando.Parameters.Add("@DtmFechaInicio2", SqlDbType.DateTime);
                    comando.Parameters["@DtmFechaInicio2"].Value = criterio.DtmFechaInicio2;
                }
                if (criterio.StrNombresPaciente != string.Empty) // Nombre(s) del Paciente.
                {
                    comando.Parameters.Add("@VchNombres", SqlDbType.VarChar, 150);
                    comando.Parameters["@VchNombres"].Value = criterio.StrNombresPaciente;
                }
                if (criterio.StrPrimerApellidoPaciente != string.Empty) // Primer Apellido del Paciente.
                {
                    comando.Parameters.Add("@VchPrimerApe", SqlDbType.VarChar, 100);
                    comando.Parameters["@VchPrimerApe"].Value = criterio.StrPrimerApellidoPaciente;
                }
                if (criterio.StrSegundoApellidoPaciente != string.Empty) // Segundo Apellido del Paciente.
                {
                    comando.Parameters.Add("@VchSegundoApe", SqlDbType.VarChar, 100);
                    comando.Parameters["@VchSegundoApe"].Value = criterio.StrSegundoApellidoPaciente;
                }
                if (criterio.IntHoraInicio != int.MinValue)
                {
                    comando.Parameters.Add("@IntHoraInicio", SqlDbType.Int);
                    comando.Parameters["@IntHoraInicio"].Value = criterio.IntHoraInicio;
                }
                if (criterio.IntMinutoInicio != int.MinValue)
                {
                    comando.Parameters.Add("@IntMinutoInicio", SqlDbType.Int);
                    comando.Parameters["@IntMinutoInicio"].Value = criterio.IntMinutoInicio;
                }
                if (criterio.BolFiltroPagado)
                {
                    comando.Parameters.Add("@BitPagado", SqlDbType.Bit);
                    comando.Parameters["@BitPagado"].Value = criterio.BolPagado;
                }
                return comando;
            }
            catch (Exception ex)
            {
                throw new Exception("(ConvertirCriterioCitaSimpleAComando)" + ex.Message);
            }
        }
        private static CitaSimple ConvertirDataRowACitaSimple(DataRow registro)
        {
            try
            {
                string uidcita = registro["UIDCita"].ToString();
                string folio = registro["IntFolioCita"].ToString();
                string fechahorainicio = registro["DtmFechaHoraInicio"].ToString();
                string fechahorafin = registro["DtmFechaHoraFin"].ToString();
                Guid uidtipocita = new Guid(registro["UIDTipoCita"].ToString());
                string consultorio = registro["VchNombreConsultorio"].ToString();
                string turno = registro["VchNombreTurno"].ToString();
                string nombresdr = string.Empty;
                if (registro["VchNombresDoctor"].ToString() != string.Empty && registro["VchNombresDoctor"].ToString().Trim() != "")
                {
                    nombresdr = registro["VchNombresDoctor"].ToString();
                }
                string primerapedr = string.Empty;
                if (registro["VchPrimerApeDoctor"].ToString() != string.Empty && registro["VchPrimerApeDoctor"].ToString().Trim() != "")
                {
                    primerapedr = registro["VchPrimerApeDoctor"].ToString();
                }
                string nombrespac = string.Empty;
                if (registro["VchNombresPaciente"].ToString() != string.Empty && registro["VchNombresPaciente"].ToString().Trim() != "")
                {
                    nombrespac = registro["VchNombresPaciente"].ToString();
                }
                string primerapepac = registro["VchPrimerApePaciente"].ToString();
                if (registro["VchPrimerApePaciente"].ToString() != string.Empty && registro["VchPrimerApePaciente"].ToString().Trim() != "")
                {
                    primerapepac = registro["VchPrimerApePaciente"].ToString();
                }
                string status = registro["VchStatusCita"].ToString();
                string especialidad = string.Empty;
                if (registro["VchEspecialidad"].ToString() != string.Empty && registro["VchEspecialidad"].ToString().Trim() != "")
                {
                    especialidad = registro["VchEspecialidad"].ToString();
                }
                string iconoweb = registro["VchIconoWeb"].ToString();
                string iconoescritorio = registro["VchIconoEscritorio"].ToString();
                string claserowweb = registro["VchWebRowClass"].ToString();
                int orden = int.Parse(registro["Orden"].ToString());
                bool pagado = bool.Parse(registro["BitPagado"].ToString());
                string iconotipocita = registro["VchIconoTipoCita"].ToString();
                string tipocita = registro["VchTipoCita"].ToString();
                return new CitaSimple(uidcita, folio, fechahorainicio, fechahorafin, uidtipocita, consultorio, turno, nombresdr, primerapedr, nombrespac, primerapepac, status, especialidad, iconoweb, iconoescritorio, claserowweb, orden, false, pagado, iconotipocita, tipocita);
            }
            catch (Exception ex)
            {
                throw new Exception("(ConvertirDataRowACitaSimple)" + ex.Message);
            }
        }
    }

    //[JsonObject(MemberSerialization.OptIn)]
    public class Calendar
    {
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string color { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Address { get; set; }

        //public Calendar(){}

        //public Calendar(string title, string start, string end, string color)
        //{
        //    this.title = title;
        //    this.start = start;
        //    this.end = end;
        //    this.color = color;
        //}
    }
   
}