namespace TmWinFormsExample
{
    partial class FxTreeview32
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
      this.TxMessage = new Telerik.WinControls.UI.RadTextBox();
      ((System.ComponentModel.ISupportInitialize)(this.LbFormTwo)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxMessage)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // LbFormTwo
      // 
      this.LbFormTwo.AutoSize = false;
      this.LbFormTwo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.LbFormTwo.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.LbFormTwo.ForeColor = System.Drawing.Color.HotPink;
      this.LbFormTwo.Location = new System.Drawing.Point(21, 12);
      this.LbFormTwo.Name = "LbFormTwo";
      this.LbFormTwo.Size = new System.Drawing.Size(948, 76);
      this.LbFormTwo.TabIndex = 3;
      this.LbFormTwo.Text = "Form Number 3.2";
      this.LbFormTwo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // TxMessage
      // 
      this.TxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TxMessage.AutoSize = false;
      this.TxMessage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.TxMessage.Location = new System.Drawing.Point(21, 173);
      this.TxMessage.MaxLength = 30000;
      this.TxMessage.Multiline = true;
      this.TxMessage.Name = "TxMessage";
      this.TxMessage.Padding = new System.Windows.Forms.Padding(5);
      this.TxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.TxMessage.Size = new System.Drawing.Size(948, 327);
      this.TxMessage.TabIndex = 5;
      // 
      // FxTreeview32
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(994, 523);
      this.ControlBox = false;
      this.Controls.Add(this.TxMessage);
      this.Controls.Add(this.LbFormTwo);
      this.Name = "FxTreeview32";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "";
      ((System.ComponentModel.ISupportInitialize)(this.LbFormTwo)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxMessage)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

        }

    #endregion

    private Telerik.WinControls.UI.RadLabel LbFormTwo;
    public Telerik.WinControls.UI.RadTextBox TxMessage;
  }
}
