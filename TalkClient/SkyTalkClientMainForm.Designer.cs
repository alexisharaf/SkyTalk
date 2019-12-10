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
            this.serverIpTextBox = new System.Windows.Forms.TextBox();
            this.connectToServerButton = new System.Windows.Forms.Button();
            this.userListListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.localIPcomboBox = new System.Windows.Forms.ComboBox();
            this.getUsersListButton = new System.Windows.Forms.Button();
            this.CallUserButton = new System.Windows.Forms.Button();
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
            // serverIpTextBox
            // 
            this.serverIpTextBox.Location = new System.Drawing.Point(136, 51);
            this.serverIpTextBox.Name = "serverIpTextBox";
            this.serverIpTextBox.Size = new System.Drawing.Size(136, 20);
            this.serverIpTextBox.TabIndex = 2;
            this.serverIpTextBox.Text = "192.168.0.7";
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
            this.label3.Location = new System.Drawing.Point(67, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "User Name:";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(136, 108);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(136, 20);
            this.userNameTextBox.TabIndex = 7;
            this.userNameTextBox.Text = "user1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password:";
            // 
            // passTextBox
            // 
            this.passTextBox.Location = new System.Drawing.Point(136, 143);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.Size = new System.Drawing.Size(136, 20);
            this.passTextBox.TabIndex = 9;
            this.passTextBox.Text = "user1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "local IP:";
            // 
            // localIPcomboBox
            // 
            this.localIPcomboBox.FormattingEnabled = true;
            this.localIPcomboBox.Location = new System.Drawing.Point(136, 79);
            this.localIPcomboBox.Name = "localIPcomboBox";
            this.localIPcomboBox.Size = new System.Drawing.Size(136, 21);
            this.localIPcomboBox.TabIndex = 11;
            // 
            // getUsersListButton
            // 
            this.getUsersListButton.Location = new System.Drawing.Point(150, 226);
            this.getUsersListButton.Name = "getUsersListButton";
            this.getUsersListButton.Size = new System.Drawing.Size(75, 23);
            this.getUsersListButton.TabIndex = 12;
            this.getUsersListButton.Text = "Get Users List";
            this.getUsersListButton.UseVisualStyleBackColor = true;
            this.getUsersListButton.Click += new System.EventHandler(this.getUsersListButton_Click);
            // 
            // CallUserButton
            // 
            this.CallUserButton.Location = new System.Drawing.Point(501, 438);
            this.CallUserButton.Name = "CallUserButton";
            this.CallUserButton.Size = new System.Drawing.Size(75, 23);
            this.CallUserButton.TabIndex = 13;
            this.CallUserButton.Text = "Call User";
            this.CallUserButton.UseVisualStyleBackColor = true;
            // 
            // SkyTalkClientMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 522);
            this.Controls.Add(this.CallUserButton);
            this.Controls.Add(this.getUsersListButton);
            this.Controls.Add(this.localIPcomboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.passTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userListListBox);
            this.Controls.Add(this.connectToServerButton);
            this.Controls.Add(this.serverIpTextBox);
            this.Controls.Add(this.label1);
            this.Name = "SkyTalkClientMainForm";
            this.Text = "TalkClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverIpTextBox;
        private System.Windows.Forms.Button connectToServerButton;
        private System.Windows.Forms.ListBox userListListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox localIPcomboBox;
        private System.Windows.Forms.Button getUsersListButton;
        private System.Windows.Forms.Button CallUserButton;
    }
}

