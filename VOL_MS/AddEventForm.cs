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
                    string phone = xlRange.Cells[xlRow, 3].Value.ToString();

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

            //check if the event name already exists in the database
            conn.Open();
            cmd = new SqlCommand("SELECT * FROM sys.tables WHERE name = '" + EventName.Text + "'", conn);
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                MessageBox.Show("Event already exists");
                dr.Close();
                conn.Close();
                return;
            }
            dr.Close();
            conn.Close();
            // check if the data grid is empty
            if (resultDataGrid.Rows.Count == 0)
            {
                MessageBox.Show("Please select an excel file");
                return;
            }


            conn.Open();
            cmd = new SqlCommand(
                "CREATE TABLE [" + EventName.Text +
                "] ([Name] VARCHAR(40) NOT NULL, [Phone] VARCHAR(17) NULL, [V_ID] VARCHAR(10) NOT NULL, [TotalHours] FLOAT NOT NULL DEFAULT 0.0, PRIMARY KEY (V_ID))",
                conn);
            cmd.ExecuteNonQuery();
            for (int i = 0; i < resultDataGrid.Rows.Count; i++)
            {
                cmd = new SqlCommand("INSERT INTO " + EventName.Text + " (Name, Phone, V_ID) VALUES (@Name, @Phone, @V_ID)", conn);
                cmd.Parameters.AddWithValue("@Name", resultDataGrid.Rows[i].Cells[0].Value);
                cmd.Parameters.AddWithValue("@Phone", resultDataGrid.Rows[i].Cells[2].Value);
                cmd.Parameters.AddWithValue("@V_ID", resultDataGrid.Rows[i].Cells[1].Value);
                try {
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

