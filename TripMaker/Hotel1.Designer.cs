﻿
namespace TripMaker
{
    partial class Hotel
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDestination = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(596, 98);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 27);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(544, 62);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(123, 23);
            this.dateTimePicker2.TabIndex = 23;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(325, 62);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(123, 23);
            this.dateTimePicker1.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(540, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 18);
            this.label5.TabIndex = 21;
            this.label5.Text = "Check Out";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(322, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 18);
            this.label4.TabIndex = 20;
            this.label4.Text = "Check In";
            // 
            // cmbDestination
            // 
            this.cmbDestination.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDestination.FormattingEnabled = true;
            this.cmbDestination.Location = new System.Drawing.Point(36, 63);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.Size = new System.Drawing.Size(138, 28);
            this.cmbDestination.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "Choose destination";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 167);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(701, 371);
            this.flowLayoutPanel1.TabIndex = 26;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.label3);
            this.panel.Location = new System.Drawing.Point(1, 130);
            this.panel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(699, 39);
            this.panel.TabIndex = 0;
            this.panel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "Available hotels";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Hotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDestination);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Hotel";
            this.Size = new System.Drawing.Size(701, 538);
            this.Load += new System.EventHandler(this.Hotel_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDestination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label3;
    }
}
