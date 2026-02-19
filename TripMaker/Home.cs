using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripMaker
{
    public partial class Home : UserControl
    {

        private static Home instance;

        public static Home Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Home();
                }
                return instance;
            }
        }
        public static Home setInstance
        {
            set
            {
                instance = value;
            }

        }

        public Home()
        {
            InitializeComponent();
            Resize += (s, e) => ApplyResponsiveLayout();
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            int w = ClientSize.Width;
            int h = ClientSize.Height;

            label1.Left = Math.Max(0, (w - label1.Width) / 2);
            label1.Top = 62;

            int titleLeft = Math.Max(0, (w - (label2.Width + 20 + label3.Width)) / 2);
            label2.Left = titleLeft;
            label2.Top = 162;
            label3.Left = label2.Right + 20;
            label3.Top = 167;

            int gap = 40;
            pictureBox1.Top = Math.Max(220, h - pictureBox1.Height);
            pictureBox2.Top = pictureBox1.Top;
            pictureBox1.Left = Math.Max(0, (w / 2) - pictureBox1.Width - (gap / 2));
            pictureBox2.Left = Math.Min(Math.Max(0, w - pictureBox2.Width), (w / 2) + (gap / 2));
        }
    }
}
