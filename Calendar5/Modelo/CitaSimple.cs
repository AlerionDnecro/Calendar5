using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using Calendar5.Conexion;

namespace Calendar5.Modelo
{
    public class CitaSimple
    {
        #region Propiedades

        Guid _UIDCita = Guid.Empty;
        /// <summary>
        /// UID de la Cita.
        /// </summary>
        public Guid UIDCita
        {
            get { return _UIDCita; }
            set { _UIDCita = value; }
        }

        public string StrURLMiCita
        {
            get { return AppSettings.AppUrl + "/View/WFrMiCita.aspx?" + _UIDCita.ToString(); }
        }

        int _IntFolioCita = 0;
        /// <summary>
        /// Número de Folio de la Cita.
        /// </summary>
        public int IntFolioCita
        {
            get { return _IntFolioCita; }
            set { _IntFolioCita = value; }
        }

        DateTime _DtmFechaHoraInicio = DateTime.MinValue;
        /// <summary>
        /// Fecha y hora de inicio de la Cita.
        /// </summary>
        public DateTime DtmFechaHoraInicio
        {
            get { return _DtmFechaHoraInicio; }
            set { _DtmFechaHoraInicio = value; }
        }

        DateTime _DtmFechaHoraFin = DateTime.MinValue;
        public DateTime DtmFechaHoraFin
        {
            get { return _DtmFechaHoraFin; }
            set { _DtmFechaHoraFin = value; }
        }

        Guid _UIDTipoCita = Guid.Empty;
        public Guid UIDTipoCita
        {
            get { return _UIDTipoCita; }
            set { _UIDTipoCita = value; }
        }

        /// <summary>
        /// Duración de la cita en minutos.
        /// </summary>
        public long IntDuracion
        {
            get
            {
                long ticks = _DtmFechaHoraFin.Ticks - _DtmFechaHoraInicio.Ticks;
                return ticks / 600000000;
            }
        }

        string _StrConsultorio = string.Empty;
        /// <summary>
        /// Nombre del Consultorio.
        /// </summary>
        public string StrConsultorio
        {
            get { return _StrConsultorio; }
            set { _StrConsultorio = value; }
        }

        string _StrTurno = string.Empty;
        /// <summary>
        /// Nombre del Turno.
        /// </summary>
        public string StrTurno
        {
            get { return _StrTurno; }
            set { _StrTurno = value; }
        }

        string _StrNombresDoctor = string.Empty;
        /// <summary>
        /// Nombre(s) del Doctor.
        /// </summary>
        public string StrNombresDoctor
        {
            get { return _StrNombresDoctor; }
            set { _StrNombresDoctor = value; }
        }

        string _StrPrimerApellidoDoctor = string.Empty;
        /// <summary>
        /// Primer apellido del Doctor.
        /// </summary>
        public string StrPrimerApellidoDoctor
        {
            get { return _StrPrimerApellidoDoctor; }
            set { _StrPrimerApellidoDoctor = value; }
        }

        /// <summary>
        /// Nombre completo corto del doctor (Nombres y primer apellido).
        /// </summary>
        public string StrNombreCompletoDoctor
        {
            get { return (_StrNombresDoctor + " " + _StrPrimerApellidoDoctor).Trim(); }
        }

        string _StrNombresPaciente = string.Empty;
        /// <summary>
        /// Nombre(s) del Paciente.
        /// </summary>
        public string StrNombresPaciente
        {
            get { return _StrNombresPaciente; }
            set { _StrNombresPaciente = value; }
        }

        string _StrPrimerApellidoPaciente = string.Empty;
        /// <summary>
        /// Primer Apellido del paciente.
        /// </summary>
        public string StrPrimerApellidoPaciente
        {
            get { return _StrPrimerApellidoPaciente; }
            set { _StrPrimerApellidoPaciente = value; }
        }

