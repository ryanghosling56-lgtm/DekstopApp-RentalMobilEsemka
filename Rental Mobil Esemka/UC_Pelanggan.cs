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
    public partial class UC_Pelanggan : UserControl
    {
        private int SelectedPelangganId = 0; // Menyimpan ID pelanggan yang dipilih
        public UC_Pelanggan()
        {
            InitializeComponent();
            TampilPelanggan();
            ClearFields();
        }


        private void ClearFields()
        {
            txtSearch.Clear();
            txtNoIdentitas.Clear();
            txtAlamat.Clear();
            txtNoHP.Clear();
            cmbIdentitas.SelectedIndex = -1;
            cmbPelanggan.SelectedIndex = -1;
            cmbKelamin.SelectedIndex = -1;
        }


        //Menampilkan data pelanggan di DataGridView
        private void TampilPelanggan()
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {


                    string sql = @"SELECT c.customer_id, u.email, c.identity_number, i.name, c.alamat, j.nama_jk, c.no_hp FROM customers c JOIN users u ON c.user_id = u.user_id JOIN identity_type i ON c.identity_type_id = i.identity_type_id JOIN jenis_kelamin j ON c.id_jk = j.id_jk";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView2.DataSource = dt;

                    if (dataGridView2.Columns.Contains("customer_id")) dataGridView2.Columns["customer_id"].Visible = false;
                    if (dataGridView2.Columns.Contains("user_id")) dataGridView2.Columns["user_id"].Visible = false;


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saat mencari pelanggan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void LoadCmbBox()
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sqlPelanggan = @"SELECT user_id, email FROM users";
                    SqlDataAdapter daPelanggan = new SqlDataAdapter(sqlPelanggan, conn);
                    DataTable dtPelanggan = new DataTable();
                    daPelanggan.Fill(dtPelanggan);

                  
                    cmbPelanggan.DisplayMember = "email";
                    cmbPelanggan.ValueMember = "user_id";
                    cmbPelanggan.DataSource = dtPelanggan;


                    string sqlIdentitas = @"SELECT identity_type_id, name FROM identity_type";
                    SqlDataAdapter daIdentitas = new SqlDataAdapter(sqlIdentitas, conn);
                    DataTable dtIdentitas = new DataTable();
                    daIdentitas.Fill(dtIdentitas);

                   
                    cmbIdentitas.DisplayMember = "name";
                    cmbIdentitas.ValueMember = "identity_type_id";
                    cmbIdentitas.DataSource = dtIdentitas;


                    string sqlKelamin = @"SELECT id_jk, nama_jk FROM jenis_kelamin";
                    SqlDataAdapter dakelamin = new SqlDataAdapter(sqlKelamin, conn);
                    DataTable dtKelamin = new DataTable();
                    dakelamin.Fill(dtKelamin);

                    
                    cmbKelamin.DisplayMember = "nama_jk";
                    cmbKelamin.ValueMember = "id_jk";
                    cmbKelamin.DataSource = dtKelamin;



                    cmbPelanggan.SelectedIndex = -1;
                    cmbIdentitas.SelectedIndex = -1;
                    cmbKelamin.SelectedIndex = -1;





                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message);
                }
            }
        }
    












        private void UC_Pelanggan_Load(object sender, EventArgs e)
        {
            TampilPelanggan();
            LoadCmbBox();


            // Atur akses berdasarkan role
            if (session.NamaRole == "admin")
            {
                btnCreate.Enabled = false;

                btnEdit.Enabled = true;
                btnDelete.Enabled = true;

            }
            else if (session.NamaRole == "petugas")
            {
                btnCreate.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }


        //Fitur search
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using(SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    string sql = @"SELECT c.customer_id, u.email, c.identity_number, i.name, c.alamat, j.nama_jk, c.no_hp FROM customers c JOIN users u ON c.user_id = u.user_id JOIN identity_type i ON c.identity_type_id = i.identity_type_id JOIN jenis_kelamin j ON c.id_jk = j.id_jk WHERE u.email LIKE @search OR c.identity_number LIKE @search i.name LIKE @search OR c.alamat lIKE @search OR j.nama_jk LIKE @search OR c.no_hp LIKE @search ";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@search", $"%{txtSearch.Text}%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saat mencari pelanggan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //Create, 
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbPelanggan.Text) || string.IsNullOrEmpty(txtNoIdentitas.Text) || string.IsNullOrEmpty(cmbIdentitas.Text) || string.IsNullOrEmpty(txtAlamat.Text) || string.IsNullOrEmpty(txtNoHP.Text))
            {
                MessageBox.Show("Semua field harus diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = @"INSERT INTO customers ( user_id, identity_number, identity_type_id, alamat, id_jk, no_hp) VALUES ( @nama_pelanggan, @nomor_identitas, @tipe_identitas, @alamat, @jenis_kelamin, @no_hp)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@nama_pelanggan", cmbPelanggan.SelectedValue);
                    cmd.Parameters.AddWithValue("@nomor_identitas", txtNoIdentitas.Text.Trim());
                    cmd.Parameters.AddWithValue("@tipe_identitas", cmbIdentitas.SelectedValue);
                    cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                    cmd.Parameters.AddWithValue("@jenis_kelamin", cmbKelamin.SelectedValue);
                    cmd.Parameters.AddWithValue("@no_hp", txtNoHP.Text.Trim());



                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pelanggan berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TampilPelanggan();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saat menambahkan pelanggan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //edit
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbPelanggan.Text) || string.IsNullOrEmpty(txtNoIdentitas.Text) || string.IsNullOrEmpty(cmbIdentitas.Text) || string.IsNullOrEmpty(txtAlamat.Text) || string.IsNullOrEmpty(cmbKelamin.Text) || string.IsNullOrEmpty(txtNoHP.Text))
            {
                MessageBox.Show("Semua field harus diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = @"UPDATE customers SET user_id = @nama_pelanggan, identity_number = @nomor_identitas, identity_type_id = @tipe_identitas, alamat = @alamat, id_jk = @jenis_kelamin, no_hp = @no_hp WHERE customer_id = @customer_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@customer_id", SelectedPelangganId);
                    cmd.Parameters.AddWithValue("@nama_pelanggan", cmbPelanggan.SelectedValue);
                    cmd.Parameters.AddWithValue("@nomor_identitas", txtNoIdentitas.Text);
                    cmd.Parameters.AddWithValue("@tipe_identitas", cmbIdentitas.SelectedValue);
                    cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                    cmd.Parameters.AddWithValue("@jenis_kelamin", cmbKelamin.SelectedValue);
                    cmd.Parameters.AddWithValue("@no_hp", Convert.ToInt32(txtNoHP.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pelanggan berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TampilPelanggan();
                    ClearFields();


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saat memperbarui pelanggan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbPelanggan.Text) || string.IsNullOrEmpty(txtNoIdentitas.Text) || string.IsNullOrEmpty(cmbIdentitas.Text) || string.IsNullOrEmpty(txtAlamat.Text) || string.IsNullOrEmpty(cmbKelamin.Text) || string.IsNullOrEmpty(txtNoHP.Text))
            {
                MessageBox.Show("Semua field harus diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = @"DELETE FROM customers WHERE customer_id = @customer_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@customer_id", SelectedPelangganId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pelanggan berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TampilPelanggan();
                    ClearFields();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saat menghapus pelanggan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //Agar data yang dipilih di DataGridView muncul di field untuk diedit atau dihapus
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView2.Rows[e.RowIndex].Cells[0].Value != null)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                SelectedPelangganId = int.Parse(row.Cells[0].Value.ToString());
                txtNoIdentitas.Text = row.Cells[1].Value.ToString();
                cmbIdentitas.Text = row.Cells[2].Value.ToString();
                txtAlamat.Text = row.Cells[3].Value.ToString();
                txtNoHP.Text = row.Cells[4].Value.ToString();
                cmbPelanggan.Text = row.Cells[5].Value.ToString();
                cmbKelamin.Text = row.Cells[6].Value.ToString();



            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}




