using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace TripMaker
{
    public partial class HotelRoom : UserControl
    {
        private Sub_RoomInfo[] Sub_RoomInfo;
        private static string hotelName;
        private DataTable dt;

        private static HotelRoom instance;
        public static HotelRoom Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HotelRoom();
                }
                return instance;
            }
        }
        public static HotelRoom setInstance { set => instance = value; }

        public static string HotelNamee
        {
            get => hotelName;
            set => hotelName = value;
        }

        public HotelRoom()
        {
            InitializeComponent();
            Resize += (s, e) => ApplyResponsiveLayout();
            flowLayoutPanel1.Resize += (s, e) => ResizeRoomCards();
        }

        public void HotelRoom_Load()
        {
            lblHotelName.Text = hotelName;

            try
            {
                using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Room WHERE Hotel_Id = (SELECT Hotel_Id FROM Hotel WHERE Hotel_Name = :hotelName)";
                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {
                        cmd.Parameters.Add("hotelName", OracleDbType.Varchar2).Value = hotelName;
                        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                        {
                            dt = new DataTable();
                            adapter.Fill(dt);
                        }
                    }
                }

                Sub_RoomInfo = new Sub_RoomInfo[dt.Rows.Count];
                flowLayoutPanel1.Controls.Clear();



                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string roomType = dt.Rows[i]["Normal"].ToString() == "Yes" ? "Normal" :
                  dt.Rows[i]["Deluxe"].ToString() == "Yes" ? "Deluxe" :
                  "Super Deluxe";

                    // Set default values
                    string breakfast = "No", lunch = "No", dinner = "No", guest = "1";

                    // Logic based on room type
                    if (roomType == "Super Deluxe")
                    {
                        breakfast = "Yes";
                        dinner = "Yes";
                        guest = "1";
                    }
                    else if (roomType == "Deluxe")
                    {
                        breakfast = "Yes";
                        guest = "3";
                    }
                    else if (roomType == "Normal")
                    {
                        guest = "5";
                    }

                    // Now assign all values to the Sub_RoomInfo
                    Sub_RoomInfo[i] = new Sub_RoomInfo
                    {
                        RoomName = roomType,
                        Breakfast = breakfast,
                        Lunch = lunch,
                        Dinner = dinner,
                        Guest = guest,
                        Price = dt.Rows[i]["Price"].ToString() + " TK"
                    };
                    flowLayoutPanel1.Controls.Add(Sub_RoomInfo[i]);
                }
                ApplyResponsiveLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rooms: " + ex.Message);
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            List<Sub_RoomInfo> selectedRooms = new List<Sub_RoomInfo>();
            for (int i = 0; i < Sub_RoomInfo.Length; i++)
            {
                if (Sub_RoomInfo[i].checkBox_checker())
                {
                    // Clone the room info into a new control for review
                    Sub_RoomInfo roomClone = new Sub_RoomInfo
                    {
                        RoomName = Sub_RoomInfo[i].RoomName,
                        Breakfast = Sub_RoomInfo[i].Breakfast,
                        Lunch = Sub_RoomInfo[i].Lunch,
                        Dinner = Sub_RoomInfo[i].Dinner,
                        Guest = Sub_RoomInfo[i].Guest,
                        Price = Sub_RoomInfo[i].Price
                    };

                    // Hide the checkbox for confirmation view
                    roomClone.HideCheckBox();

                    selectedRooms.Add(roomClone);
                }
            }

            if (selectedRooms.Count == 0)
            {
                MessageBox.Show("Please select at least one room.");
                return;
            }

            // Pass rooms and hotel name to confirmation panel
            HotelConfirmBook.Instance.SetRoomSelection(selectedRooms, hotelName);
            HotelConfirmBook.Instance.BringToFront();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            flowLayoutPanel_clear();
            Hotel.Instance.BringToFront();
        }

        public void flowLayoutPanel_clear()
        {
            flowLayoutPanel1.Controls.Clear();
        }

        private void ApplyResponsiveLayout()
        {
            int w = ClientSize.Width;
            panel.Width = w;
            lblHotelName.Left = Math.Max(200, (w - lblHotelName.Width) / 2);
            btnBack.Left = Math.Max(0, w - btnBack.Width - 20);
            btnBook.Left = Math.Max(0, btnBack.Left - btnBook.Width - 12);
            ResizeRoomCards();
        }

        private void ResizeRoomCards()
        {
            int cardWidth = Math.Max(698, flowLayoutPanel1.ClientSize.Width - 20);
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Sub_RoomInfo)
                {
                    control.Width = cardWidth;
                }
            }
        }
    }
}
