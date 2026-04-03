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
    public partial class UC_ManajemenUser : UserControl
    {
        private int SelectedManajemenUserID = 0;

        public UC_ManajemenUser()
        {
            InitializeComponent();
            LoadData();
            LoadCmbRole();
        }

        private void ClearField()
        {
            txtEmail.Clear();
            txtName.Clear();
            txtPass.Clear();
            

            SelectedManajemenUserID = 0;
        }

        

        //Koneksi Database
        private void LoadData()
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();

                    string sql = "SELECT u.user_id, u.name, u.email, u.password, [role].role_name FROM Users u JOIN [role] ON u.role_id = [role].id";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvUser.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Load CMB
        private void LoadCmbRole()
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();

                    // Load role data into ComboBox
                    string sqlRole = "SELECT * FROM [role]";

                    SqlCommand cmd = new SqlCommand(sqlRole, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    cmbRole.ValueMember = "id";
                    cmbRole.DisplayMember = "role_name";
                    cmbRole.DataSource = dt;



                    cmbRole.SelectedIndex = -1;
                   


                    // Set default selection to none
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Create User!!

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(txtName.Text) || cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO Users (name, email, password, role_id) VALUES (@name, @email, @password, @role_id)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@password", txtPass.Text);
                    cmd.Parameters.AddWithValue("@role_id", Convert.ToInt32(cmbRole.SelectedValue));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                    ClearField();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
           
        }

        //Edit Data

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (SelectedManajemenUserID == 0)
            {
                MessageBox.Show("Please select a user to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(txtName.Text) || cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE Users SET name = @name, email = @email, password = @password, role_id = @role_id WHERE user_id = @user_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user_id", SelectedManajemenUserID);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@password", txtPass.Text);
                    cmd.Parameters.AddWithValue("@role_id", cmbRole.SelectedValue);



                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                    ClearField();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            
        }

        //Hapus Data
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedManajemenUserID == 0)
            {
                MessageBox.Show("Please select a user to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = KoneksiDatabase.GetConn())
                {
                    try
                    {
                        conn.Open();
                        string sql = "DELETE FROM Users WHERE user_id = @user_id";
                        SqlCommand cmd = new SqlCommand(sql, conn);

                        cmd.Parameters.AddWithValue("@user_id", SelectedManajemenUserID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData();
                        ClearField();



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void btnHapus_Click(object sender, EventArgs e)
        {
           
        }
        
    

               
                
  





        private void UC_ManajemenUser_Load(object sender, EventArgs e)
        {
           LoadData();
           LoadCmbRole();

            

        }

        //Klik DGV dan 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUser.Rows[e.RowIndex].Cells[0].Value != null)
            {
                DataGridViewRow row = dgvUser.Rows[e.RowIndex];
                SelectedManajemenUserID = int.Parse(row.Cells[0].Value.ToString());
                txtName.Text = row.Cells[1].Value.ToString();
                txtEmail.Text = row.Cells[2].Value.ToString();
                txtPass.Text = row.Cells[3].Value.ToString();
               
                cmbRole.Text = row.Cells[4].Value.ToString();

            }
        }


        //Search Data
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT u.user_id, u.name, u.email, u.password, [role].role_name FROM Users u JOIN [role] ON u.role_id = [role].id WHERE u.name LIKE @search OR u.email LIKE @search OR u.password LIKE @search OR [role].role_name LIKE @search";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUser.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
