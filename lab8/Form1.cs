using DataGridViewExample;
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
    public partial class arm : Form
    {
        private enum sex { Мужской, Женский};
        private string role;
        public arm(string role)
        {
            this.role = role;
            InitializeComponent();
            MuteButtons(role);
            InitializeBuildings();
        }

        private void MuteButtons(string role)
        {
            btn_addBui.Enabled = true;
            btn_delBuil.Enabled = true;
            btn_addClinic.Enabled = true;
            btn_delClinic.Enabled = true;
            btn_openUsers.Enabled = true;
            dgv_buildings.ReadOnly = false;
            dgv_clinics.ReadOnly = false;

            if (role=="Оператор")
            {
                btn_openUsers.Enabled = false;
            }

            if (role == "Гость")
            {
                btn_addBui.Enabled = false;
                btn_delBuil.Enabled = false;
                btn_addClinic.Enabled = false;
                btn_delClinic.Enabled = false;
                btn_openUsers.Enabled = false;
                dgv_buildings.ReadOnly = true;
                dgv_clinics.ReadOnly = true;
            }
        }

        private void InitializeBuildings()
        {
            using (var db = new mriContext())
            {

                var result = (from Building in db.Buildings select Building).ToList();
                dgv_buildings.DataSource = result;
                dgv_buildings.Columns["IdBuilding"].Visible = false;
                dgv_buildings.Columns["BuildingAddress"].HeaderText = "Адрес здания";
                dgv_buildings.Columns["BuildingType"].HeaderText = "Тип здания";
                dgv_buildings.Columns["BuildingFloors"].HeaderText = "Количество этажей";
                dgv_buildings.Columns["Clinics"].Visible = false;

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_buildings_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            dgv_clinics.Enabled = false;

            var bID = (int)dgv_buildings.Rows[e.RowIndex].Cells["IdBuilding"].Value;

            foreach (var i in new[] { "BuildingAddress", "BuildingType", "BuildingFloors" })
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(dgv_buildings.Rows[e.RowIndex].Cells[i].Value.ToString()))
                    {
                        dgv_buildings.Rows[e.RowIndex].ErrorText = $"Значение в столбце '{dgv_buildings.Rows[e.RowIndex].Cells[i].OwningColumn.HeaderText}' не должно быть пустым";
                        e.Cancel = true;
                    }

                }
                catch
                {
                    dgv_buildings.Rows[e.RowIndex].ErrorText = $"Значение в столбце '{dgv_buildings.Rows[e.RowIndex].Cells[i].OwningColumn.HeaderText}' не должно быть пустым";
                    e.Cancel = true;
                }
            }

            if (dgv_buildings.Rows[e.RowIndex].Cells["BuildingType"].Value.ToString() != "Жилое" &&
                dgv_buildings.Rows[e.RowIndex].Cells["BuildingType"].Value.ToString() != "Нежилое")
            {
                dgv_buildings.Rows[e.RowIndex].ErrorText = $"Значение в столбце Тип здания должно быть: жилое, нежилое";
                e.Cancel = true;

            }

            if (e.Cancel)
                return;

            using (var db = new mriContext())
            {
                var new_build = new Building()
                {
                    IdBuilding = bID,
                    BuildingAddress = dgv_buildings.Rows[e.RowIndex].Cells["BuildingAddress"].Value.ToString(),
                    BuildingType = dgv_buildings.Rows[e.RowIndex].Cells["BuildingType"].Value.ToString(),
                    BuildingFloors = int.Parse(dgv_buildings.Rows[e.RowIndex].Cells["BuildingFloors"].Value.ToString())
                };


                db.Update(new_build);
                db.SaveChanges();
            }

            dgv_buildings.Rows[e.RowIndex].ErrorText = "";
            dgv_clinics.Enabled = true;
        }

        private void btn_delBuil_Click(object sender, EventArgs e)
        {
            var id_del_build = (int?)dgv_buildings.CurrentRow.Index;
            if (id_del_build.HasValue)
            {
                int id = (int)dgv_buildings.CurrentRow.Cells["IdBuilding"].Value;
                using (var db = new mriContext())
                {
                    var buil_to_del = db.Buildings.Where(a => a.IdBuilding == id).First();

                    db.Remove(buil_to_del);
                    dgv_buildings.DataSource = null;
                    db.SaveChanges();

                }
            }

            InitializeBuildings();
        }

        private void btn_addBui_Click(object sender, EventArgs e)
        {
            AddBuilding building = new AddBuilding();
            if(building.ShowDialog()==DialogResult.OK)
                InitializeBuildings();
        }

        private void dgv_buildings_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dgv_clinics.Enabled = false;
            dgv_buildings.Rows[e.RowIndex].ErrorText = $"Значение в столбце Количество этажей должно быть целочисленным";
            
        }

        private void InitializeClinics(int bui_id)
        {
            using(var db=new mriContext())
            {
                var result = (from Clinic in db.Clinics
                             where Clinic.IdBuilding == bui_id
                             select Clinic).ToList();

                dgv_clinics.DataSource = result;
                dgv_clinics.Columns["IdClinic"].Visible = false;
                dgv_clinics.Columns["ClinicName"].HeaderText = "Название клиники";
                dgv_clinics.Columns["ClinicFinance"].HeaderText = "Тип финансирования";
                dgv_clinics.Columns["ClinicEmployers"].HeaderText = "Кол-во сотрудников";
                dgv_clinics.Columns["IdBuilding"].Visible = false;
                dgv_clinics.Columns["IdBuildingNavigation"].Visible = false;
                dgv_clinics.Columns["EmpPos"].Visible = false;
                dgv_clinics.Columns["MriMachines"].Visible = false;
            }
        }

        private void dgv_buildings_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_buildings.SelectedCells.Count != 0)
                InitializeClinics((int)dgv_buildings.CurrentRow.Cells["IdBuilding"].Value);
            else
                InitializeClinics(-1);
  
        }

        private void dgv_clinics_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {

            var cId = (int)dgv_clinics.Rows[e.RowIndex].Cells["IdClinic"].Value;

            foreach(var i in new[] {"ClinicName","ClinicFinance","ClinicEmployers"})
            {
                try
                {
                    if(string.IsNullOrWhiteSpace(dgv_clinics.Rows[e.RowIndex].Cells[i].Value.ToString()))
                    {
                        dgv_clinics.Rows[e.RowIndex].ErrorText = $"Значение в столбце '{dgv_clinics.Rows[e.RowIndex].Cells[i].OwningColumn.HeaderText}' не должно быть пустым";
                        e.Cancel = true;
                    }
                }
                catch
                {
                    dgv_clinics.Rows[e.RowIndex].ErrorText = $"Значение в столбце '{dgv_clinics.Rows[e.RowIndex].Cells[i].OwningColumn.HeaderText}' не должно быть пустым";
                    e.Cancel = true;
                }
            }

            if(dgv_clinics.Rows[e.RowIndex].Cells["ClinicFinance"].Value.ToString()!="Частное"&&
                dgv_clinics.Rows[e.RowIndex].Cells["ClinicFinance"].Value.ToString() != "Государственное")
            {
                dgv_clinics.Rows[e.RowIndex].ErrorText = $"Значение в столбце Тип финансирование должно быть: Частное, Государственное";
                e.Cancel = true;
            }

            if (e.Cancel)
            {
                dgv_buildings.Enabled = false;
                return;
            }

            using(var db=new mriContext())
            {
                var new_clinic = new Clinic()
                {
                    IdClinic = cId,
                    ClinicName = dgv_clinics.Rows[e.RowIndex].Cells["ClinicName"].Value.ToString(),
                    ClinicFinance = dgv_clinics.Rows[e.RowIndex].Cells["ClinicFinance"].Value.ToString(),
                    ClinicEmployers = int.Parse(dgv_clinics.Rows[e.RowIndex].Cells["ClinicEmployers"].Value.ToString()),
                    IdBuilding=int.Parse(dgv_clinics.Rows[e.RowIndex].Cells["IdBuilding"].Value.ToString())
                };

                db.Update(new_clinic);
                db.SaveChanges();
            }

            dgv_clinics.Rows[e.RowIndex].ErrorText = "";
            dgv_buildings.Enabled = true;

        }

        private void btn_delClinic_Click(object sender, EventArgs e)
        {
            var id_del_clinic = (int?)dgv_clinics.CurrentRow.Index;
            if(id_del_clinic.HasValue)
            {
                int id = (int)dgv_clinics.CurrentRow.Cells["IdClinic"].Value;
                using(var db=new mriContext())
                {
                    var cli_to_del = db.Clinics.Where(a => a.IdClinic == id).First();

                    db.Remove(cli_to_del);
                    dgv_clinics.DataSource = null;
                    db.SaveChanges();
                }
            }

            InitializeClinics(int.Parse(dgv_buildings.CurrentRow.Cells["IdBuilding"].Value.ToString()));
        }

        private void btn_addClinic_Click(object sender, EventArgs e)
        {
            if (dgv_buildings.Rows.Count != 0)
            {
                AddClinic clinic = new AddClinic(int.Parse(dgv_buildings.CurrentRow.Cells["IdBuilding"].Value.ToString()));
                if (clinic.ShowDialog() == DialogResult.OK)
                    InitializeClinics(int.Parse(dgv_buildings.CurrentRow.Cells["IdBuilding"].Value.ToString()));
            }
            else
            {
                MessageBox.Show("Вы не выбрали здание!");
            }
        }

        private void dgv_clinics_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dgv_buildings.Enabled = false;
            dgv_clinics.Rows[e.RowIndex].ErrorText = $"Значение в столбце Количество сотрудников должно быть целочисленным";
        }

       

        private void dgv_clinics_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void arm_Load(object sender, EventArgs e)
        {

        }

        private void dgv_buildings_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && dgv_buildings.IsCurrentRowDirty)
            {
                dgv_buildings.CancelEdit();
                InitializeBuildings();
            }

            dgv_buildings.CurrentRow.ErrorText = "";
        }

        private void arm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void btn_openUsers_Click(object sender, EventArgs e)
        {
            UserdDGV userdDGV = new UserdDGV();
            userdDGV.ShowDialog();
        }

        private void btn_openEmp_Click(object sender, EventArgs e)
        {
            EmployersForm employers = new EmployersForm(role);
            employers.ShowDialog();
        }

        private void btn_openPos_Click(object sender, EventArgs e)
        {
            PositionsForm positions = new PositionsForm(role);
            positions.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv_clinics.SelectedCells.Count != 0)
            {
                Work work = new Work(int.Parse(dgv_clinics.CurrentRow.Cells["IdClinic"].Value.ToString()), role);
                work.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы не выбрали клинику");
            }
        }

        private void btn_find1_Click(object sender, EventArgs e)
        {
            FindForm find = new FindForm("find1");
            find.ShowDialog();
        }

        private void btn_find2_Click(object sender, EventArgs e)
        {
            FindForm find = new FindForm("find2");
            find.ShowDialog();
        }
    }
}
