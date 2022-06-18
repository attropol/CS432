namespace CS408Project_client
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.FilePath_textBox = new System.Windows.Forms.TextBox();
            this.button_Browse = new System.Windows.Forms.Button();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Send = new System.Windows.Forms.Button();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_downPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_folderBrowse = new System.Windows.Forms.Button();
            this.fileName_textbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_download = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(39, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP Address:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(71, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Port:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(41, 70);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(24, 157);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Select file path to upload:";
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(112, 42);
            this.textBox_IP.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(97, 20);
            this.textBox_IP.TabIndex = 5;
            this.textBox_IP.Text = "127.0.0.1";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(112, 18);
            this.textBox_Port.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(55, 20);
            this.textBox_Port.TabIndex = 6;
            this.textBox_Port.Text = "1999";
            // 
            // textBox_Username
            // 
            this.textBox_Username.Location = new System.Drawing.Point(112, 69);
            this.textBox_Username.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(97, 20);
            this.textBox_Username.TabIndex = 7;
            this.textBox_Username.Text = "Client";
            // 
            // FilePath_textBox
            // 
            this.FilePath_textBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.FilePath_textBox.Enabled = false;
            this.FilePath_textBox.Location = new System.Drawing.Point(46, 185);
            this.FilePath_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.FilePath_textBox.Name = "FilePath_textBox";
            this.FilePath_textBox.Size = new System.Drawing.Size(191, 20);
            this.FilePath_textBox.TabIndex = 8;
            // 
            // button_Browse
            // 
            this.button_Browse.Enabled = false;
            this.button_Browse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_Browse.Location = new System.Drawing.Point(198, 152);
            this.button_Browse.Margin = new System.Windows.Forms.Padding(2);
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.Size = new System.Drawing.Size(65, 26);
            this.button_Browse.TabIndex = 9;
            this.button_Browse.Text = "Browse";
            this.button_Browse.UseVisualStyleBackColor = true;
            this.button_Browse.Click += new System.EventHandler(this.button_Browse_Click);
            // 
            // logs
            // 
            this.logs.BackColor = System.Drawing.SystemColors.Control;
            this.logs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.logs.ForeColor = System.Drawing.Color.Black;
            this.logs.Location = new System.Drawing.Point(307, 11);
            this.logs.Margin = new System.Windows.Forms.Padding(2);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(382, 654);
            this.logs.TabIndex = 10;
            this.logs.Text = "";
            // 
            // button_Connect
            // 
            this.button_Connect.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_Connect.Location = new System.Drawing.Point(42, 97);
            this.button_Connect.Margin = new System.Windows.Forms.Padding(2);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(103, 31);
            this.button_Connect.TabIndex = 11;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = false;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Send
            // 
            this.button_Send.BackColor = System.Drawing.SystemColors.Control;
            this.button_Send.Enabled = false;
            this.button_Send.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_Send.Location = new System.Drawing.Point(105, 213);
            this.button_Send.Margin = new System.Windows.Forms.Padding(2);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(89, 26);
            this.button_Send.TabIndex = 12;
            this.button_Send.Text = "Upload file";
            this.button_Send.UseVisualStyleBackColor = false;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // button_disconnect
            // 
            this.button_disconnect.BackColor = System.Drawing.Color.DimGray;
            this.button_disconnect.Enabled = false;
            this.button_disconnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_disconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_disconnect.ForeColor = System.Drawing.Color.Black;
            this.button_disconnect.Location = new System.Drawing.Point(149, 97);
            this.button_disconnect.Margin = new System.Windows.Forms.Padding(2);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(103, 31);
            this.button_disconnect.TabIndex = 13;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = false;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(8, 128);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(283, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "______________________________________________";
            // 
            // textBox_downPath
            // 
            this.textBox_downPath.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox_downPath.Enabled = false;
            this.textBox_downPath.Location = new System.Drawing.Point(46, 286);
            this.textBox_downPath.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_downPath.Name = "textBox_downPath";
            this.textBox_downPath.Size = new System.Drawing.Size(191, 20);
            this.textBox_downPath.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(24, 252);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "Select file path to download:";
            // 
            // button_folderBrowse
            // 
            this.button_folderBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_folderBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_folderBrowse.Location = new System.Drawing.Point(202, 247);
            this.button_folderBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.button_folderBrowse.Name = "button_folderBrowse";
            this.button_folderBrowse.Size = new System.Drawing.Size(65, 26);
            this.button_folderBrowse.TabIndex = 23;
            this.button_folderBrowse.Text = "Browse";
            this.button_folderBrowse.UseVisualStyleBackColor = true;
            this.button_folderBrowse.Click += new System.EventHandler(this.button_folderBrowse_Click_1);
            // 
            // fileName_textbox
            // 
            this.fileName_textbox.Location = new System.Drawing.Point(97, 320);
            this.fileName_textbox.Margin = new System.Windows.Forms.Padding(2);
            this.fileName_textbox.Name = "fileName_textbox";
            this.fileName_textbox.Size = new System.Drawing.Size(112, 20);
            this.fileName_textbox.TabIndex = 24;
            this.fileName_textbox.Text = "Client";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(19, 321);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "Filename:";
            // 
            // button_download
            // 
            this.button_download.BackColor = System.Drawing.SystemColors.Control;
            this.button_download.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_download.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_download.Location = new System.Drawing.Point(105, 344);
            this.button_download.Margin = new System.Windows.Forms.Padding(2);
            this.button_download.Name = "button_download";
            this.button_download.Size = new System.Drawing.Size(104, 26);
            this.button_download.TabIndex = 27;
            this.button_download.Text = "Download file";
            this.button_download.UseVisualStyleBackColor = false;
            this.button_download.Click += new System.EventHandler(this.button_download_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(707, 685);
            this.Controls.Add(this.button_download);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.fileName_textbox);
            this.Controls.Add(this.button_folderBrowse);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_downPath);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.button_Browse);
            this.Controls.Add(this.FilePath_textBox);
            this.Controls.Add(this.textBox_Username);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.TextBox textBox_Username;
        private System.Windows.Forms.TextBox FilePath_textBox;
        private System.Windows.Forms.Button button_Browse;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_downPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_folderBrowse;
        private System.Windows.Forms.TextBox fileName_textbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_download;
    }
}

