using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Proyecto_isss_seguro.Clases
{
    class Prueba
    {
        public int idprueba;
        public int idmuestra;
        public int idtipoprueba;

        public Prueba() { }

        public Prueba(int idpru, int idmue, int idtipo)
        {
            this.idprueba = idpru;
            this.idmuestra = idmue;
            this.idtipoprueba = idtipo;
        }

        public Prueba(int idmue, int idtipo)
        {
            this.idmuestra = idmue;
            this.idtipoprueba = idtipo;
        }

        public static void ingresarprueba(MySqlConnection conexion, Prueba ip)
        {
            String query = "INSERT INTO prueba(IDMUESTRA, IDTIPOPRUEBA) VALUES ('" + ip.idmuestra + "', '" + ip.idtipoprueba + "')";
            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                Int32 lector = (Int32)comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            { throw ex; }

        }

        


    }
}