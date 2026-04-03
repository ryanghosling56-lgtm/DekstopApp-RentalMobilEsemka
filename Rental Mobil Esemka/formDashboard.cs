using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Mobil_Esemka
{
    public partial class formDashboard : Form
    {
        public formDashboard()
        {
            InitializeComponent();
        }

        private void menuStrip6_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void manajemenPelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manajemenMobilToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manajemenUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void PanelMainSide_Paint(object sender, PaintEventArgs e)
        {

        }

        private void formDashboard_Load(object sender, EventArgs e)
        {
            labelStatusUser.Text = $"{session.NamaUser} - {session.NamaRole}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
        private void manajemenToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

       

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        //User control dashboard

        private void dasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelMainSide.Controls.Clear();
            UC_Dashboard uC_Dashboard = new UC_Dashboard();
            uC_Dashboard.Dock = DockStyle.Fill;

            PanelMainSide.Controls.Add(uC_Dashboard);

        }

        //user control manajemen user
        private void manajemenUserToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            PanelMainSide.Controls.Clear();
            UC_ManajemenUser manajemenUser = new UC_ManajemenUser();

            manajemenUser.Dock = DockStyle.Fill;

            PanelMainSide.Controls.Add(manajemenUser);

        }

        //user control manajemen Mobil
        private void manajementMobilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelMainSide.Controls.Clear();
            UC_Mobil manajemenMobil = new UC_Mobil();

            manajemenMobil.Dock = DockStyle.Fill;

          
            PanelMainSide.Controls.Add(manajemenMobil);
        }

        //user control manajemen pelanggan
        private void manajemenCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelMainSide.Controls.Clear();
            UC_Pelanggan manajemenPelanggan = new UC_Pelanggan();

            manajemenPelanggan.Dock = DockStyle.Fill;

           
            PanelMainSide.Controls.Add(manajemenPelanggan);
        }

        //user control manajemen tipe identitas
        private void manajemenTipeIdentitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelMainSide.Controls.Clear();
            UC_TipeIdentitas uC_TipeIdentitas = new UC_TipeIdentitas();

            uC_TipeIdentitas.Dock = DockStyle.Fill;

            PanelMainSide.Controls.Add(uC_TipeIdentitas);
        }

        //user control manajemen car seat
        private void manajemenCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelMainSide.Controls.Clear();
            UC_CarSeat uC_CarSeat = new UC_CarSeat();
            uC_CarSeat.Dock = DockStyle.Fill;

            PanelMainSide.Controls.Add(uC_CarSeat);    

        }

        //user control manajemen detail transaksi
        private void detailTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelMainSide.Controls.Clear();
            UC_DetailTransaksi uC_DetailTransaksi = new UC_DetailTransaksi();
            uC_DetailTransaksi.Dock = DockStyle.Fill;   
         
            PanelMainSide.Controls.Add(uC_DetailTransaksi); 
        }

        //Exit!!
        private void manajemenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Yakin Ingin Keluar Dari Aplikasi?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //Logout!!
        private void settingToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           

            DialogResult dr = MessageBox.Show("Yakin Ingin Log Out?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                formLogin login = new formLogin();

                login.Show();
                this.Close();



            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void labelStatusUser_Click(object sender, EventArgs e)
        {

        }
    }
}
    