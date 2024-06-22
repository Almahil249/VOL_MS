namespace VOL_MS
{
    partial class AddVolunteerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddVolunteerForm));
            this.NameBox = new System.Windows.Forms.TextBox();
            this.PhoneBox = new System.Windows.Forms.TextBox();
            this.V_IDBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.eventNameLable = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(121, 92);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(270, 22);
            this.NameBox.TabIndex = 0;
            // 
            // PhoneBox
            // 
            this.PhoneBox.Location = new System.Drawing.Point(121, 135);
            this.PhoneBox.Name = "PhoneBox";
            this.PhoneBox.Size = new System.Drawing.Size(270, 22);
            this.PhoneBox.TabIndex = 2;
            // 
            // V_IDBox
            // 
            this.V_IDBox.Location = new System.Drawing.Point(122, 176);
            this.V_IDBox.Name = "V_IDBox";
            this.V_IDBox.Size = new System.Drawing.Size(269, 22);
            this.V_IDBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Add New Volunteer To The ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Phone : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "V_ID :";
            // 
            // eventNameLable
            // 
            this.eventNameLable.AutoSize = true;
            this.eventNameLable.BackColor = System.Drawing.Color.White;
            this.eventNameLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventNameLable.Location = new System.Drawing.Point(323, 35);
            this.eventNameLable.Name = "eventNameLable";
            this.eventNameLable.Size = new System.Drawing.Size(0, 20);
            this.eventNameLable.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddButton.ForeColor = System.Drawing.Color.Black;
            this.AddButton.Location = new System.Drawing.Point(198, 297);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(136, 28);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AddVolunteerForm
            // 
            this.AcceptButton = this.AddButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VOL_MS.Properties.Resources.BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(691, 439);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.V_IDBox);
            this.Controls.Add(this.PhoneBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.eventNameLable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddVolunteerForm";
            this.Text = "Add New Volunteer";
            this.Load += new System.EventHandler(this.AddVolunteerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox PhoneBox;
        private System.Windows.Forms.TextBox V_IDBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label eventNameLable;
        private System.Windows.Forms.Button AddButton;
    }
}