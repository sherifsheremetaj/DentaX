using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using DentaX.Helper;

namespace DentaX
{
    public partial class Menu : Form
    {
        int togmove; int mvalx;
        int mvaly;
        public string conn;
        public MySqlConnection connect;
        DataTable data;
        string shumasot;
        string shumadje;
        string shumajava;
        string shumamuaji;
        string trajtimisot;
        string trajtimidje;
        string trajtimijava;
        string trajtimimuaji;
        public Menu()
        {
            InitializeComponent(); increaseheight(); GetPatientsData(); GetTrajtimet(); loadfinance(); fillfinanca(); loadtrajtimi(); filltrajtimi(); GetSherbimetData();
        }
        public void db_connection()
        {

            try
            {
                conn = "Server=localhost;Database=dentax;Uid=root;Pwd=;Convert Zero Datetime=True;";
                connect = new MySqlConnection(conn);


                connect.Open();
            }
            catch (MySqlException e)
            {
                throw;
            }
        }
        public void increaseheight()
        {
            
        }
        public void GetPatientsData()
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("SELECT *FROM patients", connect);
            MySqlDataAdapter fd = new MySqlDataAdapter();
            fd.SelectCommand = cmd;
            data = new DataTable();
            data.Columns.Add("ID", typeof(int));
            data.Columns.Add("Emri", typeof(string));
            data.Columns.Add("Mbiemri", typeof(string));
            data.Columns.Add("Vendlindja", typeof(string));
            data.Columns.Add("Telefoni", typeof(string));
            data.Columns.Add("Regjistruar", typeof(DateTime));
            
            

            fd.Fill(data);
            BindingSource fsource = new BindingSource();
            fsource.DataSource = data;
            patienttable.DataSource = fsource;
            fd.Update(data);
            

        }
        public void GetTrajtimet()
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("SELECT *FROM trajtimi", connect);
            MySqlDataAdapter fd = new MySqlDataAdapter();
            fd.SelectCommand = cmd;
            data = new DataTable();
            data.Columns.Add("ID", typeof(int));
            data.Columns.Add("Personi", typeof(string));
            data.Columns.Add("Sherbimi", typeof(string));
            data.Columns.Add("Dhembi", typeof(string));
            data.Columns.Add("Shenime", typeof(string));
            data.Columns.Add("Qmimi", typeof(string));
            data.Columns.Add("Data", typeof(DateTime));