        /// <summary>
        /// Nombre completo corto del Paciente (Nombres y primer apellido).
        /// </summary>
        public string StrNombreCompletoPaciente
        {
            get { return (_StrNombresPaciente + " " + _StrPrimerApellidoPaciente).Trim(); }
        }

        string _StrStatus = string.Empty;
        /// <summary>
        /// Status actual de la Cita.
        /// </summary>
        public string StrStatus
        {
            get { return _StrStatus; }
            set { _StrStatus = value; }
        }

        string _StrEspecialidad = string.Empty;
        /// <summary>
        /// Nombre de la Especialidad.
        /// </summary>
        public string StrEspecialidad
        {
            get { return _StrEspecialidad; }
            set { _StrEspecialidad = value; }
        }

        string _StrIconoWeb = string.Empty;
        public string StrIconoWeb
        {
            get { return _StrIconoWeb; }
            set { _StrIconoWeb = value; }
        }

        string _StrIconoEscritorio = string.Empty;
        public string StrIconoEscritorio
        {
            get { return _StrIconoEscritorio; }
            set { _StrIconoEscritorio = value; }
        }

        string _StrClaseRowWeb = string.Empty;
        public string StrClaseRowWeb
        {
            get { return _StrClaseRowWeb; }
            set { _StrClaseRowWeb = value; }
        }

        int _IntOrdenStatus = int.MinValue;
        public int IntOrdenStatus
        {
            get { return _IntOrdenStatus; }
            set { _IntOrdenStatus = value; }
        }

        private bool _BolSeleccionado = false;
        public bool BolSeleccionado
        {
            get { return _BolSeleccionado; }
            set { _BolSeleccionado = value; }
        }

        private bool _BolPagado = false;
        public bool BolPagado
        {
            get { return _BolPagado; }
            set { _BolPagado = value; }
        }
        private string _StrIconoTipoCita = string.Empty;
        public string StrIconoTipoCita
        {
            get { return _StrIconoTipoCita; }
            set { _StrIconoTipoCita = value; }
        }
        private string _StrTipoCita = string.Empty;
        public string StrTipoCita
        {
            get { return _StrTipoCita; }
            set { _StrTipoCita = value; }
        }
        #endregion

        #region Criterio de búsqueda

        /// <summary>
        /// Criterio de búsqueda.
        /// </summary>
        public class Criterio
        {

            #region Propiedades

            Guid _UIDEmpresa = Guid.Empty;
            /// <summary>
            /// UID de la Empresa.
            /// </summary>
            public Guid UIDEmpresa
            {
                get { return _UIDEmpresa; }
            }

            Guid _UIDCita = Guid.Empty;
            /// <summary>
            /// UID de la Cita.
            /// </summary>
            public Guid UIDCita
            {
                get { return _UIDCita; }
            }

            Guid _UIDModulo = Guid.Empty;
            public Guid UIDModulo
            {
                get { return _UIDModulo; }
            }

            int _IntFolioCita = 0;
            /// <summary>
            /// Número de Folio de la Cita.
            /// </summary>
            public int IntFolioCita
            {
                get { return _IntFolioCita; }
            }

            string _StrUIDsSucursal = string.Empty;
            public string StrUIDsSucursal
            {
                get { return _StrUIDsSucursal; }
            }

            string _StrUIDsEspecialidad = string.Empty;
            public string StrUIDsEspecialidad
            {
                get { return _StrUIDsEspecialidad; }
            }

            string _StrUIDsConsultorios = string.Empty;
            public string StrUIDsConsultorios
            {
                get { return _StrUIDsConsultorios; }
                set { _StrUIDsConsultorios = value; }
            }

            string _StrUIDsTurno = string.Empty;
            public string StrUIDsTurno
            {
                get { return _StrUIDsTurno; }
            }

            string _StrUIDsDoctores = string.Empty;
            public string StrUIDsDoctores
            {
                get { return _StrUIDsDoctores; }
                set { _StrUIDsDoctores = value; }
            }

