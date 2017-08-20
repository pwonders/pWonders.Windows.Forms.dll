using System.ComponentModel;
using System.Drawing;
using Microsoft.Win32;

namespace System.Windows.Forms
{
	[System.ComponentModel.DesignerCategory("Code")]
	public class VTableLayoutPanel : TableLayoutPanel
	{
		public VTableLayoutPanel()
		{
		}

		public override Color BackColor
		{
			set
			{
				base.BackColor = value;
				if (value == Color.Transparent)
				{
					if (m_FixTransparency)
					{
						this.UpdateStyles();
					}
				}
			}
			get { return base.BackColor; }
		}

		[DefaultValue(false)]
		public bool FixTransparency
		{
			set
			{
				if (m_FixTransparency != value)
				{
					m_FixTransparency = value;
					if (this.BackColor == Color.Transparent)
					{
						this.UpdateStyles();
					}
				}
			}
			get { return m_FixTransparency; }
		}

		bool m_FixTransparency;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				if (m_FixTransparency)
				{
					cp.ExStyle |= API.WS_EX_TRANSPARENT;
				}
				return cp;
			}
		}
	}
}
