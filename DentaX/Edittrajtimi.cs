using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentaX.Helper;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DentaX
{
    public partial class Edittrajtimi : Form
    {
        private string conn;
        private MySqlConnection connect;
        public Edittrajtimi()
        {
            InitializeComponent(); FillData();
        }
        public void FillData()
        {
      
            patients.AddItem(Utility.personi.ToString());
            sherbimi.AddItem(Utility.sherbimi.ToString());
            price.Text = Utility.qmimi.ToString();
            shenime.Text = Utility.shenime;
            dhembi.Text = Utility.dhembi;
            data.Text = DateTime.Today.ToString("dd-MM-yyyy");
            patients.selectedIndex = 0;
            sherbimi.selectedIndex=0;

            
        }
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
        private void button1_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "6";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "7";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "8";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "9";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "10";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "11";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "12";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "13";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "14";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "15";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "16";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "17";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "18";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "19";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "20";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "21";
            
        }

        private void button23_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "22";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "23";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "24";
        }

        private void button28_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "25";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "26";
        }

        private void button26_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "27";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "28";
        }

        private void button32_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "29";
        }

        private void button31_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "30";
        }

        private void button30_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "31";
        }

        private void button29_Click(object sender, EventArgs e)
        {
            dhembi.ResetText();
            dhembi.Text = "32";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
           int trajtimiid = Utility.trajtimiid;
           if ( price.Text.Equals("") || dhembi.Text.Equals(""))
            {
                if (price.Text.Equals(""))
                {
                    MessageBox.Show("Shkruaj çmimin !");
                }
                if (dhembi.Text.Equals(""))
                {
                    MessageBox.Show("Zgjedh dhembin !");
                }

            }
            else
            {
                db_connection();
                string uquery = "UPDATE  trajtimi  SET Personi='" + this.patients.selectedValue.ToString() + "',Sherbimi='" + this.sherbimi.selectedValue.ToString() + "',Dhembi='" + this.dhembi.Text + "',Qmimi='" + this.price.Text + "' WHERE Id='" + trajtimiid + "'";
                MySqlCommand command = new MySqlCommand(uquery, connect);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Të dhënat janë edituar!");

                }

                else
                {
                    MessageBox.Show("Gabim në editim !");
                }
                connect.Close();
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Hide();
            var open = new Menu();
            open.Show();
        }
    }
}
