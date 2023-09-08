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
    public partial class AddBuilding : Form
    {
        public AddBuilding()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(cb_builType.Text))
            {
                MessageBox.Show($"Заполните поле Тип здания");
                return;
            }

            using (var db=new mriContext())
            {
                Building building = new Building
                {
                    BuildingAddress = tb_address.Text.ToString(),
                    BuildingType = cb_builType.Text.ToString(),
                    BuildingFloors = (int)num_builFloor.Value
                };

                db.Add(building);
                db.SaveChanges();
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
