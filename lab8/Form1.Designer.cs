
namespace lab8
{
    partial class arm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_buildings = new System.Windows.Forms.DataGridView();
            this.dgv_clinics = new System.Windows.Forms.DataGridView();
            this.btn_addBui = new System.Windows.Forms.Button();
            this.btn_openUsers = new System.Windows.Forms.Button();
            this.btn_delBuil = new System.Windows.Forms.Button();
            this.btn_addClinic = new System.Windows.Forms.Button();
            this.btn_delClinic = new System.Windows.Forms.Button();
            this.btn_openEmp = new System.Windows.Forms.Button();
            this.btn_openPos = new System.Windows.Forms.Button();
            this.btn_web = new System.Windows.Forms.Button();
            this.btn_find1 = new System.Windows.Forms.Button();
            this.btn_find2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_buildings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clinics)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_buildings
            // 
            this.dgv_buildings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_buildings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_buildings.Location = new System.Drawing.Point(0, 0);
            this.dgv_buildings.MultiSelect = false;
            this.dgv_buildings.Name = "dgv_buildings";
            this.dgv_buildings.RowTemplate.Height = 25;
            this.dgv_buildings.Size = new System.Drawing.Size(654, 286);
            this.dgv_buildings.TabIndex = 0;
            this.dgv_buildings.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_buildings_DataError);
            this.dgv_buildings.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_buildings_RowValidating);
            this.dgv_buildings.SelectionChanged += new System.EventHandler(this.dgv_buildings_SelectionChanged);
            this.dgv_buildings.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgv_buildings_PreviewKeyDown);
            // 
            // dgv_clinics
            // 
            this.dgv_clinics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_clinics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_clinics.Location = new System.Drawing.Point(0, 322);
            this.dgv_clinics.Name = "dgv_clinics";
            this.dgv_clinics.RowTemplate.Height = 25;
            this.dgv_clinics.Size = new System.Drawing.Size(654, 293);
            this.dgv_clinics.TabIndex = 2;
            this.dgv_clinics.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dgv_clinics.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_clinics_DataError);
            this.dgv_clinics.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_clinics_RowValidating);
            this.dgv_clinics.SelectionChanged += new System.EventHandler(this.dgv_clinics_SelectionChanged);
            // 
            // btn_addBui
            // 
            this.btn_addBui.Location = new System.Drawing.Point(0, 263);
            this.btn_addBui.Name = "btn_addBui";
            this.btn_addBui.Size = new System.Drawing.Size(136, 23);
            this.btn_addBui.TabIndex = 4;
            this.btn_addBui.Text = "Добавить здание";
            this.btn_addBui.UseVisualStyleBackColor = true;
            this.btn_addBui.Click += new System.EventHandler(this.btn_addBui_Click);
            // 
            // btn_openUsers
            // 
            this.btn_openUsers.Location = new System.Drawing.Point(338, 292);
            this.btn_openUsers.Name = "btn_openUsers";
            this.btn_openUsers.Size = new System.Drawing.Size(163, 23);
            this.btn_openUsers.TabIndex = 12;
            this.btn_openUsers.Text = "Таблица пользователей";
            this.btn_openUsers.UseVisualStyleBackColor = true;
            this.btn_openUsers.Click += new System.EventHandler(this.btn_openUsers_Click);
            // 
            // btn_delBuil
            // 
            this.btn_delBuil.Location = new System.Drawing.Point(142, 263);
            this.btn_delBuil.Name = "btn_delBuil";
            this.btn_delBuil.Size = new System.Drawing.Size(136, 23);
            this.btn_delBuil.TabIndex = 13;
            this.btn_delBuil.Text = "Удалить здание";
            this.btn_delBuil.UseVisualStyleBackColor = true;
            this.btn_delBuil.Click += new System.EventHandler(this.btn_delBuil_Click);
            // 
            // btn_addClinic
            // 
            this.btn_addClinic.Location = new System.Drawing.Point(0, 592);
            this.btn_addClinic.Name = "btn_addClinic";
            this.btn_addClinic.Size = new System.Drawing.Size(136, 23);
            this.btn_addClinic.TabIndex = 16;
            this.btn_addClinic.Text = "Добавить клинику";
            this.btn_addClinic.UseVisualStyleBackColor = true;
            this.btn_addClinic.Click += new System.EventHandler(this.btn_addClinic_Click);
            // 
            // btn_delClinic
            // 
            this.btn_delClinic.Location = new System.Drawing.Point(142, 592);
            this.btn_delClinic.Name = "btn_delClinic";
            this.btn_delClinic.Size = new System.Drawing.Size(136, 23);
            this.btn_delClinic.TabIndex = 17;
            this.btn_delClinic.Text = "Удалить клинику";
            this.btn_delClinic.UseVisualStyleBackColor = true;
            this.btn_delClinic.Click += new System.EventHandler(this.btn_delClinic_Click);
            // 
            // btn_openEmp
            // 
            this.btn_openEmp.Location = new System.Drawing.Point(0, 292);
            this.btn_openEmp.Name = "btn_openEmp";
            this.btn_openEmp.Size = new System.Drawing.Size(103, 24);
            this.btn_openEmp.TabIndex = 18;
            this.btn_openEmp.Text = "Сотрудники";
            this.btn_openEmp.UseVisualStyleBackColor = true;
            this.btn_openEmp.Click += new System.EventHandler(this.btn_openEmp_Click);
            // 
            // btn_openPos
            // 
            this.btn_openPos.Location = new System.Drawing.Point(109, 293);
            this.btn_openPos.Name = "btn_openPos";
            this.btn_openPos.Size = new System.Drawing.Size(104, 23);
            this.btn_openPos.TabIndex = 19;
            this.btn_openPos.Text = "Должности";
            this.btn_openPos.UseVisualStyleBackColor = true;
            this.btn_openPos.Click += new System.EventHandler(this.btn_openPos_Click);
            // 
            // btn_web
            // 
            this.btn_web.Location = new System.Drawing.Point(219, 293);
            this.btn_web.Name = "btn_web";
            this.btn_web.Size = new System.Drawing.Size(113, 23);
            this.btn_web.TabIndex = 20;
            this.btn_web.Text = "Трудоустройство";
            this.btn_web.UseVisualStyleBackColor = true;
            this.btn_web.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_find1
            // 
            this.btn_find1.Location = new System.Drawing.Point(507, 292);
            this.btn_find1.Name = "btn_find1";
            this.btn_find1.Size = new System.Drawing.Size(75, 23);
            this.btn_find1.TabIndex = 21;
            this.btn_find1.Text = "Поиск1";
            this.btn_find1.UseVisualStyleBackColor = true;
            this.btn_find1.Click += new System.EventHandler(this.btn_find1_Click);
            // 
            // btn_find2
            // 
            this.btn_find2.Location = new System.Drawing.Point(588, 292);
            this.btn_find2.Name = "btn_find2";
            this.btn_find2.Size = new System.Drawing.Size(75, 23);
            this.btn_find2.TabIndex = 22;
            this.btn_find2.Text = "Поиск2";
            this.btn_find2.UseVisualStyleBackColor = true;
            this.btn_find2.Click += new System.EventHandler(this.btn_find2_Click);
            // 
            // arm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 616);
            this.Controls.Add(this.btn_find2);
            this.Controls.Add(this.btn_find1);
            this.Controls.Add(this.btn_web);
            this.Controls.Add(this.btn_openPos);
            this.Controls.Add(this.btn_openEmp);
            this.Controls.Add(this.btn_delClinic);
            this.Controls.Add(this.btn_addClinic);
            this.Controls.Add(this.btn_delBuil);
            this.Controls.Add(this.btn_openUsers);
            this.Controls.Add(this.btn_addBui);
            this.Controls.Add(this.dgv_clinics);
            this.Controls.Add(this.dgv_buildings);
            this.Name = "arm";
            this.Text = "ARM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.arm_FormClosing);
            this.Load += new System.EventHandler(this.arm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_buildings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clinics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_buildings;
        private System.Windows.Forms.DataGridView dgv_clinics;
        private System.Windows.Forms.Button btn_addBui;
        private System.Windows.Forms.Button btn_openUsers;
        private System.Windows.Forms.Button btn_delBuil;
        private System.Windows.Forms.Button btn_addClinic;
        private System.Windows.Forms.Button btn_delClinic;
        private System.Windows.Forms.Button btn_openEmp;
        private System.Windows.Forms.Button btn_openPos;
        private System.Windows.Forms.Button btn_web;
        private System.Windows.Forms.Button btn_find1;
        private System.Windows.Forms.Button btn_find2;
    }
}

