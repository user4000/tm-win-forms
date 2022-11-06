namespace TmWinFormsExample
{
  partial class FxForm2
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
      this.TxtMessage = new Telerik.WinControls.UI.RadTextBoxControl();
      this.BxTestRaiseEvent = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.LbFormTwo)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtMessage)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BxTestRaiseEvent)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // LbFormTwo
      // 
      this.LbFormTwo.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.LbFormTwo.ForeColor = System.Drawing.Color.HotPink;
      this.LbFormTwo.Location = new System.Drawing.Point(12, 22);
      this.LbFormTwo.Name = "LbFormTwo";
      this.LbFormTwo.Size = new System.Drawing.Size(232, 38);
      this.LbFormTwo.TabIndex = 2;
      this.LbFormTwo.Text = "Form Number 2";
      // 
      // TxtMessage
      // 
      this.TxtMessage.Location = new System.Drawing.Point(12, 157);
      this.TxtMessage.MaxLength = 90000;
      this.TxtMessage.Multiline = true;
      this.TxtMessage.Name = "TxtMessage";
      this.TxtMessage.Size = new System.Drawing.Size(1057, 502);
      this.TxtMessage.TabIndex = 4;
      this.TxtMessage.VerticalScrollBarState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
      // 
      // BxTestRaiseEvent
      // 
      this.BxTestRaiseEvent.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BxTestRaiseEvent.Location = new System.Drawing.Point(311, 22);
      this.BxTestRaiseEvent.Name = "BxTestRaiseEvent";
      this.BxTestRaiseEvent.Size = new System.Drawing.Size(189, 26);
      this.BxTestRaiseEvent.TabIndex = 10;
      this.BxTestRaiseEvent.Text = "Test Raise Event";
      // 
      // FxForm2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1081, 671);
      this.Controls.Add(this.BxTestRaiseEvent);
      this.Controls.Add(this.TxtMessage);
      this.Controls.Add(this.LbFormTwo);
      this.Name = "FxForm2";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "FxForm2";
      ((System.ComponentModel.ISupportInitialize)(this.LbFormTwo)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtMessage)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BxTestRaiseEvent)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadLabel LbFormTwo;
    public Telerik.WinControls.UI.RadTextBoxControl TxtMessage;
    public Telerik.WinControls.UI.RadButton BxTestRaiseEvent;
  }
}
