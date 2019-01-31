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
            this.KEY = new System.Windows.Forms.TextBox();
            this.labelKey = new System.Windows.Forms.Label();
            this.Algorithm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.VHOD = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.deshifr = new System.Windows.Forms.Button();
            this.put_shifr = new System.Windows.Forms.Button();
            this.shifr = new System.Windows.Forms.Button();
            this.put = new System.Windows.Forms.Button();
            this.put_rash = new System.Windows.Forms.Button();
            this.RASHIFR = new System.Windows.Forms.TextBox();
            this.VIHOD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelTimer = new System.Windows.Forms.Label();
            this.ostanovka = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.KEY);
            this.groupBox1.Controls.Add(this.labelKey);
            this.groupBox1.Controls.Add(this.Algorithm);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // KEY
            // 
            this.KEY.Location = new System.Drawing.Point(288, 17);
            this.KEY.MaxLength = 8;
            this.KEY.Name = "KEY";
            this.KEY.Size = new System.Drawing.Size(181, 20);
            this.KEY.TabIndex = 3;
            this.KEY.Leave += new System.EventHandler(this.textBoxKey_Leave);
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(249, 20);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(33, 13);
            this.labelKey.TabIndex = 2;
            this.labelKey.Text = "Ключ";
            // 
            // Algorithm
            // 
            this.Algorithm.FormattingEnabled = true;
            this.Algorithm.Location = new System.Drawing.Point(75, 17);
            this.Algorithm.Name = "Algorithm";
            this.Algorithm.Size = new System.Drawing.Size(98, 21);
            this.Algorithm.TabIndex = 1;
            this.Algorithm.SelectedIndexChanged += new System.EventHandler(this.comboBoxAlgorithm_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Алгоритм";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tabControl1);
            this.groupBox3.Location = new System.Drawing.Point(2, 59);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(483, 317);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(465, 292);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage2.Controls.Add(this.VHOD);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.deshifr);
            this.tabPage2.Controls.Add(this.put_shifr);
            this.tabPage2.Controls.Add(this.shifr);
            this.tabPage2.Controls.Add(this.put);
            this.tabPage2.Controls.Add(this.put_rash);
            this.tabPage2.Controls.Add(this.RASHIFR);
            this.tabPage2.Controls.Add(this.VIHOD);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(457, 266);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Шифрования документов (указание пути)";
            // 
            // VHOD
            // 
            this.VHOD.Location = new System.Drawing.Point(6, 23);
            this.VHOD.Name = "VHOD";
            this.VHOD.Size = new System.Drawing.Size(379, 20);
            this.VHOD.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Расшифрованный файл";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Ваш зашифрованный файл\r\n";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 26);
            this.label9.TabIndex = 24;
            this.label9.Text = "Выберите файл для шифрования\r\n\r\n";
            // 
            // deshifr
            // 
            this.deshifr.Location = new System.Drawing.Point(318, 237);
            this.deshifr.Name = "deshifr";
            this.deshifr.Size = new System.Drawing.Size(99, 23);
            this.deshifr.TabIndex = 21;
            this.deshifr.Text = "Дешифрование";
            this.deshifr.UseVisualStyleBackColor = true;
            this.deshifr.Click += new System.EventHandler(this.button_File_Decrypt_Click);
            // 
            // put_shifr
            // 
            this.put_shifr.Location = new System.Drawing.Point(391, 97);
            this.put_shifr.Name = "put_shifr";
            this.put_shifr.Size = new System.Drawing.Size(65, 23);
            this.put_shifr.TabIndex = 20;
            this.put_shifr.Text = "Путь";
            this.put_shifr.UseVisualStyleBackColor = true;
            this.put_shifr.Click += new System.EventHandler(this.button_EnFile_Browse_Click);
            // 
            // shifr
            // 
            this.shifr.Location = new System.Drawing.Point(27, 237);
            this.shifr.Name = "shifr";
            this.shifr.Size = new System.Drawing.Size(87, 23);
            this.shifr.TabIndex = 18;
            this.shifr.Text = "Шифрования";
            this.shifr.UseVisualStyleBackColor = true;
            this.shifr.Click += new System.EventHandler(this.button_File_Encrypt_Click);
            // 
            // put
            // 
            this.put.Location = new System.Drawing.Point(391, 21);
            this.put.Name = "put";
            this.put.Size = new System.Drawing.Size(65, 23);
            this.put.TabIndex = 17;
            this.put.Text = "Путь";
            this.put.UseVisualStyleBackColor = true;
            this.put.Click += new System.EventHandler(this.button_File_Browse_Click);
            // 
            // put_rash
            // 
            this.put_rash.Location = new System.Drawing.Point(391, 176);
            this.put_rash.Name = "put_rash";
            this.put_rash.Size = new System.Drawing.Size(65, 23);
            this.put_rash.TabIndex = 23;
            this.put_rash.Text = "Путь";
            this.put_rash.UseVisualStyleBackColor = true;
            this.put_rash.Click += new System.EventHandler(this.button_DeFile_Browse_Click);
            // 
            // RASHIFR
            // 
            this.RASHIFR.Location = new System.Drawing.Point(6, 178);
            this.RASHIFR.Name = "RASHIFR";
            this.RASHIFR.ReadOnly = true;
            this.RASHIFR.Size = new System.Drawing.Size(379, 20);
            this.RASHIFR.TabIndex = 22;
            // 
            // VIHOD
            // 
            this.VIHOD.Location = new System.Drawing.Point(6, 99);
            this.VIHOD.Name = "VIHOD";
            this.VIHOD.Size = new System.Drawing.Size(379, 20);
            this.VIHOD.TabIndex = 19;
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
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(19, 19);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(450, 22);
            this.progressBar.TabIndex = 1;
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(405, 60);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(49, 13);
            this.labelTimer.TabIndex = 2;
            this.labelTimer.Text = "00:00:00";
            this.labelTimer.Click += new System.EventHandler(this.labelTimer_Click);
            // 
            // ostanovka
            // 
            this.ostanovka.Location = new System.Drawing.Point(19, 50);
            this.ostanovka.Name = "ostanovka";
            this.ostanovka.Size = new System.Drawing.Size(166, 23);
            this.ostanovka.TabIndex = 3;
            this.ostanovka.Text = "Остановить процесс";
            this.ostanovka.UseVisualStyleBackColor = true;
            this.ostanovka.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.ostanovka);
            this.groupBox2.Controls.Add(this.labelTimer);
            this.groupBox2.Controls.Add(this.progressBar);
            this.groupBox2.Location = new System.Drawing.Point(2, 382);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 82);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
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
            this.Text = "DOCUMENTO";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.ComboBox Algorithm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox KEY;
        private System.Windows.Forms.GroupBox groupBox3;
        
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox VHOD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button deshifr;
        private System.Windows.Forms.Button put_shifr;
        private System.Windows.Forms.Button shifr;
        private System.Windows.Forms.Button put;
        private System.Windows.Forms.Button put_rash;
        private System.Windows.Forms.TextBox RASHIFR;
        private System.Windows.Forms.TextBox VIHOD;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Button ostanovka;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

