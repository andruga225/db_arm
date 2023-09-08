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
    public partial class ChangeOrAddWork : Form
    {
        private bool edit;
        public ChangeOrAddWork()
        {
            edit = false;
            InitializeComponent();
            InitializeData();
        }

        private int clin, emp;
        private string pos;
        public ChangeOrAddWork(int clinic,int emp, string pos)
        {
            edit = true;
            this.clin = clinic;
            this.emp = emp;
            this.pos = pos;
            InitializeComponent();
            InitializeData(clinic, emp, pos);
        }

        private void InitializeData()
        {
            using(var db=new mriContext())
            {
                var result= (from Clinic in db.Clinics
                           select Clinic).ToList();

                var cData = new List<int>();

                foreach (var i in result)
                {
                    cb_clinic.Items.Add(i.ClinicName);
                    cData.Add(i.IdClinic);
                }
                cb_clinic.Tag = cData;
                cb_clinic.SelectedIndex = 0;

                var result1 = (from Position in db.Positions
                          select Position.Position1).ToList();

                cb_pos.DataSource = result1;

                var result2 = (from Employer in db.Employers
                               select Employer).ToList();

                dgv_emp.DataSource = result2;
                dgv_emp.Columns["IdEmployer"].Visible = false;
                dgv_emp.Columns["EmployerName"].HeaderText = "Имя";
                dgv_emp.Columns["EmployerSurname"].HeaderText = "Фамилия";
                dgv_emp.Columns["EmployerMiddleName"].HeaderText = "Отчество";
                dgv_emp.Columns["EmployerSex"].HeaderText = "Пол";
                dgv_emp.Columns["EmployerBirthday"].HeaderText = "Дата рождения";
                dgv_emp.Columns["EmployerExperience"].HeaderText = "Опыт";
                dgv_emp.Columns["EmpPos"].Visible = false;
                dgv_emp.Columns["MriCans"].Visible = false;
            }
        }

        private void InitializeData(int clinic, int emp, string pos)
        {
            using (var db = new mriContext())
            {
                var result = (from Clinic in db.Clinics
                              select Clinic).ToList();

                var cData = new List<int>();

                foreach (var i in result)
                {
                    cb_clinic.Items.Add(i.ClinicName);
                    cData.Add(i.IdClinic);
                }
                cb_clinic.Tag = cData;

                cb_clinic.SelectedIndex = cb_clinic.Items.IndexOf(db.Clinics.Where(a => a.IdClinic == clinic).First().ClinicName);
                                           

                var result2 = (from Position in db.Positions
                          select Position.Position1).ToList();

                cb_pos.DataSource = result2;
                cb_pos.SelectedIndex = cb_pos.Items.IndexOf(db.Positions.Where(a => a.Position1 == pos).First().Position1);
                

                var result1 = (from Employer in db.Employers
                               select Employer).ToList();

                dgv_emp.DataSource = result1;

                dgv_emp.Columns["IdEmployer"].Visible = false;
                dgv_emp.Columns["EmployerName"].HeaderText = "Имя";
                dgv_emp.Columns["EmployerSurname"].HeaderText = "Фамилия";
                dgv_emp.Columns["EmployerMiddleName"].HeaderText = "Отчество";
                dgv_emp.Columns["EmployerSex"].HeaderText = "Пол";
                dgv_emp.Columns["EmployerBirthday"].HeaderText = "Дата рождения";
                dgv_emp.Columns["EmployerExperience"].HeaderText = "Опыт";
                dgv_emp.Columns["EmpPos"].Visible = false;
                dgv_emp.Columns["MriCans"].Visible = false;

                dgv_emp.ReadOnly = false;
                dgv_emp.ClearSelection();
                dgv_emp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //for (int i = 0; i < dgv_emp.Rows.Count; ++i)
                //{
                //    if (int.Parse(dgv_emp.Rows[i].Cells["IdEmployer"].Value.ToString()) == emp)
                //    {
                //        dgv_emp.Rows[i].Selected = true
                //    }
                //}
                dgv_emp.Rows.OfType<DataGridViewRow>().Where(x => (int)x.Cells["IdEmployer"].Value == emp).ToArray<DataGridViewRow>()[0].Selected = true;
                dgv_emp.Enabled = false;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_Click_1(object sender, EventArgs e)
        {
            if (edit)
            {
                var clinic = (List<int>)cb_clinic.Tag;

                using (var db = new mriContext())
                {
                    var empToDel = db.EmpPos.Where(a => a.IdClinic == clin && a.IdEmployer == emp && a.Position == pos).FirstOrDefault();

                    if(empToDel==null)
                    {
                        MessageBox.Show("Данный работник еще не трудоустроен");
                        return;
                    }

                    EmpPo empPo = new EmpPo
                    {
                        IdClinic = clinic[cb_clinic.SelectedIndex],
                        IdEmployer = emp,
                        Position = cb_pos.Text
                    };

                    var isInDataBase = db.EmpPos.Where(a => a.IdClinic == empPo.IdClinic && a.IdEmployer == empPo.IdEmployer && a.Position == empPo.Position).FirstOrDefault();
                    if (isInDataBase != null)
                    {
                        MessageBox.Show("Этот сотрудник уже работает на данной должности в данной клинике!");
                        return;
                    }

                    db.Remove(empToDel);
                    db.SaveChanges();
                    db.Add(empPo);
                    db.SaveChanges();
                }
            }
            else
            {
                var clinic = (List<int>)cb_clinic.Tag;

                using (var db = new mriContext())
                {
                    EmpPo empPo = new EmpPo
                    {
                        IdClinic = clinic[cb_clinic.SelectedIndex],
                        IdEmployer = int.Parse(dgv_emp.CurrentRow.Cells["IdEmployer"].Value.ToString()),
                        Position = cb_pos.Text
                    };

                    var isInDataBase = db.EmpPos.Where(a => a.IdClinic == empPo.IdClinic && a.IdEmployer == empPo.IdEmployer && a.Position == empPo.Position).FirstOrDefault();
                    if (isInDataBase != null)
                    {
                        MessageBox.Show("Этот сотрудник уже работает на данной должности в данной клинике!");
                        return;
                    }

                    var IsInClinic = db.EmpPos.Where(a => a.IdClinic == empPo.IdClinic && a.IdEmployer == empPo.IdEmployer).FirstOrDefault();
                    if (IsInClinic != null)
                    {
                        MessageBox.Show("Этот сотрудник уже работет в этой клинике");
                        return;
                    }

                    db.Add(empPo);
                    db.SaveChanges();
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
