namespace Simple_randomizer_SoC.Forms.Tabs
{
    partial class ItemTab
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
            this.artefcatsStandardParamsLabel = new System.Windows.Forms.Label();
            this.artefactSectionsButton = new System.Windows.Forms.Button();
            this.artefcatsGenerateSectionsLabel = new System.Windows.Forms.Label();
            this.artefactsStatsLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.maxArtefactsStatsLabel = new System.Windows.Forms.Label();
            this.minArtefactsStatsLabel = new System.Windows.Forms.Label();
            this.maxArtefactStatCountInput = new System.Windows.Forms.NumericUpDown();
            this.minArtefactStatCountInput = new System.Windows.Forms.NumericUpDown();
            this.artefactParametersButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.artefactStatParameters1Button = new System.Windows.Forms.Button();
            this.artefactStatParameters0Button = new System.Windows.Forms.Button();
            this.itemParametersButton = new System.Windows.Forms.Button();
            this.itemSectionsButton = new System.Windows.Forms.Button();
            this.armorImmunityParametersButton = new System.Windows.Forms.Button();
            this.armorParametersButton = new System.Windows.Forms.Button();
            this.armorImmunitySectionsButton = new System.Windows.Forms.Button();
            this.armorSectionsButton = new System.Windows.Forms.Button();
            this.consumablesStatsLabel = new System.Windows.Forms.Label();
            this.consumablesGenerateSectionsLabel = new System.Windows.Forms.Label();
            this.armorImmunityStatsLabel = new System.Windows.Forms.Label();
            this.armorMainStatsLabel = new System.Windows.Forms.Label();
            this.armorImmunitySectionsLabel = new System.Windows.Forms.Label();
            this.armorGenerateSectionsLabel = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.TableLayoutPanel();
            this.itemProbabilityInput = new System.Windows.Forms.NumericUpDown();
            this.armorProbabilityInput = new System.Windows.Forms.NumericUpDown();
            this.consumablesProbabilityLabel = new System.Windows.Forms.Label();
            this.armorProbabilityLabel = new System.Windows.Forms.Label();
            this.artefactsProbabilityLabel = new System.Windows.Forms.Label();
            this.artefactProbabilityInput = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.rootContentPanel.SuspendLayout();
            this.mainContentPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxArtefactStatCountInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minArtefactStatCountInput)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemProbabilityInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.armorProbabilityInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.artefactProbabilityInput)).BeginInit();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(578, 397);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.titleLabel.Size = new System.Drawing.Size(578, 26);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Настройка генерации параметров предметов";
            // 
            // rootContentPanel
            // 
            this.rootContentPanel.Controls.Add(this.mainContentPanel);
            this.rootContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootContentPanel.Location = new System.Drawing.Point(3, 29);
            this.rootContentPanel.Name = "rootContentPanel";
            this.rootContentPanel.Size = new System.Drawing.Size(572, 365);
            this.rootContentPanel.TabIndex = 3;
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.AutoScroll = true;
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
            this.mainContentPanel.Size = new System.Drawing.Size(572, 365);
            this.mainContentPanel.TabIndex = 3;
            // 
            // topPanel
            // 
            this.topPanel.AutoSize = true;
            this.topPanel.ColumnCount = 2;
            this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topPanel.Controls.Add(this.artefcatsStandardParamsLabel, 0, 1);
            this.topPanel.Controls.Add(this.artefactSectionsButton, 1, 0);
            this.topPanel.Controls.Add(this.artefcatsGenerateSectionsLabel, 0, 0);
            this.topPanel.Controls.Add(this.artefactsStatsLabel, 0, 2);
            this.topPanel.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.topPanel.Controls.Add(this.artefactParametersButton, 1, 1);
            this.topPanel.Controls.Add(this.tableLayoutPanel4, 1, 2);
            this.topPanel.Controls.Add(this.itemParametersButton, 1, 11);
            this.topPanel.Controls.Add(this.itemSectionsButton, 1, 10);
            this.topPanel.Controls.Add(this.armorImmunityParametersButton, 1, 8);
            this.topPanel.Controls.Add(this.armorParametersButton, 1, 7);
            this.topPanel.Controls.Add(this.armorImmunitySectionsButton, 1, 6);
            this.topPanel.Controls.Add(this.armorSectionsButton, 1, 5);
            this.topPanel.Controls.Add(this.consumablesStatsLabel, 0, 11);
            this.topPanel.Controls.Add(this.consumablesGenerateSectionsLabel, 0, 10);
            this.topPanel.Controls.Add(this.armorImmunityStatsLabel, 0, 8);
            this.topPanel.Controls.Add(this.armorMainStatsLabel, 0, 7);
            this.topPanel.Controls.Add(this.armorImmunitySectionsLabel, 0, 6);
            this.topPanel.Controls.Add(this.armorGenerateSectionsLabel, 0, 5);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(0);
            this.topPanel.Name = "topPanel";
            this.topPanel.RowCount = 13;
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.topPanel.Size = new System.Drawing.Size(585, 402);
            this.topPanel.TabIndex = 0;
            // 
            // artefcatsStandardParamsLabel
            // 
            this.artefcatsStandardParamsLabel.AutoSize = true;
            this.artefcatsStandardParamsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.artefcatsStandardParamsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.artefcatsStandardParamsLabel.Location = new System.Drawing.Point(3, 29);
            this.artefcatsStandardParamsLabel.Name = "artefcatsStandardParamsLabel";
            this.artefcatsStandardParamsLabel.Size = new System.Drawing.Size(363, 29);
            this.artefcatsStandardParamsLabel.TabIndex = 38;
            this.artefcatsStandardParamsLabel.Text = "Стандартные генерируемые параметры артефактов";
            this.artefcatsStandardParamsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // artefactSectionsButton
            // 
            this.artefactSectionsButton.Location = new System.Drawing.Point(372, 3);
            this.artefactSectionsButton.Name = "artefactSectionsButton";
            this.artefactSectionsButton.Size = new System.Drawing.Size(154, 23);
            this.artefactSectionsButton.TabIndex = 32;
            this.artefactSectionsButton.Text = "Редактировать список";
            this.artefactSectionsButton.UseVisualStyleBackColor = true;
            this.artefactSectionsButton.Click += new System.EventHandler(this.artefactSectionsButton_Click);
            // 
            // artefcatsGenerateSectionsLabel
            // 
            this.artefcatsGenerateSectionsLabel.AutoSize = true;
            this.artefcatsGenerateSectionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.artefcatsGenerateSectionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.artefcatsGenerateSectionsLabel.Location = new System.Drawing.Point(3, 0);
            this.artefcatsGenerateSectionsLabel.Name = "artefcatsGenerateSectionsLabel";
            this.artefcatsGenerateSectionsLabel.Size = new System.Drawing.Size(363, 29);
            this.artefcatsGenerateSectionsLabel.TabIndex = 1;
            this.artefcatsGenerateSectionsLabel.Text = "Секции для генерации параметров артефактов";
            this.artefcatsGenerateSectionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // artefactsStatsLabel
            // 
            this.artefactsStatsLabel.AutoSize = true;
            this.artefactsStatsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.artefactsStatsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.artefactsStatsLabel.Location = new System.Drawing.Point(3, 58);
            this.artefactsStatsLabel.Name = "artefactsStatsLabel";
            this.artefactsStatsLabel.Size = new System.Drawing.Size(363, 58);
            this.artefactsStatsLabel.TabIndex = 2;
            this.artefactsStatsLabel.Text = "Генерируемые параметры характеристик артефактов";
            this.artefactsStatsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.topPanel.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.maxArtefactsStatsLabel, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.minArtefactsStatsLabel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.maxArtefactStatCountInput, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.minArtefactStatCountInput, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 116);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(585, 52);
            this.tableLayoutPanel3.TabIndex = 40;
            // 
            // maxArtefactsStatsLabel
            // 
            this.maxArtefactsStatsLabel.AutoSize = true;
            this.maxArtefactsStatsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maxArtefactsStatsLabel.Location = new System.Drawing.Point(62, 26);
            this.maxArtefactsStatsLabel.Name = "maxArtefactsStatsLabel";
            this.maxArtefactsStatsLabel.Size = new System.Drawing.Size(520, 26);
            this.maxArtefactsStatsLabel.TabIndex = 48;
            this.maxArtefactsStatsLabel.Text = "Максимальное количество статов артефактов";
            this.maxArtefactsStatsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // minArtefactsStatsLabel
            // 
            this.minArtefactsStatsLabel.AutoSize = true;
            this.minArtefactsStatsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minArtefactsStatsLabel.Location = new System.Drawing.Point(62, 0);
            this.minArtefactsStatsLabel.Name = "minArtefactsStatsLabel";
            this.minArtefactsStatsLabel.Size = new System.Drawing.Size(520, 26);
            this.minArtefactsStatsLabel.TabIndex = 47;
            this.minArtefactsStatsLabel.Text = "Минимальное количество статов артефактов";
            this.minArtefactsStatsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maxArtefactStatCountInput
            // 
            this.maxArtefactStatCountInput.Location = new System.Drawing.Point(3, 29);
            this.maxArtefactStatCountInput.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.maxArtefactStatCountInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxArtefactStatCountInput.Name = "maxArtefactStatCountInput";
            this.maxArtefactStatCountInput.Size = new System.Drawing.Size(53, 20);
            this.maxArtefactStatCountInput.TabIndex = 3;
            this.maxArtefactStatCountInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxArtefactStatCountInput.ValueChanged += new System.EventHandler(this.maxArtefactStatCountInput_ValueChanged);
            // 
            // minArtefactStatCountInput
            // 
            this.minArtefactStatCountInput.Location = new System.Drawing.Point(3, 3);
            this.minArtefactStatCountInput.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.minArtefactStatCountInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minArtefactStatCountInput.Name = "minArtefactStatCountInput";
            this.minArtefactStatCountInput.Size = new System.Drawing.Size(53, 20);
            this.minArtefactStatCountInput.TabIndex = 1;
            this.minArtefactStatCountInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minArtefactStatCountInput.ValueChanged += new System.EventHandler(this.minArtefactStatCountInput_ValueChanged);
            // 
            // artefactParametersButton
            // 
            this.artefactParametersButton.Location = new System.Drawing.Point(372, 32);
            this.artefactParametersButton.Name = "artefactParametersButton";
            this.artefactParametersButton.Size = new System.Drawing.Size(154, 23);
            this.artefactParametersButton.TabIndex = 33;
            this.artefactParametersButton.Text = "Редактировать список";
            this.artefactParametersButton.UseVisualStyleBackColor = true;
            this.artefactParametersButton.Click += new System.EventHandler(this.artefactParametersButton_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.artefactStatParameters1Button, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.artefactStatParameters0Button, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(369, 58);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(216, 58);
            this.tableLayoutPanel4.TabIndex = 41;
            // 
            // artefactStatParameters1Button
            // 
            this.artefactStatParameters1Button.AutoSize = true;
            this.artefactStatParameters1Button.Location = new System.Drawing.Point(3, 32);
            this.artefactStatParameters1Button.Name = "artefactStatParameters1Button";
            this.artefactStatParameters1Button.Size = new System.Drawing.Size(210, 23);
            this.artefactStatParameters1Button.TabIndex = 40;
            this.artefactStatParameters1Button.Text = "Параметры с базовым значением 1.0";
            this.artefactStatParameters1Button.UseVisualStyleBackColor = true;
            this.artefactStatParameters1Button.Click += new System.EventHandler(this.artefactStatParameters1Button_Click);
            // 
            // artefactStatParameters0Button
            // 
            this.artefactStatParameters0Button.AutoSize = true;
            this.artefactStatParameters0Button.Location = new System.Drawing.Point(3, 3);
            this.artefactStatParameters0Button.Name = "artefactStatParameters0Button";
            this.artefactStatParameters0Button.Size = new System.Drawing.Size(210, 23);
            this.artefactStatParameters0Button.TabIndex = 39;
            this.artefactStatParameters0Button.Text = "Параметры с базовым значением 0.0";
            this.artefactStatParameters0Button.UseVisualStyleBackColor = true;
            this.artefactStatParameters0Button.Click += new System.EventHandler(this.artefactStatParametersButton_Click);
            // 
            // itemParametersButton
            // 
            this.itemParametersButton.Location = new System.Drawing.Point(372, 356);
            this.itemParametersButton.Name = "itemParametersButton";
            this.itemParametersButton.Size = new System.Drawing.Size(154, 23);
            this.itemParametersButton.TabIndex = 37;
            this.itemParametersButton.Text = "Редактировать список";
            this.itemParametersButton.UseVisualStyleBackColor = true;
            this.itemParametersButton.Click += new System.EventHandler(this.itemParametersButton_Click);
            // 
            // itemSectionsButton
            // 
            this.itemSectionsButton.Location = new System.Drawing.Point(372, 327);
            this.itemSectionsButton.Name = "itemSectionsButton";
            this.itemSectionsButton.Size = new System.Drawing.Size(154, 23);
            this.itemSectionsButton.TabIndex = 36;
            this.itemSectionsButton.Text = "Редактировать список";
            this.itemSectionsButton.UseVisualStyleBackColor = true;
            this.itemSectionsButton.Click += new System.EventHandler(this.itemSectionsButton_Click);
            // 
            // armorImmunityParametersButton
            // 
            this.armorImmunityParametersButton.Location = new System.Drawing.Point(372, 278);
            this.armorImmunityParametersButton.Name = "armorImmunityParametersButton";
            this.armorImmunityParametersButton.Size = new System.Drawing.Size(154, 23);
            this.armorImmunityParametersButton.TabIndex = 42;
            this.armorImmunityParametersButton.Text = "Редактировать список";
            this.armorImmunityParametersButton.UseVisualStyleBackColor = true;
            this.armorImmunityParametersButton.Click += new System.EventHandler(this.armorImmunityParametersButton_Click);
            // 
            // armorParametersButton
            // 
            this.armorParametersButton.Location = new System.Drawing.Point(372, 249);
            this.armorParametersButton.Name = "armorParametersButton";
            this.armorParametersButton.Size = new System.Drawing.Size(154, 23);
            this.armorParametersButton.TabIndex = 35;
            this.armorParametersButton.Text = "Редактировать список";
            this.armorParametersButton.UseVisualStyleBackColor = true;
            this.armorParametersButton.Click += new System.EventHandler(this.armorParametersButton_Click);
            // 
            // armorImmunitySectionsButton
            // 
            this.armorImmunitySectionsButton.Location = new System.Drawing.Point(372, 220);
            this.armorImmunitySectionsButton.Name = "armorImmunitySectionsButton";
            this.armorImmunitySectionsButton.Size = new System.Drawing.Size(154, 23);
            this.armorImmunitySectionsButton.TabIndex = 44;
            this.armorImmunitySectionsButton.Text = "Редактировать список";
            this.armorImmunitySectionsButton.UseVisualStyleBackColor = true;
            this.armorImmunitySectionsButton.Click += new System.EventHandler(this.armorImmunitySectionsButton_Click);
            // 
            // armorSectionsButton
            // 
            this.armorSectionsButton.Location = new System.Drawing.Point(372, 191);
            this.armorSectionsButton.Name = "armorSectionsButton";
            this.armorSectionsButton.Size = new System.Drawing.Size(154, 23);
            this.armorSectionsButton.TabIndex = 34;
            this.armorSectionsButton.Text = "Редактировать список";
            this.armorSectionsButton.UseVisualStyleBackColor = true;
            this.armorSectionsButton.Click += new System.EventHandler(this.armorSectionsButton_Click);
            // 
            // consumablesStatsLabel
            // 
            this.consumablesStatsLabel.AutoSize = true;
            this.consumablesStatsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consumablesStatsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.consumablesStatsLabel.Location = new System.Drawing.Point(3, 353);
            this.consumablesStatsLabel.Name = "consumablesStatsLabel";
            this.consumablesStatsLabel.Size = new System.Drawing.Size(363, 29);
            this.consumablesStatsLabel.TabIndex = 6;
            this.consumablesStatsLabel.Text = "Генерируемые параметры расходников";
            this.consumablesStatsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // consumablesGenerateSectionsLabel
            // 
            this.consumablesGenerateSectionsLabel.AutoSize = true;
            this.consumablesGenerateSectionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consumablesGenerateSectionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.consumablesGenerateSectionsLabel.Location = new System.Drawing.Point(3, 324);
            this.consumablesGenerateSectionsLabel.Name = "consumablesGenerateSectionsLabel";
            this.consumablesGenerateSectionsLabel.Size = new System.Drawing.Size(363, 29);
            this.consumablesGenerateSectionsLabel.TabIndex = 5;
            this.consumablesGenerateSectionsLabel.Text = "Секции для генерации параметров расходников";
            this.consumablesGenerateSectionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // armorImmunityStatsLabel
            // 
            this.armorImmunityStatsLabel.AutoSize = true;
            this.armorImmunityStatsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.armorImmunityStatsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.armorImmunityStatsLabel.Location = new System.Drawing.Point(3, 275);
            this.armorImmunityStatsLabel.Name = "armorImmunityStatsLabel";
            this.armorImmunityStatsLabel.Size = new System.Drawing.Size(363, 29);
            this.armorImmunityStatsLabel.TabIndex = 43;
            this.armorImmunityStatsLabel.Text = "Генерируемые параметры износа брони";
            this.armorImmunityStatsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // armorMainStatsLabel
            // 
            this.armorMainStatsLabel.AutoSize = true;
            this.armorMainStatsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.armorMainStatsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.armorMainStatsLabel.Location = new System.Drawing.Point(3, 246);
            this.armorMainStatsLabel.Name = "armorMainStatsLabel";
            this.armorMainStatsLabel.Size = new System.Drawing.Size(363, 29);
            this.armorMainStatsLabel.TabIndex = 4;
            this.armorMainStatsLabel.Text = "Генерируемые параметры брони";
            this.armorMainStatsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // armorImmunitySectionsLabel
            // 
            this.armorImmunitySectionsLabel.AutoSize = true;
            this.armorImmunitySectionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.armorImmunitySectionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.armorImmunitySectionsLabel.Location = new System.Drawing.Point(3, 217);
            this.armorImmunitySectionsLabel.Name = "armorImmunitySectionsLabel";
            this.armorImmunitySectionsLabel.Size = new System.Drawing.Size(363, 29);
            this.armorImmunitySectionsLabel.TabIndex = 45;
            this.armorImmunitySectionsLabel.Text = "Секции для генерации параметров износа брони";
            this.armorImmunitySectionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // armorGenerateSectionsLabel
            // 
            this.armorGenerateSectionsLabel.AutoSize = true;
            this.armorGenerateSectionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.armorGenerateSectionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.armorGenerateSectionsLabel.Location = new System.Drawing.Point(3, 188);
            this.armorGenerateSectionsLabel.Name = "armorGenerateSectionsLabel";
            this.armorGenerateSectionsLabel.Size = new System.Drawing.Size(363, 29);
            this.armorGenerateSectionsLabel.TabIndex = 3;
            this.armorGenerateSectionsLabel.Text = "Секции для генерации параметров брони";
            this.armorGenerateSectionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bottomPanel
            // 
            this.bottomPanel.AutoSize = true;
            this.bottomPanel.ColumnCount = 2;
            this.bottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.bottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bottomPanel.Controls.Add(this.itemProbabilityInput, 0, 2);
            this.bottomPanel.Controls.Add(this.armorProbabilityInput, 0, 1);
            this.bottomPanel.Controls.Add(this.consumablesProbabilityLabel, 1, 2);
            this.bottomPanel.Controls.Add(this.armorProbabilityLabel, 1, 1);
            this.bottomPanel.Controls.Add(this.artefactsProbabilityLabel, 1, 0);
            this.bottomPanel.Controls.Add(this.artefactProbabilityInput, 0, 0);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottomPanel.Location = new System.Drawing.Point(0, 402);
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.RowCount = 3;
            this.bottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bottomPanel.Size = new System.Drawing.Size(585, 78);
            this.bottomPanel.TabIndex = 1;
            // 
            // itemProbabilityInput
            // 
            this.itemProbabilityInput.Location = new System.Drawing.Point(3, 55);
            this.itemProbabilityInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.itemProbabilityInput.Name = "itemProbabilityInput";
            this.itemProbabilityInput.Size = new System.Drawing.Size(53, 20);
            this.itemProbabilityInput.TabIndex = 50;
            this.itemProbabilityInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.itemProbabilityInput.ValueChanged += new System.EventHandler(this.itemProbabilityInput_ValueChanged);
            // 
            // armorProbabilityInput
            // 
            this.armorProbabilityInput.Location = new System.Drawing.Point(3, 29);
            this.armorProbabilityInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.armorProbabilityInput.Name = "armorProbabilityInput";
            this.armorProbabilityInput.Size = new System.Drawing.Size(53, 20);
            this.armorProbabilityInput.TabIndex = 49;
            this.armorProbabilityInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.armorProbabilityInput.ValueChanged += new System.EventHandler(this.armorProbabilityInput_ValueChanged);
            // 
            // consumablesProbabilityLabel
            // 
            this.consumablesProbabilityLabel.AutoSize = true;
            this.consumablesProbabilityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consumablesProbabilityLabel.Location = new System.Drawing.Point(62, 52);
            this.consumablesProbabilityLabel.Name = "consumablesProbabilityLabel";
            this.consumablesProbabilityLabel.Size = new System.Drawing.Size(520, 26);
            this.consumablesProbabilityLabel.TabIndex = 48;
            this.consumablesProbabilityLabel.Text = "Вероятность генерации каждого параметра расходников";
            this.consumablesProbabilityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // armorProbabilityLabel
            // 
            this.armorProbabilityLabel.AutoSize = true;
            this.armorProbabilityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.armorProbabilityLabel.Location = new System.Drawing.Point(62, 26);
            this.armorProbabilityLabel.Name = "armorProbabilityLabel";
            this.armorProbabilityLabel.Size = new System.Drawing.Size(520, 26);
            this.armorProbabilityLabel.TabIndex = 47;
            this.armorProbabilityLabel.Text = "Вероятность генерации каждого параметра брони";
            this.armorProbabilityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // artefactsProbabilityLabel
            // 
            this.artefactsProbabilityLabel.AutoSize = true;
            this.artefactsProbabilityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.artefactsProbabilityLabel.Location = new System.Drawing.Point(62, 0);
            this.artefactsProbabilityLabel.Name = "artefactsProbabilityLabel";
            this.artefactsProbabilityLabel.Size = new System.Drawing.Size(520, 26);
            this.artefactsProbabilityLabel.TabIndex = 46;
            this.artefactsProbabilityLabel.Text = "Вероятность генерации каждого параметра артефакта";
            this.artefactsProbabilityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // artefactProbabilityInput
            // 
            this.artefactProbabilityInput.Location = new System.Drawing.Point(3, 3);
            this.artefactProbabilityInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.artefactProbabilityInput.Name = "artefactProbabilityInput";
            this.artefactProbabilityInput.Size = new System.Drawing.Size(53, 20);
            this.artefactProbabilityInput.TabIndex = 0;
            this.artefactProbabilityInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.artefactProbabilityInput.ValueChanged += new System.EventHandler(this.artefactProbabilityInput_ValueChanged);
            // 
            // ItemTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ItemTab";
            this.Size = new System.Drawing.Size(578, 397);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.rootContentPanel.ResumeLayout(false);
            this.mainContentPanel.ResumeLayout(false);
            this.mainContentPanel.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxArtefactStatCountInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minArtefactStatCountInput)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemProbabilityInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.armorProbabilityInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.artefactProbabilityInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TableLayoutPanel mainContentPanel;
        private System.Windows.Forms.Panel rootContentPanel;
        private System.Windows.Forms.TableLayoutPanel topPanel;
        private System.Windows.Forms.TableLayoutPanel bottomPanel;
        private System.Windows.Forms.NumericUpDown artefactProbabilityInput;
        private System.Windows.Forms.Label artefcatsGenerateSectionsLabel;
        private System.Windows.Forms.Label artefactsStatsLabel;
        private System.Windows.Forms.Label armorGenerateSectionsLabel;
        private System.Windows.Forms.Label armorMainStatsLabel;
        private System.Windows.Forms.Label consumablesGenerateSectionsLabel;
        private System.Windows.Forms.Label consumablesStatsLabel;
        private System.Windows.Forms.Button itemParametersButton;
        private System.Windows.Forms.Button itemSectionsButton;
        private System.Windows.Forms.Button armorParametersButton;
        private System.Windows.Forms.Button armorSectionsButton;
        private System.Windows.Forms.Button artefactParametersButton;
        private System.Windows.Forms.Button artefactSectionsButton;
        private System.Windows.Forms.Label consumablesProbabilityLabel;
        private System.Windows.Forms.Label armorProbabilityLabel;
        private System.Windows.Forms.Label artefactsProbabilityLabel;
        private System.Windows.Forms.NumericUpDown itemProbabilityInput;
        private System.Windows.Forms.NumericUpDown armorProbabilityInput;
        private System.Windows.Forms.Button artefactStatParameters0Button;
        private System.Windows.Forms.Label artefcatsStandardParamsLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label maxArtefactsStatsLabel;
        private System.Windows.Forms.NumericUpDown maxArtefactStatCountInput;
        private System.Windows.Forms.NumericUpDown minArtefactStatCountInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button artefactStatParameters1Button;
        private System.Windows.Forms.Label armorImmunityStatsLabel;
        private System.Windows.Forms.Button armorImmunityParametersButton;
        private System.Windows.Forms.Label armorImmunitySectionsLabel;
        private System.Windows.Forms.Button armorImmunitySectionsButton;
        private System.Windows.Forms.Label minArtefactsStatsLabel;
    }
}
