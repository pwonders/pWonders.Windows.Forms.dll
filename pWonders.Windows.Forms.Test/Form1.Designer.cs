namespace pWonders.Windows.Forms.Test
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnClose = new System.Windows.Forms.Button();
			this.btnToggleBlur = new System.Windows.Forms.Button();
			this.btnToggleVisible = new System.Windows.Forms.Button();
			this.btnToggleSIze = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.AutoSize = true;
			this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnClose.Location = new System.Drawing.Point(608, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(32, 36);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "X";
			this.btnClose.UseCompatibleTextRendering = true;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnToggleBlur
			// 
			this.btnToggleBlur.AutoSize = true;
			this.btnToggleBlur.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnToggleBlur.Location = new System.Drawing.Point(0, 0);
			this.btnToggleBlur.Name = "btnToggleBlur";
			this.btnToggleBlur.Size = new System.Drawing.Size(175, 36);
			this.btnToggleBlur.TabIndex = 1;
			this.btnToggleBlur.Text = "Toggle Blur";
			this.btnToggleBlur.UseCompatibleTextRendering = true;
			this.btnToggleBlur.UseVisualStyleBackColor = true;
			this.btnToggleBlur.Click += new System.EventHandler(this.btnToggleBlur_Click);
			// 
			// btnToggleVisible
			// 
			this.btnToggleVisible.AutoSize = true;
			this.btnToggleVisible.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnToggleVisible.Location = new System.Drawing.Point(0, 41);
			this.btnToggleVisible.Name = "btnToggleVisible";
			this.btnToggleVisible.Size = new System.Drawing.Size(218, 36);
			this.btnToggleVisible.TabIndex = 2;
			this.btnToggleVisible.Text = "Toggle Visible";
			this.btnToggleVisible.UseCompatibleTextRendering = true;
			this.btnToggleVisible.UseVisualStyleBackColor = true;
			this.btnToggleVisible.Click += new System.EventHandler(this.btnToggleVisible_Click);
			// 
			// btnToggleSIze
			// 
			this.btnToggleSIze.AutoSize = true;
			this.btnToggleSIze.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnToggleSIze.Location = new System.Drawing.Point(0, 82);
			this.btnToggleSIze.Name = "btnToggleSIze";
			this.btnToggleSIze.Size = new System.Drawing.Size(175, 36);
			this.btnToggleSIze.TabIndex = 3;
			this.btnToggleSIze.Text = "Toggle Size";
			this.btnToggleSIze.UseCompatibleTextRendering = true;
			this.btnToggleSIze.UseVisualStyleBackColor = true;
			this.btnToggleSIze.Click += new System.EventHandler(this.btnToggleSize_Click);
			// 
			// Form1
			// 
			this.AllowDragClient = true;
			this.ClientSize = new System.Drawing.Size(640, 480);
			this.Controls.Add(this.btnToggleSIze);
			this.Controls.Add(this.btnToggleVisible);
			this.Controls.Add(this.btnToggleBlur);
			this.Controls.Add(this.btnClose);
			this.Font = new System.Drawing.Font("Lucida Console", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnToggleBlur;
		private System.Windows.Forms.Button btnToggleVisible;
		private System.Windows.Forms.Button btnToggleSIze;
	}
}

