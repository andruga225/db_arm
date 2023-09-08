
namespace lab8
{
    partial class Авторизация
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
            this.bth_reg = new System.Windows.Forms.Button();
            this.btn_auth = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_login = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.btn_guest = new System.Windows.Forms.Button();
            this.lb_status = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cb_role = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bth_reg
            // 
            this.bth_reg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bth_reg.Location = new System.Drawing.Point(0, 280);
            this.bth_reg.Name = "bth_reg";
            this.bth_reg.Size = new System.Drawing.Size(275, 23);
            this.bth_reg.TabIndex = 0;
            this.bth_reg.Text = "Регистрация";
            this.bth_reg.UseVisualStyleBackColor = true;
            this.bth_reg.Click += new System.EventHandler(this.bth_reg_Click);
            // 
            // btn_auth
            // 
            this.btn_auth.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_auth.Location = new System.Drawing.Point(0, 257);
            this.btn_auth.Name = "btn_auth";
            this.btn_auth.Size = new System.Drawing.Size(275, 23);
            this.btn_auth.TabIndex = 1;
            this.btn_auth.Text = "Авторизация";
            this.btn_auth.UseVisualStyleBackColor = true;
            this.btn_auth.Click += new System.EventHandler(this.btn_auth_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_login);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 77);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Логин";
            // 
            // tb_login
            // 
            this.tb_login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_login.Location = new System.Drawing.Point(3, 19);
            this.tb_login.Name = "tb_login";
            this.tb_login.Size = new System.Drawing.Size(269, 23);
            this.tb_login.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_password);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 83);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Пароль";
            // 
            // tb_password
            // 
            this.tb_password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_password.Location = new System.Drawing.Point(3, 19);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(269, 23);
            this.tb_password.TabIndex = 0;
            // 
            // btn_guest
            // 
            this.btn_guest.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_guest.Location = new System.Drawing.Point(0, 234);
            this.btn_guest.Name = "btn_guest";
            this.btn_guest.Size = new System.Drawing.Size(275, 23);
            this.btn_guest.TabIndex = 5;
            this.btn_guest.Text = "Гость";
            this.btn_guest.UseVisualStyleBackColor = true;
            this.btn_guest.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_status.Location = new System.Drawing.Point(0, 219);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(0, 15);
            this.lb_status.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cb_role);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 68);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Роль";
            // 
            // cb_role
            // 
            this.cb_role.Dock = System.Windows.Forms.DockStyle.Top;
            this.cb_role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_role.FormattingEnabled = true;
            this.cb_role.Items.AddRange(new object[] {
            "Администратор",
            "Оператор"});
            this.cb_role.Location = new System.Drawing.Point(3, 19);
            this.cb_role.Name = "cb_role";
            this.cb_role.Size = new System.Drawing.Size(269, 23);
            this.cb_role.TabIndex = 0;
            // 
            // Авторизация
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 303);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.btn_guest);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_auth);
            this.Controls.Add(this.bth_reg);
            this.Name = "Авторизация";
            this.Text = "Авторизация";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bth_reg;
        private System.Windows.Forms.Button btn_auth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_login;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Button btn_guest;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cb_role;
    }
}