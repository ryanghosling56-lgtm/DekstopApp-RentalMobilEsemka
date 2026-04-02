using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Rental_Mobil_Esemka
{

    public partial class UC_Mobil : UserControl
    {
        private int SelectedCarId = 0; // Variabel untuk menyimpan ID mobil yang dipilih
        public UC_Mobil()
        {
            InitializeComponent();
            TampilMobil();
            LoadData();

        }


        private void ClearField()
        {
            txtBrand.Clear();
            txtPlat.Clear();
            txtColor.Clear();
            txtStatusUnit.Clear();
            txtJmlahKursi.Clear();
            txtHargaRental.Clear();

        }

        //KOneksi Database!
        private void LoadData()
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    string sql = "SELECT m.mobil_id, m.brand, m.plate, m.color, m.year, m.status, m.harga_rental, k.kursi_mobil_id, m.image_path FROM Mobil m JOIN kursitambahan k ON m.kursi_mobil_id = k.kursitambahan_id";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void TampilMobil()
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    string sql = "SELECT m.mobil_id, m.brand, m.plate, m.color, m.year, m.status, m.harga_rental, k.kursi_mobil_id, m.image_path FROM Mobil m JOIN kursimobil k ON m.kursi_mobil_id = k.kursitambahan_id";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }







        private void btnUploud_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {

                {
                    ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string imagePath = ofd.FileName;
                        pictureBox1.Image = Image.FromFile(imagePath);
                        pictureBox1.Tag = ofd.FileName; // Simpan path gambar di Tag untuk digunakan nanti

                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    }
                }
            }



        }

        //Create!!
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBrand.Text) || string.IsNullOrEmpty(txtPlat.Text) || string.IsNullOrEmpty(txtColor.Text) || string.IsNullOrEmpty(dtpMobil.Text) || string.IsNullOrEmpty(txtStatusUnit.Text) || string.IsNullOrEmpty(txtHargaRental.Text))


            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO Users (brand, plate, color, year, status, harga_rental, kursi_mobil_id, image_path) VALUES (@brd, @plate, @color, @year, @status, @harga_rental, @kmi, @image_path)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@brd", txtBrand.Text);
                    cmd.Parameters.AddWithValue("@plate", txtPlat.Text);
                    cmd.Parameters.AddWithValue("@color", txtColor.Text);
                    cmd.Parameters.AddWithValue("@year", dtpMobil.Text);
                    cmd.Parameters.AddWithValue("@status", txtStatusUnit.Text);
                    cmd.Parameters.AddWithValue("@harga_rental", txtHargaRental.Text);
                    cmd.Parameters.AddWithValue("@kmi", txtJmlahKursi.Text);


                    //Validasi apakah gambar sudah diunggah atau belum

                    if (pictureBoxUploud.Tag != null)
                    {
                        cmd.Parameters.AddWithValue("@image_path", pictureBoxUploud.Tag.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@image_path", DBNull.Value);
                    }



                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TampilMobil();
                    ClearField();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //Dgv Cell Click!! dan klik Path Gambar!!

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {



            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                SelectedCarId = int.Parse(row.Cells[0].Value.ToString());
                txtBrand.Text = row.Cells[1].Value.ToString();
                txtPlat.Text = row.Cells[2].Value.ToString();
                txtColor.Text = row.Cells[3].Value.ToString();
                txtStatusUnit.Text = row.Cells[4].Value.ToString();
                txtHargaRental.Text = row.Cells[5].Value.ToString();
                txtJmlahKursi.Text = row.Cells[6].Value.ToString();
            }


            string path = dataGridView1.Rows[e.RowIndex].Cells["image_path"].Value.ToString();

            if (!(string.IsNullOrEmpty(path) && File.Exists(path)))
            {
                pictureBox1.Image = Image.FromFile(path);
                pictureBox1.Tag = path; // Simpan path gambar di Tag untuk digunakan nanti
            }
            else
            {
                pictureBox1.Image = null; // Atau tampilkan gambar default jika path tidak valid
                pictureBox1.Tag = null; // Pastikan Tag juga direset
            }
        }

        //Edit Mobil!!
        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE Mobil SET brand = @brd, plate = @plate, color = @color, year = @year, status = @status, harga_rental = @harga_rental, kursi_mobil_id = @kmi, image_path = @image_path WHERE mobil_id = @mobil_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@mobil_id", SelectedCarId);
                    cmd.Parameters.AddWithValue("@brd", txtBrand.Text);
                    cmd.Parameters.AddWithValue("@plate", txtPlat.Text);
                    cmd.Parameters.AddWithValue("@color", txtColor.Text);
                    cmd.Parameters.AddWithValue("@year", dtpMobil.Text);
                    cmd.Parameters.AddWithValue("@status", txtStatusUnit.Text);
                    cmd.Parameters.AddWithValue("@harga_rental", txtHargaRental.Text);
                    cmd.Parameters.AddWithValue("@kmi", txtJmlahKursi.Text);

                    if (pictureBoxUploud.Tag != null)
                    {
                        cmd.Parameters.AddWithValue("@image_path", pictureBoxUploud.Tag.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@image_path", DBNull.Value);
                    }



                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    TampilMobil();
                    ClearField();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM Mobil WHERE mobil_id = @mobil_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@mobil_id", SelectedCarId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TampilMobil();
                    ClearField();

                    pictureBox1.Image = null;
                    pictureBox1.Tag = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    string sql = "SELECT m.mobil_id, m.brand, m.plate, m.color, m.year, m.status, m.harga_rental, k.kursi_mobil_id, m.image_path FROM Mobil m JOIN kursimobil k ON m.kursi_mobil_id = k.kursitambahan_id WHERE brand LIKE @search OR plate LIKE @search OR color LIKE @search OR status LIKE @search OR harga_rental LIKE @search OR kursi_mobil LIKE @search";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    string sql = "SELECT m.mobil_id, m.brand, m.plate, m.color, m.year, m.status, m.harga_rental, k.kursi_mobil_id, m.image_path FROM Mobil m JOIN kursimobil k ON m.kursi_mobil_id = k.kursitambahan_id WHERE CAST(m.year AS DATE) = @year";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@year", dtpMobil.Value.Year);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


