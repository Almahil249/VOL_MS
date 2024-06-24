using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;
using VOL_MS;
using Microsoft.VisualStudio.OLE;
using Microsoft.Office.Interop.Excel;
using DataTable = Microsoft.Office.Interop.Excel.DataTable;

namespace VOL_MS
{
    public partial class AddEventForm : Form
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        static SqlDataReader dr;



        public AddEventForm()
        {
            InitializeComponent();
            conn = new SqlConnection(ConnectionDB.GetConnectionString());
        }



        private void SelectExcel_Click(object sender, EventArgs e)
        {
          OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Excel Sheet(*.xls;*.xlsx;*.xlsm)|*.xls;*.xlsx;*.xlsm|All Files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application xlApp;
                Microsoft.Office.Interop.Excel.Workbook xWorkbook;
                Microsoft.Office.Interop.Excel.Worksheet xlworksheet;
                Microsoft.Office.Interop.Excel.Range xlRange;

                int xlRow;
                string strFileName = op.FileName;

                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xWorkbook = xlApp.Workbooks.Open(strFileName);
                xlworksheet = xWorkbook.Sheets[1];
                xlRange = xlworksheet.UsedRange;
                int i = 0;

                for (xlRow = 2 ; xlRow <= xlRange.Rows.Count; xlRow++)
                {
                    i++;
                    string phone = "";

                    // check if the Phone number is empty
                    if (xlRange.Cells[xlRow, 3].Value != null)
                    {
                        phone = xlRange.Cells[xlRow, 3].Value.ToString();
                    }
                    // check if the V_ID is empty or not valid
                    if (xlRange.Cells[xlRow, 2].Value == null)
                    {
                        MessageBox.Show("V_ID is empty in row " + i + " and it will not be add to the database Name:  " + xlRange.Cells[xlRow, 1].Text);
                        continue;
                    }
                    if (!xlRange.Cells[xlRow, 2].Value.ToString().StartsWith("V") || xlRange.Cells[xlRow, 2].Value.ToString().Length != 7)
                    {
                        MessageBox.Show("V_ID is Not Valid in row " + i + " and it will not be add to the database Name:  "+xlRange.Cells[xlRow,1].Text );
                        continue;
                    }
                    // check if the V_ID index 1-6 are all digits

                    
                    for (int r = 1; r < 7; r++)
                    {
                        if (!char.IsDigit(xlRange.Cells[xlRow, 2].Text[r]))
                        {
                            MessageBox.Show("V_ID is Not Valid in row " + i + " and it will not be add to the database Name:  " + xlRange.Cells[xlRow, 1].Text);
                            continue;
                        }
                    }
                    resultDataGrid.Rows.Add(xlRange.Cells[xlRow,1].Text, xlRange.Cells[xlRow, 2].Text, phone);
                }
                xWorkbook.Close();
                xlApp.Quit();

            }

        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            // check if the event name is empty
            if (EventName.Text == "")
            {
                MessageBox.Show("Please enter the event name");
                return;
            }
            //remove all spaces from the event name and replace them with underscores
            EventName.Text = EventName.Text.Replace(" ", "_");
            bool IsUpdate = false;
            //check if the event name already exists in the database
            conn.Open();
            cmd = new SqlCommand("SELECT * FROM sys.tables WHERE name = '" + EventName.Text + "'", conn);
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Close();
                conn.Close();
                // prompt the user and ask if they want to update the data
                DialogResult dialogResult = MessageBox.Show("Event already exists, do you want to update the data?", "Event Exists", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    conn.Open();
                    // add any new data to the existing data (if the V_ID is not in the database add it)
                    for (int i = 0; i < resultDataGrid.Rows.Count; i++)
                    {
                        cmd = new SqlCommand("SELECT * FROM " + EventName.Text + " WHERE V_ID = '" + resultDataGrid.Rows[i].Cells[1].Value + "'", conn);
                        dr = cmd.ExecuteReader();
                        if (!dr.HasRows)
                        {
                            dr.Close();
                            cmd = new SqlCommand("INSERT INTO " + EventName.Text + " (Name, Phone, V_ID) VALUES (N'" + resultDataGrid.Rows[i].Cells[0].Value + "', @Phone, @V_ID)", conn);
                            //cmd.Parameters.AddWithValue("@Name", resultDataGrid.Rows[i].Cells[0].Value);
                            cmd.Parameters.AddWithValue("@Phone", resultDataGrid.Rows[i].Cells[2].Value);
                            cmd.Parameters.AddWithValue("@V_ID", resultDataGrid.Rows[i].Cells[1].Value);
                            cmd.ExecuteNonQuery();
                        }
                        dr.Close();
                    }
                    MessageBox.Show("Data Updated");
                    IsUpdate = true;
                    conn.Close();
                    return;
                }
                else
                {

                    return;
                }
            }
            dr.Close();
            conn.Close();
            // check if the data grid is empty
            if (resultDataGrid.Rows.Count == 0)
            {
                MessageBox.Show("Please select an excel file");
                return;
            }


            if (!IsUpdate)
            {
                conn.Open();
                cmd = new SqlCommand(
                    "CREATE TABLE [" + EventName.Text +
                    "] ([Name] NVARCHAR(40) NOT NULL, [Phone] VARCHAR(17) NULL, [V_ID] VARCHAR(10) NOT NULL, [TotalHours] FLOAT NOT NULL DEFAULT 0.0, PRIMARY KEY (V_ID))",
                    conn);
                cmd.ExecuteNonQuery();
                for (int i = 0; i < resultDataGrid.Rows.Count; i++)
                {
                    cmd = new SqlCommand("INSERT INTO " + EventName.Text + " (Name, Phone, V_ID) VALUES (N'" + resultDataGrid.Rows[i].Cells[0].Value+"', @Phone, @V_ID)", conn);
                    //cmd.Parameters.AddWithValue("@Name", resultDataGrid.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@Phone", resultDataGrid.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@V_ID", resultDataGrid.Rows[i].Cells[1].Value);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        conn.Close();
                        InitializeComponent();
                        return;
                    }


                }
                MessageBox.Show("Data Added");
                conn.Close();

            }




        }


    }
    }

