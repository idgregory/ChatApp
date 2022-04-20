
namespace ChatApp
{
    partial class MainWindow
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
            this.ChatWindowPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ChatWindowPanel
            // 
            this.ChatWindowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatWindowPanel.Location = new System.Drawing.Point(0, 0);
            this.ChatWindowPanel.Name = "ChatWindowPanel";
            this.ChatWindowPanel.Size = new System.Drawing.Size(1000, 661);
            this.ChatWindowPanel.TabIndex = 0;
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 661);
            this.Controls.Add(this.ChatWindowPanel);
            this.Name = "ChatWindow";
            this.Text = "ChatWindow";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel ChatWindowPanel;
    }
}