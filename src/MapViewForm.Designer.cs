namespace MapView_test
{
	partial class CMapViewForm
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			mapPictureBox = new System.Windows.Forms.PictureBox();
			infoLabel = new System.Windows.Forms.Label();
			menuStrip1 = new System.Windows.Forms.MenuStrip();
			グリッドToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toDrawLgLtGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toDrawUTMGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			種類ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			mapImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			photoImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			mouseLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)mapPictureBox).BeginInit();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// mapPictureBox
			// 
			mapPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			mapPictureBox.Location = new System.Drawing.Point(0, 37);
			mapPictureBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			mapPictureBox.Name = "mapPictureBox";
			mapPictureBox.Size = new System.Drawing.Size(1002, 675);
			mapPictureBox.TabIndex = 1;
			mapPictureBox.TabStop = false;
			mapPictureBox.MouseDown += MapPictureBox_MouseDown;
			mapPictureBox.MouseEnter += MapPictureBox_MouseEnter;
			mapPictureBox.MouseLeave += MapPictureBox_MouseLeave;
			mapPictureBox.MouseMove += MapPictureBox_MouseMove;
			mapPictureBox.MouseUp += MapPictureBox_MouseUp;
			// 
			// infoLabel
			// 
			infoLabel.AutoSize = true;
			infoLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			infoLabel.Location = new System.Drawing.Point(59, 115);
			infoLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			infoLabel.Name = "infoLabel";
			infoLabel.Size = new System.Drawing.Size(90, 24);
			infoLabel.TabIndex = 2;
			infoLabel.Text = "infoLabel";
			infoLabel.UseCompatibleTextRendering = true;
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { グリッドToolStripMenuItem, 種類ToolStripMenuItem });
			menuStrip1.Location = new System.Drawing.Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Padding = new System.Windows.Forms.Padding(10, 4, 0, 4);
			menuStrip1.Size = new System.Drawing.Size(1002, 37);
			menuStrip1.TabIndex = 4;
			menuStrip1.Text = "menuStrip1";
			// 
			// グリッドToolStripMenuItem
			// 
			グリッドToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toDrawLgLtGridToolStripMenuItem, toDrawUTMGridToolStripMenuItem });
			グリッドToolStripMenuItem.Name = "グリッドToolStripMenuItem";
			グリッドToolStripMenuItem.Size = new System.Drawing.Size(79, 29);
			グリッドToolStripMenuItem.Text = "グリッド";
			// 
			// toDrawLgLtGridToolStripMenuItem
			// 
			toDrawLgLtGridToolStripMenuItem.Checked = true;
			toDrawLgLtGridToolStripMenuItem.CheckOnClick = true;
			toDrawLgLtGridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			toDrawLgLtGridToolStripMenuItem.Name = "toDrawLgLtGridToolStripMenuItem";
			toDrawLgLtGridToolStripMenuItem.Size = new System.Drawing.Size(219, 34);
			toDrawLgLtGridToolStripMenuItem.Text = "経緯度グリッド";
			toDrawLgLtGridToolStripMenuItem.Click += ToDrawLgLtGridToolStripMenuItem_Click;
			// 
			// toDrawUTMGridToolStripMenuItem
			// 
			toDrawUTMGridToolStripMenuItem.Checked = true;
			toDrawUTMGridToolStripMenuItem.CheckOnClick = true;
			toDrawUTMGridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			toDrawUTMGridToolStripMenuItem.Name = "toDrawUTMGridToolStripMenuItem";
			toDrawUTMGridToolStripMenuItem.Size = new System.Drawing.Size(219, 34);
			toDrawUTMGridToolStripMenuItem.Text = "UTMグリッド";
			toDrawUTMGridToolStripMenuItem.Click += ToDrawUTMGridToolStripMenuItem_Click;
			// 
			// 種類ToolStripMenuItem
			// 
			種類ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mapImageToolStripMenuItem, photoImageToolStripMenuItem });
			種類ToolStripMenuItem.Name = "種類ToolStripMenuItem";
			種類ToolStripMenuItem.Size = new System.Drawing.Size(64, 29);
			種類ToolStripMenuItem.Text = "種類";
			// 
			// mapImageToolStripMenuItem
			// 
			mapImageToolStripMenuItem.Checked = true;
			mapImageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Indeterminate;
			mapImageToolStripMenuItem.Name = "mapImageToolStripMenuItem";
			mapImageToolStripMenuItem.Size = new System.Drawing.Size(186, 34);
			mapImageToolStripMenuItem.Text = "地図画像";
			mapImageToolStripMenuItem.Click += MapImageToolStripMenuItem_Click;
			// 
			// photoImageToolStripMenuItem
			// 
			photoImageToolStripMenuItem.Name = "photoImageToolStripMenuItem";
			photoImageToolStripMenuItem.Size = new System.Drawing.Size(186, 34);
			photoImageToolStripMenuItem.Text = "衛星画像";
			photoImageToolStripMenuItem.Click += PhotoImageToolStripMenuItem_Click;
			// 
			// mouseLabel
			// 
			mouseLabel.AutoSize = true;
			mouseLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			mouseLabel.Location = new System.Drawing.Point(472, 300);
			mouseLabel.Name = "mouseLabel";
			mouseLabel.Size = new System.Drawing.Size(62, 18);
			mouseLabel.TabIndex = 5;
			mouseLabel.Text = "label1";
			mouseLabel.Visible = false;
			// 
			// CMapViewForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(1002, 712);
			Controls.Add(mouseLabel);
			Controls.Add(infoLabel);
			Controls.Add(mapPictureBox);
			Controls.Add(menuStrip1);
			DoubleBuffered = true;
			MainMenuStrip = menuStrip1;
			Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			Name = "CMapViewForm";
			Text = "MapViewer_sample";
			Resize += CMapForm_Resize;
			((System.ComponentModel.ISupportInitialize)mapPictureBox).EndInit();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private System.Windows.Forms.PictureBox mapPictureBox;
		private System.Windows.Forms.Label infoLabel;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem グリッドToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toDrawLgLtGridToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toDrawUTMGridToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 種類ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mapImageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem photoImageToolStripMenuItem;
		private System.Windows.Forms.Label mouseLabel;
	}
}
