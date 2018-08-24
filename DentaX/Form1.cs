using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace DentaX
{
    public partial class Form1 : Form
    {
        
      public  string conn;
       public  MySqlConnection connect;
        public Form1()
        {
            InitializeComponent();
          
        }

       //Funksioni lidh aplikacionin me databazë
        public void db_connection()
        {
             
            try
            {
                conn = "Server=localhost;Database=dentax;Uid=root;Pwd=;";
                connect = new MySqlConnection(conn);


                connect.Open();
            }
            catch (MySqlException e)
            {
                throw;
            }
        }
        //Validon të dhënat që jepen nga perdoruesi
        private bool validate_login(string user, string pass)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from doctors where username=@user and password=@pass";
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.Read())
            {
                connect.Close();
                return true;
            }
            else
            {
                connect.Close();
                return false;
            }
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            string uname = username.Text;
            string upass = password.Text;
            if (uname.Equals("") || upass.Equals(""))
            {
                MessageBox.Show("Plotësoni fushat !!");
            }
            else
            {
                bool dbconnection = validate_login(uname, upass);
                if (dbconnection)
                {
                    Hide();
                    var openmenu = new Menu();
                    openmenu.Show();
                }
                else
                {
                    MessageBox.Show("Të dhënat gabim !");
                }

            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
