namespace Rental_Mobil_Esemka
{
    partial class formDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formDashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.MenuDashboard = new System.Windows.Forms.MenuStrip();
            this.MenuStrip1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuManagementUser = new System.Windows.Forms.MenuStrip();
            this.MenuStripManajemenUser = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMobil = new System.Windows.Forms.MenuStrip();
            this.MenuStripMobil = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPelanggan = new System.Windows.Forms.MenuStrip();
            this.MenuStripCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTipeIdentitas = new System.Windows.Forms.MenuStrip();
            this.MenuStripTipeIdentitas = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCarseat = new System.Windows.Forms.MenuStrip();
            this.MenuStripCarseat = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDetail = new System.Windows.Forms.MenuStrip();
            this.MenuStripDetailTransaksi = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSetting = new System.Windows.Forms.MenuStrip();
            this.MenuStripSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manajemenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelStatusUser = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PanelMainSide = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.MenuDashboard.SuspendLayout();
            this.MenuManagementUser.SuspendLayout();
            this.MenuMobil.SuspendLayout();
            this.MenuPelanggan.SuspendLayout();
            this.MenuTipeIdentitas.SuspendLayout();
            this.MenuCarseat.SuspendLayout();
            this.MenuDetail.SuspendLayout();
            this.MenuSetting.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.menuStrip2);
            this.panel1.Location = new System.Drawing.Point(1, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 534);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.MenuDashboard);
            this.flowLayoutPanel1.Controls.Add(this.MenuManagementUser);
            this.flowLayoutPanel1.Controls.Add(this.MenuMobil);
            this.flowLayoutPanel1.Controls.Add(this.MenuPelanggan);
            this.flowLayoutPanel1.Controls.Add(this.MenuTipeIdentitas);
            this.flowLayoutPanel1.Controls.Add(this.MenuCarseat);
            this.flowLayoutPanel1.Controls.Add(this.MenuDetail);
            this.flowLayoutPanel1.Controls.Add(this.MenuSetting);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(24, 38);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(231, 324);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // MenuDashboard
            // 
            this.MenuDashboard.BackColor = System.Drawing.Color.LightSteelBlue;
            this.MenuDashboard.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuDashboard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStrip1});
            this.MenuDashboard.Location = new System.Drawing.Point(0, 0);
            this.MenuDashboard.Name = "MenuDashboard";
            this.MenuDashboard.Size = new System.Drawing.Size(231, 28);
            this.MenuDashboard.TabIndex = 12;
            this.MenuDashboard.Text = "menuStrip8";
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Image = global::Rental_Mobil_Esemka.Resource.house_navigation_button_app_page_dashboard_home_icon_219341;
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(108, 24);
            this.MenuStrip1.Text = "Dasboard";
            this.MenuStrip1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MenuStrip1.Click += new System.EventHandler(this.MenuStrip1_Click);
            // 
            // MenuManagementUser
            // 
            this.MenuManagementUser.BackColor = System.Drawing.Color.LightSteelBlue;
            this.MenuManagementUser.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuManagementUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripManajemenUser});
            this.MenuManagementUser.Location = new System.Drawing.Point(0, 28);
            this.MenuManagementUser.Name = "MenuManagementUser";
            this.MenuManagementUser.Size = new System.Drawing.Size(231, 28);
            this.MenuManagementUser.TabIndex = 13;
            this.MenuManagementUser.Text = "ManajemenUser";
            // 
            // MenuStripManajemenUser
            // 
            this.MenuStripManajemenUser.Image = global::Rental_Mobil_Esemka.Resource.find_users_applications_search_29081;
            this.MenuStripManajemenUser.Name = "MenuStripManajemenUser";
            this.MenuStripManajemenUser.Size = new System.Drawing.Size(187, 24);
            this.MenuStripManajemenUser.Text = "MenuManajemenUser";
            this.MenuStripManajemenUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MenuStripManajemenUser.Click += new System.EventHandler(this.MenuStripManajemenUser_Click);
            // 
            // MenuMobil
            // 
            this.MenuMobil.BackColor = System.Drawing.Color.LightSteelBlue;
            this.MenuMobil.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuMobil.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripMobil});
            this.MenuMobil.Location = new System.Drawing.Point(0, 56);
            this.MenuMobil.Name = "MenuMobil";
            this.MenuMobil.Size = new System.Drawing.Size(231, 28);
            this.MenuMobil.TabIndex = 14;
            this.MenuMobil.Text = "menuStrip10";
            // 
            // MenuStripMobil
            // 
            this.MenuStripMobil.Image = global::Rental_Mobil_Esemka.Resource.car_vehicle_transport_icon_144665;
            this.MenuStripMobil.Name = "MenuStripMobil";
            this.MenuStripMobil.Size = new System.Drawing.Size(169, 24);
            this.MenuStripMobil.Text = "Manajement Mobil";
            this.MenuStripMobil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MenuStripMobil.Click += new System.EventHandler(this.MenuStripMobil_Click);
            // 
            // MenuPelanggan
            // 
            this.MenuPelanggan.BackColor = System.Drawing.Color.LightSteelBlue;
            this.MenuPelanggan.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuPelanggan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripCustomer});
            this.MenuPelanggan.Location = new System.Drawing.Point(0, 84);
            this.MenuPelanggan.Name = "MenuPelanggan";
            this.MenuPelanggan.Size = new System.Drawing.Size(231, 28);
            this.MenuPelanggan.TabIndex = 15;
            this.MenuPelanggan.Text = "menuStrip7";
            // 
            // MenuStripCustomer
            // 
            this.MenuStripCustomer.Image = global::Rental_Mobil_Esemka.Resource._4092564_about_mobile_ui_profile_ui_user_website_114033;
            this.MenuStripCustomer.Name = "MenuStripCustomer";
            this.MenuStripCustomer.Size = new System.Drawing.Size(188, 24);
            this.MenuStripCustomer.Text = "Manajemen Customer";
            this.MenuStripCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MenuStripCustomer.Click += new System.EventHandler(this.MenuStripCustomer_Click);
            // 
            // MenuTipeIdentitas
            // 
            this.MenuTipeIdentitas.BackColor = System.Drawing.Color.LightSteelBlue;
            this.MenuTipeIdentitas.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuTipeIdentitas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripTipeIdentitas});
            this.MenuTipeIdentitas.Location = new System.Drawing.Point(0, 112);
            this.MenuTipeIdentitas.Name = "MenuTipeIdentitas";
            this.MenuTipeIdentitas.Size = new System.Drawing.Size(231, 28);
            this.MenuTipeIdentitas.TabIndex = 16;
            this.MenuTipeIdentitas.Text = "menuStrip6";
            // 
            // MenuStripTipeIdentitas
            // 
            this.MenuStripTipeIdentitas.Image = global::Rental_Mobil_Esemka.Resource.identity_card_id_icon_123863;
            this.MenuStripTipeIdentitas.Name = "MenuStripTipeIdentitas";
            this.MenuStripTipeIdentitas.Size = new System.Drawing.Size(215, 24);
            this.MenuStripTipeIdentitas.Text = "Manajemen Tipe Identitas";
            this.MenuStripTipeIdentitas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MenuStripTipeIdentitas.Click += new System.EventHandler(this.MenuStripTipeIdentitas_Click);
            // 
            // MenuCarseat
            // 
            this.MenuCarseat.BackColor = System.Drawing.Color.LightSteelBlue;
            this.MenuCarseat.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuCarseat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripCarseat});
            this.MenuCarseat.Location = new System.Drawing.Point(0, 140);
            this.MenuCarseat.Name = "MenuCarseat";
            this.MenuCarseat.Size = new System.Drawing.Size(231, 28);
            this.MenuCarseat.TabIndex = 17;
            this.MenuCarseat.Text = "menuStrip5";
            // 
            // MenuStripCarseat
            // 
            this.MenuStripCarseat.Image = global::Rental_Mobil_Esemka.Resource.car_child_seat_icon_137817;
            this.MenuStripCarseat.Name = "MenuStripCarseat";
            this.MenuStripCarseat.Size = new System.Drawing.Size(176, 24);
            this.MenuStripCarseat.Text = "Manajemen CarSeat";
            this.MenuStripCarseat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MenuStripCarseat.Click += new System.EventHandler(this.MenuStripCarseat_Click);
            // 
            // MenuDetail
            // 
            this.MenuDetail.BackColor = System.Drawing.Color.LightSteelBlue;
            this.MenuDetail.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripDetailTransaksi});
            this.MenuDetail.Location = new System.Drawing.Point(0, 168);
            this.MenuDetail.Name = "MenuDetail";
            this.MenuDetail.Size = new System.Drawing.Size(231, 28);
            this.MenuDetail.TabIndex = 18;
            this.MenuDetail.Text = "menuStrip4";
            // 
            // MenuStripDetailTransaksi
            // 
            this.MenuStripDetailTransaksi.Image = global::Rental_Mobil_Esemka.Resource.transaction_minus_icon_244826;
            this.MenuStripDetailTransaksi.Name = "MenuStripDetailTransaksi";
            this.MenuStripDetailTransaksi.Size = new System.Drawing.Size(146, 24);
            this.MenuStripDetailTransaksi.Text = "Detail Transaksi";
            this.MenuStripDetailTransaksi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MenuStripDetailTransaksi.Click += new System.EventHandler(this.MenuStripDetailTransaksi_Click);
            // 
            // MenuSetting
            // 
            this.MenuSetting.BackColor = System.Drawing.Color.LightSteelBlue;
            this.MenuSetting.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuSetting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripSetting});
            this.MenuSetting.Location = new System.Drawing.Point(0, 196);
            this.MenuSetting.Name = "MenuSetting";
            this.MenuSetting.Size = new System.Drawing.Size(231, 28);
            this.MenuSetting.TabIndex = 19;
            this.MenuSetting.Text = "menuStrip3";
            // 
            // MenuStripSetting
            // 
            this.MenuStripSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem,
            this.manajemenToolStripMenuItem});
            this.MenuStripSetting.Image = global::Rental_Mobil_Esemka.Resource.setting_icon_2377751;
            this.MenuStripSetting.Name = "MenuStripSetting";
            this.MenuStripSetting.Size = new System.Drawing.Size(96, 24);
            this.MenuStripSetting.Text = "Settings";
            this.MenuStripSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MenuStripSetting.Click += new System.EventHandler(this.MenuStripSetting_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Image = global::Rental_Mobil_Esemka.Resource.log_out_icon_icons_com_50106;
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.settingToolStripMenuItem.Text = "Log Out";
            this.settingToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click_2);
            // 
            // manajemenToolStripMenuItem
            // 
            this.manajemenToolStripMenuItem.Image = global::Rental_Mobil_Esemka.Resource.powercircleandlinesymbol_1183691;
            this.manajemenToolStripMenuItem.Name = "manajemenToolStripMenuItem";
            this.manajemenToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.manajemenToolStripMenuItem.Text = "Exit Application";
            this.manajemenToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.manajemenToolStripMenuItem.Click += new System.EventHandler(this.manajemenToolStripMenuItem_Click_2);
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(263, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.labelStatusUser);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Location = new System.Drawing.Point(0, 477);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(263, 57);
            this.panel4.TabIndex = 13;
            // 
            // labelStatusUser
            // 
            this.labelStatusUser.BackColor = System.Drawing.Color.WhiteSmoke;
            this.labelStatusUser.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatusUser.Location = new System.Drawing.Point(40, 5);
            this.labelStatusUser.Name = "labelStatusUser";
            this.labelStatusUser.Size = new System.Drawing.Size(221, 37);
            this.labelStatusUser.TabIndex = 4;
            this.labelStatusUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelStatusUser.Click += new System.EventHandler(this.labelStatusUser_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox2.Image = global::Rental_Mobil_Esemka.Resource._4092564_about_mobile_ui_profile_ui_user_website_114033;
            this.pictureBox2.Location = new System.Drawing.Point(3, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // PanelMainSide
            // 
            this.PanelMainSide.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelMainSide.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PanelMainSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelMainSide.Location = new System.Drawing.Point(262, -19);
            this.PanelMainSide.Name = "PanelMainSide";
            this.PanelMainSide.Size = new System.Drawing.Size(814, 607);
            this.PanelMainSide.TabIndex = 1;
            this.PanelMainSide.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelMainSide_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(263, 51);
            this.panel2.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(-1, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(263, 471);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 35);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rental Mobil Esemka";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox1.Image = global::Rental_Mobil_Esemka.Resource.car90_42507;
            this.pictureBox1.Location = new System.Drawing.Point(23, -12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // formDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1076, 583);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PanelMainSide);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard Page - Rental Mobil Esemka";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.MenuDashboard.ResumeLayout(false);
            this.MenuDashboard.PerformLayout();
            this.MenuManagementUser.ResumeLayout(false);
            this.MenuManagementUser.PerformLayout();
            this.MenuMobil.ResumeLayout(false);
            this.MenuMobil.PerformLayout();
            this.MenuPelanggan.ResumeLayout(false);
            this.MenuPelanggan.PerformLayout();
            this.MenuTipeIdentitas.ResumeLayout(false);
            this.MenuTipeIdentitas.PerformLayout();
            this.MenuCarseat.ResumeLayout(false);
            this.MenuCarseat.PerformLayout();
            this.MenuDetail.ResumeLayout(false);
            this.MenuDetail.PerformLayout();
            this.MenuSetting.ResumeLayout(false);
            this.MenuSetting.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.Panel PanelMainSide;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelStatusUser;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.MenuStrip MenuDashboard;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip1;
        private System.Windows.Forms.MenuStrip MenuManagementUser;
        private System.Windows.Forms.ToolStripMenuItem MenuStripManajemenUser;
        private System.Windows.Forms.MenuStrip MenuMobil;
        private System.Windows.Forms.ToolStripMenuItem MenuStripMobil;
        private System.Windows.Forms.MenuStrip MenuPelanggan;
        private System.Windows.Forms.ToolStripMenuItem MenuStripCustomer;
        private System.Windows.Forms.MenuStrip MenuTipeIdentitas;
        private System.Windows.Forms.ToolStripMenuItem MenuStripTipeIdentitas;
        private System.Windows.Forms.MenuStrip MenuCarseat;
        private System.Windows.Forms.ToolStripMenuItem MenuStripCarseat;
        private System.Windows.Forms.MenuStrip MenuDetail;
        private System.Windows.Forms.ToolStripMenuItem MenuStripDetailTransaksi;
        private System.Windows.Forms.MenuStrip MenuSetting;
        private System.Windows.Forms.ToolStripMenuItem MenuStripSetting;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manajemenToolStripMenuItem;
    }
}