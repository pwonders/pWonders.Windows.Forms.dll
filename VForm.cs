﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace System.Windows.Forms
{
	/// <summary>
	/// Specifies the sides of a window to apply a border to.
	/// </summary>
	[Description("Specifies the sides of a window to apply a border to.")]
	[Flags]
	public enum AccentBorder
	{
		None = 0,
		/// <summary>
		/// A border on the left edge of the window.
		/// </summary>
		Left = 1,
		/// <summary>
		/// A border on the top edge of the window.
		/// </summary>
		Top = 2,
		/// <summary>
		/// A border on the right edge of the window.
		/// </summary>
		Right = 4,
		/// <summary>
		/// A border on the bottom edge of the window.
		/// </summary>
		Bottom = 8,
		/// <summary>
		/// A border on all four sides of the window.
		/// </summary>
		All = Left | Top | Right | Bottom,
	}

	public class VForm : System.Windows.Forms.Form
	{
		public VForm()
		{
			ResetBlurColor();
		}

		/// <summary>
		/// Indicate the position of the cursor hot spot as if it's in a title bar.
		/// </summary>
		[Category("Behavior")]
		[Description("Indicate the position of the cursor hot spot as if it's in a title bar.")]
		[DefaultValue(false)]
		public bool AllowDragClient { set; get; }

		/// <summary>
		/// Extends the window frame into the client area. Use negative margin values to create the \"sheet of glass\" effect where the client area is rendered as a solid surface with no window border.
		/// </summary>
		[Category("Appearance")]
		[Description("Extends the window frame into the client area. Use negative margin values to create the \"sheet of glass\" effect where the client area is rendered as a solid surface with no window border.")]
		public Padding ExtendFrame
		{
			set
			{
				if (m_ExtendFrame != value)
				{
					m_ExtendFrame = value;
					if (this.DesignMode == false && this.IsHandleCreated)
					{
						set_ExtendFrame();
					}
				}
			}
			get { return m_ExtendFrame; }
		}

		/// <summary>
		/// Blur window Windows-10 style.
		/// </summary>
		[Category("Appearance")]
		[Description("Blur window Windows-10 style.")]
		[DefaultValue(false)]
		public bool BlurWin10
		{
			set
			{
				if (m_BlurWin10 != value)
				{
					m_BlurWin10 = value;
					if (this.DesignMode == false && this.IsHandleCreated)
					{
						set_BlurWin10();
						this.Invalidate();
					}
				}
			}
			get { return m_BlurWin10; }
		}

		/// <summary>
		/// Blur window Windows-10 style with specified gradient overlay.
		/// </summary>
		[Category("Appearance")]
		[Description("Blur window Windows-10 style with specified gradient overlay.")]
		public Color BlurColor
		{
			set
			{
				if (m_BlurColor != value)
				{
					m_BlurColor = value;
					if (this.DesignMode == false && this.IsHandleCreated && m_BlurWin10)
					{
						set_BlurWin10();
					}
				}
			}
			get { return m_BlurColor; }
		}

		/// <summary>
		/// Blur window Windows-10 style with specified border.
		/// </summary>
		[Category("Appearance")]
		[Description("Blur window Windows-10 style with specified border.")]
		public AccentBorder BlurBorder
		{
			set
			{
				if (m_BlurBorder != value)
				{
					m_BlurBorder = value;
					if (this.DesignMode == false && this.IsHandleCreated && m_BlurWin10)
					{
						set_BlurWin10();
					}
				}
			}
			get { return m_BlurBorder; }
		}

		Padding m_ExtendFrame;
		bool m_BlurWin10;
		Color m_BlurColor;
		AccentBorder m_BlurBorder;
		bool m_BlurUseGradient = false;

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			if (m_ExtendFrame != Padding.Empty)
			{
				set_ExtendFrame();
			}
			if (m_BlurWin10)
			{
				set_BlurWin10();
			}
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
			if (m_BlurUseGradient == false)
			{
				if (m_BlurWin10 && ShouldSerializeBlurColor())
				{
					Color bg = m_BlurColor.A < 0xff ? m_BlurColor : Color.FromArgb(0xfe, m_BlurColor);
					using (Brush br = new SolidBrush(bg))
					{
						e.Graphics.FillRectangle(br, e.ClipRectangle);
					}
				}
			}
		}

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			switch (m.Msg)
			{
			case API.WM_NCHITTEST:
				if (this.AllowDragClient && m.Result == new IntPtr(API.HTCLIENT))
				{
					m.Result = new IntPtr(API.HTCAPTION);
				}
				break;
			}
		}

		bool ShouldSerializeExtendFrame()
		{
			return m_ExtendFrame != Padding.Empty;
		}

		void ResetExtendFrame()
		{
			m_ExtendFrame = Padding.Empty;
		}

		bool ShouldSerializeBlurColor()
		{
			return m_BlurColor != Color.Transparent;
		}

		void ResetBlurColor()
		{
			m_BlurColor = Color.Transparent;
		}

		bool ShouldSerializeBlurBorder()
		{
			return m_BlurBorder != AccentBorder.None;
		}

		void ResetBlurBorder()
		{
			m_BlurBorder = AccentBorder.None;
		}

		// WM_DWMCOMPOSITIONCHANGED not sent as of Windows 8 per MSDN.
		void set_ExtendFrame()
		{
			API.MARGINS margins = new API.MARGINS();
			margins.cxLeftWidth = m_ExtendFrame.Left;
			margins.cxRightWidth = m_ExtendFrame.Right;
			margins.cyTopHeight = m_ExtendFrame.Top;
			margins.cyBottomHeight = m_ExtendFrame.Bottom;
			// Catch on platforms without DwmExtendFrameIntoClientArea.
			try
			{
				API.DwmExtendFrameIntoClientArea(this.Handle, ref margins);
			}
			catch { }
		}

		/* See also:
		 * https://stackoverflow.com/questions/32724187/how-do-you-set-the-glass-blend-colour-on-windows-10
		 * https://stackoverflow.com/questions/32335945/blur-behind-window-with-titlebar-in-windows-10-stopped-working-after-windows-up
		 * http://undoc.airesoft.co.uk/user32.dll/SetWindowCompositionAttribute.php
		 * http://vhanla.codigobit.info/2015/07/enable-windows-10-aero-glass-aka-blur.html
		 * http://www.classicshell.net/forum/viewtopic.php?f=10&t=6444
		 */
		void set_BlurWin10()
		{
			API.AccentPolicy policy = new API.AccentPolicy();
			if (m_BlurWin10)
			{
				policy.AccentState = API.ACCENT_ENABLE_BLURBEHIND;
				if (m_BlurBorder.HasFlag(AccentBorder.Left))
				{
					policy.AccentFlags |= API.AccentFlags.DrawLeftBorder;
				}
				if (m_BlurBorder.HasFlag(AccentBorder.Right))
				{
					policy.AccentFlags |= API.AccentFlags.DrawRightBorder;
				}
				if (m_BlurBorder.HasFlag(AccentBorder.Top))
				{
					policy.AccentFlags |= API.AccentFlags.DrawTopBorder;
				}
				if (m_BlurBorder.HasFlag(AccentBorder.Bottom))
				{
					policy.AccentFlags |= API.AccentFlags.DrawBottomBorder;
				}
				/*
				 * Using SupportsTransparentBackColor with BackColor.A < 0xff flickers on move (and possibly resize).
				 * Using WS_EX_COMPOSITED doesn't avoid flicker above.
				 * Using DoubleBuffered negates blur above, sometimes.
				 * Using Black BackColor and filling in OnPaint flickers on move and resize.
				 * Using Opacity (layered) only flickers on resize, but loses blur color when visibility is toggled.
				 * Using gradient doesn't show border, and text is ugly.
				 */
				if (m_BlurUseGradient)
				{
					policy.AccentFlags |= API.AccentFlags.Unknown;
					policy.GradientColor = Color.FromArgb(m_BlurColor.A, m_BlurColor.B, m_BlurColor.G, m_BlurColor.R).ToArgb();
				}
				this.BackColor = Color.FromArgb(0xff, 0, 0, 0);
			}
			else
			{
				policy.AccentState = API.ACCENT_DISABLED;
			}
			API.WINCOMPATTRDATA data = new API.WINCOMPATTRDATA();
			data.attribute = API.WCA_ACCENT_POLICY;
			data.dataSize = Marshal.SizeOf(policy);
			data.pData = Marshal.AllocHGlobal(data.dataSize);
			if (data.pData != IntPtr.Zero)
			{
				Marshal.StructureToPtr(policy, data.pData, false);
				// Catch on platforms without SetWindowCompositionAttribute.
				try
				{
					API.SetWindowCompositionAttribute(this.Handle, ref data);
				}
				catch { }
				Marshal.FreeHGlobal(data.pData);
			}
		}
	}
}
