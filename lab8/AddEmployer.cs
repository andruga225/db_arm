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
    public partial class AddEmployer : Form
    {
        public AddEmployer()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_name.Text))
                MessageBox.Show("Заполните поле Имя");

            if (string.IsNullOrWhiteSpace(tb_surname.Text))
                MessageBox.Show("Заполните поле Фамилия");

            if (string.IsNullOrWhiteSpace(tb_middlename.Text))
                MessageBox.Show("Заполните поле Отчество");

            using(var db=new mriContext())
            {
                Employer employer = new Employer
                {
                    EmployerName = tb_name.Text,
                    EmployerSurname = tb_surname.Text,
                    EmployerMiddleName = tb_middlename.Text,
                    EmployerBirthday = dtp_birthday.Value,
                    EmployerSex = cb_sex.Text,
                    EmployerExperience = (int)num_exp.Value
                };

                db.Add(employer);
                db.SaveChanges();
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
