using System.Drawing;
using System.Runtime.InteropServices;

namespace JudJor.Model;

// Is this intended to be used with Win32 API?, if so, this should be named with their corresponding name.
[StructLayout(LayoutKind.Sequential)]
public struct WindowRect
{
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;

    public WindowRect(int left, int top, int right, int bottom) : this()
    {
        Left = left;
        Top = top;
        Right = right;
        Bottom = bottom;
    }

    // TODO: Instead of implementing all these stuffs, just create a method for converting this struct into System.Drawing.Rectangle

    public static WindowRect FromRectangle(Rectangle r)
    {
        return new WindowRect
        {
            Left = r.Left,
            Top = r.Top,
            Right = r.Right,
            Bottom = r.Bottom,
        };
    }


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
        private set {
          Offset(value.X - Left, value.Y - Top);  
        }
    }

    public void Offset(int deltaX, int deltaY)
    {
        Top += deltaY;
        Left += deltaX;
        Bottom += deltaY;
        Right += deltaX;
    }

    public void Inflate(int dl, int dt, int dr, int db)
    {
        Left -= dl;
        Top -= dt;
        Right += dr;
        Bottom += db;
    }

    public static bool operator ==(WindowRect a, WindowRect b)
    {
        return (a.Left == b.Left) && (a.Right == b.Right) &&
            (a.Top == b.Top) && (a.Bottom == b.Bottom);
    }

    public static bool operator !=(WindowRect a, WindowRect b)
    {
        return !(a == b);
    }
}