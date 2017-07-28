using System.Windows.Forms;

namespace System.Windows.Forms
{
	[System.ComponentModel.DesignerCategory("Code")]
	public class HiddenForm : Form
	{
		public HiddenForm()
		{
			this.ClientSize = new System.Drawing.Size(0, 0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.ShowInTaskbar = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
		}
	}
}
