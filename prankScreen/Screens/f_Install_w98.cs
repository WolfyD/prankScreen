using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prankScreen.Screens
{
    public partial class f_Install_w98 : f_ScreenForm
    {
        int incrementSeconds = 1;
        int seconds = 0;
        int seconds2 = 0;
        double onepercent = 0d;
        int percentile = 0;
        int maxpercent = 0;
        int slide = 0;
        int progWidth = 0;
        bool run = true;
        List<String> slides = new List<string>();

        public f_Install_w98()
        {
            InitializeComponent();

            Load += F_Install_w98_Load;

            String slid = Properties.Resources.win98Slides;
            slid = slid.Replace("--LINE--", "•");
            foreach(String s in slid.Split('•'))
            {
                slides.Add(s);
            }
        }

        private void F_Install_w98_Load(object sender, EventArgs e)
        {
            Cursor = new Cursor(Properties.Resources.win98Cursor.GetHicon());
            maxpercent = new Random().Next(60, 73);
            incrementProgress();
        }

        public void incrementProgress()
        {
            seconds = 0;
            incrementSeconds = new Random().Next(1, 5);
            percentile++;

            onepercent = (116.0d / 100.0d);

            progWidth = percentile % 2 == 0 ? (int)Math.Floor(onepercent * percentile) : (int)Math.Ceiling(onepercent * percentile);
            
            drawProgress();

            if(percentile == maxpercent) { run = false; }
        }

        public void drawProgress()
        {
            Bitmap bmp = new Bitmap(p_Progress.Width, p_Progress.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                Font f = new Font("Arial", 10, FontStyle.Bold);
                g.FillRectangle(Brushes.Blue, new Rectangle(0, 0, progWidth, 17));
                int stringwidth = (TextRenderer.MeasureText(percentile + "%", f).Width);
                int stringleft = 57 - stringwidth / 2;
                int stringright = stringleft + stringwidth;
                g.DrawString(percentile + "%", f, Brushes.Black, stringleft, 1);

                for(int i = 0; i < stringwidth; i++)
                {
                    int l = stringleft + i;
                    if(progWidth > l)
                    {
                        for (int y = 0; y < p_Progress.Height; y++)
                        {
                            Color c = bmp.GetPixel(l, y);
                            if (c.R < 150 && c.G < 150 && c.B < 150)
                            {
                                bmp.SetPixel(l, y, Color.White);
                            }
                        }
                    }
                }

                p_Progress.BackgroundImage = bmp;
            }
        }

        public void changeScreen()
        {
            slide++;
            if(slide > slides.Count - 1) { slide = 0; }

            string title = "";
            string text = "";

            string t = slides[slide - 1];
            t = t.Replace("[T]", "").Replace("[/T]", "|");
            title = t.Split('|')[0];
            title = title.Trim();
            text = t.Split('|')[1];
            text = text.Replace("[RN]", "\r\n\r\n");
            text = text.Trim();

            lbl_Title.Text = title;
            lbl_Text.Text = text;
        }

        private void t_Progress_Tick(object sender, EventArgs e)
        {
            if (run)
            {
                if (seconds == incrementSeconds)
                {
                    incrementProgress();
                }
                seconds++;
            }

            if (seconds2 % 10 == 0)
            {
                changeScreen();
            }

            seconds2++;
            
        }

        private void f_Install_w98_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Hide();
        }

        private void f_Install_w98_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Show();
        }
    }
}
