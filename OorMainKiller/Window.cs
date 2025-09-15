using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OorMainKiller
{ 

    public static class Window
    {

        public static bool Find(Func<IntPtr, bool> fn)
        {
            return EnumWindows((hwnd, lp) => !fn(hwnd), 0) == 0;
        }




        public static string GetClassName(IntPtr hwnd)
        {
            var sb = new StringBuilder(1024);
            GetClassName(hwnd, sb, sb.Capacity);
            return sb.ToString();
        }
        public static uint GetProcessId(IntPtr hwnd)//{0:X8}
        {
            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);
            return pid;
        }
        public static string GetText(IntPtr hwnd)
        {
            var sb = new StringBuilder(1024);
            GetWindowText(hwnd, sb, sb.Capacity);
            return sb.ToString();
        }


        public static string GetStr(IntPtr HwndStatue)
        {
            const int WM_GETTEXT = 0x000D;
            const int WM_GETTEXTLENGTH = 0x000E;

            string str = "";


            if (HwndStatue != IntPtr.Zero)
            {
                int TextLen;
                TextLen = SendMessage(HwndStatue, WM_GETTEXTLENGTH, 0, 0);
                Byte[] byt = new Byte[TextLen];
                SendMessage(HwndStatue, WM_GETTEXT, TextLen + 1, byt);
                str = Encoding.Default.GetString(byt);
            }
            return str;
        }


        delegate bool CallBackPtr(IntPtr hwnd, int lParam);

        [DllImport("user32.dll")]
        static extern int EnumWindows(CallBackPtr callPtr, int lPar);

        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("User32", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndParent);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int W, int H, uint uFlags);


        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", CharSet = CharSet.Auto)]
        public extern static IntPtr FindWindowEx(IntPtr parent, IntPtr child, string classname, string captionName);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam);


        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, Byte[] lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }

        public class SOAP
        {
            public IntPtr editor { get; set; }
            public int Y { get; set; }
        }

    }
}
