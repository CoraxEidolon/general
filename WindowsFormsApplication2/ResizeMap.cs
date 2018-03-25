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

        /* Функция разрешает/запрещает менять размер карты*/
        private void resizeMap()
        {
            if (installRobot == false && setFinish == false)
            {
                numberOfСolumns.Enabled = true;
                numberOfLines.Enabled = true;
            }

            if (installRobot == true || setFinish == true)
            {
                numberOfСolumns.Enabled = false;
                numberOfLines.Enabled = false;

            }
            if (installRobot == true) { InstallOrRemoveRobot.Text = "Убрать"; } else { InstallOrRemoveRobot.Text = "Установить"; }
            if (setFinish == true) { setRemoveFinish.Text = "Убрать финиш"; } else { setRemoveFinish.Text = "Установить финиш"; }
        }


    }//////////////////

}