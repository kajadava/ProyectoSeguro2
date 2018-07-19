using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Proyecto_isss_seguro.Ver
{
    public partial class Expediente : Form
    {   Clases.Conexion con = new Clases.Conexion();
        

        public Expediente(String id)
        {
            IdMuestra = null;
            InitializeComponent();
            cargar(id);
        }

        public static String IdMuestra = null;
        public static string IdTipoDeMuestra;
        public static string IdPaciente;
        public static string Fecha;
        public static string ObservacionMuestra;
        public static string IdEstablecimientoRefe;
        public static string IdEstablecimientoCulti;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ver_Paciente vnt1 = new Ver_Paciente();
            vnt1.Show();
        }

        private void Expediente_Load(object sender, EventArgs e)
        {
            try
            {
                if (con.conectar() == true)
                {
                    listarmuestras(con.conexion);
                    
                }

            }
            catch (MySqlException ex)
            {
                throw ex;
            }


            con.desconectar();
        }

        public void listarmuestras(MySqlConnection conect)
        {

            Clases.Muestra.listarMuestras(conect,label3.Text, dataGridView1);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ingresar_Muestra vnt2 = new Ingresar_Muestra();
            vnt2.label7.Text = label3.Text; 
            vnt2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IdMuestra != null)
            {
                this.Hide();
                Actualizar.Actualizar_Muestra vnt2 = new Actualizar.Actualizar_Muestra();
                vnt2.label7.Text = IdPaciente;
                vnt2.dateTimePicker2.Text = cambiarfecha(Fecha);
                vnt2.comboBox1.Text = IdEstablecimientoRefe;
                vnt2.comboBox2.Text = IdEstablecimientoCulti;
                vnt2.cbTipoMuestra.Text = IdTipoDeMuestra;
                vnt2.textBoxObservacion.Text = ObservacionMuestra;
                vnt2.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una muestra");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdMuestra = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            IdTipoDeMuestra = dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            IdPaciente = dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
            Fecha = dataGridView1.Rows[e.RowIndex].Cells["Column7"].Value.ToString();
            ObservacionMuestra = dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString();
            IdEstablecimientoRefe = dataGridView1.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
            IdEstablecimientoCulti = dataGridView1.Rows[e.RowIndex].Cells["Column6"].Value.ToString();
        }
        public static String cambiarfecha(String Fecha)
        {
            String sdate = "01/12/2018 13:00:00";
            DateTime dt = Convert.ToDateTime(sdate);
            IFormatProvider cul = new System.Globalization.CultureInfo("en-us", true);
            DateTime dt1 = DateTime.Parse(sdate, cul, System.Globalization.DateTimeStyles.AssumeLocal);
            return sdate;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (IdMuestra != null)
            {
                this.Hide();
                expedientemuestra vnt2 = new expedientemuestra(IdMuestra);
                vnt2.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un paciente");
            }
        }

        public void cargar(String id)
        {
            Clases.Paciente pac = new Clases.Paciente();
            try
            {
                if (con.conectar())
                {
                    pac = Clases.Paciente.cargarPaciente(con.conexion, id);
                    label3.Text = Convert.ToString(pac.idPaciente);
                    label11.Text = pac.nombre;
                    label12.Text = pac.apellido;
                    label13.Text = pac.grupoSanguineo;
                    label14.Text = pac.factorRH;
                    label15.Text = pac.vih;
                    label16.Text = pac.genero;
                    label17.Text = pac.direccion;
                    label18.Text = Convert.ToString(pac.edad);
                    label19.Text = pac.telefono;
                    label20.Text = pac.noafiliacion;
                }
            }catch (MySqlException ex)

            {

            }
            con.desconectar();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            con.conectar();

            MySqlCommand cmd = con.conexion.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select muestra.IDMUESTRA, tipomuestra.NOMBRETIPOMUESTRA as Tipo, muestra.IDPACIENTE, muestra.OBSERVACIONMUESTRA, Referencia.Refe, Cultivo.culti, muestra.FECHA from muestra join tipomuestra on muestra.IDTIPODEMUESTRA = tipomuestra.IDTIPOMUESTRA inner join referencia on muestra.IDMUESTRA = referencia.IDMUESTRA inner join cultivo on muestra.IDMUESTRA = cultivo.IDMUESTRA where muestra.FECHA like('" + textBox1.Text + "%') or tipomuestra.NOMBRETIPOMUESTRA like('" + textBox1.Text + "%') or Referencia.Refe like('" + textBox1.Text + "%') or Cultivo.culti like('" + textBox1.Text + "%')";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);

            dataGridView1.DataSource = dt;

            con.desconectar();
        }
    }
}
