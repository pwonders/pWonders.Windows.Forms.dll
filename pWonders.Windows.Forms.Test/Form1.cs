using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
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
			this.Opacity = 254 / 255.0;

			tmrv = new Timer();
			tmrv.Interval = 1000;
			tmrv.Tick += tmrv_Tick;

			tmrs = new Timer();
			tmrs.Interval = 100;
			tmrs.Tick += tmrs_Tick;

			tmrp = new Timer();
			tmrp.Interval = 100;
			tmrp.Tick += tmrp_Tick;

			//btnTogglePos.PerformClick();
			btnTogglePos_Click(btnTogglePos, EventArgs.Empty);
		}

		Timer tmrv, tmrs, tmrp;

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			return;
			// Ugly text when using gradient color to blur.

			Graphics g = e.Graphics;
			g.CompositingQuality = CompositingQuality.HighQuality;
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
			g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

			string s = "The quick brown fox";
			PointF ptf = new PointF(160, 16);
			Color c = Color.FromArgb(0xfe, Color.White);
			using (Font font = new Font(this.Font.FontFamily, 20))
			using (SolidBrush br = new SolidBrush(c))
			{
				for (int i = 0; i < 4; i++, ptf.Y += 64)
				{
					Point pt = new Point((int) ptf.X, (int) ptf.Y);
					Rectangle bounds = new Rectangle(pt, new Size(300, 100));
					switch (i)
					{
					case 0:
						g.DrawString(s, font, br, ptf);
						break;
					case 1:
						using (GraphicsPath path = new GraphicsPath())
						{
							path.AddString(s, font.FontFamily, (int) font.Style, font.Size * g.DpiY / 72, ptf, StringFormat.GenericDefault);
							g.FillPath(br, path);
						}
						break;
					case 2:
						Size size = TextRenderer.MeasureText(s, font);
						using (Bitmap bmp = new Bitmap(size.Width, size.Height))
						{
							Color cbg = Color.FromArgb(0xff, 0, 0, 0);
							using (Graphics gb = Graphics.FromImage(bmp))
							{
								gb.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
								gb.Clear(cbg);
								TextRenderer.DrawText(gb, s, font, Point.Empty, c);
							}
							for (int y = 0; y < size.Height; y++)
							{
								for (int x = 0; x < size.Width; x++)
								{
									if (bmp.GetPixel(x, y) == cbg)
									{
										bmp.SetPixel(x, y, Color.Transparent);
									}
								}
							}
							g.DrawImage(bmp, pt);
						}
						break;
					case 3:
						VisualStyleRenderer renderer = new VisualStyleRenderer(VisualStyleElement.StartPanel.ProgList.Normal);
						Rectangle r = renderer.GetTextExtent(g, s, TextFormatFlags.Default);
						r.Offset(pt);
						renderer.DrawText(g, r, s);
						break;
					}
				}
			}
		}

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
			//this.SetBounds(0, 0, 640, 480, BoundsSpecified.Size);
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

		private void btnTogglePos_Click(object sender, EventArgs e)
		{
			Rectangle r = Screen.PrimaryScreen.WorkingArea;
			r.X = r.Right;
			r.Width = 630;
			this.Bounds = r;
			tmrp.Enabled = true;
		}

		private void tmrp_Tick(object sender, EventArgs e)
		{
			this.Left -= 32;
			if (this.Right <= Screen.PrimaryScreen.WorkingArea.Right)
			{
				tmrp.Enabled = false;
			}
		}
	}
}
