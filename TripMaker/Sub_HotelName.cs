using System;
using System.Windows.Forms;

namespace TripMaker
{
    public partial class Sub_HotelName : UserControl
    {
        public Sub_HotelName()
        {
            InitializeComponent();
            Resize += (s, e) => ApplyResponsiveLayout();
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            int delta = Math.Max(0, ClientSize.Width - 698);

            btnGo.Left = 549 + delta;
            panel1.Left = 75;
            panel1.Width = Math.Max(551, 551 + delta);
        }

        private static Sub_HotelName instance;

        public static Sub_HotelName Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Sub_HotelName();
                }
                return instance;
            }
        }

        public static Sub_HotelName setInstance
        {
            set
            {
                instance = value;
            }
        }

        private string hotelName;

        public string HotelNamee
        {
            get
            {
                return hotelName;
            }
            set
            {
                hotelName = value;
                lblName.Text = value;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            HotelRoom.HotelNamee = this.lblName.Text;
            HotelRoom.Instance.HotelRoom_Load();
            HotelRoom.Instance.BringToFront();
        }
    }
}
