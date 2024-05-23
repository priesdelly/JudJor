using System.Drawing;
using System.Runtime.InteropServices;

namespace JudJor.Model;

[StructLayout(LayoutKind.Sequential)]
public struct WindowRect
{
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;

    public int Width
    {
        get => Right - Left;
        private set {  }
    }

    public int Height
    {
        get => Bottom - Top;
        private set { }
    }

    public Size Size {
        get => new(Width, Height);
        private set { }
    }
        
    public Point Location
    {
        get => new(Left, Top);
        private set { }
    }
}