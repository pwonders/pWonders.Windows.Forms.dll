using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.Forms
{
	[System.ComponentModel.DesignerCategory("Code")]
	public class VTextBox : TextBox
	{
		public VTextBox()
		{
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
		}
	}
}
