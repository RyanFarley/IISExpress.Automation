using System;
using System.Runtime.InteropServices;

namespace IISExpress.Automation
{
    internal class NativeMethods
    {
       [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr GetTopWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern uint GetWindowThreadProcessId(IntPtr hwnd, out uint lpdwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool PostMessage(HandleRef hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    }
}