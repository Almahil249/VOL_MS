using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.DateTime;
using Microsoft.Office.Interop.Excel;



namespace VOL_MS
{
    public partial class ManageEventForm : Form
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        static SqlCommand cmd1;
        static SqlDataReader dr;
        string EventName;
        System.Data.DataTable dtAllVOL = new System.Data.DataTable();
        System.Data.DataTable dtActiveVOL = new System.Data.DataTable();
        System.Data.DataTable dtAttendedVOL = new System.Data.DataTable();


        public ManageEventForm(string eventName)
        {
            InitializeComponent();
            EventName = eventName;
            EventNameLable.Text = EventName;
            //add  the data to the DateLable
            DateLable.Text = Now.ToString("dd/MM/yyyy");
            conn = new SqlConnection(ConnectionDB.GetConnectionString());

        }


        private void ManageEventForm_Load(object sender, EventArgs e)
        {
            //SqlDataAdapter da = new SqlDataAdapter("select * from [" + EventName + "]", conn); select only the Name, V_ID, Phone columns from the EventName table in the database
            SqlDataAdapter da = new SqlDataAdapter("select Name, Phone, V_ID, TotalHours from [" + EventName + "]", conn);
            da.Fill(dtAllVOL);
            AllVolDataGrid.DataSource = dtAllVOL;
            //fill the first column with the "Check IN" button
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            AllVolDataGrid.Columns.Add(btn);
            btn.HeaderText = "Action";
            btn.Text = "Check IN";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
            //set all the columns to read only
            for (int i = 0; i < AllVolDataGrid.Columns.Count; i++)
            {
                AllVolDataGrid.Columns[i].ReadOnly = true;
            }
            //construct the dtActiveVOL table with the columns Name, V_ID, Phone, TotalHours, Today's Hours, Check IN, Check Out, Action and  set all the columns to read only
            dtActiveVOL.Columns.Add("Name");
            dtActiveVOL.Columns.Add("Phone");
            dtActiveVOL.Columns.Add("V_ID");
            dtActiveVOL.Columns.Add("TotalHours");
            dtActiveVOL.Columns.Add("Shift's Hours");
            dtActiveVOL.Columns.Add("Check IN");
            dtActiveVOL.Columns.Add("Check Out");
            ActiveDataGrid.DataSource = dtActiveVOL;
            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            ActiveDataGrid.Columns.Add(btn1);
            btn1.HeaderText = "Action";
            btn1.Text = "Check Out";
            btn1.Name = "btn1";
            btn1.UseColumnTextForButtonValue = true;

            //construct the dtAttendedVOL table with the columns Name, V_ID, Phone, TotalHours, Today's Hours , check IN and Check Out
            dtAttendedVOL.Columns.Add("Name");
            dtAttendedVOL.Columns.Add("Phone");
            dtAttendedVOL.Columns.Add("V_ID");
            dtAttendedVOL.Columns.Add("TotalHours");
            dtAttendedVOL.Columns.Add("Today's Hours");
            dtAttendedVOL.Columns.Add("Check IN");
            dtAttendedVOL.Columns.Add("Check Out");
            AttendedGridView.DataSource = dtAttendedVOL;




        }

        private void SearchALL_TextChanged(object sender, EventArgs e)
        {
            DataView dvAllVOL = dtAllVOL.DefaultView;
            //filter the data in the data grid view by the Name or V_ID or Phone
            dvAllVOL.RowFilter = string.Format("Name LIKE '%{0}%' OR V_ID LIKE '%{0}%' OR Phone LIKE '%{0}%'", Search1.Text);
            //clear the Search1.Text after 15 seconds
            Timer timer = new Timer();
            timer.Interval = 15000;

            timer.Tick += (s, ee) =>
            {
                Search1.Text = "";
                timer.Stop();
            };
            timer.Start();

        
        }
        private void SearchActive_TextChanged(object sender, EventArgs e)
        {
            DataView dvActiveVOL = dtActiveVOL.DefaultView;
            //filter the data in the data grid view by the Name or V_ID or Phone
            dvActiveVOL.RowFilter = string.Format("Name LIKE '%{0}%' OR V_ID LIKE '%{0}%' OR Phone LIKE '%{0}%'", SearchActive.Text);
            //clear the SearchActive.Text after 15 seconds
            Timer timer1 = new Timer();
            timer1.Interval = 15000;

            timer1.Tick += (s, ee) =>
            {
                SearchActive.Text = "";
                timer1.Stop();
            };
            timer1.Start();

        }



