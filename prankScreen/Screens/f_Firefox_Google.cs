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
	public partial class f_Firefox_Google : f_ScreenForm
	{
		public string param { get; set; }

		double pLeft = 35.67708333d;
		double pTop = 30.20559259d;

		Brush b = new SolidBrush(Color.FromArgb(120, Color.Gray));
		System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

		public f_Firefox_Google()
		{
			InitializeComponent();
			Load += F_Firefox_Google_Load;
		}

		private void F_Firefox_Google_Load(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			if(param == null)
			{
				param = "How do I tell my family that I am a Brony";
			}

			t.Interval = 1000;
			t.Start();
			t.Tick += T_Tick;
		}

		public override void doBSOD()
		{
			using (Graphics g = Graphics.FromHwnd(this.Handle))
			{
				Image i = Properties.Resources.ffhsw;
				g.DrawImage(i, Width / 2 - i.Width / 2, Height / 3 - i.Height / 2);

				Thread.Sleep(1000);

				g.FillRectangle(b, new Rectangle(Width / 2 - i.Width / 2, Height / 3 - i.Height / 2, i.Width, i.Height));
			}
		}

		private void T_Tick(object sender, EventArgs e)
		{
			using (Graphics g = Graphics.FromHwnd(this.Handle))
			{
				Font f = new Font("Arial", 16, FontStyle.Regular);

				if(Width < 1280 || Height < 1024)
				{
					f = new Font(f.FontFamily, 12, f.Style);
				}

				int ll = (int)(((this.Width * 1.0d) / 100.0d) * pLeft);
				int tt = (int)(((this.Height * 1.0d) / 100.0d) * pTop);

				g.DrawString(param, f, Brushes.Black, new Point(ll, tt));

				

				g.FillRectangle(b, new Rectangle(0,0,Width,Height));
				t.Stop();
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			/*
			using (Graphics g = Graphics.FromHwnd(this.Handle))
			{
				Brush b = new SolidBrush(Color.FromArgb(150, Color.Gray));

				g.FillRectangle(b, this.Bounds);

			}
			*/

			base.OnPaint(e);
			
		}

	}
}
