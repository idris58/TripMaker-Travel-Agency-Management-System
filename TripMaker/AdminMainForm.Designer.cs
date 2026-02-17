namespace TripMaker
{
    partial class AdminMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.Panel panelIndicator;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblAdminTitle;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnHotels;
        private System.Windows.Forms.Button btnRooms;
        private System.Windows.Forms.Button btnBus;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnFlight;
        private System.Windows.Forms.Button btnActivity;
        private System.Windows.Forms.Button btnAnalytics;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelIndicator = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblAdminTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAnalytics = new System.Windows.Forms.Button();
            this.btnActivity = new System.Windows.Forms.Button();
            this.btnFlight = new System.Windows.Forms.Button();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnBus = new System.Windows.Forms.Button();
            this.btnRooms = new System.Windows.Forms.Button();
            this.btnHotels = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.panelSidebar.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelDashboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panelSidebar.Controls.Add(this.panelIndicator);
            this.panelSidebar.Controls.Add(this.btnAnalytics);
            this.panelSidebar.Controls.Add(this.btnActivity);
            this.panelSidebar.Controls.Add(this.btnFlight);
            this.panelSidebar.Controls.Add(this.btnTrain);
            this.panelSidebar.Controls.Add(this.btnBus);
            this.panelSidebar.Controls.Add(this.btnRooms);
            this.panelSidebar.Controls.Add(this.btnHotels);
            this.panelSidebar.Controls.Add(this.btnUsers);
            this.panelSidebar.Controls.Add(this.lblLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 700);
            this.panelSidebar.TabIndex = 0;
            // 
            // panelIndicator
            // 
            this.panelIndicator.BackColor = System.Drawing.Color.Red;
            this.panelIndicator.Location = new System.Drawing.Point(0, 150);
            this.panelIndicator.Name = "panelIndicator";
            this.panelIndicator.Size = new System.Drawing.Size(8, 46);
            this.panelIndicator.TabIndex = 9;
            this.panelIndicator.Visible = false;
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Bauhaus 93", 24F);
            this.lblLogo.ForeColor = System.Drawing.Color.Red;
            this.lblLogo.Location = new System.Drawing.Point(18, 28);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(159, 36);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "TripMaker";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.btnLogout);
            this.panelTop.Controls.Add(this.lblAdminTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(220, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(980, 50);
            this.panelTop.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::TripMaker.Properties.Resources.CloseB;
            this.btnClose.Location = new System.Drawing.Point(936, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(44, 50);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblAdminTitle
            // 
            this.lblAdminTitle.AutoSize = true;
            this.lblAdminTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAdminTitle.ForeColor = System.Drawing.Color.White;
            this.lblAdminTitle.Location = new System.Drawing.Point(16, 12);
            this.lblAdminTitle.Name = "lblAdminTitle";
            this.lblAdminTitle.Size = new System.Drawing.Size(136, 20);
            this.lblAdminTitle.TabIndex = 0;
            this.lblAdminTitle.Text = "Admin Dashboard";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.AliceBlue;
            this.panelContent.Controls.Add(this.panelDashboard);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(220, 50);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(980, 650);
            this.panelContent.TabIndex = 2;
            // 
            // panelDashboard
            // 
            this.panelDashboard.Controls.Add(this.lblDashboard);
            this.panelDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashboard.Location = new System.Drawing.Point(0, 0);
            this.panelDashboard.Name = "panelDashboard";
            this.panelDashboard.Size = new System.Drawing.Size(980, 650);
            this.panelDashboard.TabIndex = 0;
            // 
            // lblDashboard
            // 
            this.lblDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDashboard.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblDashboard.Location = new System.Drawing.Point(0, 0);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(980, 650);
            this.lblDashboard.TabIndex = 0;
            this.lblDashboard.Text = "Welcome to Admin Panel";
            this.lblDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Font = new System.Drawing.Font("Century", 10F);
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLogout.Image = global::TripMaker.Properties.Resources.Logout;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(810, 8);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 36);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnAnalytics
            // 
            this.btnAnalytics.FlatAppearance.BorderSize = 0;
            this.btnAnalytics.Font = new System.Drawing.Font("Century", 11F);
            this.btnAnalytics.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAnalytics.Image = global::TripMaker.Properties.Resources.Analytics;
            this.btnAnalytics.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnalytics.Location = new System.Drawing.Point(12, 472);
            this.btnAnalytics.Name = "btnAnalytics";
            this.btnAnalytics.Padding = new System.Windows.Forms.Padding(4);
            this.btnAnalytics.Size = new System.Drawing.Size(200, 46);
            this.btnAnalytics.TabIndex = 8;
            this.btnAnalytics.Text = "   Analytics";
            this.btnAnalytics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnalytics.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnalytics.UseVisualStyleBackColor = true;
            this.btnAnalytics.Click += new System.EventHandler(this.btnNav_Click);
            // 
            // btnActivity
            // 
            this.btnActivity.FlatAppearance.BorderSize = 0;
            this.btnActivity.Font = new System.Drawing.Font("Century", 11F);
            this.btnActivity.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnActivity.Image = global::TripMaker.Properties.Resources.ManageActivity;
            this.btnActivity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActivity.Location = new System.Drawing.Point(12, 420);
            this.btnActivity.Name = "btnActivity";
            this.btnActivity.Padding = new System.Windows.Forms.Padding(4);
            this.btnActivity.Size = new System.Drawing.Size(200, 46);
            this.btnActivity.TabIndex = 7;
            this.btnActivity.Text = "   Manage Activity";
            this.btnActivity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActivity.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActivity.UseVisualStyleBackColor = true;
            this.btnActivity.Click += new System.EventHandler(this.btnNav_Click);
            // 
            // btnFlight
            // 
            this.btnFlight.FlatAppearance.BorderSize = 0;
            this.btnFlight.Font = new System.Drawing.Font("Century", 11F);
            this.btnFlight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFlight.Image = global::TripMaker.Properties.Resources.ManageFlight;
            this.btnFlight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFlight.Location = new System.Drawing.Point(12, 368);
            this.btnFlight.Name = "btnFlight";
            this.btnFlight.Padding = new System.Windows.Forms.Padding(4);
            this.btnFlight.Size = new System.Drawing.Size(200, 46);
            this.btnFlight.TabIndex = 6;
            this.btnFlight.Text = "   Manage Flight";
            this.btnFlight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFlight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFlight.UseVisualStyleBackColor = true;
            this.btnFlight.Click += new System.EventHandler(this.btnNav_Click);
            // 
            // btnTrain
            // 
            this.btnTrain.FlatAppearance.BorderSize = 0;
            this.btnTrain.Font = new System.Drawing.Font("Century", 11F);
            this.btnTrain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTrain.Image = global::TripMaker.Properties.Resources.ManageTrain;
            this.btnTrain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrain.Location = new System.Drawing.Point(12, 316);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Padding = new System.Windows.Forms.Padding(4);
            this.btnTrain.Size = new System.Drawing.Size(200, 46);
            this.btnTrain.TabIndex = 5;
            this.btnTrain.Text = "   Manage Train";
            this.btnTrain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnNav_Click);
            // 
            // btnBus
            // 
            this.btnBus.FlatAppearance.BorderSize = 0;
            this.btnBus.Font = new System.Drawing.Font("Century", 11F);
            this.btnBus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBus.Image = global::TripMaker.Properties.Resources.ManageBus;
            this.btnBus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBus.Location = new System.Drawing.Point(12, 264);
            this.btnBus.Name = "btnBus";
            this.btnBus.Padding = new System.Windows.Forms.Padding(4);
            this.btnBus.Size = new System.Drawing.Size(200, 46);
            this.btnBus.TabIndex = 4;
            this.btnBus.Text = "   Manage Bus";
            this.btnBus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBus.UseVisualStyleBackColor = true;
            this.btnBus.Click += new System.EventHandler(this.btnNav_Click);
            // 
            // btnRooms
            // 
            this.btnRooms.FlatAppearance.BorderSize = 0;
            this.btnRooms.Font = new System.Drawing.Font("Century", 11F);
            this.btnRooms.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRooms.Image = global::TripMaker.Properties.Resources.ManageHotelRoom;
            this.btnRooms.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRooms.Location = new System.Drawing.Point(12, 212);
            this.btnRooms.Name = "btnRooms";
            this.btnRooms.Padding = new System.Windows.Forms.Padding(4);
            this.btnRooms.Size = new System.Drawing.Size(200, 46);
            this.btnRooms.TabIndex = 3;
            this.btnRooms.Text = "   Manage Rooms";
            this.btnRooms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRooms.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRooms.UseVisualStyleBackColor = true;
            this.btnRooms.Click += new System.EventHandler(this.btnNav_Click);
            // 
            // btnHotels
            // 
            this.btnHotels.FlatAppearance.BorderSize = 0;
            this.btnHotels.Font = new System.Drawing.Font("Century", 11F);
            this.btnHotels.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnHotels.Image = global::TripMaker.Properties.Resources.Hotel;
            this.btnHotels.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHotels.Location = new System.Drawing.Point(12, 160);
            this.btnHotels.Name = "btnHotels";
            this.btnHotels.Padding = new System.Windows.Forms.Padding(4);
            this.btnHotels.Size = new System.Drawing.Size(200, 46);
            this.btnHotels.TabIndex = 2;
            this.btnHotels.Text = "   Manage Hotels";
            this.btnHotels.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHotels.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHotels.UseVisualStyleBackColor = true;
            this.btnHotels.Click += new System.EventHandler(this.btnNav_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.Font = new System.Drawing.Font("Century", 11F);
            this.btnUsers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUsers.Image = global::TripMaker.Properties.Resources.Manage_User;
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Location = new System.Drawing.Point(12, 108);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Padding = new System.Windows.Forms.Padding(4);
            this.btnUsers.Size = new System.Drawing.Size(200, 46);
            this.btnUsers.TabIndex = 1;
            this.btnUsers.Text = "   Manage Users";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnNav_Click);
            // 
            // AdminMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminMainForm";
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelDashboard.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
