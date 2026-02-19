
namespace TripMaker
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblLogo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlActivity = new System.Windows.Forms.Panel();
            this.btnActivity = new System.Windows.Forms.Button();
            this.pnlTrain = new System.Windows.Forms.Panel();
            this.btnTrain = new System.Windows.Forms.Button();
            this.pnlAbout = new System.Windows.Forms.Panel();
            this.pnlWallet = new System.Windows.Forms.Panel();
            this.btnAbout = new System.Windows.Forms.Button();
            this.pnlHotel = new System.Windows.Forms.Panel();
            this.pnlFlight = new System.Windows.Forms.Panel();
            this.btnBookingInfo = new System.Windows.Forms.Button();
            this.btnHotel = new System.Windows.Forms.Button();
            this.pnlBus = new System.Windows.Forms.Panel();
            this.btnFlight = new System.Windows.Forms.Button();
            this.pnlHome = new System.Windows.Forms.Panel();
            this.btnBus = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.panelUp = new System.Windows.Forms.Panel();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.Red;
            this.lblLogo.Location = new System.Drawing.Point(20, 35);
            this.lblLogo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(159, 36);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "TripMaker";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel1.Controls.Add(this.pnlActivity);
            this.panel1.Controls.Add(this.btnActivity);
            this.panel1.Controls.Add(this.pnlTrain);
            this.panel1.Controls.Add(this.btnTrain);
            this.panel1.Controls.Add(this.pnlAbout);
            this.panel1.Controls.Add(this.pnlWallet);
            this.panel1.Controls.Add(this.btnAbout);
            this.panel1.Controls.Add(this.pnlHotel);
            this.panel1.Controls.Add(this.pnlFlight);
            this.panel1.Controls.Add(this.btnBookingInfo);
            this.panel1.Controls.Add(this.btnHotel);
            this.panel1.Controls.Add(this.pnlBus);
            this.panel1.Controls.Add(this.btnFlight);
            this.panel1.Controls.Add(this.pnlHome);
            this.panel1.Controls.Add(this.btnBus);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.lblLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 678);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // pnlActivity
            // 
            this.pnlActivity.BackColor = System.Drawing.Color.Red;
            this.pnlActivity.Location = new System.Drawing.Point(1, 429);
            this.pnlActivity.Margin = new System.Windows.Forms.Padding(2);
            this.pnlActivity.Name = "pnlActivity";
            this.pnlActivity.Size = new System.Drawing.Size(14, 49);
            this.pnlActivity.TabIndex = 13;
            this.pnlActivity.Visible = false;
            // 
            // btnActivity
            // 
            this.btnActivity.FlatAppearance.BorderSize = 0;
            this.btnActivity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivity.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivity.ForeColor = System.Drawing.Color.White;
            this.btnActivity.Image = ((System.Drawing.Image)(resources.GetObject("btnActivity.Image")));
            this.btnActivity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActivity.Location = new System.Drawing.Point(15, 429);
            this.btnActivity.Margin = new System.Windows.Forms.Padding(2);
            this.btnActivity.Name = "btnActivity";
            this.btnActivity.Size = new System.Drawing.Size(177, 49);
            this.btnActivity.TabIndex = 14;
            this.btnActivity.Text = "Activity";
            this.btnActivity.UseVisualStyleBackColor = true;
            this.btnActivity.Click += new System.EventHandler(this.btn_function);
            // 
            // pnlTrain
            // 
            this.pnlTrain.BackColor = System.Drawing.Color.Red;
            this.pnlTrain.Location = new System.Drawing.Point(2, 305);
            this.pnlTrain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTrain.Name = "pnlTrain";
            this.pnlTrain.Size = new System.Drawing.Size(14, 49);
            this.pnlTrain.TabIndex = 11;
            this.pnlTrain.Visible = false;
            // 
            // btnTrain
            // 
            this.btnTrain.FlatAppearance.BorderSize = 0;
            this.btnTrain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrain.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrain.ForeColor = System.Drawing.Color.White;
            this.btnTrain.Image = ((System.Drawing.Image)(resources.GetObject("btnTrain.Image")));
            this.btnTrain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrain.Location = new System.Drawing.Point(16, 305);
            this.btnTrain.Margin = new System.Windows.Forms.Padding(2);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(177, 49);
            this.btnTrain.TabIndex = 12;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btn_function);
            // 
            // pnlAbout
            // 
            this.pnlAbout.BackColor = System.Drawing.Color.Red;
            this.pnlAbout.Location = new System.Drawing.Point(1, 544);
            this.pnlAbout.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAbout.Name = "pnlAbout";
            this.pnlAbout.Size = new System.Drawing.Size(14, 49);
            this.pnlAbout.TabIndex = 9;
            this.pnlAbout.Visible = false;
            // 
            // pnlWallet
            // 
            this.pnlWallet.BackColor = System.Drawing.Color.Red;
            this.pnlWallet.Location = new System.Drawing.Point(1, 485);
            this.pnlWallet.Margin = new System.Windows.Forms.Padding(2);
            this.pnlWallet.Name = "pnlWallet";
            this.pnlWallet.Size = new System.Drawing.Size(14, 49);
            this.pnlWallet.TabIndex = 6;
            this.pnlWallet.Visible = false;
            // 
            // btnAbout
            // 
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.ForeColor = System.Drawing.Color.White;
            this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
            this.btnAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbout.Location = new System.Drawing.Point(15, 544);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(177, 49);
            this.btnAbout.TabIndex = 10;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btn_function);
            // 
            // pnlHotel
            // 
            this.pnlHotel.BackColor = System.Drawing.Color.Red;
            this.pnlHotel.Location = new System.Drawing.Point(1, 367);
            this.pnlHotel.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHotel.Name = "pnlHotel";
            this.pnlHotel.Size = new System.Drawing.Size(14, 49);
            this.pnlHotel.TabIndex = 4;
            this.pnlHotel.Visible = false;
            // 
            // pnlFlight
            // 
            this.pnlFlight.BackColor = System.Drawing.Color.Red;
            this.pnlFlight.Location = new System.Drawing.Point(1, 248);
            this.pnlFlight.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFlight.Name = "pnlFlight";
            this.pnlFlight.Size = new System.Drawing.Size(14, 49);
            this.pnlFlight.TabIndex = 4;
            this.pnlFlight.Visible = false;
            // 
            // btnBookingInfo
            // 
            this.btnBookingInfo.FlatAppearance.BorderSize = 0;
            this.btnBookingInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookingInfo.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookingInfo.ForeColor = System.Drawing.Color.White;
            this.btnBookingInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnBookingInfo.Image")));
            this.btnBookingInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBookingInfo.Location = new System.Drawing.Point(15, 485);
            this.btnBookingInfo.Margin = new System.Windows.Forms.Padding(2);
            this.btnBookingInfo.Name = "btnBookingInfo";
            this.btnBookingInfo.Size = new System.Drawing.Size(177, 49);
            this.btnBookingInfo.TabIndex = 8;
            this.btnBookingInfo.Text = "Booking Info";
            this.btnBookingInfo.UseVisualStyleBackColor = true;
            this.btnBookingInfo.Click += new System.EventHandler(this.btn_function);
            // 
            // btnHotel
            // 
            this.btnHotel.FlatAppearance.BorderSize = 0;
            this.btnHotel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHotel.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHotel.ForeColor = System.Drawing.Color.White;
            this.btnHotel.Image = ((System.Drawing.Image)(resources.GetObject("btnHotel.Image")));
            this.btnHotel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHotel.Location = new System.Drawing.Point(15, 367);
            this.btnHotel.Margin = new System.Windows.Forms.Padding(2);
            this.btnHotel.Name = "btnHotel";
            this.btnHotel.Size = new System.Drawing.Size(177, 49);
            this.btnHotel.TabIndex = 5;
            this.btnHotel.Text = "Hotel";
            this.btnHotel.UseVisualStyleBackColor = true;
            this.btnHotel.Click += new System.EventHandler(this.btn_function);
            // 
            // pnlBus
            // 
            this.pnlBus.BackColor = System.Drawing.Color.Red;
            this.pnlBus.Location = new System.Drawing.Point(1, 185);
            this.pnlBus.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBus.Name = "pnlBus";
            this.pnlBus.Size = new System.Drawing.Size(14, 49);
            this.pnlBus.TabIndex = 4;
            this.pnlBus.Visible = false;
            // 
            // btnFlight
            // 
            this.btnFlight.FlatAppearance.BorderSize = 0;
            this.btnFlight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlight.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFlight.ForeColor = System.Drawing.Color.White;
            this.btnFlight.Image = ((System.Drawing.Image)(resources.GetObject("btnFlight.Image")));
            this.btnFlight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFlight.Location = new System.Drawing.Point(15, 248);
            this.btnFlight.Margin = new System.Windows.Forms.Padding(2);
            this.btnFlight.Name = "btnFlight";
            this.btnFlight.Size = new System.Drawing.Size(177, 49);
            this.btnFlight.TabIndex = 5;
            this.btnFlight.Text = "Flight";
            this.btnFlight.UseVisualStyleBackColor = true;
            this.btnFlight.Click += new System.EventHandler(this.btn_function);
            // 
            // pnlHome
            // 
            this.pnlHome.BackColor = System.Drawing.Color.Red;
            this.pnlHome.Location = new System.Drawing.Point(1, 121);
            this.pnlHome.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Size = new System.Drawing.Size(14, 49);
            this.pnlHome.TabIndex = 3;
            // 
            // btnBus
            // 
            this.btnBus.FlatAppearance.BorderSize = 0;
            this.btnBus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBus.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBus.ForeColor = System.Drawing.SystemColors.Window;
            this.btnBus.Image = ((System.Drawing.Image)(resources.GetObject("btnBus.Image")));
            this.btnBus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBus.Location = new System.Drawing.Point(15, 185);
            this.btnBus.Margin = new System.Windows.Forms.Padding(2);
            this.btnBus.Name = "btnBus";
            this.btnBus.Size = new System.Drawing.Size(177, 49);
            this.btnBus.TabIndex = 5;
            this.btnBus.Text = "Bus";
            this.btnBus.UseVisualStyleBackColor = true;
            this.btnBus.Click += new System.EventHandler(this.btn_function);
            // 
            // btnHome
            // 
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(15, 121);
            this.btnHome.Margin = new System.Windows.Forms.Padding(2);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(177, 49);
            this.btnHome.TabIndex = 3;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btn_function);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.AliceBlue;
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(199, 148);
            this.panel.Margin = new System.Windows.Forms.Padding(2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(701, 530);
            this.panel.TabIndex = 8;
            // 
            // panelUp
            // 
            this.panelUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.panelUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUp.Location = new System.Drawing.Point(199, 35);
            this.panelUp.Margin = new System.Windows.Forms.Padding(2);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(701, 113);
            this.panelUp.TabIndex = 9;
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pnlControl.Controls.Add(this.btnMinimize);
            this.pnlControl.Controls.Add(this.btnMaximize);
            this.pnlControl.Controls.Add(this.btnClose);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControl.Location = new System.Drawing.Point(199, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(701, 35);
            this.pnlControl.TabIndex = 21;
            this.pnlControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlControl_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackgroundImage = global::TripMaker.Properties.Resources.minimize;
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Location = new System.Drawing.Point(587, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(38, 35);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.BackgroundImage = global::TripMaker.Properties.Resources.maximize_before;
            this.btnMaximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Location = new System.Drawing.Point(625, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(38, 35);
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::TripMaker.Properties.Resources.CloseB;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(663, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(38, 35);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 678);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.panelUp);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(900, 678);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel pnlHome;
        private System.Windows.Forms.Panel pnlWallet;
        private System.Windows.Forms.Panel pnlHotel;
        private System.Windows.Forms.Panel pnlFlight;
        private System.Windows.Forms.Button btnBookingInfo;
        private System.Windows.Forms.Button btnHotel;
        private System.Windows.Forms.Panel pnlBus;
        private System.Windows.Forms.Button btnFlight;
        private System.Windows.Forms.Button btnBus;
        private System.Windows.Forms.Panel pnlAbout;
        private System.Windows.Forms.Button btnAbout;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Panel panelUp;
        protected System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel pnlTrain;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Panel pnlActivity;
        private System.Windows.Forms.Button btnActivity;
        public System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnClose;
    }
}

