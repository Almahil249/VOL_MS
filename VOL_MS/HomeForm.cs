using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace VOL_MS
{
    public partial class HomeForm : Form
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        static SqlCommand cmd1;
        static SqlDataReader dr;
        public HomeForm()
        {
            InitializeComponent();
            conn = new SqlConnection(ConnectionDB.GetConnectionString());

        }


        private void HomeForm_Load(object sender, EventArgs e)
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
            //change the text of the result label to show the number of tables
            resultLable.Text = tableCount.ToString();

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

            // get the number of records in each table
            int[] tableRecords = new int[tableCount];
            conn.Open();
            for (int j = 0; j < tableCount; j++)
            {
                cmd = new SqlCommand("SELECT COUNT(*) FROM " + tableNames[j], conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tableRecords[j] = Convert.ToInt32(dr[0]);
                }
                dr.Close();
            }
            conn.Close();

            // get the number of records in each table that have not 0.0 values in the "TotalHours" column
            int[] tableRecordsNotNull = new int[tableCount];
            conn.Open();
            for (int j = 0; j < tableCount; j++)
            {
                // get the number of records in each table that have not 0.0 values in the "TotalHours" column
                cmd = new SqlCommand("SELECT COUNT(*) FROM " + tableNames[j] + " WHERE TotalHours != 0.0", conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tableRecordsNotNull[j] = Convert.ToInt32(dr[0]);
                }
                dr.Close();
            }
            conn.Close();
           
            // populate the dataGridView with the names of the tables
            for (int j = 0; j < tableCount; j++)
            {
                dataGridView.Rows.Add(tableNames[j], tableRecords[j], tableRecordsNotNull[j]);
            }


        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                string eventName = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                // call ManageEventForm(eventName); in the same window
                if (eventName != "" && dataGridView.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    var MainForm = (MainForm)Application.OpenForms["MainForm"];
                    MainForm.LoadChildFormIntoPanel(new ManageEventForm(eventName));
                }
                else
                {
                    MessageBox.Show("Please select an event from the list");
                }
            }

            // ShowDataForm(string tableName);
            //close the current form and open the ShowDataForm with the name of the table that the user clicked on






        }
    }
}
