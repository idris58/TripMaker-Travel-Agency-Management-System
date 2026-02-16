using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace TripMaker
{
    public partial class AdminAnalyticsForm : Form
    {
        private readonly Form _parent;
        private bool _exitRequested;

        public AdminAnalyticsForm(Form parent)
        {
            _parent = parent;
            InitializeComponent();
            Load += AdminAnalyticsForm_Load;
            FormClosing += AdminAnalyticsForm_FormClosing;
            FormClosed += AdminAnalyticsForm_FormClosed;
            btnRefresh.Click += (s, e) => LoadAnalytics();
            btnBack.Click += (s, e) => Close();
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
