using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prankScreen
{
    public partial class f_secondaryScreen : f_ScreenForm
    {
        public Color bgColor { get; set; }

        public f_secondaryScreen()
        {
            InitializeComponent();

            Load += F_secondaryScreen_Load;
        }

        private void F_secondaryScreen_Load(object sender, EventArgs e)
        {
            BackColor = bgColor;
        }
    }
}
