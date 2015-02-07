using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AppTalentosYTecnologia
{
    public class ConnectionClass
    {
        private static SqlCommand command;
        private static SqlConnection conn;

        static ConnectionClass()
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["TalentosConnectionString"].ToString();
            conn = new SqlConnection(cadenaConexion);
            command = new SqlCommand("", conn);
        }

        public static int consultarCantidad(int idProducto)
        {
            conn.Open();
            string query = "SELECT Cantidad FROM Producto WHERE IdProducto = "+idProducto;
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            int cantidad = (int)(command.ExecuteScalar());  //Se hace la consulta y se almacena el valor en una variable executeScalar devuelve el primer valor de la
            conn.Close();                                   //primera columna y fila, hay que hacer la conversion de objeto a entero
            return cantidad;
        }

        public static int RegistrarCompra(int idCliente, int idProducto, int cantidad)
        {
            conn.Open();
            string query = "INSERT INTO Venta (IdProducto, IdCliente, Cantidad) VALUES (" + idProducto + "," + idCliente + "," + cantidad + ")";
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            int numFil = command.ExecuteNonQuery();
            conn.Close();
            return numFil;
        }

        public static void ActualizarProducto(int idProducto, int cantidad)
        {
            conn.Open();
            string query = "UPDATE Producto SET Cantidad = " + cantidad + " WHERE IdProducto = " + idProducto;
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
            conn.Close();

        }
    }
}