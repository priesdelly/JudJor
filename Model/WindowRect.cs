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
        set {
            Right = Left + value;
        }
    }

    public int Height
    {
        get => Bottom - Top;
        private set { 
            Bottom = Top + value;
        }
    }

    public Size Size {
        get => new(Width, Height);
        private set { 
            Width = value.Width;
            Height = value.Height;
        }
    }
        
    public Point Location
    {
        get => new(Left, Top);
        private set { }
    }
}