namespace TripMaker
{
    partial class BookingCard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBookingId = new System.Windows.Forms.Label();
            this.lblBookingDate = new System.Windows.Forms.Label();
            this.lblBookingType = new System.Windows.Forms.Label();
            this.panelTransport = new System.Windows.Forms.Panel();
            this.lblTransportName = new System.Windows.Forms.Label();
            this.lblSeatNumber = new System.Windows.Forms.Label();
            this.lblDeparture = new System.Windows.Forms.Label();
            this.lblArrival = new System.Windows.Forms.Label();
            this.lblTransportPrice = new System.Windows.Forms.Label();
            this.panelHotel = new System.Windows.Forms.Panel();
            this.lblHotelPrice = new System.Windows.Forms.Label();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.lblHotelName = new System.Windows.Forms.Label();
            this.panelActivity = new System.Windows.Forms.Panel();
            this.lblActivityPrice = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblActivityName = new System.Windows.Forms.Label();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.panelTransport.SuspendLayout();
            this.panelHotel.SuspendLayout();
            this.panelActivity.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBookingId
            // 
            this.lblBookingId.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBookingId.AutoSize = true;
            this.lblBookingId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingId.Location = new System.Drawing.Point(47, 24);
            this.lblBookingId.Name = "lblBookingId";
            this.lblBookingId.Size = new System.Drawing.Size(115, 16);
            this.lblBookingId.TabIndex = 0;
            this.lblBookingId.Text = "Booking ID: 102";
            // 
            // lblBookingDate
            // 
            this.lblBookingDate.AutoSize = true;
            this.lblBookingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingDate.Location = new System.Drawing.Point(227, 24);
            this.lblBookingDate.Name = "lblBookingDate";
            this.lblBookingDate.Size = new System.Drawing.Size(122, 16);
            this.lblBookingDate.TabIndex = 1;
            this.lblBookingDate.Text = "Date: 2025-06-28";
            // 
            // lblBookingType
            // 
            this.lblBookingType.AutoSize = true;
            this.lblBookingType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingType.Location = new System.Drawing.Point(382, 24);
            this.lblBookingType.Name = "lblBookingType";
            this.lblBookingType.Size = new System.Drawing.Size(77, 16);
            this.lblBookingType.TabIndex = 2;
            this.lblBookingType.Text = "Type: Bus";
            // 
            // panelTransport
            // 
            this.panelTransport.AutoSize = true;
            this.panelTransport.Controls.Add(this.lblTransportPrice);
            this.panelTransport.Controls.Add(this.lblArrival);
            this.panelTransport.Controls.Add(this.lblDeparture);
            this.panelTransport.Controls.Add(this.lblSeatNumber);
            this.panelTransport.Controls.Add(this.lblTransportName);
            this.panelTransport.Location = new System.Drawing.Point(82, 52);
            this.panelTransport.Name = "panelTransport";
            this.panelTransport.Padding = new System.Windows.Forms.Padding(2);
            this.panelTransport.Size = new System.Drawing.Size(436, 145);
            this.panelTransport.TabIndex = 3;
            this.panelTransport.Visible = false;
            // 
            // lblTransportName
            // 
            this.lblTransportName.AutoSize = true;
            this.lblTransportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransportName.Location = new System.Drawing.Point(36, 17);
            this.lblTransportName.Name = "lblTransportName";
            this.lblTransportName.Size = new System.Drawing.Size(116, 18);
            this.lblTransportName.TabIndex = 0;
            this.lblTransportName.Text = "TransportName ";
            // 
            // lblSeatNumber
            // 
            this.lblSeatNumber.AutoSize = true;
            this.lblSeatNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeatNumber.Location = new System.Drawing.Point(36, 49);
            this.lblSeatNumber.Name = "lblSeatNumber";
            this.lblSeatNumber.Size = new System.Drawing.Size(38, 18);
            this.lblSeatNumber.TabIndex = 1;
            this.lblSeatNumber.Text = "Seat";
            // 
            // lblDeparture
            // 
            this.lblDeparture.AutoSize = true;
            this.lblDeparture.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeparture.Location = new System.Drawing.Point(36, 91);
            this.lblDeparture.Name = "lblDeparture";
            this.lblDeparture.Size = new System.Drawing.Size(73, 18);
            this.lblDeparture.TabIndex = 3;
            this.lblDeparture.Text = "Departure";
            // 
            // lblArrival
            // 
            this.lblArrival.AutoSize = true;
            this.lblArrival.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrival.Location = new System.Drawing.Point(178, 91);
            this.lblArrival.Name = "lblArrival";
            this.lblArrival.Size = new System.Drawing.Size(48, 18);
            this.lblArrival.TabIndex = 4;
            this.lblArrival.Text = "Arrival";
            // 
            // lblTransportPrice
            // 
            this.lblTransportPrice.AutoSize = true;
            this.lblTransportPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransportPrice.Location = new System.Drawing.Point(178, 49);
            this.lblTransportPrice.Name = "lblTransportPrice";
            this.lblTransportPrice.Size = new System.Drawing.Size(42, 18);
            this.lblTransportPrice.TabIndex = 5;
            this.lblTransportPrice.Text = "Price";
            // 
            // panelHotel
            // 
            this.panelHotel.AutoSize = true;
            this.panelHotel.Controls.Add(this.lblCheckOut);
            this.panelHotel.Controls.Add(this.lblHotelPrice);
            this.panelHotel.Controls.Add(this.lblCheckIn);
            this.panelHotel.Controls.Add(this.lblRoomType);
            this.panelHotel.Controls.Add(this.lblHotelName);
            this.panelHotel.Location = new System.Drawing.Point(82, 52);
            this.panelHotel.Name = "panelHotel";
            this.panelHotel.Padding = new System.Windows.Forms.Padding(2);
            this.panelHotel.Size = new System.Drawing.Size(436, 145);
            this.panelHotel.TabIndex = 4;
            this.panelHotel.Visible = false;
            // 
            // lblHotelPrice
            // 
            this.lblHotelPrice.AutoSize = true;
            this.lblHotelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHotelPrice.Location = new System.Drawing.Point(178, 49);
            this.lblHotelPrice.Name = "lblHotelPrice";
            this.lblHotelPrice.Size = new System.Drawing.Size(42, 18);
            this.lblHotelPrice.TabIndex = 5;
            this.lblHotelPrice.Text = "Price";
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckIn.Location = new System.Drawing.Point(36, 91);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(120, 18);
            this.lblCheckIn.TabIndex = 3;
            this.lblCheckIn.Text = "Check-in: 25-Jun";
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomType.Location = new System.Drawing.Point(36, 49);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(38, 18);
            this.lblRoomType.TabIndex = 1;
            this.lblRoomType.Text = "Seat";
            // 
            // lblHotelName
            // 
            this.lblHotelName.AutoSize = true;
            this.lblHotelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHotelName.Location = new System.Drawing.Point(36, 17);
            this.lblHotelName.Name = "lblHotelName";
            this.lblHotelName.Size = new System.Drawing.Size(112, 18);
            this.lblHotelName.TabIndex = 0;
            this.lblHotelName.Text = "Hotel: Sea View";
            // 
            // panelActivity
            // 
            this.panelActivity.AutoSize = true;
            this.panelActivity.Controls.Add(this.lblActivityPrice);
            this.panelActivity.Controls.Add(this.lblLocation);
            this.panelActivity.Controls.Add(this.lblActivityName);
            this.panelActivity.Location = new System.Drawing.Point(82, 52);
            this.panelActivity.Name = "panelActivity";
            this.panelActivity.Padding = new System.Windows.Forms.Padding(2);
            this.panelActivity.Size = new System.Drawing.Size(436, 145);
            this.panelActivity.TabIndex = 6;
            this.panelActivity.Visible = false;
            // 
            // lblActivityPrice
            // 
            this.lblActivityPrice.AutoSize = true;
            this.lblActivityPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActivityPrice.Location = new System.Drawing.Point(36, 89);
            this.lblActivityPrice.Name = "lblActivityPrice";
            this.lblActivityPrice.Size = new System.Drawing.Size(66, 18);
            this.lblActivityPrice.TabIndex = 5;
            this.lblActivityPrice.Text = "700 BDT";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(36, 54);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(144, 18);
            this.lblLocation.TabIndex = 1;
            this.lblLocation.Text = "Location: Bandarban";
            // 
            // lblActivityName
            // 
            this.lblActivityName.AutoSize = true;
            this.lblActivityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActivityName.Location = new System.Drawing.Point(36, 17);
            this.lblActivityName.Name = "lblActivityName";
            this.lblActivityName.Size = new System.Drawing.Size(143, 18);
            this.lblActivityName.TabIndex = 0;
            this.lblActivityName.Text = "Activity: Water Safari";
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckOut.Location = new System.Drawing.Point(178, 89);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(130, 18);
            this.lblCheckOut.TabIndex = 6;
            this.lblCheckOut.Text = "Check-out: 27-Jun";
            // 
            // BookingCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblBookingType);
            this.Controls.Add(this.lblBookingDate);
            this.Controls.Add(this.lblBookingId);
            this.Controls.Add(this.panelActivity);
            this.Controls.Add(this.panelTransport);
            this.Controls.Add(this.panelHotel);
            this.Name = "BookingCard";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(701, 196);
            this.panelTransport.ResumeLayout(false);
            this.panelTransport.PerformLayout();
            this.panelHotel.ResumeLayout(false);
            this.panelHotel.PerformLayout();
            this.panelActivity.ResumeLayout(false);
            this.panelActivity.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBookingId;
        private System.Windows.Forms.Label lblBookingDate;
        private System.Windows.Forms.Label lblBookingType;
        private System.Windows.Forms.Panel panelTransport;
        private System.Windows.Forms.Label lblTransportPrice;
        private System.Windows.Forms.Label lblArrival;
        private System.Windows.Forms.Label lblDeparture;
        private System.Windows.Forms.Label lblSeatNumber;
        private System.Windows.Forms.Label lblTransportName;
        private System.Windows.Forms.Panel panelHotel;
        private System.Windows.Forms.Label lblHotelPrice;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.Label lblHotelName;
        private System.Windows.Forms.Panel panelActivity;
        private System.Windows.Forms.Label lblActivityPrice;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblActivityName;
        private System.Windows.Forms.Label lblCheckOut;
    }
}
