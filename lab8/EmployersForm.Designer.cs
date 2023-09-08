
namespace lab8
{
    partial class EmployersForm
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
            this.dvg_employers = new System.Windows.Forms.DataGridView();
            this.btn_delEmp = new System.Windows.Forms.Button();
            this.btn_addEmp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_employers)).BeginInit();
            this.SuspendLayout();
            // 
            // dvg_employers
            // 
            this.dvg_employers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvg_employers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvg_employers.Dock = System.Windows.Forms.DockStyle.Top;
            this.dvg_employers.Location = new System.Drawing.Point(0, 0);
            this.dvg_employers.Name = "dvg_employers";
            this.dvg_employers.RowTemplate.Height = 25;
            this.dvg_employers.Size = new System.Drawing.Size(800, 408);
            this.dvg_employers.TabIndex = 0;
            this.dvg_employers.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dvg_employers_DataError);
            this.dvg_employers.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dvg_employers_RowValidating);
            // 
            // btn_delEmp
            // 
            this.btn_delEmp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_delEmp.Location = new System.Drawing.Point(0, 427);
            this.btn_delEmp.Name = "btn_delEmp";
            this.btn_delEmp.Size = new System.Drawing.Size(800, 23);
            this.btn_delEmp.TabIndex = 1;
            this.btn_delEmp.Text = "Удалить";
            this.btn_delEmp.UseVisualStyleBackColor = true;
            this.btn_delEmp.Click += new System.EventHandler(this.btn_delEmp_Click);
            // 
            // btn_addEmp
            // 
            this.btn_addEmp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_addEmp.Location = new System.Drawing.Point(0, 404);
            this.btn_addEmp.Name = "btn_addEmp";
            this.btn_addEmp.Size = new System.Drawing.Size(800, 23);
            this.btn_addEmp.TabIndex = 2;
            this.btn_addEmp.Text = "Добавить";
            this.btn_addEmp.UseVisualStyleBackColor = true;
            this.btn_addEmp.Click += new System.EventHandler(this.btn_addEmp_Click);
            // 
            // EmployersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_addEmp);
            this.Controls.Add(this.btn_delEmp);
            this.Controls.Add(this.dvg_employers);
            this.Name = "EmployersForm";
            this.Text = "EmployersForm";
            ((System.ComponentModel.ISupportInitialize)(this.dvg_employers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvg_employers;
        private System.Windows.Forms.Button btn_delEmp;
        private System.Windows.Forms.Button btn_addEmp;
    }
}