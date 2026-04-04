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
    public partial class UC_Transaksi : UserControl
    {
        private int SelectedTransaksiId = 0; // Menyimpan ID transaksi yang dipilih
        public UC_Transaksi()
        {
            InitializeComponent();
            TampilTransaksi();
            ClearFields();
            LoadCmbBox();


        }

        private void ClearFields()
        {
            txtTotal.Clear();   
            txtSearch.Clear();
            cmbPelanggan.SelectedIndex = -1;
            cmbMobil.SelectedIndex = -1;
            dtpRental.Value = DateTime.Now;
            dtpKembali.Value = DateTime.Now;
        }

        private void TampilTransaksi()
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    string sql = @"SELECT t.transaction_id, t.transaction_id, t.user_id, t.customer_id, t.car_id, u_customer_email.email AS [Email], u_customer_name.name AS [Pelanggan], m.brand, t.rent_date, t.return_date, t.total_price 
                                    FROM transactions t 
                                    JOIN customers c ON t.customer_id = c.customer_id 
                                    JOIN users u_customer_email ON t.user_id = u_customer_email.user_id 
                                    JOIN users u_customer_name ON c.user_id = u_customer_name.user_id 
                                    JOIN mobil m ON t.car_id = m.mobil_id";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                   
                    dgvDetail.DataSource = dt;

                    dgvDetail.Columns["total_price"].DefaultCellStyle.Format = "Rp #,##0";


                    dgvDetail.DataSource = dt; // Baris ini sudah ada di kode Anda

                    // --- TAMBAHKAN KODE INI DI BAWAHNYA ---
                    if (dgvDetail.Columns.Contains("transaction_id")) dgvDetail.Columns["transaction_id"].Visible = false;
                    if (dgvDetail.Columns.Contains("user_id")) dgvDetail.Columns["user_id"].Visible = false;
                    if (dgvDetail.Columns.Contains("customer_id")) dgvDetail.Columns["customer_id"].Visible = false;
                    if (dgvDetail.Columns.Contains("car_id")) dgvDetail.Columns["car_id"].Visible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void LoadCmbBox()
        {
            using (SqlConnection connection = KoneksiDatabase.GetConn())
            {
                try
                {
                    connection.Open();
                    string sqlUser = "SELECT user_id, email FROM users";
                    SqlDataAdapter daUser = new SqlDataAdapter(sqlUser, connection);
                    DataTable dtUser = new DataTable();
                    daUser.Fill(dtUser);

                    cmbUser.ValueMember = "user_id";
                    cmbUser.DisplayMember = "email";
                    cmbUser.DataSource = dtUser;

                    string sqlPelanggan = @"SELECT c.customer_id, u.name FROM customers c JOIN users u ON c.user_id = u.user_id";
                    SqlDataAdapter daPelanggan = new SqlDataAdapter(sqlPelanggan, connection);
                    DataTable dtPelanggan = new DataTable();
                    daPelanggan.Fill(dtPelanggan);
                

                    cmbPelanggan.ValueMember = "customer_id";
                    cmbPelanggan.DisplayMember = "name";
                    cmbPelanggan.DataSource = dtPelanggan;

                    string sqlMobil = "SELECT mobil_id, brand, harga_rental FROM mobil";
                    SqlDataAdapter daMobil = new SqlDataAdapter(sqlMobil, connection);
                    DataTable dtMobil = new DataTable();
                    daMobil.Fill(dtMobil);

                    cmbMobil.ValueMember = "mobil_id";
                    cmbMobil.DisplayMember = "brand";
                    cmbMobil.DataSource = dtMobil;

                    txtTotal.Clear();
                    cmbUser.SelectedValue = -1;
                    cmbPelanggan.SelectedValue = -1;
                    cmbMobil.SelectedValue = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }   
            }
        }



        private void UC_Transaksi_Load(object sender, EventArgs e)
        {
            if (session.NamaRole == "admin" )
            {
                btnCreate.Visible = false;
                btnDelete.Visible = true;
                btnEdit.Visible = true;
            }
            else if (session.NamaRole == "petugas")
            {
                btnCreate.Visible = true;
                btnEdit.Visible = true ;
                btnDelete.Visible = true ;
            }

            TampilTransaksi();
            LoadCmbBox();

        }

        //btn create
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTotal.Text) || string.IsNullOrEmpty(cmbPelanggan.Text) || string.IsNullOrEmpty(cmbMobil.Text) || string.IsNullOrEmpty(dtpRental.Text) || string.IsNullOrEmpty(dtpKembali.Text))
            {
                MessageBox.Show("Semua field harus diisi!");

            }
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = @"INSERT INTO transactions  (user_id, customer_id, car_id, rent_date, return_date, total_price) VALUES (@user_id, @customer_id, @car_id, @tanggal_sewa, @tanggal_kembali, @total)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@user_id", cmbUser.SelectedValue);
                    cmd.Parameters.AddWithValue("@customer_id", cmbPelanggan.SelectedValue);
                    cmd.Parameters.AddWithValue("@car_id", cmbMobil.SelectedValue);
                    cmd.Parameters.AddWithValue("@tanggal_sewa", dtpRental.Value);
                    cmd.Parameters.AddWithValue("@tanggal_kembali", dtpKembali.Value);
                    cmd.Parameters.AddWithValue("@total", txtTotal.Text);


                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Transaksi berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TampilTransaksi();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        //btn update
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbUser.Text) || string.IsNullOrEmpty(cmbPelanggan.Text) || string.IsNullOrEmpty(cmbMobil.Text) || string.IsNullOrEmpty(dtpRental.Text) || string.IsNullOrEmpty(dtpKembali.Text) || string.IsNullOrEmpty(txtTotal.Text))
            {
                MessageBox.Show("Semua field harus diisi!");
            }
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = @"UPDATE transactions  SET user_id = @user_id, customer_id = @customer_id, car_id = @car_id, rent_date = @tanggal_sewa, return_date = @tanggal_kembali, total_price = @total WHERE transaction_id = @transaction_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@transaction_id", SelectedTransaksiId);
                    cmd.Parameters.AddWithValue("@user_id", cmbUser.SelectedValue);
                    cmd.Parameters.AddWithValue("@customer_id", cmbPelanggan.SelectedValue);
                    cmd.Parameters.AddWithValue("@car_id", cmbMobil.SelectedValue);
                    cmd.Parameters.AddWithValue("@tanggal_sewa", dtpRental.Value);
                    cmd.Parameters.AddWithValue("@tanggal_kembali", dtpKembali.Value);
                    cmd.Parameters.AddWithValue("@total", txtTotal.Text);
                

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Transaksi berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TampilTransaksi();
                    ClearFields();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        //btn delete

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbUser.Text) || string.IsNullOrEmpty(cmbPelanggan.Text) || string.IsNullOrEmpty(cmbMobil.Text) || string.IsNullOrEmpty(dtpRental.Text) || string.IsNullOrEmpty(dtpKembali.Text) || string.IsNullOrEmpty(txtTotal.Text))
            {
                MessageBox.Show("Semua field harus diisi!");
            }
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = @"DELETE FROM transactions  WHERE transaction_id = @transaction_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@transaction_id", SelectedTransaksiId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Transaksi berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TampilTransaksi();
                    ClearFields();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDetail.Rows[e.RowIndex].Cells[0].Value != null)
            {
                DataGridViewRow row = dgvDetail.Rows[e.RowIndex];
                SelectedTransaksiId = int.Parse(row.Cells["transaction_id"].Value.ToString());
                cmbUser.SelectedValue = row.Cells["user_id"].Value;
                cmbPelanggan.SelectedValue = row.Cells["customer_id"].Value;
                cmbMobil.SelectedValue = row.Cells["car_id"].Value;
                dtpRental.Value = Convert.ToDateTime(row.Cells["rent_date"].Value);
                dtpKembali.Value = Convert.ToDateTime(row.Cells["return_date"].Value);
                txtTotal.Text = row.Cells["total_price"].Value.ToString();
            }
        }

        //otomatis hitung harga
        private void HitungOtomatisHarga()
        {
            if (cmbMobil.SelectedIndex != -1)
            {
                try
                {
                    //Ambil harga rental per hari dari database berdasarkan mobil yang dipilih
                    DataRowView drv = (DataRowView)cmbMobil.SelectedItem;

                    // Pastikan kolom harga_rental ada di DataTable yang digunakan untuk mengisi cmbMobil
                    decimal hargaPerHari = Convert.ToDecimal(drv["harga_rental"]);


                    //Hitung durasi sewa dalam hari
                    TimeSpan durasiSewa = dtpKembali.Value.Date - dtpRental.Value.Date;
                    int jumlahHari = durasiSewa.Days + 1; // Tambahkan 1 untuk menghitung hari pertama
                    decimal totalHarga = hargaPerHari * jumlahHari;
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error menghitung total harga: " + ex.Message);
                }
            }
        }


        //search
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    string sql = @"SELECT t.transaction_id, u_customer_email.email AS [Email], u_customer_name.name AS [Pelanggan], m.brand, t.rent_date, t.return_date, t.total_price 
                                    FROM transactions t 
                                    JOIN customers c ON t.customer_id = c.customer_id 
                                    JOIN users u_customer_email ON t.user_id = u_customer_email.user_id 
                                    JOIN users u_customer_name ON c.user_id = u_customer_name.user_id 
                                    JOIN mobil m ON t.car_id = m.mobil_id
                                    WHERE u_customer_email.email LIKE @search OR u_customer_name.name LIKE @search OR m.brand LIKE @search OR t.rent_date LIKE @search OR t.total_price LIKE @search ";


                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDetail.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        //filter rentang tanggal
        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();

                    DateTime tglAwal = dtpAwal.Value.Date;
                    DateTime tglAkhir = dtpAkhir.Value.Date;

                    string sql = @"SELECT t.transaction_id, u_customer_email.email AS [Email], u_customer_name.name AS [Pelanggan], m.brand, t.rent_date, t.return_date, t.total_price 
                                    FROM transactions t 
                                    JOIN customers c ON t.customer_id = c.customer_id 
                                    JOIN users u_customer_email ON t.user_id = u_customer_email.user_id 
                                    JOIN users u_customer_name ON c.user_id = u_customer_name.user_id 
                                    JOIN mobil m ON t.car_id = m.mobil_id
                                    WHERE t.rent_date BETWEEN @tglAwal AND @tglAkhir ";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@tglAwal", dtpAwal.Value.Date);
                    cmd.Parameters.AddWithValue("@tglAkhir", dtpAkhir.Value.Date);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDetail.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Event handler untuk menghitung harga otomatis saat tanggal kembali berubah
        private void dtpKembali_ValueChanged(object sender, EventArgs e)
        {
            HitungOtomatisHarga();
        }

        // Event handler untuk menghitung harga otomatis saat mobil yang dipilih berubah
        private void cmbMobil_SelectedIndexChanged(object sender, EventArgs e)
        {
            HitungOtomatisHarga();
        }

        // Event handler untuk menghitung harga otomatis saat tanggal sewa berubah
        private void dtpAwal_ValueChanged(object sender, EventArgs e)
        {
            HitungOtomatisHarga();
        }
    }
}