using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8
{
    public partial class Авторизация : Form
    {
        private bool us;
        public Авторизация()
        {
            InitializeComponent();
            groupBox3.Visible = false;
            cb_role.Visible = false;
            cb_role.Enabled = false;
        }

        public Авторизация(bool fromUsers)
        {

            us = fromUsers;
            InitializeComponent();
            if(fromUsers)
            {
                btn_auth.Enabled = false;
                btn_guest.Enabled = false;
                groupBox3.Visible = true;
                cb_role.Visible = true;
                cb_role.Enabled = true;
            }
        }

        private static bool ContainsDigit(string pass)
        {
            foreach (char c in pass)
                if (char.IsDigit(c)) return true;

            return false;
        }

        private static bool ContainsLowerLetter(string pass)
        {
            foreach (char c in pass)
                if (char.IsLetter(c) && char.IsLower(c)) return true;

            return false;
        }

        private static bool ContainsUpperLetter(string pass)
        {
            foreach (char c in pass)
                if (char.IsLetter(c) && char.IsUpper(c)) return true;

            return false;
        }

        private static bool ContainsSpecialSymbols(string pass)
        {
            foreach (char c in pass)
            {
                if (char.IsPunctuation(c)) return true;
            }

            return false;
        }

        private void btn_auth_Click(object sender, EventArgs e)
        {
            using(var db=new mriContext())
            {
                var result = (from User in db.Users
                              where User.Login == tb_login.Text
                              select User).FirstOrDefault();

                if(result==null)
                {
                    MessageBox.Show("Неверный логин");
                    return;
                }

                if(BCrypt.Net.BCrypt.Verify(tb_password.Text,result.Password))
                {
                    arm arm = new arm(result.Role);
                    tb_login.Text = "";
                    tb_password.Text = "";
                    arm.ShowDialog();
                    return;
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                    return;
                }
            }
        }

        private void bth_reg_Click(object sender, EventArgs e)
        {
            using (var db = new mriContext())
            {
                var countLogins = (from User in db.Users
                                   where User.Login == tb_login.Text
                                   select User).ToList();

                if(countLogins.Count!=0)
                {
                    MessageBox.Show("Логин уже занят");
                    return;
                }

                var password = tb_password.Text;

                if (!ContainsDigit(password))
                {
                    MessageBox.Show("Пароль не содержит цифр");
                    return;
                }
                if (!ContainsUpperLetter(password))
                {
                    MessageBox.Show("Пароль не содержит букв верхнего регистра");
                    return;
                }
                if (!ContainsLowerLetter(password))
                {
                    MessageBox.Show("Пароль не содержит букв нижнего регистра");
                    return;
                }
                if (!ContainsSpecialSymbols(password))
                {
                    MessageBox.Show("Пароль не содержит специальных символов");
                    return;
                }

                var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

                User user = new User()
                {
                    Login = tb_login.Text,
                    Password = passwordHash,
                    Role = "Оператор"
                };

                if (us)
                    user.Role = cb_role.Text;

                db.Add(user);
                db.SaveChanges();
            }

            if(us)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            arm arm = new arm("Гость");
            arm.ShowDialog();
            return;
        }
    }
}
