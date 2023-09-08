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
    public partial class EmployersForm : Form
    {
        public EmployersForm(string role)
        {
            InitializeComponent();
            InitializeEmployers();

            dvg_employers.ReadOnly = false;
            btn_addEmp.Enabled = true;
            btn_delEmp.Enabled = true;

            if (role=="Гость")
            {
                dvg_employers.ReadOnly = true;
                btn_addEmp.Enabled = false;
                btn_delEmp.Enabled = false;
            }
        }

        private void InitializeEmployers()
        {
            using (var db = new mriContext())
            {
                var result = (from Employer in db.Employers
                              select Employer).ToList();

                //dvg_employers.ReadOnly = false;
                dvg_employers.DataSource = result;
                dvg_employers.Columns["IdEmployer"].Visible = false;
                dvg_employers.Columns["EmployerName"].HeaderText = "Имя";
                dvg_employers.Columns["EmployerSurname"].HeaderText = "Фамилия";
                dvg_employers.Columns["EmployerMiddleName"].HeaderText = "Отчество";
                dvg_employers.Columns["EmployerSex"].HeaderText = "Пол";
                dvg_employers.Columns["EmployerBirthday"].HeaderText = "Дата рождения";
                dvg_employers.Columns["EmployerExperience"].HeaderText = "Опыт";
                dvg_employers.Columns["EmpPos"].Visible = false;
                dvg_employers.Columns["MriCans"].Visible = false;

            }
        }

        private void btn_addEmp_Click(object sender, EventArgs e)
        {
            AddEmployer employer = new AddEmployer();
            if (employer.ShowDialog() == DialogResult.OK)
                InitializeEmployers();
        }

        private void btn_delEmp_Click(object sender, EventArgs e)
        {
            var id_del_emp = (int?)dvg_employers.CurrentRow.Index;
            if (id_del_emp.HasValue)
            {
                int id = (int)dvg_employers.CurrentRow.Cells["IdEmployer"].Value;

                using (var db = new mriContext())
                {
                    var emp_to_del = db.Employers.Where(a => a.IdEmployer == id).First();

                    db.Remove(emp_to_del);
                    dvg_employers.DataSource = null;
                    db.SaveChanges();
                }
            }

            InitializeEmployers();
        }

        private void dvg_employers_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var eId = (int)dvg_employers.Rows[e.RowIndex].Cells["IdEmployer"].Value;

            foreach (var i in new[] { "EmployerName", "EmployerSurname", "EmployerMiddleName", "EmployerSex", "EmployerExperience", "EmployerBirthday" })
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(dvg_employers.Rows[e.RowIndex].Cells[i].Value.ToString()))
                    {
                        dvg_employers.Rows[e.RowIndex].ErrorText = $"Значение в столбце '{dvg_employers.Rows[e.RowIndex].Cells[i].OwningColumn.HeaderText}' не должно быть пустым";
                        e.Cancel = true;
                    }
                }
                catch
                {
                    dvg_employers.Rows[e.RowIndex].ErrorText = $"Значение в столбце '{dvg_employers.Rows[e.RowIndex].Cells[i].OwningColumn.HeaderText}' не должно быть пустым";
                    e.Cancel = true;
                }
            }

            if (dvg_employers.Rows[e.RowIndex].Cells["EmployerSex"].Value.ToString() != "Мужской" &&
                dvg_employers.Rows[e.RowIndex].Cells["EmployerSex"].Value.ToString() != "Женский")
            {
                dvg_employers.Rows[e.RowIndex].ErrorText = $"Значение в столбце Пол должно быть: Мужской, Женский";
                e.Cancel = true;
            }

            if (e.Cancel)
                return;

            using (var db = new mriContext())
            {
                var new_emp = new Employer()
                {
                    IdEmployer = eId,
                    EmployerName = dvg_employers.Rows[e.RowIndex].Cells["EmployerName"].Value.ToString(),
                    EmployerSurname = dvg_employers.Rows[e.RowIndex].Cells["EmployerSurname"].Value.ToString(),
                    EmployerMiddleName = dvg_employers.Rows[e.RowIndex].Cells["EmployerMiddleName"].Value.ToString(),
                    EmployerSex = dvg_employers.Rows[e.RowIndex].Cells["EmployerSex"].Value.ToString(),
                    EmployerBirthday = (DateTime)dvg_employers.Rows[e.RowIndex].Cells["EmployerBirthday"].Value,
                    EmployerExperience = int.Parse(dvg_employers.Rows[e.RowIndex].Cells["EmployerExperience"].Value.ToString())
                };

                db.Update(new_emp);
                db.SaveChanges();

            }

            dvg_employers.Rows[e.RowIndex].ErrorText = "";
        }

        private void dvg_employers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == dvg_employers.Columns["EmployerExperience"].Index)
                dvg_employers.Rows[e.RowIndex].ErrorText = $"Значение в поле Опыт должно быть целочисленным";
            if (e.ColumnIndex == dvg_employers.Columns["EmployerBirthday"].Index)
                dvg_employers.Rows[e.RowIndex].ErrorText = $"Неверная дата";
        }
    }

    
}
