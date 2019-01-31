namespace Cipher
{
    partial class CipherDemo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.labelKey = new System.Windows.Forms.Label();
            this.comboBoxAlgorithm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.labelTimer = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.button_Text_Decrypt = new System.Windows.Forms.Button();
            this.button_Text_Encrypt = new System.Windows.Forms.Button();
            this.textBox_DeText = new System.Windows.Forms.TextBox();
            this.textBox_EnText = new System.Windows.Forms.TextBox();
            this.textBox_Text_Input = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button_File_Decrypt = new System.Windows.Forms.Button();
            this.button_EnFile_Browse = new System.Windows.Forms.Button();
            this.button_File_Encrypt = new System.Windows.Forms.Button();
            this.button_File_Browse = new System.Windows.Forms.Button();
            this.button_DeFile_Browse = new System.Windows.Forms.Button();
            this.textBox_DeFile = new System.Windows.Forms.TextBox();
            this.textBox_EnFile = new System.Windows.Forms.TextBox();
            this.textBox_File_Input = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxKey);
            this.groupBox1.Controls.Add(this.labelKey);
            this.groupBox1.Controls.Add(this.comboBoxAlgorithm);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Properties";
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(288, 17);
            this.textBoxKey.MaxLength = 8;
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(181, 20);
            this.textBoxKey.TabIndex = 3;
            this.textBoxKey.Text = "DefaultK";
            this.textBoxKey.Leave += new System.EventHandler(this.textBoxKey_Leave);
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(179, 20);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(94, 13);
            this.labelKey.TabIndex = 2;
            this.labelKey.Text = "Key(8 Characters):";
            // 
            // comboBoxAlgorithm
            // 
            this.comboBoxAlgorithm.FormattingEnabled = true;
            this.comboBoxAlgorithm.Location = new System.Drawing.Point(75, 17);
            this.comboBoxAlgorithm.Name = "comboBoxAlgorithm";
            this.comboBoxAlgorithm.Size = new System.Drawing.Size(98, 21);
            this.comboBoxAlgorithm.TabIndex = 1;
            this.comboBoxAlgorithm.SelectedIndexChanged += new System.EventHandler(this.comboBoxAlgorithm_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Algorithm:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonStop);
            this.groupBox2.Controls.Add(this.labelTimer);
            this.groupBox2.Controls.Add(this.progressBar);
            this.groupBox2.Location = new System.Drawing.Point(2, 382);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 82);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Progress";
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(19, 50);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(74, 23);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(127, 55);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(49, 13);
            this.labelTimer.TabIndex = 2;
            this.labelTimer.Text = "00:00:00";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(19, 19);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(450, 22);
            this.progressBar.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tabControl1);
            this.groupBox3.Location = new System.Drawing.Point(2, 59);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(483, 317);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Encryption - Decryption";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(18, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(465, 292);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.button_Text_Decrypt);
            this.tabPage1.Controls.Add(this.button_Text_Encrypt);
            this.tabPage1.Controls.Add(this.textBox_DeText);
            this.tabPage1.Controls.Add(this.textBox_EnText);
            this.tabPage1.Controls.Add(this.textBox_Text_Input);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(457, 266);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Text";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Decrypted Text:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 83);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(82, 13);
            this.label22.TabIndex = 20;
            this.label22.Text = "Encrypted Text:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 7);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(87, 13);
            this.label23.TabIndex = 19;
            this.label23.Text = "Input(Plain) Text:";
            // 
            // button_Text_Decrypt
            // 
            this.button_Text_Decrypt.Location = new System.Drawing.Point(99, 237);
            this.button_Text_Decrypt.Name = "button_Text_Decrypt";
            this.button_Text_Decrypt.Size = new System.Drawing.Size(75, 23);
            this.button_Text_Decrypt.TabIndex = 18;
            this.button_Text_Decrypt.Text = "Decrypt";
            this.button_Text_Decrypt.UseVisualStyleBackColor = true;
            this.button_Text_Decrypt.Click += new System.EventHandler(this.button_Text_Decrypt_Click);
            // 
            // button_Text_Encrypt
            // 
            this.button_Text_Encrypt.Location = new System.Drawing.Point(6, 237);
            this.button_Text_Encrypt.Name = "button_Text_Encrypt";
            this.button_Text_Encrypt.Size = new System.Drawing.Size(75, 23);
            this.button_Text_Encrypt.TabIndex = 17;
            this.button_Text_Encrypt.Text = "Encrypt";
            this.button_Text_Encrypt.UseVisualStyleBackColor = true;
            this.button_Text_Encrypt.Click += new System.EventHandler(this.button_Text_Encrypt_Click);
            // 
            // textBox_DeText
            // 
            this.textBox_DeText.Location = new System.Drawing.Point(6, 178);
            this.textBox_DeText.Multiline = true;
            this.textBox_DeText.Name = "textBox_DeText";
            this.textBox_DeText.ReadOnly = true;
            this.textBox_DeText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_DeText.Size = new System.Drawing.Size(450, 55);
            this.textBox_DeText.TabIndex = 16;
            // 
            // textBox_EnText
            // 
            this.textBox_EnText.Location = new System.Drawing.Point(6, 99);
            this.textBox_EnText.Multiline = true;
            this.textBox_EnText.Name = "textBox_EnText";
            this.textBox_EnText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_EnText.Size = new System.Drawing.Size(450, 55);
            this.textBox_EnText.TabIndex = 15;
            this.textBox_EnText.TextChanged += new System.EventHandler(this.textBox_EnText_TextChanged);
            // 
            // textBox_Text_Input
            // 
            this.textBox_Text_Input.Location = new System.Drawing.Point(6, 23);
            this.textBox_Text_Input.Multiline = true;
            this.textBox_Text_Input.Name = "textBox_Text_Input";
            this.textBox_Text_Input.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Text_Input.Size = new System.Drawing.Size(450, 55);
            this.textBox_Text_Input.TabIndex = 14;
            this.textBox_Text_Input.TextChanged += new System.EventHandler(this.textBox_Text_Input_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.button_File_Decrypt);
            this.tabPage2.Controls.Add(this.button_EnFile_Browse);
            this.tabPage2.Controls.Add(this.button_File_Encrypt);
            this.tabPage2.Controls.Add(this.button_File_Browse);
            this.tabPage2.Controls.Add(this.button_DeFile_Browse);
            this.tabPage2.Controls.Add(this.textBox_DeFile);
            this.tabPage2.Controls.Add(this.textBox_EnFile);
            this.tabPage2.Controls.Add(this.textBox_File_Input);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(457, 266);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "File";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Decrypted File:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(205, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Encrypted File(Browse and Click Decrypt):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Input File(Browse and Click Encrypt):";
            // 
            // button_File_Decrypt
            // 
            this.button_File_Decrypt.Location = new System.Drawing.Point(99, 237);
            this.button_File_Decrypt.Name = "button_File_Decrypt";
            this.button_File_Decrypt.Size = new System.Drawing.Size(75, 23);
            this.button_File_Decrypt.TabIndex = 21;
            this.button_File_Decrypt.Text = "Decrypt";
            this.button_File_Decrypt.UseVisualStyleBackColor = true;
            this.button_File_Decrypt.Click += new System.EventHandler(this.button_File_Decrypt_Click);
            // 
            // button_EnFile_Browse
            // 
            this.button_EnFile_Browse.Location = new System.Drawing.Point(391, 97);
            this.button_EnFile_Browse.Name = "button_EnFile_Browse";
            this.button_EnFile_Browse.Size = new System.Drawing.Size(65, 23);
            this.button_EnFile_Browse.TabIndex = 20;
            this.button_EnFile_Browse.Text = "Browse";
            this.button_EnFile_Browse.UseVisualStyleBackColor = true;
            this.button_EnFile_Browse.Click += new System.EventHandler(this.button_EnFile_Browse_Click);
            // 
            // button_File_Encrypt
            // 
            this.button_File_Encrypt.Location = new System.Drawing.Point(6, 237);
            this.button_File_Encrypt.Name = "button_File_Encrypt";
            this.button_File_Encrypt.Size = new System.Drawing.Size(75, 23);
            this.button_File_Encrypt.TabIndex = 18;
            this.button_File_Encrypt.Text = "Encrypt";
            this.button_File_Encrypt.UseVisualStyleBackColor = true;
            this.button_File_Encrypt.Click += new System.EventHandler(this.button_File_Encrypt_Click);
            // 
            // button_File_Browse
            // 
            this.button_File_Browse.Location = new System.Drawing.Point(391, 21);
            this.button_File_Browse.Name = "button_File_Browse";
            this.button_File_Browse.Size = new System.Drawing.Size(65, 23);
            this.button_File_Browse.TabIndex = 17;
            this.button_File_Browse.Text = "Browse";
            this.button_File_Browse.UseVisualStyleBackColor = true;
            this.button_File_Browse.Click += new System.EventHandler(this.button_File_Browse_Click);
            // 
            // button_DeFile_Browse
            // 
            this.button_DeFile_Browse.Location = new System.Drawing.Point(391, 176);
            this.button_DeFile_Browse.Name = "button_DeFile_Browse";
            this.button_DeFile_Browse.Size = new System.Drawing.Size(65, 23);
            this.button_DeFile_Browse.TabIndex = 23;
            this.button_DeFile_Browse.Text = "Browse";
            this.button_DeFile_Browse.UseVisualStyleBackColor = true;
            this.button_DeFile_Browse.Click += new System.EventHandler(this.button_DeFile_Browse_Click);
            // 
            // textBox_DeFile
            // 
            this.textBox_DeFile.Location = new System.Drawing.Point(6, 178);
            this.textBox_DeFile.Name = "textBox_DeFile";
            this.textBox_DeFile.ReadOnly = true;
            this.textBox_DeFile.Size = new System.Drawing.Size(379, 20);
            this.textBox_DeFile.TabIndex = 22;
            // 
            // textBox_EnFile
            // 
            this.textBox_EnFile.Location = new System.Drawing.Point(6, 99);
            this.textBox_EnFile.Name = "textBox_EnFile";
            this.textBox_EnFile.Size = new System.Drawing.Size(379, 20);
            this.textBox_EnFile.TabIndex = 19;
            // 
            // textBox_File_Input
            // 
            this.textBox_File_Input.Location = new System.Drawing.Point(6, 23);
            this.textBox_File_Input.Name = "textBox_File_Input";
            this.textBox_File_Input.Size = new System.Drawing.Size(379, 20);
            this.textBox_File_Input.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Key(8 Character):";
            // 
            // CipherDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(489, 468);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "CipherDemo";
            this.Text = "AES & DES Cipher | ver1.0 ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.ComboBox comboBoxAlgorithm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox_DeText;
        private System.Windows.Forms.TextBox textBox_EnText;
        private System.Windows.Forms.TextBox textBox_Text_Input;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button button_Text_Decrypt;
        private System.Windows.Forms.Button button_Text_Encrypt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_File_Decrypt;
        private System.Windows.Forms.Button button_EnFile_Browse;
        private System.Windows.Forms.Button button_File_Encrypt;
        private System.Windows.Forms.Button button_File_Browse;
        private System.Windows.Forms.Button button_DeFile_Browse;
        private System.Windows.Forms.TextBox textBox_DeFile;
        private System.Windows.Forms.TextBox textBox_EnFile;
        private System.Windows.Forms.TextBox textBox_File_Input;
        
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;

    }
}

