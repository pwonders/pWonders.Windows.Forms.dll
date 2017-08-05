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
			this.btnTogglePos = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.AutoSize = true;
			this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnClose.Location = new System.Drawing.Point(610, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(30, 34);
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
			this.btnToggleBlur.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnToggleBlur.Location = new System.Drawing.Point(3, 3);
			this.btnToggleBlur.Name = "btnToggleBlur";
			this.btnToggleBlur.Size = new System.Drawing.Size(140, 34);
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
			this.btnToggleVisible.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnToggleVisible.Location = new System.Drawing.Point(3, 43);
			this.btnToggleVisible.Name = "btnToggleVisible";
			this.btnToggleVisible.Size = new System.Drawing.Size(140, 34);
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
			this.btnToggleSIze.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnToggleSIze.Location = new System.Drawing.Point(3, 83);
			this.btnToggleSIze.Name = "btnToggleSIze";
			this.btnToggleSIze.Size = new System.Drawing.Size(140, 34);
			this.btnToggleSIze.TabIndex = 3;
			this.btnToggleSIze.Text = "Toggle Size";
			this.btnToggleSIze.UseCompatibleTextRendering = true;
			this.btnToggleSIze.UseVisualStyleBackColor = true;
			this.btnToggleSIze.Click += new System.EventHandler(this.btnToggleSize_Click);
			// 
			// btnTogglePos
			// 
			this.btnTogglePos.AutoSize = true;
			this.btnTogglePos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnTogglePos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnTogglePos.Location = new System.Drawing.Point(3, 123);
			this.btnTogglePos.Name = "btnTogglePos";
			this.btnTogglePos.Size = new System.Drawing.Size(140, 34);
			this.btnTogglePos.TabIndex = 4;
			this.btnTogglePos.Text = "Toggle Pos";
			this.btnTogglePos.UseCompatibleTextRendering = true;
			this.btnTogglePos.UseVisualStyleBackColor = true;
			this.btnTogglePos.Click += new System.EventHandler(this.btnTogglePos_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.btnTogglePos, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.btnToggleBlur, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnToggleSIze, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.btnToggleVisible, 0, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(146, 160);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// Form1
			// 
			this.AllowDragClient = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(640, 480);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.btnClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Form1";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnToggleBlur;
		private System.Windows.Forms.Button btnToggleVisible;
		private System.Windows.Forms.Button btnToggleSIze;
		private System.Windows.Forms.Button btnTogglePos;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}

