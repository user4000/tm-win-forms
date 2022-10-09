namespace TmWinFormsExample
{
    partial class FxAboutProgram
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
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radLabel1
      // 
      this.radLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.radLabel1.AutoSize = false;
      this.radLabel1.BorderVisible = true;
      this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.radLabel1.ForeColor = System.Drawing.Color.DarkSeaGreen;
      this.radLabel1.Location = new System.Drawing.Point(133, 91);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(774, 148);
      this.radLabel1.TabIndex = 0;
      this.radLabel1.Text = "This is a test application";
      this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // radLabel2
      // 
      this.radLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.radLabel2.AutoSize = false;
      this.radLabel2.BorderVisible = true;
      this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.radLabel2.ForeColor = System.Drawing.Color.DarkCyan;
      this.radLabel2.Location = new System.Drawing.Point(133, 245);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Size = new System.Drawing.Size(774, 148);
      this.radLabel2.TabIndex = 0;
      this.radLabel2.Text = "Enterprise Edition";
      this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // radLabel3
      // 
      this.radLabel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.radLabel3.AutoSize = false;
      this.radLabel3.BorderVisible = true;
      this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.radLabel3.ForeColor = System.Drawing.Color.Orchid;
      this.radLabel3.Location = new System.Drawing.Point(133, 442);
      this.radLabel3.Name = "radLabel3";
      this.radLabel3.Size = new System.Drawing.Size(774, 71);
      this.radLabel3.TabIndex = 0;
      this.radLabel3.Text = "Version 1.2.3";
      this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // FxAboutProgram
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1063, 593);
      this.Controls.Add(this.radLabel3);
      this.Controls.Add(this.radLabel2);
      this.Controls.Add(this.radLabel1);
      this.Name = "FxAboutProgram";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "FxAboutProgram";
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

        }

    #endregion

    public Telerik.WinControls.UI.RadLabel radLabel1;
    public Telerik.WinControls.UI.RadLabel radLabel2;
    public Telerik.WinControls.UI.RadLabel radLabel3;
  }
}
