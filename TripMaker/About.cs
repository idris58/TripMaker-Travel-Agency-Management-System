using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripMaker
{
    public partial class About: UserControl
    {

        private static About instance;
        public static About Instance => instance ?? (instance = new About());
        public About()
        {
            InitializeComponent();
            Resize += (s, e) => ApplyResponsiveLayout();
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            int w = ClientSize.Width;

            label1.Left = Math.Max(0, (w - label1.Width) / 2);
            label4.Left = Math.Max(0, (w - label4.Width) / 2);
            label5.Left = Math.Max(0, (w - label5.Width) / 2);
            label2.Left = Math.Max(0, (w - label2.Width) / 2);
            label3.Left = Math.Max(0, (w - label3.Width) / 2);
            label6.Left = Math.Max(0, (w - label6.Width) / 2);
        }
    }
}
