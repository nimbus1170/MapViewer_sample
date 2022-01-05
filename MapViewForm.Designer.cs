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
            if(disposing && (components != null))
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
			this.mapPictureBox = new System.Windows.Forms.PictureBox();
			this.infoLabel = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.グリッドToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toDrawLgLtGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toDrawUTMGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.種類ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mapImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.photoImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mouseLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mapPictureBox
			// 
			this.mapPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mapPictureBox.Location = new System.Drawing.Point(0, 36);
			this.mapPictureBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.mapPictureBox.Name = "mapPictureBox";
			this.mapPictureBox.Size = new System.Drawing.Size(1040, 1179);
			this.mapPictureBox.TabIndex = 1;
			this.mapPictureBox.TabStop = false;
			this.mapPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapPictureBox_MouseDown);
			this.mapPictureBox.MouseEnter += new System.EventHandler(this.mapPictureBox_MouseEnter);
			this.mapPictureBox.MouseLeave += new System.EventHandler(this.mapPictureBox_MouseLeave);
			this.mapPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapPictureBox_MouseMove);
			this.mapPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapPictureBox_MouseUp);
			// 
			// infoLabel
			// 
			this.infoLabel.AutoSize = true;
			this.infoLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.infoLabel.Location = new System.Drawing.Point(20, 54);
			this.infoLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(90, 24);
			this.infoLabel.TabIndex = 2;
			this.infoLabel.Text = "infoLabel";
			this.infoLabel.UseCompatibleTextRendering = true;
			// 
			// menuStrip1
			// 
			this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.グリッドToolStripMenuItem,
            this.種類ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
			this.menuStrip1.Size = new System.Drawing.Size(1040, 36);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// グリッドToolStripMenuItem
			// 
			this.グリッドToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toDrawLgLtGridToolStripMenuItem,
            this.toDrawUTMGridToolStripMenuItem});
			this.グリッドToolStripMenuItem.Name = "グリッドToolStripMenuItem";
			this.グリッドToolStripMenuItem.Size = new System.Drawing.Size(80, 30);
			this.グリッドToolStripMenuItem.Text = "グリッド";
			// 
			// toDrawLgLtGridToolStripMenuItem
			// 
			this.toDrawLgLtGridToolStripMenuItem.Checked = true;
			this.toDrawLgLtGridToolStripMenuItem.CheckOnClick = true;
			this.toDrawLgLtGridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toDrawLgLtGridToolStripMenuItem.Name = "toDrawLgLtGridToolStripMenuItem";
			this.toDrawLgLtGridToolStripMenuItem.Size = new System.Drawing.Size(220, 34);
			this.toDrawLgLtGridToolStripMenuItem.Text = "経緯度グリッド";
			this.toDrawLgLtGridToolStripMenuItem.Click += new System.EventHandler(this.ToDrawLgLtGridToolStripMenuItem_Click);
			// 
			// toDrawUTMGridToolStripMenuItem
			// 
			this.toDrawUTMGridToolStripMenuItem.Checked = true;
			this.toDrawUTMGridToolStripMenuItem.CheckOnClick = true;
			this.toDrawUTMGridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toDrawUTMGridToolStripMenuItem.Name = "toDrawUTMGridToolStripMenuItem";
			this.toDrawUTMGridToolStripMenuItem.Size = new System.Drawing.Size(220, 34);
			this.toDrawUTMGridToolStripMenuItem.Text = "UTMグリッド";
			this.toDrawUTMGridToolStripMenuItem.Click += new System.EventHandler(this.ToDrawUTMGridToolStripMenuItem_Click);
			// 
			// 種類ToolStripMenuItem
			// 
			this.種類ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapImageToolStripMenuItem,
            this.photoImageToolStripMenuItem});
			this.種類ToolStripMenuItem.Name = "種類ToolStripMenuItem";
			this.種類ToolStripMenuItem.Size = new System.Drawing.Size(64, 30);
			this.種類ToolStripMenuItem.Text = "種類";
			// 
			// mapImageToolStripMenuItem
			// 
			this.mapImageToolStripMenuItem.Checked = true;
			this.mapImageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Indeterminate;
			this.mapImageToolStripMenuItem.Name = "mapImageToolStripMenuItem";
			this.mapImageToolStripMenuItem.Size = new System.Drawing.Size(186, 34);
			this.mapImageToolStripMenuItem.Text = "地図画像";
			this.mapImageToolStripMenuItem.Click += new System.EventHandler(this.MapImageToolStripMenuItem_Click);
			// 
			// photoImageToolStripMenuItem
			// 
			this.photoImageToolStripMenuItem.Name = "photoImageToolStripMenuItem";
			this.photoImageToolStripMenuItem.Size = new System.Drawing.Size(186, 34);
			this.photoImageToolStripMenuItem.Text = "衛星画像";
			this.photoImageToolStripMenuItem.Click += new System.EventHandler(this.PhotoImageToolStripMenuItem_Click);
			// 
			// mouseLabel
			// 
			this.mouseLabel.AutoSize = true;
			this.mouseLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.mouseLabel.Location = new System.Drawing.Point(472, 216);
			this.mouseLabel.Name = "mouseLabel";
			this.mouseLabel.Size = new System.Drawing.Size(62, 18);
			this.mouseLabel.TabIndex = 5;
			this.mouseLabel.Text = "label1";
			this.mouseLabel.Visible = false;
			// 
			// CMapViewForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1040, 1215);
			this.Controls.Add(this.mouseLabel);
			this.Controls.Add(this.infoLabel);
			this.Controls.Add(this.mapPictureBox);
			this.Controls.Add(this.menuStrip1);
			this.DoubleBuffered = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.Name = "CMapViewForm";
			this.Text = "MapViewer_sample";
			this.Resize += new System.EventHandler(this.CMapForm_Resize);
			((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

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
