using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Mobil_Esemka
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        //Login!
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    string sql = @"SELECT u.email, u.level, u.name, r.role_name FROM Users u JOIN role r ON u.role_id = r.id WHERE Email = @email AND Password = @password";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@password", txtPass.Text);

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        KoneksiDatabase.NamaEmail = dr["email"].ToString();
                        KoneksiDatabase.Level = dr["level"].ToString();

                        session.NamaUser = dr["name"].ToString();
                        session.NamaRole = dr["role_name"].ToString(); 


                        if (KoneksiDatabase.Level == "1")
                        {
                            MessageBox.Show("Login Berhasil Sebagai Admin!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            formDashboard dash1 = new formDashboard();
                            dash1.Show();
                            this.Hide();
                        }
                        else if (KoneksiDatabase.Level == "2")
                        {

                            MessageBox.Show("Login Berhasil Sebagai Petugas!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            formDashboard dash2 = new formDashboard();
                            dash2.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Level user tidak dikenali. Hubungi administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            conn.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login Gagal! Periksa kembali username dan password Anda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat mencoba login: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }
        }




        private void formLogin_Load(object sender, EventArgs e)
        {
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //checklist show password
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
            
                txtPass.PasswordChar = '\0';



            }
            else
            {
                txtPass.PasswordChar = '*';


            }
        }
    }
}
