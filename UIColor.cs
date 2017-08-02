using System.Drawing;
using Windows.UI.ViewManagement;
using Microsoft.Win32;

namespace System.Drawing
{
	public static partial class UIColor
	{
		static UIColor()
		{
			try
			{
				s_Settings = new UISettings();
				s_hasSettings = true;
				//s_Settings.ColorValuesChanged += UISettings_ColorValuesChanged;
			}
			catch { }
		}

		public static Color Blend(Color color1, Color color2, int alpha)
		{
			if (alpha < 0) alpha = 0;
			else if (alpha > 255) alpha = 255;
			int r = color1.R * (255 - alpha) / 255 + color2.R * alpha / 255;
			int g = color1.G * (255 - alpha) / 255 + color2.G * alpha / 255;
			int b = color1.B * (255 - alpha) / 255 + color2.B * alpha / 255;
			return Color.FromArgb(r, g, b);
		}

		public static Color FromName(Name name)
		{
			return FromName(name.ToString());
		}

		public static Color FromName(string name)
		{
			try
			{
				int colorSet = g.GetImmersiveUserColorSetPreference(false, false);
				int colorType = g.GetImmersiveColorTypeFromName(name);
				int abgr = g.GetImmersiveColorFromColorSetEx(colorSet, colorType, false, 0);
				return Color_from_abgr(abgr);
			}
			catch { }
			return Color.Empty;
		}

		public static Color Accent
		{
			get { return Color_from_UIColorType(UIColorType.Accent); }
		}

		public static Color AccentDark1
		{
			get { return Color_from_UIColorType(UIColorType.AccentDark1); }
		}

		public static Color AccentDark2
		{
			get { return Color_from_UIColorType(UIColorType.AccentDark2); }
		}

		public static Color AccentDark3
		{
			get { return Color_from_UIColorType(UIColorType.AccentDark3); }
		}

		public static Color AccentLight1
		{
			get { return Color_from_UIColorType(UIColorType.AccentLight1); }
		}

		public static Color AccentLight2
		{
			get { return Color_from_UIColorType(UIColorType.AccentLight2); }
		}

		public static Color AccentLight3
		{
			get { return Color_from_UIColorType(UIColorType.AccentLight3); }
		}

		public static Color Background
		{
			get { return Color_from_UIColorType(UIColorType.Background); }
		}

		public static Color Complement
		{
			get { return Color_from_UIColorType(UIColorType.Complement); }
		}

		public static Color Foreground
		{
			get { return Color_from_UIColorType(UIColorType.Foreground); }
		}

		// Start menu and action center have different colors.
		public static Color Shell
		{
			get { return FromName(Name.ImmersiveStartBackground); }
		}

		public static Color ShellWithTransparency
		{
			get { return Color.FromArgb(0xcc, Blend(Shell, FromName(Name.ImmersiveSystemAccentDark2), 0xcc)); }
		}

		static UISettings s_Settings;
		static bool s_hasSettings;

		// Doesn't work.
		// https://social.msdn.microsoft.com/Forums/en-US/2a1e3d21-17a1-47d1-9783-6f4e97900f96/uisettingscolorvalueschanged?forum=wpdevelop, 2017-08-01.
		static void UISettings_ColorValuesChanged(UISettings sender, object obj)
		{
			System.Diagnostics.Debug.WriteLine(obj, "UISettings_ColorValuesChanged");
		}

		static Color Color_from_UIColorType(UIColorType desiredColor)
		{
			if (s_hasSettings)
			{
				try
				{
					return Color_from_UIColor(s_Settings.GetColorValue(desiredColor));
				}
				catch { }
			}
			switch (desiredColor)
			{
			case UIColorType.Accent:
				return SystemColors.Highlight;
			case UIColorType.AccentDark1:
				return Blend(SystemColors.Highlight, Color.Black, 0x3f);
			case UIColorType.AccentDark2:
				return Blend(SystemColors.Highlight, Color.Black, 0x7f);
			case UIColorType.AccentDark3:
				return Blend(SystemColors.Highlight, Color.Black, 0xbf);
			case UIColorType.AccentLight1:
				return Blend(SystemColors.Highlight, Color.White, 0x3f);
			case UIColorType.AccentLight2:
				return Blend(SystemColors.Highlight, Color.White, 0x7f);
			case UIColorType.AccentLight3:
				return Blend(SystemColors.Highlight, Color.White, 0xbf);
			case UIColorType.Background:
				return SystemColors.Window;
			case UIColorType.Foreground:
				return SystemColors.WindowText;
			default:
				return Color.Empty;
			}
		}

		static Color Color_from_UIColor(global::Windows.UI.Color color)
		{
			return Color.FromArgb(color.A, color.R, color.G, color.B);
		}

		static Color Color_from_abgr(int abgr)
		{
			byte a = (byte) ((0xff000000 & abgr) >> 24);
			byte b = (byte) ((0x00ff0000 & abgr) >> 16);
			byte g = (byte) ((0x0000ff00 & abgr) >> 8);
			byte r = (byte) ((0x000000ff & abgr) >> 0);

			return Color.FromArgb(a, r, g, b);
		}
	}
}
