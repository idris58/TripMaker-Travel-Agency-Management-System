
namespace TripMaker
{
    partial class Flight
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
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtbjourney = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFromAirport = new System.Windows.Forms.ComboBox();
            this.cbToAirport = new System.Windows.Forms.ComboBox();
            this.DateLbl = new System.Windows.Forms.Label();
            this.flowFlightPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(233, 104);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 22);
            this.label4.TabIndex = 18;
            this.label4.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "Available Flights";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.label1);
            this.panel.Location = new System.Drawing.Point(2, 179);
            this.panel.Margin = new System.Windows.Forms.Padding(2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(699, 39);
            this.panel.TabIndex = 27;
            this.panel.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(577, 147);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 27);
            this.btnSearch.TabIndex = 26;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtbjourney
            // 
            this.dtbjourney.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtbjourney.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtbjourney.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtbjourney.Location = new System.Drawing.Point(462, 106);
            this.dtbjourney.Name = "dtbjourney";
            this.dtbjourney.Size = new System.Drawing.Size(123, 23);
            this.dtbjourney.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(326, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 21);
            this.label5.TabIndex = 20;
            this.label5.Text = "Flight";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 23);
            this.label3.TabIndex = 15;
            this.label3.Text = "Choose Airports";
            // 
            // cbFromAirport
            // 
            this.cbFromAirport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbFromAirport.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFromAirport.FormattingEnabled = true;
            this.cbFromAirport.Items.AddRange(new object[] {
            "Chittagong Airport",
            "Cumilla Airport",
            "Dhaka Airport"});
            this.cbFromAirport.Location = new System.Drawing.Point(82, 108);
            this.cbFromAirport.Margin = new System.Windows.Forms.Padding(2);
            this.cbFromAirport.Name = "cbFromAirport";
            this.cbFromAirport.Size = new System.Drawing.Size(128, 28);
            this.cbFromAirport.Sorted = true;
            this.cbFromAirport.TabIndex = 16;
            // 
            // cbToAirport
            // 
            this.cbToAirport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbToAirport.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbToAirport.FormattingEnabled = true;
            this.cbToAirport.Items.AddRange(new object[] {
            "Dhaka Airport",
            "Cumilla Airport",
            "Chittagong Airport"});
            this.cbToAirport.Location = new System.Drawing.Point(277, 108);
            this.cbToAirport.Margin = new System.Windows.Forms.Padding(2);
            this.cbToAirport.Name = "cbToAirport";
            this.cbToAirport.Size = new System.Drawing.Size(128, 28);
            this.cbToAirport.TabIndex = 17;
            // 
            // DateLbl
            // 
            this.DateLbl.AutoSize = true;
            this.DateLbl.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLbl.Location = new System.Drawing.Point(459, 71);
            this.DateLbl.Name = "DateLbl";
            this.DateLbl.Size = new System.Drawing.Size(43, 18);
            this.DateLbl.TabIndex = 23;
            this.DateLbl.Text = "Date";
            // 
            // flowFlightPanel
            // 
            this.flowFlightPanel.AutoScroll = true;
            this.flowFlightPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowFlightPanel.Location = new System.Drawing.Point(0, 223);
            this.flowFlightPanel.Name = "flowFlightPanel";
            this.flowFlightPanel.Size = new System.Drawing.Size(701, 315);
            this.flowFlightPanel.TabIndex = 32;
            // 
            // Flight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowFlightPanel);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtbjourney);
            this.Controls.Add(this.DateLbl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbToAirport);
            this.Controls.Add(this.cbFromAirport);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Flight";
            this.Size = new System.Drawing.Size(701, 538);
            this.Load += new System.EventHandler(this.Flight_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtbjourney;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFromAirport;
        private System.Windows.Forms.ComboBox cbToAirport;
        private System.Windows.Forms.Label DateLbl;
        private System.Windows.Forms.FlowLayoutPanel flowFlightPanel;
    }
}
