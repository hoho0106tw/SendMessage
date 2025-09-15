using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OorMainKiller
{
   public class Run
    {
        public void runHarker(string S, string O, string A, string P)
        {
            Window.Find(hwnd =>
            {
                var cn = Window.GetClassName(hwnd);
                var res = (cn == "ThunderRT6FormDC");
                if (res)
                {


                    IntPtr ThunderRT6PictureBoxDC = Window.FindWindowEx(hwnd, IntPtr.Zero, "ThunderRT6PictureBoxDC", null);
                    IntPtr ThunderRT6PictureBoxDC2 = Window.FindWindowEx(hwnd, ThunderRT6PictureBoxDC, "ThunderRT6PictureBoxDC", null);

                    IntPtr editor1 = Window.FindWindowEx(ThunderRT6PictureBoxDC2, IntPtr.Zero, "ThunderRT6TextBox", null);
                    IntPtr editor2 = Window.FindWindowEx(ThunderRT6PictureBoxDC2, editor1, "ThunderRT6TextBox", null);
                    IntPtr editor3 = Window.FindWindowEx(ThunderRT6PictureBoxDC2, editor2, "ThunderRT6TextBox", null);
                    IntPtr editor4 = Window.FindWindowEx(ThunderRT6PictureBoxDC2, editor3, "ThunderRT6TextBox", null);


                    Window.Rect NotepadRect1 = new Window.Rect();
                    Window.GetWindowRect(editor1, ref NotepadRect1);

                    Window.Rect NotepadRect2 = new Window.Rect();
                    Window.GetWindowRect(editor2, ref NotepadRect2);

                    Window.Rect NotepadRect3 = new Window.Rect();
                    Window.GetWindowRect(editor3, ref NotepadRect3);

                    Window.Rect NotepadRect4 = new Window.Rect();
                    Window.GetWindowRect(editor4, ref NotepadRect4);

                    List<Window.SOAP> SOAP = new List<Window.SOAP>()
      {
        new Window.SOAP() { editor = editor1, Y= NotepadRect1.Top},
       new Window.SOAP() { editor = editor2, Y= NotepadRect2.Top},
       new Window.SOAP() { editor = editor3, Y= NotepadRect3.Top},
        new Window.SOAP() { editor = editor4, Y= NotepadRect4.Top}
      };

                    SOAP.Sort((a, b) => a.Y.CompareTo(b.Y));


                    for (int i = 0; i <= SOAP.Count - 1; i++)

                    {
                        string msg = (i + 1).ToString();
                        string str = Window.GetStr(SOAP[i].editor);
                        uint WM_SETTEXT = 0xC;

                        if (i == 0 && S!=String.Empty)
                        {
                            msg = S;
                            Window.SendMessage(SOAP[i].editor, WM_SETTEXT, IntPtr.Zero, str + "\r\n" + msg);
                        }


                        if (i == 1 && O != String.Empty)
                        {
                            msg = O;
                            Window.SendMessage(SOAP[i].editor, WM_SETTEXT, IntPtr.Zero, str + "\r\n" + msg);
                        }


                        if (i == 2 && A != String.Empty)
                        {
                            msg = A;
                            Window.SendMessage(SOAP[i].editor, WM_SETTEXT, IntPtr.Zero, str + "\r\n" + msg);
                        }

                        if (i == 3 && P != String.Empty)
                        {
                            msg = P;
                            Window.SendMessage(SOAP[i].editor, WM_SETTEXT, IntPtr.Zero, str + "\r\n" + msg);
                        }
                    }


                }
                return res;
            });


        }
    }
}
