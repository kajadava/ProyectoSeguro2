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

namespace Proyecto_isss_seguro
{
    public partial class Ver_Paciente : Form
    {
       
        
        Clases.Conexion con = new Clases.Conexion();
        public Ver_Paciente()
        {
            IdPaciente = null;
            InitializeComponent();

        }

        public static String IdPaciente = null;
        public static string Afiliacion;
        public static string Nombres;
        public static string Apellidos;
        public static string Direccion1;
        public static string GrupoSanguineo1;
        public static string FactorRH1;
        public static string Genero1;
        public static string VIH1;
        public static string Edad1;
        public static string Telefono;

        private void Ver_Paciente_Load(object sender, EventArgs e)
        {
            try
            {
                if (con.conectar() == true) {
                    listarpacientes(con.conexion);
                    
                }
                
            }
            catch (MySqlException ex) {
                throw ex;
            }

            con.desconectar();
        }

        public void listarpacientes(MySqlConnection conect)
        {
            
            Clases.Paciente.listarPacientes(conect,dataGridView1);
                      
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu_Paciente vnt0 = new Menu_Paciente();
            vnt0.Show();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            con.conectar();

            MySqlCommand cmd = con.conexion.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from paciente where NOAFILIACION like('" + textBox1.Text + "%') or NOMBRE like('" + textBox1.Text + "%') or APELLIDO like('" + textBox1.Text + "%')";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);

            dataGridView1.DataSource = dt;

            con.desconectar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IdPaciente != null)
            {
                this.Hide();
                Actualizar.Actualizar_Paciente vnt2 = new Actualizar.Actualizar_Paciente();
                vnt2.label11.Text = IdPaciente;
                vnt2.textBoxafiliacion.Text = Afiliacion;
                vnt2.textBoxnombres.Text = Nombres;
                vnt2.textBoxapellidos.Text = Apellidos;
                vnt2.textBoxdireccion.Text = Direccion1;
                vnt2.comboBoxgruposanguineo.Text = GrupoSanguineo1;
                vnt2.comboBoxfactorrh.Text = FactorRH1;
                vnt2.comboBoxgenero.Text = Genero1;
                vnt2.textBoxvih.Text = VIH1;
                vnt2.textBoxedad.Text = Edad1;
                vnt2.textBoxtelefono.Text = Telefono;
                vnt2.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un paciente");
            }
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdPaciente = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            Afiliacion = dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            Nombres = dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
            Apellidos = dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString();
            Direccion1 = dataGridView1.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
            GrupoSanguineo1 = dataGridView1.Rows[e.RowIndex].Cells["Column6"].Value.ToString();
            FactorRH1 = dataGridView1.Rows[e.RowIndex].Cells["Column7"].Value.ToString();
            Genero1 = dataGridView1.Rows[e.RowIndex].Cells["Column8"].Value.ToString();
            VIH1 = dataGridView1.Rows[e.RowIndex].Cells["Column9"].Value.ToString();
            Edad1 = dataGridView1.Rows[e.RowIndex].Cells["Column10"].Value.ToString();
            Telefono = dataGridView1.Rows[e.RowIndex].Cells["Column11"].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IdPaciente != null)
            {
                this.Hide();
                Ver.Expediente vnt2 = new Ver.Expediente(IdPaciente);
                vnt2.Show();
            } else {
                MessageBox.Show("Debe seleccionar un paciente");
            }
    }
    }
}
