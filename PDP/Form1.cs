using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;
using System.Security.Cryptography;
using Cipher;
using System.Threading;

namespace PDP
{
    public partial class Form1 : Form
    {
        private AESProvider AesProvider;
        private DESProvider DesProvider;

        //to invoke UI elements when required
        private delegate void UpdateUIHandler(string Message);

        //for asynchronous programming
        private delegate void ProcessCipherHandler(OperationType t);

        private ProcessCipherHandler ProcessCipherDelegate;
        private AsyncCallback AsyCall;

        private enum OperationType { EncryptText, DecryptText, EncryptFile, DecryptFile };
        //secondary thread must invoke the combobox to retrieve index. instead hold index at a variable



        private ManualResetEvent ManualStop = new ManualResetEvent(false);

        public Form1()
        {
            InitializeComponent();
            ProcessCipherDelegate = new ProcessCipherHandler(ProcessCipher);
        }

        // документы для подключения
        private readonly string TemplateFileName2 = @"L:\\PDP\\PDP\\source\\obrashenie.docx";
        private readonly string TemplateFileName1 = @"L:\\PDP\\PDP\\source\\predostavlenie.docx";
        private readonly string TemplateFileName = @"L:\\PDP\\PDP\\source\\pismo.docx";
        public static string sdwConnectionString1 = @"Data Source = DESKTOP-34MR68E\DEPISHMOD; user id=sa; password=12; Initial Catalog = PDP;Persist Security Info=True;";

        public int ComboBoxIndex { get; private set; }

        private void Form1_Load(object sender, EventArgs e)
        {

            //закрытие форм
            ADMIN_ACC.Visible = false;
            label34.Visible = false;
            panel_Obrashenie.Visible = false;
            Obrashenie_menu.Visible = false;
            panel_pismo.Visible = false;
            panel_pismo_menu.Visible = false;
            panel_predostavlenie_menu.Visible = false;
            panel_predostavlenie.Visible = false;

            this.Width = 313;
            this.Height = 486;
            panel1.Width = 1313;
            panel1.Height = 986;
            panel1.Visible = false;
            //izmenit' kod
            SqlConnection sad = new SqlConnection(@"Data Source=DESKTOP-34MR68E\DEPISHMOD;Initial Catalog=PDP;Integrated Security=True");
            sad.Open();

            try
            {



                label4.Text = "Есть подключение к базе";
                label5.Text = "Есть подключение к базе";
            }

            catch
            {
                MessageBox.Show("error, обратитесь к администратору");
                label4.Text = "Нету подключения к базе";
                label5.Text = "Нету подключения к базе";
            }
        }

        
        

