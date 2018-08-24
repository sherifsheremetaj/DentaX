using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DentaX.Helper;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DentaX
{
    public partial class Form2 : Form
    {
        int sherbimiid;
        public string conn;
        public MySqlConnection connect;
        public Form2()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Hide();
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
        private void Form2_Load(object sender, EventArgs e)
        {
            sherbimiid = Utility.sherbimiid;
            sherbimi.Text = Utility.sherbimimjeksor;
            aktiv.Text = Utility.aktiv.ToString();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (sherbimi.Text.Equals("")  )
            {
               
                    MessageBox.Show("Shkruaj sherbimin !");

          }
                if (aktiv.Text.Equals(""))
                {
                     MessageBox.Show("Shkruaj Statusin Aktiv apo jo  !");
                }



                else
                {
                    db_connection();
                    string uquery = "UPDATE  sherbimet  SET Sherbimi='" + this.sherbimi.Text + "',Aktive='" + this.aktiv.Text + "' WHERE Id='" + sherbimiid + "'";
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

        private void aktiv_OnValueChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(aktiv.Text, "[^0-1]"))
            {
                MessageBox.Show("Shkruaj VETEM 1 OSE 0.");
                aktiv.Text = aktiv.Text.Remove(aktiv.Text.Length - 1);
                if (aktiv.Text.Length > 1)
                {
                    MessageBox.Show("Shkruaj VETEM  1 OSE 0.");
                    aktiv.Text = aktiv.Text.Remove(aktiv.Text.Length - 1);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sherbimi_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
