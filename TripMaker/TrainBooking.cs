using System;
using System.Windows.Forms;

namespace TripMaker
{
    public partial class TrainBooking : UserControl
    {
        private static TrainBooking instance;
        public static TrainBooking Instance => instance ?? (instance = new TrainBooking());
        public static TrainBooking setInstance
        {
            set { instance = value; }
        }

        public TrainBooking()
        {
            InitializeComponent();
            Resize += (s, e) => ApplyResponsiveLayout();
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            int delta = Math.Max(0, ClientSize.Width - 674);

            Lblname.Left = Math.Max(180, (ClientSize.Width - Lblname.Width) / 2);
            aa.Left = 353 + delta;
            aaa.Left = 488 + delta;
            label1.Left = 605 + delta;
            lbldepT.Left = 370 + delta;
            lblarvT.Left = 497 + delta;
            lblprice.Left = 600 + delta;
            btnbook.Left = 585 + delta;

            panel1.Left = 63;
            panel1.Width = Math.Max(551, 551 + delta);
        }

        private string trainName, start, ending, depTime, arrTime, price, ttype;

        public string trainname
        {
            get { return trainName; }
            set { trainName = value; Lblname.Text = value; }
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
            var trainConfirmBookInstance = TrainConfirmBook.Instance;
            trainConfirmBookInstance.Trainname = this.trainname;
            trainConfirmBookInstance.Start = this.Start;
            trainConfirmBookInstance.Ending = this.Ending;
            trainConfirmBookInstance.DepTime = this.DepTime;
            trainConfirmBookInstance.ArrTime = this.ArrTime;
            trainConfirmBookInstance.Price = this.Price;

            TrainConfirmBook.Instance.trainconfirmbook_Load();
            TrainConfirmBook.Instance.BringToFront();
        }
    }
}
