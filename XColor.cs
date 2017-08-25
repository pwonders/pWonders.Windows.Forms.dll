using System.Drawing;
using Windows.UI.ViewManagement;
using Microsoft.Win32;

namespace System.Drawing
{
	public static class XColor
	{
		public static Color Blend(Color color1, Color color2, int alpha)
		{
			if (alpha < 0) alpha = 0;
			else if (alpha > 255) alpha = 255;
			int r = color1.R * (255 - alpha) / 255 + color2.R * alpha / 255;
			int g = color1.G * (255 - alpha) / 255 + color2.G * alpha / 255;
			int b = color1.B * (255 - alpha) / 255 + color2.B * alpha / 255;
			return Color.FromArgb(r, g, b);
		}

		public static Color Invert(Color color)
		{
			int r = 0xff - color.R;
			int g = 0xff - color.G;
			int b = 0xff - color.B;
			return Color.FromArgb(color.A, r, g, b);
		}

		public static Color Rotate(Color color, float degree)
		{
			float h = color.GetHue();
			float s = color.GetSaturation();
			float b = color.GetBrightness();
			return FromAhsb(color.A, (h + ((degree % 360f) + 360f)) % 360f, s, b);
		}

		public static Color FromAbgr(int abgr)
		{
			byte a = (byte) ((0xff000000 & abgr) >> 24);
			byte b = (byte) ((0x00ff0000 & abgr) >> 16);
			byte g = (byte) ((0x0000ff00 & abgr) >> 8);
			byte r = (byte) ((0x000000ff & abgr) >> 0);

			return Color.FromArgb(a, r, g, b);
		}

		// https://blogs.msdn.microsoft.com/cjacks/2006/04/12/converting-from-hsb-to-rgb-in-net/, 2017-08-25.
		public static Color FromAhsb(int alpha, float hue, float saturation, float brightness)
		{
			int a = alpha;
			float h = hue, s = saturation, b = brightness;

			if (a < 0 || 255 < a)
			{
				throw new ArgumentOutOfRangeException("alpha");
			}
			if (h < 0f || 360f < h)
			{
				throw new ArgumentOutOfRangeException("hue");
			}
			if (s < 0f || 1f < s)
			{
				throw new ArgumentOutOfRangeException("saturation");
			}
			if (b < 0f || 1f < b)
			{
				throw new ArgumentOutOfRangeException("brightness");
			}

			if (0 == s)
			{
				return Color.FromArgb(a, Convert.ToInt32(b * 255), Convert.ToInt32(b * 255), Convert.ToInt32(b * 255));
			}

			float fMax, fMid, fMin;
			int iSextant, iMax, iMid, iMin;

			if (0.5 < b)
			{
				fMax = b - (b * s) + s;
				fMin = b + (b * s) - s;
			}
			else
			{
				fMax = b + (b * s);
				fMin = b - (b * s);
			}

			iSextant = (int) Math.Floor(h / 60f);
			if (300f <= h)
			{
				h -= 360f;
			}
			h /= 60f;
			h -= 2f * (float) Math.Floor(((iSextant + 1f) % 6f) / 2f);
			if (0 == iSextant % 2)
			{
				fMid = h * (fMax - fMin) + fMin;
			}
			else
			{
				fMid = fMin - h * (fMax - fMin);
			}

			iMax = Convert.ToInt32(fMax * 255);
			iMid = Convert.ToInt32(fMid * 255);
			iMin = Convert.ToInt32(fMin * 255);

			switch (iSextant)
			{
			case 1:
				return Color.FromArgb(a, iMid, iMax, iMin);
			case 2:
				return Color.FromArgb(a, iMin, iMax, iMid);
			case 3:
				return Color.FromArgb(a, iMin, iMid, iMax);
			case 4:
				return Color.FromArgb(a, iMid, iMin, iMax);
			case 5:
				return Color.FromArgb(a, iMax, iMin, iMid);
			default:
				return Color.FromArgb(a, iMax, iMid, iMin);
			}
		}
	}
}
