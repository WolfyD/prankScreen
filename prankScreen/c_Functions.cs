using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prankScreen
{
    class c_Functions
    {
        public static Dictionary<string, string> helpLST = helpLST = new Dictionary<string, string>() {
              {"1" ,@"Microsoft Windows 95 Installation spoof. 
Bar fills up on the bottom while the majority of the screen shows slides of information about Win95.
BSOD if user messes with keys or clicks [ Exit (F3) ] button" },
              {"2" ,@"Microsoft Windows 98 Installation spoof. 
Bar on left shows process status whiole a bar fills up in the middle of the screen over blue background
BSOD if user messes with keys" },
              {"3" ,"" },
              {"4" ,"" },
              {"5" ,"" },
              {"6" ,"" },
              {"7" ,"" },
              {"8" ,"" },
              {"9" ,"" },
              {"10","" },
              {"11","" },
              {"12","" },
              {"13","" },
              {"14","" },
              {"15","" },
              {"16","" },
              {"17","" },
              {"18","" },
              {"19","" },
              {"20","" },
              {"21","" },
              {"22","" },
              {"23","" },
              {"24","" },
              {"25","" },
              {"26","" },
              {"27","" },
              {"28","" },
              {"29","" },
              {"30","" },
              {"31","" },
              {"32","" },
              {"33","" },
              {"34","" },
              {"35","" },
              {"36","" },
              {"37","" },
              {"38","" },
              {"39","" },
              {"40","" }
          };



        public void echo(String str)
        {
            echo(str, 1);
        }

        public void echo(String str, int mode)
        {
            if (mode == 1)
            {
                Console.WriteLine(str);
            }
            else
            {
                Console.Write(str);
            }
        }

        public void listEcho(string[] strs)
        {
            foreach (string s in strs)
            {
				ConsoleColor c = Console.ForegroundColor;
				if (s.EndsWith(" "))
				{
					Console.ForegroundColor = ConsoleColor.Green;
				}

				echo(s);

				if (s.EndsWith(" "))
				{
					Console.ForegroundColor = c;
				}
			}
        }

        public void listEcho(List<string> strs)
        {
            foreach (string s in strs)
            {
				ConsoleColor c = Console.ForegroundColor;
				if (s.EndsWith(" "))
				{
					Console.ForegroundColor = ConsoleColor.Green;
				}

                echo(s);

				if (s.EndsWith(" "))
				{
					Console.ForegroundColor = c;
				}
			}
        }

        public void question(String str)
        {
            echo(str);
            echo("> ", 2);
        }

        public void init()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            echo("Welcome to the WolfPaw PrankScreen! (v0.9)");
            echo("You can use this software to mess with your incautious coworker or friend.");
            echo("");
            echo("This software is made to be used as a joke, the creator assumes no responsibility for it's use or effects.");
            echo("This software was inspired by the site fakeupdate.net.");
            echo("");
        }

        public void help(String str)
        {
            try
            {
                str = str.Substring(1);
                echo(helpLST[str]);
            }
            catch (KeyNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                echo(">> Error: No such item [" + str + "]");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            catch (Exception ex2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                echo("\r\n======================================\r\n");
                echo(ex2.ToString());
                echo("\r\n======================================\r\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.ReadKey();
        }

        public void search(String str, string[] modes)
        {
            str = str.Replace("s-", "");
            Regex reg = new Regex("^\\s+(\\d{1,2})?.*?" + str.ToLower() + ".*$");

            List<string> lst = new List<string>();

            foreach(String s in modes)
            {
                var m = reg.Match(s.ToLower());
                if (m.Success)
                {
                    lst.Add(s);
                }
            }

            listEcho(lst);
            Console.ReadKey();
        }

        public void open(string mode)
        {
            f_Simple fs = new f_Simple();

            Screen[] ss = Screen.AllScreens;
            int ps = 0;
            for (int i = 0; i <  ss.Length; i++) { if (ss[i] == Screen.PrimaryScreen) { ps = i; } }

            fs.screens = ss;
            fs.mainScreen = ps;
            fs.secondaryScreenColor = Color.Black;

			string param = "";
			string[] paramModes = new string[] { "" };

			if (mode.Contains(":"))
			{
				param = mode.Split(':')[1];
				mode = mode.Split(':')[0];
			}

			if (fs.paramModes.Contains(mode))
			{
				fs.parameter = param;
			}

            switch (mode)
            {
                case "1":
                    fs.st = SimpleScreenType.Install_w95;
                    break;

                case "2":
                    fs.st = SimpleScreenType.Install_w98;
                    break;

				case "27":
					fs.st = SimpleScreenType.Screen_Unresponsive;
					break;

				case "28":
					fs.st = SimpleScreenType.Screen_Pixelated;
					break;
					
				case "36":
                    fs.st = SimpleScreenType.Screen_Black;
                    break;

				case "37":
					fs.st = SimpleScreenType.Firefox_Google;
					break;
            }

            fs.evalScreens();
        }
    }
}
