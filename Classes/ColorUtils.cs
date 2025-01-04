using System.Drawing;

namespace ExileMaps.Classes
{
    public static class ColorUtils
    {
        public static Color InterpolateColor(Color color1, Color color2, float fraction)
        {
            float r = color1.R + (color2.R - color1.R) * fraction;
            float g = color1.G + (color2.G - color1.G) * fraction;
            float b = color1.B + (color2.B - color1.B) * fraction;
            float a = color1.A + (color2.A - color1.A) * fraction;

            // Restrict RGBA values to 0-255
            r = r > 255 ? 255 : r < 0 ? 0 : r;
            g = g > 255 ? 255 : g < 0 ? 0 : g;
            b = b > 255 ? 255 : b < 0 ? 0 : b;
            a = a > 255 ? 255 : a < 0 ? 0 : a;

            return Color.FromArgb((int)a, (int)r, (int)g, (int)b);
        }
    }
}
