using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Security.Cryptography;
using Cipher;

namespace PDP
{
    public partial class RealRegistr : Form
    {
        public RealRegistr()
        {
            InitializeComponent();
            
        
        }

       


        private void label5_Click(object sender, EventArgs e)
        {

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-34MR68E\DEPISHMOD; user id=sa; password=12; Initial Catalog = PDP;Persist Security Info=True;");
            con.Open();
            string sql = "INSERT INTO Sign1 (Login , password, Im , Fam, Otch , Doljn, User_prav, Mail ) Values ('" + log.Text + "','" + pas.Text + "','" + im.Text + "','" + fam.Text + "','" + otch.Text + "','" + doljn.Text + "','" + prav.Text + "','" + mail.Text + "')";


            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            if (log.Text == "" || doljn.Text == "" || otch.Text == "" || fam.Text == "" || im.Text == "" || pas.Text == "")
            {
                MessageBox.Show("Все поля обязательны к заполнению!");
            }
            else
                MessageBox.Show("Регистрация прошла успешно");
        }







        private string byteArrayToHexString(byte[] encrypted)
        {
            throw new NotImplementedException();
        }

      
    }
}
