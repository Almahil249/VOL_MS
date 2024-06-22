namespace VOL_MS
{
    partial class ShowDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowDataForm));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.ShowButton = new System.Windows.Forms.Button();
            this.EventsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AllEventsDataGrid = new System.Windows.Forms.DataGridView();
            this.EventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.DeleteEvent = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllEventsDataGrid)).BeginInit();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelMenu.Controls.Add(this.DeleteEvent);
            this.panelMenu.Controls.Add(this.ShowButton);
            this.panelMenu.Controls.Add(this.EventsComboBox);
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Controls.Add(this.AllEventsDataGrid);
            this.panelMenu.Controls.Add(this.panelTitle);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(281, 653);
            this.panelMenu.TabIndex = 0;
            // 
            // ShowButton
            // 
            this.ShowButton.Location = new System.Drawing.Point(17, 523);
            this.ShowButton.Name = "ShowButton";
            this.ShowButton.Size = new System.Drawing.Size(248, 41);
            this.ShowButton.TabIndex = 3;
            this.ShowButton.Text = "Show";
            this.ShowButton.UseVisualStyleBackColor = true;
            this.ShowButton.Click += new System.EventHandler(this.ShowButton_Click);
            // 
            // EventsComboBox
            // 
            this.EventsComboBox.FormattingEnabled = true;
            this.EventsComboBox.Location = new System.Drawing.Point(95, 477);
            this.EventsComboBox.Name = "EventsComboBox";
            this.EventsComboBox.Size = new System.Drawing.Size(170, 24);
            this.EventsComboBox.TabIndex = 2;
            this.EventsComboBox.SelectedIndexChanged += new System.EventHandler(this.EventsComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 480);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Event";
            // 
            // AllEventsDataGrid
            // 
            this.AllEventsDataGrid.AllowUserToAddRows = false;
            this.AllEventsDataGrid.AllowUserToDeleteRows = false;
            this.AllEventsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllEventsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EventName});
            this.AllEventsDataGrid.Location = new System.Drawing.Point(0, 89);
            this.AllEventsDataGrid.Name = "AllEventsDataGrid";
            this.AllEventsDataGrid.ReadOnly = true;
            this.AllEventsDataGrid.RowHeadersWidth = 51;
            this.AllEventsDataGrid.RowTemplate.Height = 24;
            this.AllEventsDataGrid.Size = new System.Drawing.Size(281, 351);
            this.AllEventsDataGrid.TabIndex = 1;
            // 
            // EventName
            // 
            this.EventName.HeaderText = "Event Name";
            this.EventName.MinimumWidth = 6;
            this.EventName.Name = "EventName";
            this.EventName.ReadOnly = true;
            this.EventName.Width = 125;
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(281, 83);
            this.panelTitle.TabIndex = 0;
            this.panelTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTitle_Paint);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(103, 35);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(37, 16);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "clear";
            this.labelTitle.Click += new System.EventHandler(this.labelTitle_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackgroundImage = global::VOL_MS.Properties.Resources.BG;
            this.panelContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(281, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(905, 653);
            this.panelContent.TabIndex = 1;
            // 
            // DeleteEvent
            // 
            this.DeleteEvent.BackColor = System.Drawing.Color.Red;
            this.DeleteEvent.Location = new System.Drawing.Point(17, 596);
            this.DeleteEvent.Name = "DeleteEvent";
            this.DeleteEvent.Size = new System.Drawing.Size(66, 31);
            this.DeleteEvent.TabIndex = 4;
            this.DeleteEvent.Text = "Delete Event";
            this.DeleteEvent.UseVisualStyleBackColor = false;
            this.DeleteEvent.Visible = false;
            this.DeleteEvent.Click += new System.EventHandler(this.DeleteEvent_Click);
            // 
            // ShowDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 653);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowDataForm";
            this.Text = "Show Data";
            this.Load += new System.EventHandler(this.ShowDataForm_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllEventsDataGrid)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.DataGridView AllEventsDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox EventsComboBox;
        private System.Windows.Forms.Button ShowButton;
        private System.Windows.Forms.Button DeleteEvent;
    }
}