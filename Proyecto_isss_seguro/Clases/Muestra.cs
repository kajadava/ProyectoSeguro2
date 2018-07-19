using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace Proyecto_isss_seguro.Clases
{
    class Muestra
    {
        public int idmuestra;
        public int idtipomuestra;
        public int idpaciente;
        public String fecha;
        public String observacionMuestra;
        public int idestablecimientorefe;
        public int idestablecimientoculti;

        public Muestra() { }
        public Muestra(int idmuestra, int idtipomuestra, int idpaciente, String fecha, String observacionMuestra, int idestablecimientorefe, int idestablecimientoculti)
        {
            this.idmuestra = idmuestra;
            this.idtipomuestra = idtipomuestra;
            this.idpaciente = idpaciente;
            this.fecha = fecha;
            this.observacionMuestra = observacionMuestra;
            this.idestablecimientorefe = idestablecimientorefe;
            this.idestablecimientoculti = idestablecimientoculti;
        }

        public Muestra( int idtipomuestra, int idpaciente, String fecha, String observacionMuestra, int idestablecimientorefe, int idestablecimientoculti)
        {
          
            this.idtipomuestra = idtipomuestra;
            this.idpaciente = idpaciente;
            this.fecha = fecha;
            this.observacionMuestra = observacionMuestra;
            this.idestablecimientorefe = idestablecimientorefe;
            this.idestablecimientoculti = idestablecimientoculti;
        }


        public static void listarMuestras(MySqlConnection conexion,String idPaciente,DataGridView dgv)
        {
            DataTable datat = new DataTable();

            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("select muestra.IDMUESTRA, tipomuestra.NOMBRETIPOMUESTRA as Tipo, muestra.IDPACIENTE, muestra.OBSERVACIONMUESTRA, Referencia.Refe, Cultivo.culti, muestra.FECHA from muestra join tipomuestra on muestra.IDTIPODEMUESTRA = tipomuestra.IDTIPOMUESTRA inner join referencia on muestra.IDMUESTRA = referencia.IDMUESTRA inner join cultivo on muestra.IDMUESTRA = cultivo.IDMUESTRA where muestra.IDPACIENTE ='" + idPaciente + "'"), conexion);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(comando);
                dataAdapter.Fill(datat);
                dgv.DataSource = datat;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

        }


        public static void insertarMuestra(MySqlConnection conexion,Muestra mu)
        {
            String query = "INSERT INTO muestra(IDTIPODEMUESTRA, IDPACIENTE, OBSERVACIONMUESTRA, IDESTABLECIMIENTOREFE, IDESTABLECIMEINTOCULTI, FECHA) VALUES ('"+mu.idtipomuestra+"','"+mu.idpaciente+"','"+mu.observacionMuestra+"','"+mu.idestablecimientorefe+"','"+mu.idestablecimientoculti+"','"+ mu.fecha +"')";
              try
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                Int32 lector = (Int32)comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            { throw ex; }

        }
        public static void actualizarMuestra(MySqlConnection conexion, Muestra mu)
        {
            String query = "update muestra set IDTIPODEMUESTRA = '" + mu.idtipomuestra + "', IDPACIENTE = '" + mu.idpaciente + "', OBSERVACIONMUESTRA = '"+mu.observacionMuestra+"', IDESTABLECIMIENTOREFE = '"+mu.idestablecimientorefe+"', IDESTABLECIMEINTOCULTI = '"+mu.idestablecimientoculti+"', FECHA = '"+mu.fecha+"' where idmuestra = '" +mu.idmuestra+"'";
            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                Int32 lector = (Int32)comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            { throw ex; }
        }
        public static Muestra cargarMuestra(MySqlConnection conexion, String id)
        {
            String query = "select * from muestra where idMuestra='" + id + "'";
            try
            {
                Muestra p = new Muestra();
                MySqlCommand comando = new MySqlCommand(query, conexion);
                MySqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    p.idmuestra = datos.GetInt32(0);
                    p.idtipomuestra = datos.GetInt32(1);
                    p.idpaciente = datos.GetInt32(2);
                    p.fecha = datos.GetString(3);
                    p.observacionMuestra = datos.GetString(4);
                    p.idestablecimientorefe = datos.GetInt32(5);
                    p.idestablecimientoculti = datos.GetInt32(6);
                }
                return p;


            }
            catch (MySqlException ex)
            { throw ex; }
        }
    }
}
