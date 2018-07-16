using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace Proyecto_isss_seguro.Clases
{
    class Paciente
    {  //atributos de la clase
      public int idPaciente { get; set; }
      public String noafiliacion { get; set; }
      public String nombre { get; set; }
      public  String apellido { get; set; }
      public String direccion { get; set; }
      public String grupoSanguineo { get; set; }
      public String factorRH { get; set; }
      public String genero { get; set; }
      public String vih { get; set; }
      public int edad { get; set; }
      public String telefono { get; set; }




        //constructor vacío para iniciar un nuevo usuario sin asignarle valores a sus atributos
        public Paciente() {
        }

        //constructor con parámetros para iniciar un nuevo usuario asignandole valores a sus atributos
        public Paciente(int id, String noaf, String nomb, String apell, String dir, String gpoSanguineo, String factor, String genero, String vih, int edad, String tel)

        {

            this.idPaciente = id;
            this.noafiliacion = noaf;
            this.nombre = nomb;
            this.apellido = apell;
            this.direccion = dir;
            this.grupoSanguineo = gpoSanguineo;
            this.factorRH = factor;
            this.genero = genero;
            this.vih = vih;
            this.edad = edad;
            this.telefono = tel;

        }
        //constructor sin id
        public Paciente(String noaf, String nomb, String apell, String dir, String gpoSanguineo, String factor, String genero, String vih, int edad, String tel)

        {

            this.noafiliacion = noaf;
            this.nombre = nomb;
            this.apellido = apell;
            this.direccion = dir;
            this.grupoSanguineo = gpoSanguineo;
            this.factorRH = factor;
            this.genero = genero;
            this.vih = vih;
            this.edad = edad;
            this.telefono = tel;

        }



        public static void listarPacientes(MySqlConnection conexion, DataGridView dgv)
        {
            DataTable datat = new DataTable();

            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(("select * from paciente")), conexion);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(comando);
                dataAdapter.Fill(datat);
                dgv.DataSource = datat;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

        }



        public static void insertarPaciente(MySqlConnection conexion, Paciente paciente)
        {
            String query = "INSERT INTO paciente(NOAFILIACION, NOMBRE, APELLIDO, DIRECCION, GRUPOSANGUINEO, FACTORRH, GENERO, VIH, EDAD, TELEFONOPACIENTE) VALUES('" + paciente.noafiliacion + "','" + paciente.nombre + "','" + paciente.apellido + "','" + paciente.direccion + "','" + paciente.grupoSanguineo + "','" + paciente.factorRH + "','" + paciente.genero + "','" + paciente.vih + "','" + paciente.edad + "', '" + paciente.telefono + "')";
            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                Int32 lector = (Int32)comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            { throw ex; }



        }

        public static void actualizarPaciente(MySqlConnection conexion, Paciente paciente)
        {
            String query = "UPDATE paciente set NOAFILIACION = '" + paciente.noafiliacion + "', NOMBRE = '" + paciente.nombre + "', APELLIDO = '" + paciente.apellido + "', DIRECCION = '" + paciente.direccion + "', GRUPOSANGUINEO = '" + paciente.grupoSanguineo + "', FACTORRH = '" + paciente.factorRH + "', GENERO = '" + paciente.genero + "', VIH = '" + paciente.vih + "', EDAD = '" + paciente.edad + "', TELEFONOPACIENTE = '" + paciente.telefono + "' where idpaciente = '" + paciente.idPaciente + "'";
            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                Int32 lector = (Int32)comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            { throw ex; }
        }


        public static Paciente cargarPaciente(MySqlConnection conexion, String id)
        {
            String query = "select * from paciente where idPaciente='" + id + "'";
            try
            {
                Paciente p = new Paciente();
                MySqlCommand comando = new MySqlCommand(query, conexion);
                MySqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    p.idPaciente = datos.GetInt32(0);
                    p.noafiliacion = datos.GetString(1);
                    p.nombre = datos.GetString(2);
                    p.apellido = datos.GetString(3);
                    p.direccion = datos.GetString(4);
                    p.grupoSanguineo = datos.GetString(5);
                    p.factorRH = datos.GetString(6);
                    p.genero = datos.GetString(7);
                    p.vih = datos.GetString(8);
                    p.edad = datos.GetInt32(9);
                    p.telefono = datos.GetString(10);
                }
                return p;


            }
            catch (MySqlException ex)
            { throw ex; }





        }
    }

}
