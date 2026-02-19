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
            ConfigureButtonStyles();
            Resize += AdminMainForm_Resize;
            FormClosing += AdminMainForm_FormClosing;
            UpdateMaximizeButtonImage();
            ShowDashboard();
        }

        private void ConfigureButtonStyles()
        {
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 0, 0);
            btnClose.TabStop = false;

            btnMaximize.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnMaximize.FlatAppearance.MouseDownBackColor = Color.FromArgb(48, 48, 48);
            btnMaximize.TabStop = false;

            btnMinimize.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnMinimize.FlatAppearance.MouseDownBackColor = Color.FromArgb(48, 48, 48);
            btnMinimize.TabStop = false;
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
            DisableMetroShadowForHostedForm(form);
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.ControlBox = false;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            HideBackButtons(form.Controls);
        }

        private static void DisableMetroShadowForHostedForm(Form form)
        {
            // MetroFramework forms create a top-level shadow window by default.
            // Hosted forms are not top-level, so force shadow off to prevent owner exceptions.
            var shadowProperty = form.GetType().GetProperty("ShadowType");
            if (shadowProperty == null || !shadowProperty.CanWrite)
            {
                return;
            }

            var enumType = shadowProperty.PropertyType;
            if (!enumType.IsEnum)
            {
                return;
            }

            foreach (string enumName in Enum.GetNames(enumType))
            {
                if (string.Equals(enumName, "None", StringComparison.OrdinalIgnoreCase))
                {
                    object noneValue = Enum.Parse(enumType, enumName);
                    shadowProperty.SetValue(form, noneValue, null);
                    return;
                }
            }
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
            ActiveControl = null;
            _logoutNavigating = true;
            Session.Logout();
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            WindowState = WindowState == FormWindowState.Maximized
                ? FormWindowState.Normal
                : FormWindowState.Maximized;
            UpdateMaximizeButtonImage();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            WindowState = FormWindowState.Minimized;
        }

        private void AdminMainForm_Resize(object sender, EventArgs e)
        {
            UpdateMaximizeButtonImage();
        }

        private void UpdateMaximizeButtonImage()
        {
            btnMaximize.Image = WindowState == FormWindowState.Maximized
                ? Properties.Resources.maximize_after
                : Properties.Resources.maximize_before;
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
