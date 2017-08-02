using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace pWonders.Windows.Forms.Test
{
	public partial class Form1 : VForm
	{
		public Form1()
		{
			InitializeComponent();

			bool frame = false;
			if (frame)
			{
				this.FormBorderStyle = FormBorderStyle.Sizable;
			}

			//this.DoubleBuffered = true;
			this.BlurBorder = AccentBorder.All;
			this.BlurColor = UIColor.ShellWithTransparency;
			this.BlurWin10 = true;
			//this.Opacity = 254 / 255.0;

			tmrv = new Timer();
			tmrv.Interval = 1000;
			tmrv.Tick += tmrv_Tick;

			tmrs = new Timer();
			tmrs.Interval = 100;
			tmrs.Tick += tmrs_Tick;
		}

		Timer tmrv, tmrs;

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnToggleBlur_Click(object sender, EventArgs e)
		{
			this.BlurWin10 = !this.BlurWin10;
			if (this.BlurWin10 == false)
			{
				this.BackColor = SystemColors.Control;
			}
		}

		private void btnToggleVisible_Click(object sender, EventArgs e)
		{
			this.Width = 0;
			this.Visible = false;
			tmrv.Enabled = true;
		}

		private void tmrv_Tick(object sender, EventArgs e)
		{
			tmrv.Enabled = false;
			this.Visible = true;
			this.Width = 640;
		}

		private void btnToggleSize_Click(object sender, EventArgs e)
		{
			base.OnResizeBegin(e);
			tmrs.Enabled = true;
		}

		private void tmrs_Tick(object sender, EventArgs e)
		{
			this.Width += 32;
			if (this.Width > 1000)
			{
				tmrs.Enabled = false;
				base.OnResizeEnd(e);
			}
		}
	}
}
