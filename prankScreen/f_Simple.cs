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
	public partial class f_Simple
	{
		public Screen[] screens { get; set; }
		public int mainScreen { get; set; }
		public bool multiScreen { get; set; }
		public Color secondaryScreenColor { get; set; }
		public SimpleScreenType st { get; set; }
		public int func { get; set; }
		f_ScreenForm fsf = new f_ScreenForm();

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
            MainScreen = screens[mainScreen];

			

            switch (st)
            {
                case SimpleScreenType.Install_w95:
                    prankScreen.Screens.f_Install_w95 fi95 = new Screens.f_Install_w95();
                    fi95.bounds = MainScreen.Bounds;
					fi95.stayawakeMode = func;
					fi95.ShowDialog();
                    break;

                case SimpleScreenType.Install_w98:
                    prankScreen.Screens.f_Install_w98 fi98 = new Screens.f_Install_w98();
                    fi98.bounds = MainScreen.Bounds;
					fi98.stayawakeMode = func;
					fi98.ShowDialog();
                    break;

                case SimpleScreenType.Screen_Unresponsive:
					foreach (Screen s in Screen.AllScreens)
					{
						prankScreen.Screens.f_Screen_Unresponsive sunrep = new Screens.f_Screen_Unresponsive();
						sunrep.bounds = MainScreen.Bounds;
						sunrep.stayawakeMode = func;
						showScreens(sunrep, s);
					}
					break;

                case SimpleScreenType.Screen_Black:
					foreach (Screen s in Screen.AllScreens)
					{
						prankScreen.Screens.f_Screen_Black sb = new Screens.f_Screen_Black();
						sb.bounds = MainScreen.Bounds;
						sb.stayawakeMode = func;
						showScreens(sb, s);
					}
                    break;

				case SimpleScreenType.Firefox_Google:
					prankScreen.Screens.f_Firefox_Google goo = new Screens.f_Firefox_Google();
					goo.bounds = MainScreen.Bounds;
					goo.stayawakeMode = func;
					goo.param = parameter == "" ? null : parameter;
					goo.ShowDialog();
					break;

				case SimpleScreenType.Firefox_Porn:
					prankScreen.Screens.f_Firefox_Pron prn = new Screens.f_Firefox_Pron();
					prn.bounds = MainScreen.Bounds;
					prn.stayawakeMode = func;
					prn.param = parameter == "" ? "M" : parameter.ToLower() == "m" ? "M" : "F";
					prn.ShowDialog();
					break;


				case SimpleScreenType.Screen_Pixelated:
					foreach (Screen s in Screen.AllScreens)
					{
						prankScreen.Screens.f_Screen_Blurry blur = new Screens.f_Screen_Blurry();
						blur.bounds = MainScreen.Bounds;
						blur.stayawakeMode = func;
						blur.param = parameter == "" ? null : parameter;
						showScreens(blur, s);
					}
					break;

            }


			
		}

		public void showScreens(f_ScreenForm fsf, Screen s)
		{
			if (s != MainScreen)
			{
				fsf.Show();
			}
			else
			{
				fsf.ShowDialog();
			}
		}

    }
}
