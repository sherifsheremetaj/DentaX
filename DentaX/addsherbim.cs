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
using MySql.Data.MySqlClient;

namespace DentaX
{
    public partial class addsherbim : Form
    {
        public string conn;
        public MySqlConnection connect;
        public addsherbim()
        {
            InitializeComponent();
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
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (sherbimi.Text.Equals(""))
            {

                MessageBox.Show("Shkruaj sherbimin !");

            }
            if (aktiv.Text.Equals(""))
            {
                MessageBox.Show("Shkruaj Statusin Aktiv apo jo  !");
            }



            else
            {
                string aquery = "INSERT INTO sherbimet (Sherbimi,Aktive) values('" + this.sherbimi.Text + "','" + this.aktiv.Text + "') ";
                db_connection();
                MySqlCommand command = new MySqlCommand(aquery, connect);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sherbimi është regjistruar !");

                    sherbimi.ResetText();
                    aktiv.ResetText();


                }
                else
                {
                    MessageBox.Show("Gabim në regjistrim !");
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
    }
}
