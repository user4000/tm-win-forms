namespace TmWinForms
{
    partial class FxMessage
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxMessage));
      this.PnMessage = new Telerik.WinControls.UI.RadPanel();
      this.TxMessage = new Telerik.WinControls.UI.RadTextBox();
      this.PnTop = new Telerik.WinControls.UI.RadPanel();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.BxClose = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.PnMessage)).BeginInit();
      this.PnMessage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TxMessage)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PnTop)).BeginInit();
      this.PnTop.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BxClose)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // PnMessage
      // 
      this.PnMessage.BackColor = System.Drawing.Color.MistyRose;
      this.PnMessage.Controls.Add(this.TxMessage);
      this.PnMessage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PnMessage.Location = new System.Drawing.Point(0, 48);
      this.PnMessage.Name = "PnMessage";
      this.PnMessage.Padding = new System.Windows.Forms.Padding(5);
      this.PnMessage.Size = new System.Drawing.Size(792, 522);
      this.PnMessage.TabIndex = 0;
      // 
      // TxMessage
      // 
      this.TxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TxMessage.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.TxMessage.Location = new System.Drawing.Point(5, 5);
      this.TxMessage.MaxLength = 100000;
      this.TxMessage.Multiline = true;
      this.TxMessage.Name = "TxMessage";
      this.TxMessage.ReadOnly = true;
      // 
      // 
      // 
      this.TxMessage.RootElement.StretchVertically = true;
      this.TxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.TxMessage.Size = new System.Drawing.Size(782, 512);
      this.TxMessage.TabIndex = 0;
      // 
      // PnTop
      // 
      this.PnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
      this.PnTop.Controls.Add(this.pictureBox1);
      this.PnTop.Controls.Add(this.BxClose);
      this.PnTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.PnTop.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.PnTop.Location = new System.Drawing.Point(0, 0);
      this.PnTop.Name = "PnTop";
      this.PnTop.Size = new System.Drawing.Size(792, 48);
      this.PnTop.TabIndex = 0;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(0, 0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(74, 48);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 9;
      this.pictureBox1.TabStop = false;
      // 
      // BxClose
      // 
      this.BxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.BxClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BxClose.Image = ((System.Drawing.Image)(resources.GetObject("BxClose.Image")));
      this.BxClose.Location = new System.Drawing.Point(635, 12);
      this.BxClose.Name = "BxClose";
      this.BxClose.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
      this.BxClose.Size = new System.Drawing.Size(145, 25);
      this.BxClose.TabIndex = 8;
      this.BxClose.Text = "Close";
      // 
      // FxMessage
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.WhiteSmoke;
      this.ClientSize = new System.Drawing.Size(792, 570);
      this.Controls.Add(this.PnMessage);
      this.Controls.Add(this.PnTop);
      this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.MinimumSize = new System.Drawing.Size(300, 500);
      this.Name = "FxMessage";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "   An error occurred while the program was running.";
      ((System.ComponentModel.ISupportInitialize)(this.PnMessage)).EndInit();
      this.PnMessage.ResumeLayout(false);
      this.PnMessage.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TxMessage)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PnTop)).EndInit();
      this.PnTop.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BxClose)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

        }

    #endregion
    public Telerik.WinControls.UI.RadTextBox TxMessage;
    public Telerik.WinControls.UI.RadPanel PnTop;
    public Telerik.WinControls.UI.RadButton BxClose;
    public Telerik.WinControls.UI.RadPanel PnMessage;
    public System.Windows.Forms.PictureBox pictureBox1;
  }
}
