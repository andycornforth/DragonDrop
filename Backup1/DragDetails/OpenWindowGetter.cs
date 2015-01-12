using System;
using System.Collections.Generic;
using System.Text;
using HWND = System.IntPtr;
using System.Runtime.InteropServices;

namespace DragDetails {

    /// <summary>
    /// http://tommycarlier.blogspot.com/2006/05/getting-list-of-all-open-windows.html
    /// </summary>
    public static class OpenWindowGetter {
        /// <summary>Returns a dictionary that contains the handle and title of all the open windows.</summary>
        /// <returns>A dictionary that contains the handle and title of all the open windows.</returns>
        public static IDictionary<HWND, string> GetOpenWindows() {
            HWND lShellWindow = GetShellWindow();
            Dictionary<HWND, string> lWindows = new Dictionary<HWND, string>();

            EnumWindows(delegate(HWND hWnd, int lParam) {
                if (hWnd == lShellWindow) return true;
                if (!IsWindowVisible(hWnd)) return true;

                int lLength = GetWindowTextLength(hWnd);
                if (lLength == 0) return true;

                StringBuilder lBuilder = new StringBuilder(lLength);
                GetWindowText(hWnd, lBuilder, lLength + 1);

                lWindows[hWnd] = lBuilder.ToString();
                return true;

            }, 0);

            return lWindows;
        }

        delegate bool EnumWindowsProc(HWND hWnd, int lParam);

        [DllImport("USER32.DLL")]
        static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        static extern int GetWindowText(HWND hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        static extern int GetWindowTextLength(HWND hWnd);

        [DllImport("USER32.DLL")]
        static extern bool IsWindowVisible(HWND hWnd);

        [DllImport("USER32.DLL")]
        static extern IntPtr GetShellWindow();

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern bool SetWindowPos(
           int hWnd,               // window handle
           int hWndInsertAfter,    // placement-order handle
           int X,                  // horizontal position
           int Y,                  // vertical position
           int cx,                 // width
           int cy,                 // height
           uint uFlags);           // window positioning flags

        public const int HWND_BOTTOM = 0x1;

        // Following keeps the window always on top, even if you click on a window behind (annoying)
        public const int HWND_TOPMOST = -1; // http://www.developerfusion.co.uk/show/662/
        public const int HWND_NOTOPMOST = -2;


        public const uint SWP_NOSIZE = 0x1;
        public const uint SWP_NOMOVE = 0x2;
        public const uint SWP_SHOWWINDOW = 0x40;


        public const uint SW_SHOWMAXIMIZED = 0x3;

        /// <summary>
        /// http://www.developer.com/net/csharp/print.php/3347251
        /// </summary>
        /// <param name="handle"></param>
        public static void ShoveToBackground(IntPtr handle) {
            SetWindowPos((int)handle,
               HWND_BOTTOM,
               0, 0, 0, 0,
               SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
        }

        public static void MoveToTopLeft (IntPtr handle) {
            SetWindowPos((int)handle,
               HWND_NOTOPMOST,
               0, 0, 0, 0,
               SWP_NOSIZE | SWP_SHOWWINDOW);
        }

    }
}