            Guid _UIDPaciente = Guid.Empty;
            /// <summary>
            /// UID del Paciente.
            /// </summary>
            public Guid UIDPaciente
            {
                get { return _UIDPaciente; }
            }

            private string _StrUIDsTipoCita;
            public string StrUIDsTipoCita
            {
                get { return _StrUIDsTipoCita; }
                set { _StrUIDsTipoCita = value; }
            }

            string _StrUIDsStatus = string.Empty;
            public string StrUIDsStatus
            {
                get { return _StrUIDsStatus; }
            }

            DateTime _DtmFechaInicio = DateTime.MinValue;
            /// <summary>
            /// Fecha inicial de búsqueda de la Cita.
            /// </summary>
            public DateTime DtmFechaInicio
            {
                get { return _DtmFechaInicio; }
            }

            DateTime _DtmFechaInicio2 = DateTime.MinValue;
            /// <summary>
            /// Fecha final de búsqueda de la Cita.
            /// </summary>
            public DateTime DtmFechaInicio2
            {
                get { return _DtmFechaInicio2; }
                set { _DtmFechaInicio2 = value; }
            }

            string _StrNombresPaciente = string.Empty;
            /// <summary>
            /// Nombres del Paciente.
            /// </summary>
            public string StrNombresPaciente
            {
                get { return _StrNombresPaciente; }
            }

            string _StrPrimerApellidoPaciente = string.Empty;
            /// <summary>
            /// Primer Apellido del Paciente.
            /// </summary>
            public string StrPrimerApellidoPaciente
            {
                get { return _StrPrimerApellidoPaciente; }
            }

            string _StrSegundoApellidoPaciente = string.Empty;
            /// <summary>
            /// Segundo Apellidos del Paciente.
            /// </summary>
            public string StrSegundoApellidoPaciente
            {
                get { return _StrSegundoApellidoPaciente; }
            }

            int _IntHoraInicio = int.MinValue;
            public int IntHoraInicio
            {
                get { return _IntHoraInicio; }
            }

            int _IntMinutoInicio = int.MinValue;
            public int IntMinutoInicio
            {
                get { return _IntMinutoInicio; }
            }

            private bool _BolFiltroPagado;
            public bool BolFiltroPagado
            {
                get { return _BolFiltroPagado; }
            }

            private bool _BolPagado;
            public bool BolPagado
            {
                get { return _BolPagado; }
            }

            #endregion

            #region Funciones
            public SqlCommand ConvertirAComandoSQL(bool storedprocedure = true)
            {
                SqlCommand comando = new SqlCommand();
                if (storedprocedure) comando.CommandType = CommandType.StoredProcedure;
                else comando.CommandType = CommandType.Text;
                if (_UIDCita != Guid.Empty && _UIDCita != new Guid())
                {
                    comando.Parameters.Add(new SqlParameter("@UidCita", SqlDbType.UniqueIdentifier)).Value = _UIDCita;
                }
                return comando;
            }
            #endregion Funciones

            #region Constructores

            /// <summary>
            /// Crea un nuevo criterio de búsqueda con valores nulos o vacíos. Se emplea para obtener una lista de TODAS
            /// las citas en la Base de Datos.
            /// </summary>
            public Criterio() { }

