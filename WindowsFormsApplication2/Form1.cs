﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO.Ports;


namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        /* Глобальные переменные ********************************************************************/
        SerialPort SerialPort;//серийный порт
        bool GLOBAL_SerialPortOpen = false; //Отвечает открыт или закрыт серийный порт
        bool GLOBAL_installRobot = false; // Установлен ли робот
        bool GLOBAL_setFinish = false; //Установлен ли финиш
        bool GLOBAL_editMap = false; //Включен режим редактирование -true создание новой таблицы-false
        bool GLOBAL_wayBuilt = false; //Отвечат за построен ли маршрут или нет

        List<int> GLOBAL_robotRoute = new List<int>(); // готовый маршрут робота. Глобальный, чтобы иметь к нему доступ из любого метода
        int GLOBAL_buf_timerPlus = 0;
        int GLOBAL_initialPositionRobot_timer = 0;
        int GLOBAL_X_timer = 0;
        int GLOBAL_Y_timer = 0;
        int GLOBAL_X_finish_stop = 0;
        int GLOBAL_Y_finish_stop = 0;
        /* Подключение к БД */
        string databaseWay = Environment.CurrentDirectory + "\\DatabaseMap.mdb";
        string connectionString = @"provider=Microsoft.Jet.OLEDB.4.0; data source=" + Environment.CurrentDirectory + "\\DatabaseMap.mdb";

        public Form1()
        {
            InitializeComponent();
            //Старотовыое значение для поля позиция робота
            robotPosition.SelectedIndex = 0;
            //Стартовые значения таблицы
            standardClearMap();
            tableLoad();
            // получаем список доступных портов
            string[] ports = SerialPort.GetPortNames();
            // выводим список портов
            for (int i = 0; i < ports.Length; i++)
            {
                ComPortNumber.Items.Add(ports[i].ToString());
            }
        }

    

        /* Кнопка прибавляет/убавляет колличество столбцов *******************************************************************/
        private void numberOfСolumns_ValueChanged(object sender, EventArgs e)
        { 
                dataGridView1.ColumnCount = Convert.ToInt32(numberOfСolumns.Value);
                for (int i = Convert.ToInt32(numberOfСolumns.Value) - 1; i < Convert.ToInt32(numberOfСolumns.Value); i++)
                {
                    dataGridView1.Columns[i].Width = 40;
                }
                dataGridView1.Width = Convert.ToInt32(numberOfСolumns.Value) * 40 + 4;
        }

        /* Кнопка прибавляет/убавляет колличество строк********************************************************************/
        private void numberOfLines_ValueChanged(object sender, EventArgs e)
        {
                dataGridView1.RowCount = Convert.ToInt32(numberOfLines.Value);
                dataGridView1.Height = Convert.ToInt32(numberOfLines.Value) * 22 + 4;
        }

       
       


        /* Сохраняет карту ********************************************************************/
        private void saveMap_Click(object sender, EventArgs e)
        {
            if (emptyCells() == true)
            {
                if (mapName.Text != "")
                {
                    if (GLOBAL_installRobot == true && GLOBAL_setFinish == true)
                    {
                        Boolean uniqueness = true;
                        if (uniqueness == true)
                        {
                            if (GLOBAL_editMap == false)
                            {
                                for (int i = 0; i < selectTable.Items.Count; i++)
                                {
                                    if (Convert.ToString(selectTable.Items[i]) == mapName.Text) { uniqueness = false; }
                                }
                                InquiryUpdateInsertDeleteCreate("CREATE TABLE " + mapName.Text + " (  [Map] TEXT(50), [LinesСolumns] TEXT(50) )"); //CREATE TABLE Map3 (  [Map] TEXT(50), [LinesСolumns] TEXT(50) )
                            }
                            else
                            {
                                InquiryUpdateInsertDeleteCreate("DELETE * FROM " + mapName.Text + ";"); //DELETE * FROM Тест3;
                            }

                            Boolean LinesСolumns = false;// Отвечает за добавление колличества строк и столбцов в бд 
                            for (int i = 0; i < dataGridView1.RowCount; i++)
                            {
                                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                                {
                                    if (LinesСolumns == false)
                                    {
                                        if (j == 0) { InquiryUpdateInsertDeleteCreate("INSERT INTO " + mapName.Text + " (Map, LinesСolumns) VALUES ('" + Convert.ToString(dataGridView1.Rows[i].Cells[j].Value) + "', " + dataGridView1.RowCount + ");"); }
                                        if (j == 1) { InquiryUpdateInsertDeleteCreate("INSERT INTO " + mapName.Text + " (Map, LinesСolumns) VALUES ('" + Convert.ToString(dataGridView1.Rows[i].Cells[j].Value) + "', " + dataGridView1.ColumnCount + ");"); LinesСolumns = true; }
                                    }
                                    else
                                    {
                                        InquiryUpdateInsertDeleteCreate("INSERT INTO " + mapName.Text + " (Map) VALUES ('" + Convert.ToString(dataGridView1.Rows[i].Cells[j].Value) + "');");
                                    }
                                } // for j
                            }// for i
                            selectTable.Items.Clear();
                            tableLoad();
                            statusBar.SelectionColor = Color.Green;
                            statusBar.AppendText("Сохранена карта «" + mapName.Text + "»\n");
                        }//Проверка уникальности имени
                        else
                        {
                            MessageBox.Show("Имя карты должно быть уникальным! Имя «" + mapName.Text + "» уже занято.");
                        }
                    }//Проверка установки робота
                    else
                    {
                        MessageBox.Show("Необходимо установить робота и финишную точку!");
                    }
                }//Поле имя карты не пустое
                else
                {
                    MessageBox.Show("Название карты не может быть пустым!");
                }
            }
            else
            {
                MessageBox.Show("Ячейки не должны быть пустыми!");
            }
        }//сохранение кнопка

         /* При вводе имени таблицы запрещаем пробелы ********************************************************************/
        private void mapName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
        }

        /* При нажатие на элемент ComboBox автоматически показывается выбранная таблица ********************************************************************/
        private void selectTable_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (selectTable.Items.Count > 0)
            {
                GLOBAL_wayBuilt = false;
                GLOBAL_installRobot = false;
                GLOBAL_setFinish = false;
                string[] mas = InquirySelect("SELECT TOP 2 LinesСolumns FROM " + selectTable.SelectedItem + " ;", "LinesСolumns", 2);
                dataGridView1.RowCount = Convert.ToInt32(mas[0]);
                dataGridView1.ColumnCount = Convert.ToInt32(mas[1]);
                dataGridView1.Width = Convert.ToInt32(mas[1]) * 40 + 4;
                dataGridView1.Height = Convert.ToInt32(mas[0]) * 22 + 4;
                for (int i = 0; i < Convert.ToInt32(mas[1]); i++)
                {
                    dataGridView1.Columns[i].Width = 40;
                }
                int lines = Convert.ToInt32(mas[0]);
                int columns = Convert.ToInt32(mas[1]);
                mas = InquirySelect("SELECT Map FROM " + selectTable.SelectedItem + ";", "Map", (lines * columns));
                int a = 0;
                int b = 0;
                int bbuf = columns - 1;
                for (int i = 0; i < mas.Length; i++)
                {
                    dataGridView1.Rows[a].Cells[b].Value = mas[i];
                    dataGridView1.Rows[a].Cells[b].Style.BackColor = Color.White;

                    if (searchRobotInstall(Convert.ToString(dataGridView1.Rows[a].Cells[b].Value)))
                    {
                        dataGridView1.Rows[a].Cells[b].ReadOnly = true;
                        dataGridView1.Rows[a].Cells[b].Style.BackColor = Color.GreenYellow;
                        GLOBAL_installRobot = true;
                        InstallOrRemoveRobot.ImageIndex=1;
                    }

                    if (searchFinishInstall(Convert.ToString(dataGridView1.Rows[a].Cells[b].Value)) == true)
                    {
                        dataGridView1.Rows[a].Cells[b].ReadOnly = true;
                        dataGridView1.Rows[a].Cells[b].Style.BackColor = Color.Gold;
                        GLOBAL_setFinish = true;
                        setRemoveFinish.ImageIndex = 3;
                    }

                    if (Convert.ToString(dataGridView1.Rows[a].Cells[b].Value) == "w")
                    {
                        dataGridView1.Rows[a].Cells[b].Style.BackColor = Color.Black;
                    }
                    b++;
                    if (bbuf == i) { bbuf += columns; b = 0; a++; }
                }//for
                resizeMap();
                statusBar.AppendText("Открыта карта «" + selectTable.SelectedItem + "»\n");
            }
        }

        /* Редактирование карты ********************************************************************/
        private void mapEdit_Click(object sender, EventArgs e)
        {       
            if (Convert.ToString(selectTable.Text) == "Выберете карту") { MessageBox.Show("Выберете карту"); }
            else
            {
                loadMapPanel.Visible = false;
                createMapPanel.Visible = true;
                GLOBAL_editMap = true;
                mapName.Text = Convert.ToString(selectTable.SelectedItem);
                mapName.ReadOnly = true;
                numberOfСolumns.Value = dataGridView1.ColumnCount;
                numberOfLines.Value = dataGridView1.RowCount;
                statusBar.SelectionColor = Color.Orange;
                statusBar.AppendText("Карта «" + selectTable.Text + "» открыта для редактирования\n");
            }
        }







        /* Удаление карты ********************************************************************/
        private void deleteMap_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(selectTable.Text) == "Выберете карту") { MessageBox.Show("Выберете карту"); }
            else
            {
                if (MessageBox.Show("Вы действительно хотите удалить карту «" + selectTable.SelectedItem + "» ?", "Удаление",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            == DialogResult.Yes)
                {
                    InquiryUpdateInsertDeleteCreate("drop table " + selectTable.SelectedItem + ";");
                    tableLoad();
                    statusBar.SelectionColor = Color.Red;
                    statusBar.AppendText("Карта «" + selectTable.Text + "» была удалена \n");
                }
            }
        }

        /* Создает новую таблицу ********************************************************************/
        private void createMap_Click(object sender, EventArgs e)
        {
            loadMapPanel.Visible = false;
            createMapPanel.Visible = true;
            standardClearMap();
            GLOBAL_editMap = false;
            GLOBAL_installRobot = false;
            GLOBAL_setFinish = false;
            resizeMap();
            mapName.ReadOnly = false;
            mapName.Clear();
            statusBar.AppendText("Создание новой карты \n");
        }

        /* открывает панель с выбором карты ********************************************************************/
        private void openMap_Click(object sender, EventArgs e)
        {
            if (GLOBAL_installRobot == true && GLOBAL_setFinish == true)
            {
                if (emptyCells() == true)
                {

                    loadMapPanel.Visible = true;
                    createMapPanel.Visible = false;
                }
                else
                {
                    MessageBox.Show("Ячейки не должны быть пустыми!");
                }
            }
            else
            {
                MessageBox.Show("Необходимо установить робота и финишную точку!");
            }
        }

        /* Запрещаем в dataGridView вводить буквы ********************************************************************/
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Cell_KeyPress);
        }
        private void Cell_KeyPress(object Sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 'w')// w- wall стена, разрешен ввод только этого символа
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                    e.KeyChar = Convert.ToChar("\0");
                dataGridView1.CurrentCell.Style.BackColor = Color.White;
            }
            else { dataGridView1.CurrentCell.Style.BackColor= Color.Black; }
        }

        /* Устанавливает/убирает точку финиша на карте ********************************************************************/
        private void setRemoveFinish_Click(object sender, EventArgs e)
        {
            if (GLOBAL_setFinish == false)
            {
                if (searchRobotInstall(Convert.ToString(dataGridView1.CurrentCell.Value))==true)
                { MessageBox.Show("На этой клетке установлен робот!"); }
                else
                {
                    GLOBAL_setFinish = true;
                    resizeMap();
                    string buf = Convert.ToString(dataGridView1.CurrentCell.Value);
                    if (buf.Length != 0)
                    {
                        dataGridView1.CurrentCell.Value = buf + "f";
                    }
                    else { dataGridView1.CurrentCell.Value = buf + "1f"; }
                    dataGridView1.CurrentCell.Style.BackColor = Color.Gold;
                    dataGridView1.CurrentCell.ReadOnly = true;
                }    
            }
            else
            {
                if (searchFinishInstall( Convert.ToString(dataGridView1.CurrentCell.Value))== true)
                {
                    GLOBAL_setFinish = false;
                    resizeMap();
                    dataGridView1.CurrentCell.Value = deleteFinish(Convert.ToString(dataGridView1.CurrentCell.Value)) ;/////////////////////////////////
                    dataGridView1.CurrentCell.Style.BackColor = Color.White;
                    dataGridView1.CurrentCell.ReadOnly = false;
                }
                else
                {
                    MessageBox.Show("Выберете ячеку, где установлен финиш");
                } 
            }
        }
        /* Если редактирование законченно, а поле пустое, то записываем в него 1 ********************************************************************/
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString(dataGridView1.CurrentCell.Value) == "") { dataGridView1.CurrentCell.Value = "1"; }
            string buf = Convert.ToString(dataGridView1.CurrentCell.Value);

            if (buf.Length > 6)
            {
                dataGridView1.CurrentCell.Value = "1";
                MessageBox.Show("Длина не должна превышать 6 символов");
            }
            else
            {
                if (buf.Length > 1)
                {
                    for (int i = 0; i < buf.Length; i++)
                    {
                        if (buf[i] == 'w') { dataGridView1.CurrentCell.Value = "w"; break; }
                    }
                    //if (buf == "0" && Convert.ToString(dataGridView1.CurrentCell.Value) != "w") { dataGridView1.CurrentCell.Value = "1"; }
                   // else { dataGridView1.CurrentCell.Value = Convert.ToInt32(buf); }
                }
            }
        }

        public Tuple<int, int, int> searchStartFinishInitialPosition()
        {
            int initialPositionRobot=0;
            int start = 0;
            int finish = 0;

            byte searchStartFinish = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)//строки
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)//столбцы
                {
                    /* Так как работа с текстовыми данными медленнее числовых временно заменяем все значения на числовые */
                    string str = Convert.ToString(dataGridView1.Rows[i].Cells[j].Value);
                    if (str.IndexOf("▲") >= 0) {
                        initialPositionRobot = 2;
                        start = (dataGridView1.ColumnCount * i) + j;
                        dataGridView1.Rows[i].Cells[j].Value = "1";
                        searchStartFinish++;
                        continue;
                    }
                    if (str.IndexOf("►") >= 0) {
                        initialPositionRobot = 6;
                        start = (dataGridView1.ColumnCount * i) + j;
                        dataGridView1.Rows[i].Cells[j].Value = "1";
                        searchStartFinish++;
                        continue;
                    }
                    if (str.IndexOf("▼") >= 0) {
                        initialPositionRobot = 8;
                        start = (dataGridView1.ColumnCount * i) + j;
                        dataGridView1.Rows[i].Cells[j].Value = "1";
                        searchStartFinish++;
                        continue;
                    }
                    if (str.IndexOf("◄") >= 0) {
                        initialPositionRobot = 4;
                        start = (dataGridView1.ColumnCount * i) + j;
                        dataGridView1.Rows[i].Cells[j].Value = "1";
                        searchStartFinish++;
                        continue;
                    }
                    if (str.IndexOf("f") >= 0) {
                        int ind = str.IndexOf("f");
                        finish = (dataGridView1.ColumnCount * i) + j;
                        dataGridView1.Rows[i].Cells[j].Value = str.Remove(ind);
                        searchStartFinish++;
                        continue;
                    }
                    if (searchStartFinish == 2) { break; }
                }
                if (searchStartFinish == 2) { break; }
            }

           return Tuple.Create(initialPositionRobot, start, finish);
        }


        /* Проложить маршрут ********************************************************************/
        private void getDirections_Click(object sender, EventArgs e)
        {
            clearColorMap();
            GLOBAL_robotRoute.Clear();// обнулить глобальный список маршрута
            GLOBAL_buf_timerPlus = 0;// обнулить переменную для таймера
            int matrixSize = (dataGridView1.ColumnCount) * (dataGridView1.RowCount);
            int start = 0;
            int finish = 0;
            int[,] adjacencyList = new int[matrixSize, 4];  // список смежноти
            int[,] adjacencyList_adjacentVertices = new int[matrixSize, 4]; // смежные вершины списка смежности 

            /* Если в списке смежности будет отсутствовать какая либо вершина, то она будет отрицательна */
            for (int i = 0; i < matrixSize; i++)//строки
            {
                for (int j = 0; j < 4; j++)//столбцы
                {
                    adjacencyList[i, j] = -1;
                    adjacencyList_adjacentVertices[i, j] = -1;
                }

            }

            int[,] vertexMatrix = new int[matrixSize, 2];
            int stroka = 0;
            byte initialPositionRobot = 0; // Начальное положение робота
                                           /**
                                            * Важно определить начальное положение робота
                                            * вводим следующее обозначение
                                            * 2 - верх
                                            * 4 - лево
                                            * 6 - право
                                            * 8 - низ
                                            * как на кнопочных телефонах         
                                            */

            /* Ищем старт и финиш */
            Tuple<int, int, int> initialPositionStartFinish = searchStartFinishInitialPosition();
            initialPositionRobot =Convert.ToByte(initialPositionStartFinish.Item1);
            start = Convert.ToInt32(initialPositionStartFinish.Item2);
            finish = Convert.ToInt32(initialPositionStartFinish.Item3);


            /* Строим список смежности */
            for (int i = 0; i < dataGridView1.RowCount; i++)//строки
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)//столбцы
                {
                    int stolb = 0;
                    if (i + 1 < dataGridView1.RowCount) { if (Convert.ToString(dataGridView1.Rows[i + 1].Cells[j].Value) != "w") { adjacencyList[stroka, stolb] = Convert.ToInt32(dataGridView1.Rows[i + 1].Cells[j].Value); adjacencyList_adjacentVertices[stroka, stolb] = ((dataGridView1.ColumnCount * (i + 1)) + j); stolb++; } }
                    if (i - 1 >= 0) { if (Convert.ToString(dataGridView1.Rows[i - 1].Cells[j].Value) != "w") { adjacencyList[stroka, stolb] = Convert.ToInt32(dataGridView1.Rows[i - 1].Cells[j].Value); adjacencyList_adjacentVertices[stroka, stolb] = ((dataGridView1.ColumnCount * (i - 1)) + j); stolb++; } }
                    if (j + 1 < dataGridView1.ColumnCount) { if (Convert.ToString(dataGridView1.Rows[i].Cells[j + 1].Value) != "w") { adjacencyList[stroka, stolb] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j + 1].Value); adjacencyList_adjacentVertices[stroka, stolb] = ((dataGridView1.ColumnCount * i) + (j + 1)); stolb++; } }
                    if (j - 1 >= 0) { if (Convert.ToString(dataGridView1.Rows[i].Cells[j - 1].Value) != "w") { adjacencyList[stroka, stolb] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j - 1].Value); adjacencyList_adjacentVertices[stroka, stolb] = ((dataGridView1.ColumnCount * i) + (j - 1)); stolb++; } }
                    vertexMatrix[stroka, 0] = i;
                    vertexMatrix[stroka, 1] = j;
                    stroka++;
                }
            }

            const int infinity = 999999999;// Бесконечность
            int currentVertex; // текущая вершина
                               // Будем искать путь из вершины s в вершину g
            bool[] visit = new bool[matrixSize]; //посещенные вершины
            int[] vertexLabels = new int[matrixSize]; //Мектки вершин
            int[] way = new int[matrixSize]; // запоминает последнюю вершину для нахождения пути назад
            int[] vertex = new int[matrixSize];//хранит соседние вершиеы
                                               /*
                                                * Введем следеющее обозначения:
                                                * 2- движение прямо ^
                                                * 4-поворот налево <=
                                                * 6-поворот направо =>
                                                */
                                               /* метка всех вершин бесконечность */

            List<int> routeOfMovement_x = new List<int>(); //Список движения будет хранить конечный маршрут
            List<int> routeOfMovement_y = new List<int>(); //Список движения будет хранить конечный маршрут
            for (int i = 0; i < matrixSize; i++)
            {
                vertexLabels[i] = infinity;
                vertex[i] = infinity;
            }
            way[start] = 0;          // s - начало пути, поэтому этой вершине ничего не предшествует
            vertexLabels[start] = 0; // Кратчайший путь из start в start равен 0 /начальная метка как в википедии и норм статьях
            visit[start] = true;       // Вершина s посещена
            currentVertex = start;    // Делаем s текущей вершиной

            while (true)
            {
                // Перебираем все вершины, смежные v, и ищем для них кратчайший путь
                for (int i = 0; i < 4; i++)
                {
                    if (adjacencyList[currentVertex, i] == -1) continue; // Вершины u и v несмежные
                    if (visit[adjacencyList_adjacentVertices[currentVertex, i]] == false && vertexLabels[adjacencyList_adjacentVertices[currentVertex, i]] > vertexLabels[currentVertex] + adjacencyList[currentVertex, i])
                    {
                        vertexLabels[adjacencyList_adjacentVertices[currentVertex, i]] = vertexLabels[currentVertex] + adjacencyList[currentVertex, i]; //новая метка вершины
                        way[adjacencyList_adjacentVertices[currentVertex, i]] = currentVertex;//запоминаем, что v->u часть кратчайшего пути из s->u
                        vertex[adjacencyList_adjacentVertices[currentVertex, i]] = vertexLabels[adjacencyList_adjacentVertices[currentVertex, i]];

                        // adjacencyList_adjacentVertices[currentVertex, i]
                    }
                }


               
                currentVertex = -1;// В конце поиска v - вершина, в которую будет найден новый кратчайший путь. Она станет текущей вершиной
                if (visit[Array.IndexOf(vertex, vertex.Min())] == false)
                {
                    currentVertex = Array.IndexOf(vertex, vertex.Min());
                    vertex[Array.IndexOf(vertex, vertex.Min())] = infinity;
                }

                if (currentVertex == -1)
                {
                    MessageBox.Show("Нет пути из вершины " + Convert.ToString(start) + " в вершину " + Convert.ToString(finish));
                    break;
                }
                if (currentVertex == finish) // Найден кратчайший путь,
                {        // выводим его
                    int u = finish;
                    while (u != start)
                    {
                        dataGridView1.Rows[vertexMatrix[u, 0]].Cells[vertexMatrix[u, 1]].Style.BackColor = Color.PeachPuff;
                        routeOfMovement_y.Add(vertexMatrix[u, 0]);
                        routeOfMovement_x.Add(vertexMatrix[u, 1]);
                        u = way[u];
                    }
                    break;
                }
                visit[currentVertex] = true;
            }/// while 


            if (initialPositionRobot == 2) { dataGridView1.Rows[vertexMatrix[start, 0]].Cells[vertexMatrix[start, 1]].Value =Convert.ToString(dataGridView1.Rows[vertexMatrix[start, 0]].Cells[vertexMatrix[start, 1]].Value) + "▲"; dataGridView1.Rows[vertexMatrix[start, 0]].Cells[vertexMatrix[start, 1]].Style.BackColor = Color.GreenYellow; }
            if (initialPositionRobot == 4) { dataGridView1.Rows[vertexMatrix[start, 0]].Cells[vertexMatrix[start, 1]].Value = Convert.ToString(dataGridView1.Rows[vertexMatrix[start, 0]].Cells[vertexMatrix[start, 1]].Value) + "◄"; dataGridView1.Rows[vertexMatrix[start, 0]].Cells[vertexMatrix[start, 1]].Style.BackColor = Color.GreenYellow; }
            if (initialPositionRobot == 6) { dataGridView1.Rows[vertexMatrix[start, 0]].Cells[vertexMatrix[start, 1]].Value = Convert.ToString(dataGridView1.Rows[vertexMatrix[start, 0]].Cells[vertexMatrix[start, 1]].Value) + "►"; dataGridView1.Rows[vertexMatrix[start, 0]].Cells[vertexMatrix[start, 1]].Style.BackColor = Color.GreenYellow; }
            if (initialPositionRobot == 8) { dataGridView1.Rows[vertexMatrix[start, 0]].Cells[vertexMatrix[start, 1]].Value = Convert.ToString(dataGridView1.Rows[vertexMatrix[start, 0]].Cells[vertexMatrix[start, 1]].Value) + "▼"; dataGridView1.Rows[vertexMatrix[start, 0]].Cells[vertexMatrix[start, 1]].Style.BackColor = Color.GreenYellow; }

            dataGridView1.Rows[vertexMatrix[finish, 0]].Cells[vertexMatrix[finish, 1]].Value = Convert.ToString(dataGridView1.Rows[vertexMatrix[finish, 0]].Cells[vertexMatrix[finish, 1]].Value) + "f";
            dataGridView1.Rows[vertexMatrix[finish, 0]].Cells[vertexMatrix[finish, 1]].Style.BackColor = Color.Gold;
            GLOBAL_X_finish_stop = vertexMatrix[finish, 1];
            GLOBAL_Y_finish_stop = vertexMatrix[finish, 0];
            int current_X = vertexMatrix[start, 1];
            int current_Y = vertexMatrix[start, 0];
            int currentPosition = initialPositionRobot;
            for (int i = routeOfMovement_x.Count - 1; i >= 0; i--)
            {
                if (currentPosition == 2)
                {
                    if (current_X + 1 == routeOfMovement_x[i]) { GLOBAL_robotRoute.Add(6); GLOBAL_robotRoute.Add(2); currentPosition = 6; current_X++; continue; }
                    if (current_X - 1 == routeOfMovement_x[i]) { GLOBAL_robotRoute.Add(4); GLOBAL_robotRoute.Add(2); currentPosition = 4; current_X--; continue; }
                    if (current_Y + 1 == routeOfMovement_y[i]) { GLOBAL_robotRoute.Add(0); GLOBAL_robotRoute.Add(2); currentPosition = 8; current_Y++; continue; }
                    if (current_Y - 1 == routeOfMovement_y[i]) { GLOBAL_robotRoute.Add(2); current_Y--; continue; }
                }
                if (currentPosition == 4)
                {
                    if (current_X + 1 == routeOfMovement_x[i]) { GLOBAL_robotRoute.Add(0); GLOBAL_robotRoute.Add(2); currentPosition = 6; current_X++; continue; }
                    if (current_X - 1 == routeOfMovement_x[i]) { GLOBAL_robotRoute.Add(2);  current_X--; continue; }
                    if (current_Y + 1 == routeOfMovement_y[i]) { GLOBAL_robotRoute.Add(4); GLOBAL_robotRoute.Add(2); currentPosition = 8; current_Y++; continue; }
                    if (current_Y - 1 == routeOfMovement_y[i]) { GLOBAL_robotRoute.Add(6); GLOBAL_robotRoute.Add(2); currentPosition = 2; current_Y--; continue; }
                }
                if (currentPosition == 6)
                {
                    if (current_X + 1 == routeOfMovement_x[i]) { GLOBAL_robotRoute.Add(2); current_X++; continue; }
                    if (current_X - 1 == routeOfMovement_x[i]) { GLOBAL_robotRoute.Add(0); GLOBAL_robotRoute.Add(2); currentPosition = 4; current_X--; continue; }
                    if (current_Y + 1 == routeOfMovement_y[i]) { GLOBAL_robotRoute.Add(6); GLOBAL_robotRoute.Add(2); currentPosition = 8; current_Y++; continue; }
                    if (current_Y - 1 == routeOfMovement_y[i]) { GLOBAL_robotRoute.Add(4); GLOBAL_robotRoute.Add(2); currentPosition = 2; current_Y--; continue; }
                }
                if (currentPosition == 8)
                {
                    if (current_X + 1 == routeOfMovement_x[i]) { GLOBAL_robotRoute.Add(4); GLOBAL_robotRoute.Add(2); currentPosition = 6; current_X++; continue; }
                    if (current_X - 1 == routeOfMovement_x[i]) { GLOBAL_robotRoute.Add(6); GLOBAL_robotRoute.Add(2); currentPosition = 4; current_X--; continue; }
                    if (current_Y + 1 == routeOfMovement_y[i]) { GLOBAL_robotRoute.Add(2); current_Y++; continue; }
                    if (current_Y - 1 == routeOfMovement_y[i]) { GLOBAL_robotRoute.Add(0); GLOBAL_robotRoute.Add(2); currentPosition = 2; current_Y--; continue; }
                }
            }//for
            GLOBAL_wayBuilt = true;        
            GLOBAL_buf_timerPlus = 0;
            GLOBAL_X_timer = vertexMatrix[start, 1];
            GLOBAL_Y_timer = vertexMatrix[start, 0];
            GLOBAL_initialPositionRobot_timer = initialPositionRobot;
        }// проложить маршрут





        private void loadMapIntoRobot_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(selectTable.Text) != "Выберете карту")
            {
                uploadRobotPanel.Visible = true;
                loadMapPanel.Visible = false;
            }
            else
            {
                MessageBox.Show("Выберете карту!");
            }
        }

        private void Compound_Click(object sender, EventArgs e)
        {

            try
            {
                SerialPort = new SerialPort(Convert.ToString(ComPortNumber.SelectedItem));
                SerialPort.BaudRate = 115200;
                SerialPort.Parity = Parity.None;
                SerialPort.StopBits = StopBits.One;
                SerialPort.DataBits = 8;
                SerialPort.Handshake = Handshake.None;
                SerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                statusBar.AppendText("Установка соединения..." + "\n");
                SerialPort.Open();
                statusBar.AppendText("Соединение успешно установлено " + "\n");
                GLOBAL_SerialPortOpen = true;

            }
            catch
            {
                statusBar.AppendText("Не удалось выполнить соединение" + "\n");

            }


        }

        private void DataReceivedHandler(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string POT = SerialPort.ReadLine();
        }
        private delegate void LineReceivedEvent(string POT);

        private void openMap2_Click(object sender, EventArgs e)
        {
            uploadRobotPanel.Visible = false;
            loadMapPanel.Visible = true;
            GLOBAL_wayBuilt = false;
            clearColorMap();
        }

        private void clearColorMap()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)//строки
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)//столбцы
                {

                    if ( searchRobotInstall(Convert.ToString(dataGridView1.Rows[i].Cells[j].Value))==true||
                        searchFinishInstall(Convert.ToString(dataGridView1.Rows[i].Cells[j].Value))==true||
                        Convert.ToString(dataGridView1.Rows[i].Cells[j].Value) == "w" ){ continue; }
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
        }


        private void StopRobotWay(bool b)
        {
            if (b == true)
            {
                openMap2.Enabled = true;
                getDirections.Enabled = true;
                Compound.Enabled = true;
                ComPortNumber.Enabled = true;
                sendWayRobot.Enabled = true;
                dataGridView1.ReadOnly = false;

            }
            else {
                openMap2.Enabled = false;
                getDirections.Enabled = false;
                Compound.Enabled = false;
                ComPortNumber.Enabled = false;
                sendWayRobot.Enabled = false;
                dataGridView1.ReadOnly = true;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {           
            for (int i=0; i<1; i++)
            {

                if (GLOBAL_robotRoute[GLOBAL_buf_timerPlus] == 4) 
                {
                    if (GLOBAL_initialPositionRobot_timer == 2) {
                        GLOBAL_initialPositionRobot_timer = 4;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value=DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "◄";
                        break;
                    }

                    if (GLOBAL_initialPositionRobot_timer == 4) {
                        GLOBAL_initialPositionRobot_timer = 8;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "▼";
                        break;
                    }

                    if (GLOBAL_initialPositionRobot_timer == 6) {
                        GLOBAL_initialPositionRobot_timer = 2;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "▲";
                        break;
                    }

                    if (GLOBAL_initialPositionRobot_timer == 8) {
                        GLOBAL_initialPositionRobot_timer = 6;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "►";
                        break;
                    }
                }

                if (GLOBAL_robotRoute[GLOBAL_buf_timerPlus] == 6) 
                {
                    if (GLOBAL_initialPositionRobot_timer == 2) {
                        GLOBAL_initialPositionRobot_timer = 6;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "►";
                        break;
                    }

                    if (GLOBAL_initialPositionRobot_timer == 4) {
                        GLOBAL_initialPositionRobot_timer = 2;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "▲";
                        break;
                    }

                    if (GLOBAL_initialPositionRobot_timer == 6) {
                        GLOBAL_initialPositionRobot_timer = 8;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "▼";
                        break;
                    }
                    if (GLOBAL_initialPositionRobot_timer == 8) {
                        GLOBAL_initialPositionRobot_timer = 4;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "◄";
                        break;
                    }
                }
                if (GLOBAL_robotRoute[GLOBAL_buf_timerPlus] == 0) 
                {
                    if (GLOBAL_initialPositionRobot_timer == 2) {
                        GLOBAL_initialPositionRobot_timer = 8;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "▼";
                        break;
                    }

                    if (GLOBAL_initialPositionRobot_timer == 4) {
                        GLOBAL_initialPositionRobot_timer = 6;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "►";
                        break;
                    }

                    if (GLOBAL_initialPositionRobot_timer == 6) {
                        GLOBAL_initialPositionRobot_timer = 4;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "◄";
                        break;
                    }

                    if (GLOBAL_initialPositionRobot_timer == 8) {
                        GLOBAL_initialPositionRobot_timer = 2;
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                        dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "▲";
                        break;
                    }
                }
            }

            if (GLOBAL_robotRoute[GLOBAL_buf_timerPlus] == 2)
            {
                if (GLOBAL_initialPositionRobot_timer == 2) {
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value= DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Style.BackColor = Color.LawnGreen;
                    GLOBAL_Y_timer--;
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "▲";
                }

                if (GLOBAL_initialPositionRobot_timer == 4) {
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Style.BackColor = Color.LawnGreen;
                    GLOBAL_X_timer--;
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "◄";
                }

                if (GLOBAL_initialPositionRobot_timer == 6) {
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Style.BackColor = Color.LawnGreen;
                    GLOBAL_X_timer++;
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "►";
                }

                if (GLOBAL_initialPositionRobot_timer == 8) {
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value = DeleteRobot(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value));
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Style.BackColor = Color.LawnGreen;
                    GLOBAL_Y_timer++;
                    dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Value += "▼";
                }

                dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].Style.BackColor = Color.Orange;
            }
            GLOBAL_buf_timerPlus++;
            if (GLOBAL_buf_timerPlus >= GLOBAL_robotRoute.Count) {
                timer1.Enabled = false;
                MessageBox.Show("Робот успешно закончил маршрут");
                dataGridView1.Rows[GLOBAL_Y_finish_stop].Cells[GLOBAL_X_finish_stop].Value = deleteFinish(Convert.ToString(dataGridView1.Rows[GLOBAL_Y_finish_stop].Cells[GLOBAL_X_finish_stop].Value));
                GLOBAL_setFinish = false;
                GLOBAL_wayBuilt = false;
                resizeMap();
                StopRobotWay(true);
                dataGridView1.Rows[GLOBAL_Y_finish_stop].Cells[GLOBAL_X_finish_stop].ReadOnly = true;
                uploadRobotPanel.Visible = false;
                createMapPanel.Visible = true;
                clearColorMap();
                RobotStop.Enabled = false;

            }        
        }
        private void sendWayRobot_Click(object sender, EventArgs e)
        {
            if (GLOBAL_wayBuilt == true)
            {
                StopRobotWay(false);
                timer1.Enabled = true;
                RobotStop.Enabled = true;
            }
            else
            {
                MessageBox.Show("Необходимо построить маршрут");
            }
        }

        private void InstallOrRemoveRobot_Click(object sender, EventArgs e)
        {
            if (robotPosition.SelectedItem == "▲" || robotPosition.SelectedItem == "►" || robotPosition.SelectedItem == "▼" || robotPosition.SelectedItem == "◄")
            {
                if (GLOBAL_installRobot == false)
                {
                    if (Convert.ToString(dataGridView1.CurrentCell.Value) == "w")
                    {
                        MessageBox.Show("На этой клетке находится непроходимое препятствие!");
                    }
                    else
                    {
                        if (searchFinishInstall(Convert.ToString(dataGridView1.CurrentCell.Value)) == true)
                        {
                            MessageBox.Show("На этой клетке установлен финиш!");
                        }
                        else
                        {
                            string buf = Convert.ToString(dataGridView1.CurrentCell.Value);
                            if (buf.Length != 0)
                            {
                                dataGridView1.CurrentCell.Value = buf + Convert.ToString(robotPosition.SelectedItem);
                            }
                            else { dataGridView1.CurrentCell.Value = buf +"1"+ Convert.ToString(robotPosition.SelectedItem); }

                            dataGridView1.CurrentCell.ReadOnly = true;
                            GLOBAL_installRobot = true;
                            resizeMap();
                            dataGridView1.CurrentCell.Style.BackColor = Color.GreenYellow;
                        }
                    }
                }//GLOBAL_installRobot == false
                else
                {
                    if (searchRobotInstall(Convert.ToString(dataGridView1.CurrentCell.Value)) == true)
                    {
                        dataGridView1.CurrentCell.Value = DeleteRobot(Convert.ToString(dataGridView1.CurrentCell.Value));///////////////////////
                        dataGridView1.CurrentCell.ReadOnly = false;
                        GLOBAL_installRobot = false;
                        resizeMap();
                        dataGridView1.CurrentCell.Style.BackColor = Color.White;
                    }
                    else MessageBox.Show("Выберете ячеку, где установлен робот");
                }
            }
            else MessageBox.Show("Положение робота должно быть ▲, ►, ▼, ◄");



        }

        private void createMap2_Click(object sender, EventArgs e)
        {
            createMap_Click(sender, e);
        }

        private void RobotStop_Click(object sender, EventArgs e)
        {
            GLOBAL_wayBuilt = false;
            timer1.Enabled = false;
            StopRobotWay(true);
            dataGridView1.Rows[GLOBAL_Y_timer].Cells[GLOBAL_X_timer].ReadOnly = true;
            dataGridView1.Rows[GLOBAL_Y_finish_stop].Cells[GLOBAL_X_finish_stop].ReadOnly = true;
            RobotStop.Enabled = false;
        }
    } // form class
} //namespace 
