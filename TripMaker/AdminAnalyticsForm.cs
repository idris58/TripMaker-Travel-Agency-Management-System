using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace TripMaker
{
    public class AdminAnalyticsForm : Form
    {
        private readonly Form _parent;
        private bool _exitRequested;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Button btnRefresh;
        private Button btnBack;
        private Label lblTotalBookings;
        private Label lblTotalRevenue;
        private DataGridView dgvByType;
        private DataGridView dgvDailyTrend;
        private DataGridView dgvTopRoutes;
        private DataGridView dgvTopHotels;
        private DataGridView dgvTopActivities;

        public AdminAnalyticsForm(Form parent)
        {
            _parent = parent;
            InitializeUi();
            Load += AdminAnalyticsForm_Load;
            FormClosing += AdminAnalyticsForm_FormClosing;
            FormClosed += AdminAnalyticsForm_FormClosed;
        }

        private void AdminAnalyticsForm_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now.AddDays(-30);
            dtpTo.Value = DateTime.Now;
            LoadAnalytics();
        }

        private void AdminAnalyticsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_exitRequested && _parent != null && !_parent.IsDisposed)
            {
                _parent.Show();
            }
        }

        private void AdminAnalyticsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                _exitRequested = true;
                Application.Exit();
            }
        }

        private void InitializeUi()
        {
            Text = "Admin Analytics";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1020, 640);
            BackColor = Color.WhiteSmoke;

            var topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70
            };

            var lblFrom = new Label { Text = "From", AutoSize = true, Left = 20, Top = 26 };
            var lblTo = new Label { Text = "To", AutoSize = true, Left = 250, Top = 26 };
            dtpFrom = new DateTimePicker { Format = DateTimePickerFormat.Short, Left = 65, Top = 22, Width = 150 };
            dtpTo = new DateTimePicker { Format = DateTimePickerFormat.Short, Left = 275, Top = 22, Width = 150 };
            btnRefresh = new Button { Text = "Refresh", Left = 450, Top = 20, Width = 100, Height = 30 };
            btnBack = new Button { Text = "Back", Left = 560, Top = 20, Width = 100, Height = 30 };
            btnRefresh.Click += (s, e) => LoadAnalytics();
            btnBack.Click += (s, e) => Close();

            topPanel.Controls.Add(lblFrom);
            topPanel.Controls.Add(dtpFrom);
            topPanel.Controls.Add(lblTo);
            topPanel.Controls.Add(dtpTo);
            topPanel.Controls.Add(btnRefresh);
            topPanel.Controls.Add(btnBack);

            var summaryPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 80,
                Padding = new Padding(20, 10, 20, 10),
                FlowDirection = FlowDirection.LeftToRight
            };

            lblTotalBookings = CreateSummaryLabel("Total Bookings: 0");
            lblTotalRevenue = CreateSummaryLabel("Total Revenue: 0");
            summaryPanel.Controls.Add(lblTotalBookings);
            summaryPanel.Controls.Add(lblTotalRevenue);

            var gridPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 3,
                Padding = new Padding(12),
                BackColor = Color.WhiteSmoke
            };
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            gridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33f));
            gridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33f));
            gridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33f));

            dgvByType = CreateGrid();
            dgvDailyTrend = CreateGrid();
            dgvTopRoutes = CreateGrid();
            dgvTopHotels = CreateGrid();
            dgvTopActivities = CreateGrid();

            gridPanel.Controls.Add(WrapGrid("Bookings & Revenue By Type", dgvByType), 0, 0);
            gridPanel.Controls.Add(WrapGrid("Daily Booking Trend", dgvDailyTrend), 1, 0);
            gridPanel.Controls.Add(WrapGrid("Top Routes", dgvTopRoutes), 0, 1);
            gridPanel.Controls.Add(WrapGrid("Top Hotels", dgvTopHotels), 1, 1);
            gridPanel.Controls.Add(WrapGrid("Top Activities", dgvTopActivities), 0, 2);

            var emptyPanel = new Panel { BackColor = Color.Transparent, Dock = DockStyle.Fill };
            gridPanel.Controls.Add(emptyPanel, 1, 2);

            Controls.Add(gridPanel);
            Controls.Add(summaryPanel);
            Controls.Add(topPanel);
        }

        private static Label CreateSummaryLabel(string text)
        {
            return new Label
            {
                AutoSize = false,
                Width = 280,
                Height = 52,
                Margin = new Padding(0, 0, 16, 0),
                TextAlign = ContentAlignment.MiddleLeft,
                Text = text,
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };
        }

        private static DataGridView CreateGrid()
        {
            return new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                BackgroundColor = Color.White
            };
        }

        private static GroupBox WrapGrid(string title, Control grid)
        {
            var group = new GroupBox
            {
                Text = title,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold)
            };
            group.Controls.Add(grid);
            return group;
        }

        private void LoadAnalytics()
        {
            if (dtpTo.Value.Date < dtpFrom.Value.Date)
            {
                MessageBox.Show("To date must be greater than or equal to From date.");
                return;
            }

            string error;
            var snapshot = AdminAnalyticsService.Load(dtpFrom.Value.Date, dtpTo.Value.Date, out error);
            if (!string.IsNullOrEmpty(error) || snapshot == null)
            {
                MessageBox.Show("Failed to load analytics: " + error);
                return;
            }

            lblTotalBookings.Text = "Total Bookings: " + snapshot.TotalBookings;
            lblTotalRevenue.Text = "Total Revenue: " + snapshot.TotalRevenue.ToString("N2", CultureInfo.InvariantCulture);

            dgvByType.DataSource = snapshot.ByType;
            dgvDailyTrend.DataSource = snapshot.DailyTrend;
            dgvTopRoutes.DataSource = snapshot.TopRoutes;
            dgvTopHotels.DataSource = snapshot.TopHotels;
            dgvTopActivities.DataSource = snapshot.TopActivities;
        }
    }
}
