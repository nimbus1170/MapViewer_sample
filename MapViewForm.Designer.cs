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
			this.toDrawTudeGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toDrawUTMGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.種類ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mapImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.photoImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mapPictureBox
			// 
			this.mapPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mapPictureBox.Location = new System.Drawing.Point(0, 24);
			this.mapPictureBox.Name = "mapPictureBox";
			this.mapPictureBox.Size = new System.Drawing.Size(624, 786);
			this.mapPictureBox.TabIndex = 1;
			this.mapPictureBox.TabStop = false;
			this.mapPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapPictureBox_MouseDown);
			this.mapPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapPictureBox_MouseMove);
			this.mapPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapPictureBox_MouseUp);
			// 
			// infoLabel
			// 
			this.infoLabel.AutoSize = true;
			this.infoLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.infoLabel.Location = new System.Drawing.Point(12, 36);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(60, 17);
			this.infoLabel.TabIndex = 2;
			this.infoLabel.Text = "infoLabel";
			this.infoLabel.UseCompatibleTextRendering = true;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.グリッドToolStripMenuItem,
            this.種類ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(624, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// グリッドToolStripMenuItem
			// 
			this.グリッドToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toDrawTudeGridToolStripMenuItem,
            this.toDrawUTMGridToolStripMenuItem});
			this.グリッドToolStripMenuItem.Name = "グリッドToolStripMenuItem";
			this.グリッドToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.グリッドToolStripMenuItem.Text = "グリッド";
			// 
			// toDrawTudeGridToolStripMenuItem
			// 
			this.toDrawTudeGridToolStripMenuItem.Checked = true;
			this.toDrawTudeGridToolStripMenuItem.CheckOnClick = true;
			this.toDrawTudeGridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toDrawTudeGridToolStripMenuItem.Name = "toDrawTudeGridToolStripMenuItem";
			this.toDrawTudeGridToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.toDrawTudeGridToolStripMenuItem.Text = "経緯度グリッド";
			this.toDrawTudeGridToolStripMenuItem.Click += new System.EventHandler(this.toDrawTudeGridToolStripMenuItem_Click);
			// 
			// toDrawUTMGridToolStripMenuItem
			// 
			this.toDrawUTMGridToolStripMenuItem.Checked = true;
			this.toDrawUTMGridToolStripMenuItem.CheckOnClick = true;
			this.toDrawUTMGridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toDrawUTMGridToolStripMenuItem.Name = "toDrawUTMGridToolStripMenuItem";
			this.toDrawUTMGridToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.toDrawUTMGridToolStripMenuItem.Text = "UTMグリッド";
			this.toDrawUTMGridToolStripMenuItem.Click += new System.EventHandler(this.toDrawUTMGridToolStripMenuItem_Click);
			// 
			// 種類ToolStripMenuItem
			// 
			this.種類ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapImageToolStripMenuItem,
            this.photoImageToolStripMenuItem});
			this.種類ToolStripMenuItem.Name = "種類ToolStripMenuItem";
			this.種類ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.種類ToolStripMenuItem.Text = "種類";
			// 
			// MapImageToolStripMenuItem
			// 
			this.mapImageToolStripMenuItem.Checked = true;
			this.mapImageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Indeterminate;
			this.mapImageToolStripMenuItem.Name = "MapImageToolStripMenuItem";
			this.mapImageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.mapImageToolStripMenuItem.Text = "地図画像";
			this.mapImageToolStripMenuItem.Click += new System.EventHandler(this.MapImageToolStripMenuItem_Click);
			// 
			// PhotoImageToolStripMenuItem
			// 
			this.photoImageToolStripMenuItem.Name = "PhotoImageToolStripMenuItem";
			this.photoImageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.photoImageToolStripMenuItem.Text = "衛星画像";
			this.photoImageToolStripMenuItem.Click += new System.EventHandler(this.PhotoImageToolStripMenuItem_Click);
			// 
			// CMapViewForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 810);
			this.Controls.Add(this.infoLabel);
			this.Controls.Add(this.mapPictureBox);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "CMapViewForm";
			this.Text = "NET_MapView_test";
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
        private System.Windows.Forms.ToolStripMenuItem toDrawTudeGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toDrawUTMGridToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 種類ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mapImageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem photoImageToolStripMenuItem;
	}
}

