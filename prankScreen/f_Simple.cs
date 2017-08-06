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

		public string parameter { get; set; }

		public Screen MainScreen = null;
		public List<Screen> secondaryScreens = new List<Screen>();

		public string[] paramModes = new string[] { "28","37" };

        public f_Simple()
        {
            InitializeComponent();
        }

        public void evalScreens()
        {
            MainScreen = screens[mainScreen];
            foreach(Screen s in screens)
            {
                if(s != MainScreen)
                {
                    secondaryScreens.Add(s);
                }
            }

            foreach (Screen s in secondaryScreens)
            {
                f_ScreenForm fsf = new f_ScreenForm();

            }

            switch (st)
            {
                case SimpleScreenType.Install_w95:
                    prankScreen.Screens.f_Install_w95 fi95 = new Screens.f_Install_w95();
                    fi95.bounds = MainScreen.Bounds;
                    fi95.ShowDialog();
                    break;

                case SimpleScreenType.Install_w98:
                    prankScreen.Screens.f_Install_w98 fi98 = new Screens.f_Install_w98();
                    fi98.bounds = MainScreen.Bounds;
                    fi98.ShowDialog();
                    break;

                case SimpleScreenType.Screen_Unresponsive:
                    prankScreen.Screens.f_Screen_Unresponsive sunrep = new Screens.f_Screen_Unresponsive();
                    sunrep.bounds = MainScreen.Bounds;
                    sunrep.ShowDialog();
                    break;

                case SimpleScreenType.Screen_Black:
                    prankScreen.Screens.f_Screen_Black sb = new Screens.f_Screen_Black();
                    sb.bounds = MainScreen.Bounds;
                    sb.ShowDialog();
                    break;

				case SimpleScreenType.Firefox_Google:
					prankScreen.Screens.f_Firefox_Google goo = new Screens.f_Firefox_Google();
					goo.bounds = MainScreen.Bounds;
					goo.param = parameter == "" ? null : parameter;
					goo.ShowDialog();
					break;

				case SimpleScreenType.Screen_Pixelated:
					prankScreen.Screens.f_Screen_Blurry blur = new Screens.f_Screen_Blurry();
					blur.bounds = MainScreen.Bounds;
					blur.param = parameter == "" ? null : parameter;
					blur.ShowDialog();
					break;

            }
        }
    }
}
