namespace CordTool
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnReleaseNotes;
        private System.Windows.Forms.Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnReleaseNotes = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReleaseNotes
            // 
            this.btnReleaseNotes.Location = new System.Drawing.Point(-5, 623);
            this.btnReleaseNotes.Name = "btnReleaseNotes";
            this.btnReleaseNotes.Size = new System.Drawing.Size(200, 40);
            this.btnReleaseNotes.TabIndex = 3;
            this.btnReleaseNotes.Text = "Release Notes";
            this.btnReleaseNotes.UseVisualStyleBackColor = true;
            this.btnReleaseNotes.Click += new System.EventHandler(this.btnReleaseNotes_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(-5, 577);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(200, 40);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1098, 64);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cordtool GUI will be phased out. Thank you.";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1107, 663);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReleaseNotes);
            this.Controls.Add(this.btnExit);
            this.Name = "Form1";
            this.Text = "CordTool GUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
    }
}
