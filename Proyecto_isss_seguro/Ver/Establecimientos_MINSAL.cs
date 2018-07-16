﻿using System;
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
    public partial class Establecimientos_MINSAL : Form
    {
        Clases.Conexion con = new Clases.Conexion();
        public Establecimientos_MINSAL()
        {
            IdEstablecimiento = null;
            InitializeComponent();

        }

        public static String IdEstablecimiento = null;
        public static string IdEntidad;
        public static string IdRegion;
        public static string NombreEstablecimiento;
        public static string TipoEstablecimiento;
        public static string DireccionEstablecimiento;
        public static string TelefonoEstablecimiento;

        private void Establecimientos_MINSAL_Load(object sender, EventArgs e)
        {
            try
            {
                if (con.conectar() == true)
                {
                    listarminsal(con.conexion);

                }

            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            con.desconectar();
        }

        public void listarminsal(MySqlConnection conect)
        {

            Clases.Establecimiento.listarEstablecimientosMINSAL(conect, dataGridView1);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu_Establecimiento vnt0 = new Menu_Establecimiento();
            vnt0.Show();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            con.conectar();

            MySqlCommand cmd = con.conexion.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select establecimiento.IDESTABLECIMIENTO, entidad.TIPODEENTIDAD as ENTIDAD, region.NOMBREREGION as REGION, establecimiento.NOMBREESTABLECIMIENTO, establecimiento.TIPOESTABLECIMIENTO, establecimiento.DIRECCIONESTABLECIMIENTO, establecimiento.TELEFONOESTABLECIMIENTO from establecimiento inner join entidad on establecimiento.IDENTIDAD = entidad.IDENTIDAD inner join region on establecimiento.IDREGION = region.IDREGION where establecimiento.IDENTIDAD like('2') and (establecimiento.NOMBREESTABLECIMIENTO like('" + textBox1.Text + "%') or establecimiento.TIPOESTABLECIMIENTO like('" + textBox1.Text + "%'))";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);

            dataGridView1.DataSource = dt;

            con.desconectar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IdEstablecimiento != null)
            {
                this.Hide();
                Actualizar.Actualizar_Establecimiento vnt1 = new Actualizar.Actualizar_Establecimiento();
                vnt1.comboBox2.Text = IdEntidad;
                vnt1.comboBox1.Text = IdRegion;
                vnt1.textBox3.Text = NombreEstablecimiento;
                vnt1.comboBox3.Text = TipoEstablecimiento;
                vnt1.textBox4.Text = DireccionEstablecimiento;
                vnt1.textBox5.Text = TelefonoEstablecimiento;
                vnt1.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un paciente");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdEstablecimiento = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            IdEntidad = dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            IdRegion = dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
            NombreEstablecimiento = dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString();
            TipoEstablecimiento = dataGridView1.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
            DireccionEstablecimiento = dataGridView1.Rows[e.RowIndex].Cells["Column6"].Value.ToString();
            TelefonoEstablecimiento = dataGridView1.Rows[e.RowIndex].Cells["Column7"].Value.ToString();
        }

        public static String cambiarRegionString(String idRegion)
        {
            String nomregion = null;
            if (idRegion == "1")
            { nomregion = "Zona Central"; }

            else if (idRegion == "2")
            { nomregion = "Zona Paracentral"; }

            else if (idRegion == "3")
            { nomregion = "Zona Occidental"; }

            else if (idRegion == "4")
            { nomregion = "Zona Oriental"; }
            else if (idRegion == "5")
            { nomregion = "Zona Metropolitana"; }

            else if (idRegion == "6")
            { nomregion = "Zona M. Unidades"; }
            else if (idRegion == "7")
            { nomregion = "Zona M.Hospitales"; }
            else
            { nomregion = "Otros"; }
            return nomregion;
        }

        public static String cambiarEntidadString(String idEntidad)
        {
            String non = null;

            if (idEntidad == "1")
            { non = "ISSS"; }
            else
            { non = "MINSAL"; }
            return non;
        }
    }
}