        private void ProcessCipher(OperationType OpType)
        {
            
          

            try
            {
                if (OpType == OperationType.EncryptText)
                {

                    byte[] EnBytesBuffer = DesProvider.Encrypt(Encoding.ASCII.GetBytes(textBox1.Text), "ESHKETIT");
                    Update_EncryptedText_LOGIN(Convert.ToBase64String(EnBytesBuffer));

                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Error: " + e.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update_EncryptedText_LOGIN(string v)
        {
            throw new NotImplementedException();
        }

     
       

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
         
           
           

           
            //Если человек не знает о надписи Администратора
            if (ADMIN_ACC.Text == "")
            {
                ADMIN_ACC.Text = "Нет";
                panel_admin.Visible = false;
            }
            //Если написано не правильно и действия
            if (ADMIN_ACC.Text == "ДА" || ADMIN_ACC.Text == "Да")
            {
                ADMIN_ACC.Text = "Да";
                panel_admin.Visible = true;
            }
           

            //Проверка авторизации
            int count = 0;
            SqlConnection sad = new SqlConnection(@"Data Source=DESKTOP-34MR68E\DEPISHMOD;Initial Catalog=PDP;Integrated Security=True");
            sad.Open();
            SqlCommand cmd = new SqlCommand("Select *  from Sign1 where Login = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'and User_Prav = '" + ADMIN_ACC.Text + "'", sad);

            SqlDataReader dr;

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                count += 1;

            }
            if (count == 1)
            {
                MessageBox.Show("Вы успешно авторизировались ");
                this.Width = +1000;
                this.Height = +750;
                panel1.Visible = true;
                label34.Visible = false;


            }
            {
                if (count == 0)
                {
                    MessageBox.Show("Вы не правильно ввели данные");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                //using (SqlConnection sc = new SqlConnection(sdwConnectionString1))
                //{
                //    sc.Connection_Options("ACER\\LOXX", "LogParol");
                //    SqlConnection connectionUser = new SqlConnection(ConCheck.ConnectString);
                //    SqlCommand Select_USID = new SqlCommand("select [dbo].[Login_L].[ID_Login] " +
                //        "from [dbo].[Login_L] " +
                //        "where [login] = '" + textBox.Text + "' and [pass] = '" + passwordBox.Password + "'", connectionUser);
                //    SqlCommand Select_ISA = new SqlCommand("select [dbo].[roli].[Role_Name]" +
                //      " from [dbo].[Login_L] inner join[dbo].[roli] on " +
                //      "[dbo].[Login_L].[ID_roli] =[dbo].[roli].[ID_roli]" +
                //      "where [login]='" + textBox.Text + "' and [pass]='" + passwordBox.Password + "'", connectionUser);
                //    try
                //    {
                //        connectionUser.Open();
                //        USID = Select_USID.ExecuteScalar().ToString();
                //        ISA = Select_ISA.ExecuteScalar().ToString();
                //        connectionUser.Close();
                //        MessageBox.Show("Авторизация пройдена!");
                //        Podsis regi = new Podsis();
                //        this.Hide();
                //        regi.Show();
                //    }
                //    catch (Exception bl)
                //    {
                //        MessageBox.Show(bl.Message);
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("Введите данные!");
                //}



            }
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            //Word._Application application;
            //Word._Document document;
            //Object missingObj = System.Reflection.Missing.Value;
            //Object trueObj = true;
            //Object falseObj = false;

            ////создаем обьект приложения word
            //application = new Word.Application();
            //// создаем путь к файлу 
            //Object templatePathObj = "C:\\Users\\GreatRepit\\Desktop\\Димы\\kol.docx"; ;

            // если вылетим не этом этапе, приложение останется открытым
            //try
            //{
            //    document = application.Documents.Add(ref templatePathObj, ref missingObj, ref missingObj, ref missingObj);
            //}
            //catch (Exception error)
            //{
            //    document.Close(ref falseObj, ref missingObj, ref missingObj);
            //    application.Quit(ref missingObj, ref missingObj, ref missingObj);
            //    document = null;
            //    application = null;
            //    throw error;
            //}
            //_Application.Visible = true;
            // занесение данных 

            ////
            ////
            /////
            /////
            ///






            //
            //
            //
            // VIPISKI
            //
            //
            //




            var Kompaniya = komy_vipiska.Text;
            var ADRES = ADRES_Pismo.Text;
            var data = datatext_vipiska.Text;
            var nomer = nomer_pismo.Text;

            //-------------------------------------------------------------------------------------------------

            Random random = new Random();
            int a;
            a = random.Next(9999999);
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-34MR68E\DEPISHMOD; user id=sa; password=12; Initial Catalog = PDP;Persist Security Info=True;");
            con.Open();

            string sql = "INSERT INTO Pismo_save (id_pismo, komy_napr , ADRES, nomer_vipiska ,Data, Data_save, KTO_sdelal) Values ('" + Convert.ToString(a) + "','" + Convert.ToString(Kompaniya) + "','" + Convert.ToString(ADRES) + "','" + Convert.ToString(data) + "','" + Convert.ToString(nomer) + "','" + Convert.ToString(System.DateTime.Now.ToLongTimeString()) + "','" + Convert.ToString(textBox1.Text) + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            // ------------------------------------------------------------------------------------


            // экспорт документа Word
            var wordApp = new Word.Application();
            wordApp.Visible = false;
            try
            {
                var WordDocument = wordApp.Documents.Open(TemplateFileName);
                ReplaceWordstub("{Kompaniya}", Kompaniya, WordDocument);
                ReplaceWordstub("{ADRES}", ADRES, WordDocument);
                ReplaceWordstub("{data}", data, WordDocument);
                ReplaceWordstub("{nomer}", nomer, WordDocument);
                ReplaceWordstub("{Kompaniya1}", Kompaniya, WordDocument);

                // сохранение измененного документа 
                // WordDocument.SaveAs(@"C:\vipiska.docx");
                wordApp.Visible = true;
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }

        }
        // создание метода
        private void ReplaceWordstub(string StubtoReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: StubtoReplace, ReplaceWith: text);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel_pismo_menu.Visible = true;
            panel_pismo.Visible = true;
            panel_predostavlenie.Visible = false;
            panel_predostavlenie_menu.Visible = false;
            Obrashenie_menu.Width = 0;
            panel_Obrashenie.Width = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel_predostavlenie.Visible = true;
            panel_pismo_menu.Visible = false;
            Obrashenie_menu.Width = 0;
            panel_Obrashenie.Width = 0;
            panel_predostavlenie_menu.Visible = true;
            panel_predostavlenie.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel_Obrashenie.Visible = true;
            Obrashenie_menu.Visible = true;
            Obrashenie_menu.Width = 294;
            panel_Obrashenie.Width = 538;
            panel_pismo_menu.Visible = false;
            panel_predostavlenie.Visible = false;
            panel_predostavlenie_menu.Visible = false;
            panel_pismo.Visible = false;
            //if (panel_Obrashenie.Width == 0)
            //{
            //    panel_Obrashenie.Width = 660;
            //}

        }

        private void nomer_pismo1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int a;
            a = random.Next(9999999);
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-34MR68E\DEPISHMOD; user id=sa; password=12; Initial Catalog = PDP;Persist Security Info=True;");
            con.Open();

            string sql = "INSERT INTO Predostavlenie_save (id_predostavlenie, name_ogranizatii , Adres_organizatii, Data_obrashenie , Nomer_obrashenie, DATA_SAVE , KTO_sdelal) Values ('" + Convert.ToString(a) + "','" + Convert.ToString(nameOrgan_predostav.Text) + "','" + Convert.ToString(adresorg_predostav.Text) + "','" + Convert.ToString(data_predostav.Text) + "','" + Convert.ToString(Nomer_predostav.Text) + "','" + Convert.ToString(System.DateTime.Now.ToLongTimeString()) + "','" + Convert.ToString(textBox1.Text) + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            ///
            ///
            ///
            //                PREDSTAVLENIE
            ///
            ///
            ///
            ///
            ///
            ///
            ///

            var Name1 = nameOrgan_predostav.Text;
            var Adres1 = adresorg_predostav.Text;
            var date1 = data_predostav.Text;
            var nomer = Nomer_predostav.Text;
            var data_real = System.DateTime.Now.ToLongTimeString();
            

            // экспорт документа Word
            var wordApp = new Word.Application();
            wordApp.Visible = false;

           
            try
            {
                var WordDocument = wordApp.Documents.Open(TemplateFileName1);
                ReplaceWordstub("{NAME1}", Name1, WordDocument);
                ReplaceWordstub("{ADRES1}", Adres1, WordDocument);
                ReplaceWordstub("{DATE1}", date1, WordDocument);
                ReplaceWordstub("{NOMER1}", nomer, WordDocument);
                ReplaceWordstub("{NAME11}", Name1, WordDocument);


                wordApp.Visible = true;
            }
            catch
            {
          //      MessageBox.Show("Произошла ошибка!");
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
          
            ///
            ///
            ///
            //                OBRASHENIE
            ///
            ///
            ///
            ///
            ///
            ///
            ///

            var organ = organiz_Obrashenie.Text;
            var fio_admin = FIOadmin_Obrashenie.Text;
            var adres = ADRES_Obrashenie.Text;
            var io_admin = IOadmin_Obrashenie.Text;
            var data_obr = DATAobr_Obrashenie.Text;
            var nomer = NOMER_Obrashenie.Text;
            var data_moment = DATAmoment_Obrashenie.Text;
            
            //-------------------------------------------------------------------------------------------------

            Random random = new Random();
            int a;
            a = random.Next(9999999);
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-34MR68E\DEPISHMOD; user id=sa; password=12; Initial Catalog = PDP;Persist Security Info=True;");
            con.Open();

            string sql = "INSERT INTO Obrashenie_save (id_obrashenie, name_organizatii , Adres_organizatii, FamIO_Directora , Nomer_obrashenii, ImOtch_Directora, Data_obrasheniya, Data_moment, Data_Save, KTO_sdelal ) Values ('" + Convert.ToString(a) + "','" + Convert.ToString(organ) + "','" + Convert.ToString(adres) + "','" + Convert.ToString(fio_admin) + "','" + Convert.ToString(nomer) + "','" + Convert.ToString(io_admin) + "','" + Convert.ToString(data_obr) + "','" + Convert.ToString(data_moment) + "','" + Convert.ToString(System.DateTime.Now.ToLongTimeString()) + "','" + Convert.ToString(textBox1.Text) + "')"; 
          SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            // ------------------------------------------------------------------------------------


            // экспорт документа Word
            var wordApp = new Word.Application();
            wordApp.Visible = false;
            try
            {
                var WordDocument = wordApp.Documents.Open(TemplateFileName2);
                ReplaceWordstub("{ORGAN}", organ, WordDocument);
                ReplaceWordstub("{FIO ADMIN}", fio_admin, WordDocument);
                ReplaceWordstub("{ADRES}", adres, WordDocument);
                ReplaceWordstub("{IO ADMIN}", io_admin, WordDocument);
                ReplaceWordstub("{DATA_OBR}", data_obr, WordDocument);
                ReplaceWordstub("{NOMER}", nomer, WordDocument);
                ReplaceWordstub("{DATA_MOMENT}", data_moment, WordDocument);


                wordApp.Visible = true;
            }
            catch
            {
            //    MessageBox.Show("Произошла ошибка!");
            }

        }

        private void nomer_pismo_TextChanged(object sender, EventArgs e)
        {

        }

        private void datatext_vipiska_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Registration sa = new Registration();
            sa.Show();
            //this.Visible=false;
        }

