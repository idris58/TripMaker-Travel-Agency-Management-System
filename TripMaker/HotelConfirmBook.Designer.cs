namespace TripMaker
{
    partial class HotelConfirmBook
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
            this.panel = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.flowLayoutPanelRooms = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.gbPaymentMethods = new System.Windows.Forms.GroupBox();
            this.radioBkash = new System.Windows.Forms.RadioButton();
            this.radioUpay = new System.Windows.Forms.RadioButton();
            this.radioRocket = new System.Windows.Forms.RadioButton();
            this.radioNagod = new System.Windows.Forms.RadioButton();
            this.cmbNumber = new System.Windows.Forms.ComboBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.gbPaymentMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.lblDate);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(701, 40);
            this.panel.TabIndex = 32;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Red;
            this.lblDate.Location = new System.Drawing.Point(252, 7);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(196, 26);
            this.lblDate.TabIndex = 20;
            this.lblDate.Text = "Confirm Payment";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelRooms
            // 
            this.flowLayoutPanelRooms.Location = new System.Drawing.Point(0, 41);
            this.flowLayoutPanelRooms.Name = "flowLayoutPanelRooms";
            this.flowLayoutPanelRooms.Size = new System.Drawing.Size(701, 179);
            this.flowLayoutPanelRooms.TabIndex = 33;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.Location = new System.Drawing.Point(207, 228);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(104, 18);
            this.lblTotalPrice.TabIndex = 34;
            this.lblTotalPrice.Text = "Total Amount: ";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(201, 368);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(73, 35);
            this.btnBack.TabIndex = 59;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // gbPaymentMethods
            // 
            this.gbPaymentMethods.Controls.Add(this.radioBkash);
            this.gbPaymentMethods.Controls.Add(this.radioUpay);
            this.gbPaymentMethods.Controls.Add(this.radioRocket);
            this.gbPaymentMethods.Controls.Add(this.radioNagod);
            this.gbPaymentMethods.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPaymentMethods.Location = new System.Drawing.Point(378, 260);
            this.gbPaymentMethods.Margin = new System.Windows.Forms.Padding(2);
            this.gbPaymentMethods.Name = "gbPaymentMethods";
            this.gbPaymentMethods.Padding = new System.Windows.Forms.Padding(2);
            this.gbPaymentMethods.Size = new System.Drawing.Size(191, 204);
            this.gbPaymentMethods.TabIndex = 63;
            this.gbPaymentMethods.TabStop = false;
            this.gbPaymentMethods.Text = "Payment Methods";
            // 
            // radioBkash
            // 
            this.radioBkash.AutoSize = true;
            this.radioBkash.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.radioBkash.FlatAppearance.BorderSize = 2;
            this.radioBkash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBkash.Location = new System.Drawing.Point(14, 29);
            this.radioBkash.Margin = new System.Windows.Forms.Padding(2);
            this.radioBkash.Name = "radioBkash";
            this.radioBkash.Size = new System.Drawing.Size(77, 24);
            this.radioBkash.TabIndex = 0;
            this.radioBkash.TabStop = true;
            this.radioBkash.Text = "Bkash";
            this.radioBkash.UseVisualStyleBackColor = true;
            // 
            // radioUpay
            // 
            this.radioUpay.AutoSize = true;
            this.radioUpay.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.radioUpay.FlatAppearance.BorderSize = 2;
            this.radioUpay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioUpay.Location = new System.Drawing.Point(14, 158);
            this.radioUpay.Margin = new System.Windows.Forms.Padding(2);
            this.radioUpay.Name = "radioUpay";
            this.radioUpay.Size = new System.Drawing.Size(68, 24);
            this.radioUpay.TabIndex = 3;
            this.radioUpay.TabStop = true;
            this.radioUpay.Text = "Upay";
            this.radioUpay.UseVisualStyleBackColor = true;
            // 
            // radioRocket
            // 
            this.radioRocket.AutoSize = true;
            this.radioRocket.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.radioRocket.FlatAppearance.BorderSize = 2;
            this.radioRocket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioRocket.Location = new System.Drawing.Point(14, 72);
            this.radioRocket.Margin = new System.Windows.Forms.Padding(2);
            this.radioRocket.Name = "radioRocket";
            this.radioRocket.Size = new System.Drawing.Size(84, 24);
            this.radioRocket.TabIndex = 1;
            this.radioRocket.TabStop = true;
            this.radioRocket.Text = "Rocket";
            this.radioRocket.UseVisualStyleBackColor = true;
            // 
            // radioNagod
            // 
            this.radioNagod.AutoSize = true;
            this.radioNagod.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.radioNagod.FlatAppearance.BorderSize = 2;
            this.radioNagod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioNagod.Location = new System.Drawing.Point(14, 115);
            this.radioNagod.Margin = new System.Windows.Forms.Padding(2);
            this.radioNagod.Name = "radioNagod";
            this.radioNagod.Size = new System.Drawing.Size(79, 24);
            this.radioNagod.TabIndex = 2;
            this.radioNagod.TabStop = true;
            this.radioNagod.Text = "Nagod";
            this.radioNagod.UseVisualStyleBackColor = true;
            // 
            // cmbNumber
            // 
            this.cmbNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNumber.FormattingEnabled = true;
            this.cmbNumber.Items.AddRange(new object[] {
            "01791642895",
            "01864592680",
            "01758899168"});
            this.cmbNumber.Location = new System.Drawing.Point(203, 285);
            this.cmbNumber.Margin = new System.Windows.Forms.Padding(2);
            this.cmbNumber.Name = "cmbNumber";
            this.cmbNumber.Size = new System.Drawing.Size(152, 26);
            this.cmbNumber.TabIndex = 62;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(282, 368);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(79, 35);
            this.btnConfirm.TabIndex = 60;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(207, 260);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 20);
            this.label4.TabIndex = 61;
            this.label4.Text = "Select Number";
            // 
            // HotelConfirmBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.gbPaymentMethods);
            this.Controls.Add(this.cmbNumber);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.flowLayoutPanelRooms);
            this.Controls.Add(this.panel);
            this.Name = "HotelConfirmBook";
            this.Size = new System.Drawing.Size(701, 471);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.gbPaymentMethods.ResumeLayout(false);
            this.gbPaymentMethods.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRooms;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox gbPaymentMethods;
        private System.Windows.Forms.RadioButton radioBkash;
        private System.Windows.Forms.RadioButton radioUpay;
        private System.Windows.Forms.RadioButton radioRocket;
        private System.Windows.Forms.RadioButton radioNagod;
        private System.Windows.Forms.ComboBox cmbNumber;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label4;
    }
}
