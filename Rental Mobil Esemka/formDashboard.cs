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
            label1.Text = $"{session.NamaUser} - {session.NamaRole}";
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

        //user control manajemen user
        private void manajemenUserToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UC_ManajemenUser manajemenUser = new UC_ManajemenUser();



            PanelMainSide.Controls.Clear();
            PanelMainSide.Controls.Add(manajemenUser);

        }

        //user control manajemen Mobil
        private void manajementMobilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_Mobil manajemenMobil = new UC_Mobil();

            PanelMainSide.Controls.Clear();
            PanelMainSide.Controls.Add(manajemenMobil);
        }

        //user control manajemen pelanggan
        private void manajemenCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_Pelanggan manajemenPelanggan = new UC_Pelanggan();

            PanelMainSide.Controls.Clear();
            PanelMainSide.Controls.Add(manajemenPelanggan);
        }

        //user control manajemen tipe identitas
        private void manajemenTipeIdentitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_TipeIdentitas uC_TipeIdentitas = new UC_TipeIdentitas();

            PanelMainSide.Controls.Clear();
            PanelMainSide.Controls.Add(uC_TipeIdentitas);
        }

        //user control manajemen car seat
        private void manajemenCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_CarSeat uC_CarSeat = new UC_CarSeat();

            PanelMainSide.Controls.Clear();
            PanelMainSide.Controls.Add(uC_CarSeat);    

        }

        //user control manajemen detail transaksi
        private void detailTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_DetailTransaksi uC_DetailTransaksi = new UC_DetailTransaksi();

            PanelMainSide.Controls.Clear();
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
            KoneksiDatabase.NamaEmail = null;
            KoneksiDatabase.Level = null;

            DialogResult dr = MessageBox.Show("Yakin Ingin Log Out?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                formLogin login = new formLogin();

                login.Show();
                this.Close();



            }
        }

        private void dasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
    