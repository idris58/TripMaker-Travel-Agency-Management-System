namespace TripMaker
{
    partial class ActivityBooking
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
            this.btnbook = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.loc = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbResturant = new System.Windows.Forms.PictureBox();
            this.co = new System.Windows.Forms.Label();
            this.pbSports = new System.Windows.Forms.PictureBox();
            this.pbOthers = new System.Windows.Forms.PictureBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbResturant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOthers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnbook
            // 
            this.btnbook.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnbook.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnbook.Location = new System.Drawing.Point(535, 113);
            this.btnbook.Margin = new System.Windows.Forms.Padding(2);
            this.btnbook.Name = "btnbook";
            this.btnbook.Size = new System.Drawing.Size(68, 24);
            this.btnbook.TabIndex = 87;
            this.btnbook.Text = "Book Now";
            this.btnbook.UseVisualStyleBackColor = false;
            this.btnbook.Click += new System.EventHandler(this.btnbook_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Century Gothic", 10.5F);
            this.lblPrice.ForeColor = System.Drawing.Color.Black;
            this.lblPrice.Location = new System.Drawing.Point(409, 103);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(33, 19);
            this.lblPrice.TabIndex = 86;
            this.lblPrice.Text = "350";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.ForeColor = System.Drawing.Color.Black;
            this.lblLocation.Location = new System.Drawing.Point(409, 58);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(67, 19);
            this.lblLocation.TabIndex = 82;
            this.lblLocation.Text = "Rajshahi";
            // 
            // loc
            // 
            this.loc.AutoSize = true;
            this.loc.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loc.ForeColor = System.Drawing.Color.Black;
            this.loc.Location = new System.Drawing.Point(314, 58);
            this.loc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.loc.Name = "loc";
            this.loc.Size = new System.Drawing.Size(74, 17);
            this.loc.TabIndex = 81;
            this.loc.Text = "Location :";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblName.ForeColor = System.Drawing.Color.Red;
            this.LblName.Location = new System.Drawing.Point(368, 20);
            this.LblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(72, 23);
            this.LblName.TabIndex = 79;
            this.LblName.Text = "Dine In";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.ForeColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(63, 161);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 4);
            this.panel1.TabIndex = 78;
            // 
            // pbResturant
            // 
            this.pbResturant.Image = global::TripMaker.Properties.Resources.Resturant;
            this.pbResturant.Location = new System.Drawing.Point(15, 11);
            this.pbResturant.Margin = new System.Windows.Forms.Padding(2);
            this.pbResturant.Name = "pbResturant";
            this.pbResturant.Size = new System.Drawing.Size(158, 137);
            this.pbResturant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbResturant.TabIndex = 91;
            this.pbResturant.TabStop = false;
            // 
            // co
            // 
            this.co.AutoSize = true;
            this.co.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.co.ForeColor = System.Drawing.Color.Black;
            this.co.Location = new System.Drawing.Point(342, 103);
            this.co.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.co.Name = "co";
            this.co.Size = new System.Drawing.Size(46, 17);
            this.co.TabIndex = 89;
            this.co.Text = "Cost :";
            // 
            // pbSports
            // 
            this.pbSports.Image = global::TripMaker.Properties.Resources.Sports;
            this.pbSports.Location = new System.Drawing.Point(15, 11);
            this.pbSports.Margin = new System.Windows.Forms.Padding(2);
            this.pbSports.Name = "pbSports";
            this.pbSports.Size = new System.Drawing.Size(158, 137);
            this.pbSports.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSports.TabIndex = 92;
            this.pbSports.TabStop = false;
            // 
            // pbOthers
            // 
            this.pbOthers.Image = global::TripMaker.Properties.Resources.Others;
            this.pbOthers.Location = new System.Drawing.Point(15, 11);
            this.pbOthers.Margin = new System.Windows.Forms.Padding(2);
            this.pbOthers.Name = "pbOthers";
            this.pbOthers.Size = new System.Drawing.Size(158, 137);
            this.pbOthers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOthers.TabIndex = 93;
            this.pbOthers.TabStop = false;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.ForeColor = System.Drawing.Color.Black;
            this.lblCategory.Location = new System.Drawing.Point(408, 80);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(74, 19);
            this.lblCategory.TabIndex = 95;
            this.lblCategory.Text = "Resturant";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(313, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 94;
            this.label2.Text = "Category :";
            // 
            // ActivityBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbResturant);
            this.Controls.Add(this.co);
            this.Controls.Add(this.btnbook);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.loc);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbOthers);
            this.Controls.Add(this.pbSports);
            this.Name = "ActivityBooking";
            this.Size = new System.Drawing.Size(674, 171);
            ((System.ComponentModel.ISupportInitialize)(this.pbResturant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOthers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnbook;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label loc;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbResturant;
        private System.Windows.Forms.Label co;
        private System.Windows.Forms.PictureBox pbSports;
        private System.Windows.Forms.PictureBox pbOthers;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label label2;
    }
}
