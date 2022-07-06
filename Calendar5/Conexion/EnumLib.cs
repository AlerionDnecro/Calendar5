using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calendar5.Conexion
{
    public class EnumLib
    {
    }
    /// <summary>
    /// Indica el orden en el que se ordenan los resultados de una consulta.
    /// </summary>
    public enum Orden { ASC, DESC }
    /// <summary>
    /// Indica la Acción actual a realizar.
    /// </summary>
    public enum Accion { Insertar, AsignarServicio, AsignarUsuario, Modificar, Eliminar, Cancelar, Nada, Pagar, Descancelar, PagarCita, GuardarCita, ModificarNotaCita, ModificarPagosNota, ModificarProductosNota, Agregar, CambiarContraseña, CambiarUsuario, GenerarOrden, Mirar, SeleccionarSucursal }
    /// <summary>
    /// Indica el campo raíz a partir del cual se elige reserva la cita.
    /// </summary>
    public enum CampoCita { Sucursal, Paciente, Doctor, Especialidad, Turno, Fecha, Consultorio, Ninguno }
    public enum TipoCampo { General, Texto, Entero, Decimal, Fecha, Logico, UID, EMail, FechaHora, CEI }
    public enum SubModuloConsulta { Citas, Paciente, Antecedente, Interrogatorio, ExploracionFisica, Estudio, Diagnostico, Receta, Historico, OrdenEstudio, Nota }
    public enum Mostrar { Siempre, Nunca, CuandoTieneValor, CuandoValorMayor, CuandoValorMayorOIgual, CuandoValorMenor, CuandoValorMenorOIgual, CuandoValorIgual, CuandoValorDiferente }
    public enum TipoProcesamiento { Ninguno, SeleccionarNotas, AplicarPorcentajeGeneral, AplicarPorcentajeIndividual }
    public enum EtapaProcesamiento { Ninguno, Resumen, Notas, Resultados, Reportes }
    public enum Operador { MayorQue, MayorOIgual, MenorQue, MenorOIgual, IgualA, DiferenteA, Entre }
    public enum DiseñoImpresion { SoloImagen, CuadroDeNotas, Esquema }
    public enum CantidadImagenes { Uno, Dos, Tres, Cuatro, Seis }
    public enum TipoAlerta { Informacion, Exito, Alerta, Peligro }
    public enum AppEnvironment { Localhost, Localhost2, Develop, Staging, Production }
}