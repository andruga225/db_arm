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
    public partial class AddPosition : Form
    {
        public AddPosition()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_position.Text))
                MessageBox.Show("Заполните поле Должность");

            using(var db=new mriContext())
            {
                Position position = new Position
                {
                    Position1 = tb_position.Text,
                    Salary = (int)num_salary.Value,
                    Permission = chb_perm.Checked
                };

                var result = (from Position in db.Positions
                              where Position.Position1 == tb_position.Text
                              select Position).FirstOrDefault();
                if(result!=null)
                {
                    MessageBox.Show("Такая должность уже существует");
                    return;
                }
                db.Add(position);
                db.SaveChanges();
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
