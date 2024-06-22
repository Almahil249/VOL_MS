using System;
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

namespace VOL_MS
{
    public partial class MainForm : Form
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        static SqlCommand cmd1;
        static SqlDataReader dr;

        public MainForm()
        {
            InitializeComponent();
            LoadChildFormIntoPanel(new HomeForm());
            conn = new SqlConnection(ConnectionDB.GetConnectionString());            
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
        }
    }
}

