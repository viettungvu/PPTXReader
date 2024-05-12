namespace PPTXTool
{
    partial class Form1
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
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSlideFrom = new System.Windows.Forms.NumericUpDown();
            this.txtSlideZoomTo = new System.Windows.Forms.NumericUpDown();
            this.SlideZoomFrom = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.txtSlideFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSlideZoomTo)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilePath.Location = new System.Drawing.Point(187, 9);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(447, 30);
            this.txtFilePath.TabIndex = 0;
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(187, 119);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(339, 73);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Kiểm tra";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đường dẫn file PPTX";
            // 
            // txtSlideFrom
            // 
            this.txtSlideFrom.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlideFrom.Location = new System.Drawing.Point(187, 71);
            this.txtSlideFrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSlideFrom.Name = "txtSlideFrom";
            this.txtSlideFrom.Size = new System.Drawing.Size(120, 30);
            this.txtSlideFrom.TabIndex = 3;
            this.txtSlideFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtSlideZoomTo
            // 
            this.txtSlideZoomTo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlideZoomTo.Location = new System.Drawing.Point(406, 71);
            this.txtSlideZoomTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSlideZoomTo.Name = "txtSlideZoomTo";
            this.txtSlideZoomTo.Size = new System.Drawing.Size(120, 30);
            this.txtSlideZoomTo.TabIndex = 4;
            this.txtSlideZoomTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SlideZoomFrom
            // 
            this.SlideZoomFrom.AutoSize = true;
            this.SlideZoomFrom.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SlideZoomFrom.Location = new System.Drawing.Point(12, 75);
            this.SlideZoomFrom.Name = "SlideZoomFrom";
            this.SlideZoomFrom.Size = new System.Drawing.Size(137, 23);
            this.SlideZoomFrom.TabIndex = 5;
            this.SlideZoomFrom.Text = "Zoom từ slide số";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(313, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "đến slide";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(69, 28);
            this.lblStatus.Text = "Kết quả";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.toolStrip1.Location = new System.Drawing.Point(0, 242);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(640, 26);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 268);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.SlideZoomFrom);
            this.Controls.Add(this.txtSlideZoomTo);
            this.Controls.Add(this.txtSlideFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtFilePath);
            this.Name = "Form1";
            this.Text = "Tool Check SlideZoom";
            ((System.ComponentModel.ISupportInitialize)(this.txtSlideFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSlideZoomTo)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtSlideFrom;
        private System.Windows.Forms.NumericUpDown txtSlideZoomTo;
        private System.Windows.Forms.Label SlideZoomFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripLabel lblStatus;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}

