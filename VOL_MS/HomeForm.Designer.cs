namespace VOL_MS
{
    partial class HomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.EventName = new System.Windows.Forms.DataGridViewButtonColumn();
            this.RegesterdVolunteers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcitiveVolunteers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statLable = new System.Windows.Forms.Label();
            this.resultLable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EventName,
            this.RegesterdVolunteers,
            this.AcitiveVolunteers});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(0, 232);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(800, 218);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // EventName
            // 
            this.EventName.HeaderText = "Event Name";
            this.EventName.MinimumWidth = 6;
            this.EventName.Name = "EventName";
            this.EventName.ReadOnly = true;
            this.EventName.Width = 125;
            // 
            // RegesterdVolunteers
            // 
            this.RegesterdVolunteers.HeaderText = "Regesterd Volunteers";
            this.RegesterdVolunteers.MinimumWidth = 6;
            this.RegesterdVolunteers.Name = "RegesterdVolunteers";
            this.RegesterdVolunteers.ReadOnly = true;
            this.RegesterdVolunteers.Width = 125;
            // 
            // AcitiveVolunteers
            // 
            this.AcitiveVolunteers.HeaderText = "Acitive Volunteers";
            this.AcitiveVolunteers.MinimumWidth = 6;
            this.AcitiveVolunteers.Name = "AcitiveVolunteers";
            this.AcitiveVolunteers.ReadOnly = true;
            this.AcitiveVolunteers.Width = 125;
            // 
            // statLable
            // 
            this.statLable.AutoSize = true;
            this.statLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statLable.Location = new System.Drawing.Point(29, 63);
            this.statLable.Name = "statLable";
            this.statLable.Size = new System.Drawing.Size(314, 20);
            this.statLable.TabIndex = 1;
            this.statLable.Text = "Number Of Events in the Database :";
            // 
            // resultLable
            // 
            this.resultLable.AutoSize = true;
            this.resultLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLable.Location = new System.Drawing.Point(387, 63);
            this.resultLable.Name = "resultLable";
            this.resultLable.Size = new System.Drawing.Size(0, 20);
            this.resultLable.TabIndex = 1;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VOL_MS.Properties.Resources.BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.resultLable);
            this.Controls.Add(this.statLable);
            this.Controls.Add(this.dataGridView);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HomeForm";
            this.Text = "Home Form";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewButtonColumn EventName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegesterdVolunteers;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcitiveVolunteers;
        private System.Windows.Forms.Label statLable;
        private System.Windows.Forms.Label resultLable;
    }
}