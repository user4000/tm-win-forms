namespace TmWinFormsExample
{
  partial class FxForm3
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
      this.LbFormTwo = new Telerik.WinControls.UI.RadLabel();
      this.PvMain = new Telerik.WinControls.UI.RadPageView();
      this.PageFirst = new Telerik.WinControls.UI.RadPageViewPage();
      this.PageLog = new Telerik.WinControls.UI.RadPageViewPage();
      this.PageSettings = new Telerik.WinControls.UI.RadPageViewPage();
      this.PageAboutProgram = new Telerik.WinControls.UI.RadPageViewPage();
      this.PageExit = new Telerik.WinControls.UI.RadPageViewPage();
      this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
      this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
      this.radPageViewPage3 = new Telerik.WinControls.UI.RadPageViewPage();
      this.radPageViewPage4 = new Telerik.WinControls.UI.RadPageViewPage();
      ((System.ComponentModel.ISupportInitialize)(this.LbFormTwo)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PvMain)).BeginInit();
      this.PvMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // LbFormTwo
      // 
      this.LbFormTwo.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.LbFormTwo.ForeColor = System.Drawing.Color.Green;
      this.LbFormTwo.Location = new System.Drawing.Point(31, 31);
      this.LbFormTwo.Name = "LbFormTwo";
      this.LbFormTwo.Size = new System.Drawing.Size(232, 38);
      this.LbFormTwo.TabIndex = 2;
      this.LbFormTwo.Text = "Form Number 3";
      // 
      // PvMain
      // 
      this.PvMain.Controls.Add(this.PageFirst);
      this.PvMain.Controls.Add(this.PageLog);
      this.PvMain.Controls.Add(this.PageSettings);
      this.PvMain.Controls.Add(this.PageAboutProgram);
      this.PvMain.Controls.Add(this.PageExit);
      this.PvMain.Controls.Add(this.radPageViewPage1);
      this.PvMain.Controls.Add(this.radPageViewPage2);
      this.PvMain.Controls.Add(this.radPageViewPage3);
      this.PvMain.Controls.Add(this.radPageViewPage4);
      this.PvMain.Font = new System.Drawing.Font("Verdana", 10F);
      this.PvMain.Location = new System.Drawing.Point(74, 171);
      this.PvMain.Name = "PvMain";
      this.PvMain.SelectedPage = this.radPageViewPage4;
      this.PvMain.Size = new System.Drawing.Size(674, 411);
      this.PvMain.TabIndex = 7;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PvMain.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PvMain.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(1);
      ((Telerik.WinControls.UI.StripViewItemContainer)(this.PvMain.GetChildAt(0).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0);
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).DrawBorder = true;
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).EnableImageTransparency = false;
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).EnableFocusBorder = false;
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).EnableHighlight = true;
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).ToolTipText = "Scroll Strip Left";
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(32, 24);
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).ToolTipText = "Scroll Strip Right";
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Enabled = false;
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).MinSize = new System.Drawing.Size(32, 24);
      // 
      // PageFirst
      // 
      this.PageFirst.ItemSize = new System.Drawing.SizeF(64F, 30F);
      this.PageFirst.Location = new System.Drawing.Point(6, 35);
      this.PageFirst.Name = "PageFirst";
      this.PageFirst.Size = new System.Drawing.Size(498, 370);
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
      // PageAboutProgram
      // 
      this.PageAboutProgram.ItemSize = new System.Drawing.SizeF(121F, 30F);
      this.PageAboutProgram.Location = new System.Drawing.Point(6, 35);
      this.PageAboutProgram.Name = "PageAboutProgram";
      this.PageAboutProgram.Size = new System.Drawing.Size(1045, 660);
      this.PageAboutProgram.Text = "About Program";
      // 
      // PageExit
      // 
      this.PageExit.ItemSize = new System.Drawing.SizeF(43F, 30F);
      this.PageExit.Location = new System.Drawing.Point(6, 35);
      this.PageExit.Name = "PageExit";
      this.PageExit.Size = new System.Drawing.Size(1045, 660);
      this.PageExit.Text = "Exit";
      // 
      // radPageViewPage1
      // 
      this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(147F, 30F);
      this.radPageViewPage1.Location = new System.Drawing.Point(6, 35);
      this.radPageViewPage1.Name = "radPageViewPage1";
      this.radPageViewPage1.Size = new System.Drawing.Size(498, 370);
      this.radPageViewPage1.Text = "radPageViewPage1";
      // 
      // radPageViewPage2
      // 
      this.radPageViewPage2.ItemSize = new System.Drawing.SizeF(147F, 30F);
      this.radPageViewPage2.Location = new System.Drawing.Point(6, 35);
      this.radPageViewPage2.Name = "radPageViewPage2";
      this.radPageViewPage2.Size = new System.Drawing.Size(498, 370);
      this.radPageViewPage2.Text = "radPageViewPage2";
      // 
      // radPageViewPage3
      // 
      this.radPageViewPage3.ItemSize = new System.Drawing.SizeF(147F, 30F);
      this.radPageViewPage3.Location = new System.Drawing.Point(6, 35);
      this.radPageViewPage3.Name = "radPageViewPage3";
      this.radPageViewPage3.Size = new System.Drawing.Size(662, 370);
      this.radPageViewPage3.Text = "radPageViewPage3";
      // 
      // radPageViewPage4
      // 
      this.radPageViewPage4.ItemSize = new System.Drawing.SizeF(147F, 30F);
      this.radPageViewPage4.Location = new System.Drawing.Point(6, 35);
      this.radPageViewPage4.Name = "radPageViewPage4";
      this.radPageViewPage4.Size = new System.Drawing.Size(662, 370);
      this.radPageViewPage4.Text = "radPageViewPage4";
      // 
      // FxForm3
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1081, 671);
      this.Controls.Add(this.PvMain);
      this.Controls.Add(this.LbFormTwo);
      this.Name = "FxForm3";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "";
      ((System.ComponentModel.ISupportInitialize)(this.LbFormTwo)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PvMain)).EndInit();
      this.PvMain.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadLabel LbFormTwo;
    public Telerik.WinControls.UI.RadPageView PvMain;
    public Telerik.WinControls.UI.RadPageViewPage PageFirst;
    public Telerik.WinControls.UI.RadPageViewPage PageLog;
    public Telerik.WinControls.UI.RadPageViewPage PageSettings;
    public Telerik.WinControls.UI.RadPageViewPage PageAboutProgram;
    public Telerik.WinControls.UI.RadPageViewPage PageExit;
    private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
    private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
    private Telerik.WinControls.UI.RadPageViewPage radPageViewPage3;
    private Telerik.WinControls.UI.RadPageViewPage radPageViewPage4;
  }
}
