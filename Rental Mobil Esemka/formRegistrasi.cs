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
    public partial class formRegistrasi : Form
    {
        public formRegistrasi()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassRegis.PasswordChar = checkBox1.Checked ? '\0' : '•';
            txtcPassword.PasswordChar = checkBox1.Checked ? '\0' : '•';
        }


        // Validasi input dan proses btn registrasi
        private void btnRegis_Click(object sender, EventArgs e)
        {
            //validasi kolom input
            if (string.IsNullOrEmpty(txtUsernameRegis.Text) || string.IsNullOrEmpty(txtEmailRegis.Text) || string.IsNullOrEmpty(txtPassRegis.Text) || string.IsNullOrEmpty(txtcPassword.Text))
            {
                MessageBox.Show("Semua kolom harus diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //validasi format email
            else if (!txtEmailRegis.Text.Contains("@") || !txtEmailRegis.Text.EndsWith(".com"))
            {
                MessageBox.Show("Format email tidak valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //validasi password dan confirm password
            else if (txtPassRegis.Text != txtcPassword.Text)
            {
                MessageBox.Show("Password dan Confirm Password tidak cocok!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //validasi panjang password
            else if (txtPassRegis.Text.Length < 8)
            {
                MessageBox.Show("Password harus terdiri dari minimal 8 karakter!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Lanjutkan proses registrasi jika semua validasi terpenuhi
            else
            {
                using (SqlConnection conn = KoneksiDatabase.GetConn())
                {
                    try
                    {
                        conn.Open();
                        string cekEmail = @"SELECT * FROM Users WHERE email = @email";
                        SqlCommand cmd = new SqlCommand(cekEmail, conn);
                        cmd.Parameters.AddWithValue("@Email", txtEmailRegis.Text.Trim());

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);


                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show(txtEmailRegis.Text.Substring(0, 1).ToUpper() + txtEmailRegis.Text.Substring(1) + " sudah terdaftar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        else
                        {
                            string sql = @"INSERT INTO Users (name, email, password, role_id) VALUES (@Username, @Email, @Password, 2)";

                            using (SqlCommand cmd1 = new SqlCommand(sql, conn))
                            {
                                cmd1.Parameters.AddWithValue("@Username", txtUsernameRegis.Text.Trim());
                                cmd1.Parameters.AddWithValue("@Email", txtEmailRegis.Text.Trim());
                                cmd1.Parameters.AddWithValue("@Password", txtPassRegis.Text.Trim());
                                cmd1.Parameters.AddWithValue("@Role", 2); // Role 2 untuk petugas biasa

                                cmd1.ExecuteNonQuery();

                                MessageBox.Show("Registrasi berhasil! Silakan login dengan email dan password yang telah dibuat.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            }
                        }
                    
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formLogin formLogin = new formLogin();
            formLogin.Show();

            this.Hide();
        }
    }
}

