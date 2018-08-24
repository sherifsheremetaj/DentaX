using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using DentaX.Helper;
using MySql.Data.MySqlClient;

namespace DentaX
{
    public partial class Trajtimi : Form
    {
        private string conn;
        private MySqlConnection connect;
        public Trajtimi()
        {
            InitializeComponent(); loadsherbimet(); loadpatients(); patients.selectedIndex = 0; sherbimi.selectedIndex = 0;
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
        private void loadsherbimet()
        {
            sherbimi.AddItem("Mjekimi");
            string nquery = "SELECT Sherbimi FROM sherbimet Where Aktive=1 ORDER BY Sherbimi";
            try
            {
                db_connection();
                MySqlCommand cmd = new MySqlCommand(nquery, connect);
                MySqlDataReader nrd;
                nrd = cmd.ExecuteReader();
                while (nrd.Read())
                {
                    
                    sherbimi.AddItem(nrd["Sherbimi"].ToString());
                }
                connect.Close();
            }
            catch (Exception ex)
            {

            }
        }
        private void loadpatients()
        {
            patients.AddItem("Pacienti");

           
            string nquery = "SELECT Id,Emri,Mbiemri FROM patients ORDER BY Emri";
            try
            {
                db_connection();
                MySqlCommand cmd = new MySqlCommand(nquery, connect);
                MySqlDataReader nrd;
                nrd = cmd.ExecuteReader();
                while (nrd.Read())
                {


                    patients.AddItem(nrd["Id"].ToString() + " " + nrd["Emri"].ToString()+ " "+nrd["Mbiemri"].ToString());
                  
                   
                }

                nrd.Close();
                
            }
            catch (Exception ex)
            {



            }

            connect.Close();
        }
        private void Trajtimi_Load(object sender, EventArgs e)
        {
            data.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Hide();
            var menuobj = new Menu();
            menuobj.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void name_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (shenime.Text.Equals("Shenime"))
            {
                shenime.Text = "";
            }
            else
            {

            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (patients.selectedIndex.Equals(0) ||  sherbimi.selectedIndex.Equals(0))
            {
                if (patients.selectedIndex.Equals(0))
                {
                    MessageBox.Show("Selekto një pacient !");
                }
                if (sherbimi.selectedIndex.Equals(0))
                {
                    MessageBox.Show("Selekto një lloj sherbimi !");
                }
               
            }
            else
            {
                if(dhembi.Text.Equals("") || price.Text.Equals("")){

                    if (dhembi.Text.Equals(""))
                    {
                        MessageBox.Show("Selekto dhëmbin !");
                    }
                    if (price.Text.Equals(""))
                    {
                        MessageBox.Show("Shkruaj çmimin !");
                    }
                   

                }
                else
                {
                    
                    decimal qmimi = Convert.ToDecimal(price.Text);
                    connect.Open();
                    string aquery = "INSERT INTO trajtimi (Personi,Sherbimi,Dhembi,Shenime,Qmimi,Data) values('" + this.patients.selectedValue.ToString() + "','" + this.sherbimi.selectedValue.ToString() + "','" + this.dhembi.Text + "','" + this.shenime.Text + "','" + qmimi + "',NOW()) ";

                    MySqlCommand command = new MySqlCommand(aquery, connect);
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Trajtimi është regjistruar !");
                        price.ResetText();
                        shenime.ResetText();
                        dhembi.ResetText();
                        patients.selectedIndex = 0;
                        sherbimi.selectedIndex = 0;

                        


                    }
                    else
                    {
                        MessageBox.Show("Gabim në regjistrim !");
                    }

                    connect.Close();
                   
                }
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
    }
}
