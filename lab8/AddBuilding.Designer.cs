
namespace lab8
{
    partial class AddBuilding
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
            this.tb_address = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_builType = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.num_builFloor = new System.Windows.Forms.NumericUpDown();
            this.btn_add = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_builFloor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_address);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Адрес";
            // 
            // tb_address
            // 
            this.tb_address.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_address.Location = new System.Drawing.Point(3, 19);
            this.tb_address.Name = "tb_address";
            this.tb_address.Size = new System.Drawing.Size(276, 23);
            this.tb_address.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_builType);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 81);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Тип здания";
            // 
            // cb_builType
            // 
            this.cb_builType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_builType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_builType.FormattingEnabled = true;
            this.cb_builType.Items.AddRange(new object[] {
            "Жилое",
            "Нежилое"});
            this.cb_builType.Location = new System.Drawing.Point(3, 19);
            this.cb_builType.Name = "cb_builType";
            this.cb_builType.Size = new System.Drawing.Size(276, 23);
            this.cb_builType.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.num_builFloor);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 155);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(282, 86);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Количество этажей";
            // 
            // num_builFloor
            // 
            this.num_builFloor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_builFloor.Location = new System.Drawing.Point(3, 19);
            this.num_builFloor.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_builFloor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_builFloor.Name = "num_builFloor";
            this.num_builFloor.Size = new System.Drawing.Size(276, 23);
            this.num_builFloor.TabIndex = 0;
            this.num_builFloor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_add
            // 
            this.btn_add.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_add.Location = new System.Drawing.Point(0, 325);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(282, 23);
            this.btn_add.TabIndex = 3;
            this.btn_add.Text = "Добавить";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // AddBuilding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 348);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddBuilding";
            this.Text = "AddBuilding";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_builFloor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_address;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cb_builType;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown num_builFloor;
        private System.Windows.Forms.Button btn_add;
    }
}