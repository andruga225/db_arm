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
    public partial class AddClinic : Form
    {
        private int id_bui;
        public AddClinic(int building)
        {
            InitializeComponent();
            id_bui = building;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_clinicName.Text))
                MessageBox.Show("Заполните поле Название клиники");

            using(var db=new mriContext())
            {
                Clinic clinic = new Clinic
                {
                    ClinicName = tb_clinicName.Text,
                    ClinicFinance = cb_finance.Text,
                    ClinicEmployers = (int)num_emp.Value,
                    IdBuilding = id_bui
                };

                db.Add(clinic);
                db.SaveChanges();
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
