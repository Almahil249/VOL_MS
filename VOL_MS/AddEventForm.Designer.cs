namespace VOL_MS
{
    partial class AddEventForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.resultDataGrid = new System.Windows.Forms.DataGridView();
            this.EventName = new System.Windows.Forms.TextBox();
            this.EventNameLabel = new System.Windows.Forms.Label();
            this.AddEventButton = new System.Windows.Forms.Button();
            this.SelectExcel = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // resultDataGrid
            // 
            this.resultDataGrid.AllowUserToAddRows = false;
            this.resultDataGrid.AllowUserToDeleteRows = false;
            this.resultDataGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.NullValue = "-";
            this.resultDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.resultDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.resultDataGrid.ColumnHeadersHeight = 29;
            this.resultDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.resultDataGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.resultDataGrid.Location = new System.Drawing.Point(0, 250);
            this.resultDataGrid.Name = "resultDataGrid";
            this.resultDataGrid.ReadOnly = true;
            this.resultDataGrid.RowHeadersVisible = false;
            this.resultDataGrid.RowHeadersWidth = 51;
            this.resultDataGrid.RowTemplate.Height = 24;
            this.resultDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultDataGrid.Size = new System.Drawing.Size(817, 175);
            this.resultDataGrid.TabIndex = 0;
            // 
            // EventName
            // 
            this.EventName.Location = new System.Drawing.Point(12, 117);
            this.EventName.Name = "EventName";
            this.EventName.Size = new System.Drawing.Size(191, 22);
            this.EventName.TabIndex = 1;
            // 
            // EventNameLabel
            // 
            this.EventNameLabel.AutoSize = true;
            this.EventNameLabel.BackColor = System.Drawing.Color.White;
            this.EventNameLabel.Font = new System.Drawing.Font("Aldhabi", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.EventNameLabel.Location = new System.Drawing.Point(9, 83);
            this.EventNameLabel.Name = "EventNameLabel";
            this.EventNameLabel.Size = new System.Drawing.Size(90, 31);
            this.EventNameLabel.TabIndex = 2;
            this.EventNameLabel.Text = "Event Name";
            // 
            // AddEventButton
            // 
            this.AddEventButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.AddEventButton.Location = new System.Drawing.Point(12, 153);
            this.AddEventButton.Name = "AddEventButton";
            this.AddEventButton.Size = new System.Drawing.Size(127, 40);
            this.AddEventButton.TabIndex = 3;
            this.AddEventButton.Text = "Add Event";
            this.AddEventButton.UseVisualStyleBackColor = false;
            this.AddEventButton.Click += new System.EventHandler(this.AddEventButton_Click);
            // 
            // SelectExcel
            // 
            this.SelectExcel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SelectExcel.Location = new System.Drawing.Point(12, 23);
            this.SelectExcel.Name = "SelectExcel";
            this.SelectExcel.Size = new System.Drawing.Size(127, 40);
            this.SelectExcel.TabIndex = 3;
            this.SelectExcel.Text = "Select Excel File";
            this.SelectExcel.UseVisualStyleBackColor = false;
            this.SelectExcel.Click += new System.EventHandler(this.SelectExcel_Click);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Name";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 73;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "V_ID ";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 68;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.HeaderText = "phone";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 180;
            // 
            // AddEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VOL_MS.Properties.Resources.BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(817, 425);
            this.Controls.Add(this.SelectExcel);
            this.Controls.Add(this.AddEventButton);
            this.Controls.Add(this.EventNameLabel);
            this.Controls.Add(this.EventName);
            this.Controls.Add(this.resultDataGrid);
            this.DoubleBuffered = true;
            this.Name = "AddEventForm";
            this.Text = "Add Event";
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView resultDataGrid;
        private System.Windows.Forms.TextBox EventName;
        private System.Windows.Forms.Label EventNameLabel;
        private System.Windows.Forms.Button AddEventButton;
        private System.Windows.Forms.Button SelectExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}