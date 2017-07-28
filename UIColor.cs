﻿using System.Drawing;
using Windows.UI.ViewManagement;
using Microsoft.Win32;

namespace System.Drawing
{
	public static class UIColor
	{
		static UIColor()
		{
			try
			{
				s_Settings = new UISettings();
				s_Settings.ColorValuesChanged += UISettings_ColorValuesChanged;
				s_IsValid = true;
			}
			catch
			{
				s_IsValid = false;
			}
		}
		
		// 2017-06-29, https://github.com/File-New-Project/EarTrumpet/blob/master/EarTrumpet/Color%20Types.txt
		public static Color FromName(string name)
		{
			int colorSet = g.GetImmersiveUserColorSetPreference(false, false);
			int colorType = g.GetImmersiveColorTypeFromName(name);
			int abgr = g.GetImmersiveColorFromColorSetEx(colorSet, colorType, false, 0);
			return Color_From_Abgr(abgr);
		}

		public static bool IsValid
		{
			get { return s_IsValid; }
		}

		public static Color Accent
		{
			get { return Color_From_UIColorType(UIColorType.Accent); }
		}

		public static Color AccentDark1
		{
			get { return Color_From_UIColorType(UIColorType.AccentDark1); }
		}

		public static Color AccentDark2
		{
			get { return Color_From_UIColorType(UIColorType.AccentDark2); }
		}

		public static Color AccentDark3
		{
			get { return Color_From_UIColorType(UIColorType.AccentDark3); }
		}

		public static Color AccentLight1
		{
			get { return Color_From_UIColorType(UIColorType.AccentLight1); }
		}

		public static Color AccentLight2
		{
			get { return Color_From_UIColorType(UIColorType.AccentLight2); }
		}

		public static Color AccentLight3
		{
			get { return Color_From_UIColorType(UIColorType.AccentLight3); }
		}

		public static Color Background
		{
			get { return Color_From_UIColorType(UIColorType.Background); }
		}

		public static Color Complement
		{
			get { return Color_From_UIColorType(UIColorType.Complement); }
		}

		public static Color Foreground
		{
			get { return Color_From_UIColorType(UIColorType.Foreground); }
		}

		static bool s_IsValid;
		static UISettings s_Settings;

		static void UISettings_ColorValuesChanged(UISettings sender, object obj)
		{
			System.Diagnostics.Debug.WriteLine(obj);
		}

		static Color Color_From_UIColorType(UIColorType desiredColor)
		{
			global::Windows.UI.Color uic;
			try
			{
				uic = s_Settings.GetColorValue(desiredColor);
			}
			catch
			{
				s_IsValid = false;
				return Color.Empty;
			}
			return Color_From_UIColor(uic);
		}

		static Color Color_From_UIColor(global::Windows.UI.Color color)
		{
			return Color.FromArgb(color.A, color.R, color.G, color.B);
		}

		static Color Color_From_Abgr(int abgr)
		{
			byte a = (byte) ((0xff000000 & abgr) >> 24);
			byte b = (byte) ((0x00ff0000 & abgr) >> 16);
			byte g = (byte) ((0x0000ff00 & abgr) >> 8);
			byte r = (byte) ((0x000000ff & abgr) >> 0);

			return Color.FromArgb(a, r, g, b);
		}
	}
}
