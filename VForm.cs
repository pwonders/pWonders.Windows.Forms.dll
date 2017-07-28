using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace System.Windows.Forms
{
	[System.ComponentModel.DesignerCategory("")]
	public class VForm : System.Windows.Forms.Form
	{
		public VForm()
		{
			return;
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.UserPaint, true);
		}

		[Category("Appearance")]
		public Padding ExtendFrame
		{
			set
			{
				if (m_ExtendFrame != value)
				{
					m_ExtendFrame = value;
					if (m_ExtendFrame != Padding.Empty)
					{
						if (this.DesignMode == false && this.IsHandleCreated)
						{
							set_ExtendFrame();
						}
					}
				}
			}
			get { return m_ExtendFrame; }
		}

		[Category("Appearance")]
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
					}
				}
			}
			get { return m_BlurWin10; }
		}

		[Category("Appearance")]
		public Color BlurColor
		{
			set
			{
				if (m_BlurColor != value)
				{
					m_BlurColor = value;
					if (this.DesignMode == false && this.IsHandleCreated)
					{
						set_BlurWin10();
					}
				}
			}
			get { return m_BlurColor; }
		}

		Padding m_ExtendFrame;
		bool m_BlurWin10;
		Color m_BlurColor;

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
			return m_BlurColor != Color.Empty;
		}

		void ResetBlurColor()
		{
			m_BlurColor = Color.Empty;
		}

		void set_ExtendFrame()
		{
			g.MARGINS margins = new g.MARGINS();
			margins.cxLeftWidth = m_ExtendFrame.Left;
			margins.cxRightWidth = m_ExtendFrame.Right;
			margins.cyTopHeight = m_ExtendFrame.Top;
			margins.cyBottomHeight = m_ExtendFrame.Bottom;
			try
			{
				g.DwmExtendFrameIntoClientArea(this.Handle, ref margins);
			}
			catch { }
		}

		/* See also:
		 * https://stackoverflow.com/questions/32724187/how-do-you-set-the-glass-blend-colour-on-windows-10
		 * http://undoc.airesoft.co.uk/user32.dll/SetWindowCompositionAttribute.php
		 * http://vhanla.codigobit.info/2015/07/enable-windows-10-aero-glass-aka-blur.html
		 * http://www.classicshell.net/forum/viewtopic.php?f=10&t=6444
		 */
		void set_BlurWin10()
		{
			g.AccentPolicy policy = new g.AccentPolicy();
			if (m_BlurWin10)
			{
				policy.AccentState = g.ACCENT_ENABLE_BLURBEHIND;
				policy.AccentFlags = g.AccentFlags.Unknown | (g.AccentFlags.DrawAllBorders & ~g.AccentFlags.DrawRightBorder);
				policy.AccentFlags = (g.AccentFlags.DrawAllBorders & ~g.AccentFlags.DrawRightBorder);
				policy.GradientColor = Color.FromArgb(0x80, m_BlurColor).ToArgb();
				//this.BackColor = Color.Black;
			}
			else
			{
				policy.AccentState = g.ACCENT_DISABLED;
			}
			g.WINCOMPATTRDATA data = new g.WINCOMPATTRDATA();
			data.attribute = g.WCA_ACCENT_POLICY;
			data.dataSize = Marshal.SizeOf(policy);
			data.pData = Marshal.AllocHGlobal(data.dataSize);
			if (data.pData != IntPtr.Zero)
			{
				Marshal.StructureToPtr(policy, data.pData, false);
				try
				{
					g.SetWindowCompositionAttribute(this.Handle, ref data);
				}
				catch { }
				Marshal.FreeHGlobal(data.pData);
			}
		}
	}
}
