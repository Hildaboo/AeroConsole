using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AeroConsole
{
    class Aero
    {
        [DllImport("user32.dll")]
        private static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern System.UInt32 GetWindowLong(IntPtr hWnd, int nIndex);

        private const int GWL_EXSTYLE   = -20;
        private const int WS_EX_LAYERED = 0x80000;
        private const int LWA_ALPHA     = 0x2;

        /// <summary>
        /// percentage of opacity, 0% - 255%
        /// </summary>
        /// <param name="percent"></param>
        public static void MakeTransparent(byte percent)
        {
            IntPtr Handle = Process.GetCurrentProcess().MainWindowHandle;
            int newDwLong = ((int)GetWindowLong(Handle, GWL_EXSTYLE)) ^ WS_EX_LAYERED;
            
            SetWindowLong(Handle, GWL_EXSTYLE, newDwLong);
            SetLayeredWindowAttributes(Handle, 0, percent, LWA_ALPHA);
        }
    }
}
