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
			this.BackColor = Color.FromArgb(0xff, UIColor.ShellWithTransparency);
			this.BackColor = Color.FromArgb(0xff, Color.Black);
			this.BlurColor = UIColor.ShellWithTransparency;
			this.BlurBorder = AccentBorder.All;
			this.BlurWin10 = true;
			this.Opacity = 254 / 255.0;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
