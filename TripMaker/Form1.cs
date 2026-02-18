using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TripMaker
{
    public partial class Form1 : Form
    {
        private static Form1 instance;
        public static Form1 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Form1();
                }
                return instance;
            }
        }

        public Form1()
        {
            InitializeComponent();
            ConfigureSidebarButtons();
            Resize += Form1_Resize;
            UpdateMaximizeButtonImage();
        }

        
        private void ConfigureSidebarButtons()
        {
            Color navBackColor = panel1.BackColor;
            Button[] navButtons =
            {
                btnHome, btnBus, btnFlight, btnTrain, btnHotel, btnActivity, btnBookingInfo, btnAbout
            };

            foreach (var btn in navButtons)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = navBackColor;
                btn.FlatAppearance.MouseDownBackColor = navBackColor;
                btn.BackColor = navBackColor;
                btn.UseVisualStyleBackColor = false;
                btn.TabStop = false;
            }
        }
        public void red_panel_changed(bool home, bool bus, bool flight, bool train, bool hotel, bool activity, bool wallet, bool about)
        {
            pnlHome.Visible = home;
            pnlBus.Visible = bus;
            pnlFlight.Visible = flight;
            pnlTrain.Visible = train;
            pnlHotel.Visible = hotel;
            pnlActivity.Visible = activity;
            pnlWallet.Visible = wallet;
            pnlAbout.Visible = about;
        }

        private void btn_function(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Text)
            {
                case "Home":
                    red_panel_changed(true, false, false, false, false, false, false, false);
                    Home.Instance.BringToFront();
                    break;

                case "Bus":
                    red_panel_changed(false, true, false, false, false, false, false, false);
                    Bus.Instance.BringToFront();
                    break;

                case "Flight":
                    red_panel_changed(false, false, true, false, false, false, false, false);
                    Flight.Instance.BringToFront();
                    break;

                case "Train":
                    red_panel_changed(false, false, false, true, false, false, false, false);
                    Train.Instance.BringToFront();
                    break;

                case "Hotel":
                    red_panel_changed(false, false, false, false, true, false, false, false);
                    HotelRoom.Instance.flowLayoutPanel_clear();
                    Hotel.Instance.BringToFront();
                    break;

                case "Activity":
                    red_panel_changed(false, false, false, false, false, true, false, false);
                    Activity.Instance.BringToFront();
                    break;

                case "Booking Info":
                    if (!Session.IsLoggedIn)
                    {
                        MessageBox.Show("You must be logged in to View Booking Info.");
                        return;
                    }
                    red_panel_changed(false, false, false, false, false, false, true, false);
                    BookingInfo.Instance.BringToFront();
                    BookingInfo.Instance.LoadBookings();
                    break;

                case "About":
                    red_panel_changed(false, false, false, false, false, false, false, true);
                    About.Instance.BringToFront();
                    break;
            }

            this.ActiveControl = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel.Controls.Add(Home.Instance);
            Home.Instance.Dock = DockStyle.Fill;
            Home.Instance.BringToFront();

            panelUp.Controls.Add(LoginAndSignupPanel.Instance);
            LoginAndSignupPanel.Instance.Dock = DockStyle.Fill;
            LoginAndSignupPanel.Instance.BringToFront();

            panelUp.Controls.Add(LogoutPanel.Instance);
            LogoutPanel.Instance.Dock = DockStyle.Fill;

            panel.Controls.Add(Login.Instance);
            Login.Instance.Dock = DockStyle.Fill;

            panel.Controls.Add(Signup.Instance);
            Signup.Instance.Dock = DockStyle.Fill;

            panel.Controls.Add(Bus.Instance);
            Bus.Instance.Dock = DockStyle.Fill;

            panel.Controls.Add(Flight.Instance);
            Flight.Instance.Dock = DockStyle.Fill;

            panel.Controls.Add(Train.Instance);
            Train.Instance.Dock = DockStyle.Fill;

            panel.Controls.Add(Hotel.Instance);
            Hotel.Instance.Dock = DockStyle.Fill;

            panel.Controls.Add(Activity.Instance);
            Activity.Instance.Dock = DockStyle.Fill;

            panel.Controls.Add(profile.Instance);
            profile.Instance.Dock = DockStyle.Fill;

            panel.Controls.Add(Profileedit.Instance);
            Profileedit.Instance.Dock = DockStyle.Fill;

            panel.Controls.Add(HotelRoom.Instance);
            HotelRoom.Instance.Dock = DockStyle.Fill;

            panel.Controls.Add(BookingInfo.Instance);
            BookingInfo.Instance.Dock = DockStyle.Fill;

            panel.Controls.Add(Busconfirmbook.Instance);
            Busconfirmbook.Instance.Dock = DockStyle.Fill;

            panel.Controls.Add(Flightconfirmbook.Instance);
            Flightconfirmbook.Instance.Dock = DockStyle.Fill;

            panel.Controls.Add(TrainConfirmBook.Instance);
            TrainConfirmBook.Instance.Dock = DockStyle.Fill;

            panel.Controls.Add(HotelConfirmBook.Instance);
            HotelConfirmBook.Instance.Dock = DockStyle.Fill;


            panel.Controls.Add(ActivityConfirmBook.Instance);
            ActivityConfirmBook.Instance.Dock = DockStyle.Fill;

            panel.Controls.Add(About.Instance);
            About.Instance.Dock = DockStyle.Fill;

            red_panel_changed(true, false, false, false, false, false, false, false);

        }


        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        
        public void pnlControl_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Maximized
                ? FormWindowState.Normal
                : FormWindowState.Maximized;
            UpdateMaximizeButtonImage();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            UpdateMaximizeButtonImage();
        }

        private void UpdateMaximizeButtonImage()
        {
            btnMaximize.BackgroundImage = WindowState == FormWindowState.Maximized
                ? Properties.Resources.maximize_after
                : Properties.Resources.maximize_before;
        }
    }
}




