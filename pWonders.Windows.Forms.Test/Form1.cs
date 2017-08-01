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
				this.FormBorderStyle = FormBorderStyle.FixedSingle;
				this.MinimizeBox = true;
				this.MaximizeBox = false;
			}

			this.BlurBorder = AccentBorder.Left;
			this.BlurColor = UIColor.ShellWithTransparency;
			this.BlurWin10 = true;
			this.Opacity = 254 / 255.0;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
