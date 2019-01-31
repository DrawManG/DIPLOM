//Copyright (c), October 2007, Some Rights Reserved 
//By Murat Firat

using System;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Cipher;


namespace Cipher
{
    public partial class CipherDemo : Form
    {
        private AESProvider AesProvider;
        private DESProvider DesProvider;

        //to invoke UI elements when required
        private delegate void UpdateUIHandler(string Message);

        //for asynchronous programming
        private delegate void ProcessCipherHandler(OperationType t);
        private ProcessCipherHandler ProcessCipherDelegate;
        private AsyncCallback AsyCall;

        //to hold start and elapsed time of threads
        private DateTime DTStart;
        private TimeSpan TSElapsed;

        private enum OperationType { EncryptText, DecryptText, EncryptFile, DecryptFile };
        //secondary thread must invoke the combobox to retrieve index. instead hold index at a variable
        private int ComboBoxIndex = 1;

        private bool exeptionOccured = false;
        private ManualResetEvent ManualStop = new ManualResetEvent(false);

        public CipherDemo()
        {
            InitializeComponent();
            InitComboBox();

            AesProvider = new AESProvider();
            DesProvider = new DESProvider();

            AesProvider.ProgressChanged += new ProgressEventHandler(Aes_ProgressChanged);
            DesProvider.ProgressChanged += new ProgressEventHandler(Des_ProgressChanged);

            ProcessCipherDelegate = new ProcessCipherHandler(ProcessCipher);
            AsyCall = new AsyncCallback(ProcessCompleted);
        }

        void Des_ProgressChanged(object o, ProgressEventArgs args)
        {
            TSElapsed = DateTime.Now.Subtract(DTStart);
            string Elapsed = TSElapsed.Hours.ToString("D2") + ":" +
                             TSElapsed.Minutes.ToString("D2") + ":" +
                             TSElapsed.Seconds.ToString("D2");

            Update_ProgressBar(args.progress.ToString());
            Update_LabelTimer(Elapsed);

            if (ManualStop.WaitOne(0, false))
                args.stop = true;
        }

        void Aes_ProgressChanged(object o, ProgressEventArgs args)
        {
            TSElapsed = DateTime.Now.Subtract(DTStart);
            string Elapsed = TSElapsed.Hours.ToString("D2") + ":" +
                             TSElapsed.Minutes.ToString("D2") + ":" +
                             TSElapsed.Seconds.ToString("D2");

            Update_ProgressBar(args.progress.ToString());
            Update_LabelTimer(Elapsed);

            if (ManualStop.WaitOne(0, false))
                args.stop = true;
        }

        void ProcessCompleted(IAsyncResult r)
        {
            if (r.AsyncState is string)
            {
                if (!exeptionOccured)
                    if (ManualStop.WaitOne(0, false))
                        MessageBox.Show((string)r.AsyncState + "Aborted..", "Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show((string)r.AsyncState + "Completed..", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                Update_ProgressBar("0");
            }
        }

        private void button_Text_Encrypt_Click(object sender, EventArgs e)
        {
            ProcessCipherDelegate.BeginInvoke(OperationType.EncryptText, AsyCall, "syja ");
        }

        private void button_Text_Decrypt_Click(object sender, EventArgs e)
        {
            ProcessCipherDelegate.BeginInvoke(OperationType.DecryptText, AsyCall, "Decrypting Text ");
        }

        private void button_File_Encrypt_Click(object sender, EventArgs e)
        {
            ProcessCipherDelegate.BeginInvoke(OperationType.EncryptFile, AsyCall, "Encrypting File ");
        }

        private void button_File_Decrypt_Click(object sender, EventArgs e)
        {
            ProcessCipherDelegate.BeginInvoke(OperationType.DecryptFile, AsyCall, "Decrypting File ");
        }

        private void ProcessCipher(OperationType OpType)
        {
            DTStart = DateTime.Now;
            exeptionOccured = false;
            ManualStop.Reset();

            try
            {
                if (OpType == OperationType.DecryptFile)
                {
                    if (!File.Exists(textBox_EnFile.Text))
                    {
                        throw new Exception("File Does Not Exist: " + textBox_EnFile.Text);
                    }

                    if (ComboBoxIndex == 0)
                    {
                        DesProvider.Decrypt(textBox_EnFile.Text, textBox_DeFile.Text, textBoxKey.Text);
                    }
                    else
                    {
                        AesProvider.Decrypt(textBox_EnFile.Text, textBox_DeFile.Text, textBoxKey.Text);
                    }
                }
                else if (OpType == OperationType.EncryptFile)
                {
                    if (!File.Exists(textBox_File_Input.Text))
                    {
                        throw new Exception("File Does Not Exist: " + textBox_File_Input.Text);
                    }

                    if (ComboBoxIndex == 0)
                    {
                        DesProvider.Encrypt(textBox_File_Input.Text, textBox_EnFile.Text, textBoxKey.Text);
                    }
                    else
                    {
                        AesProvider.Encrypt(textBox_File_Input.Text, textBox_EnFile.Text, textBoxKey.Text);
                    }
                }
                else if (OpType == OperationType.DecryptText)
                {
                    if (ComboBoxIndex == 0)
                    {
                        byte[] EnBytesBuffer = Convert.FromBase64String(textBox_EnText.Text);
                        Update_DecryptedText(Encoding.ASCII.GetString
                            (DesProvider.Decrypt(EnBytesBuffer, textBoxKey.Text)));
                    }
                    else
                    {
                        byte[] EnBytesBuffer = Convert.FromBase64String(textBox_EnText.Text);
                        Update_DecryptedText(Encoding.ASCII.GetString
                            (AesProvider.Decrypt(EnBytesBuffer, textBoxKey.Text)));
                    }
                }
                else if (OpType == OperationType.EncryptText)
                {
                    if (ComboBoxIndex == 0)
                    {
                        byte[] EnBytesBuffer = DesProvider.Encrypt(Encoding.ASCII.GetBytes(textBox_Text_Input.Text), textBoxKey.Text);
                        Update_EncryptedText(Convert.ToBase64String(EnBytesBuffer));
                    }
                    else
                    {
                        byte[] EnBytesBuffer = AesProvider.Encrypt(Encoding.ASCII.GetBytes(textBox_Text_Input.Text), textBoxKey.Text);
                        Update_EncryptedText(Convert.ToBase64String(EnBytesBuffer));
                    }
                }
            }
            catch (Exception e)
            {
                exeptionOccured = true;
                MessageBox.Show("Error: " + e.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            ManualStop.Set();
        }

        #region Update UI Components If Required, Event Handlers For UI Elements and etc..
        private void Update_EncryptedText(string Text)
        {
            if (textBox_EnText.InvokeRequired)
            {
                textBox_EnText.Invoke(new UpdateUIHandler(Update_EncryptedText), Text);
            }
            else
            {
                textBox_EnText.Text = Text;
            }
        }

        private void Update_DecryptedText(string Text)
        {
            if (textBox_DeText.InvokeRequired)
            {
                textBox_DeText.Invoke(new UpdateUIHandler(Update_DecryptedText), Text);
            }
            else
            {
                textBox_DeText.Text = Text;
            }
        }

        private void Update_ProgressBar(string Value)
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new UpdateUIHandler(Update_ProgressBar), Value);
            }
            else
            {
                progressBar.Value = Int16.Parse(Value);
            }
        }

