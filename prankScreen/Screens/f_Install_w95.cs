using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prankScreen.Screens
{
    public partial class f_Install_w95 : f_ScreenForm
    {
        int incrementSeconds = 1;
        int seconds = 0;
        int seconds2 = 0;
        int onepercent = 0;
        int percentile = 0;
        int maxpercent = 0;
        int slide = 1;

        String[] titles = new String[]{
            "Welcome",
            "Easier to use",
            "Get more done",
            "More powerful",
            "Have more fun",
            "It's more accessible",
            "Plug and Play",
            "Take it on the road",
            "Communicate with anyone",
            "The Microsoft Network",
            "Register now",
            "Getting started"
        };

        bool run = true;

        public f_Install_w95()
        {
            InitializeComponent();

            Load += F_Install_w95_Load;
        }

        private void F_Install_w95_Load(object sender, EventArgs e)
        {
            Cursor = new Cursor(Properties.Resources.win98Cursor.GetHicon());
            maxpercent = new Random().Next(30, 48);
            lbl_Prog.Select();
            lbl_Prog.Focus();
        }

        private void panel2_SizeChanged(object sender, EventArgs e)
        {
            p_Banner.Width = (int)(((panel3.Width * 1.0f) / 100.0f) * 28.6f);
        }

        public void incrementPercent()
        {
            onepercent = percentile % 2 == 0 ? ((int)Math.Ceiling(((p_Prog0.Width * 1.0f) / 100f) * 1)) : ((int)Math.Floor(((p_Prog0.Width * 1.0f) / 100f) * 1));

            incrementSeconds = new Random().Next(1, 5);
            seconds = 0;
            p_Prog1.Width += onepercent;
            percentile++;
            lbl_Prog.Text = percentile + "%";

            if(percentile == maxpercent)
            {
                run = false;
            }
        }

        public void changeScreen()
        {
            slide++;
            if(slide > 12) { slide = 1; }

            lbl_Title.Text = titles[slide - 1];

            switch (slide)
            {
                case 1:
                    p_Banner.BackgroundImage = Properties.Resources.win95Banner;
                    p_Screen.BackgroundImage = Properties.Resources.w95_Install01;
                    break;

                case 2:
                    p_Banner.BackgroundImage = Properties.Resources.win95_Banner2;
                    p_Screen.BackgroundImage = Properties.Resources.w95_Install02;
                    break;

                case 3:
                    p_Banner.BackgroundImage = Properties.Resources.win95_Banner3;
                    p_Screen.BackgroundImage = Properties.Resources.w95_Install03;
                    break;

                case 4:
                    p_Banner.BackgroundImage = Properties.Resources.win95_Banner4;
                    p_Screen.BackgroundImage = Properties.Resources.w95_Install04;
                    break;

                case 5:
                    p_Banner.BackgroundImage = Properties.Resources.win95_Banner5;
                    p_Screen.BackgroundImage = Properties.Resources.w95_Install05;
                    break;

                case 6:
                    p_Banner.BackgroundImage = Properties.Resources.win95_Banner6;
                    p_Screen.BackgroundImage = Properties.Resources.w95_Install06;
                    break;

                case 7:
                    p_Banner.BackgroundImage = Properties.Resources.win95_Banner7;
                    p_Screen.BackgroundImage = Properties.Resources.w95_Install07;
                    break;

                case 8:
                    p_Banner.BackgroundImage = Properties.Resources.win95_Banner8;
                    p_Screen.BackgroundImage = Properties.Resources.w95_Install08;
                    break;

                case 9:
                    p_Banner.BackgroundImage = Properties.Resources.win95_Banner9;
                    p_Screen.BackgroundImage = Properties.Resources.w95_Install09;
                    break;

                case 10:
                    p_Banner.BackgroundImage = Properties.Resources.win95_Banner10;
                    p_Screen.BackgroundImage = Properties.Resources.w95_Install10;
                    break;

                case 11:
                    p_Banner.BackgroundImage = Properties.Resources.win95_Banner11;
                    p_Screen.BackgroundImage = Properties.Resources.w95_Install11;
                    break;

                case 12:
                    p_Banner.BackgroundImage = Properties.Resources.win95_Banner12;
                    p_Screen.BackgroundImage = Properties.Resources.w95_Install12;
                    break;
            }
        }

        public override void doBSOD()
        {
            Bitmap img = (Bitmap)Properties.Resources.cursor;
            Cursor c = new Cursor(img.GetHicon());
            this.Cursor = c;
            Thread.Sleep(5000);
            panel1.Hide();
            panel7.Hide();
            label1.Hide();
            this.BackColor = Color.FromArgb(255, 0, 0, 170);
            this.BackgroundImage = Properties.Resources.win95BSOD;
            BackgroundImageLayout = ImageLayout.None;
            this.Cursor.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (run)
            {
                if (seconds == incrementSeconds)
                {
                    incrementPercent();
                }
                seconds++;
            }

            if(seconds2 % 10 == 0 && seconds2 != 0)
            {
                changeScreen();
            }

            seconds2++;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            doBSOD();
        }
    }
}