        private void AllVolDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.RowIndex.ToString());

            //if the user clicked the "Check IN" buttodd the current date and time to the "Check IN" column
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {

                dtActiveVOL.Rows.Add(AllVolDataGrid.Rows[e.RowIndex].Cells[1].Value.ToString(), AllVolDataGrid.Rows[e.RowIndex].Cells[2].Value.ToString(), AllVolDataGrid.Rows[e.RowIndex].Cells[3].Value.ToString(), AllVolDataGrid.Rows[e.RowIndex].Cells[4].Value.ToString(), null, Now.ToString("HH:mm:ss"), null);
                ActiveDataGrid.DataSource = dtActiveVOL;
                for (int i = 0; i < ActiveDataGrid.Columns.Count; i++)
                {
                    ActiveDataGrid.Columns[i].ReadOnly = true;
                }
                AllVolDataGrid.Rows.RemoveAt(e.RowIndex);
                MessageBox.Show("Checked In!");
                // check the EventName table in the database if the current date column exists or not
                conn.Open();
                cmd = new SqlCommand("SELECT COUNT(*) FROM information_schema.columns WHERE table_name = '" + EventName + "' AND column_name = '" + Now.ToString("yyyy_MM_dd") + "'", conn);
                dr = cmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count = Convert.ToInt32(dr[0]);
                }
                dr.Close();
                conn.Close();
                //if the current date column does not exist in the EventName table in the database
                if (count == 0)
                {
                    //create new columns in the "EventName" table in the database with the current Date name format "YYYY_MM_DD" to store the Hours of the volunteers in this particular day
                    conn.Open();
                    cmd = new SqlCommand("ALTER TABLE [" + EventName + "] ADD [" + Now.ToString("yyyy_MM_dd") + "] float NOT NULL DEFAULT 0.0", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }



            }
        }

        private void ActiveDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Row: " + e.RowIndex.ToString() + "Col" + e.ColumnIndex);
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                //add the current date and time to the "Check Out" column in the ActiveDataGrid (indix 6)
                //and subtract the "Check IN" date and time from the "Check Out" date and time and add the result to the "Today's Hours" column  (index 4)
                ActiveDataGrid.Rows[e.RowIndex].Cells[7].Value = Now.ToString("HH:mm:ss");
                DateTime checkIn = Convert.ToDateTime(ActiveDataGrid.Rows[e.RowIndex].Cells[6].Value.ToString());
                DateTime checkOut = Convert.ToDateTime(ActiveDataGrid.Rows[e.RowIndex].Cells[7].Value.ToString());
                TimeSpan time = checkOut - checkIn;
                // round the time to the nearest 3 minutes
                time = TimeSpan.FromMinutes(Math.Round(time.TotalMinutes / 3) * 3);
                ActiveDataGrid.Rows[e.RowIndex].Cells[5].Value = time.TotalHours.ToString();
                float hours = (float)time.TotalHours;
                float PrevTotalHours = (float)Convert.ToDouble(ActiveDataGrid.Rows[e.RowIndex].Cells[4].Value.ToString());

                // update the "EventName" table in the database with the the particular volunteer's hours in the current date column
                conn.Open();
                /*
                    UPDATE [dbo].[NSTI]
                       SET 
                          [TotalHours] = [TotalHours]+h
                          ,[date] = [date]+h
                     WHERE [V_ID] = 'vid';
                    */
                string query = "UPDATE [dbo].[" + EventName + "] SET [TotalHours] = [TotalHours] + " + hours + " WHERE V_ID = '" + ActiveDataGrid.Rows[e.RowIndex].Cells[3].Value.ToString() + "'";
                string query1 = "UPDATE [dbo].[" + EventName + "] SET [" + Now.ToString("yyyy_MM_dd") + "] = [" + Now.ToString("yyyy_MM_dd") + "] + " + hours + " WHERE V_ID = '" + ActiveDataGrid.Rows[e.RowIndex].Cells[3].Value.ToString() + "'";
                //MessageBox.Show(query+"\n"+ query1);
                cmd = new SqlCommand(query, conn);
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                cmd1 = new SqlCommand(query1, conn);
                int rows1 = cmd1.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("R1:  "+rows.ToString()+ "  R2:  " + rows1.ToString());
                //remove the volunteer from the ActiveDataGrid and add him to the AttendedGridView
                // if rows > 0 then the update was successful
                if (rows > 0 && rows1 > 0)
                {
                    dtAttendedVOL.Rows.Add(ActiveDataGrid.Rows[e.RowIndex].Cells[1].Value.ToString(), ActiveDataGrid.Rows[e.RowIndex].Cells[2].Value.ToString(), ActiveDataGrid.Rows[e.RowIndex].Cells[3].Value.ToString(), PrevTotalHours + hours, ActiveDataGrid.Rows[e.RowIndex].Cells[5].Value.ToString(), ActiveDataGrid.Rows[e.RowIndex].Cells[6].Value.ToString(), ActiveDataGrid.Rows[e.RowIndex].Cells[7].Value.ToString());
                    AttendedGridView.DataSource = dtAttendedVOL;
                    dtActiveVOL.Rows.RemoveAt(e.RowIndex);
                    ActiveDataGrid.DataSource = dtActiveVOL;
                    for (int i = 0; i < ActiveDataGrid.Columns.Count; i++)
                    {
                        ActiveDataGrid.Columns[i].ReadOnly = true;
                    }
                    for (int i = 0; i < AttendedGridView.Columns.Count; i++)
                    {
                        AttendedGridView.Columns[i].ReadOnly = true;
                    }
                    MessageBox.Show("Checked Out!");
                }
                else
                {
                    MessageBox.Show("Error!");
                }


            }


        }

        private void CheckOutAll_Vol()
        {
            while (ActiveDataGrid.Rows.Count > 0)
            {
                int iRowIndex = 0;
                //add the current date and time to the "Check Out" column in the ActiveDataGrid (indix 6)
                //and subtract the "Check IN" date and time from the "Check Out" date and time and add the result to the "Today's Hours" column  (index 4)
                ActiveDataGrid.Rows[iRowIndex].Cells[7].Value = Now.ToString("HH:mm:ss");
                DateTime checkIn = Convert.ToDateTime(ActiveDataGrid.Rows[iRowIndex].Cells[6].Value.ToString());
                DateTime checkOut = Convert.ToDateTime(ActiveDataGrid.Rows[iRowIndex].Cells[7].Value.ToString());
                TimeSpan time = checkOut - checkIn;
                // round the time to the nearest 3 minutes
                time = TimeSpan.FromMinutes(Math.Round(time.TotalMinutes / 3) * 3);
                ActiveDataGrid.Rows[iRowIndex].Cells[5].Value = time.TotalHours.ToString();
                float hours = (float)time.TotalHours;
                float PrevTotalHours = (float)Convert.ToDouble(ActiveDataGrid.Rows[iRowIndex].Cells[4].Value.ToString());

                // update the "EventName" table in the database with the the particular volunteer's hours in the current date column
                conn.Open();
                string query = "UPDATE [dbo].[" + EventName + "] SET [TotalHours] = [TotalHours] + " + hours + " WHERE V_ID = '" + ActiveDataGrid.Rows[iRowIndex].Cells[3].Value.ToString() + "'";
                string query1 = "UPDATE [dbo].[" + EventName + "] SET [" + Now.ToString("yyyy_MM_dd") + "] = [" + Now.ToString("yyyy_MM_dd") + "] + " + hours + " WHERE V_ID = '" + ActiveDataGrid.Rows[iRowIndex].Cells[3].Value.ToString() + "'";
                cmd = new SqlCommand(query, conn);
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                cmd1 = new SqlCommand(query1, conn);
                int rows1 = cmd1.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("R1:  "+rows.ToString()+ "  R2:  " + rows1.ToString());
                //remove the volunteer from the ActiveDataGrid and add him to the AttendedGridView
                // if rows > 0 then the update was successful
                if (rows > 0 && rows1 > 0)
                {
                    dtAttendedVOL.Rows.Add(ActiveDataGrid.Rows[iRowIndex].Cells[1].Value.ToString(), ActiveDataGrid.Rows[iRowIndex].Cells[2].Value.ToString(), ActiveDataGrid.Rows[iRowIndex].Cells[3].Value.ToString(), PrevTotalHours + hours, ActiveDataGrid.Rows[iRowIndex].Cells[5].Value.ToString(), ActiveDataGrid.Rows[iRowIndex].Cells[6].Value.ToString(), ActiveDataGrid.Rows[iRowIndex].Cells[7].Value.ToString());
                    AttendedGridView.DataSource = dtAttendedVOL;
                    dtActiveVOL.Rows.RemoveAt(iRowIndex);
                    ActiveDataGrid.DataSource = dtActiveVOL;
                    for (int i = 0; i < ActiveDataGrid.Columns.Count; i++)
                    {
                        ActiveDataGrid.Columns[i].ReadOnly = true;
                    }
                    for (int i = 0; i < AttendedGridView.Columns.Count; i++)
                    {
                        AttendedGridView.Columns[i].ReadOnly = true;
                    }
                }
                else
                {
                    MessageBox.Show("Error!");
                }

            }
        }

        private void CheckOutAll_Click(object sender, EventArgs e)
        {
            CheckOutAll_Vol();
        }

        private void Save_Records() 
        {
            //save each data grid view to a separate sheet in one excel file named EventName_Date_Shift.xlsx
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            Workbook wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)excel.ActiveSheet;
            ws.Name = "Attended Volunteers";
            for (int i = 1; i < AttendedGridView.Columns.Count + 1; i++)
            {
                ws.Cells[1, i] = AttendedGridView.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < AttendedGridView.Rows.Count; i++)
            {
                for (int j = 0; j < AttendedGridView.Columns.Count; j++)
                {
                    ws.Cells[i + 2, j + 1].NumberFormat = "@";
                    ws.Cells[i + 2, j + 1] = AttendedGridView.Rows[i].Cells[j].Value.ToString();
                }
            }

            Worksheet ws1 = wb.Sheets.Add();
            ws1.Name = "Active Volunteers";
            for (int i = 1; i < ActiveDataGrid.Columns.Count + 1; i++)
            {
                ws1.Cells[1, i] = ActiveDataGrid.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < ActiveDataGrid.Rows.Count; i++)
            {
                for (int j = 0; j < ActiveDataGrid.Columns.Count; j++)
                {
                    ws1.Cells[i + 2, j + 1].NumberFormat = "@";
                    ws1.Cells[i + 2, j + 1] = ActiveDataGrid.Rows[i].Cells[j].Value.ToString();
                }
            }

            //set the Attended Volunteers as the active sheet (the first sheet)
            ws.Activate();
            ws.Select();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = EventName + "_" + Now.ToString("dd_MM_yyyy") + "_Shift.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                wb.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Saved!");
            }
            excel.Quit();
        }

        private void SaveRecords_Click(object sender, EventArgs e)
        {
            Save_Records();
        }

        private void AddVol_Click(object sender, EventArgs e)
        {
            // prompt the user to enter the volunteer's Name, V_ID and Phone
            AddVolunteerForm addVolunteerForm = new AddVolunteerForm(EventName);
            addVolunteerForm.ShowDialog();
            // when the user claoses the AddVolunteerForm, update the AllVolDataGrid with the new volunteer's data from the form 
            // there in public bool isVolunteerAdded if it is true then add the new volunteer to the AllVolDataGrid
            // there are public strings VolID, VolPhone, VolName that store the new volunteer's data
            if (addVolunteerForm.isVolunteerAdded)
            {
                dtAllVOL.Rows.Add(addVolunteerForm.VolName, addVolunteerForm.VolPhone, addVolunteerForm.VolID, 0);
                AllVolDataGrid.DataSource = dtAllVOL;
                for (int i = 0; i < AllVolDataGrid.Columns.Count; i++)
                {
                    AllVolDataGrid.Columns[i].ReadOnly = true;
                }
            }
        }

        // when the user closes the ManageEventForm, check if the user wants to save the data or not
        public void ManageEventForm_FormClosing()
        {
            // check if the ActiveDataGrid is empty or not
            if (ActiveDataGrid.Rows.Count > 0)
            {
                
                DialogResult result = MessageBox.Show("Do you want to save the data? Else Check Out All Volunteers in this shift ", "Save Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Save_Records();
                }
                else
                {
                    CheckOutAll_Vol();
                    MessageBox.Show("Checked Out All Volunteers!");
                }


            }
        }

    }

}


