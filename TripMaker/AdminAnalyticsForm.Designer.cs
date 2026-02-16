namespace TripMaker
{
    partial class AdminAnalyticsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTotalBookings;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.DataGridView dgvByType;
        private System.Windows.Forms.DataGridView dgvDailyTrend;
        private System.Windows.Forms.DataGridView dgvTopRoutes;
        private System.Windows.Forms.DataGridView dgvTopHotels;
        private System.Windows.Forms.DataGridView dgvTopActivities;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.FlowLayoutPanel summaryPanel;
        private System.Windows.Forms.TableLayoutPanel gridPanel;
        private System.Windows.Forms.GroupBox grpByType;
        private System.Windows.Forms.GroupBox grpDailyTrend;
        private System.Windows.Forms.GroupBox grpTopRoutes;
        private System.Windows.Forms.GroupBox grpTopHotels;
        private System.Windows.Forms.GroupBox grpTopActivities;
        private System.Windows.Forms.Panel emptyPanel;

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
            this.components = new System.ComponentModel.Container();
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.summaryPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTotalBookings = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.gridPanel = new System.Windows.Forms.TableLayoutPanel();
            this.grpByType = new System.Windows.Forms.GroupBox();
            this.dgvByType = new System.Windows.Forms.DataGridView();
            this.grpDailyTrend = new System.Windows.Forms.GroupBox();
            this.dgvDailyTrend = new System.Windows.Forms.DataGridView();
            this.grpTopRoutes = new System.Windows.Forms.GroupBox();
            this.dgvTopRoutes = new System.Windows.Forms.DataGridView();
            this.grpTopHotels = new System.Windows.Forms.GroupBox();
            this.dgvTopHotels = new System.Windows.Forms.DataGridView();
            this.grpTopActivities = new System.Windows.Forms.GroupBox();
            this.dgvTopActivities = new System.Windows.Forms.DataGridView();
            this.emptyPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            this.summaryPanel.SuspendLayout();
            this.gridPanel.SuspendLayout();
            this.grpByType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvByType)).BeginInit();
            this.grpDailyTrend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyTrend)).BeginInit();
            this.grpTopRoutes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopRoutes)).BeginInit();
            this.grpTopHotels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopHotels)).BeginInit();
            this.grpTopActivities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopActivities)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.lblFrom);
            this.topPanel.Controls.Add(this.dtpFrom);
            this.topPanel.Controls.Add(this.lblTo);
            this.topPanel.Controls.Add(this.dtpTo);
            this.topPanel.Controls.Add(this.btnRefresh);
            this.topPanel.Controls.Add(this.btnBack);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1020, 70);
            this.topPanel.TabIndex = 0;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(20, 26);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(65, 22);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(150, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(250, 26);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(275, 22);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(150, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(450, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(560, 20);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // summaryPanel
            // 
            this.summaryPanel.Controls.Add(this.lblTotalBookings);
            this.summaryPanel.Controls.Add(this.lblTotalRevenue);
            this.summaryPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.summaryPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.summaryPanel.Location = new System.Drawing.Point(0, 70);
            this.summaryPanel.Name = "summaryPanel";
            this.summaryPanel.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.summaryPanel.Size = new System.Drawing.Size(1020, 80);
            this.summaryPanel.TabIndex = 1;
            // 
            // lblTotalBookings
            // 
            this.lblTotalBookings.AutoSize = false;
            this.lblTotalBookings.BackColor = System.Drawing.Color.White;
            this.lblTotalBookings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalBookings.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalBookings.Location = new System.Drawing.Point(20, 10);
            this.lblTotalBookings.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblTotalBookings.Name = "lblTotalBookings";
            this.lblTotalBookings.Size = new System.Drawing.Size(280, 52);
            this.lblTotalBookings.TabIndex = 0;
            this.lblTotalBookings.Text = "Total Bookings: 0";
            this.lblTotalBookings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = false;
            this.lblTotalRevenue.BackColor = System.Drawing.Color.White;
            this.lblTotalRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.Location = new System.Drawing.Point(316, 10);
            this.lblTotalRevenue.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(280, 52);
            this.lblTotalRevenue.TabIndex = 1;
            this.lblTotalRevenue.Text = "Total Revenue: 0";
            this.lblTotalRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridPanel
            // 
            this.gridPanel.ColumnCount = 2;
            this.gridPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gridPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gridPanel.Controls.Add(this.grpByType, 0, 0);
            this.gridPanel.Controls.Add(this.grpDailyTrend, 1, 0);
            this.gridPanel.Controls.Add(this.grpTopRoutes, 0, 1);
            this.gridPanel.Controls.Add(this.grpTopHotels, 1, 1);
            this.gridPanel.Controls.Add(this.grpTopActivities, 0, 2);
            this.gridPanel.Controls.Add(this.emptyPanel, 1, 2);
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPanel.Location = new System.Drawing.Point(0, 150);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Padding = new System.Windows.Forms.Padding(12);
            this.gridPanel.RowCount = 3;
            this.gridPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.gridPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.gridPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.gridPanel.Size = new System.Drawing.Size(1020, 490);
            this.gridPanel.TabIndex = 2;
            // 
            // grpByType
            // 
            this.grpByType.Controls.Add(this.dgvByType);
            this.grpByType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpByType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpByType.Location = new System.Drawing.Point(15, 15);
            this.grpByType.Name = "grpByType";
            this.grpByType.Size = new System.Drawing.Size(493, 150);
            this.grpByType.TabIndex = 0;
            this.grpByType.TabStop = false;
            this.grpByType.Text = "Bookings & Revenue By Type";
            // 
            // dgvByType
            // 
            this.dgvByType.AllowUserToAddRows = false;
            this.dgvByType.AllowUserToDeleteRows = false;
            this.dgvByType.AllowUserToResizeRows = false;
            this.dgvByType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvByType.BackgroundColor = System.Drawing.Color.White;
            this.dgvByType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvByType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvByType.MultiSelect = false;
            this.dgvByType.Name = "dgvByType";
            this.dgvByType.ReadOnly = true;
            this.dgvByType.RowHeadersVisible = false;
            this.dgvByType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvByType.TabIndex = 0;
            // 
            // grpDailyTrend
            // 
            this.grpDailyTrend.Controls.Add(this.dgvDailyTrend);
            this.grpDailyTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDailyTrend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpDailyTrend.Location = new System.Drawing.Point(514, 15);
            this.grpDailyTrend.Name = "grpDailyTrend";
            this.grpDailyTrend.Size = new System.Drawing.Size(493, 150);
            this.grpDailyTrend.TabIndex = 1;
            this.grpDailyTrend.TabStop = false;
            this.grpDailyTrend.Text = "Daily Booking Trend";
            // 
            // dgvDailyTrend
            // 
            this.dgvDailyTrend.AllowUserToAddRows = false;
            this.dgvDailyTrend.AllowUserToDeleteRows = false;
            this.dgvDailyTrend.AllowUserToResizeRows = false;
            this.dgvDailyTrend.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDailyTrend.BackgroundColor = System.Drawing.Color.White;
            this.dgvDailyTrend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDailyTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDailyTrend.MultiSelect = false;
            this.dgvDailyTrend.Name = "dgvDailyTrend";
            this.dgvDailyTrend.ReadOnly = true;
            this.dgvDailyTrend.RowHeadersVisible = false;
            this.dgvDailyTrend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDailyTrend.TabIndex = 0;
            // 
            // grpTopRoutes
            // 
            this.grpTopRoutes.Controls.Add(this.dgvTopRoutes);
            this.grpTopRoutes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTopRoutes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpTopRoutes.Location = new System.Drawing.Point(15, 171);
            this.grpTopRoutes.Name = "grpTopRoutes";
            this.grpTopRoutes.Size = new System.Drawing.Size(493, 150);
            this.grpTopRoutes.TabIndex = 2;
            this.grpTopRoutes.TabStop = false;
            this.grpTopRoutes.Text = "Top Routes";
            // 
            // dgvTopRoutes
            // 
            this.dgvTopRoutes.AllowUserToAddRows = false;
            this.dgvTopRoutes.AllowUserToDeleteRows = false;
            this.dgvTopRoutes.AllowUserToResizeRows = false;
            this.dgvTopRoutes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopRoutes.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopRoutes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopRoutes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopRoutes.MultiSelect = false;
            this.dgvTopRoutes.Name = "dgvTopRoutes";
            this.dgvTopRoutes.ReadOnly = true;
            this.dgvTopRoutes.RowHeadersVisible = false;
            this.dgvTopRoutes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopRoutes.TabIndex = 0;
            // 
            // grpTopHotels
            // 
            this.grpTopHotels.Controls.Add(this.dgvTopHotels);
            this.grpTopHotels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTopHotels.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpTopHotels.Location = new System.Drawing.Point(514, 171);
            this.grpTopHotels.Name = "grpTopHotels";
            this.grpTopHotels.Size = new System.Drawing.Size(493, 150);
            this.grpTopHotels.TabIndex = 3;
            this.grpTopHotels.TabStop = false;
            this.grpTopHotels.Text = "Top Hotels";
            // 
            // dgvTopHotels
            // 
            this.dgvTopHotels.AllowUserToAddRows = false;
            this.dgvTopHotels.AllowUserToDeleteRows = false;
            this.dgvTopHotels.AllowUserToResizeRows = false;
            this.dgvTopHotels.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopHotels.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopHotels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopHotels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopHotels.MultiSelect = false;
            this.dgvTopHotels.Name = "dgvTopHotels";
            this.dgvTopHotels.ReadOnly = true;
            this.dgvTopHotels.RowHeadersVisible = false;
            this.dgvTopHotels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopHotels.TabIndex = 0;
            // 
            // grpTopActivities
            // 
            this.grpTopActivities.Controls.Add(this.dgvTopActivities);
            this.grpTopActivities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTopActivities.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpTopActivities.Location = new System.Drawing.Point(15, 327);
            this.grpTopActivities.Name = "grpTopActivities";
            this.grpTopActivities.Size = new System.Drawing.Size(493, 150);
            this.grpTopActivities.TabIndex = 4;
            this.grpTopActivities.TabStop = false;
            this.grpTopActivities.Text = "Top Activities";
            // 
            // dgvTopActivities
            // 
            this.dgvTopActivities.AllowUserToAddRows = false;
            this.dgvTopActivities.AllowUserToDeleteRows = false;
            this.dgvTopActivities.AllowUserToResizeRows = false;
            this.dgvTopActivities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopActivities.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopActivities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopActivities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopActivities.MultiSelect = false;
            this.dgvTopActivities.Name = "dgvTopActivities";
            this.dgvTopActivities.ReadOnly = true;
            this.dgvTopActivities.RowHeadersVisible = false;
            this.dgvTopActivities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopActivities.TabIndex = 0;
            // 
            // emptyPanel
            // 
            this.emptyPanel.BackColor = System.Drawing.Color.Transparent;
            this.emptyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emptyPanel.Location = new System.Drawing.Point(514, 327);
            this.emptyPanel.Name = "emptyPanel";
            this.emptyPanel.Size = new System.Drawing.Size(493, 150);
            this.emptyPanel.TabIndex = 5;
            // 
            // AdminAnalyticsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1020, 640);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.summaryPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "AdminAnalyticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Analytics";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.summaryPanel.ResumeLayout(false);
            this.gridPanel.ResumeLayout(false);
            this.grpByType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvByType)).EndInit();
            this.grpDailyTrend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyTrend)).EndInit();
            this.grpTopRoutes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopRoutes)).EndInit();
            this.grpTopHotels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopHotels)).EndInit();
            this.grpTopActivities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopActivities)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
