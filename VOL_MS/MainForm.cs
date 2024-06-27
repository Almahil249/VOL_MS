using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VOL_MS;
using System.Data.SqlClient;
using static System.DateTime;


namespace VOL_MS
{
    public partial class MainForm : Form
    {
        static SqlConnection conn;
        static SqlConnection connShifts;

        static SqlCommand cmd;
        static SqlCommand cmd1;
        static SqlDataReader dr;

        public MainForm()
        {
            InitializeComponent();
            LoadChildFormIntoPanel(new HomeForm());
            conn = new SqlConnection(ConnectionDB.GetConnectionString());   
            connShifts = new SqlConnection(ConnectionDB.GetShitsConnectionString());
        }

        public void LoadChildFormIntoPanel(Form childForm)
        {
            // check if the panelContent has any form
            if (panelContent.Controls.Count > 0)
            {
                // get the name of the form and check if it is ManageEventForm call    ManageEventForm_FormClosing() it is a public method
                string formName = panelContent.Controls[0].Name;
                if (formName == "ManageEventForm")
                {
                    ManageEventForm form1 = panelContent.Controls[0] as ManageEventForm;
                    form1.ManageEventForm_FormClosing();
                }

                // if it has close the form
                Form form = panelContent.Controls[0] as Form;
                form.Close();
            }

            panelContent.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(childForm);
            childForm.Show();
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {
            LoadChildFormIntoPanel(new HomeForm());
            PopulateComboBox();
        }

        private void panelTitle_Paint(object sender, PaintEventArgs e)
        {
            //LoadChildFormIntoPanel(new HomeForm());
            PopulateComboBox();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void buttonShowData_Click(object sender, EventArgs e)
        {
            LoadChildFormIntoPanel(new ShowDataForm());
        }

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            LoadChildFormIntoPanel(new AddEventForm());
        }

        private void buttonManageEvents_Click(object sender, EventArgs e)
        {
            string eventName = EventsComboBox.Text;
            if (eventName != "" && EventsComboBox.Items.Contains(eventName))
            {
                //check if the eventName is a table in the database
                conn.Open();
                cmd = new SqlCommand("SELECT COUNT(*) FROM information_schema.tables WHERE TABLE_NAME = '" + eventName + "'", conn);
                dr = cmd.ExecuteReader();
                int tableCount = 0;
                while (dr.Read())
                {
                    tableCount = Convert.ToInt32(dr[0]);
                }
                dr.Close();
                conn.Close();

                if (tableCount == 0)
                {
                    MessageBox.Show("The event does not exist in the database");
                    return;
                }
                LoadChildFormIntoPanel(new ManageEventForm(eventName));
            }
            else
            {
                MessageBox.Show("Please select an event from the list");
            }
        }

        private void PopulateComboBox()
        {
            // clear the combobox
            EventsComboBox.Items.Clear();
            int tableCount = 0;

            conn.Open();
            cmd = new SqlCommand("SELECT COUNT(*) FROM information_schema.tables", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tableCount = Convert.ToInt32(dr[0]);
            }
            dr.Close();
            conn.Close();

            // get the names of the tables
            string[] tableNames = new string[tableCount];
            conn.Open();
            cmd1 = new SqlCommand("SELECT TABLE_NAME FROM information_schema.tables", conn);
            dr = cmd1.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                tableNames[i] = dr[0].ToString();
                i++;
            }

            dr.Close();
            conn.Close();

            // add events names to the EventsComboBox
            for (int j = 0; j < tableCount; j++)
            {
                EventsComboBox.Items.Add(tableNames[j]);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PopulateComboBox();
            // connect to ShiftsDB database and check if the "Shifts" table exists or not
            connShifts.Open();
            cmd = new SqlCommand("SELECT COUNT(*) FROM information_schema.tables WHERE table_name = 'Shifts'", connShifts);
            dr = cmd.ExecuteReader();
            int countTableShifts = 0;
            while (dr.Read())
            {
                countTableShifts = Convert.ToInt32(dr[0]);
            }
            dr.Close();
            connShifts.Close();

            // if the "Shifts" table does not exist in the ShiftsDB database then create the "Shifts" table with Name, v_ID, Phone, Date, Check IN, EventName columns and set the Date and EventName and V_ID columns as the primary key
            if (countTableShifts == 0)
            {
                connShifts.Open();
                cmd = new SqlCommand("CREATE TABLE [Shifts] ([Name] NVARCHAR(50) NOT NULL, [V_ID] VARCHAR(50) NOT NULL, [Phone] VARCHAR(50)  NULL, [Date] VARCHAR(50) NOT NULL, [Check IN] VARCHAR(50) NOT NULL, [EventName] VARCHAR(50) NOT NULL, [TotalHours] VARCHAR(50) NOT NULL , PRIMARY KEY ([Date], [EventName], [V_ID]))", connShifts);
                cmd.ExecuteNonQuery();
                connShifts.Close();
            }


            connShifts.Open();
            cmd = new SqlCommand("SELECT COUNT(*) FROM Shifts WHERE Date != '" + DateTime.Now.ToString("yyyy_MM_dd") + "'", connShifts);
            dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count = Convert.ToInt32(dr[0]);
            }
            dr.Close();
            connShifts.Close();
            //create a datatable to store the records
            DataTable dt = new DataTable();
            // if there are records  checkout all

            if (count > 0)
            {
                //get the records
                connShifts.Open();
                cmd = new SqlCommand("SELECT * FROM Shifts WHERE Date != '" + DateTime.Now.ToString("yyyy_MM_dd") + "'", connShifts);
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dr.Close();
                connShifts.Close();
                //pop up a message box with the records
                string message = "";
                message = message + "There are " + count + " records in the Shifts table that belong to previous dates\n";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //the columns are: Name , V_ID , Phone , Date , CheckIn , EventName, TotalHours
                    message = message + $"{i + 1})  V_ID: " + dt.Rows[i][1].ToString() + " Date: " + dt.Rows[i][3].ToString() + " EventName: " + dt.Rows[i][5].ToString() + "\n";

                   // message = message + "Name: " + dt.Rows[i][0].ToString() + " V_ID: " + dt.Rows[i][1].ToString() + " Phone: " + dt.Rows[i][2].ToString() + " Date: " + dt.Rows[i][3].ToString() + " CheckIn: " + dt.Rows[i][4].ToString() + " EventName: " + dt.Rows[i][5].ToString() + "\n";
                }
                message = message + "\n\n And They will be Checked out with time-stamp 23:59:00 \n";
                MessageBox.Show(message);
                //check out all the records
                string checkOutLast = "23:59:00";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // V_ID: " + dt.Rows[i][1].ToString() + " Date: " + dt.Rows[i][3].ToString() + " EventName: " + dt.Rows[i][5].ToString() + " CheckIn: " + dt.Rows[i][4].ToString() 
                    DateTime checkIn = Convert.ToDateTime(dt.Rows[i][4].ToString());
                    DateTime checkOut = Convert.ToDateTime(checkOutLast);
                    TimeSpan time = checkOut - checkIn;
                    // round the time to the nearest 3 minutes
                    time = TimeSpan.FromMinutes(Math.Round(time.TotalMinutes / 3) * 3);
                    float hours = (float)time.TotalHours;
                    string query = "UPDATE [dbo].[" + dt.Rows[i][5].ToString() + "] SET [TotalHours] = [TotalHours] + " + hours + " WHERE V_ID = '" + dt.Rows[i][1].ToString() + "'";
                    string query1 = "UPDATE [dbo].[" + dt.Rows[i][5].ToString() + "] SET [" + dt.Rows[i][3].ToString() + "] = [" + dt.Rows[i][3].ToString() + "] + " + hours + " WHERE V_ID = '" + dt.Rows[i][1].ToString() + "'";
                    //MessageBox.Show(query+"\n"+ query1);
                    conn.Open();
                    cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Open();
                    cmd1 = new SqlCommand(query1, conn);
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                    //delete the record from the Shifts table
                    connShifts.Open();
                    cmd = new SqlCommand("DELETE FROM Shifts WHERE V_ID = '" + dt.Rows[i][1].ToString() + "' AND Date = '" + dt.Rows[i][3].ToString() + "' AND EventName = '" + dt.Rows[i][5].ToString() + "'", connShifts);
                    int rows2 = cmd.ExecuteNonQuery();
                    connShifts.Close();

                }
                //clear the datatable
                dt.Clear();

                
            }




           


        }
    }
}