        private void Update_LabelTimer(string Elapsed)
        {
            if (labelTimer.InvokeRequired)
            {
                labelTimer.Invoke(new UpdateUIHandler(Update_LabelTimer), Elapsed);
            }
            else
            {
                labelTimer.Text = Elapsed;
            }
        }

        private void InitComboBox()
        {
            comboBoxAlgorithm.Items.Add("DES (64 Bit)");
            comboBoxAlgorithm.Items.Add("AES (128 Bit)");
            comboBoxAlgorithm.Items.Add("AES (192 Bit)");
            comboBoxAlgorithm.Items.Add("AES (256 Bit)");
            comboBoxAlgorithm.SelectedIndex = ComboBoxIndex;
        }

        private void comboBoxAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAlgorithm.SelectedIndex == 0)
            {
                textBoxKey.MaxLength = 8;
                textBoxKey.Text = "DefaultK";
                labelKey.Text = "Key(8 Characters):";
                ComboBoxIndex = 0;
            }
            else if (comboBoxAlgorithm.SelectedIndex == 1)
            {
                textBoxKey.MaxLength = 16;
                textBoxKey.Text = "DefaultKeyForAes";
                labelKey.Text = "Key(16 Characters):";
                ComboBoxIndex = 1;
            }
            else if (comboBoxAlgorithm.SelectedIndex == 2)
            {
                textBoxKey.MaxLength = 24;
                textBoxKey.Text = "DefaultKeyForAes192BitAl";
                labelKey.Text = "Key(24 Characters):";
                ComboBoxIndex = 2;
            }
            else if (comboBoxAlgorithm.SelectedIndex == 3)
            {
                textBoxKey.MaxLength = 32;
                textBoxKey.Text = "DefaultKeyForAes256BitAlgorithm.";
                labelKey.Text = "Key(32 Characters):";
                ComboBoxIndex = 3;
            }

        }

        private void button_File_Browse_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "All File Types(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_File_Input.Text = openFileDialog.FileName;
                textBox_EnFile.Text = openFileDialog.FileName + ".enc";
                textBox_DeFile.Text = openFileDialog.FileName + ".enc" + Path.GetExtension(openFileDialog.FileName);

            }
        }

        private void button_EnFile_Browse_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Encrypted File(*.enc)|*.enc";
            openFileDialog.Filter += "|All File Types(*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_EnFile.Text = openFileDialog.FileName;
            }
        }

        private void button_DeFile_Browse_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "All File Types(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_DeFile.Text = saveFileDialog.FileName;
            }
        }

        private void textBoxKey_Leave(object sender, EventArgs e)
        {
            if (comboBoxAlgorithm.SelectedIndex == 0 && textBoxKey.Text.Length != 8)
            {
                MessageBox.Show("Key Must Be 8 Characters Long..", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxKey.Text = "DefaultK";
            }
            else if (comboBoxAlgorithm.SelectedIndex == 1 && textBoxKey.Text.Length != 16)
            {
                MessageBox.Show("Key Must Be 16 Characters Long..", "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxKey.Text = "DefaultKeyForAes";
            }
            else if (comboBoxAlgorithm.SelectedIndex == 2 && textBoxKey.Text.Length != 24)
            {
                MessageBox.Show("Key Must Be 24 Characters Long..", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxKey.Text = "DefaultKeyForAes192BitAl";
            }
            else if (comboBoxAlgorithm.SelectedIndex == 3 && textBoxKey.Text.Length != 32)
            {
                MessageBox.Show("Key Must Be 32 Characters Long..", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxKey.Text = "DefaultKeyForAes256BitAlgorithm.";
            }
        }
        #endregion

        private void textBox_Text_Input_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_EnText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}