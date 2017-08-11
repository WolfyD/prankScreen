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

namespace prankScreen
{
	public partial class f_Simple
	{
		public Screen[] screens { get; set; }
		public int mainScreen { get; set; }
		public bool multiScreen { get; set; }
		public Color secondaryScreenColor { get; set; }
		public SimpleScreenType st { get; set; }
		public int func { get; set; }
		f_ScreenForm fsf = new f_ScreenForm();
		int screenIndex = 0;
		List<f_ScreenForm> opened = new List<f_ScreenForm>();

		public string parameter { get; set; }

		public Screen MainScreen = null;
		public List<Screen> secondaryScreens = new List<Screen>();

		public string[] paramModes = new string[] { "28","37","38" };

        public f_Simple()
        {
            InitializeComponent();
        }

        public void evalScreens()
        {
			screenIndex = 0;
			MainScreen = screens[mainScreen];

			

            switch (st)
            {
                case SimpleScreenType.Install_w95:
                    prankScreen.Screens.f_Install_w95 fi95 = new Screens.f_Install_w95();
                    fi95.Bounds = MainScreen.Bounds;
					fi95.stayawakeMode = func;
					fi95.ShowDialog();
                    break;

                case SimpleScreenType.Install_w98:
                    prankScreen.Screens.f_Install_w98 fi98 = new Screens.f_Install_w98();
                    fi98.Bounds = MainScreen.Bounds;
					fi98.stayawakeMode = func;
					fi98.ShowDialog();
                    break;

                case SimpleScreenType.Screen_Unresponsive:
					foreach (Screen s in Screen.AllScreens)
					{
						prankScreen.Screens.f_Screen_Unresponsive sunrep = new Screens.f_Screen_Unresponsive();
						sunrep.multiscreen = true;
						sunrep.Bounds = MainScreen.Bounds;
						sunrep.stayawakeMode = func;
						showScreens(sunrep, s);
						screenIndex++;
					}
					break;

                case SimpleScreenType.Screen_Black:
					foreach (Screen s in Screen.AllScreens)
					{
						prankScreen.Screens.f_Screen_Black sb = new Screens.f_Screen_Black();
						sb.multiscreen = true;
						sb.Bounds = MainScreen.Bounds;
						sb.stayawakeMode = func;
						showScreens(sb, s);
						screenIndex++;
					}
                    break;

				case SimpleScreenType.Firefox_Google:
					prankScreen.Screens.f_Firefox_Google goo = new Screens.f_Firefox_Google();
					goo.Bounds = MainScreen.Bounds;
					goo.stayawakeMode = func;
					goo.param = parameter == "" ? null : parameter;
					goo.ShowDialog();
					break;

				case SimpleScreenType.Firefox_Porn:
					prankScreen.Screens.f_Firefox_Pron prn = new Screens.f_Firefox_Pron();
					prn.Bounds = MainScreen.Bounds;
					prn.stayawakeMode = func;
					prn.param = parameter == "" ? "M" : parameter.ToLower() == "m" ? "M" : "F";
					prn.ShowDialog();
					break;


				case SimpleScreenType.Screen_Pixelated:
					foreach (Screen s in Screen.AllScreens)
					{
						prankScreen.Screens.f_Screen_Blurry blur = new Screens.f_Screen_Blurry();
						blur.multiscreen = true;
						blur.Bounds = s.Bounds;
						blur.stayawakeMode = func;
						blur.param = parameter == "" ? null : parameter;
						showScreens(blur, s);
						screenIndex++;
					}
					break;

            }


			
		}

        f_ScreenForm ffsf = null;

        public void startfsf()
        {
            opened.Add(ffsf);
            ffsf.ShowDialog();
        }

		public void showScreens(f_ScreenForm fsf, Screen s)
		{
            fsf.StartPosition = FormStartPosition.Manual;
            fsf.Left = s.WorkingArea.Left + 10;
            fsf.Bounds = s.Bounds;


			if (screenIndex < Screen.AllScreens.Count() - 1)
			{
                ffsf = fsf;
                Thread t = new Thread(new ThreadStart(startfsf));
                t.Start();
			}
			else
			{
				foreach(f_ScreenForm f in opened)
				{
					fsf.openedscreens.Add(f);
				}

				fsf.ShowDialog();
			}
		}

    }
}
