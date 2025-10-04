namespace Simple_randomizer_SoC.Forms.Tabs
{
    partial class NpcTab
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.rootContentPanel = new System.Windows.Forms.Panel();
            this.mainContentPanel = new System.Windows.Forms.TableLayoutPanel();
            this.topPanel = new System.Windows.Forms.TableLayoutPanel();
            this.exceptionsLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.minMoneyInput = new System.Windows.Forms.NumericUpDown();
            this.minMoneyLabel = new System.Windows.Forms.Label();
            this.maxMoneyInput = new System.Windows.Forms.NumericUpDown();
            this.maxMoneyLabel = new System.Windows.Forms.Label();
            this.moneyCheckBox = new System.Windows.Forms.CheckBox();
            this.rankCheckBox = new System.Windows.Forms.CheckBox();
            this.keepSupplieButton = new System.Windows.Forms.Button();
            this.singleWeaponCheckBox = new System.Windows.Forms.CheckBox();
            this.additionalWeaponButton = new System.Windows.Forms.Button();
            this.additionalWeaponCheckBox = new System.Windows.Forms.CheckBox();
            this.mainWeaponButton = new System.Windows.Forms.Button();
            this.mainWeaponCheckBox = new System.Windows.Forms.CheckBox();
            this.communityCheckBox = new System.Windows.Forms.CheckBox();
            this.uniqueNameCheckBox = new System.Windows.Forms.CheckBox();
            this.generateNameCheckBox = new System.Windows.Forms.CheckBox();
            this.iconCheckBox = new System.Windows.Forms.CheckBox();
            this.soundCheckBox = new System.Windows.Forms.CheckBox();
            this.exceptionButton = new System.Windows.Forms.Button();
            this.communityButton = new System.Windows.Forms.Button();
            this.uniqueNameButton = new System.Windows.Forms.Button();
            this.generateNameButton = new System.Windows.Forms.Button();
            this.iconButton = new System.Windows.Forms.Button();
            this.modelButon = new System.Windows.Forms.Button();
            this.soundButton = new System.Windows.Forms.Button();
            this.modelCheckBox = new System.Windows.Forms.CheckBox();
            this.extendCampCheckBox = new System.Windows.Forms.CheckBox();
            this.keepSupplieLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.minRankInput = new System.Windows.Forms.NumericUpDown();
            this.minRankLabel = new System.Windows.Forms.Label();
            this.maxRankInput = new System.Windows.Forms.NumericUpDown();
            this.maxRankLabel = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.TableLayoutPanel();
            this.probabilityLabel = new System.Windows.Forms.Label();
            this.npcProbabilityInput = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.rootContentPanel.SuspendLayout();
            this.mainContentPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minMoneyInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxMoneyInput)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minRankInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRankInput)).BeginInit();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npcProbabilityInput)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.titleLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rootContentPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(513, 381);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Padding = new System.Windows.Forms.Padding(3);
            this.titleLabel.Size = new System.Drawing.Size(513, 26);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Настройка генерации НПС";
            // 
            // rootContentPanel
            // 
            this.rootContentPanel.Controls.Add(this.mainContentPanel);
            this.rootContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootContentPanel.Location = new System.Drawing.Point(3, 29);
            this.rootContentPanel.Name = "rootContentPanel";
            this.rootContentPanel.Size = new System.Drawing.Size(507, 349);
            this.rootContentPanel.TabIndex = 3;
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.AutoScroll = true;
            this.mainContentPanel.AutoSize = true;
            this.mainContentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainContentPanel.ColumnCount = 1;
            this.mainContentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mainContentPanel.Controls.Add(this.topPanel, 0, 0);
            this.mainContentPanel.Controls.Add(this.bottomPanel, 0, 1);
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(0, 0);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.RowCount = 2;
            this.mainContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainContentPanel.Size = new System.Drawing.Size(507, 349);
            this.mainContentPanel.TabIndex = 3;
            // 
            // topPanel
            // 
            this.topPanel.AutoSize = true;
            this.topPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.topPanel.ColumnCount = 2;
            this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topPanel.Controls.Add(this.exceptionsLabel, 0, 6);
            this.topPanel.Controls.Add(this.tableLayoutPanel3, 1, 13);
            this.topPanel.Controls.Add(this.moneyCheckBox, 0, 13);
            this.topPanel.Controls.Add(this.rankCheckBox, 0, 12);
            this.topPanel.Controls.Add(this.keepSupplieButton, 1, 10);
            this.topPanel.Controls.Add(this.singleWeaponCheckBox, 0, 9);
            this.topPanel.Controls.Add(this.additionalWeaponButton, 1, 8);
            this.topPanel.Controls.Add(this.additionalWeaponCheckBox, 0, 8);
            this.topPanel.Controls.Add(this.mainWeaponButton, 1, 7);
            this.topPanel.Controls.Add(this.mainWeaponCheckBox, 0, 7);
            this.topPanel.Controls.Add(this.communityCheckBox, 0, 5);
            this.topPanel.Controls.Add(this.uniqueNameCheckBox, 0, 4);
            this.topPanel.Controls.Add(this.generateNameCheckBox, 0, 3);
            this.topPanel.Controls.Add(this.iconCheckBox, 0, 2);
            this.topPanel.Controls.Add(this.soundCheckBox, 0, 1);
            this.topPanel.Controls.Add(this.exceptionButton, 1, 6);
            this.topPanel.Controls.Add(this.communityButton, 1, 5);
            this.topPanel.Controls.Add(this.uniqueNameButton, 1, 4);
            this.topPanel.Controls.Add(this.generateNameButton, 1, 3);
            this.topPanel.Controls.Add(this.iconButton, 1, 2);
            this.topPanel.Controls.Add(this.modelButon, 1, 0);
            this.topPanel.Controls.Add(this.soundButton, 1, 1);
            this.topPanel.Controls.Add(this.modelCheckBox, 0, 0);
            this.topPanel.Controls.Add(this.extendCampCheckBox, 0, 11);
            this.topPanel.Controls.Add(this.keepSupplieLabel, 0, 10);
            this.topPanel.Controls.Add(this.tableLayoutPanel2, 1, 12);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(0);
            this.topPanel.Name = "topPanel";
            this.topPanel.RowCount = 14;
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.Size = new System.Drawing.Size(545, 388);
            this.topPanel.TabIndex = 0;
            // 
            // exceptionsLabel
            // 
            this.exceptionsLabel.AutoSize = true;
            this.exceptionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exceptionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exceptionsLabel.Location = new System.Drawing.Point(3, 174);
            this.exceptionsLabel.Name = "exceptionsLabel";
            this.exceptionsLabel.Size = new System.Drawing.Size(189, 29);
            this.exceptionsLabel.TabIndex = 80;
            this.exceptionsLabel.Text = "Исключения";
            this.exceptionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.minMoneyInput, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.minMoneyLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.maxMoneyInput, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.maxMoneyLabel, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(195, 362);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(350, 26);
            this.tableLayoutPanel3.TabIndex = 79;
            // 
            // minMoneyInput
            // 
            this.minMoneyInput.Location = new System.Drawing.Point(90, 3);
            this.minMoneyInput.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.minMoneyInput.Name = "minMoneyInput";
            this.minMoneyInput.Size = new System.Drawing.Size(79, 20);
            this.minMoneyInput.TabIndex = 0;
            this.minMoneyInput.ValueChanged += new System.EventHandler(this.minMoneyInput_ValueChanged);
            // 
            // minMoneyLabel
            // 
            this.minMoneyLabel.AutoSize = true;
            this.minMoneyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minMoneyLabel.Location = new System.Drawing.Point(3, 0);
            this.minMoneyLabel.Name = "minMoneyLabel";
            this.minMoneyLabel.Size = new System.Drawing.Size(81, 26);
            this.minMoneyLabel.TabIndex = 2;
            this.minMoneyLabel.Text = "Мин. значение";
            this.minMoneyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maxMoneyInput
            // 
            this.maxMoneyInput.Location = new System.Drawing.Point(268, 3);
            this.maxMoneyInput.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.maxMoneyInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxMoneyInput.Name = "maxMoneyInput";
            this.maxMoneyInput.Size = new System.Drawing.Size(79, 20);
            this.maxMoneyInput.TabIndex = 1;
            this.maxMoneyInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxMoneyInput.ValueChanged += new System.EventHandler(this.maxMoneyInput_ValueChanged);
            // 
            // maxMoneyLabel
            // 
            this.maxMoneyLabel.AutoSize = true;
            this.maxMoneyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maxMoneyLabel.Location = new System.Drawing.Point(175, 0);
            this.maxMoneyLabel.Name = "maxMoneyLabel";
            this.maxMoneyLabel.Size = new System.Drawing.Size(87, 26);
            this.maxMoneyLabel.TabIndex = 3;
            this.maxMoneyLabel.Text = "Макс. значение";
            this.maxMoneyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // moneyCheckBox
            // 
            this.moneyCheckBox.AutoSize = true;
            this.moneyCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moneyCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.moneyCheckBox.Location = new System.Drawing.Point(3, 365);
            this.moneyCheckBox.Name = "moneyCheckBox";
            this.moneyCheckBox.Size = new System.Drawing.Size(189, 20);
            this.moneyCheckBox.TabIndex = 77;
            this.moneyCheckBox.Text = "Деньги";
            this.moneyCheckBox.UseVisualStyleBackColor = true;
            this.moneyCheckBox.CheckedChanged += new System.EventHandler(this.moneyCheckBox_CheckedChanged);
            // 
            // rankCheckBox
            // 
            this.rankCheckBox.AutoSize = true;
            this.rankCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rankCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rankCheckBox.Location = new System.Drawing.Point(3, 339);
            this.rankCheckBox.Name = "rankCheckBox";
            this.rankCheckBox.Size = new System.Drawing.Size(189, 20);
            this.rankCheckBox.TabIndex = 75;
            this.rankCheckBox.Text = "Ранг";
            this.rankCheckBox.UseVisualStyleBackColor = true;
            this.rankCheckBox.CheckedChanged += new System.EventHandler(this.rankCheckBox_CheckedChanged);
            // 
            // keepSupplieButton
            // 
            this.keepSupplieButton.Location = new System.Drawing.Point(198, 287);
            this.keepSupplieButton.Name = "keepSupplieButton";
            this.keepSupplieButton.Size = new System.Drawing.Size(154, 23);
            this.keepSupplieButton.TabIndex = 73;
            this.keepSupplieButton.Text = "Редактировать список";
            this.keepSupplieButton.UseVisualStyleBackColor = true;
            this.keepSupplieButton.Click += new System.EventHandler(this.keepSupplieButton_Click);
            // 
            // singleWeaponCheckBox
            // 
            this.singleWeaponCheckBox.AutoSize = true;
            this.topPanel.SetColumnSpan(this.singleWeaponCheckBox, 2);
            this.singleWeaponCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.singleWeaponCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.singleWeaponCheckBox.Location = new System.Drawing.Point(3, 264);
            this.singleWeaponCheckBox.Name = "singleWeaponCheckBox";
            this.singleWeaponCheckBox.Size = new System.Drawing.Size(539, 17);
            this.singleWeaponCheckBox.TabIndex = 71;
            this.singleWeaponCheckBox.Text = "Использовать одно случайное оружие из обоих списков";
            this.singleWeaponCheckBox.UseVisualStyleBackColor = true;
            this.singleWeaponCheckBox.CheckedChanged += new System.EventHandler(this.singleWeaponCheckBox_CheckedChanged);
            // 
            // additionalWeaponButton
            // 
            this.additionalWeaponButton.Location = new System.Drawing.Point(198, 235);
            this.additionalWeaponButton.Name = "additionalWeaponButton";
            this.additionalWeaponButton.Size = new System.Drawing.Size(154, 23);
            this.additionalWeaponButton.TabIndex = 70;
            this.additionalWeaponButton.Text = "Редактировать список";
            this.additionalWeaponButton.UseVisualStyleBackColor = true;
            this.additionalWeaponButton.Click += new System.EventHandler(this.additionalWeaponButton_Click);
            // 
            // additionalWeaponCheckBox
            // 
            this.additionalWeaponCheckBox.AutoSize = true;
            this.additionalWeaponCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.additionalWeaponCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.additionalWeaponCheckBox.Location = new System.Drawing.Point(3, 235);
            this.additionalWeaponCheckBox.Name = "additionalWeaponCheckBox";
            this.additionalWeaponCheckBox.Size = new System.Drawing.Size(189, 23);
            this.additionalWeaponCheckBox.TabIndex = 69;
            this.additionalWeaponCheckBox.Text = "Дополнительное оружие";
            this.additionalWeaponCheckBox.UseVisualStyleBackColor = true;
            this.additionalWeaponCheckBox.CheckedChanged += new System.EventHandler(this.additionalWeaponCheckBox_CheckedChanged);
            // 
            // mainWeaponButton
            // 
            this.mainWeaponButton.Location = new System.Drawing.Point(198, 206);
            this.mainWeaponButton.Name = "mainWeaponButton";
            this.mainWeaponButton.Size = new System.Drawing.Size(154, 23);
            this.mainWeaponButton.TabIndex = 68;
            this.mainWeaponButton.Text = "Редактировать список";
            this.mainWeaponButton.UseVisualStyleBackColor = true;
            this.mainWeaponButton.Click += new System.EventHandler(this.mainWeaponButton_Click);
            // 
            // mainWeaponCheckBox
            // 
            this.mainWeaponCheckBox.AutoSize = true;
            this.mainWeaponCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWeaponCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainWeaponCheckBox.Location = new System.Drawing.Point(3, 206);
            this.mainWeaponCheckBox.Name = "mainWeaponCheckBox";
            this.mainWeaponCheckBox.Size = new System.Drawing.Size(189, 23);
            this.mainWeaponCheckBox.TabIndex = 67;
            this.mainWeaponCheckBox.Text = "Основное оружие";
            this.mainWeaponCheckBox.UseVisualStyleBackColor = true;
            this.mainWeaponCheckBox.CheckedChanged += new System.EventHandler(this.mainWeaponCheckBox_CheckedChanged);
            // 
            // communityCheckBox
            // 
            this.communityCheckBox.AutoSize = true;
            this.communityCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.communityCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.communityCheckBox.Location = new System.Drawing.Point(3, 148);
            this.communityCheckBox.Name = "communityCheckBox";
            this.communityCheckBox.Size = new System.Drawing.Size(189, 23);
            this.communityCheckBox.TabIndex = 61;
            this.communityCheckBox.Text = "Группировки";
            this.communityCheckBox.UseVisualStyleBackColor = true;
            this.communityCheckBox.CheckedChanged += new System.EventHandler(this.communityCheckBox_CheckedChanged);
            // 
            // uniqueNameCheckBox
            // 
            this.uniqueNameCheckBox.AutoSize = true;
            this.uniqueNameCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uniqueNameCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uniqueNameCheckBox.Location = new System.Drawing.Point(3, 119);
            this.uniqueNameCheckBox.Name = "uniqueNameCheckBox";
            this.uniqueNameCheckBox.Size = new System.Drawing.Size(189, 23);
            this.uniqueNameCheckBox.TabIndex = 60;
            this.uniqueNameCheckBox.Text = "Уникальные имена";
            this.uniqueNameCheckBox.UseVisualStyleBackColor = true;
            this.uniqueNameCheckBox.CheckedChanged += new System.EventHandler(this.uniqueNameCheckBox_CheckedChanged);
            // 
            // generateNameCheckBox
            // 
            this.generateNameCheckBox.AutoSize = true;
            this.generateNameCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generateNameCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateNameCheckBox.Location = new System.Drawing.Point(3, 90);
            this.generateNameCheckBox.Name = "generateNameCheckBox";
            this.generateNameCheckBox.Size = new System.Drawing.Size(189, 23);
            this.generateNameCheckBox.TabIndex = 59;
            this.generateNameCheckBox.Text = "Генерируемые имена";
            this.generateNameCheckBox.UseVisualStyleBackColor = true;
            this.generateNameCheckBox.CheckedChanged += new System.EventHandler(this.generateNameCheckBox_CheckedChanged);
            // 
            // iconCheckBox
            // 
            this.iconCheckBox.AutoSize = true;
            this.iconCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iconCheckBox.Location = new System.Drawing.Point(3, 61);
            this.iconCheckBox.Name = "iconCheckBox";
            this.iconCheckBox.Size = new System.Drawing.Size(189, 23);
            this.iconCheckBox.TabIndex = 58;
            this.iconCheckBox.Text = "Миниатюры";
            this.iconCheckBox.UseVisualStyleBackColor = true;
            // 
            // soundCheckBox
            // 
            this.soundCheckBox.AutoSize = true;
            this.soundCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soundCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.soundCheckBox.Location = new System.Drawing.Point(3, 32);
            this.soundCheckBox.Name = "soundCheckBox";
            this.soundCheckBox.Size = new System.Drawing.Size(189, 23);
            this.soundCheckBox.TabIndex = 57;
            this.soundCheckBox.Text = "Озвучка";
            this.soundCheckBox.UseVisualStyleBackColor = true;
            // 
            // exceptionButton
            // 
            this.exceptionButton.Location = new System.Drawing.Point(198, 177);
            this.exceptionButton.Name = "exceptionButton";
            this.exceptionButton.Size = new System.Drawing.Size(154, 23);
            this.exceptionButton.TabIndex = 55;
            this.exceptionButton.Text = "Редактировать список";
            this.exceptionButton.UseVisualStyleBackColor = true;
            this.exceptionButton.Click += new System.EventHandler(this.exceptionButton_Click);
            // 
            // communityButton
            // 
            this.communityButton.Location = new System.Drawing.Point(198, 148);
            this.communityButton.Name = "communityButton";
            this.communityButton.Size = new System.Drawing.Size(154, 23);
            this.communityButton.TabIndex = 54;
            this.communityButton.Text = "Редактировать список";
            this.communityButton.UseVisualStyleBackColor = true;
            this.communityButton.Click += new System.EventHandler(this.communityButton_Click);
            // 
            // uniqueNameButton
            // 
            this.uniqueNameButton.Location = new System.Drawing.Point(198, 119);
            this.uniqueNameButton.Name = "uniqueNameButton";
            this.uniqueNameButton.Size = new System.Drawing.Size(154, 23);
            this.uniqueNameButton.TabIndex = 53;
            this.uniqueNameButton.Text = "Редактировать список";
            this.uniqueNameButton.UseVisualStyleBackColor = true;
            this.uniqueNameButton.Click += new System.EventHandler(this.uniqueNameButton_Click);
            // 
            // generateNameButton
            // 
            this.generateNameButton.Location = new System.Drawing.Point(198, 90);
            this.generateNameButton.Name = "generateNameButton";
            this.generateNameButton.Size = new System.Drawing.Size(154, 23);
            this.generateNameButton.TabIndex = 52;
            this.generateNameButton.Text = "Редактировать список";
            this.generateNameButton.UseVisualStyleBackColor = true;
            this.generateNameButton.Click += new System.EventHandler(this.generateNameButton_Click);
            // 
            // iconButton
            // 
            this.iconButton.Location = new System.Drawing.Point(198, 61);
            this.iconButton.Name = "iconButton";
            this.iconButton.Size = new System.Drawing.Size(154, 23);
            this.iconButton.TabIndex = 51;
            this.iconButton.Text = "Редактировать список";
            this.iconButton.UseVisualStyleBackColor = true;
            this.iconButton.Click += new System.EventHandler(this.iconButton_Click);
            // 
            // modelButon
            // 
            this.modelButon.Location = new System.Drawing.Point(198, 3);
            this.modelButon.Name = "modelButon";
            this.modelButon.Size = new System.Drawing.Size(154, 23);
            this.modelButon.TabIndex = 32;
            this.modelButon.Text = "Редактировать список";
            this.modelButon.UseVisualStyleBackColor = true;
            this.modelButon.Click += new System.EventHandler(this.modelButton_Click);
            // 
            // soundButton
            // 
            this.soundButton.Location = new System.Drawing.Point(198, 32);
            this.soundButton.Name = "soundButton";
            this.soundButton.Size = new System.Drawing.Size(154, 23);
            this.soundButton.TabIndex = 33;
            this.soundButton.Text = "Редактировать список";
            this.soundButton.UseVisualStyleBackColor = true;
            this.soundButton.Click += new System.EventHandler(this.soundButton_Click);
            // 
            // modelCheckBox
            // 
            this.modelCheckBox.AutoSize = true;
            this.modelCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.modelCheckBox.Location = new System.Drawing.Point(3, 3);
            this.modelCheckBox.Name = "modelCheckBox";
            this.modelCheckBox.Size = new System.Drawing.Size(189, 23);
            this.modelCheckBox.TabIndex = 56;
            this.modelCheckBox.Text = "Модели";
            this.modelCheckBox.UseVisualStyleBackColor = true;
            // 
            // extendCampCheckBox
            // 
            this.extendCampCheckBox.AutoSize = true;
            this.topPanel.SetColumnSpan(this.extendCampCheckBox, 2);
            this.extendCampCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extendCampCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.extendCampCheckBox.Location = new System.Drawing.Point(3, 316);
            this.extendCampCheckBox.Name = "extendCampCheckBox";
            this.extendCampCheckBox.Size = new System.Drawing.Size(539, 17);
            this.extendCampCheckBox.TabIndex = 66;
            this.extendCampCheckBox.Text = "Расширить присоединение НПС к лагерям (ломает некоторые скрипты)";
            this.extendCampCheckBox.UseVisualStyleBackColor = true;
            this.extendCampCheckBox.CheckedChanged += new System.EventHandler(this.extendCampCheckBox_CheckedChanged);
            // 
            // keepSupplieLabel
            // 
            this.keepSupplieLabel.AutoSize = true;
            this.keepSupplieLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keepSupplieLabel.Location = new System.Drawing.Point(3, 284);
            this.keepSupplieLabel.Name = "keepSupplieLabel";
            this.keepSupplieLabel.Size = new System.Drawing.Size(189, 29);
            this.keepSupplieLabel.TabIndex = 74;
            this.keepSupplieLabel.Text = "Предметы, которые не нужно\r\nубирать у НПС при генерации";
            this.keepSupplieLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.minRankInput, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.minRankLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.maxRankInput, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.maxRankLabel, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(195, 336);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(350, 26);
            this.tableLayoutPanel2.TabIndex = 78;
            // 
            // minRankInput
            // 
            this.minRankInput.Location = new System.Drawing.Point(90, 3);
            this.minRankInput.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.minRankInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minRankInput.Name = "minRankInput";
            this.minRankInput.Size = new System.Drawing.Size(79, 20);
            this.minRankInput.TabIndex = 0;
            this.minRankInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minRankInput.ValueChanged += new System.EventHandler(this.minRankInput_ValueChanged);
            // 
            // minRankLabel
            // 
            this.minRankLabel.AutoSize = true;
            this.minRankLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minRankLabel.Location = new System.Drawing.Point(3, 0);
            this.minRankLabel.Name = "minRankLabel";
            this.minRankLabel.Size = new System.Drawing.Size(81, 26);
            this.minRankLabel.TabIndex = 2;
            this.minRankLabel.Text = "Мин. значение";
            this.minRankLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maxRankInput
            // 
            this.maxRankInput.Location = new System.Drawing.Point(268, 3);
            this.maxRankInput.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.maxRankInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxRankInput.Name = "maxRankInput";
            this.maxRankInput.Size = new System.Drawing.Size(79, 20);
            this.maxRankInput.TabIndex = 1;
            this.maxRankInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxRankInput.ValueChanged += new System.EventHandler(this.maxRankInput_ValueChanged);
            // 
            // maxRankLabel
            // 
            this.maxRankLabel.AutoSize = true;
            this.maxRankLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maxRankLabel.Location = new System.Drawing.Point(175, 0);
            this.maxRankLabel.Name = "maxRankLabel";
            this.maxRankLabel.Size = new System.Drawing.Size(87, 26);
            this.maxRankLabel.TabIndex = 3;
            this.maxRankLabel.Text = "Макс. значение";
            this.maxRankLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bottomPanel
            // 
            this.bottomPanel.AutoSize = true;
            this.bottomPanel.ColumnCount = 2;
            this.bottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.bottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bottomPanel.Controls.Add(this.probabilityLabel, 1, 2);
            this.bottomPanel.Controls.Add(this.npcProbabilityInput, 0, 2);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottomPanel.Location = new System.Drawing.Point(0, 388);
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.RowCount = 1;
            this.bottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bottomPanel.Size = new System.Drawing.Size(545, 26);
            this.bottomPanel.TabIndex = 1;
            // 
            // probabilityLabel
            // 
            this.probabilityLabel.AutoSize = true;
            this.probabilityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.probabilityLabel.Location = new System.Drawing.Point(62, 0);
            this.probabilityLabel.Name = "probabilityLabel";
            this.probabilityLabel.Size = new System.Drawing.Size(480, 26);
            this.probabilityLabel.TabIndex = 51;
            this.probabilityLabel.Text = "Вероятность генерации каждого параметра НПС";
            this.probabilityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // npcProbabilityInput
            // 
            this.npcProbabilityInput.Location = new System.Drawing.Point(3, 3);
            this.npcProbabilityInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.npcProbabilityInput.Name = "npcProbabilityInput";
            this.npcProbabilityInput.Size = new System.Drawing.Size(53, 20);
            this.npcProbabilityInput.TabIndex = 49;
            this.npcProbabilityInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.npcProbabilityInput.ValueChanged += new System.EventHandler(this.npcProbabilityInput_ValueChanged);
            // 
            // NpcTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NpcTab";
            this.Size = new System.Drawing.Size(513, 381);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.rootContentPanel.ResumeLayout(false);
            this.rootContentPanel.PerformLayout();
            this.mainContentPanel.ResumeLayout(false);
            this.mainContentPanel.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minMoneyInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxMoneyInput)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minRankInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRankInput)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npcProbabilityInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel rootContentPanel;
        private System.Windows.Forms.TableLayoutPanel mainContentPanel;
        private System.Windows.Forms.TableLayoutPanel topPanel;
        private System.Windows.Forms.Button modelButon;
        private System.Windows.Forms.Button soundButton;
        private System.Windows.Forms.TableLayoutPanel bottomPanel;
        private System.Windows.Forms.Label probabilityLabel;
        private System.Windows.Forms.NumericUpDown npcProbabilityInput;
        private System.Windows.Forms.Button exceptionButton;
        private System.Windows.Forms.Button communityButton;
        private System.Windows.Forms.Button uniqueNameButton;
        private System.Windows.Forms.Button generateNameButton;
        private System.Windows.Forms.Button iconButton;
        private System.Windows.Forms.CheckBox modelCheckBox;
        private System.Windows.Forms.CheckBox communityCheckBox;
        private System.Windows.Forms.CheckBox uniqueNameCheckBox;
        private System.Windows.Forms.CheckBox generateNameCheckBox;
        private System.Windows.Forms.CheckBox iconCheckBox;
        private System.Windows.Forms.CheckBox soundCheckBox;
        private System.Windows.Forms.Button mainWeaponButton;
        private System.Windows.Forms.CheckBox mainWeaponCheckBox;
        private System.Windows.Forms.CheckBox extendCampCheckBox;
        private System.Windows.Forms.Button additionalWeaponButton;
        private System.Windows.Forms.CheckBox additionalWeaponCheckBox;
        private System.Windows.Forms.CheckBox singleWeaponCheckBox;
        private System.Windows.Forms.Button keepSupplieButton;
        private System.Windows.Forms.Label keepSupplieLabel;
        private System.Windows.Forms.CheckBox moneyCheckBox;
        private System.Windows.Forms.CheckBox rankCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown maxRankInput;
        private System.Windows.Forms.NumericUpDown minRankInput;
        private System.Windows.Forms.Label minRankLabel;
        private System.Windows.Forms.Label maxRankLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.NumericUpDown minMoneyInput;
        private System.Windows.Forms.Label minMoneyLabel;
        private System.Windows.Forms.NumericUpDown maxMoneyInput;
        private System.Windows.Forms.Label maxMoneyLabel;
        private System.Windows.Forms.Label exceptionsLabel;
    }
}
