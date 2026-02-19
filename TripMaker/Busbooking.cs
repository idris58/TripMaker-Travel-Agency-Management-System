using System;
using System.Windows.Forms;

namespace TripMaker
{
    public partial class Busbooking : UserControl
    {
        private static Busbooking instance;
        public static Busbooking Instance => instance ?? (instance = new Busbooking());

        public static Busbooking setInstance
        {
            set { instance = value; }
        }

        public Busbooking()
        {
            InitializeComponent();
            Resize += (s, e) => ApplyResponsiveLayout();
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            int delta = Math.Max(0, ClientSize.Width - 674);

            Lblname.Left = Math.Max(180, (ClientSize.Width - Lblname.Width) / 2);
            aa.Left = 352 + delta;
            aaa.Left = 486 + delta;
            label1.Left = 600 + delta;
            lbldepT.Left = 369 + delta;
            lblarvT.Left = 495 + delta;
            lblprice.Left = 594 + delta;
            btnbook.Left = 593 + delta;

            panel1.Left = 75;
            panel1.Width = Math.Max(551, 551 + delta);
        }

        private string Busname, start, ending, depTime, arrTime, price, btype;

        public string busname
        {
            get { return Busname; }
            set { Busname = value; Lblname.Text = value; }
        }

        public string Start
        {
            get { return start; }
            set { start = value; lblstart.Text = value; }
        }


        public string Ending
        {
            get { return ending; }
            set { ending = value; lblEnding.Text = value; }
        }

        public string DepTime
        {
            get { return depTime; }
            set { depTime = value; lbldepT.Text = value; }
        }

        public string ArrTime
        {
            get { return arrTime; }
            set { arrTime = value; lblarvT.Text = value; }
        }

        public string Price
        {
            get { return price; }
            set { price = value; lblprice.Text = value; }
        }

        public void btnbook_Click(object sender, EventArgs e)
        {
            if (!Session.IsLoggedIn)
            {
                MessageBox.Show("You must be logged in to book.");
                return;
            }

            var busConfirmBookInstance = Busconfirmbook.Instance;
            busConfirmBookInstance.Busname = this.busname;
            busConfirmBookInstance.Start = this.Start;
            busConfirmBookInstance.Ending = this.Ending;
            busConfirmBookInstance.DepTime = this.DepTime;
            busConfirmBookInstance.ArrTime = this.ArrTime;
            busConfirmBookInstance.Price = this.Price;

            Busconfirmbook.Instance.busconfirmbook_Load();
            Busconfirmbook.Instance.BringToFront();
        }
    }
}
