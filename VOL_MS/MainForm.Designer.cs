namespace VOL_MS
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.EventsComboBox = new System.Windows.Forms.ComboBox();
            this.LogOut = new System.Windows.Forms.Button();
            this.buttonManageEvents = new System.Windows.Forms.Button();
            this.buttonAddEvent = new System.Windows.Forms.Button();
            this.buttonShowData = new System.Windows.Forms.Button();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Controls.Add(this.EventsComboBox);
            this.panelMenu.Controls.Add(this.LogOut);
            this.panelMenu.Controls.Add(this.buttonManageEvents);
            this.panelMenu.Controls.Add(this.buttonAddEvent);
            this.panelMenu.Controls.Add(this.buttonShowData);
            this.panelMenu.Controls.Add(this.panelTitle);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(167, 866);
            this.panelMenu.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 750);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select Event";
            // 
            // EventsComboBox
            // 
            this.EventsComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EventsComboBox.FormattingEnabled = true;
            this.EventsComboBox.Location = new System.Drawing.Point(0, 772);
            this.EventsComboBox.Name = "EventsComboBox";
            this.EventsComboBox.Size = new System.Drawing.Size(167, 24);
            this.EventsComboBox.TabIndex = 6;
            // 
            // LogOut
            // 
            this.LogOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.LogOut.Location = new System.Drawing.Point(0, 175);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(167, 46);
            this.LogOut.TabIndex = 5;
            this.LogOut.Text = "LOG OUT";
            this.LogOut.UseVisualStyleBackColor = true;
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // buttonManageEvents
            // 
            this.buttonManageEvents.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonManageEvents.Location = new System.Drawing.Point(0, 796);
            this.buttonManageEvents.Name = "buttonManageEvents";
            this.buttonManageEvents.Size = new System.Drawing.Size(167, 70);
            this.buttonManageEvents.TabIndex = 4;
            this.buttonManageEvents.Text = "Manage Events";
            this.buttonManageEvents.UseVisualStyleBackColor = true;
            this.buttonManageEvents.Click += new System.EventHandler(this.buttonManageEvents_Click);
            // 
            // buttonAddEvent
            // 
            this.buttonAddEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAddEvent.Location = new System.Drawing.Point(0, 129);
            this.buttonAddEvent.Name = "buttonAddEvent";
            this.buttonAddEvent.Size = new System.Drawing.Size(167, 46);
            this.buttonAddEvent.TabIndex = 2;
            this.buttonAddEvent.Text = "Add Event";
            this.buttonAddEvent.UseVisualStyleBackColor = true;
            this.buttonAddEvent.Click += new System.EventHandler(this.buttonAddEvent_Click);
            // 
            // buttonShowData
            // 
            this.buttonShowData.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonShowData.Location = new System.Drawing.Point(0, 83);
            this.buttonShowData.Name = "buttonShowData";
            this.buttonShowData.Size = new System.Drawing.Size(167, 46);
            this.buttonShowData.TabIndex = 1;
            this.buttonShowData.Text = "Show All Data";
            this.buttonShowData.UseVisualStyleBackColor = true;
            this.buttonShowData.Click += new System.EventHandler(this.buttonShowData_Click);
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(167, 83);
            this.panelTitle.TabIndex = 0;
            this.panelTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTitle_Paint);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 33);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(122, 22);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Admin Panel";
            this.labelTitle.Click += new System.EventHandler(this.labelTitle_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackgroundImage = global::VOL_MS.Properties.Resources.BG;
            this.panelContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(167, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1392, 866);
            this.panelContent.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1559, 866);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonShowData;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonManageEvents;
        private System.Windows.Forms.Button buttonAddEvent;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button LogOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox EventsComboBox;
    }
}