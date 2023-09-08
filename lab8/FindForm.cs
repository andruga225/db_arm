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
    public partial class FindForm : Form
    {
        public FindForm(string find)
        {
            InitializeComponent();
            InitializeView(find);
        }

        private void InitializeView(string find)
        {
            if(find=="find1")
            {
                using(var db=new mriContext())
                {
                    var result = (from Employer in db.Employers
                                  join EmpPo in db.EmpPos on Employer.IdEmployer equals EmpPo.IdEmployer
                                  where EmpPo.Position == "Врач-радиолог"
                                  select Employer).ToList();

                    dgv_find.DataSource = result;
                    dgv_find.Columns["IdEmployer"].Visible = false;
                    dgv_find.Columns["EmployerName"].HeaderText = "Имя";
                    dgv_find.Columns["EmployerSurname"].HeaderText = "Фамилия";
                    dgv_find.Columns["EmployerMiddleName"].HeaderText = "Отчество";
                    dgv_find.Columns["EmployerSex"].HeaderText = "Пол";
                    dgv_find.Columns["EmployerBirthday"].HeaderText = "Дата рождения";
                    dgv_find.Columns["EmployerExperience"].HeaderText = "Опыт";
                    dgv_find.Columns["EmpPos"].Visible = false;
                    dgv_find.Columns["MriCans"].Visible = false;
                    dgv_find.ReadOnly = true;
                }
            }

            if(find=="find2")
            {
                using(var db=new mriContext())
                {
                    var result = (from Clinic in db.Clinics
                                  where Clinic.ClinicFinance == "Государственное"
                                  select Clinic).ToList();

                    dgv_find.DataSource = result;
                    dgv_find.Columns["IdClinic"].Visible = false;
                    dgv_find.Columns["ClinicName"].HeaderText = "Название клиники";
                    dgv_find.Columns["ClinicFinance"].HeaderText = "Тип финансирования";
                    dgv_find.Columns["ClinicEmployers"].HeaderText = "Кол-во сотрудников";
                    dgv_find.Columns["IdBuilding"].Visible = false;
                    dgv_find.Columns["IdBuildingNavigation"].Visible = false;
                    dgv_find.Columns["EmpPos"].Visible = false;
                    dgv_find.Columns["MriMachines"].Visible = false;
                    dgv_find.ReadOnly = true;

                }
            }
        }
    }
}
