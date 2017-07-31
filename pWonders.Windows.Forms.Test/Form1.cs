using System;
using System.Windows.Forms;

namespace pWonders.Windows.Forms.Test
{
	public partial class Form1 : VForm
	{
		public Form1()
		{
			InitializeComponent();
			this.Opacity = 0.9961;
		}

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
