namespace CommandTable
{
    partial class MainForm
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
            this.MainWebBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // MainWebBrowser
            // 
            this.MainWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.MainWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.MainWebBrowser.Name = "MainWebBrowser";
            this.MainWebBrowser.Size = new System.Drawing.Size(1002, 712);
            this.MainWebBrowser.TabIndex = 0;
            this.MainWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1002, 712);
            this.Controls.Add(this.MainWebBrowser);
            this.Name = "MainForm";
            this.Text = "CommandTable";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser MainWebBrowser;
    }
}

