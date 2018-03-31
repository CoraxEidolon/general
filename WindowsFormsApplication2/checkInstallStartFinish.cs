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

        /* Проверка, установлен робот на карту ********************************************************************/
        private bool searchRobotInstall(string str)
        {
            bool rez = false;
            if (str.IndexOf("▲") >= 0) { rez = true; }
            if (str.IndexOf("►") >= 0) { rez = true; }
            if (str.IndexOf("▼") >= 0) { rez = true; }
            if (str.IndexOf("◄") >= 0) { rez = true; }
            return rez;
        }
        /* Удаляет робота с карты ********************************************************************/
        private string DeleteRobot(string str)
        {        
            if (str.IndexOf("▲") >= 0) {
                int ind = str.IndexOf("▲");
                str = str.Remove(ind);
            }
            if (str.IndexOf("►") >= 0) {
                int ind = str.IndexOf("►");
                str = str.Remove(ind);
            }
            if (str.IndexOf("▼") >= 0) {
                int ind = str.IndexOf("▼");
                str = str.Remove(ind);
            }
            if (str.IndexOf("◄") >= 0) {
                int ind = str.IndexOf("◄");
                str = str.Remove(ind);
            }
            return str;
        }

        /* Проверка, установлен финиш ********************************************************************/
        private bool searchFinishInstall(string str)
        {
            bool rez = false;
            if (str.IndexOf("f") >= 0) { rez = true; }
            return rez;
        }

        private string deleteFinish(string str)
        {
            if (str.IndexOf("f") >= 0) { int ind = str.IndexOf("f"); str = str.Remove(ind,1); }
            return str;
        }


        /* Проверка, что ячейки не пустые ********************************************************************/
        private bool emptyCells()
        {
            bool rezult = true;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    if (Convert.ToString(dataGridView1.Rows[j].Cells[i].Value) == "") { rezult = false; break; }
                }
            }
            return (rezult);
        }



    }//////////////////

}