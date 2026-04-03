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
    public partial class UC_CarSeat : UserControl
    {
        private int SelectedCarSeatId = 0; // Menyimpan ID car seat yang dipilih
        public UC_CarSeat()
        {
            InitializeComponent();
            TampilCarseat();
            ClearField();

        }



        private void ClearField()
        {
            txtCarseat.Clear();

        }


        private void TampilCarseat()
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    string sql = "SELECT * FROM kursimobil";
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCarseat.Text))
            {
                MessageBox.Show("Nama car seat tidak boleh kosong!");
            }

            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    string sql = "INSERT INTO kursimobil (jumlah_kursi) VALUES (@jumlah_kursi)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@jumlah_kursi", txtCarseat.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil ditambahkan!");

                    TampilCarseat();
                    ClearField();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCarseat.Text))
            {
                MessageBox.Show("Nama car seat tidak boleh kosong!");

            }
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    string sql = "UPDATE kursimobil SET jumlah_kursi = @jumlah_kursi WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@jumlah_kursi", txtCarseat.Text);
                    cmd.Parameters.AddWithValue("@id", SelectedCarSeatId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil diupdate!");
                    TampilCarseat();
                    ClearField();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        //btn delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCarseat.Text))
            {
                MessageBox.Show("Nama car seat tidak boleh kosong!");
            }
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM kursimobil WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@id", SelectedCarSeatId);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil dihapus!");

                    TampilCarseat();
                    ClearField();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        //Search Data
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    string sql = "SELECT * FROM kursimobil WHERE jumlah_kursi LIKE @search";
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


        // Event handler untuk klik pada DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                SelectedCarSeatId = int.Parse(row.Cells[0].Value.ToString());
                txtCarseat.Text = row.Cells[1].Value.ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


