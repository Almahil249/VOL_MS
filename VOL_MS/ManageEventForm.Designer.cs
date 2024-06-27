namespace VOL_MS
{
    partial class ManageEventForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageEventForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.RecoverExcel = new System.Windows.Forms.Button();
            this.AddVol = new System.Windows.Forms.Button();
            this.CheckOutAll = new System.Windows.Forms.Button();
            this.SaveRecords = new System.Windows.Forms.Button();
            this.Search1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AttendedGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ActiveDataGrid = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AllVolDataGrid = new System.Windows.Forms.DataGridView();
            this.DateLable = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.EventNameLable = new System.Windows.Forms.Label();
            this.TitleLable = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SearchActive = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AttendedGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActiveDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllVolDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RecoverExcel);
            this.panel1.Controls.Add(this.AddVol);
            this.panel1.Controls.Add(this.CheckOutAll);
            this.panel1.Controls.Add(this.SaveRecords);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 733);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1187, 65);
            this.panel1.TabIndex = 0;
            // 
            // RecoverExcel
            // 
            this.RecoverExcel.Dock = System.Windows.Forms.DockStyle.Left;
            this.RecoverExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecoverExcel.Location = new System.Drawing.Point(0, 0);
            this.RecoverExcel.Name = "RecoverExcel";
            this.RecoverExcel.Size = new System.Drawing.Size(190, 65);
            this.RecoverExcel.TabIndex = 1;
            this.RecoverExcel.Text = "Recover From Excel";
            this.RecoverExcel.UseVisualStyleBackColor = true;
            this.RecoverExcel.Click += new System.EventHandler(this.RecoverExcel_Click);
            // 
            // AddVol
            // 
            this.AddVol.Dock = System.Windows.Forms.DockStyle.Right;
            this.AddVol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.AddVol.Location = new System.Drawing.Point(715, 0);
            this.AddVol.Name = "AddVol";
            this.AddVol.Size = new System.Drawing.Size(183, 65);
            this.AddVol.TabIndex = 0;
            this.AddVol.Text = "Add New Volunteer";
            this.AddVol.UseVisualStyleBackColor = true;
            this.AddVol.Click += new System.EventHandler(this.AddVol_Click);
            // 
            // CheckOutAll
            // 
            this.CheckOutAll.BackColor = System.Drawing.Color.LimeGreen;
            this.CheckOutAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.CheckOutAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.CheckOutAll.Location = new System.Drawing.Point(898, 0);
            this.CheckOutAll.Name = "CheckOutAll";
            this.CheckOutAll.Size = new System.Drawing.Size(129, 65);
            this.CheckOutAll.TabIndex = 0;
            this.CheckOutAll.Text = "Check Out All";
            this.CheckOutAll.UseVisualStyleBackColor = false;
            this.CheckOutAll.Click += new System.EventHandler(this.CheckOutAll_Click);
            // 
            // SaveRecords
            // 
            this.SaveRecords.BackColor = System.Drawing.Color.LemonChiffon;
            this.SaveRecords.Dock = System.Windows.Forms.DockStyle.Right;
            this.SaveRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.SaveRecords.Location = new System.Drawing.Point(1027, 0);
            this.SaveRecords.Name = "SaveRecords";
            this.SaveRecords.Size = new System.Drawing.Size(160, 65);
            this.SaveRecords.TabIndex = 0;
            this.SaveRecords.Text = "Save Records (Excel)";
            this.SaveRecords.UseVisualStyleBackColor = false;
            this.SaveRecords.Click += new System.EventHandler(this.SaveRecords_Click);
            // 
            // Search1
            // 
            this.Search1.Location = new System.Drawing.Point(199, 91);
            this.Search1.Name = "Search1";
            this.Search1.Size = new System.Drawing.Size(200, 22);
            this.Search1.TabIndex = 5;
            this.Search1.TextChanged += new System.EventHandler(this.SearchALL_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Saerch";
            // 
            // AttendedGridView
            // 
            this.AttendedGridView.AllowUserToAddRows = false;
            this.AttendedGridView.AllowUserToDeleteRows = false;
            this.AttendedGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AttendedGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AttendedGridView.Location = new System.Drawing.Point(0, 568);
            this.AttendedGridView.Name = "AttendedGridView";
            this.AttendedGridView.RowHeadersWidth = 51;
            this.AttendedGridView.RowTemplate.Height = 24;
            this.AttendedGridView.Size = new System.Drawing.Size(1187, 165);
            this.AttendedGridView.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 548);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Today\'s Attended Volunteers List";
            // 
            // ActiveDataGrid
            // 
            this.ActiveDataGrid.AllowUserToAddRows = false;
            this.ActiveDataGrid.AllowUserToDeleteRows = false;
            this.ActiveDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ActiveDataGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ActiveDataGrid.Location = new System.Drawing.Point(0, 388);
            this.ActiveDataGrid.Name = "ActiveDataGrid";
            this.ActiveDataGrid.RowHeadersWidth = 51;
            this.ActiveDataGrid.RowTemplate.Height = 24;
            this.ActiveDataGrid.Size = new System.Drawing.Size(1187, 160);
            this.ActiveDataGrid.TabIndex = 11;
            this.ActiveDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ActiveDataGrid_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "This Shift active volunteers";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Event Volunteers List";
            // 
            // AllVolDataGrid
            // 
            this.AllVolDataGrid.AllowUserToAddRows = false;
            this.AllVolDataGrid.AllowUserToDeleteRows = false;
            this.AllVolDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllVolDataGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AllVolDataGrid.Location = new System.Drawing.Point(0, 240);
            this.AllVolDataGrid.Name = "AllVolDataGrid";
            this.AllVolDataGrid.RowHeadersWidth = 51;
            this.AllVolDataGrid.RowTemplate.Height = 24;
            this.AllVolDataGrid.Size = new System.Drawing.Size(1187, 128);
            this.AllVolDataGrid.TabIndex = 13;
            this.AllVolDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AllVolDataGrid_CellContentClick);
            // 
            // DateLable
            // 
            this.DateLable.AutoSize = true;
            this.DateLable.BackColor = System.Drawing.Color.Transparent;
            this.DateLable.Dock = System.Windows.Forms.DockStyle.Left;
            this.DateLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLable.Location = new System.Drawing.Point(429, 0);
            this.DateLable.Name = "DateLable";
            this.DateLable.Padding = new System.Windows.Forms.Padding(20);
            this.DateLable.Size = new System.Drawing.Size(40, 65);
            this.DateLable.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(325, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(20);
            this.label5.Size = new System.Drawing.Size(104, 65);
            this.label5.TabIndex = 18;
            this.label5.Text = "Date:";
            // 
            // EventNameLable
            // 
            this.EventNameLable.AutoSize = true;
            this.EventNameLable.BackColor = System.Drawing.Color.Transparent;
            this.EventNameLable.Dock = System.Windows.Forms.DockStyle.Left;
            this.EventNameLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventNameLable.Location = new System.Drawing.Point(285, 0);
            this.EventNameLable.Margin = new System.Windows.Forms.Padding(10);
            this.EventNameLable.Name = "EventNameLable";
            this.EventNameLable.Padding = new System.Windows.Forms.Padding(20);
            this.EventNameLable.Size = new System.Drawing.Size(40, 65);
            this.EventNameLable.TabIndex = 15;
            // 
            // TitleLable
            // 
            this.TitleLable.AutoSize = true;
            this.TitleLable.BackColor = System.Drawing.Color.Transparent;
            this.TitleLable.Dock = System.Windows.Forms.DockStyle.Left;
            this.TitleLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLable.Location = new System.Drawing.Point(0, 0);
            this.TitleLable.Margin = new System.Windows.Forms.Padding(10);
            this.TitleLable.Name = "TitleLable";
            this.TitleLable.Padding = new System.Windows.Forms.Padding(20);
            this.TitleLable.Size = new System.Drawing.Size(285, 65);
            this.TitleLable.TabIndex = 16;
            this.TitleLable.Text = "You are now managing :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Saerch Active";
            // 
            // SearchActive
            // 
            this.SearchActive.Location = new System.Drawing.Point(199, 137);
            this.SearchActive.Name = "SearchActive";
            this.SearchActive.Size = new System.Drawing.Size(200, 22);
            this.SearchActive.TabIndex = 19;
            this.SearchActive.TextChanged += new System.EventHandler(this.SearchActive_TextChanged);
            // 
            // ManageEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VOL_MS.Properties.Resources.BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1187, 798);
            this.Controls.Add(this.SearchActive);
            this.Controls.Add(this.DateLable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.EventNameLable);
            this.Controls.Add(this.TitleLable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AllVolDataGrid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ActiveDataGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AttendedGridView);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Search1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageEventForm";
            this.Text = "Manage Event";
            this.Load += new System.EventHandler(this.ManageEventForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AttendedGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActiveDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllVolDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddVol;
        private System.Windows.Forms.Button CheckOutAll;
        private System.Windows.Forms.Button SaveRecords;
        private System.Windows.Forms.TextBox Search1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView AttendedGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView ActiveDataGrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView AllVolDataGrid;
        private System.Windows.Forms.Label DateLable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label EventNameLable;
        private System.Windows.Forms.Label TitleLable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox SearchActive;
        private System.Windows.Forms.Button RecoverExcel;
    }
}