using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TripMaker
{
    public partial class AdminMainForm : Form
    {
        private readonly Dictionary<string, Form> _moduleCache = new Dictionary<string, Form>();
        private bool _logoutNavigating;

        public AdminMainForm()
        {
            InitializeComponent();
            ConfigureSidebarButtons();
            FormClosing += AdminMainForm_FormClosing;
            ShowDashboard();
        }

        private void ConfigureSidebarButtons()
        {
            Color navBackColor = panelSidebar.BackColor;
            Button[] navButtons =
            {
                btnUsers, btnHotels, btnRooms, btnBus, btnTrain, btnFlight, btnActivity, btnAnalytics
            };

            foreach (var btn in navButtons)
            {
                btn.FlatAppearance.MouseOverBackColor = navBackColor;
                btn.FlatAppearance.MouseDownBackColor = navBackColor;
                btn.TabStop = false;
            }
        }

        private void btnNav_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            panelIndicator.Visible = true;
            panelIndicator.Top = btn.Top;
            panelIndicator.Height = btn.Height;

            switch (btn.Name)
            {
                case "btnUsers":
                    ShowModule("users", () => new ManegerSignup());
                    break;
                case "btnHotels":
                    ShowModule("hotels", () => new ManageHotels());
                    break;
                case "btnRooms":
                    ShowModule("rooms", () => new ManageHotelRooms());
                    break;
                case "btnBus":
                    ShowModule("bus", () => new ManegerBus());
                    break;
                case "btnTrain":
                    ShowModule("train", () => new ManegerTrain());
                    break;
                case "btnFlight":
                    ShowModule("flight", () => new FlightManagerView());
                    break;
                case "btnActivity":
                    ShowModule("activity", () => new ManegerActivity());
                    break;
                case "btnAnalytics":
                    ShowModule("analytics", () => new AdminAnalyticsForm());
                    break;
            }

            ActiveControl = null;
        }

        private void ShowDashboard()
        {
            panelIndicator.Visible = false;
            panelDashboard.BringToFront();
        }

        private void ShowModule(string key, Func<Form> factory)
        {
            panelDashboard.SendToBack();

            if (!_moduleCache.TryGetValue(key, out Form module))
            {
                module = factory();
                PrepareHostedForm(module);
                panelContent.Controls.Add(module);
                _moduleCache[key] = module;
            }

            module.Show();
            module.BringToFront();
        }

        private static void PrepareHostedForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.ControlBox = false;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            HideBackButtons(form.Controls);
        }

        private static void HideBackButtons(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Button btn)
                {
                    if (btn.Name.StartsWith("btnBack", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(btn.Text?.Trim(), "Back", StringComparison.OrdinalIgnoreCase))
                    {
                        btn.Visible = false;
                    }
                }

                if (control.HasChildren)
                {
                    HideBackButtons(control.Controls);
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _logoutNavigating = true;
            Session.Logout();
            Form1 form1 = new Form1();
            form1.Show();
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AdminMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !_logoutNavigating)
            {
                Application.Exit();
            }
        }
    }
}
