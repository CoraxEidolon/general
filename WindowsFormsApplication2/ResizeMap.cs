using System.Windows.Forms;
namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {////////////////////

        /* Функция разрешает/запрещает менять размер карты*/
        private void resizeMap()
        {
            if (GLOBAL_installRobot == false && GLOBAL_setFinish == false)
            {
                numberOfСolumns.Enabled = true;
                numberOfLines.Enabled = true;
            }

            if (GLOBAL_installRobot == true || GLOBAL_setFinish == true)
            {
                numberOfСolumns.Enabled = false;
                numberOfLines.Enabled = false;

            }
            if (GLOBAL_installRobot == true) { InstallOrRemoveRobot.ImageIndex=1; } else { InstallOrRemoveRobot.ImageIndex=0; }
            if (GLOBAL_setFinish == true) { setRemoveFinish.ImageIndex = 3; } else { setRemoveFinish.ImageIndex = 2; }
        }


    }//////////////////

}