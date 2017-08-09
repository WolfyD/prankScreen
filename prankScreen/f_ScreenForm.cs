using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prankScreen
{
    public partial class f_ScreenForm : Form
    {
		System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

		public enum EXECUTION_STATE : uint
		{
			ES_AWAYMODE_REQUIRED = 0x00000040,
			ES_CONTINUOUS = 0x80000000,
			ES_DISPLAY_REQUIRED = 0x00000002,
			ES_SYSTEM_REQUIRED = 0x00000001
			// Legacy flag, should not be used.
			// ES_USER_PRESENT = 0x00000004
		}
		
		
        public Screen bgScreen { get; set; } 
        public float opacity { get; set; }
		public string parameter { get; set; }
		public bool multiscreen { get; set; }
		public List<f_ScreenForm> openedscreens = new List<f_ScreenForm>();
		public bool selfOpen { get; set; }

		int keypresscount = 0;
        int maxkeypress = 0;

        public bool close = false;
        
        public f_ScreenForm()
        {
            InitializeComponent();
            Load += F_ScreenForm_Load;
        }

		/*
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }
        */

		public int stayawakeMode { get; set; }

        private void F_ScreenForm_Load(object sender, EventArgs e)
        {
			if (stayawakeMode == 0)
			{
				SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_SYSTEM_REQUIRED | EXECUTION_STATE.ES_AWAYMODE_REQUIRED);
			}
			else
			{
				t.Interval = 1000;
				t.Tick += T_Tick;
				t.Start();
			}

			maxkeypress = new Random().Next(10, 50);

            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
			this.TopMost = true;
			this.Select(false,false);
			this.Focus();
			this.TopMost = true;
			this.Select(true, true);
			this.Focus();

			if (!multiscreen && !selfOpen)
			{
				Screen[] screens = Screen.AllScreens;

				foreach (Screen s in screens)
				{
					if (s.DeviceName != Screen.FromPoint(this.Location).DeviceName)
					{
						f_secondaryScreen fss = new f_secondaryScreen();
						fss.Bounds = s.Bounds;
						fss.selfOpen = true;
						openedscreens.Add(fss);

						fss.Show();
					}
				}
			}

			//TODO: Turn Back On
			ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule;
            objKeyboardProcess = new LowLevelKeyboardProc(captureKey);
            ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0);
        }

		int tickcount = 0;

		private void T_Tick(object sender, EventArgs e)
		{
			if(tickcount >= 50)
			{
				tickcount = 0;

				Cursor.Position = new Point(Cursor.Position.X + 5, Cursor.Position.Y);
				Thread.Sleep(100);
				Cursor.Position = new Point(Cursor.Position.X - 5, Cursor.Position.Y);
				TopMost = true;
			}

			tickcount++;
		}

		public virtual void doBSOD()
        {

        }

        private void f_ScreenForm_KeyDown(object sender, KeyEventArgs e)
        {
            keypresscount++;

            if(keypresscount >= maxkeypress)
            {
                keypresscount = -10000;
                doBSOD();
            }

			if (e.KeyCode == Keys.X && (e.Shift & e.Control))
			{
				if (stayawakeMode == 0)
				{
					SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
				}

				UnhookWindowsHookEx(ptrHook);

				if(openedscreens.Count > 0)
				{
					foreach(f_ScreenForm f in openedscreens)
					{
						f.Close();
					}
				}

				close = true;
				this.Close();
			}
        }

        private void f_ScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason.ToString() == "UserClosing" && !close)
            {
                e.Cancel = true;
            }

        }






            
#region Handle special keys
        // Structure contain information about low-level keyboard input event 
        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public Keys key;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr extra;
        }
        //System level functions to be used for hook and unhook keyboard input  
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string name);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern short GetAsyncKeyState(Keys key);
        //Declaring Global objects     
        private IntPtr ptrHook;
        private LowLevelKeyboardProc objKeyboardProcess;

        private IntPtr captureKey(int nCode, IntPtr wp, IntPtr lp)
        {
            if (nCode >= 0)
            {
                KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lp, typeof(KBDLLHOOKSTRUCT));

                // Disabling Windows keys 

                if (objKeyInfo.key == Keys.RWin || objKeyInfo.key == Keys.LWin || objKeyInfo.key == Keys.Tab && HasAltModifier(objKeyInfo.flags) || objKeyInfo.key == Keys.Escape && (ModifierKeys & Keys.Control) == Keys.Control || objKeyInfo.key == Keys.Escape && (ModifierKeys & Keys.Alt) == Keys.Alt)
                {
                    //return (IntPtr)0;
                    return (IntPtr)2; // if 0 is returned then All the above keys will be enabled
                }
            }
            return CallNextHookEx(ptrHook, nCode, wp, lp);
        }

        bool HasAltModifier(int flags)
        {
            return (flags & 0x20) == 0x20;
        }
#endregion

    }
}
