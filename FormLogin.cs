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
    public partial class FormLogin : Form
    {
        string connect = "server=localhost;port=3306;database=db_apotek_petugas;user=root;password=;";
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username kosong");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password kosong");
                return;
            }
            using (MySqlConnection koneksi = new MySqlConnection(connect))
            {
                try
                {
                    koneksi.Open();

                    string query = "SELECT nama_petugas FROM tb_apoteker WHERE username = @username  AND password = @password ";
                    using (MySqlCommand cmd = new MySqlCommand(query, koneksi))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                string nama = reader.GetString("nama_petugas");

                                this.Hide();
                                FormDashboard dashboard = new FormDashboard();
                                dashboard.Show();
                            }
                            else
                            {
                                MessageBox.Show("Username tidak di temukan atau kata sandi salah");
                                txtPassword.Clear();
                                txtPassword.Focus();
                            }
                        }
                    }

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("gagal masuk ke database\n\n" + ex.Message);
                }
                
            }

        }
    }
}
