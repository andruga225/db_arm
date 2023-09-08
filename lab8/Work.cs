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
    public partial class Work : Form
    {
        private int id_clinic;
        public Work(int clinic, string role)
        {
            id_clinic = clinic;
            InitializeComponent();
            InitializeView(clinic);

            if(role=="Гость")
            {
                dgv_work.ReadOnly = true;
                btn_add.Enabled = false;
                btn_del.Enabled = false;
                btn_edit.Enabled = false;
            }
        }

        private void InitializeView(int clinic)
        {
            dgv_work.AutoGenerateColumns = false;
            dgv_work.Columns.Clear();

            dgv_work.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdEmployer", Name="IdEmployer" });
            dgv_work.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EmployerName", HeaderText="Имя" });
            dgv_work.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EmployerSurname", HeaderText="Фамилия" });
            dgv_work.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EmployerMiddleName", HeaderText="Отчество" });
            dgv_work.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EmployerBirthday", HeaderText="Дата рождения" });
            dgv_work.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EmployerExperience",HeaderText="Опыт" });
            dgv_work.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Position", Name="Position",HeaderText="Должность" });

            using (var db = new mriContext())
            {
                var result = (from Employer in db.Employers
                              join EmpPo in db.EmpPos on Employer.IdEmployer equals EmpPo.IdEmployer
                              where EmpPo.IdClinic==clinic
                              select new { Employer.IdEmployer,
                                    Employer.EmployerName,
                              Employer.EmployerSurname,
                              Employer.EmployerMiddleName,
                              Employer.EmployerSex,
                              Employer.EmployerBirthday,
                              Employer.EmployerExperience,
                              EmpPo.Position}).ToList();

                dgv_work.DataSource = result;

            }

            dgv_work.Columns["IdEmployer"].Visible = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            ChangeOrAddWork changeOrAddWork = new ChangeOrAddWork();
            if(changeOrAddWork.ShowDialog()==DialogResult.OK)
            {
                InitializeView(id_clinic);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            ChangeOrAddWork changeOrAddWork = new ChangeOrAddWork(id_clinic,
                int.Parse(dgv_work.CurrentRow.Cells["IdEmployer"].Value.ToString()),
                dgv_work.CurrentRow.Cells["Position"].Value.ToString());
            if(changeOrAddWork.ShowDialog()==DialogResult.OK)
            {
                InitializeView(id_clinic);
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            var id_to_del = (int?)dgv_work.CurrentRow.Index;
            if(id_to_del.HasValue)
            {
                int id_emp = (int)dgv_work.CurrentRow.Cells["IdEmployer"].Value;
                string pos = (string)dgv_work.CurrentRow.Cells["Position"].Value;

                using(var db=new mriContext())
                {
                    var to_del = db.EmpPos.Where(a => a.IdClinic == id_clinic && a.IdEmployer == id_emp && a.Position == pos).First();

                    db.Remove(to_del);
                    dgv_work.DataSource = null;
                    db.SaveChanges();
                }
            }

            InitializeView(id_clinic);
        }
    }
}
