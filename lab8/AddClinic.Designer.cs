
namespace lab8
{
    partial class AddClinic
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_clinicName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_finance = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.num_emp = new System.Windows.Forms.NumericUpDown();
            this.btn_add = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_emp)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_clinicName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Название клиники";
            // 
            // tb_clinicName
            // 
            this.tb_clinicName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_clinicName.Location = new System.Drawing.Point(3, 19);
            this.tb_clinicName.Name = "tb_clinicName";
            this.tb_clinicName.Size = new System.Drawing.Size(308, 23);
            this.tb_clinicName.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_finance);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 74);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Тип финансирования";
            // 
            // cb_finance
            // 
            this.cb_finance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_finance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_finance.FormattingEnabled = true;
            this.cb_finance.Items.AddRange(new object[] {
            "Государственное",
            "Частное"});
            this.cb_finance.Location = new System.Drawing.Point(3, 19);
            this.cb_finance.Name = "cb_finance";
            this.cb_finance.Size = new System.Drawing.Size(308, 23);
            this.cb_finance.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.num_emp);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(314, 68);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Количество сотрудников";
            // 
            // num_emp
            // 
            this.num_emp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_emp.Location = new System.Drawing.Point(3, 19);
            this.num_emp.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_emp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_emp.Name = "num_emp";
            this.num_emp.Size = new System.Drawing.Size(308, 23);
            this.num_emp.TabIndex = 0;
            this.num_emp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_add
            // 
            this.btn_add.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_add.Location = new System.Drawing.Point(0, 335);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(314, 23);
            this.btn_add.TabIndex = 3;
            this.btn_add.Text = "Добавить";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // AddClinic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 358);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddClinic";
            this.Text = "AddClinic";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_emp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_clinicName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cb_finance;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown num_emp;
        private System.Windows.Forms.Button btn_add;
    }
}