            /// <summary>
            /// Crea un nuevo criterio con strings como parámetros.
            /// </summary>
            /// <param name="uidempresa">UID de la empresa.</param>
            /// <param name="uidcita">UID de la cita.</param>
            /// <param name="foliocita">Número de folio de la cita.</param>
            /// <param name="uidssucursal">UID de la sucursal.</param>
            /// <param name="uidsespecialidad">UID de la especialidad.</param>
            /// <param name="uidsconsultorio">UID del consultorio.</param>
            /// <param name="uidsturno">UID del turno.</param>
            /// <param name="uidsdoctores">UID del doctor.</param>
            /// <param name="uidpaciente">UID del paciente.</param>
            /// <param name="uidstatus">UID del status.</param>
            /// <param name="fechainicio">Fecha de inicio de la cita.</param>
            /// <param name="nombrespaciente">Nombre(s) del paciente.</param>
            /// <param name="primerapepaciente">Primer apellido del paciente.</param>
            /// <param name="segundoapepaciente">Segundo apellido del paciente.</param>
            public Criterio(Guid uidempresa, Guid uidcita, Guid uidmodulo, string foliocita,
                string uidssucursal, string uidsespecialidad, string uidsconsultorio, string uidsturno,
                string uidsdoctores, Guid uidpaciente, DateTime fechainicio, DateTime fechainicio2,
                string nombrespaciente, string primerapepaciente, string segundoapepaciente,
                string uidstipocita, string uidsstatus, int horainicio, int minutoinicio, bool filtrarpagado, bool pagado)
            {
                try
                {
                    if (uidempresa != Guid.Empty && uidempresa != new Guid())
                    {
                        _UIDEmpresa = uidempresa;
                    }
                    if (uidcita != Guid.Empty && uidcita != new Guid())
                    {
                        _UIDCita = uidcita;
                    }
                    if (uidmodulo != Guid.Empty && uidmodulo != new Guid())
                    {
                        _UIDModulo = uidmodulo;
                    }
                    if (foliocita != string.Empty && foliocita.Trim() != "" && foliocita.Trim() != "0")
                    {
                        _IntFolioCita = Int32.Parse(foliocita.Trim());
                    }
                    if (uidssucursal != string.Empty && uidssucursal.Trim() != "")
                    {
                        _StrUIDsSucursal = uidssucursal.Trim();
                    }
                    if (uidsespecialidad != string.Empty && uidsespecialidad.Trim() != "")
                    {
                        _StrUIDsEspecialidad = uidsespecialidad.Trim();
                    }
                    if (uidsconsultorio != string.Empty && uidsconsultorio.Trim() != "")
                    {
                        _StrUIDsConsultorios = uidsconsultorio.Trim();
                    }
                    if (uidsturno != string.Empty && uidsturno.Trim() != "")
                    {
                        _StrUIDsTurno = uidsturno.Trim();
                    }
                    if (uidsdoctores != string.Empty && uidsdoctores.Trim() != "")
                    {
                        _StrUIDsDoctores = uidsdoctores.Trim();
                    }
                    if (uidpaciente != Guid.Empty && uidpaciente != new Guid())
                    {
                        _UIDPaciente = uidpaciente;
                    }
                    if (fechainicio != DateTime.MinValue)
                    {
                        _DtmFechaInicio = fechainicio;
                    }
                    if (fechainicio2 != DateTime.MinValue)
                    {
                        _DtmFechaInicio2 = fechainicio2;
                    }
                    if (nombrespaciente != string.Empty && nombrespaciente.Trim() != "")
                    {
                        _StrNombresPaciente = FuncionesString.FormatearStringConsulta(nombrespaciente.Trim());
                    }
                    if (primerapepaciente != string.Empty && primerapepaciente.Trim() != "")
                    {
                        _StrPrimerApellidoPaciente = FuncionesString.FormatearStringConsulta(primerapepaciente.Trim());
                    }
                    if (segundoapepaciente != string.Empty && segundoapepaciente.Trim() != "")
                    {
                        _StrSegundoApellidoPaciente = FuncionesString.FormatearStringConsulta(segundoapepaciente.Trim());
                    }
                    if (uidstipocita != string.Empty && uidstipocita.Trim() != "")
                    {
                        _StrUIDsTipoCita = uidstipocita.Trim();
                    }
                    if (uidsstatus != string.Empty && uidsstatus.Trim() != "")
                    {
                        _StrUIDsStatus = uidsstatus.Trim();
                    }
                    if (horainicio != int.MinValue)
                    {
                        _IntHoraInicio = horainicio;
                    }
                    if (minutoinicio != int.MinValue)
                    {
                        _IntMinutoInicio = minutoinicio;
                    }
                    _BolFiltroPagado = filtrarpagado;
                    _BolPagado = pagado;
                }
                catch (Exception ex)
                {
                    throw new CitaSimpleCriterioException(ex.Message);
                }
            }

