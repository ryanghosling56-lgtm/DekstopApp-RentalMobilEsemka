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

    public partial class UC_TipeIdentitas : UserControl
    {
        private int SelectedTipeIdentitasId = 0; // Menyimpan ID tipe identitas yang dipilih
        public UC_TipeIdentitas()
        {
            InitializeComponent();
            TampilTipeIdentitas();
            ClearField();


        }

        private void ClearField()
        {
            txtTipeIdentitas.Clear();

        }

        private void TampilTipeIdentitas()
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    string sql = "SELECT * FROM identity_type";
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


        private void UC_TipeIdentitas_Load(object sender, EventArgs e)
        {

        }

        //btn create
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTipeIdentitas.Text))
            {
                MessageBox.Show("Tipe identitas tidak boleh kosong!");
                return;
            }
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO identity_type (name) VALUES (@name)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@name", txtTipeIdentitas.Text);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tipe identitas berhasil ditambahkan!");

                    TampilTipeIdentitas();
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
            if (string.IsNullOrEmpty(txtTipeIdentitas.Text))
            {
                MessageBox.Show("Tipe identitas tidak boleh kosong!");
                return;
            }
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE identity_type SET name = @name WHERE identity_type_id = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@name", txtTipeIdentitas.Text);
                    cmd.Parameters.AddWithValue("@id", SelectedTipeIdentitasId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tipe identitas berhasil diperbarui!");

                    TampilTipeIdentitas();
                    ClearField();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTipeIdentitas.Text))
            {
                MessageBox.Show("Tipe identitas tidak boleh kosong!");
                return;
            }
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM identity_type WHERE identity_type_id = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", SelectedTipeIdentitasId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tipe identitas berhasil dihapus!");

                    TampilTipeIdentitas();
                    ClearField();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                SelectedTipeIdentitasId = int.Parse(row.Cells[0].Value.ToString());
                txtTipeIdentitas.Text = row.Cells[1].Value.ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    string sql = "SELECT * FROM identity_type WHERE name LIKE @search";
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
    }
}
