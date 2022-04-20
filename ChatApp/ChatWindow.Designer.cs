
namespace ChatApp
{
    partial class ChatWindow
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
            this.SendInput = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.ChatLogInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RecipientComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SendInput
            // 
            this.SendInput.Location = new System.Drawing.Point(175, 447);
            this.SendInput.Multiline = true;
            this.SendInput.Name = "SendInput";
            this.SendInput.Size = new System.Drawing.Size(462, 64);
            this.SendInput.TabIndex = 0;
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(358, 517);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(79, 23);
            this.SendBtn.TabIndex = 1;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // ChatLogInput
            // 
            this.ChatLogInput.Location = new System.Drawing.Point(175, 84);
            this.ChatLogInput.Multiline = true;
            this.ChatLogInput.Name = "ChatLogInput";
            this.ChatLogInput.ReadOnly = true;
            this.ChatLogInput.Size = new System.Drawing.Size(462, 357);
            this.ChatLogInput.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(382, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Messages";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select User";
            // 
            // RecipientComboBox
            // 
            this.RecipientComboBox.FormattingEnabled = true;
            this.RecipientComboBox.Location = new System.Drawing.Point(12, 29);
            this.RecipientComboBox.Name = "RecipientComboBox";
            this.RecipientComboBox.Size = new System.Drawing.Size(121, 21);
            this.RecipientComboBox.TabIndex = 5;
            this.RecipientComboBox.SelectedIndexChanged += new System.EventHandler(this.RecipientComboBox_SelectedIndexChanged);
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 547);
            this.Controls.Add(this.RecipientComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChatLogInput);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.SendInput);
            this.Name = "ChatWindow";
            this.Text = "Chat App";
            this.Load += new System.EventHandler(this.ChatWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SendInput;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.TextBox ChatLogInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox RecipientComboBox;
    }
}