using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;

namespace JudJor.Repository;

public static class WindowAPI
{
    //public const int SM_CXSCREEN = 0;
    //public const int SM_CYSCREEN = 1;
    public const int SWP_SHOWWINDOW = 0x0040;

    [DllImport("user32.dll")]
    public static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", SetLastError = true)]
    public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetWindowRect(IntPtr hWnd, out Model.WindowRect lpRect);

    //[DllImport("user32.dll", SetLastError = true)]
    //public static extern int GetSystemMetrics(int hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    
}