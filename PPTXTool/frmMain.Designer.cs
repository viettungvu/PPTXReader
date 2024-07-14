namespace PPTXTool
{
    partial class frmMain
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
            this.btnCheckInk = new System.Windows.Forms.Button();
            this.btnGetAnimate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCheckInk
            // 
            this.btnCheckInk.Location = new System.Drawing.Point(103, 70);
            this.btnCheckInk.Name = "btnCheckInk";
            this.btnCheckInk.Size = new System.Drawing.Size(163, 52);
            this.btnCheckInk.TabIndex = 0;
            this.btnCheckInk.Text = "button1";
            this.btnCheckInk.UseVisualStyleBackColor = true;
            this.btnCheckInk.Click += new System.EventHandler(this.btnCheckInk_Click);
            // 
            // btnGetAnimate
            // 
            this.btnGetAnimate.Location = new System.Drawing.Point(103, 167);
            this.btnGetAnimate.Name = "btnGetAnimate";
            this.btnGetAnimate.Size = new System.Drawing.Size(163, 52);
            this.btnGetAnimate.TabIndex = 1;
            this.btnGetAnimate.Text = "Get Animate";
            this.btnGetAnimate.UseVisualStyleBackColor = true;
            this.btnGetAnimate.Click += new System.EventHandler(this.btnGetAnimate_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGetAnimate);
            this.Controls.Add(this.btnCheckInk);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCheckInk;
        private System.Windows.Forms.Button btnGetAnimate;
    }
}