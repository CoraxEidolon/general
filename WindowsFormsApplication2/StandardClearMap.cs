using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {////////////////////

        /* Очистка поля до стандартных значений */
        private void standardClearMap()
        {
            numberOfСolumns.Value = 2;
            numberOfLines.Value = 2;
            dataGridView1.RowCount = Convert.ToInt32(numberOfСolumns.Value);
            dataGridView1.ColumnCount = Convert.ToInt32(numberOfСolumns.Value);
            dataGridView1.Width = Convert.ToInt32(numberOfСolumns.Value) * 40 + 4;
            dataGridView1.Height = Convert.ToInt32(numberOfСolumns.Value) * 22 + 4;
            for (int i = 0; i < Convert.ToInt32(numberOfСolumns.Value); i++)
            {
                dataGridView1.Columns[i].Width = 40;
            }

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    dataGridView1.Rows[j].Cells[i].Value = "";
                }
            }
        }

    }//////////////////

}