using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Proyecto_isss_seguro.Clases
{
    class PruebaGX
    {
        public int idgx;
        public int idprueba;
        public string fechaindicacion;
        public int idmotivoindicaciongx;
        public int idresultadogx;
        public string fecharesultado;

        public PruebaGX() { }
        public PruebaGX(int idgx, int idpru, string fechaind, int idmot, int idres, string fechares)
        {
            this.idgx = idgx;
            this.idprueba = idpru;
            this.fechaindicacion = fechaind;
            this.idmotivoindicaciongx = idmot;
            this.idresultadogx = idres;
            this.fecharesultado = fechares;
        }

        public PruebaGX(int idpru, string fechaind, int idmot, int idres, string fechares)
        {
            this.idprueba = idpru;
            this.fechaindicacion = fechaind;
            this.idmotivoindicaciongx = idmot;
            this.idresultadogx = idres;
            this.fecharesultado = fechares;
        }


        public static void insertarPruebaGX(MySqlConnection conexion, PruebaGX ipgx)
        {
            String query = "INSERT INTO gx( IDPRUEBA, FECHAINDICACION, IDMOTIVOINDICACIONGX, IDRESULTADOGX, FECHARESULTADO) VALUES ('" + ipgx.idprueba + "' , '" + ipgx.fechaindicacion + "', '" + ipgx.idmotivoindicaciongx +"' , '" + ipgx.idresultadogx +"', '" + ipgx.fecharesultado +"' )";
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
