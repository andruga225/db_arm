
namespace lab8
{
    partial class PositionsForm
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
            this.dgv_position = new System.Windows.Forms.DataGridView();
            this.btn_addPos = new System.Windows.Forms.Button();
            this.btn_delPos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_position)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_position
            // 
            this.dgv_position.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_position.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_position.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_position.Location = new System.Drawing.Point(0, 0);
            this.dgv_position.Name = "dgv_position";
            this.dgv_position.RowTemplate.Height = 25;
            this.dgv_position.Size = new System.Drawing.Size(493, 408);
            this.dgv_position.TabIndex = 0;
            this.dgv_position.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_position_DataError);
            this.dgv_position.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_position_RowValidating);
            // 
            // btn_addPos
            // 
            this.btn_addPos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_addPos.Location = new System.Drawing.Point(0, 427);
            this.btn_addPos.Name = "btn_addPos";
            this.btn_addPos.Size = new System.Drawing.Size(493, 23);
            this.btn_addPos.TabIndex = 1;
            this.btn_addPos.Text = "Добавить";
            this.btn_addPos.UseVisualStyleBackColor = true;
            this.btn_addPos.Click += new System.EventHandler(this.btn_addPos_Click);
            // 
            // btn_delPos
            // 
            this.btn_delPos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_delPos.Location = new System.Drawing.Point(0, 404);
            this.btn_delPos.Name = "btn_delPos";
            this.btn_delPos.Size = new System.Drawing.Size(493, 23);
            this.btn_delPos.TabIndex = 2;
            this.btn_delPos.Text = "Удалить";
            this.btn_delPos.UseVisualStyleBackColor = true;
            this.btn_delPos.Click += new System.EventHandler(this.btn_delPos_Click);
            // 
            // PositionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 450);
            this.Controls.Add(this.btn_delPos);
            this.Controls.Add(this.btn_addPos);
            this.Controls.Add(this.dgv_position);
            this.Name = "PositionsForm";
            this.Text = "PositionsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_position)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_position;
        private System.Windows.Forms.Button btn_addPos;
        private System.Windows.Forms.Button btn_delPos;
    }
}