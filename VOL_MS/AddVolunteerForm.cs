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

namespace VOL_MS
{
    public partial class AddVolunteerForm : Form
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        static SqlDataReader dr;
        string EventName;

        public string VolName;
        public string VolPhone;
        public string VolID;
        public bool isVolunteerAdded = false;

        public AddVolunteerForm(string eventName)
        {
            InitializeComponent();
            conn = new SqlConnection(ConnectionDB.GetConnectionString());
            EventName = eventName;
        }

        private void AddVolunteerForm_Load(object sender, EventArgs e)
        {
            eventNameLable.Text = EventName;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // check if the user has entered a name
            if (NameBox.Text == "")
            {
                MessageBox.Show("Please enter a name");
                return;
            }
            // check if the user has entered a phone number
            if (PhoneBox.Text == "")
            {
                MessageBox.Show("Please enter a phone number");
                return;
            }
            // check if the user has entered th V_ID
            if (V_IDBox.Text == "")
            {
                MessageBox.Show("Please enter a V_ID");
                return;
            }
            // check if the v_id is  valid (the v_id starts with a V followed by 6 numarical digits)
            if (!V_IDBox.Text.StartsWith("V") || V_IDBox.Text.Length != 7)
            {
                MessageBox.Show("Please enter a valid V_ID");
                return;
            }
            // check if the V_ID index 1-6 are all digits
            for (int i = 1; i < 7; i++)
            {
                if (!char.IsDigit(V_IDBox.Text[i]))
                {
                    MessageBox.Show("Please enter a valid V_ID");
                    return;
                }
            }
            // check if the V_ID is already in the EventName table in database 
            conn.Open();
            cmd = new SqlCommand("SELECT * FROM " + EventName + " WHERE V_ID = '" + V_IDBox.Text + "'", conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("This V_ID is already in the event");
                conn.Close();
                return;
            }
            conn.Close();
            // add the volunteer to the event
            conn.Open();
            cmd = new SqlCommand("INSERT INTO " + EventName + " (V_ID, Name, Phone) VALUES ('" + V_IDBox.Text + "', N'" + NameBox.Text + "', '" + PhoneBox.Text + "')", conn);
            try
            {
                cmd.ExecuteNonQuery();
                //check if the volunteer added to the event
                cmd = new SqlCommand("SELECT * FROM " + EventName + " WHERE V_ID = '" + V_IDBox.Text + "'", conn);
                dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    MessageBox.Show("Volunteer not added to the event");
                    conn.Close();
                    return;
                }
                MessageBox.Show("Volunteer added successfully");
                VolName = NameBox.Text;
                VolPhone = PhoneBox.Text;
                VolID = V_IDBox.Text;
                isVolunteerAdded = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            this.Close();


        }

    }
}
