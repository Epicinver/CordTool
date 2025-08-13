namespace CordTool
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnSendWebhook;
        private System.Windows.Forms.Button btnNukeServer;
        private System.Windows.Forms.Button btnNukeServerBetter;
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
            this.btnSendWebhook = new System.Windows.Forms.Button();
            this.btnNukeServer = new System.Windows.Forms.Button();
            this.btnNukeServerBetter = new System.Windows.Forms.Button();
            this.btnReleaseNotes = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSendWebhook
            // 
            this.btnSendWebhook.Location = new System.Drawing.Point(468, 377);
            this.btnSendWebhook.Name = "btnSendWebhook";
            this.btnSendWebhook.Size = new System.Drawing.Size(200, 40);
            this.btnSendWebhook.TabIndex = 0;
            this.btnSendWebhook.Text = "Send Webhook Message";
            this.btnSendWebhook.UseVisualStyleBackColor = true;
            this.btnSendWebhook.Click += new System.EventHandler(this.btnSendWebhook_Click);
            // 
            // btnNukeServer
            // 
            this.btnNukeServer.Location = new System.Drawing.Point(468, 285);
            this.btnNukeServer.Name = "btnNukeServer";
            this.btnNukeServer.Size = new System.Drawing.Size(200, 40);
            this.btnNukeServer.TabIndex = 1;
            this.btnNukeServer.Text = "Nuke Server";
            this.btnNukeServer.UseVisualStyleBackColor = true;
            this.btnNukeServer.Click += new System.EventHandler(this.btnNukeServer_Click);
            // 
            // btnNukeServerBetter
            // 
            this.btnNukeServerBetter.Location = new System.Drawing.Point(468, 331);
            this.btnNukeServerBetter.Name = "btnNukeServerBetter";
            this.btnNukeServerBetter.Size = new System.Drawing.Size(200, 40);
            this.btnNukeServerBetter.TabIndex = 2;
            this.btnNukeServerBetter.Text = "Nuke Server Better";
            this.btnNukeServerBetter.UseVisualStyleBackColor = true;
            this.btnNukeServerBetter.Click += new System.EventHandler(this.btnNukeServerBetter_Click);
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
            this.label1.Cursor = System.Windows.Forms.Cursors.Help;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(236, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(654, 199);
            this.label1.TabIndex = 5;
            this.label1.Text = "CordTool";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1107, 663);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSendWebhook);
            this.Controls.Add(this.btnNukeServer);
            this.Controls.Add(this.btnNukeServerBetter);
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
