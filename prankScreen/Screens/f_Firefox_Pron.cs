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
	public partial class f_Firefox_Pron : f_ScreenForm
	{
		public string param { get; set; }
		System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

		public f_Firefox_Pron()
		{
			InitializeComponent();

			Load += F_Firefox_Pron_Load;
		}

		private void F_Firefox_Pron_Load(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			t.Interval = 500;

			if(param == "M")
			{
				BackgroundImage = Properties.Resources.pr0n;
			}
			else
			{
				BackgroundImage = Properties.Resources.pr0n2;
			}

			BackgroundImageLayout = ImageLayout.Stretch;

			t.Start();
			t.Tick += T_Tick;
			
		}

		private void T_Tick(object sender, EventArgs e)
		{
			using (Graphics g = Graphics.FromHwnd(this.Handle))
			{
				Brush b = new SolidBrush(Color.FromArgb(120, Color.Gray));
				g.FillRectangle(b, new Rectangle(0, 0, Width, Height));
			}
			t.Stop();
		}

		public override void doBSOD()
		{
			using (Graphics g = Graphics.FromHwnd(this.Handle))
			{
				Image i = Properties.Resources.ffhsw;
				g.DrawImage(i, Width / 2 - i.Width / 2, Height / 3 - i.Height / 2);

				Thread.Sleep(1000);

				Brush b = new SolidBrush(Color.FromArgb(120, Color.Gray));
				g.FillRectangle(b, new Rectangle(Width / 2 - i.Width / 2, Height / 3 - i.Height / 2, i.Width, i.Height));
			}
		}
	}
}
