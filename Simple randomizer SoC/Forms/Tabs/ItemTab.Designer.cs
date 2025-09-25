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
            this.label1 = new System.Windows.Forms.Label();
            this.rootContentPanel = new System.Windows.Forms.Panel();
            this.mainContentPanel = new System.Windows.Forms.TableLayoutPanel();
            this.topPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.artefactSectionsButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
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
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.TableLayoutPanel();
            this.itemProbabilityInput = new System.Windows.Forms.NumericUpDown();
            this.armorProbabilityInput = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(578, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Настройка генерации параметров предметов";
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
            this.topPanel.Controls.Add(this.label11, 0, 1);
            this.topPanel.Controls.Add(this.artefactSectionsButton, 1, 0);
            this.topPanel.Controls.Add(this.label2, 0, 0);
            this.topPanel.Controls.Add(this.label3, 0, 2);
            this.topPanel.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.topPanel.Controls.Add(this.artefactParametersButton, 1, 1);
            this.topPanel.Controls.Add(this.tableLayoutPanel4, 1, 2);
            this.topPanel.Controls.Add(this.itemParametersButton, 1, 11);
            this.topPanel.Controls.Add(this.itemSectionsButton, 1, 10);
            this.topPanel.Controls.Add(this.armorImmunityParametersButton, 1, 8);
            this.topPanel.Controls.Add(this.armorParametersButton, 1, 7);
            this.topPanel.Controls.Add(this.armorImmunitySectionsButton, 1, 6);
            this.topPanel.Controls.Add(this.armorSectionsButton, 1, 5);
            this.topPanel.Controls.Add(this.label7, 0, 11);
            this.topPanel.Controls.Add(this.label6, 0, 10);
            this.topPanel.Controls.Add(this.label14, 0, 8);
            this.topPanel.Controls.Add(this.label5, 0, 7);
            this.topPanel.Controls.Add(this.label15, 0, 6);
            this.topPanel.Controls.Add(this.label4, 0, 5);
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
            this.topPanel.Size = new System.Drawing.Size(595, 402);
            this.topPanel.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(3, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(363, 29);
            this.label11.TabIndex = 38;
            this.label11.Text = "Стандартные генерируемые параметры артефактов";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(363, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Секции для генерации параметров артефактов";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(363, 58);
            this.label3.TabIndex = 2;
            this.label3.Text = "Генерируемые параметры характеристик артефактов";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.topPanel.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label13, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label12, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.maxArtefactStatCountInput, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.minArtefactStatCountInput, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 116);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(595, 52);
            this.tableLayoutPanel3.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(62, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(530, 26);
            this.label13.TabIndex = 48;
            this.label13.Text = "Максимальное количество статов артефактов";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(62, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(530, 26);
            this.label12.TabIndex = 47;
            this.label12.Text = "Минимальное количество статов артефактов";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tableLayoutPanel4.Size = new System.Drawing.Size(226, 58);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(3, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(363, 29);
            this.label7.TabIndex = 6;
            this.label7.Text = "Генерируемые параметры расходников";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(363, 29);
            this.label6.TabIndex = 5;
            this.label6.Text = "Секции для генерации параметров расходников";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(3, 275);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(363, 29);
            this.label14.TabIndex = 43;
            this.label14.Text = "Генерируемые параметры износа брони";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(363, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "Генерируемые параметры брони";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(3, 217);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(363, 29);
            this.label15.TabIndex = 45;
            this.label15.Text = "Секции для генерации параметров износа брони";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(363, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Секции для генерации параметров брони";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bottomPanel
            // 
            this.bottomPanel.AutoSize = true;
            this.bottomPanel.ColumnCount = 2;
            this.bottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.bottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bottomPanel.Controls.Add(this.itemProbabilityInput, 0, 2);
            this.bottomPanel.Controls.Add(this.armorProbabilityInput, 0, 1);
            this.bottomPanel.Controls.Add(this.label10, 1, 2);
            this.bottomPanel.Controls.Add(this.label9, 1, 1);
            this.bottomPanel.Controls.Add(this.label8, 1, 0);
            this.bottomPanel.Controls.Add(this.artefactProbabilityInput, 0, 0);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottomPanel.Location = new System.Drawing.Point(0, 402);
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.RowCount = 3;
            this.bottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bottomPanel.Size = new System.Drawing.Size(595, 78);
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(62, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(530, 26);
            this.label10.TabIndex = 48;
            this.label10.Text = "Вероятность генерации каждого параметра расходников";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(62, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(530, 26);
            this.label9.TabIndex = 47;
            this.label9.Text = "Вероятность генерации каждого параметра брони";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(62, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(530, 26);
            this.label8.TabIndex = 46;
            this.label8.Text = "Вероятность генерации каждого параметра артефакта";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel mainContentPanel;
        private System.Windows.Forms.Panel rootContentPanel;
        private System.Windows.Forms.TableLayoutPanel topPanel;
        private System.Windows.Forms.TableLayoutPanel bottomPanel;
        private System.Windows.Forms.NumericUpDown artefactProbabilityInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button itemParametersButton;
        private System.Windows.Forms.Button itemSectionsButton;
        private System.Windows.Forms.Button armorParametersButton;
        private System.Windows.Forms.Button armorSectionsButton;
        private System.Windows.Forms.Button artefactParametersButton;
        private System.Windows.Forms.Button artefactSectionsButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown itemProbabilityInput;
        private System.Windows.Forms.NumericUpDown armorProbabilityInput;
        private System.Windows.Forms.Button artefactStatParameters0Button;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown maxArtefactStatCountInput;
        private System.Windows.Forms.NumericUpDown minArtefactStatCountInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button artefactStatParameters1Button;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button armorImmunityParametersButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button armorImmunitySectionsButton;
    }
}
