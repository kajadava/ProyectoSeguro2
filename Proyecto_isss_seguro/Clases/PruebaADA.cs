using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Proyecto_isss_seguro.Clases
{
    class PruebaADA
    {
        public int idada;
        public int idprueba;
        public string fechaindicacion;
        public string fecharecepcion;
        public string resultadosada;
        public int idvalorreferencia;
        public string fecharesultado;

        public PruebaADA() { }
        public PruebaADA(int iada, int idpru, string fechaind, string fecharec, string resul, int idva, string fechares)
        {
            this.idada = iada;
            this.idprueba = idpru;
            this.fechaindicacion = fechaind;
            this.fecharecepcion = fecharec;
            this.resultadosada = resul;
            this.idvalorreferencia = idva;
            this.fecharesultado = fechares;
        }

        public PruebaADA(int idpru, string fechaind, string fecharec, string resul, int idva, string fechares)
        {
            this.idprueba = idpru;
            this.fechaindicacion = fechaind;
            this.fecharecepcion = fecharec;
            this.resultadosada = resul;
            this.idvalorreferencia = idva;
            this.fecharesultado = fechares;
        }

        public static void insertarPruebaADA(MySqlConnection conexion, PruebaADA ipada)
        {
            String query = "INSERT INTO ADA(IDPRUEBA, FECHAINDICACION, FECHARECEPCION, RESULTADOSADA, IDVALOREFERENCIAADA, FECHARESULTADO) VALUES ('" + ipada.idprueba + "','" + ipada.fechaindicacion + "','" + ipada.fecharecepcion + "','" + ipada.resultadosada + "','" + ipada.idvalorreferencia + "','" + ipada.fecharesultado + "',)";
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
