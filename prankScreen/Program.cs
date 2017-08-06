﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace prankScreen
{
    class Program
    {
        public static c_Functions cf = new c_Functions();
        
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        

        public static string[] modes = new string[] {
            "--INSTALLERS:",
            "   Windows Systems:",
            "		1, Windows 95 Install ",
            "		2, Windows 98 Install ",
            "		3, Windows XP Install",
            "		4, Windows Vista Install",
            "		5, Windows 7 / 8 Install",
            "		6, Windows 8.1 Install",
            "		7, Windows 10 Install",
            "   Linux Systems:",
            "		8, Linux Debian Install",
            "		9, Linux Fedora Install",
            "		10, Linux Kali Install",
            "		11, Linux Raspbian Install",
            "	Other Systems:",
            "		12, Mac OSX Install",
            "		13, Apple TV Install",
            "		14, Chrome OS Install",
            "",
            "--Other Screens",
            "   Windows Systems:	",
            "		15, Windows XP Boot",
            "		16, Windows 7 Boot",
            "		17, Windows 8 Boot",
            "		18, Windows 10 Boot",
            "		19, Windows 98 BSOD",
            "		20, Windows XP BSOD",
            "		21, Windows 7 BSOD",
            "		22, Windows 8 BSOD",
            "		23, Windows 10 BSOD",
            "		24, Windows 95 Desktop",
            "		25, Windows 98 Desktop",
            "		26, Windows XP Desktop",
            "   Current Desktop:",
            "		27, Current Desktop (Unresponsive) ",
            "		28, Current Desktop (Pixelated) ",
            "		29, Current Desktop (LCD Broken)",
            "		30, Current Desktop (Error Message)",
            "		31, Current Desktop (Mirrored)",
            "   Linux Systems:",
            "		32, Linux Debian Boot",
            "		33, Linux Fedora Boot",
            "		34, Linux Kali Boot",
            "		35, Linux Raspbian Boot",
            "   Other:",
            "		36, Black Screen ",
            "		37, Frozen Firefox (Google Search) ",
            "		38, Frozen Firefox (Porn)",
            "		39, Frozen Firefox (Custom Website)",
            "		40, Virus Warning",
            "		0, Random Mode",
            ""
        };

        public static string numRegex = "^\\s+\\d{1,2}.*$";


        static void Main(string[] args)
        {
            Console.BufferWidth = 100;
            Console.WindowWidth = Console.LargestWindowWidth - 100;

            Console.BufferHeight = 100;
            Console.WindowHeight = Console.LargestWindowHeight - 10;
            
            //cf.init();
            mode();

            //TODO:SelfDelete with CMD /C
            //Console.Read();
        }
        
        public static void mode()
        {
			
			string mode = "";

            while (mode == "")
            {
				Console.SetCursorPosition(0, 7);

				for (int i = 0; i < 100; i++)
                {
                    cf.echo("                                            ");
                }

				Console.SetCursorPosition(0, 0);
				cf.init();

				Console.SetCursorPosition(0, 7);

				cf.echo("Please select a mode by typing in the corresponding number.");
                cf.echo("For help type in 'h' followed by the corresponding number (e.g.: h3)");
                cf.echo("To search in the list type in 's-' followed by your query (e.g.: s-Windows or s-2\\d <- regex)");
                cf.echo("");

				Console.ForegroundColor = ConsoleColor.Gray;

                cf.listEcho(modes);

                cf.question("Please enter your selection:");

                mode = Console.ReadLine();

                if(mode.ToLower().StartsWith("h") || mode.ToLower().StartsWith("s-"))
                {
                    if (mode.ToLower().StartsWith("h"))
                    {
                        cf.help(mode);
                        mode = "";
                    }
                    else
                    {
                        cf.search(mode, modes);
                        mode = "";
                    }
                }
                else
                {
                    int mod = -1;

					if (mode.Contains(':'))
					{
						Int32.TryParse(mode.Split(':')[0], out mod);
					}
					else
					{
						Int32.TryParse(mode, out mod);
					}
                    
                    if (mod > 0)
                    {
                        ShowWindow(Process.GetCurrentProcess().MainWindowHandle, SW_HIDE);
                        cf.open(mode);
                    }
                    else
                    {
                        mode = "";
                    }
                }

            }
        }
    }
}
