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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ImageList imageList1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.createMapPanel = new System.Windows.Forms.Panel();
            this.createMap2 = new System.Windows.Forms.Button();
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
            this.labelMapSelect = new System.Windows.Forms.Label();
            this.loadMapIntoRobot = new System.Windows.Forms.Button();
            this.createMap = new System.Windows.Forms.Button();
            this.deleteMap = new System.Windows.Forms.Button();
            this.mapEdit = new System.Windows.Forms.Button();
            this.selectTable = new System.Windows.Forms.ComboBox();
            this.getDirections = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.RichTextBox();
            this.uploadRobotPanel = new System.Windows.Forms.Panel();
            this.labelComPortNumber = new System.Windows.Forms.Label();
            this.sendWayRobot = new System.Windows.Forms.Button();
            this.openMap2 = new System.Windows.Forms.Button();
            this.ComPortNumber = new System.Windows.Forms.ComboBox();
            this.Compound = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.RobotStop = new System.Windows.Forms.Button();
            imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.createMapPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfСolumns)).BeginInit();
            this.loadMapPanel.SuspendLayout();
            this.uploadRobotPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            imageList1.TransparentColor = System.Drawing.Color.Transparent;
            imageList1.Images.SetKeyName(0, "robot.png");
            imageList1.Images.SetKeyName(1, "robotDelete.png");
            imageList1.Images.SetKeyName(2, "start.png");
            imageList1.Images.SetKeyName(3, "startDelete.png");
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
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
            this.createMapPanel.Size = new System.Drawing.Size(690, 57);
            this.createMapPanel.TabIndex = 1;
            this.createMapPanel.Visible = false;
            // 
            // createMap2
            // 
            this.createMap2.Image = ((System.Drawing.Image)(resources.GetObject("createMap2.Image")));
            this.createMap2.Location = new System.Drawing.Point(535, 10);
            this.createMap2.Name = "createMap2";
            this.createMap2.Size = new System.Drawing.Size(44, 44);
            this.createMap2.TabIndex = 10;
            this.toolTip1.SetToolTip(this.createMap2, "Создать новую карту");
            this.createMap2.UseVisualStyleBackColor = true;
            this.createMap2.Click += new System.EventHandler(this.createMap2_Click);
            // 
            // setRemoveFinish
            // 
            this.setRemoveFinish.BackColor = System.Drawing.Color.Transparent;
            this.setRemoveFinish.ImageIndex = 2;
            this.setRemoveFinish.ImageList = imageList1;
            this.setRemoveFinish.Location = new System.Drawing.Point(423, 10);
            this.setRemoveFinish.Name = "setRemoveFinish";
            this.setRemoveFinish.Size = new System.Drawing.Size(44, 44);
            this.setRemoveFinish.TabIndex = 3;
            this.toolTip1.SetToolTip(this.setRemoveFinish, "Установить/убрать финиш");
            this.setRemoveFinish.UseVisualStyleBackColor = false;
            this.setRemoveFinish.Click += new System.EventHandler(this.setRemoveFinish_Click);
            // 
            // openMap
            // 
            this.openMap.Image = ((System.Drawing.Image)(resources.GetObject("openMap.Image")));
            this.openMap.Location = new System.Drawing.Point(585, 8);
            this.openMap.Name = "openMap";
            this.openMap.Size = new System.Drawing.Size(44, 44);
            this.openMap.TabIndex = 9;
            this.toolTip1.SetToolTip(this.openMap, "Перейти на панель выбора карт");
            this.openMap.UseMnemonic = false;
            this.openMap.UseVisualStyleBackColor = true;
            this.openMap.Click += new System.EventHandler(this.openMap_Click);
            // 
            // saveMap
            // 
            this.saveMap.BackColor = System.Drawing.Color.Transparent;
            this.saveMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveMap.Image = ((System.Drawing.Image)(resources.GetObject("saveMap.Image")));
            this.saveMap.Location = new System.Drawing.Point(635, 7);
            this.saveMap.Name = "saveMap";
            this.saveMap.Size = new System.Drawing.Size(44, 44);
            this.saveMap.TabIndex = 6;
            this.saveMap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.saveMap, "Сохранить карту");
            this.saveMap.UseVisualStyleBackColor = false;
            this.saveMap.Click += new System.EventHandler(this.saveMap_Click);
            // 
            // labelMapName
            // 
            this.labelMapName.AutoSize = true;
            this.labelMapName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelMapName.Location = new System.Drawing.Point(152, 37);
            this.labelMapName.Name = "labelMapName";
            this.labelMapName.Size = new System.Drawing.Size(94, 13);
            this.labelMapName.TabIndex = 8;
            this.labelMapName.Text = "Название карты:";
            // 
            // mapName
            // 
            this.mapName.Location = new System.Drawing.Point(249, 34);
            this.mapName.Name = "mapName";
            this.mapName.Size = new System.Drawing.Size(168, 20);
            this.mapName.TabIndex = 7;
            this.mapName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mapName_KeyPress);
            // 
            // InstallOrRemoveRobot
            // 
            this.InstallOrRemoveRobot.ImageIndex = 0;
            this.InstallOrRemoveRobot.ImageList = imageList1;
            this.InstallOrRemoveRobot.Location = new System.Drawing.Point(473, 10);
            this.InstallOrRemoveRobot.Name = "InstallOrRemoveRobot";
            this.InstallOrRemoveRobot.Size = new System.Drawing.Size(44, 44);
            this.InstallOrRemoveRobot.TabIndex = 5;
            this.toolTip1.SetToolTip(this.InstallOrRemoveRobot, "Установить/убрать робота с карты");
            this.InstallOrRemoveRobot.UseVisualStyleBackColor = true;
            this.InstallOrRemoveRobot.Click += new System.EventHandler(this.InstallOrRemoveRobot_Click);
            // 
            // labelRobotPosition
            // 
            this.labelRobotPosition.AutoSize = true;
            this.labelRobotPosition.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelRobotPosition.Location = new System.Drawing.Point(140, 10);
            this.labelRobotPosition.Name = "labelRobotPosition";
            this.labelRobotPosition.Size = new System.Drawing.Size(106, 13);
            this.labelRobotPosition.TabIndex = 2;
            this.labelRobotPosition.Text = "Положение робота:";
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
            this.robotPosition.Location = new System.Drawing.Point(249, 7);
            this.robotPosition.Name = "robotPosition";
            this.robotPosition.Size = new System.Drawing.Size(40, 22);
            this.robotPosition.TabIndex = 4;
            // 
            // LabelLines
            // 
            this.LabelLines.AutoSize = true;
            this.LabelLines.ForeColor = System.Drawing.SystemColors.ControlLightLight;
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
            this.LabelСolumns.ForeColor = System.Drawing.SystemColors.ControlLightLight;
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
            this.loadMapPanel.Controls.Add(this.labelMapSelect);
            this.loadMapPanel.Controls.Add(this.loadMapIntoRobot);
            this.loadMapPanel.Controls.Add(this.createMap);
            this.loadMapPanel.Controls.Add(this.deleteMap);
            this.loadMapPanel.Controls.Add(this.mapEdit);
            this.loadMapPanel.Controls.Add(this.selectTable);
            this.loadMapPanel.Location = new System.Drawing.Point(733, 12);
            this.loadMapPanel.Name = "loadMapPanel";
            this.loadMapPanel.Size = new System.Drawing.Size(383, 57);
            this.loadMapPanel.TabIndex = 1;
            // 
            // labelMapSelect
            // 
            this.labelMapSelect.AutoSize = true;
            this.labelMapSelect.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelMapSelect.Location = new System.Drawing.Point(3, 7);
            this.labelMapSelect.Name = "labelMapSelect";
            this.labelMapSelect.Size = new System.Drawing.Size(91, 13);
            this.labelMapSelect.TabIndex = 5;
            this.labelMapSelect.Text = "Выберете карту:";
            // 
            // loadMapIntoRobot
            // 
            this.loadMapIntoRobot.Image = ((System.Drawing.Image)(resources.GetObject("loadMapIntoRobot.Image")));
            this.loadMapIntoRobot.Location = new System.Drawing.Point(316, 10);
            this.loadMapIntoRobot.Name = "loadMapIntoRobot";
            this.loadMapIntoRobot.Size = new System.Drawing.Size(44, 44);
            this.loadMapIntoRobot.TabIndex = 3;
            this.toolTip1.SetToolTip(this.loadMapIntoRobot, "Перейти к загрузке карты в робота");
            this.loadMapIntoRobot.UseVisualStyleBackColor = true;
            this.loadMapIntoRobot.Click += new System.EventHandler(this.loadMapIntoRobot_Click);
            // 
            // createMap
            // 
            this.createMap.Image = ((System.Drawing.Image)(resources.GetObject("createMap.Image")));
            this.createMap.Location = new System.Drawing.Point(216, 10);
            this.createMap.Name = "createMap";
            this.createMap.Size = new System.Drawing.Size(44, 44);
            this.createMap.TabIndex = 4;
            this.toolTip1.SetToolTip(this.createMap, "Перейти на панель создания карты");
            this.createMap.UseVisualStyleBackColor = true;
            this.createMap.Click += new System.EventHandler(this.createMap_Click);
            // 
            // deleteMap
            // 
            this.deleteMap.Image = ((System.Drawing.Image)(resources.GetObject("deleteMap.Image")));
            this.deleteMap.Location = new System.Drawing.Point(266, 10);
            this.deleteMap.Name = "deleteMap";
            this.deleteMap.Size = new System.Drawing.Size(44, 44);
            this.deleteMap.TabIndex = 3;
            this.toolTip1.SetToolTip(this.deleteMap, "Удалить карту");
            this.deleteMap.UseVisualStyleBackColor = true;
            this.deleteMap.Click += new System.EventHandler(this.deleteMap_Click);
            // 
            // mapEdit
            // 
            this.mapEdit.Image = ((System.Drawing.Image)(resources.GetObject("mapEdit.Image")));
            this.mapEdit.Location = new System.Drawing.Point(166, 10);
            this.mapEdit.Name = "mapEdit";
            this.mapEdit.Size = new System.Drawing.Size(44, 44);
            this.mapEdit.TabIndex = 2;
            this.toolTip1.SetToolTip(this.mapEdit, "Перейти на панель редактирования карты");
            this.mapEdit.UseVisualStyleBackColor = true;
            this.mapEdit.Click += new System.EventHandler(this.mapEdit_Click);
            // 
            // selectTable
            // 
            this.selectTable.FormattingEnabled = true;
            this.selectTable.Location = new System.Drawing.Point(3, 23);
            this.selectTable.Name = "selectTable";
            this.selectTable.Size = new System.Drawing.Size(153, 21);
            this.selectTable.TabIndex = 1;
            this.selectTable.Text = "Выберете карту";
            this.selectTable.SelectedIndexChanged += new System.EventHandler(this.selectTable_SelectedIndexChanged);
            // 
            // getDirections
            // 
            this.getDirections.Image = ((System.Drawing.Image)(resources.GetObject("getDirections.Image")));
            this.getDirections.Location = new System.Drawing.Point(57, 9);
            this.getDirections.Name = "getDirections";
            this.getDirections.Size = new System.Drawing.Size(44, 44);
            this.getDirections.TabIndex = 4;
            this.toolTip1.SetToolTip(this.getDirections, "Проложить маршрут");
            this.getDirections.UseVisualStyleBackColor = true;
            this.getDirections.Click += new System.EventHandler(this.getDirections_Click);
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
            this.uploadRobotPanel.Controls.Add(this.RobotStop);
            this.uploadRobotPanel.Controls.Add(this.labelComPortNumber);
            this.uploadRobotPanel.Controls.Add(this.sendWayRobot);
            this.uploadRobotPanel.Controls.Add(this.openMap2);
            this.uploadRobotPanel.Controls.Add(this.getDirections);
            this.uploadRobotPanel.Controls.Add(this.ComPortNumber);
            this.uploadRobotPanel.Controls.Add(this.Compound);
            this.uploadRobotPanel.Location = new System.Drawing.Point(331, 355);
            this.uploadRobotPanel.Name = "uploadRobotPanel";
            this.uploadRobotPanel.Size = new System.Drawing.Size(612, 56);
            this.uploadRobotPanel.TabIndex = 3;
            this.uploadRobotPanel.Visible = false;
            // 
            // labelComPortNumber
            // 
            this.labelComPortNumber.AutoSize = true;
            this.labelComPortNumber.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelComPortNumber.Location = new System.Drawing.Point(451, 16);
            this.labelComPortNumber.Name = "labelComPortNumber";
            this.labelComPortNumber.Size = new System.Drawing.Size(100, 13);
            this.labelComPortNumber.TabIndex = 9;
            this.labelComPortNumber.Text = "Номер Com порта:";
            // 
            // sendWayRobot
            // 
            this.sendWayRobot.Image = ((System.Drawing.Image)(resources.GetObject("sendWayRobot.Image")));
            this.sendWayRobot.Location = new System.Drawing.Point(107, 9);
            this.sendWayRobot.Name = "sendWayRobot";
            this.sendWayRobot.Size = new System.Drawing.Size(44, 44);
            this.sendWayRobot.TabIndex = 8;
            this.toolTip1.SetToolTip(this.sendWayRobot, "Отправить маршрут роботу");
            this.sendWayRobot.UseVisualStyleBackColor = true;
            this.sendWayRobot.Click += new System.EventHandler(this.sendWayRobot_Click);
            // 
            // openMap2
            // 
            this.openMap2.Image = ((System.Drawing.Image)(resources.GetObject("openMap2.Image")));
            this.openMap2.Location = new System.Drawing.Point(7, 9);
            this.openMap2.Name = "openMap2";
            this.openMap2.Size = new System.Drawing.Size(44, 44);
            this.openMap2.TabIndex = 7;
            this.toolTip1.SetToolTip(this.openMap2, "Открыть другую карту");
            this.openMap2.UseVisualStyleBackColor = true;
            this.openMap2.Click += new System.EventHandler(this.openMap2_Click);
            // 
            // ComPortNumber
            // 
            this.ComPortNumber.FormattingEnabled = true;
            this.ComPortNumber.Location = new System.Drawing.Point(451, 32);
            this.ComPortNumber.Name = "ComPortNumber";
            this.ComPortNumber.Size = new System.Drawing.Size(121, 21);
            this.ComPortNumber.TabIndex = 6;
            // 
            // Compound
            // 
            this.Compound.Image = ((System.Drawing.Image)(resources.GetObject("Compound.Image")));
            this.Compound.Location = new System.Drawing.Point(401, 12);
            this.Compound.Name = "Compound";
            this.Compound.Size = new System.Drawing.Size(44, 44);
            this.Compound.TabIndex = 5;
            this.toolTip1.SetToolTip(this.Compound, "Установить соединение");
            this.Compound.UseVisualStyleBackColor = true;
            this.Compound.Click += new System.EventHandler(this.Compound_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 800;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // RobotStop
            // 
            this.RobotStop.Enabled = false;
            this.RobotStop.Image = ((System.Drawing.Image)(resources.GetObject("RobotStop.Image")));
            this.RobotStop.Location = new System.Drawing.Point(207, 9);
            this.RobotStop.Name = "RobotStop";
            this.RobotStop.Size = new System.Drawing.Size(44, 44);
            this.RobotStop.TabIndex = 10;
            this.toolTip1.SetToolTip(this.RobotStop, "Остановить робота");
            this.RobotStop.UseVisualStyleBackColor = true;
            this.RobotStop.Click += new System.EventHandler(this.RobotStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1159, 436);
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
            this.loadMapPanel.PerformLayout();
            this.uploadRobotPanel.ResumeLayout(false);
            this.uploadRobotPanel.PerformLayout();
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
        private System.Windows.Forms.Button mapEdit;
        private System.Windows.Forms.Button createMap;
        private System.Windows.Forms.Button setRemoveFinish;
        private System.Windows.Forms.RichTextBox statusBar;
        private System.Windows.Forms.Button createMap2;
        private System.Windows.Forms.Button loadMapIntoRobot;
        private System.Windows.Forms.Panel uploadRobotPanel;
        private System.Windows.Forms.Button getDirections;
        private System.Windows.Forms.Button Compound;
        private System.Windows.Forms.ComboBox ComPortNumber;
        private System.Windows.Forms.Button openMap2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button sendWayRobot;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelComPortNumber;
        private System.Windows.Forms.Label labelMapSelect;
        private System.Windows.Forms.Button RobotStop;
    }
}

