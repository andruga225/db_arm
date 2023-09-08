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
    public partial class UserdDGV : Form
    {
        private enum Roles { Администратор, Оператор };
        public UserdDGV()
        {
            InitializeComponent();
            InitializeUsers();
        }

        private void InitializeUsers()
        {
            using(var db=new mriContext())
            {
                var result=(from User in db.Users
                           select User).ToList();

                dgv_users.DataSource = result;
                dgv_users.Columns["Id"].Visible = false;
                dgv_users.Columns["Login"].HeaderText = "Логин";
                dgv_users.Columns["Password"].Visible = false;
                dgv_users.Columns["Role"].HeaderText = "Роль";
            }
        }

        private void dgv_users_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            int uId = (int)dgv_users.Rows[e.RowIndex].Cells["Id"].Value;

            foreach(var i in new[] { "Login","Role"})
            {
                if (string.IsNullOrWhiteSpace(dgv_users.Rows[e.RowIndex].Cells[i].Value.ToString()))
                {
                    dgv_users.Rows[e.RowIndex].ErrorText = $"Значение в столбце '{dgv_users.Rows[e.RowIndex].Cells[i].OwningColumn.HeaderText}' не должно быть пустым";
                    e.Cancel = true;
                }
            }

            if (e.Cancel)
                return;

            var r= Enum.GetNames(typeof(Roles)).ToList();
            if (!r.Contains(dgv_users.Rows[e.RowIndex].Cells["Role"].Value))
            {
                dgv_users.Rows[e.RowIndex].ErrorText = $"Введенная роль не существует";
                e.Cancel = true;
            }

            if (e.Cancel)
                return;

            using(var db=new mriContext())
            {
                User user = new User
                {
                    Id = (int)dgv_users.Rows[e.RowIndex].Cells["Id"].Value,
                    Login = dgv_users.Rows[e.RowIndex].Cells["Login"].Value.ToString(),
                    Password = dgv_users.Rows[e.RowIndex].Cells["Password"].Value.ToString(),
                    Role = dgv_users.Rows[e.RowIndex].Cells["Role"].Value.ToString()
                };

                db.Update(user);
                db.SaveChanges();
            }

            dgv_users.Rows[e.RowIndex].ErrorText = "";
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            var id_to_del = (int?)dgv_users.CurrentRow.Cells["Id"].Value;

            if(id_to_del.HasValue)
            {
                int id = (int)dgv_users.CurrentRow.Cells["Id"].Value;

                using(var db=new mriContext())
                {
                    var user = db.Users.Where(a => a.Id == id).First();

                    db.Remove(user);
                    dgv_users.DataSource = null;
                    db.SaveChanges();
                }
            }

            InitializeUsers();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Авторизация авторизация = new Авторизация(true);
            if (авторизация.ShowDialog() == DialogResult.OK)
                InitializeUsers();
        }
    }
}
