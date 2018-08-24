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
    public partial class editpatient : Form
    {
        int patientid;
        public string conn;
        public MySqlConnection connect;
        public editpatient()
        {
            InitializeComponent(); FillData();
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
            patientid = Utility.patientid;
            if (name.Text.Equals("") || surname.Text.Equals("") || birthplace.Text.Equals(""))
            {
                MessageBox.Show("Plotësoni fushat !");

            }
            else
            {
                db_connection();
                string uquery = "UPDATE  patients  SET Emri='" + this.name.Text + "',Mbiemri='" + this.surname.Text + "',Vendlindja='" + this.birthplace.Text + "',Telefoni='" + this.telnr.Text + "' WHERE Id='"+patientid+"'";
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
        public void FillData()
        {
            name.Text = Utility.patientname;
            surname.Text = Utility.patientsurname;
            birthplace.Text = Utility.patientbirthplace;
            telnr.Text = Utility.patienttel;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
