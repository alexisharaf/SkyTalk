namespace SkyTalk
{
    partial class SkyTalkClientMainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.serverIpTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.connectToServerButton = new System.Windows.Forms.Button();
            this.userListListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP adress:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // serverIpTextBox
            // 
            this.serverIpTextBox.Location = new System.Drawing.Point(136, 51);
            this.serverIpTextBox.Name = "serverIpTextBox";
            this.serverIpTextBox.Size = new System.Drawing.Size(116, 20);
            this.serverIpTextBox.TabIndex = 2;
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(136, 97);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(116, 20);
            this.portTextBox.TabIndex = 3;
            this.portTextBox.Text = "11111";
            // 
            // connectToServerButton
            // 
            this.connectToServerButton.Location = new System.Drawing.Point(150, 180);
            this.connectToServerButton.Name = "connectToServerButton";
            this.connectToServerButton.Size = new System.Drawing.Size(75, 23);
            this.connectToServerButton.TabIndex = 4;
            this.connectToServerButton.Text = "Connect";
            this.connectToServerButton.UseVisualStyleBackColor = true;
            this.connectToServerButton.Click += new System.EventHandler(this.connectToServerButton_Click);
            // 
            // userListListBox
            // 
            this.userListListBox.FormattingEnabled = true;
            this.userListListBox.Location = new System.Drawing.Point(356, 51);
            this.userListListBox.Name = "userListListBox";
            this.userListListBox.Size = new System.Drawing.Size(357, 355);
            this.userListListBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "User Name:";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(136, 137);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(116, 20);
            this.userNameTextBox.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 522);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userListListBox);
            this.Controls.Add(this.connectToServerButton);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.serverIpTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "TalkClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox serverIpTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button connectToServerButton;
        private System.Windows.Forms.ListBox userListListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userNameTextBox;
    }
}