        private void Form1_MaximumSizeChanged(object sender, EventArgs e)
        {
            MaximumSize = MinimumSize;
        }

        private void Form1_MinimumSizeChanged(object sender, EventArgs e)
        {
            MinimumSize = MaximumSize;
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            ADMIN_ACC.Visible = true;
        }

        private void ADMIN_ACC_Enter(object sender, EventArgs e)
        {
            //ADMIN_ACC.Visible = false;
            //label34.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ADMIN_ACC.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label34.Visible = true;
            ADMIN_ACC.Visible = true;
        }

        private void FIOadmin_Obrashenie_TextChanged(object sender, EventArgs e)
        {

        }

        private void FIOadmin_Obrashenie_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void IOadmin_Obrashenie_KeyDown(object sender, KeyEventArgs e)
        {
            IOTEXT.Text = ". " + IOadmin_Obrashenie.Text + "  ";
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
            Random random = new Random();
            int a;
            a = random.Next(9999999);
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-34MR68E\DEPISHMOD; user id=sa; password=12; Initial Catalog = PDP;Persist Security Info=True;");
            con.Open();

            string sql = "INSERT INTO Predostavlenie_save (id_predostavlenie, name_ogranizatii , Adres_organizatii, Data_obrashenie , Nomer_obrashenie, DATA_SAVE , KTO_sdelal) Values ('" + Convert.ToString(a) + "','" + Convert.ToString(nameOrgan_predostav.Text) + "','" + Convert.ToString(adresorg_predostav.Text) + "','" + Convert.ToString(data_predostav.Text) + "','" + Convert.ToString(Nomer_predostav.Text) + "','" + Convert.ToString(System.DateTime.Now.ToLongTimeString()) + "','" + Convert.ToString(textBox1.Text) + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            //______________________________________________________________________________
            var Name1 = nameOrgan_predostav.Text;
            var Adres1 = adresorg_predostav.Text;
            var date1 = data_predostav.Text;
            var nomer = Nomer_predostav.Text;

            // экспорт документа Word
            var wordApp = new Word.Application();
            wordApp.Visible = false;
            try
            {
                var WordDocument = wordApp.Documents.Open(TemplateFileName1);
                ReplaceWordstub("{NAME1}", Name1, WordDocument);
                ReplaceWordstub("{ADRES1}", Adres1, WordDocument);
                ReplaceWordstub("{DATE1}", date1, WordDocument);
                ReplaceWordstub("{NOMER1}", nomer, WordDocument);
                ReplaceWordstub("{NAME11}", Name1, WordDocument);


                if (!Directory.Exists(Environment.CurrentDirectory + "\\PREDOSTAVLENIE\\" + "" + Name1))
                    Directory.CreateDirectory(Environment.CurrentDirectory + "\\PREDOSTAVLENIE\\" + "" + Name1);
                Word.Document DocWord = wordApp.Application.ActiveDocument;
                DocWord.SaveAs2(Environment.CurrentDirectory + "\\PREDOSTAVLENIE\\" + Name1 + "\\Test " + nomer + ".docx");
                //string path = @"C:\DOCUMENTO";
                //string subpath = @"pismo";
                //DirectoryInfo dirInfo = new DirectoryInfo(path);
                //if (!dirInfo.Exists)
                //{
                //    dirInfo.Create();
                //}
                //dirInfo.CreateSubdirectory(subpath);

                //___________________________________________________________________________________


                DocWord.ExportAsFixedFormat(Environment.CurrentDirectory + "\\PREDOSTAVLENIE\\" + "" + Name1 + "\\Test " + nomer + ".pdf", Word.WdExportFormat.wdExportFormatPDF);
                File.OpenRead(Environment.CurrentDirectory + "\\PREDOSTAVLENIE\\" + Name1 + "\\Test " + nomer + ".pdf");
                //File.Delete(Environment.CurrentDirectory + "\\PREDOSTAVLENIE\\" + Name1 + "\\Test " + nomer + ".docx");


                MessageBox.Show("Документ готов. Он лежит сдесь:  " + Environment.CurrentDirectory + "\\PREDOSTAVLENIE\\" + Name1 + "\\Test " + nomer + ".pdf");
            }
            catch
            {
              //  MessageBox.Show("error");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
            var organ = organiz_Obrashenie.Text;
            var fio_admin = FIOadmin_Obrashenie.Text;
            var adres = ADRES_Obrashenie.Text;
            var io_admin = IOadmin_Obrashenie.Text;
            var data_obr = DATAobr_Obrashenie.Text;
            var nomer = NOMER_Obrashenie.Text;
            var data_moment = DATAmoment_Obrashenie.Text;
            //-------------------------------------------------------------------------------------------------

            Random random = new Random();
            int a;
            a = random.Next(9999999);
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-34MR68E\DEPISHMOD; user id=sa; password=12; Initial Catalog = PDP;Persist Security Info=True;");
            con.Open();

            string sql = "INSERT INTO Obrashenie_save (id_obrashenie, name_organizatii , Adres_organizatii, FamIO_Directora , Nomer_obrashenii, ImOtch_Directora, Data_obrasheniya, Data_moment, Data_Save, KTO_sdelal ) Values ('" + Convert.ToString(a) + "','" + Convert.ToString(organ) + "','" + Convert.ToString(adres) + "','" + Convert.ToString(fio_admin) + "','" + Convert.ToString(nomer) + "','" + Convert.ToString(io_admin) + "','" + Convert.ToString(data_obr) + "','" + Convert.ToString(data_moment) + "','" + Convert.ToString(System.DateTime.Now.ToLongTimeString()) + "','" + Convert.ToString(textBox1.Text) + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            // ------------------------------------------------------------------------------------


            // экспорт документа Word
            var wordApp = new Word.Application();
            wordApp.Visible = false;
            try
            {
                var WordDocument = wordApp.Documents.Open(TemplateFileName2);
                ReplaceWordstub("{ORGAN}", organ, WordDocument);
                ReplaceWordstub("{FIO ADMIN}", fio_admin, WordDocument);
                ReplaceWordstub("{ADRES}", adres, WordDocument);
                ReplaceWordstub("{IO ADMIN}", io_admin, WordDocument);
                ReplaceWordstub("{DATA_OBR}", data_obr, WordDocument);
                ReplaceWordstub("{NOMER}", nomer, WordDocument);
                ReplaceWordstub("{DATA_MOMENT}", data_moment, WordDocument);
                Word.Document DocWord = wordApp.Application.ActiveDocument;
                if (!Directory.Exists(Environment.CurrentDirectory + "\\OBRASHENIE\\" + "" + organ))
                    Directory.CreateDirectory(Environment.CurrentDirectory + "\\OBRASHENIE\\" + "" + organ);
                DocWord.SaveAs2(Environment.CurrentDirectory + "\\OBRASHENIE\\" + organ + "\\Test " + nomer + ".docx");
                //string path = @"C:\DOCUMENTO";
                //string subpath = @"pismo";
                //DirectoryInfo dirInfo = new DirectoryInfo(path);
                //if (!dirInfo.Exists)
                //{
                //    dirInfo.Create();
                //}
                //dirInfo.CreateSubdirectory(subpath);

                //___________________________________________________________________________________


                DocWord.ExportAsFixedFormat(Environment.CurrentDirectory + "\\OBRASHENIE\\" + "" + organ + "\\Test " + nomer + ".pdf", Word.WdExportFormat.wdExportFormatPDF);
                File.OpenRead(Environment.CurrentDirectory + "\\OBRASHENIE\\" + organ + "\\Test " + nomer + ".pdf");
                //  File.Delete(Environment.CurrentDirectory + "\\OBRASHENIE\\" + organ + "\\Test " + nomer + ".docx");

                MessageBox.Show("Документ готов. Он лежит сдесь:  "+Environment.CurrentDirectory + "\\OBRASHENIE\\" + organ + "\\Test " + nomer + ".pdf");
            }
            catch
            {
               // MessageBox.Show("error");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
            var Kompaniya = komy_vipiska.Text;
            var ADRES = ADRES_Pismo.Text;
            var data = datatext_vipiska.Text;
            var nomer = nomer_pismo.Text;

            //-------------------------------------------------------------------------------------------------

            Random random = new Random();
            int a;
            a = random.Next(9999999);
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-34MR68E\DEPISHMOD; user id=sa; password=12; Initial Catalog = PDP;Persist Security Info=True;");
            con.Open();

            string sql = "INSERT INTO Pismo_save (id_pismo, komy_napr , ADRES, nomer_vipiska ,Data, Data_save, KTO_sdelal) Values ('" + Convert.ToString(a) + "','" + Convert.ToString(Kompaniya) + "','" + Convert.ToString(ADRES) + "','" + Convert.ToString(data) + "','" + Convert.ToString(nomer) + "','" + Convert.ToString(System.DateTime.Now.ToLongTimeString()) + "','" + Convert.ToString(textBox1.Text) + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            // ------------------------------------------------------------------------------------

            // экспорт документа Word
            var wordApp = new Word.Application();
            wordApp.Visible = false;
            try
            {
                
                var WordDocument = wordApp.Documents.Open(TemplateFileName);
                ReplaceWordstub("{Kompaniya}", Kompaniya, WordDocument);
                ReplaceWordstub("{ADRES}", ADRES, WordDocument);
                ReplaceWordstub("{data}", data, WordDocument);
                ReplaceWordstub("{nomer}", nomer, WordDocument);
                ReplaceWordstub("{Kompaniya1}", Kompaniya, WordDocument);
                Word.Document DocWord = wordApp.Application.ActiveDocument;
                if (!Directory.Exists(Environment.CurrentDirectory + "\\PISMA\\" + "" + Kompaniya))
                    Directory.CreateDirectory(Environment.CurrentDirectory + "\\PISMA\\" + "" + Kompaniya);
                DocWord.SaveAs2(Environment.CurrentDirectory + "\\PISMA\\"+ Kompaniya + "\\Test " + nomer + ".docx");
                //string path = @"C:\DOCUMENTO";
                //string subpath = @"pismo";
                //DirectoryInfo dirInfo = new DirectoryInfo(path);
                //if (!dirInfo.Exists)
                //{
                //    dirInfo.Create();
                //}
                //dirInfo.CreateSubdirectory(subpath);

                //___________________________________________________________________________________

               
                DocWord.ExportAsFixedFormat(Environment.CurrentDirectory + "\\PISMA\\" + "" + Kompaniya + "\\Test " + nomer + ".pdf", Word.WdExportFormat.wdExportFormatPDF);
                File.OpenRead(Environment.CurrentDirectory + "\\PISMA\\" + Kompaniya + "\\Test " + nomer + ".pdf");
              File.Delete(Environment.CurrentDirectory + "\\PISMA\\" + Kompaniya + "\\Test " + nomer + ".docx");

                MessageBox.Show("Документ готов. Он лежит сдесь:  " + Environment.CurrentDirectory + "\\PISMA\\" + Kompaniya + "\\Test " + nomer + ".pdf");
            }
            catch
            {
              //  MessageBox.Show("error");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            CipherDemo a = new CipherDemo();
            a.Show();
        }
    }
}
