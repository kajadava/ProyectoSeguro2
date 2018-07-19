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
    public partial class CC_BK_General : Form
    {
        Clases.Conexion con = new Clases.Conexion();
        public CC_BK_General()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            cbesta.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttoncancelar_Click(object sender, EventArgs e)
        {
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (con.conectar() == true)
                {
                    
                    cbesta.Items.Insert(0, "Seleccionar");
                    cbesta.SelectedIndex = 0;
                    cbesta.DataSource = Clases.Establecimiento.cargartodos(con.conexion);
                    cbesta.DisplayMember = "nombreEstablecimiento";
                    cbesta.ValueMember = "idEstablecimiento";
                    
                }

            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            con.desconectar();

        }

        
        private void buttonguardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (con.conectar())
                {
                    Clases.CCBKGeneral cc1 = new Clases.CCBKGeneral(Convert.ToInt32(cbesta.SelectedValue), comboBox1.Text, comboBox2.Text, Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox9.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text));
                    Clases.CCBKGeneral.insertarCCBKgeneral(con.conexion, cc1);
                    MessageBox.Show("Consolidado Ingresado Exitosamente");
                }

            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Error al insertar el consolidado" + ex);
            }
            con.desconectar();
        }

        private void CC_BK_General_Load(object sender, EventArgs e)
        {

        }

        private void buttonguardar_Click_1(object sender, EventArgs e)
        {

        }

        private void buttoncancelar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Menu_Consolidados vnt0 = new Menu_Consolidados();
            vnt0.Show();
        }
    }
}
