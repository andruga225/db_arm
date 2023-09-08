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
    public partial class PositionsForm : Form
    {
        public PositionsForm(string role)
        {
            InitializeComponent();
            InitializePositions();
            dgv_position.ReadOnly = false;
            btn_addPos.Enabled = true;
            btn_delPos.Enabled = true;

            if (role=="Гость")
            {
                dgv_position.ReadOnly = true;
                btn_addPos.Enabled = false;
                btn_delPos.Enabled = false;
            }
        }

        private void InitializePositions()
        {
            using (var db = new mriContext())
            {
                var result = (from Position in db.Positions
                              select Position).ToList();

                dgv_position.DataSource = result;

                dgv_position.Columns["Position1"].HeaderText = "Должность";
                dgv_position.Columns["Salary"].HeaderText = "Зарплата";
                dgv_position.Columns["Permission"].HeaderText = "Разрешение описывать список";
                dgv_position.Columns["EmpPos"].Visible = false;
                dgv_position.Columns["Position1"].ReadOnly = true;
            }
        }

        private void btn_addPos_Click(object sender, EventArgs e)
        {
            AddPosition addPosition = new AddPosition();
            if (addPosition.ShowDialog() == DialogResult.OK)
                InitializePositions();
        }

        private void btn_delPos_Click(object sender, EventArgs e)
        {
            var id_del_pos = (int?)dgv_position.CurrentRow.Index;
            if(id_del_pos.HasValue)
            {
                string id = dgv_position.CurrentRow.Cells["Position1"].Value.ToString();
                using(var db=new mriContext())
                {
                    var pos_to_del = db.Positions.Where(a => a.Position1 == id).First();

                    db.Remove(pos_to_del);
                    dgv_position.DataSource = null;
                    db.SaveChanges();
                }
            }

            InitializePositions();
        }

        private void dgv_position_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var pId = dgv_position.Rows[e.RowIndex].Cells["Position1"].Value.ToString();

            foreach(var i in new[] { "Position1","Salary"})
            {
                try
                {
                    if(string.IsNullOrWhiteSpace(dgv_position.Rows[e.RowIndex].Cells[i].Value.ToString()))
                    {
                        dgv_position.Rows[e.RowIndex].ErrorText = $"Значение в столбце '{dgv_position.Rows[e.RowIndex].Cells[i].OwningColumn.HeaderText}' не должно быть пустым";
                        e.Cancel = true;
                    }
                }
                catch
                {
                    dgv_position.Rows[e.RowIndex].ErrorText = $"Значение в столбце '{dgv_position.Rows[e.RowIndex].Cells[i].OwningColumn.HeaderText}' не должно быть пустым";
                    e.Cancel = true;
                }
            }

            if (e.Cancel)
                return;

            using(var db=new mriContext())
            {
                var new_pos = new Position()
                {
                    Position1 = pId,
                    Salary =int.Parse(dgv_position.Rows[e.RowIndex].Cells["Salary"].Value.ToString()),
                    Permission= (bool)dgv_position.Rows[e.RowIndex].Cells["Permission"].Value,
                };

                db.Update(new_pos);
                db.SaveChanges();
            }

            dgv_position.Rows[e.RowIndex].ErrorText = "";
        }

        private void dgv_position_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dgv_position.Rows[e.RowIndex].ErrorText = $"Значение в столбце Зарплата должно быть целочисленным";
        }
    }
}