            #endregion Constructores

            #region Excepciones

            public class CitaSimpleCriterioException : Exception
            {
                public CitaSimpleCriterioException(string mensaje)
                    : base("(CitaSimpleCriterioException)" + mensaje)
                {
                }
            }

            #endregion Excepciones

        }

        #endregion

        #region Métodos
        #endregion

        #region Constructores

        /// <summary>
        /// Crea una Cita Simple con los valores nulos o vacíos.
        /// </summary>
        public CitaSimple()
        {
        }

        /// <summary>
        /// Crea una simple.
        /// </summary>
        /// <param name="uidcita">UID de la cita.</param>
        /// <param name="foliocita">Folio de la cita.</param>
        /// <param name="fechahorainicio">Fecha y hora de inicio de la cita.</param>
        /// <param name="fechahorafin">Duración en minutos de la cita.</param>
        /// <param name="nombreconsultorio">Nombre del consultorio.</param>
        /// <param name="nombreturno">Nombre del turno.</param>
        /// <param name="nombresdoctor">Nombre(s) del doctor.</param>
        /// <param name="primerapedoctor">Primer apellido del doctor.</param>
        /// <param name="nombrespaciente">Nombre(s) del paciente.</param>
        /// <param name="primerapepaciente">Primer apellido del paciente.</param>
        /// <param name="statuscita">Status actual de la cita.</param>
        /// <param name="especialidad">Especialidad de la cita.</param>
        public CitaSimple(string uidcita, string foliocita, string fechahorainicio, string fechahorafin, Guid uidtipocita,
            string nombreconsultorio, string nombreturno, string nombresdoctor, string primerapedoctor,
            string nombrespaciente, string primerapepaciente, string statuscita, string especialidad,
            string iconoweb, string iconoescritorio, string claserowweb, int ordenstatus, bool seleccionado, bool pagado, string iconotipocita, string tipocita)
        {
            try
            {
                if (uidcita != string.Empty && uidcita.Trim() != "")
                {
                    _UIDCita = new Guid(uidcita.Trim());
                }
                if (foliocita != string.Empty && foliocita.Trim() != "" && foliocita.Trim() != "0")
                {
                    _IntFolioCita = Int32.Parse(foliocita.Trim());
                }
                if (uidtipocita != Guid.Empty && uidtipocita != new Guid())
                {
                    _UIDTipoCita = uidtipocita;
                }
                if (fechahorainicio != string.Empty && fechahorainicio.Trim() != "")
                {
                    _DtmFechaHoraInicio = DateTime.Parse(fechahorainicio);
                }
                if (fechahorafin != string.Empty && fechahorafin.Trim() != "")
                {
                    _DtmFechaHoraFin = DateTime.Parse(fechahorafin);
                }
                if (nombreconsultorio != string.Empty && nombreconsultorio.Trim() != "")
                {
                    _StrConsultorio = nombreconsultorio.Trim();
                }
                if (nombreturno != string.Empty && nombreturno.Trim() != "")
                {
                    _StrTurno = nombreturno.Trim();
                }
                if (nombresdoctor != string.Empty && nombresdoctor.Trim() != "")
                {
                    _StrNombresDoctor = nombresdoctor.Trim();
                }
                if (primerapedoctor != string.Empty && primerapedoctor.Trim() != "")
                {
                    _StrPrimerApellidoDoctor = primerapedoctor.Trim();
                }
                if (nombrespaciente != string.Empty && nombrespaciente.Trim() != "")
                {
                    _StrNombresPaciente = nombrespaciente.Trim();
                }
                if (primerapepaciente != string.Empty && primerapepaciente.Trim() != "")
                {
                    _StrPrimerApellidoPaciente = primerapepaciente.Trim();
                }
                if (statuscita != string.Empty && statuscita.Trim() != "")
                {
                    _StrStatus = statuscita.Trim();
                }
                if (especialidad != string.Empty && especialidad.Trim() != "")
                {
                    _StrEspecialidad = especialidad.Trim();
                }
                if (iconoweb != string.Empty && iconoweb.Trim() != "")
                {
                    _StrIconoWeb = iconoweb.Trim();
                }
                if (iconoescritorio != string.Empty && iconoescritorio.Trim() != "")
                {
                    _StrIconoEscritorio = iconoescritorio.Trim();
                }
                if (claserowweb != string.Empty && claserowweb.Trim() != "")
                {
                    _StrClaseRowWeb = claserowweb.Trim();
                }
                if (ordenstatus != int.MinValue)
                {
                    _IntOrdenStatus = ordenstatus;
                }
                if (iconotipocita != string.Empty && iconotipocita.Trim() != "")
                {
                    _StrIconoTipoCita = iconotipocita;
                }
                if (tipocita != string.Empty && tipocita.Trim() != "")
                {
                    _StrTipoCita = tipocita.Trim().ToUpper();
                }
                _BolSeleccionado = seleccionado;
                _BolPagado = pagado;
            }
            catch (Exception ex)
            {
                throw new CitaSimpleException(ex.Message);
            }
        }
        public CitaSimple(DataRow registro)
        {
            try
            {
                _UIDCita = new Guid(registro["UIDCita"].ToString());
                _IntFolioCita = int.Parse(registro["IntFolioCita"].ToString());
                _DtmFechaHoraInicio = DateTime.Parse(registro["DtmFechaHoraInicio"].ToString());
                _DtmFechaHoraFin = DateTime.Parse(registro["DtmFechaHoraFin"].ToString());
                _UIDTipoCita = new Guid(registro["UIDTipoCita"].ToString());
                _StrConsultorio = registro["VchNombreConsultorio"].ToString();
                _StrTurno = registro["VchNombreTurno"].ToString();
                if (registro["VchNombresDoctor"].ToString() != string.Empty && registro["VchNombresDoctor"].ToString().Trim() != "")
                {
                    _StrNombresDoctor = registro["VchNombresDoctor"].ToString();
                }
                if (registro["VchPrimerApeDoctor"].ToString() != string.Empty && registro["VchPrimerApeDoctor"].ToString().Trim() != "")
                {
                    _StrPrimerApellidoDoctor = registro["VchPrimerApeDoctor"].ToString();
                }
                if (registro["VchNombresPaciente"].ToString() != string.Empty && registro["VchNombresPaciente"].ToString().Trim() != "")
                {
                    _StrNombresPaciente = registro["VchNombresPaciente"].ToString();
                }
                if (registro["VchPrimerApePaciente"].ToString() != string.Empty && registro["VchPrimerApePaciente"].ToString().Trim() != "")
                {
                    _StrPrimerApellidoPaciente = registro["VchPrimerApePaciente"].ToString();
                }
                _StrStatus = registro["VchStatusCita"].ToString();
                if (registro["VchEspecialidad"].ToString() != string.Empty && registro["VchEspecialidad"].ToString().Trim() != "")
                {
                    _StrEspecialidad = registro["VchEspecialidad"].ToString();
                }
                _StrIconoWeb = registro["VchIconoWeb"].ToString();
                _StrIconoEscritorio = registro["VchIconoEscritorio"].ToString();
                _StrClaseRowWeb = registro["VchWebRowClass"].ToString();
                _IntOrdenStatus = int.Parse(registro["Orden"].ToString());
                _BolPagado = bool.Parse(registro["BitPagado"].ToString());
            }
            catch (Exception ex)
            {
                throw new CitaSimpleException(ex.Message);
            }
        }

        #endregion

        #region Excepciones

        public class CitaSimpleException : Exception
        {
            public CitaSimpleException(string mensaje) : base(mensaje) { }
        }

        #endregion Excepciones
    }
}