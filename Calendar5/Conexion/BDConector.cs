using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace Calendar5.Conexion
{
    public class BDConector
    {
        // Password para Publicar:
        // iEZLQjJjrP4Z998yhutRjEiCaNcpFPMvfFwRyYRgDlMgT80AJeBQeXq9udwr
        // Cadena de la conexion a la Base de Datos
        // Cadena de conexión para pruebas locales
        // https://localhost:44357

        private string _StrIdDB = AppSettings.StrIdDB;
        string cadenaconex = AppSettings.CnnStr;

        public string StrIdDB
        {
            get { return _StrIdDB; }
        }
        // Función que devuelve una tabla con los resultados de la búsqueda
        public virtual DataTable ConsultarDB(string Query)
        {
            SqlCommand comando = new SqlCommand(Query);
            return ConsultarDB(comando);
        }
        // Función que devuelve una tabla con los resultados de la búsqueda
        public virtual DataTable ConsultarDB(SqlCommand comando)
        {
            // Conexion SQL
            SqlConnection conexion = new SqlConnection(cadenaconex);
            // Adaptador para comunicarse a la DB
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            // Tabla que almacenará los resultados
            DataTable tabla = new DataTable();

            // Intentar realizar la consulta
            try
            {
                // Abrir conexión
                conexion.Open();
                // Asignar conexión al SQLCommand
                comando.Connection = conexion;
                // Llenar la tabla con los resultados
                adaptador.Fill(tabla);
            }
            catch (Exception ex)
            {
                // Este espacio está destinado al manejo de los errores en la consulta
                // Más adelante se determinarán las acciones a realizar
                string error = ex.Message;
            }
            finally
            {
                // Cerrar la conexión
                conexion.Close();
                // Desechar conexión
                conexion.Dispose();
            }
            return tabla;
        }
        // Función que devuelve un Dataset
        public virtual DataSet ConsultarDBVariosResultados(SqlCommand comando)
        {
            // Conexion SQL
            SqlConnection conexion = new SqlConnection(cadenaconex);
            // Adaptador para comunicarse a la DB
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            // Tabla que almacenará los resultados
            DataSet dataset = new DataSet();

            // Intentar realizar la consulta
            try
            {
                // Abrir conexión
                conexion.Open();
                // Asignar conexión al SQLCommand
                comando.Connection = conexion;
                // Llenar la tabla con los resultados
                adaptador.Fill(dataset);
            }
            catch (Exception ex)
            {
                // Este espacio está destinado al manejo de los errores en la consulta
                // Más adelante se determinarán las acciones a realizar
                string error = ex.Message;
            }
            finally
            {
                // Cerrar la conexión
                conexion.Close();
                // Desechar conexión
                conexion.Dispose();
            }
            return dataset;
        }
        // Función para insertar registros a la Base de Datos
        public virtual void Insertar(SqlCommand comando)
        {
            // Conexion SQL
            SqlConnection conexion = new SqlConnection(cadenaconex);

            // Intentar realizar la consulta
            try
            {
                // Abrir Conexión
                conexion.Open();
                // Asignar conexión al SQLCommand
                comando.Connection = conexion;
                // Ejecutar el comando
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Aun por definir que hacer con las excepciones
                throw new DBConectorException("Error en DBConector - Insertar:" + ex.Message);
            }
            finally
            {
                // Cerrar Conexión
                conexion.Close();
                // Desechar Conexión
                conexion.Dispose();
            }
        }
        // Función para actualizar registros de la base de datos
        public virtual void ActualizarBD(SqlCommand comando)
        {

            // Conexión SQL
            SqlConnection conexion = new SqlConnection(cadenaconex);

            // Intentar realizar la consulta
            try
            {
                // Abrir conexión
                conexion.Open();
                // Asignar conexión al SQLCommand
                comando.Connection = conexion;
                // Ejecutar el comando
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBConectorException("(ActualizarBD)" + ex.Message);
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }
        }
        // Función para actualizar registros de la base de datos
        public virtual void EliminarBD(SqlCommand comando)
        {

            // Conexión SQL
            SqlConnection conexion = new SqlConnection(cadenaconex);

            // Intentar realizar la consulta
            try
            {
                // Abrir conexión
                conexion.Open();
                // Asignar conexión al SQLCommand
                comando.Connection = conexion;
                // Ejecutar el comando
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBConectorException("(EliminarBD)" + ex.Message);
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }
        }
        class DBConectorException : Exception
        {
            public DBConectorException(string mensaje) : base("(DBConectorException)" + mensaje) { }
        }
    }
}