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
	public partial class f_Screen_Blurry : f_ScreenForm
	{
		Bitmap bmp = null;
		int pixelSize = 3;
		public string param { get; set; }

		public f_Screen_Blurry()
		{
			InitializeComponent();

			Load += F_Screen_Blurry_Load;
		}

		private void F_Screen_Blurry_Load(object sender, EventArgs e)
		{
			Cursor = new Cursor(Properties.Resources.blurryCursor.GetHicon());

			if(param != null)
			{
				int i = 0;
				Int32.TryParse(param, out i);
				if(i > 0)
				{
					pixelSize = i;
				}
			}

			getNewImg();
		}

		public void getNewImg()
		{
			bmp = new Bitmap(Width, Height);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				Hide();
				g.CopyFromScreen(new Point(0, 0), new Point(0, 0), bmp.Size, CopyPixelOperation.SourceCopy);
				Show();
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			Bitmap bmp2 = new Bitmap(Width, Height);

			//using (Graphics g = Graphics.FromHwnd(this.Handle))
			using (Graphics g = Graphics.FromImage(bmp2))
			{
				for (int x = (int)Math.Ceiling((double)pixelSize / 2); x < bmp.Width; x += pixelSize)
				{
					for (int y = (int)Math.Ceiling((double)pixelSize / 2); y < bmp.Height; y += pixelSize)
					{
						try
						{
							Brush b = new SolidBrush(Color.FromArgb(255, bmp.GetPixel(x, y)));
							g.FillRectangle(b, new Rectangle(new Point(x - (int)Math.Ceiling((double)pixelSize / 2), y - (int)Math.Ceiling((double)pixelSize / 2)), new Size(pixelSize, pixelSize)));
						}
						catch
						{

						}
					}
				}

				this.BackgroundImage = bmp2;
			}
		}
	}
}
