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
        }
    }
}
