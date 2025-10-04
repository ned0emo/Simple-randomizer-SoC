namespace Simple_randomizer_SoC.Forms.Tabs
{
    partial class StashTab
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.communitiesMaxCountLabel = new System.Windows.Forms.Label();
            this.maxCommunitiesInput = new System.Windows.Forms.NumericUpDown();
            this.editCommunitiesButton = new System.Windows.Forms.Button();
            this.communitiesLabel = new System.Windows.Forms.Label();
            this.probabilityLabel = new System.Windows.Forms.Label();
            this.probabilityInput = new System.Windows.Forms.NumericUpDown();
            this.armorMaxCountLabel = new System.Windows.Forms.Label();
            this.maxArmorsInput = new System.Windows.Forms.NumericUpDown();
            this.editArmorsButton = new System.Windows.Forms.Button();
            this.armorLabel = new System.Windows.Forms.Label();
            this.artefactsMaxCountLabel = new System.Windows.Forms.Label();
            this.maxArtefactsInput = new System.Windows.Forms.NumericUpDown();
            this.editArtefactsButton = new System.Windows.Forms.Button();
            this.artefactsLabel = new System.Windows.Forms.Label();
            this.ammoMaxCountLabel = new System.Windows.Forms.Label();
            this.maxAmmosInput = new System.Windows.Forms.NumericUpDown();
            this.editAmmosButton = new System.Windows.Forms.Button();
            this.ammoLabel = new System.Windows.Forms.Label();
            this.consumablesMaxCountLabel = new System.Windows.Forms.Label();
            this.maxItemsInput = new System.Windows.Forms.NumericUpDown();
            this.editItemsButton = new System.Windows.Forms.Button();
            this.consumablesLabel = new System.Windows.Forms.Label();
            this.otherMaxCountLabel = new System.Windows.Forms.Label();
            this.maxOthersInput = new System.Windows.Forms.NumericUpDown();
            this.editOthersButton = new System.Windows.Forms.Button();
            this.otherLabel = new System.Windows.Forms.Label();
            this.weaponsMaxCountLabel = new System.Windows.Forms.Label();
            this.maxWeaponsInput = new System.Windows.Forms.NumericUpDown();
            this.editWeaponsButton = new System.Windows.Forms.Button();
            this.weaponsLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxCommunitiesInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxArmorsInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxArtefactsInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxAmmosInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxItemsInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxOthersInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxWeaponsInput)).BeginInit();
            this.SuspendLayout();
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
            this.titleLabel.Size = new System.Drawing.Size(266, 26);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Настройка заполнения тайников";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.titleLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 26);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.communitiesMaxCountLabel);
            this.panel2.Controls.Add(this.maxCommunitiesInput);
            this.panel2.Controls.Add(this.editCommunitiesButton);
            this.panel2.Controls.Add(this.communitiesLabel);
            this.panel2.Controls.Add(this.probabilityLabel);
            this.panel2.Controls.Add(this.probabilityInput);
            this.panel2.Controls.Add(this.armorMaxCountLabel);
            this.panel2.Controls.Add(this.maxArmorsInput);
            this.panel2.Controls.Add(this.editArmorsButton);
            this.panel2.Controls.Add(this.armorLabel);
            this.panel2.Controls.Add(this.artefactsMaxCountLabel);
            this.panel2.Controls.Add(this.maxArtefactsInput);
            this.panel2.Controls.Add(this.editArtefactsButton);
            this.panel2.Controls.Add(this.artefactsLabel);
            this.panel2.Controls.Add(this.ammoMaxCountLabel);
            this.panel2.Controls.Add(this.maxAmmosInput);
            this.panel2.Controls.Add(this.editAmmosButton);
            this.panel2.Controls.Add(this.ammoLabel);
            this.panel2.Controls.Add(this.consumablesMaxCountLabel);
            this.panel2.Controls.Add(this.maxItemsInput);
            this.panel2.Controls.Add(this.editItemsButton);
            this.panel2.Controls.Add(this.consumablesLabel);
            this.panel2.Controls.Add(this.otherMaxCountLabel);
            this.panel2.Controls.Add(this.maxOthersInput);
            this.panel2.Controls.Add(this.editOthersButton);
            this.panel2.Controls.Add(this.otherLabel);
            this.panel2.Controls.Add(this.weaponsMaxCountLabel);
            this.panel2.Controls.Add(this.maxWeaponsInput);
            this.panel2.Controls.Add(this.editWeaponsButton);
            this.panel2.Controls.Add(this.weaponsLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(618, 371);
            this.panel2.TabIndex = 3;
            // 
            // communitiesMaxCountLabel
            // 
            this.communitiesMaxCountLabel.AutoSize = true;
            this.communitiesMaxCountLabel.Location = new System.Drawing.Point(304, 162);
            this.communitiesMaxCountLabel.Name = "communitiesMaxCountLabel";
            this.communitiesMaxCountLabel.Size = new System.Drawing.Size(98, 13);
            this.communitiesMaxCountLabel.TabIndex = 41;
            this.communitiesMaxCountLabel.Text = "Макс. количество";
            // 
            // maxCommunitiesInput
            // 
            this.maxCommunitiesInput.Location = new System.Drawing.Point(408, 159);
            this.maxCommunitiesInput.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maxCommunitiesInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxCommunitiesInput.Name = "maxCommunitiesInput";
            this.maxCommunitiesInput.Size = new System.Drawing.Size(53, 20);
            this.maxCommunitiesInput.TabIndex = 40;
            this.maxCommunitiesInput.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.maxCommunitiesInput.ValueChanged += new System.EventHandler(this.maxCommunitiesInput_ValueChanged);
            // 
            // editCommunitiesButton
            // 
            this.editCommunitiesButton.Location = new System.Drawing.Point(116, 156);
            this.editCommunitiesButton.Name = "editCommunitiesButton";
            this.editCommunitiesButton.Size = new System.Drawing.Size(154, 23);
            this.editCommunitiesButton.TabIndex = 39;
            this.editCommunitiesButton.Text = "Редактировать список";
            this.editCommunitiesButton.UseVisualStyleBackColor = true;
            this.editCommunitiesButton.Click += new System.EventHandler(this.editCommunitiesButton_Click);
            // 
            // communitiesLabel
            // 
            this.communitiesLabel.AutoSize = true;
            this.communitiesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.communitiesLabel.Location = new System.Drawing.Point(3, 159);
            this.communitiesLabel.Name = "communitiesLabel";
            this.communitiesLabel.Size = new System.Drawing.Size(93, 16);
            this.communitiesLabel.TabIndex = 38;
            this.communitiesLabel.Text = "Группировки";
            // 
            // probabilityLabel
            // 
            this.probabilityLabel.AutoSize = true;
            this.probabilityLabel.Location = new System.Drawing.Point(66, 191);
            this.probabilityLabel.Name = "probabilityLabel";
            this.probabilityLabel.Size = new System.Drawing.Size(276, 13);
            this.probabilityLabel.TabIndex = 37;
            this.probabilityLabel.Text = "Вероятность генерации каждого параметра тайника";
            // 
            // probabilityInput
            // 
            this.probabilityInput.Location = new System.Drawing.Point(7, 189);
            this.probabilityInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.probabilityInput.Name = "probabilityInput";
            this.probabilityInput.Size = new System.Drawing.Size(53, 20);
            this.probabilityInput.TabIndex = 36;
            this.probabilityInput.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.probabilityInput.ValueChanged += new System.EventHandler(this.probabilityInput_ValueChanged);
            // 
            // armorMaxCountLabel
            // 
            this.armorMaxCountLabel.AutoSize = true;
            this.armorMaxCountLabel.Location = new System.Drawing.Point(304, 32);
            this.armorMaxCountLabel.Name = "armorMaxCountLabel";
            this.armorMaxCountLabel.Size = new System.Drawing.Size(98, 13);
            this.armorMaxCountLabel.TabIndex = 35;
            this.armorMaxCountLabel.Text = "Макс. количество";
            // 
            // maxArmorsInput
            // 
            this.maxArmorsInput.Location = new System.Drawing.Point(408, 29);
            this.maxArmorsInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxArmorsInput.Name = "maxArmorsInput";
            this.maxArmorsInput.Size = new System.Drawing.Size(53, 20);
            this.maxArmorsInput.TabIndex = 34;
            this.maxArmorsInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxArmorsInput.ValueChanged += new System.EventHandler(this.maxArmorsInput_ValueChanged);
            // 
            // editArmorsButton
            // 
            this.editArmorsButton.Location = new System.Drawing.Point(116, 26);
            this.editArmorsButton.Name = "editArmorsButton";
            this.editArmorsButton.Size = new System.Drawing.Size(154, 23);
            this.editArmorsButton.TabIndex = 31;
            this.editArmorsButton.Text = "Редактировать список";
            this.editArmorsButton.UseVisualStyleBackColor = true;
            this.editArmorsButton.Click += new System.EventHandler(this.editArmorsButton_Click);
            // 
            // armorLabel
            // 
            this.armorLabel.AutoSize = true;
            this.armorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.armorLabel.Location = new System.Drawing.Point(3, 29);
            this.armorLabel.Name = "armorLabel";
            this.armorLabel.Size = new System.Drawing.Size(47, 16);
            this.armorLabel.TabIndex = 30;
            this.armorLabel.Text = "Броня";
            // 
            // artefactsMaxCountLabel
            // 
            this.artefactsMaxCountLabel.AutoSize = true;
            this.artefactsMaxCountLabel.Location = new System.Drawing.Point(304, 58);
            this.artefactsMaxCountLabel.Name = "artefactsMaxCountLabel";
            this.artefactsMaxCountLabel.Size = new System.Drawing.Size(98, 13);
            this.artefactsMaxCountLabel.TabIndex = 29;
            this.artefactsMaxCountLabel.Text = "Макс. количество";
            // 
            // maxArtefactsInput
            // 
            this.maxArtefactsInput.Location = new System.Drawing.Point(408, 55);
            this.maxArtefactsInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxArtefactsInput.Name = "maxArtefactsInput";
            this.maxArtefactsInput.Size = new System.Drawing.Size(53, 20);
            this.maxArtefactsInput.TabIndex = 28;
            this.maxArtefactsInput.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.maxArtefactsInput.ValueChanged += new System.EventHandler(this.maxArtefactsInput_ValueChanged);
            // 
            // editArtefactsButton
            // 
            this.editArtefactsButton.Location = new System.Drawing.Point(116, 52);
            this.editArtefactsButton.Name = "editArtefactsButton";
            this.editArtefactsButton.Size = new System.Drawing.Size(154, 23);
            this.editArtefactsButton.TabIndex = 25;
            this.editArtefactsButton.Text = "Редактировать список";
            this.editArtefactsButton.UseVisualStyleBackColor = true;
            this.editArtefactsButton.Click += new System.EventHandler(this.editArtefactsButton_Click);
            // 
            // artefactsLabel
            // 
            this.artefactsLabel.AutoSize = true;
            this.artefactsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.artefactsLabel.Location = new System.Drawing.Point(3, 55);
            this.artefactsLabel.Name = "artefactsLabel";
            this.artefactsLabel.Size = new System.Drawing.Size(81, 16);
            this.artefactsLabel.TabIndex = 24;
            this.artefactsLabel.Text = "Артефакты";
            // 
            // ammoMaxCountLabel
            // 
            this.ammoMaxCountLabel.AutoSize = true;
            this.ammoMaxCountLabel.Location = new System.Drawing.Point(304, 84);
            this.ammoMaxCountLabel.Name = "ammoMaxCountLabel";
            this.ammoMaxCountLabel.Size = new System.Drawing.Size(98, 13);
            this.ammoMaxCountLabel.TabIndex = 23;
            this.ammoMaxCountLabel.Text = "Макс. количество";
            // 
            // maxAmmosInput
            // 
            this.maxAmmosInput.Location = new System.Drawing.Point(408, 81);
            this.maxAmmosInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxAmmosInput.Name = "maxAmmosInput";
            this.maxAmmosInput.Size = new System.Drawing.Size(53, 20);
            this.maxAmmosInput.TabIndex = 22;
            this.maxAmmosInput.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.maxAmmosInput.ValueChanged += new System.EventHandler(this.maxAmmosInput_ValueChanged);
            // 
            // editAmmosButton
            // 
            this.editAmmosButton.Location = new System.Drawing.Point(116, 78);
            this.editAmmosButton.Name = "editAmmosButton";
            this.editAmmosButton.Size = new System.Drawing.Size(154, 23);
            this.editAmmosButton.TabIndex = 19;
            this.editAmmosButton.Text = "Редактировать список";
            this.editAmmosButton.UseVisualStyleBackColor = true;
            this.editAmmosButton.Click += new System.EventHandler(this.editAmmosButton_Click);
            // 
            // ammoLabel
            // 
            this.ammoLabel.AutoSize = true;
            this.ammoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ammoLabel.Location = new System.Drawing.Point(3, 81);
            this.ammoLabel.Name = "ammoLabel";
            this.ammoLabel.Size = new System.Drawing.Size(65, 16);
            this.ammoLabel.TabIndex = 18;
            this.ammoLabel.Text = "Патроны";
            // 
            // consumablesMaxCountLabel
            // 
            this.consumablesMaxCountLabel.AutoSize = true;
            this.consumablesMaxCountLabel.Location = new System.Drawing.Point(304, 110);
            this.consumablesMaxCountLabel.Name = "consumablesMaxCountLabel";
            this.consumablesMaxCountLabel.Size = new System.Drawing.Size(98, 13);
            this.consumablesMaxCountLabel.TabIndex = 17;
            this.consumablesMaxCountLabel.Text = "Макс. количество";
            // 
            // maxItemsInput
            // 
            this.maxItemsInput.Location = new System.Drawing.Point(408, 107);
            this.maxItemsInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxItemsInput.Name = "maxItemsInput";
            this.maxItemsInput.Size = new System.Drawing.Size(53, 20);
            this.maxItemsInput.TabIndex = 16;
            this.maxItemsInput.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.maxItemsInput.ValueChanged += new System.EventHandler(this.maxItemsInput_ValueChanged);
            // 
            // editItemsButton
            // 
            this.editItemsButton.Location = new System.Drawing.Point(116, 104);
            this.editItemsButton.Name = "editItemsButton";
            this.editItemsButton.Size = new System.Drawing.Size(154, 23);
            this.editItemsButton.TabIndex = 13;
            this.editItemsButton.Text = "Редактировать список";
            this.editItemsButton.UseVisualStyleBackColor = true;
            this.editItemsButton.Click += new System.EventHandler(this.editItemsButton_Click);
            // 
            // consumablesLabel
            // 
            this.consumablesLabel.AutoSize = true;
            this.consumablesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.consumablesLabel.Location = new System.Drawing.Point(3, 107);
            this.consumablesLabel.Name = "consumablesLabel";
            this.consumablesLabel.Size = new System.Drawing.Size(84, 16);
            this.consumablesLabel.TabIndex = 12;
            this.consumablesLabel.Text = "Расходники";
            // 
            // otherMaxCountLabel
            // 
            this.otherMaxCountLabel.AutoSize = true;
            this.otherMaxCountLabel.Location = new System.Drawing.Point(304, 136);
            this.otherMaxCountLabel.Name = "otherMaxCountLabel";
            this.otherMaxCountLabel.Size = new System.Drawing.Size(98, 13);
            this.otherMaxCountLabel.TabIndex = 11;
            this.otherMaxCountLabel.Text = "Макс. количество";
            // 
            // maxOthersInput
            // 
            this.maxOthersInput.Location = new System.Drawing.Point(408, 133);
            this.maxOthersInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxOthersInput.Name = "maxOthersInput";
            this.maxOthersInput.Size = new System.Drawing.Size(53, 20);
            this.maxOthersInput.TabIndex = 10;
            this.maxOthersInput.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.maxOthersInput.ValueChanged += new System.EventHandler(this.maxOthersInput_ValueChanged);
            // 
            // editOthersButton
            // 
            this.editOthersButton.Location = new System.Drawing.Point(116, 130);
            this.editOthersButton.Name = "editOthersButton";
            this.editOthersButton.Size = new System.Drawing.Size(154, 23);
            this.editOthersButton.TabIndex = 7;
            this.editOthersButton.Text = "Редактировать список";
            this.editOthersButton.UseVisualStyleBackColor = true;
            this.editOthersButton.Click += new System.EventHandler(this.editOthersButton_Click);
            // 
            // otherLabel
            // 
            this.otherLabel.AutoSize = true;
            this.otherLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.otherLabel.Location = new System.Drawing.Point(3, 133);
            this.otherLabel.Name = "otherLabel";
            this.otherLabel.Size = new System.Drawing.Size(57, 16);
            this.otherLabel.TabIndex = 6;
            this.otherLabel.Text = "Прочее";
            // 
            // weaponsMaxCountLabel
            // 
            this.weaponsMaxCountLabel.AutoSize = true;
            this.weaponsMaxCountLabel.Location = new System.Drawing.Point(304, 6);
            this.weaponsMaxCountLabel.Name = "weaponsMaxCountLabel";
            this.weaponsMaxCountLabel.Size = new System.Drawing.Size(98, 13);
            this.weaponsMaxCountLabel.TabIndex = 5;
            this.weaponsMaxCountLabel.Text = "Макс. количество";
            // 
            // maxWeaponsInput
            // 
            this.maxWeaponsInput.Location = new System.Drawing.Point(408, 3);
            this.maxWeaponsInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxWeaponsInput.Name = "maxWeaponsInput";
            this.maxWeaponsInput.Size = new System.Drawing.Size(53, 20);
            this.maxWeaponsInput.TabIndex = 4;
            this.maxWeaponsInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxWeaponsInput.ValueChanged += new System.EventHandler(this.maxWeponsInput_ValueChanged);
            // 
            // editWeaponsButton
            // 
            this.editWeaponsButton.Location = new System.Drawing.Point(116, 0);
            this.editWeaponsButton.Name = "editWeaponsButton";
            this.editWeaponsButton.Size = new System.Drawing.Size(154, 23);
            this.editWeaponsButton.TabIndex = 1;
            this.editWeaponsButton.Text = "Редактировать список";
            this.editWeaponsButton.UseVisualStyleBackColor = true;
            this.editWeaponsButton.Click += new System.EventHandler(this.editWeaponsButton_Click);
            // 
            // weaponsLabel
            // 
            this.weaponsLabel.AutoSize = true;
            this.weaponsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.weaponsLabel.Location = new System.Drawing.Point(3, 3);
            this.weaponsLabel.Name = "weaponsLabel";
            this.weaponsLabel.Size = new System.Drawing.Size(58, 16);
            this.weaponsLabel.TabIndex = 0;
            this.weaponsLabel.Text = "Оружие";
            // 
            // StashTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "StashTab";
            this.Size = new System.Drawing.Size(618, 397);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxCommunitiesInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxArmorsInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxArtefactsInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxAmmosInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxItemsInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxOthersInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxWeaponsInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label weaponsLabel;
        private System.Windows.Forms.Label weaponsMaxCountLabel;
        private System.Windows.Forms.NumericUpDown maxWeaponsInput;
        private System.Windows.Forms.Button editWeaponsButton;
        private System.Windows.Forms.Label armorMaxCountLabel;
        private System.Windows.Forms.NumericUpDown maxArmorsInput;
        private System.Windows.Forms.Button editArmorsButton;
        private System.Windows.Forms.Label armorLabel;
        private System.Windows.Forms.Label artefactsMaxCountLabel;
        private System.Windows.Forms.NumericUpDown maxArtefactsInput;
        private System.Windows.Forms.Button editArtefactsButton;
        private System.Windows.Forms.Label artefactsLabel;
        private System.Windows.Forms.NumericUpDown maxAmmosInput;
        private System.Windows.Forms.Button editAmmosButton;
        private System.Windows.Forms.Label ammoLabel;
        private System.Windows.Forms.Label consumablesMaxCountLabel;
        private System.Windows.Forms.NumericUpDown maxItemsInput;
        private System.Windows.Forms.Button editItemsButton;
        private System.Windows.Forms.Label consumablesLabel;
        private System.Windows.Forms.Label otherMaxCountLabel;
        private System.Windows.Forms.NumericUpDown maxOthersInput;
        private System.Windows.Forms.Button editOthersButton;
        private System.Windows.Forms.Label otherLabel;
        private System.Windows.Forms.Label probabilityLabel;
        private System.Windows.Forms.NumericUpDown probabilityInput;
        private System.Windows.Forms.Label communitiesMaxCountLabel;
        private System.Windows.Forms.NumericUpDown maxCommunitiesInput;
        private System.Windows.Forms.Button editCommunitiesButton;
        private System.Windows.Forms.Label communitiesLabel;
        private System.Windows.Forms.Label ammoMaxCountLabel;
    }
}