            fd.Fill(data);
            BindingSource fsource = new BindingSource();
            fsource.DataSource = data;
            trajtimitable.DataSource = fsource;
            fd.Update(data);


        }
        public void GetSherbimetData()
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand("SELECT *FROM sherbimet", connect);
            MySqlDataAdapter fd = new MySqlDataAdapter();
            fd.SelectCommand = cmd;
            data = new DataTable();
            data.Columns.Add("ID", typeof(int));
            data.Columns.Add("Sherbimi", typeof(string));
            data.Columns.Add("Aktive", typeof(int));
            



            fd.Fill(data);
            BindingSource fsource = new BindingSource();
            fsource.DataSource = data;
            sherbimitable.DataSource = fsource;
            fd.Update(data);


        }
        private void patientpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void username_OnValueChanged(object sender, EventArgs e)
        {
           

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
           
            var addpatient = new AddPatient();
            addpatient.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rifreskoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetPatientsData();
            patienttable.Refresh();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void fshijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (patienttable.SelectedRows.Count > 0)
            {
                string getid = patienttable.SelectedRows[0].Cells[0].Value.ToString();
                int patientid = Convert.ToInt32(getid);
                db_connection();

                string aquery = "DELETE From patients  WHERE Id='" + patientid + "'";
                MySqlCommand command = new MySqlCommand(aquery, connect);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Pacienti është fshirë !!");

                    GetPatientsData();
                    patienttable.Refresh();

                }
                else
                {
                    MessageBox.Show("Gabim në fshirje !");
                }
                connect.Close();
            }
            else
            {
                MessageBox.Show("Selektoje një rresht !");
            }
           
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            
            Hide();
            var trajtim = new Trajtimi();
            trajtim.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            sherbimetpanel.Visible = false;
            statistikapanel.Visible = false;
            trajtimipanel.Visible = false;
            patientpanel.Visible = true;
           
            pictureBox1.Top = ((Control)sender).Top;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = ((Control)sender).Top;
            sherbimetpanel.Visible = false;
            patientpanel.Visible = false;
            statistikapanel.Visible = false;
            trajtimipanel.Visible = true;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = ((Control)sender).Top;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = ((Control)sender).Top;
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = ((Control)sender).Top;
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = ((Control)sender).Top;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void editoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string getid = patienttable.SelectedRows[0].Cells[0].Value.ToString();
            string name= patienttable.SelectedRows[0].Cells[1].Value.ToString();
            string surname= patienttable.SelectedRows[0].Cells[2].Value.ToString();
            string birthplace= patienttable.SelectedRows[0].Cells[3].Value.ToString();
            string telnr= patienttable.SelectedRows[0].Cells[4].Value.ToString();
            int patientid = Convert.ToInt32(getid);

            Utility.patientid = patientid;
            Utility.patientname = name;
            Utility.patientsurname = surname;
            Utility.patienttel = telnr;
            Utility.patientbirthplace = birthplace;
            var editpatientobj = new editpatient();
            editpatientobj.Show();
        }

        private void trajtimipanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fshijeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (trajtimitable.SelectedRows.Count > 0)
            {
                string getid = trajtimitable.SelectedRows[0].Cells[0].Value.ToString();
                int patientid = Convert.ToInt32(getid);
                db_connection();

                string aquery = "DELETE From trajtimi  WHERE Id='" + patientid + "'";
                MySqlCommand command = new MySqlCommand(aquery, connect);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Trajtimi është fshirë !!");

                    GetTrajtimet();
                    trajtimitable.Refresh();

                }
                else
                {
                    MessageBox.Show("Gabim në fshirje !");
                }
                connect.Close();
            }
            else
            {
                MessageBox.Show("Selektoje një rresht !");
            }
        }

        private void rifreskoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetTrajtimet();
            trajtimitable.Refresh();
        }

        private void editoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string getid = trajtimitable.SelectedRows[0].Cells[0].Value.ToString();
            string personi = trajtimitable.SelectedRows[0].Cells[1].Value.ToString();
            string sherbimi = trajtimitable.SelectedRows[0].Cells[2].Value.ToString();
            string dhembi = trajtimitable.SelectedRows[0].Cells[3].Value.ToString();
            string shenime = trajtimitable.SelectedRows[0].Cells[4].Value.ToString();
            string qmimi = trajtimitable.SelectedRows[0].Cells[5].Value.ToString();
            int trajtimiid = Convert.ToInt32(getid);
            decimal price = Convert.ToDecimal(qmimi);

            Utility.trajtimiid = trajtimiid;
            Utility.personi = personi;
            Utility.sherbimi = sherbimi;
            Utility.dhembi = dhembi;
            Utility.shenime = shenime;
            Utility.qmimi = price;
            var editpatientobj = new Edittrajtimi();
            editpatientobj.Show();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            Hide();
            var trajtimi = new Trajtimi();
            trajtimi.Show();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            var pacienti = new AddPatient();
            pacienti.Show();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            GetTrajtimet();
            DataView dv = new DataView(data);
            dv.RowFilter = string.Format("Personi LIKE '%{0}%'", trajtimifilter.Text);
            trajtimitable.DataSource = dv; 
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            GetPatientsData();
            DataView dv = new DataView(data);
            dv.RowFilter = string.Format("Emri LIKE '%{0}%'", pacientfilter.Text);
            patienttable.DataSource = dv; 
        }

        private void eksportExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (patienttable.RowCount > 0)
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "Pacientët";
                // storing header part in Excel  
                for (int i = 1; i < patienttable.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = patienttable.Columns[i - 1].HeaderText;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < patienttable.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < patienttable.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = patienttable.Rows[i].Cells[j].Value.ToString();
                    }
                }
                //// save the application  
                //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                //// Exit from the application  
                //app.Quit();  
            }

            else
            {
                MessageBox.Show("Nuk ka të dhëna për të eksportuar në Excel !");
            }
        }

        private void eksportExcelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (trajtimitable.RowCount > 0)
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "Trajtimet";
                // storing header part in Excel  
                for (int i = 1; i < trajtimitable.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = trajtimitable.Columns[i - 1].HeaderText;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < trajtimitable.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < trajtimitable.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = trajtimitable.Rows[i].Cells[j].Value.ToString();
                    }
                }
                //// save the application  
                //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                //// Exit from the application  
                //app.Quit();  
            }

            else
            {
                MessageBox.Show("Nuk ka të dhëna për të eksportuar në Excel !");
            }
        }

        private void bunifuFlatButton5_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Top = ((Control)sender).Top;
            trajtimipanel.Visible = false;
            statistikapanel.Visible = false;
            patientpanel.Visible = false;
            sherbimetpanel.Visible = true;
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = ((Control)sender).Top;
            var open = new info();
            open.Show();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Hide();
            var open = new Form1();
            open.Show();
        }

        private void bunifuFlatButton4_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Top = ((Control)sender).Top;
            patientpanel.Visible = false;
            trajtimipanel.Visible = false;
            statistikapanel.Visible = true;
            sherbimetpanel.Visible = false;
        }
        void loadfinance()
        {
            string sotquery = "SELECT SUM(Qmimi) FROM trajtimi Where Data=CURRENT_DATE ";
            string djequery = "SELECT SUM(Qmimi) from trajtimi where Data = DATE_SUB(CURRENT_DATE(),INTERVAL 1 DAY) ";
            string javaquery = "SELECT SUM(Qmimi) FROM trajtimi WHERE YEARWEEK(`Data`, 1) = YEARWEEK(CURDATE(), 1) ";
            string muajiquery = " SELECT SUM(Qmimi) FROM trajtimi WHEre MONTH(Data)=MONTH(CURRENT_DATE)";
           
           
           //sot records
            try
            {
                db_connection();
                MySqlCommand cmd = new MySqlCommand(sotquery, connect);
                MySqlDataReader nrd;
                nrd = cmd.ExecuteReader();
                while (nrd.Read())
                {


                    shumasot = nrd["SUM(Qmimi)"].ToString();


                }

                nrd.Close();

            }
            catch (Exception ex)
            {



            }

            //dje records
            try
            {
                db_connection();
                MySqlCommand cmd = new MySqlCommand(djequery, connect);
                MySqlDataReader nrd;
                nrd = cmd.ExecuteReader();
                while (nrd.Read())
                {


                    shumadje = nrd["SUM(Qmimi)"].ToString();


                }

                nrd.Close();

            }
            catch (Exception ex)
            {



            }
            //java records
            try
            {
                db_connection();
                MySqlCommand cmd = new MySqlCommand(javaquery, connect);
                MySqlDataReader nrd;
                nrd = cmd.ExecuteReader();
                while (nrd.Read())
                {


                    shumajava = nrd["SUM(Qmimi)"].ToString();


                }

                nrd.Close();

            }
            catch (Exception ex)
            {



            }
            //muaji records
            try
            {
                db_connection();
                MySqlCommand cmd = new MySqlCommand(muajiquery, connect);
                MySqlDataReader nrd;
                nrd = cmd.ExecuteReader();
                while (nrd.Read())
                {


                    shumamuaji = nrd["SUM(Qmimi)"].ToString();


                }

                nrd.Close();

            }
            catch (Exception ex)
            {



            }
            connect.Close();

            chart1.Series["Sot"].Points.AddXY("", shumasot);
            chart1.Series["Dje"].Points.AddXY("", shumadje);
            chart1.Series["Java"].Points.AddXY("", shumajava);
            chart1.Series["Muaji"].Points.AddXY("", shumamuaji);

         
        }
        void fillfinanca()
        {
            
            //Sot
            
            chart1.Series["Sot"].Points[0].Color = Color.SeaGreen;
           // chart1.Series["Sot"].Points[0].AxisLabel = "SOT";
            //chart1.Series["Sot"].Points[0].LegendText = "SOT";
            chart1.Series["Sot"].Points[0].Label = shumasot+" €";

            //Dje
            
            chart1.Series["Dje"].Points[0].Color = Color.FromArgb(102, 205, 170);
           // chart1.Series["Dje"].Points[0].AxisLabel = "Dje";
            //chart1.Series["Dje"].Points[1].LegendText = "Dje";
            chart1.Series["Dje"].Points[0].Label = shumadje + " €"; 

           
            ////Java
           
          
            chart1.Series["Java"].Points[0].Color = Color.FromArgb(70, 130, 180);
           // chart1.Series["Java"].Points[0].AxisLabel = "Java";
            //chart1.Series["Java"].Points[2].LegendText = "Java";
            chart1.Series["Java"].Points[0].Label = shumajava + " €"; 

            ////Muaji
           
         
            chart1.Series["Muaji"].Points[0].Color = Color.FromArgb(0, 139, 139);
          //  chart1.Series["Muaji"].Points[0].AxisLabel = "Muaji";
            //chart1.Series["Muaji"].Points[3].LegendText = "Muaji";
            chart1.Series["Muaji"].Points[0].Label = shumamuaji + " €";

        }
        void loadtrajtimi()
        {
            string sotquery = "SELECT Count(*) FROM trajtimi Where Data=CURRENT_DATE ";
            string djequery = "SELECT Count(*) from trajtimi where Data = DATE_SUB(CURRENT_DATE(),INTERVAL 1 DAY) ";
            string javaquery = "SELECT Count(*) FROM trajtimi WHERE YEARWEEK(`Data`, 1) = YEARWEEK(CURDATE(), 1) ";
            string muajiquery = " SELECT Count(*) FROM trajtimi WHEre MONTH(Data)=MONTH(CURRENT_DATE)";


            //sot records
            try
            {
                db_connection();
                MySqlCommand cmd = new MySqlCommand(sotquery, connect);
                MySqlDataReader nrd;
                nrd = cmd.ExecuteReader();
                while (nrd.Read())
                {


                    trajtimisot = nrd["Count(*)"].ToString();


                }

                nrd.Close();

            }
            catch (Exception ex)
            {



            }

            //dje records
            try
            {
                db_connection();
                MySqlCommand cmd = new MySqlCommand(djequery, connect);
                MySqlDataReader nrd;
                nrd = cmd.ExecuteReader();
                while (nrd.Read())
                {


                    trajtimidje = nrd["Count(*)"].ToString();


                }

                nrd.Close();

            }
            catch (Exception ex)
            {



            }
            //java records
            try
            {
                db_connection();
                MySqlCommand cmd = new MySqlCommand(javaquery, connect);
                MySqlDataReader nrd;
                nrd = cmd.ExecuteReader();
                while (nrd.Read())
                {


                    trajtimijava = nrd["Count(*)"].ToString();


                }

                nrd.Close();

            }
            catch (Exception ex)
            {



            }
            //muaji records
            try
            {
                db_connection();
                MySqlCommand cmd = new MySqlCommand(muajiquery, connect);
                MySqlDataReader nrd;
                nrd = cmd.ExecuteReader();
                while (nrd.Read())
                {


                    trajtimimuaji = nrd["Count(*)"].ToString();


                }

                nrd.Close();

            }
            catch (Exception ex)
            {



            }
            connect.Close();

            chart2.Series["Sot"].Points.AddXY("", trajtimisot);
            chart2.Series["Dje"].Points.AddXY("", trajtimidje);
            chart2.Series["Java"].Points.AddXY("", trajtimijava);
            chart2.Series["Muaji"].Points.AddXY("", trajtimimuaji);

            
        }
        void filltrajtimi()
        {
            chart2.Series["Sot"].Points[0].Color = Color.SeaGreen;
            // chart1.Series["Sot"].Points[0].AxisLabel = "SOT";
            //chart1.Series["Sot"].Points[0].LegendText = "SOT";
            chart2.Series["Sot"].Points[0].Label = trajtimisot ;

            //Dje

            chart2.Series["Dje"].Points[0].Color = Color.FromArgb(102, 205, 170);
            // chart1.Series["Dje"].Points[0].AxisLabel = "Dje";
            //chart1.Series["Dje"].Points[1].LegendText = "Dje";
            chart2.Series["Dje"].Points[0].Label = trajtimidje ;


            ////Java


            chart2.Series["Java"].Points[0].Color = Color.FromArgb(70, 130, 180);
            // chart1.Series["Java"].Points[0].AxisLabel = "Java";
            //chart1.Series["Java"].Points[2].LegendText = "Java";
            chart2.Series["Java"].Points[0].Label = trajtimijava ;

            ////Muaji


            chart2.Series["Muaji"].Points[0].Color = Color.FromArgb(0, 139, 139);
            //  chart1.Series["Muaji"].Points[0].AxisLabel = "Muaji";
            //chart1.Series["Muaji"].Points[3].LegendText = "Muaji";
            chart2.Series["Muaji"].Points[0].Label = trajtimimuaji ;
        }
        private void statistikapanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sherbimetpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged_1(object sender, EventArgs e)
        {
            GetSherbimetData();
            DataView dv = new DataView(data);
            dv.RowFilter = string.Format("Sherbimi LIKE '%{0}%'", sherbimifilter.Text);
            sherbimitable.DataSource = dv; 
        }

        private void eksportExcelToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (sherbimitable.RowCount > 0)
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "Trajtimet";
                // storing header part in Excel  
                for (int i = 1; i < sherbimitable.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = sherbimitable.Columns[i - 1].HeaderText;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < sherbimitable.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < sherbimitable.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = sherbimitable.Rows[i].Cells[j].Value.ToString();
                    }
                }
                //// save the application  
                //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                //// Exit from the application  
                //app.Quit();  
            }

            else
            {
                MessageBox.Show("Nuk ka të dhëna për të eksportuar në Excel !");
            }
        }

        private void editoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string sherbimid = sherbimitable.SelectedRows[0].Cells[0].Value.ToString();
            string sherbimii = sherbimitable.SelectedRows[0].Cells[1].Value.ToString();
            string sherbimiaktiv = sherbimitable.SelectedRows[0].Cells[2].Value.ToString();
            
            int sherbimiid = Convert.ToInt32(sherbimid);
            int statusi = Convert.ToInt32(sherbimiaktiv);

            Utility.sherbimiid = sherbimiid;
            Utility.sherbimimjeksor = sherbimii;
            Utility.aktiv = statusi;
           
            var editsherbimi = new Form2();
            editsherbimi.Show();
        }

        private void fshijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sherbimitable.SelectedRows.Count > 0)
            {
                string getid = sherbimitable.SelectedRows[0].Cells[0].Value.ToString();
                int patientid = Convert.ToInt32(getid);
                db_connection();

                string aquery = "DELETE From sherbimet  WHERE Id='" + patientid + "'";
                MySqlCommand command = new MySqlCommand(aquery, connect);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sherbimi është fshirë !!");

                    GetTrajtimet();
                    trajtimitable.Refresh();

                }
                else
                {
                    MessageBox.Show("Gabim në fshirje !");
                }
                connect.Close();
            }
            else
            {
                MessageBox.Show("Selektoje një rresht !");
            }
        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
            Hide();
            var open = new addsherbim();
            open.Show();
        }

        private void rifreskoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            GetTrajtimet();
            trajtimitable.Refresh();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            togmove = 1; mvalx = e.X;
            mvaly = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (togmove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mvalx, MousePosition.Y - mvaly);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            togmove = 0;
        }
    }
}
