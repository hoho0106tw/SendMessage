using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using System.Runtime.InteropServices;


namespace OorMainKiller
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        /// 

        //[DllImport("kernel32.dll")]
        //static extern IntPtr GetConsoleWindow();

        //[DllImport("user32.dll")]
        //static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        public  static void Main(string[] args)
        {


            //const int SW_HIDE = 0;
            //////const int SW_SHOW = 5;

            ////// Usage:
            //var handle = GetConsoleWindow();

            //// Hide
            //ShowWindow(handle, SW_HIDE);

            //// Show
            ////ShowWindow(handle, SW_SHOW);


            Run Run = new Run();

            if (args.Length >= 4)
            {
                Run.runHarker(args[0].Replace("<br>","\r\n"), args[1].Replace("<br>", "\r\n"), args[2].Replace("<br>", "\r\n"), args[3].Replace("<br>", "\r\n"));
            }        





        }
    }
}
