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
using DentaX.Helper;

namespace DentaX
{
    public partial class AddPatient : Form
    {
        public string conn;
        public MySqlConnection connect;
        int togmove;
        int mvalx; 
        int mvaly;
        public AddPatient()
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
           
                db_connection();
                if (name.Text.Equals("") || surname.Text.Equals("") || birthplace.Text.Equals(""))
                {
                    MessageBox.Show("Plotësoni fushat !");

                }

                else if (telnr.Text.Equals(""))
                {
                    string aquery = "INSERT INTO patients (Emri,Mbiemri,Vendlindja,Telefoni,Regjistruar) values('" + this.name.Text + "','" + this.surname.Text + "','" + this.birthplace.Text + "','049000000',NOW() ) ";

                    MySqlCommand command = new MySqlCommand(aquery, connect);
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Pacienti është regjistruar !");
                        name.ResetText();
                        surname.ResetText();
                        birthplace.ResetText();
                        telnr.Text = "049000000";
                        var menuobj = new Menu();
                        menuobj.GetPatientsData();
                        menuobj.GetPatientsData();


                    }
                    else
                    {
                        MessageBox.Show("Gabim në regjistrim !");
                    }

                    connect.Close();
                }
                else
                {
                    string aquery = "INSERT INTO patients (Emri,Mbiemri,Vendlindja,Telefoni,Regjistruar) values('" + this.name.Text + "','" + this.surname.Text + "','" + this.birthplace.Text + "','" + this.telnr.Text + "',NOW() ) ";

                    MySqlCommand command = new MySqlCommand(aquery, connect);
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Pacienti është regjistruar !");
                        name.ResetText();
                        surname.ResetText();
                        birthplace.ResetText();
                        telnr.Text = "049000000";
                        var menuobj = new Menu();
                        menuobj.GetPatientsData();
                        menuobj.GetPatientsData();


                    }
                    else
                    {
                        MessageBox.Show("Gabim në regjistrim !");
                    }

                    connect.Close();
                }
           
           
           

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddPatient_Load(object sender, EventArgs e)
        {
            date.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            togmove = 1; mvalx = e.X;
            mvaly = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            togmove = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (togmove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mvalx, MousePosition.Y - mvaly);
            }
        }
    }
}
