using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FarmCabal
{
    public class SendKeySample
    {
        private static Int32 WM_KEYDOWN = 0x100;
        private static Int32 WM_KEYUP = 0x101;

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PostMessage(IntPtr hWnd, int Msg, System.Windows.Forms.Keys wParam, int lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        public static IntPtr FindWindow(string windowName)
        {
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                if (p.MainWindowHandle != IntPtr.Zero && p.MainWindowTitle.ToLower() == windowName.ToLower())
                    return p.MainWindowHandle;
            }

            return IntPtr.Zero;
        }

        public static IntPtr FindWindow(IntPtr parent, string childClassName)
        {
            return FindWindowEx(parent, IntPtr.Zero, childClassName, string.Empty);
        }

        public static void SendKey(IntPtr hWnd, System.Windows.Forms.Keys key)
        {
            PostMessage(hWnd, WM_KEYDOWN, key, 0);

        }
    }
}
