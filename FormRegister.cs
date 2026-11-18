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

namespace PRAKTIKUM1_DESKTOP_XII_242507012_RAHMADIKA
{
    public partial class FormRegister : Form
    {
        string connect = "server=localhost;port=3306;database=db_apotek_petugas;user=root;password=;";

         
        public FormRegister()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connect);
           if (txtPassword == txtKonfirmasiPassword)
            {
                MessageBox.Show("password dan konfirmasi berbeda");
            }
            try
            {
                conn.Open();

                string query = "INSERT INTO tb_apoteker (username, password, role, shift) VALUES (@username, @password, @role, @shift)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new MySqlParameter("@nama_petugas", txtNama.Text));
                cmd.Parameters.Add(new MySqlParameter("@username", txtUsername.Text));
                cmd.Parameters.Add(new MySqlParameter("@password", txtPassword.Text));
                cmd.Parameters.Add(new MySqlParameter("@role", cmbRole.SelectedItem.ToString()));
                cmd.Parameters.Add(new MySqlParameter("@shift", cmbShift.SelectedItem.ToString()));

                cmd.ExecuteNonQuery();
                MessageBox.Show("data berhasil di simpan");
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("gagal menyimpan" +  ex.Message);
            }

            }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connect);
            try
            {
                con.Open();
                string query = "SELECT @role FROM tb_petugas";
                MySqlCommand cmd = new MySqlCommand(query, con);
                return;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void cmbShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connect);
            try
            {
                con.Open();
                string query = "SELECT @shift FROM tb_petugas";
                MySqlCommand cmd = new MySqlCommand(query, con);
                return;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
    }
