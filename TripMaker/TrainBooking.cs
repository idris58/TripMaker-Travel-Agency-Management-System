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

        public string Ttype
        {
            get { return ttype; }
            set { ttype = value; lbltype.Text = value; }
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
            trainConfirmBookInstance.Ttype = this.Ttype;

            TrainConfirmBook.Instance.trainconfirmbook_Load();
            TrainConfirmBook.Instance.BringToFront();
        }
    }
}