namespace WindowsFormsApplication2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.createMapPanel = new System.Windows.Forms.Panel();
            this.createMap2 = new System.Windows.Forms.Button();
            this.labelFinish = new System.Windows.Forms.Label();
            this.setRemoveFinish = new System.Windows.Forms.Button();
            this.openMap = new System.Windows.Forms.Button();
            this.saveMap = new System.Windows.Forms.Button();
            this.labelMapName = new System.Windows.Forms.Label();
            this.mapName = new System.Windows.Forms.TextBox();
            this.InstallOrRemoveRobot = new System.Windows.Forms.Button();
            this.labelRobotPosition = new System.Windows.Forms.Label();
            this.robotPosition = new System.Windows.Forms.ComboBox();
            this.LabelLines = new System.Windows.Forms.Label();
            this.numberOfLines = new System.Windows.Forms.NumericUpDown();
            this.LabelСolumns = new System.Windows.Forms.Label();
            this.numberOfСolumns = new System.Windows.Forms.NumericUpDown();
            this.loadMapPanel = new System.Windows.Forms.Panel();
            this.loadMapIntoRobot = new System.Windows.Forms.Button();
            this.getDirections = new System.Windows.Forms.Button();
            this.createMap = new System.Windows.Forms.Button();
            this.deleteMap = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.selectTable = new System.Windows.Forms.ComboBox();
            this.statusBar = new System.Windows.Forms.RichTextBox();
            this.uploadRobotPanel = new System.Windows.Forms.Panel();
            this.Compound = new System.Windows.Forms.Button();
            this.ComPortNumber = new System.Windows.Forms.ComboBox();
            this.openMap2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.createMapPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfСolumns)).BeginInit();
            this.loadMapPanel.SuspendLayout();
            this.uploadRobotPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridView1.Location = new System.Drawing.Point(328, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(51, 44);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // createMapPanel
            // 
            this.createMapPanel.Controls.Add(this.createMap2);
            this.createMapPanel.Controls.Add(this.labelFinish);
            this.createMapPanel.Controls.Add(this.setRemoveFinish);
            this.createMapPanel.Controls.Add(this.openMap);
            this.createMapPanel.Controls.Add(this.saveMap);
            this.createMapPanel.Controls.Add(this.labelMapName);
            this.createMapPanel.Controls.Add(this.mapName);
            this.createMapPanel.Controls.Add(this.InstallOrRemoveRobot);
            this.createMapPanel.Controls.Add(this.labelRobotPosition);
            this.createMapPanel.Controls.Add(this.robotPosition);
            this.createMapPanel.Controls.Add(this.LabelLines);
            this.createMapPanel.Controls.Add(this.numberOfLines);
            this.createMapPanel.Controls.Add(this.LabelСolumns);
            this.createMapPanel.Controls.Add(this.numberOfСolumns);
            this.createMapPanel.Location = new System.Drawing.Point(24, 12);
            this.createMapPanel.Name = "createMapPanel";
            this.createMapPanel.Size = new System.Drawing.Size(779, 57);
            this.createMapPanel.TabIndex = 1;
            this.createMapPanel.Visible = false;
            // 
            // createMap2
            // 
            this.createMap2.Location = new System.Drawing.Point(678, 7);
            this.createMap2.Name = "createMap2";
            this.createMap2.Size = new System.Drawing.Size(96, 23);
            this.createMap2.TabIndex = 10;
            this.createMap2.Text = "Создать";
            this.createMap2.UseVisualStyleBackColor = true;
            this.createMap2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelFinish
            // 
            this.labelFinish.AutoSize = true;
            this.labelFinish.Location = new System.Drawing.Point(282, 16);
            this.labelFinish.Name = "labelFinish";
            this.labelFinish.Size = new System.Drawing.Size(86, 13);
            this.labelFinish.TabIndex = 3;
            this.labelFinish.Text = "Конечная точка";
            // 
            // setRemoveFinish
            // 
            this.setRemoveFinish.Location = new System.Drawing.Point(270, 32);
            this.setRemoveFinish.Name = "setRemoveFinish";
            this.setRemoveFinish.Size = new System.Drawing.Size(112, 23);
            this.setRemoveFinish.TabIndex = 3;
            this.setRemoveFinish.Text = "Установить финиш";
            this.setRemoveFinish.UseVisualStyleBackColor = true;
            this.setRemoveFinish.Click += new System.EventHandler(this.setRemoveFinish_Click);
            // 
            // openMap
            // 
            this.openMap.Location = new System.Drawing.Point(560, 7);
            this.openMap.Name = "openMap";
            this.openMap.Size = new System.Drawing.Size(112, 21);
            this.openMap.TabIndex = 9;
            this.openMap.Text = "Открыть карту";
            this.openMap.UseVisualStyleBackColor = true;
            this.openMap.Click += new System.EventHandler(this.openMap_Click);
            // 
            // saveMap
            // 
            this.saveMap.Location = new System.Drawing.Point(560, 31);
            this.saveMap.Name = "saveMap";
            this.saveMap.Size = new System.Drawing.Size(112, 22);
            this.saveMap.TabIndex = 6;
            this.saveMap.Text = "Сохранить карту";
            this.saveMap.UseVisualStyleBackColor = true;
            this.saveMap.Click += new System.EventHandler(this.saveMap_Click);
            // 
            // labelMapName
            // 
            this.labelMapName.AutoSize = true;
            this.labelMapName.Location = new System.Drawing.Point(403, 15);
            this.labelMapName.Name = "labelMapName";
            this.labelMapName.Size = new System.Drawing.Size(91, 13);
            this.labelMapName.TabIndex = 8;
            this.labelMapName.Text = "Название карты";
            // 
            // mapName
            // 
            this.mapName.Location = new System.Drawing.Point(406, 34);
            this.mapName.Name = "mapName";
            this.mapName.Size = new System.Drawing.Size(146, 20);
            this.mapName.TabIndex = 7;
            this.mapName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mapName_KeyPress);
            // 
            // InstallOrRemoveRobot
            // 
            this.InstallOrRemoveRobot.Location = new System.Drawing.Point(189, 33);
            this.InstallOrRemoveRobot.Name = "InstallOrRemoveRobot";
            this.InstallOrRemoveRobot.Size = new System.Drawing.Size(75, 23);
            this.InstallOrRemoveRobot.TabIndex = 5;
            this.InstallOrRemoveRobot.Text = "Установить";
            this.InstallOrRemoveRobot.UseVisualStyleBackColor = true;
            this.InstallOrRemoveRobot.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelRobotPosition
            // 
            this.labelRobotPosition.AutoSize = true;
            this.labelRobotPosition.Location = new System.Drawing.Point(151, 15);
            this.labelRobotPosition.Name = "labelRobotPosition";
            this.labelRobotPosition.Size = new System.Drawing.Size(103, 13);
            this.labelRobotPosition.TabIndex = 2;
            this.labelRobotPosition.Text = "Положение робота";
            // 
            // robotPosition
            // 
            this.robotPosition.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.robotPosition.FormattingEnabled = true;
            this.robotPosition.Items.AddRange(new object[] {
            "▲",
            "►",
            "▼",
            "◄"});
            this.robotPosition.Location = new System.Drawing.Point(143, 34);
            this.robotPosition.Name = "robotPosition";
            this.robotPosition.Size = new System.Drawing.Size(40, 22);
            this.robotPosition.TabIndex = 4;
            // 
            // LabelLines
            // 
            this.LabelLines.AutoSize = true;
            this.LabelLines.Location = new System.Drawing.Point(11, 36);
            this.LabelLines.Name = "LabelLines";
            this.LabelLines.Size = new System.Drawing.Size(40, 13);
            this.LabelLines.TabIndex = 3;
            this.LabelLines.Text = "Строк:";
            // 
            // numberOfLines
            // 
            this.numberOfLines.Location = new System.Drawing.Point(63, 34);
            this.numberOfLines.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberOfLines.Name = "numberOfLines";
            this.numberOfLines.ReadOnly = true;
            this.numberOfLines.Size = new System.Drawing.Size(63, 20);
            this.numberOfLines.TabIndex = 2;
            this.numberOfLines.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberOfLines.ValueChanged += new System.EventHandler(this.numberOfLines_ValueChanged);
            // 
            // LabelСolumns
            // 
            this.LabelСolumns.AutoSize = true;
            this.LabelСolumns.Location = new System.Drawing.Point(5, 10);
            this.LabelСolumns.Name = "LabelСolumns";
            this.LabelСolumns.Size = new System.Drawing.Size(58, 13);
            this.LabelСolumns.TabIndex = 2;
            this.LabelСolumns.Text = "Столбцов:";
            // 
            // numberOfСolumns
            // 
            this.numberOfСolumns.Location = new System.Drawing.Point(63, 8);
            this.numberOfСolumns.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberOfСolumns.Name = "numberOfСolumns";
            this.numberOfСolumns.ReadOnly = true;
            this.numberOfСolumns.Size = new System.Drawing.Size(63, 20);
            this.numberOfСolumns.TabIndex = 2;
            this.numberOfСolumns.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberOfСolumns.ValueChanged += new System.EventHandler(this.numberOfСolumns_ValueChanged);
            // 
            // loadMapPanel
            // 
            this.loadMapPanel.Controls.Add(this.loadMapIntoRobot);
            this.loadMapPanel.Controls.Add(this.createMap);
            this.loadMapPanel.Controls.Add(this.deleteMap);
            this.loadMapPanel.Controls.Add(this.button1);
            this.loadMapPanel.Controls.Add(this.selectTable);
            this.loadMapPanel.Location = new System.Drawing.Point(24, 12);
            this.loadMapPanel.Name = "loadMapPanel";
            this.loadMapPanel.Size = new System.Drawing.Size(504, 57);
            this.loadMapPanel.TabIndex = 1;
            // 
            // loadMapIntoRobot
            // 
            this.loadMapIntoRobot.Location = new System.Drawing.Point(362, 5);
            this.loadMapIntoRobot.Name = "loadMapIntoRobot";
            this.loadMapIntoRobot.Size = new System.Drawing.Size(132, 48);
            this.loadMapIntoRobot.TabIndex = 3;
            this.loadMapIntoRobot.Text = "Перейти к загрузке карты в робота";
            this.loadMapIntoRobot.UseVisualStyleBackColor = true;
            this.loadMapIntoRobot.Click += new System.EventHandler(this.loadMapIntoRobot_Click);
            // 
            // getDirections
            // 
            this.getDirections.Location = new System.Drawing.Point(3, 3);
            this.getDirections.Name = "getDirections";
            this.getDirections.Size = new System.Drawing.Size(120, 24);
            this.getDirections.TabIndex = 4;
            this.getDirections.Text = "Проложить маршрут";
            this.getDirections.UseVisualStyleBackColor = true;
            this.getDirections.Click += new System.EventHandler(this.getDirections_Click);
            // 
            // createMap
            // 
            this.createMap.Location = new System.Drawing.Point(264, 5);
            this.createMap.Name = "createMap";
            this.createMap.Size = new System.Drawing.Size(96, 23);
            this.createMap.TabIndex = 4;
            this.createMap.Text = "Создать";
            this.createMap.UseVisualStyleBackColor = true;
            this.createMap.Click += new System.EventHandler(this.createMap_Click);
            // 
            // deleteMap
            // 
            this.deleteMap.Location = new System.Drawing.Point(264, 30);
            this.deleteMap.Name = "deleteMap";
            this.deleteMap.Size = new System.Drawing.Size(96, 23);
            this.deleteMap.TabIndex = 3;
            this.deleteMap.Text = "Удалить";
            this.deleteMap.UseVisualStyleBackColor = true;
            this.deleteMap.Click += new System.EventHandler(this.deleteMap_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Редактировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // selectTable
            // 
            this.selectTable.FormattingEnabled = true;
            this.selectTable.Location = new System.Drawing.Point(3, 4);
            this.selectTable.Name = "selectTable";
            this.selectTable.Size = new System.Drawing.Size(153, 21);
            this.selectTable.TabIndex = 1;
            this.selectTable.Text = "Выберете карту";
            this.selectTable.SelectedIndexChanged += new System.EventHandler(this.selectTable_SelectedIndexChanged);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(24, 75);
            this.statusBar.Name = "statusBar";
            this.statusBar.ReadOnly = true;
            this.statusBar.Size = new System.Drawing.Size(298, 336);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "";
            // 
            // uploadRobotPanel
            // 
            this.uploadRobotPanel.Controls.Add(this.openMap2);
            this.uploadRobotPanel.Controls.Add(this.getDirections);
            this.uploadRobotPanel.Controls.Add(this.ComPortNumber);
            this.uploadRobotPanel.Controls.Add(this.Compound);
            this.uploadRobotPanel.Location = new System.Drawing.Point(328, 296);
            this.uploadRobotPanel.Name = "uploadRobotPanel";
            this.uploadRobotPanel.Size = new System.Drawing.Size(505, 56);
            this.uploadRobotPanel.TabIndex = 3;
            this.uploadRobotPanel.Visible = false;
            // 
            // Compound
            // 
            this.Compound.Location = new System.Drawing.Point(266, 3);
            this.Compound.Name = "Compound";
            this.Compound.Size = new System.Drawing.Size(120, 23);
            this.Compound.TabIndex = 5;
            this.Compound.Text = "Соединение";
            this.Compound.UseVisualStyleBackColor = true;
            this.Compound.Click += new System.EventHandler(this.Compound_Click);
            // 
            // ComPortNumber
            // 
            this.ComPortNumber.FormattingEnabled = true;
            this.ComPortNumber.Location = new System.Drawing.Point(139, 5);
            this.ComPortNumber.Name = "ComPortNumber";
            this.ComPortNumber.Size = new System.Drawing.Size(121, 21);
            this.ComPortNumber.TabIndex = 6;
            // 
            // openMap2
            // 
            this.openMap2.Location = new System.Drawing.Point(3, 30);
            this.openMap2.Name = "openMap2";
            this.openMap2.Size = new System.Drawing.Size(120, 23);
            this.openMap2.TabIndex = 7;
            this.openMap2.Text = "Открыть карту";
            this.openMap2.UseVisualStyleBackColor = true;
            this.openMap2.Click += new System.EventHandler(this.openMap2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(934, 436);
            this.Controls.Add(this.uploadRobotPanel);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.loadMapPanel);
            this.Controls.Add(this.createMapPanel);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Gray;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.createMapPanel.ResumeLayout(false);
            this.createMapPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfСolumns)).EndInit();
            this.loadMapPanel.ResumeLayout(false);
            this.uploadRobotPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel createMapPanel;
        private System.Windows.Forms.Label LabelLines;
        private System.Windows.Forms.NumericUpDown numberOfLines;
        private System.Windows.Forms.Label LabelСolumns;
        private System.Windows.Forms.NumericUpDown numberOfСolumns;
        private System.Windows.Forms.ComboBox robotPosition;
        private System.Windows.Forms.Label labelRobotPosition;
        private System.Windows.Forms.Button InstallOrRemoveRobot;
        private System.Windows.Forms.Panel loadMapPanel;
        private System.Windows.Forms.ComboBox selectTable;
        private System.Windows.Forms.Button saveMap;
        private System.Windows.Forms.TextBox mapName;
        private System.Windows.Forms.Label labelMapName;
        private System.Windows.Forms.Button openMap;
        private System.Windows.Forms.Button deleteMap;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button createMap;
        private System.Windows.Forms.Button setRemoveFinish;
        private System.Windows.Forms.Label labelFinish;
        private System.Windows.Forms.RichTextBox statusBar;
        private System.Windows.Forms.Button createMap2;
        private System.Windows.Forms.Button loadMapIntoRobot;
        private System.Windows.Forms.Panel uploadRobotPanel;
        private System.Windows.Forms.Button getDirections;
        private System.Windows.Forms.Button Compound;
        private System.Windows.Forms.ComboBox ComPortNumber;
        private System.Windows.Forms.Button openMap2;
    }
}

