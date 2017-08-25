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

		public static Color FromName(Name name)
		{
			return FromName(name.ToString());
		}

		public static Color FromName(string name)
		{
			try
			{
				int colorSet = API.GetImmersiveUserColorSetPreference(false, false);
				int colorType = API.GetImmersiveColorTypeFromName(name);
				int abgr = API.GetImmersiveColorFromColorSetEx(colorSet, colorType, false, 0);
				return XColor.FromAbgr(abgr);
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
			get { return Color.FromArgb(0xcc, XColor.Blend(Shell, FromName(Name.ImmersiveSystemAccentDark2), 0xcc)); }
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
				return XColor.Blend(SystemColors.Highlight, Color.Black, 0x3f);
			case UIColorType.AccentDark2:
				return XColor.Blend(SystemColors.Highlight, Color.Black, 0x7f);
			case UIColorType.AccentDark3:
				return XColor.Blend(SystemColors.Highlight, Color.Black, 0xbf);
			case UIColorType.AccentLight1:
				return XColor.Blend(SystemColors.Highlight, Color.White, 0x3f);
			case UIColorType.AccentLight2:
				return XColor.Blend(SystemColors.Highlight, Color.White, 0x7f);
			case UIColorType.AccentLight3:
				return XColor.Blend(SystemColors.Highlight, Color.White, 0xbf);
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
	}
}
