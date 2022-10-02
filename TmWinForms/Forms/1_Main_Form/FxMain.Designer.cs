namespace TmWinForms
{
    partial class FxMain
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
      this.MainFormMenu = new Telerik.WinControls.UI.RadMenu();
      this.MenuItemFirstItem = new Telerik.WinControls.UI.RadMenuItem();
      this.PnMainTop = new Telerik.WinControls.UI.RadPanel();
      this.SplitterMainHorizontal = new System.Windows.Forms.Splitter();
      this.PnMainSide = new Telerik.WinControls.UI.RadPanel();
      this.SplitterMainVertical = new System.Windows.Forms.Splitter();
      this.PvMain = new Telerik.WinControls.UI.RadPageView();
      this.PageFirst = new Telerik.WinControls.UI.RadPageViewPage();
      this.PageLog = new Telerik.WinControls.UI.RadPageViewPage();
      this.PageSettings = new Telerik.WinControls.UI.RadPageViewPage();
      this.PageAbout = new Telerik.WinControls.UI.RadPageViewPage();
      this.PageExit = new Telerik.WinControls.UI.RadPageViewPage();
      ((System.ComponentModel.ISupportInitialize)(this.MainFormMenu)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PnMainTop)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PnMainSide)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PvMain)).BeginInit();
      this.PvMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // MainFormMenu
      // 
      this.MainFormMenu.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.MainFormMenu.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.MenuItemFirstItem});
      this.MainFormMenu.Location = new System.Drawing.Point(0, 0);
      this.MainFormMenu.Name = "MainFormMenu";
      this.MainFormMenu.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
      this.MainFormMenu.Size = new System.Drawing.Size(1192, 28);
      this.MainFormMenu.TabIndex = 1;
      this.MainFormMenu.Visible = false;
      // 
      // MenuItemFirstItem
      // 
      this.MenuItemFirstItem.Name = "MenuItemFirstItem";
      this.MenuItemFirstItem.Padding = new System.Windows.Forms.Padding(15, 1, 15, 1);
      this.MenuItemFirstItem.Text = "Main menu";
      this.MenuItemFirstItem.UseCompatibleTextRendering = false;
      // 
      // PnMainTop
      // 
      this.PnMainTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.PnMainTop.Location = new System.Drawing.Point(0, 28);
      this.PnMainTop.Name = "PnMainTop";
      this.PnMainTop.Size = new System.Drawing.Size(1192, 35);
      this.PnMainTop.TabIndex = 2;
      this.PnMainTop.Visible = false;
      // 
      // SplitterMainHorizontal
      // 
      this.SplitterMainHorizontal.Dock = System.Windows.Forms.DockStyle.Top;
      this.SplitterMainHorizontal.Location = new System.Drawing.Point(0, 63);
      this.SplitterMainHorizontal.Name = "SplitterMainHorizontal";
      this.SplitterMainHorizontal.Size = new System.Drawing.Size(1192, 5);
      this.SplitterMainHorizontal.TabIndex = 3;
      this.SplitterMainHorizontal.TabStop = false;
      this.SplitterMainHorizontal.Visible = false;
      // 
      // PnMainSide
      // 
      this.PnMainSide.Dock = System.Windows.Forms.DockStyle.Left;
      this.PnMainSide.Location = new System.Drawing.Point(0, 68);
      this.PnMainSide.Name = "PnMainSide";
      this.PnMainSide.Size = new System.Drawing.Size(45, 702);
      this.PnMainSide.TabIndex = 4;
      this.PnMainSide.Visible = false;
      ((Telerik.WinControls.Primitives.FillPrimitive)(this.PnMainSide.GetChildAt(0).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0);
      ((Telerik.WinControls.Primitives.BorderPrimitive)(this.PnMainSide.GetChildAt(0).GetChildAt(1))).Padding = new System.Windows.Forms.Padding(0);
      // 
      // SplitterMainVertical
      // 
      this.SplitterMainVertical.Location = new System.Drawing.Point(45, 68);
      this.SplitterMainVertical.Name = "SplitterMainVertical";
      this.SplitterMainVertical.Size = new System.Drawing.Size(5, 702);
      this.SplitterMainVertical.TabIndex = 5;
      this.SplitterMainVertical.TabStop = false;
      this.SplitterMainVertical.Visible = false;
      // 
      // PvMain
      // 
      this.PvMain.Controls.Add(this.PageFirst);
      this.PvMain.Controls.Add(this.PageLog);
      this.PvMain.Controls.Add(this.PageSettings);
      this.PvMain.Controls.Add(this.PageAbout);
      this.PvMain.Controls.Add(this.PageExit);
      this.PvMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PvMain.Font = new System.Drawing.Font("Verdana", 10F);
      this.PvMain.Location = new System.Drawing.Point(50, 68);
      this.PvMain.Name = "PvMain";
      this.PvMain.SelectedPage = this.PageFirst;
      this.PvMain.Size = new System.Drawing.Size(1142, 702);
      this.PvMain.TabIndex = 6;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PvMain.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PvMain.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(1);
      ((Telerik.WinControls.UI.StripViewItemContainer)(this.PvMain.GetChildAt(0).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0);
      // 
      // PgFirst
      // 
      this.PageFirst.ItemSize = new System.Drawing.SizeF(64F, 30F);
      this.PageFirst.Location = new System.Drawing.Point(6, 35);
      this.PageFirst.Name = "PgFirst";
      this.PageFirst.Size = new System.Drawing.Size(1130, 661);
      this.PageFirst.Text = "Page 1";
      // 
      // PageLog
      // 
      this.PageLog.ItemSize = new System.Drawing.SizeF(83F, 30F);
      this.PageLog.Location = new System.Drawing.Point(6, 35);
      this.PageLog.Name = "PageLog";
      this.PageLog.Size = new System.Drawing.Size(1045, 660);
      this.PageLog.Text = "Messages";
      // 
      // PageSettings
      // 
      this.PageSettings.ItemSize = new System.Drawing.SizeF(74F, 30F);
      this.PageSettings.Location = new System.Drawing.Point(6, 35);
      this.PageSettings.Name = "PageSettings";
      this.PageSettings.Size = new System.Drawing.Size(1045, 660);
      this.PageSettings.Text = "Settings";
      // 
      // PageAbout
      // 
      this.PageAbout.ItemSize = new System.Drawing.SizeF(121F, 30F);
      this.PageAbout.Location = new System.Drawing.Point(6, 35);
      this.PageAbout.Name = "PageAbout";
      this.PageAbout.Size = new System.Drawing.Size(1045, 660);
      this.PageAbout.Text = "About Program";
      // 
      // PageExit
      // 
      this.PageExit.ItemSize = new System.Drawing.SizeF(43F, 30F);
      this.PageExit.Location = new System.Drawing.Point(6, 35);
      this.PageExit.Name = "PageExit";
      this.PageExit.Size = new System.Drawing.Size(1045, 660);
      this.PageExit.Text = "Exit";
      // 
      // FxMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1192, 770);
      this.Controls.Add(this.PvMain);
      this.Controls.Add(this.SplitterMainVertical);
      this.Controls.Add(this.PnMainSide);
      this.Controls.Add(this.SplitterMainHorizontal);
      this.Controls.Add(this.PnMainTop);
      this.Controls.Add(this.MainFormMenu);
      this.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.Name = "FxMain";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "";
      ((System.ComponentModel.ISupportInitialize)(this.MainFormMenu)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PnMainTop)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PnMainSide)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PvMain)).EndInit();
      this.PvMain.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

    #endregion

    public Telerik.WinControls.UI.RadMenu MainFormMenu;
    public Telerik.WinControls.UI.RadMenuItem MenuItemFirstItem;
    public Telerik.WinControls.UI.RadPanel PnMainTop;
    public System.Windows.Forms.Splitter SplitterMainHorizontal;
    public Telerik.WinControls.UI.RadPanel PnMainSide;
    public System.Windows.Forms.Splitter SplitterMainVertical;
    public Telerik.WinControls.UI.RadPageViewPage PageFirst;
    public Telerik.WinControls.UI.RadPageViewPage PageLog;
    public Telerik.WinControls.UI.RadPageViewPage PageSettings;
    public Telerik.WinControls.UI.RadPageViewPage PageAbout;
    public Telerik.WinControls.UI.RadPageViewPage PageExit;
    public Telerik.WinControls.UI.RadPageView PvMain;
  }
}
