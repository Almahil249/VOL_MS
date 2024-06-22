namespace VOL_MS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AllVolLable = new System.Windows.Forms.Label();
            this.AllVolDataGrid = new System.Windows.Forms.DataGridView();
            this.ActiveVolLable = new System.Windows.Forms.Label();
            this.ActiveDataGrid = new System.Windows.Forms.DataGridView();
            this.VolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.V_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TodayHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.DateLable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EventNameLable = new System.Windows.Forms.Label();
            this.TitleLable = new System.Windows.Forms.Label();
            this.Search1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.AllVolDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActiveDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AllVolLable
            // 
            this.AllVolLable.AutoSize = true;
            this.AllVolLable.BackColor = System.Drawing.SystemColors.Window;
            this.AllVolLable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AllVolLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllVolLable.Location = new System.Drawing.Point(0, 532);
            this.AllVolLable.Name = "AllVolLable";
            this.AllVolLable.Size = new System.Drawing.Size(190, 20);
            this.AllVolLable.TabIndex = 8;
            this.AllVolLable.Text = "Event Volunteers List";
            // 
            // AllVolDataGrid
            // 
            this.AllVolDataGrid.AllowUserToAddRows = false;
            this.AllVolDataGrid.AllowUserToDeleteRows = false;
            this.AllVolDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllVolDataGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AllVolDataGrid.Location = new System.Drawing.Point(0, 552);
            this.AllVolDataGrid.Name = "AllVolDataGrid";
            this.AllVolDataGrid.RowHeadersWidth = 51;
            this.AllVolDataGrid.RowTemplate.Height = 24;
            this.AllVolDataGrid.Size = new System.Drawing.Size(1005, 88);
            this.AllVolDataGrid.TabIndex = 7;
            // 
            // ActiveVolLable
            // 
            this.ActiveVolLable.AutoSize = true;
            this.ActiveVolLable.BackColor = System.Drawing.SystemColors.Window;
            this.ActiveVolLable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ActiveVolLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActiveVolLable.Location = new System.Drawing.Point(0, 640);
            this.ActiveVolLable.Name = "ActiveVolLable";
            this.ActiveVolLable.Size = new System.Drawing.Size(263, 20);
            this.ActiveVolLable.TabIndex = 6;
            this.ActiveVolLable.Text = "today\'s Shift active volunteers";
            // 
            // ActiveDataGrid
            // 
            this.ActiveDataGrid.AllowUserToAddRows = false;
            this.ActiveDataGrid.AllowUserToDeleteRows = false;
            this.ActiveDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ActiveDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VolName,
            this.V_ID,
            this.Phone,
            this.TotalHours,
            this.TodayHours,
            this.CheckIn,
            this.CheckOut,
            this.Action});
            this.ActiveDataGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ActiveDataGrid.Location = new System.Drawing.Point(0, 660);
            this.ActiveDataGrid.Name = "ActiveDataGrid";
            this.ActiveDataGrid.RowHeadersWidth = 51;
            this.ActiveDataGrid.RowTemplate.Height = 24;
            this.ActiveDataGrid.Size = new System.Drawing.Size(1005, 270);
            this.ActiveDataGrid.TabIndex = 5;
            // 
            // VolName
            // 
            this.VolName.HeaderText = "Name";
            this.VolName.MinimumWidth = 6;
            this.VolName.Name = "VolName";
            this.VolName.ReadOnly = true;
            this.VolName.Width = 125;
            // 
            // V_ID
            // 
            this.V_ID.HeaderText = "V_ID";
            this.V_ID.MinimumWidth = 6;
            this.V_ID.Name = "V_ID";
            this.V_ID.ReadOnly = true;
            this.V_ID.Width = 125;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Phone";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            this.Phone.Width = 125;
            // 
            // TotalHours
            // 
            this.TotalHours.HeaderText = "TotoalHours";
            this.TotalHours.MinimumWidth = 6;
            this.TotalHours.Name = "TotalHours";
            this.TotalHours.ReadOnly = true;
            this.TotalHours.Width = 125;
            // 
            // TodayHours
            // 
            this.TodayHours.HeaderText = "Today\'s Hours";
            this.TodayHours.MinimumWidth = 6;
            this.TodayHours.Name = "TodayHours";
            this.TodayHours.ReadOnly = true;
            this.TodayHours.Width = 125;
            // 
            // CheckIn
            // 
            this.CheckIn.HeaderText = "Check In ";
            this.CheckIn.MinimumWidth = 6;
            this.CheckIn.Name = "CheckIn";
            this.CheckIn.ReadOnly = true;
            this.CheckIn.Width = 125;
            // 
            // CheckOut
            // 
            this.CheckOut.HeaderText = "Check Out";
            this.CheckOut.MinimumWidth = 6;
            this.CheckOut.Name = "CheckOut";
            this.CheckOut.ReadOnly = true;
            this.CheckOut.Width = 125;
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.MinimumWidth = 6;
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Width = 125;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(280, 501);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Saerch";
            // 
            // DateLable
            // 
            this.DateLable.AutoSize = true;
            this.DateLable.BackColor = System.Drawing.Color.White;
            this.DateLable.Dock = System.Windows.Forms.DockStyle.Left;
            this.DateLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLable.Location = new System.Drawing.Point(429, 0);
            this.DateLable.Name = "DateLable";
            this.DateLable.Padding = new System.Windows.Forms.Padding(20);
            this.DateLable.Size = new System.Drawing.Size(40, 65);
            this.DateLable.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(325, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(20);
            this.label1.Size = new System.Drawing.Size(104, 65);
            this.label1.TabIndex = 13;
            this.label1.Text = "Date:";
            // 
            // EventNameLable
            // 
            this.EventNameLable.AutoSize = true;
            this.EventNameLable.BackColor = System.Drawing.Color.White;
            this.EventNameLable.Dock = System.Windows.Forms.DockStyle.Left;
            this.EventNameLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventNameLable.Location = new System.Drawing.Point(285, 0);
            this.EventNameLable.Margin = new System.Windows.Forms.Padding(10);
            this.EventNameLable.Name = "EventNameLable";
            this.EventNameLable.Padding = new System.Windows.Forms.Padding(20);
            this.EventNameLable.Size = new System.Drawing.Size(40, 65);
            this.EventNameLable.TabIndex = 10;
            // 
            // TitleLable
            // 
            this.TitleLable.AutoSize = true;
            this.TitleLable.BackColor = System.Drawing.Color.White;
            this.TitleLable.Dock = System.Windows.Forms.DockStyle.Left;
            this.TitleLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLable.Location = new System.Drawing.Point(0, 0);
            this.TitleLable.Margin = new System.Windows.Forms.Padding(10);
            this.TitleLable.Name = "TitleLable";
            this.TitleLable.Padding = new System.Windows.Forms.Padding(20);
            this.TitleLable.Size = new System.Drawing.Size(285, 65);
            this.TitleLable.TabIndex = 11;
            this.TitleLable.Text = "You are now managing :";
            // 
            // Search1
            // 
            this.Search1.Location = new System.Drawing.Point(377, 499);
            this.Search1.Name = "Search1";
            this.Search1.Size = new System.Drawing.Size(200, 22);
            this.Search1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 930);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DateLable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EventNameLable);
            this.Controls.Add(this.TitleLable);
            this.Controls.Add(this.Search1);
            this.Controls.Add(this.AllVolLable);
            this.Controls.Add(this.AllVolDataGrid);
            this.Controls.Add(this.ActiveVolLable);
            this.Controls.Add(this.ActiveDataGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.AllVolDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActiveDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AllVolLable;
        private System.Windows.Forms.DataGridView AllVolDataGrid;
        private System.Windows.Forms.Label ActiveVolLable;
        private System.Windows.Forms.DataGridView ActiveDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn VolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn V_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn TodayHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckOut;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label DateLable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label EventNameLable;
        private System.Windows.Forms.Label TitleLable;
        private System.Windows.Forms.TextBox Search1;
    }
}