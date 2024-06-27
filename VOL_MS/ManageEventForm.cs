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
        static SqlConnection connShifts;

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
            connShifts = new SqlConnection(ConnectionDB.GetShitsConnectionString());

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


            //populate ActiveDataGrid from the "Shifts" table in the ShiftsDB database with the data of the current date and the current EventName and remove the data from the AllVolDataGrid
            connShifts.Open();
            cmd = new SqlCommand("SELECT COUNT(*) FROM [Shifts] WHERE [Date] = '" + Now.ToString("yyyy_MM_dd") + "' AND [EventName] = '" + EventName + "'", connShifts);
            dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count = Convert.ToInt32(dr[0]);
            }
            dr.Close();
            connShifts.Close();
            if(count > 0)
            {
                System.Data.DataTable dt = new System.Data.DataTable();

                connShifts.Open();
                cmd = new SqlCommand("SELECT * FROM [Shifts] WHERE [Date] = '" + Now.ToString("yyyy_MM_dd") + "' AND [EventName] = '" + EventName + "'", connShifts);
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dr.Close();
                connShifts.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dtActiveVOL.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][6].ToString(), 0, dt.Rows[i][4].ToString(), null);

                }
                // delete the dt datatable
                dt.Clear();
                dt.Dispose();


                ActiveDataGrid.DataSource = dtActiveVOL;
                for (int i = 0; i < ActiveDataGrid.Columns.Count; i++)
                {
                    ActiveDataGrid.Columns[i].ReadOnly = false;
                }
                //remove the volunteers that are in the ActiveDataGrid from the AllVolDataGrid

                for (int i = 0; i < dtActiveVOL.Rows.Count; i++)
                {
                    for (int j = 0; j < dtAllVOL.Rows.Count; j++)
                    {
                        if (dtActiveVOL.Rows[i][2].ToString() == dtAllVOL.Rows[j][2].ToString())
                        {
                            dtAllVOL.Rows.RemoveAt(j);
                        }
                    }
                }
                AllVolDataGrid.DataSource = dtAllVOL;
                for (int k = 0; k < AllVolDataGrid.Columns.Count; k++)
                {
                    AllVolDataGrid.Columns[k].ReadOnly = true;
                }

            }



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
            try
            {
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
                    //insert the volunteer's data to the "Shifts" table in the ShiftsDB database
                    connShifts.Open();
                    cmd = new SqlCommand("INSERT INTO [Shifts] ([Name], [V_ID], [Phone], [Date], [Check IN], [EventName], [TotalHours]) VALUES (N'" + dtActiveVOL.Rows[dtActiveVOL.Rows.Count - 1][0].ToString() + "', '" + dtActiveVOL.Rows[dtActiveVOL.Rows.Count - 1][2].ToString() + "', '" + dtActiveVOL.Rows[dtActiveVOL.Rows.Count - 1][1].ToString() + "', '" + Now.ToString("yyyy_MM_dd") + "', '" + Now.ToString("HH:mm:ss") + "', '" + EventName + "', '"+ dtActiveVOL.Rows[dtActiveVOL.Rows.Count - 1][3].ToString() + "' )", connShifts);
                    cmd.ExecuteNonQuery();
                    connShifts.Close();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ActiveDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
                        //remove the volunteer from the "Shifts" table in the ShiftsDB database
                        connShifts.Open();
                        cmd = new SqlCommand("DELETE FROM [Shifts] WHERE [V_ID] = '" + ActiveDataGrid.Rows[e.RowIndex].Cells[3].Value.ToString() + "' AND [Date] = '" + Now.ToString("yyyy_MM_dd") + "' AND [EventName] = '" + EventName + "'", connShifts);
                        cmd.ExecuteNonQuery();
                        connShifts.Close();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                //Remove the volunteer from the "Shifts" table in the ShiftsDB database
                connShifts.Open();
                cmd = new SqlCommand("DELETE FROM [Shifts] WHERE [V_ID] = '" + ActiveDataGrid.Rows[iRowIndex].Cells[3].Value.ToString() + "' AND [Date] = '" + Now.ToString("yyyy_MM_dd") + "' AND [EventName] = '" + EventName + "'", connShifts);
                cmd.ExecuteNonQuery();
                connShifts.Close();
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
            for (int i = 1; i < ActiveDataGrid.Columns.Count ; i++)
            {
                ws1.Cells[1, i] = ActiveDataGrid.Columns[i].HeaderText;
            }
            for (int i = 0; i < ActiveDataGrid.Rows.Count; i++)
            {
                for (int j = 1; j < ActiveDataGrid.Columns.Count; j++)
                {
                    ws1.Cells[i + 2, j ].NumberFormat = "@";
                    ws1.Cells[i + 2, j ] = ActiveDataGrid.Rows[i].Cells[j].Value.ToString();
                }
            }

            //set the Attended Volunteers as the active sheet (the first sheet)
            ws.Activate();
            ws.Select();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = EventName + "_" + Now.ToString("yyyy_MM_dd") + "_Shift.xlsx";
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
            /*/ check if the ActiveDataGrid is empty or not
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


            }*/
        }

        private void RecoverExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to recover the data from an excel file?", "Recover Data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    //check if the ActiveDataGrid is empty or not
                    if (ActiveDataGrid.Rows.Count > 0)
                    {
                        DialogResult result1 = MessageBox.Show("Warning! All the current data will be lost It is recommended to Check Out All Volunteers before performing this action", "Check Out All ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result1 == DialogResult.Yes)
                        {
                            CheckOutAll_Vol();
                            MessageBox.Show("Checked Out All Volunteers!");
                        }
                    }

                    // clear the data in the ActiveDataGrid 
                    dtActiveVOL.Clear();
                    ActiveDataGrid.DataSource = dtActiveVOL;

                    // let the user choose the excel file to recover the data from it
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";


                    //check if the user selected a file or not then validate the file name EventName_yyyy_MM_dd_Shift if it is valid then recover the data from the file

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = openFileDialog.FileName;
                        // get file name without the path
                        fileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
                        //get the shift date from the file name (the date is in the format yyyy_MM_dd and it srarts from the 16th character from the end of the file name)
                        // Split the string by underscore
                        string[] parts = fileName.Split('_');
                        // Assuming the date is always the second to last element
                        int datePartIndex = parts.Length - 4; // Adjust the index based on the fixed position of the date

                        string EventNameFromFile = string.Join("_", parts.Take(datePartIndex));
                        string dateFromFile = $"{parts[datePartIndex]}_{parts[datePartIndex + 1]}_{parts[datePartIndex + 2]}";





                        if (EventNameFromFile == EventName && dateFromFile == Now.ToString("yyyy_MM_dd"))
                        {
                            try
                            {
                                // open the excel file and read the data from the Active Volunteers sheet and the Attended Volunteers sheet
                                //ignore the first row in each sheet because it contains the column names 
                                //add the data from the Active Volunteers sheet to the ActiveDataGrid and dtActiveVOL
                                // appned the data from the Attended Volunteers sheet to the AttendedGridView and dtAttendedVOL
                                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                                Workbook wb = excel.Workbooks.Open(openFileDialog.FileName);
                                Worksheet ws = (Worksheet)wb.Sheets[1];
                                int i = 2;
                                while (ws.Cells[i, 1].Value != null)
                                {
                                    dtActiveVOL.Rows.Add(ws.Cells[i, 1].Value.ToString(), ws.Cells[i, 2].Value.ToString(), ws.Cells[i, 3].Value.ToString(), ws.Cells[i, 4].Value.ToString(), ws.Cells[i, 5].Value.ToString(), ws.Cells[i, 6].Value.ToString(), ws.Cells[i, 7].Value.ToString());
                                    i++;
                                }
                                ActiveDataGrid.DataSource = dtActiveVOL;
                                for (int j = 0; j < ActiveDataGrid.Columns.Count; j++)
                                {
                                    ActiveDataGrid.Columns[j].ReadOnly = true;
                                }

                                Worksheet ws1 = (Worksheet)wb.Sheets[2];
                                i = 2;
                                while (ws1.Cells[i, 1].Value != null)
                                {
                                    dtAttendedVOL.Rows.Add(ws1.Cells[i, 1].Value.ToString(), ws1.Cells[i, 2].Value.ToString(), ws1.Cells[i, 3].Value.ToString(), ws1.Cells[i, 4].Value.ToString(), ws1.Cells[i, 5].Value.ToString(), ws1.Cells[i, 6].Value.ToString(), ws1.Cells[i, 7].Value.ToString());
                                    i++;
                                }
                                AttendedGridView.DataSource = dtAttendedVOL;
                                for (int j = 0; j < AttendedGridView.Columns.Count; j++)
                                {
                                    AttendedGridView.Columns[j].ReadOnly = true;
                                }
                                wb.Close();
                                excel.Quit();
                                //remove all the data that was recovered from the excel file from the AllVolDataGrid
                                for (int j = 0; j < dtActiveVOL.Rows.Count; j++)
                                {
                                    for (int k = 0; k < dtAllVOL.Rows.Count; k++)
                                    {
                                        if (dtActiveVOL.Rows[j][2].ToString() == dtAllVOL.Rows[k][2].ToString())
                                        {
                                            dtAllVOL.Rows.RemoveAt(k);
                                            AllVolDataGrid.DataSource = dtAllVOL;
                                            for (int l = 0; l < AllVolDataGrid.Columns.Count; l++)
                                            {
                                                AllVolDataGrid.Columns[l].ReadOnly = true;
                                            }
                                        }
                                    }
                                }

                                for (int j = 0; j < dtAttendedVOL.Rows.Count; j++)
                                {
                                    for (int k = 0; k < dtAllVOL.Rows.Count; k++)
                                    {
                                        if (dtAttendedVOL.Rows[j][2].ToString() == dtAllVOL.Rows[k][2].ToString())
                                        {
                                            dtAllVOL.Rows.RemoveAt(k);
                                            AllVolDataGrid.DataSource = dtAllVOL;
                                            for (int l = 0; l < AllVolDataGrid.Columns.Count; l++)
                                            {
                                                AllVolDataGrid.Columns[l].ReadOnly = true;
                                            }
                                        }
                                    }
                                }

                                MessageBox.Show("Recovered!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }



                        }
                        else
                        {
                            if (EventNameFromFile != EventName)
                            {
                                MessageBox.Show("The Event Name in the file does not match the current Event Name!");
                            }
                            else if (dateFromFile != Now.ToString("yyyy_MM_dd"))
                            {
                                MessageBox.Show("The Date in the file does not match the current Date!");
                            }
                            else
                            {
                                MessageBox.Show("Invalid File Name!");
                            }
                        }

                    }




                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }
    }

}


