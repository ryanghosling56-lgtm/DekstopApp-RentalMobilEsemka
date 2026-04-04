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
using System.Windows.Forms.DataVisualization.Charting;

namespace Rental_Mobil_Esemka
{
    public partial class UC_Dashboard : UserControl
    {
        public UC_Dashboard()
        {
            InitializeComponent();
            TampilGrafikTransaksiRentalPerBulan();
            LoadTransaksiTerakhir();
        }


        private void TampilGrafikTransaksiRentalPerBulan()
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT DATENAME(MONTH, rent_date) AS Bulan, COUNT(*) AS JumlahTransaksi
                                   FROM transactions
                                   GROUP BY DATENAME(MONTH, rent_date), MONTH(rent_date)
                                   ORDER BY MONTH(rent_date)";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    //bersihkan data sebelumnya
                    chart1.Series.Clear();
                    //buat series baru untuk transaksi rental
                    Series series = chart1.Series.Add("Transaksi Rental");

                    //Batang vertikal
                    series.ChartType = SeriesChartType.Column;

                    while (dr.Read())
                    {
                        ////nama bulan X
                        //string bulan = dr.GetString(0);

                        ////jumlah transaksi Y
                        //int jumlahTransaksi = dr.GetInt32(1);
                        //masukkan data ke chart
                        series.Points.AddXY(dr["Bulan"].ToString(), dr["JumlahTransaksi"]);
                    }
                  

                    //menampilkan nilai di atas kolom
                    series.IsValueShownAsLabel = true;
                    //mengatur warna kolom
                    series.Palette = ChartColorPalette.SeaGreen;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void LoadTransaksiTerakhir()
        {
            using (SqlConnection conn = KoneksiDatabase.GetConn())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT TOP 5 t.transaction_id, u.name AS Pelanggan, m.brand AS Mobil, t.rent_date, t.total_price
                                   FROM transactions t
                                   JOIN users u ON t.user_id = u.user_id
                                   JOIN mobil m ON t.car_id = m.mobil_id
                                   ORDER BY t.rent_date DESC";


                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;


                    dataGridView1.Columns["total_price"].DefaultCellStyle.Format = "Rp ##0"; // Format sebagai mata uang
                    dataGridView1.ReadOnly = true;  


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        //Load dashboard
        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            TampilGrafikTransaksiRentalPerBulan();
            LoadTransaksiTerakhir();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
