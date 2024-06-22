using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using DataTable = Microsoft.Office.Interop.Excel.DataTable;


namespace VOL_MS
{
    public partial class ShowDataForm : Form
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        static SqlCommand cmd1;
        static SqlDataReader dr;
        string[] tableNames1;
        System.Data.DataTable dtAllVOL = new System.Data.DataTable();

        public ShowDataForm()
        {
            InitializeComponent();
            conn = new SqlConnection(ConnectionDB.GetConnectionString());

        }
        public ShowDataForm(string eventName)
        {
            InitializeComponent();
            conn = new SqlConnection(ConnectionDB.GetConnectionString());

            ShowButton.Text = "Show and Save as Excel : " + eventName;



            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(0, 250);
            dataGridView1.Name = "resultDataGrid";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new System.Drawing.Size(817, 175);
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Phone", "Phone");
            dataGridView1.Columns.Add("V_ID", "V_ID");
            dataGridView1.Columns.Add("TotalHours", "TotalHours");
            dataGridView1.Columns.Add("EventName", "Event Name: " + eventName);



            LoadChildDataGridIntoPanel(dataGridView1, eventName);


        }


        private void LoadChildDataGridIntoPanel(DataGridView childDataGridView, string eventName)
        {
            dtAllVOL.Clear();
            panelContent.Controls.Clear();
            childDataGridView.Rows.Clear();
            childDataGridView.Columns.Clear();
            childDataGridView.AllowUserToAddRows = false;
            childDataGridView.AllowUserToDeleteRows = false;
            childDataGridView.Dock = DockStyle.Fill;
            panelContent.Controls.Add(childDataGridView);
            

            SqlDataAdapter da = new SqlDataAdapter("select * from [" + eventName + "]", conn);
            da.Fill(dtAllVOL);
            childDataGridView.DataSource = dtAllVOL;
            //set all the columns to read only
            for (int i = 0; i < childDataGridView.Columns.Count; i++)
            {
                childDataGridView.Columns[i].ReadOnly = true;
            }
            childDataGridView.Show();

            //export the data to a xlsx file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = eventName + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Workbook wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
                Worksheet ws = (Worksheet)excel.ActiveSheet;

                // storing header part in Excel
                for (int i = 1; i < childDataGridView.Columns.Count + 1; i++)
                {
                    ws.Cells[1, i] = childDataGridView.Columns[i - 1].HeaderText;
                }

                // storing Each row and column value to excel sheet
                for (int i = 0; i < childDataGridView.Rows.Count ; i++)
                {
                    for (int j = 0; j < childDataGridView.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j + 1].NumberFormat = "@";
                        ws.Cells[i + 2, j + 1] = childDataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // save the file
                wb.SaveAs(path);
                wb.Close();
                excel.Quit();
                MessageBox.Show("Data exported successfully");

            }
        }


        private void labelTitle_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
        }
        private void ShowDataForm_Load(object sender, EventArgs e)
        {
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

            tableNames1 = tableNames;

            // populate the AllEventsDataGrid with the names of the tables
            AllEventsDataGrid.Rows.Clear();
            for (int j = 0; j < tableCount; j++)
            {
                AllEventsDataGrid.Rows.Add(tableNames[j]);
            }
            // add events names to the EventsComboBox
            for (int j = 0; j < tableCount; j++)
            {
                EventsComboBox.Items.Add(tableNames[j]);
            }

        }

        private void EventsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // change the text of the ShowButton to the name of the selected event from the EventsComboBox
            ShowButton.Text = "Show and Save as Excel : " + EventsComboBox.Text.ToString();
            DeleteEvent.Visible = true;
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            //retrieve the event name from the EventsComboBox and display the data in the DataGridView in the panelContent
            string eventName = EventsComboBox.Text;
            //check if the event name not empty and if the event name is in the tableNames 
            if (eventName != "" && EventsComboBox.Items.Contains(eventName))
            {
                DataGridView dataGridView = new DataGridView();
                dataGridView.AllowUserToAddRows = false;
                dataGridView.AllowUserToDeleteRows = false;

                LoadChildDataGridIntoPanel(dataGridView, eventName);
            }
            else
            {
                MessageBox.Show("Select a valid event from the list");
            }
        }

        private void DeleteEvent_Click(object sender, EventArgs e)
        {
            //prompt the user to confirm the deletion of the event
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete :" + EventsComboBox.Text , "Delete Event", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                // check if the EventsComboBox.Text is in the database
                conn.Open();
                cmd = new SqlCommand("SELECT COUNT(*) FROM information_schema.tables WHERE TABLE_NAME = '" + EventsComboBox.Text + "'", conn);
                dr = cmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count = Convert.ToInt32(dr[0]);
                }
                dr.Close();
                conn.Close();
                if (count == 0)
                {
                    MessageBox.Show("Event not found in the database");
                    return;
                }

                //delete the event from the database
                conn.Open();
                cmd = new SqlCommand("DROP TABLE [" + EventsComboBox.Text + "]", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                //refresh the EventsComboBox and the AllEventsDataGrid
                EventsComboBox.Items.Clear();
                AllEventsDataGrid.Rows.Clear();
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

                tableNames1 = tableNames;

                // populate the AllEventsDataGrid with the names of the tables
                AllEventsDataGrid.Rows.Clear();
                for (int j = 0; j < tableCount; j++)
                {
                    AllEventsDataGrid.Rows.Add(tableNames[j]);
                }
                // add events names to the EventsComboBox
                for (int j = 0; j < tableCount; j++)
                {
                    EventsComboBox.Items.Add(tableNames[j]);
                }
                MessageBox.Show("Event deleted successfully");
            }
        }
    }
}
