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
            LoadCmbKursi();
            ClearField();

        }


        private void ClearField()
        {
            txtBrand.Clear();
            txtPlat.Clear();
            txtColor.Clear();
            
            txtHargaRental.Clear();
            cmbStatus.SelectedIndex = -1;
            cmbKursi.SelectedIndex = -1;

            dtpMobil.Value = DateTime.Now;

        }

        //KOneksi Database!
        private void LoadData()
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    string sql = "SELECT m.mobil_id, m.brand, m.plate, m.color, m.year, m.status, m.harga_rental, k.jumlah_kursi, m.image_path FROM Mobil m JOIN kursimobil k ON m.kursi_mobil_id = k.id";
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
                    string sql = "SELECT m.mobil_id, m.brand, m.plate, m.color, m.year, m.status, m.harga_rental, k.jumlah_kursi, m.image_path FROM Mobil m JOIN kursimobil k ON m.kursi_mobil_id = k.id";
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

        //DataGridView Cell Click!!
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {



            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                SelectedCarId = int.Parse(row.Cells[0].Value.ToString());
                txtBrand.Text = row.Cells[1].Value.ToString();
                txtPlat.Text = row.Cells[2].Value.ToString();
                txtColor.Text = row.Cells[3].Value.ToString();
                cmbStatus.Text = row.Cells[4].Value.ToString();
                txtHargaRental.Text = row.Cells[5].Value.ToString();
                cmbKursi.Text = row.Cells[6].Value.ToString();

                pictureBoxUploud.Image = row.Cells[8].Value != null && File.Exists(row.Cells[8].Value.ToString()) ? Image.FromFile(row.Cells[8].Value.ToString()) : null;
                pictureBoxUploud.SizeMode = PictureBoxSizeMode.StretchImage;
            }


            
        }


        //Load cmb kursi mobil!!
        private void LoadCmbKursi()
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    string sql = "SELECT id, jumlah_kursi FROM kursimobil";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbKursi.ValueMember = "id";
                    cmbKursi.DisplayMember = "jumlah_kursi";
                    cmbKursi.DataSource = dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }





        //button uploud gambar!!
        string pathuntukDB = string.Empty; // Variabel untuk menyimpan path gambar yang akan disimpan ke database
        private void btnUploud_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openfile = new OpenFileDialog())
            {

                {
                    openfile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                    if (openfile.ShowDialog() == DialogResult.OK)
                    {
                        string foldertujuan = Path.Combine(Application.StartupPath, "Resources");

                        if (!Directory.Exists(foldertujuan))
                        {
                            Directory.CreateDirectory(foldertujuan);
                        }

                        string namafile = Path.GetFileName(openfile.FileName);

                        string fullpath = Path.Combine(foldertujuan, namafile);

                        pathuntukDB = Path.Combine("Resources", namafile);

                        File.Copy(openfile.FileName, fullpath, true);

                        pictureBoxUploud.Image = Image.FromStream(openfile.OpenFile());
                        pictureBoxUploud.Tag = openfile.FileName; // Simpan path gambar di Tag untuk digunakan nanti

                        pictureBoxUploud.SizeMode = PictureBoxSizeMode.StretchImage;

                    }
                }
            }



        }

        //Create!!

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBrand.Text) || string.IsNullOrEmpty(txtPlat.Text) || string.IsNullOrEmpty(txtColor.Text) || string.IsNullOrEmpty(dtpMobil.Text) || string.IsNullOrEmpty(cmbStatus.Text) || string.IsNullOrEmpty(txtHargaRental.Text))


            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO Mobil (brand, plate, color, year, status, harga_rental, kursi_mobil_id, image_path) VALUES (@brd, @plate, @color, @year, @status, @harga_rental, @kursi, @image_path)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@brd", txtBrand.Text);
                    cmd.Parameters.AddWithValue("@plate", txtPlat.Text);
                    cmd.Parameters.AddWithValue("@color", txtColor.Text);
                    cmd.Parameters.AddWithValue("@year", dtpMobil.Value.Date);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                    cmd.Parameters.AddWithValue("@harga_rental", txtHargaRental.Text);
                    cmd.Parameters.AddWithValue("@kursi", Convert.ToInt32(cmbKursi.SelectedValue));
                  
                    cmd.Parameters.AddWithValue("@image_path", pathuntukDB);

                    //Validasi apakah gambar sudah diunggah atau belum




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



        private void button2_Click(object sender, EventArgs e)
        {
           
        }



        

        //Edit Mobil!!

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE Mobil SET brand = @brd, plate = @plate, color = @color, year = @year, status = @status, harga_rental = @harga_rental, jumlah_kursi = @kursi, image_path = @image_path WHERE mobil_id = @mobil_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@mobil_id", SelectedCarId);
                    cmd.Parameters.AddWithValue("@brd", txtBrand.Text);
                    cmd.Parameters.AddWithValue("@plate", txtPlat.Text);
                    cmd.Parameters.AddWithValue("@color", txtColor.Text);
                    cmd.Parameters.AddWithValue("@year", dtpMobil.Text);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                    cmd.Parameters.AddWithValue("@harga_rental", txtHargaRental.Text);
                    cmd.Parameters.AddWithValue("@kursi", Convert.ToInt32(cmbKursi.SelectedValue));

                    if (!string.IsNullOrEmpty(pathuntukDB))
                    {
                        cmd.Parameters.AddWithValue("@image_path", pathuntukDB);
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


        private void button3_Click(object sender, EventArgs e)
        {
           
        }


        //Delete Mobil!!
        private void btnDelete_Click(object sender, EventArgs e)
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

                    pictureBoxUploud.Image = null;
                    pictureBoxUploud.Tag = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
           
        }


        //Search Mobil!!
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    string sql = @"SELECT m.mobil_id, m.brand, m.plate, m.color, m.year, m.status, m.harga_rental, k.jumlah_kursi, m.image_path FROM Mobil m JOIN kursimobil k ON m.kursi_mobil_id = k.id WHERE brand LIKE @search OR plate LIKE @search OR color LIKE @search OR status LIKE @search OR harga_rental LIKE @search OR jumlah_kursi LIKE @search";
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


        //dtp select tahun mobil!! 
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int TahunPilihan =  dtpMobil.Value.Year;

            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    string sql = "SELECT m.mobil_id, m.brand, m.plate, m.color, m.year, m.status, m.harga_rental, k.kursi_mobil_id, m.image_path FROM Mobil m JOIN kursimobil k ON m.kursi_mobil_id = k.kursitambahan_id WHERE YEAR(year) = @tahun";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@tahun", TahunPilihan);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
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

        private void UC_Mobil_Load(object sender, EventArgs e)
        {

            TampilMobil();

           
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


