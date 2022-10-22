namespace TmWinForms
{
    partial class FxTreeview
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxTreeview));
      this.PnTreeview = new Telerik.WinControls.UI.RadPanel();
      this.TvMain = new Telerik.WinControls.UI.RadTreeView();
      this.PvTreeview = new Telerik.WinControls.UI.RadPageView();
      this.PageEmpty = new Telerik.WinControls.UI.RadPageViewPage();
      this.SplitterMainVertical = new System.Windows.Forms.Splitter();
      this.PicItem = new System.Windows.Forms.PictureBox();
      this.PicGroup = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.PnTreeview)).BeginInit();
      this.PnTreeview.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TvMain)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PvTreeview)).BeginInit();
      this.PvTreeview.SuspendLayout();
      this.PageEmpty.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PicItem)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PicGroup)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // PnTreeview
      // 
      this.PnTreeview.Controls.Add(this.TvMain);
      this.PnTreeview.Location = new System.Drawing.Point(12, 16);
      this.PnTreeview.Name = "PnTreeview";
      this.PnTreeview.Padding = new System.Windows.Forms.Padding(1);
      this.PnTreeview.Size = new System.Drawing.Size(317, 629);
      this.PnTreeview.TabIndex = 8;
      // 
      // TvMain
      // 
      this.TvMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
      this.TvMain.Cursor = System.Windows.Forms.Cursors.Default;
      this.TvMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TvMain.Font = new System.Drawing.Font("Verdana", 9F);
      this.TvMain.ForeColor = System.Drawing.Color.Black;
      this.TvMain.HotTracking = false;
      this.TvMain.ItemHeight = 30;
      this.TvMain.LineStyle = Telerik.WinControls.UI.TreeLineStyle.Solid;
      this.TvMain.Location = new System.Drawing.Point(1, 1);
      this.TvMain.Name = "TvMain";
      this.TvMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.TvMain.ShowLines = true;
      this.TvMain.ShowRootLines = false;
      this.TvMain.Size = new System.Drawing.Size(315, 627);
      this.TvMain.SpacingBetweenNodes = -1;
      this.TvMain.TabIndex = 1;
      this.TvMain.TreeIndent = 35;
      // 
      // PvTreeview
      // 
      this.PvTreeview.Controls.Add(this.PageEmpty);
      this.PvTreeview.Font = new System.Drawing.Font("Verdana", 10F);
      this.PvTreeview.Location = new System.Drawing.Point(397, 16);
      this.PvTreeview.Name = "PvTreeview";
      this.PvTreeview.SelectedPage = this.PageEmpty;
      this.PvTreeview.Size = new System.Drawing.Size(758, 629);
      this.PvTreeview.TabIndex = 9;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PvTreeview.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PvTreeview.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(1);
      ((Telerik.WinControls.UI.StripViewItemContainer)(this.PvTreeview.GetChildAt(0).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0);
      // 
      // PageEmpty
      // 
      this.PageEmpty.Controls.Add(this.PicItem);
      this.PageEmpty.Controls.Add(this.PicGroup);
      this.PageEmpty.ItemSize = new System.Drawing.SizeF(99F, 30F);
      this.PageEmpty.Location = new System.Drawing.Point(6, 35);
      this.PageEmpty.Name = "PageEmpty";
      this.PageEmpty.Size = new System.Drawing.Size(746, 588);
      this.PageEmpty.Text = "Page Empty";
      // 
      // SplitterMainVertical
      // 
      this.SplitterMainVertical.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.SplitterMainVertical.Location = new System.Drawing.Point(0, 760);
      this.SplitterMainVertical.Name = "SplitterMainVertical";
      this.SplitterMainVertical.Size = new System.Drawing.Size(1192, 10);
      this.SplitterMainVertical.TabIndex = 10;
      this.SplitterMainVertical.TabStop = false;
      // 
      // PicItem
      // 
      this.PicItem.Image = ((System.Drawing.Image)(resources.GetObject("PicItem.Image")));
      this.PicItem.Location = new System.Drawing.Point(112, 52);
      this.PicItem.Name = "PicItem";
      this.PicItem.Size = new System.Drawing.Size(50, 50);
      this.PicItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.PicItem.TabIndex = 1;
      this.PicItem.TabStop = false;
      this.PicItem.Visible = false;
      // 
      // PicGroup
      // 
      this.PicGroup.Image = ((System.Drawing.Image)(resources.GetObject("PicGroup.Image")));
      this.PicGroup.Location = new System.Drawing.Point(33, 52);
      this.PicGroup.Name = "PicGroup";
      this.PicGroup.Size = new System.Drawing.Size(50, 50);
      this.PicGroup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.PicGroup.TabIndex = 2;
      this.PicGroup.TabStop = false;
      this.PicGroup.Visible = false;
      // 
      // FxTreeview
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1192, 770);
      this.ControlBox = false;
      this.Controls.Add(this.SplitterMainVertical);
      this.Controls.Add(this.PvTreeview);
      this.Controls.Add(this.PnTreeview);
      this.Name = "FxTreeview";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.ShowInTaskbar = false;
      this.Text = "";
      ((System.ComponentModel.ISupportInitialize)(this.PnTreeview)).EndInit();
      this.PnTreeview.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.TvMain)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PvTreeview)).EndInit();
      this.PvTreeview.ResumeLayout(false);
      this.PageEmpty.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.PicItem)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PicGroup)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

        }

    #endregion

    public Telerik.WinControls.UI.RadPanel PnTreeview;
    public Telerik.WinControls.UI.RadTreeView TvMain;
    public Telerik.WinControls.UI.RadPageView PvTreeview;
    public Telerik.WinControls.UI.RadPageViewPage PageEmpty;
    public System.Windows.Forms.PictureBox PicItem;
    public System.Windows.Forms.PictureBox PicGroup;
    public System.Windows.Forms.Splitter SplitterMainVertical;
  }
}
