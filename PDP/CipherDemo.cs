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
                        MessageBox.Show((string)r.AsyncState + "Ошибка", "Внимание",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show((string)r.AsyncState + "Выполнено", "Информация",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                Update_ProgressBar("0");
            }
        }

        private void button_Text_Encrypt_Click(object sender, EventArgs e)
        {
            ProcessCipherDelegate.BeginInvoke(OperationType.EncryptText, AsyCall, "Зашифрован файл ");
        }

        private void button_Text_Decrypt_Click(object sender, EventArgs e)
        {
            ProcessCipherDelegate.BeginInvoke(OperationType.DecryptText, AsyCall, "Разшифрован файл ");
        }

        private void button_File_Encrypt_Click(object sender, EventArgs e)
        {
            ProcessCipherDelegate.BeginInvoke(OperationType.EncryptFile, AsyCall, "Зашифрован файл ");
        }

        private void button_File_Decrypt_Click(object sender, EventArgs e)
        {
            ProcessCipherDelegate.BeginInvoke(OperationType.DecryptFile, AsyCall, "Разшифрован файл ");
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
                    if (!File.Exists(VIHOD.Text))
                    {
                        throw new Exception("Файл не найден по этому пути: " + VIHOD.Text);
                    }

                    if (ComboBoxIndex == 0)
                    {
                        DesProvider.Decrypt(VIHOD.Text, RASHIFR.Text, KEY.Text);
                    }
                    else
                    {
                        AesProvider.Decrypt(VIHOD.Text, RASHIFR.Text, KEY.Text);
                    }
                }
                else if (OpType == OperationType.EncryptFile)
                {
                    if (!File.Exists(VHOD.Text))
                    {
                        throw new Exception("Файл не найден: " + VHOD.Text);
                    }

                    if (ComboBoxIndex == 0)
                    {
                        DesProvider.Encrypt(VHOD.Text, VIHOD.Text, KEY.Text);
                    }
                    else
                    {
                        AesProvider.Encrypt(VHOD.Text, VIHOD.Text, KEY.Text);
                    }
                }
                else if (OpType == OperationType.DecryptText)
                {
                    if (ComboBoxIndex == 0)
                    {
                       
                    }
                    else
                    {
                   
                    }
                }
                else if (OpType == OperationType.EncryptText)
                {
                    if (ComboBoxIndex == 0)
                    {
                      
                    }
                    else
                    {
               
                    }
                }
            }
            catch (Exception e)
            {
                exeptionOccured = true;
                MessageBox.Show("Ошибка: " + e.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            ManualStop.Set();
        }

        #region Update UI Components If Required, Event Handlers For UI Elements and etc..
        
          
        
        

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
            Algorithm.Items.Add("DES (128 Bit)");
            Algorithm.Items.Add("AES (128 Bit)");
            
            Algorithm.SelectedIndex = ComboBoxIndex;
        }

        private void comboBoxAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Algorithm.SelectedIndex == 0)
            {
                KEY.MaxLength = 8;
                KEY.Text = "ESHKETIT";
                
                ComboBoxIndex = 0;
            }
            else if (Algorithm.SelectedIndex == 1)
            {
                KEY.MaxLength = 16;
                KEY.Text = "ESHKETIT_LILPUMP";
             
                ComboBoxIndex = 1;
            }
            

        }

        private void button_File_Browse_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "All File Types(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                VHOD.Text = openFileDialog.FileName;
                VIHOD.Text = openFileDialog.FileName + ".enc";
                RASHIFR.Text = openFileDialog.FileName + ".enc" + Path.GetExtension(openFileDialog.FileName);

            }
        }

        private void button_EnFile_Browse_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "файл (*.enc)|*.enc";
            openFileDialog.Filter += "|Все виды файлов (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                VIHOD.Text = openFileDialog.FileName;
            }
        }

        private void button_DeFile_Browse_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Все виды файлов (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                RASHIFR.Text = saveFileDialog.FileName;
            }
        }

        private void textBoxKey_Leave(object sender, EventArgs e)
        {
            if (Algorithm.SelectedIndex == 0 && KEY.Text.Length != 8)
            {
                MessageBox.Show("Ключ не подходит", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                KEY.Text = "ESHKETIT";
            }
            else if (Algorithm.SelectedIndex == 1 && KEY.Text.Length != 16)
            {
                MessageBox.Show("Key Must Be 16 Characters Long..", "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                KEY.Text = "ESHKETIT_LILPUMP";
            }
           
        }
        #endregion

        private void labelTimer_Click(object sender, EventArgs e)
        {

        }
    }
}