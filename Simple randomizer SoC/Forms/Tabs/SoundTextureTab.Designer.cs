namespace Simple_randomizer_SoC.Forms.Tabs
{
    partial class SoundTextureTab
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
            this.contentPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.texturesProbabilityInput = new System.Windows.Forms.NumericUpDown();
            this.texturesProbabilityLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.soundsProbabilityInput = new System.Windows.Forms.NumericUpDown();
            this.soundsProbabilityLabel = new System.Windows.Forms.Label();
            this.texturesUICheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.texturesPathLabel = new System.Windows.Forms.Label();
            this.texturesDirTextBox = new System.Windows.Forms.TextBox();
            this.texturesDirButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.threadCountInput = new System.Windows.Forms.NumericUpDown();
            this.threadsCountLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.soundsStepInput = new System.Windows.Forms.NumericUpDown();
            this.soundsRoundLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.soundsPathLabel = new System.Windows.Forms.Label();
            this.soundsDirTextBox = new System.Windows.Forms.TextBox();
            this.soundsDirButton = new System.Windows.Forms.Button();
            this.soundsStepCheckBox = new System.Windows.Forms.CheckBox();
            this.epilepsyLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.texturesProbabilityInput)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundsProbabilityInput)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.threadCountInput)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundsStepInput)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.titleLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.contentPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(710, 368);
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
            this.titleLabel.Size = new System.Drawing.Size(710, 26);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Настройка перемешивания звуков и текстур";
            // 
            // contentPanel
            // 
            this.contentPanel.AutoScroll = true;
            this.contentPanel.AutoSize = true;
            this.contentPanel.ColumnCount = 2;
            this.contentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.contentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentPanel.Controls.Add(this.tableLayoutPanel7, 0, 7);
            this.contentPanel.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.contentPanel.Controls.Add(this.texturesUICheckBox, 0, 8);
            this.contentPanel.Controls.Add(this.tableLayoutPanel5, 0, 6);
            this.contentPanel.Controls.Add(this.tableLayoutPanel4, 0, 10);
            this.contentPanel.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.contentPanel.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.contentPanel.Controls.Add(this.soundsStepCheckBox, 0, 3);
            this.contentPanel.Controls.Add(this.epilepsyLabel, 0, 5);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(3, 29);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.RowCount = 12;
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.contentPanel.Size = new System.Drawing.Size(704, 336);
            this.contentPanel.TabIndex = 4;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.contentPanel.SetColumnSpan(this.tableLayoutPanel7, 2);
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.texturesProbabilityInput, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.texturesProbabilityLabel, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 185);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(704, 26);
            this.tableLayoutPanel7.TabIndex = 23;
            // 
            // texturesProbabilityInput
            // 
            this.texturesProbabilityInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.texturesProbabilityInput.Location = new System.Drawing.Point(3, 3);
            this.texturesProbabilityInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.texturesProbabilityInput.Name = "texturesProbabilityInput";
            this.texturesProbabilityInput.Size = new System.Drawing.Size(53, 20);
            this.texturesProbabilityInput.TabIndex = 5;
            this.texturesProbabilityInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.texturesProbabilityInput.ValueChanged += new System.EventHandler(this.texturesProbabilityInput_ValueChanged);
            // 
            // texturesProbabilityLabel
            // 
            this.texturesProbabilityLabel.AutoSize = true;
            this.texturesProbabilityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.texturesProbabilityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.texturesProbabilityLabel.Location = new System.Drawing.Point(62, 0);
            this.texturesProbabilityLabel.Name = "texturesProbabilityLabel";
            this.texturesProbabilityLabel.Size = new System.Drawing.Size(639, 26);
            this.texturesProbabilityLabel.TabIndex = 4;
            this.texturesProbabilityLabel.Text = "Вероятность перемешивания каждой текстуры";
            this.texturesProbabilityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 2;
            this.contentPanel.SetColumnSpan(this.tableLayoutPanel6, 2);
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.soundsProbabilityInput, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.soundsProbabilityLabel, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 55);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(704, 26);
            this.tableLayoutPanel6.TabIndex = 22;
            // 
            // soundsProbabilityInput
            // 
            this.soundsProbabilityInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.soundsProbabilityInput.Location = new System.Drawing.Point(3, 3);
            this.soundsProbabilityInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.soundsProbabilityInput.Name = "soundsProbabilityInput";
            this.soundsProbabilityInput.Size = new System.Drawing.Size(53, 20);
            this.soundsProbabilityInput.TabIndex = 5;
            this.soundsProbabilityInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.soundsProbabilityInput.ValueChanged += new System.EventHandler(this.soundsProbabilityInput_ValueChanged);
            // 
            // soundsProbabilityLabel
            // 
            this.soundsProbabilityLabel.AutoSize = true;
            this.soundsProbabilityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soundsProbabilityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.soundsProbabilityLabel.Location = new System.Drawing.Point(62, 0);
            this.soundsProbabilityLabel.Name = "soundsProbabilityLabel";
            this.soundsProbabilityLabel.Size = new System.Drawing.Size(639, 26);
            this.soundsProbabilityLabel.TabIndex = 4;
            this.soundsProbabilityLabel.Text = "Вероятность перемешивания каждого звука";
            this.soundsProbabilityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // texturesUICheckBox
            // 
            this.texturesUICheckBox.AutoSize = true;
            this.contentPanel.SetColumnSpan(this.texturesUICheckBox, 2);
            this.texturesUICheckBox.Location = new System.Drawing.Point(3, 214);
            this.texturesUICheckBox.Name = "texturesUICheckBox";
            this.texturesUICheckBox.Size = new System.Drawing.Size(194, 17);
            this.texturesUICheckBox.TabIndex = 21;
            this.texturesUICheckBox.Text = "Заменять элементы интерфейса";
            this.texturesUICheckBox.UseVisualStyleBackColor = true;
            this.texturesUICheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 3;
            this.contentPanel.SetColumnSpan(this.tableLayoutPanel5, 2);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.texturesPathLabel, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.texturesDirTextBox, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.texturesDirButton, 2, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 156);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(704, 29);
            this.tableLayoutPanel5.TabIndex = 17;
            // 
            // texturesPathLabel
            // 
            this.texturesPathLabel.AutoSize = true;
            this.texturesPathLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.texturesPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.texturesPathLabel.Location = new System.Drawing.Point(3, 0);
            this.texturesPathLabel.Name = "texturesPathLabel";
            this.texturesPathLabel.Size = new System.Drawing.Size(140, 29);
            this.texturesPathLabel.TabIndex = 4;
            this.texturesPathLabel.Text = "Путь к папке textures";
            this.texturesPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // texturesDirTextBox
            // 
            this.texturesDirTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.texturesDirTextBox.Location = new System.Drawing.Point(149, 3);
            this.texturesDirTextBox.Name = "texturesDirTextBox";
            this.texturesDirTextBox.Size = new System.Drawing.Size(471, 20);
            this.texturesDirTextBox.TabIndex = 5;
            this.texturesDirTextBox.TextChanged += new System.EventHandler(this.texturesDirTextBox_TextChanged);
            // 
            // texturesDirButton
            // 
            this.texturesDirButton.Location = new System.Drawing.Point(626, 3);
            this.texturesDirButton.Name = "texturesDirButton";
            this.texturesDirButton.Size = new System.Drawing.Size(75, 23);
            this.texturesDirButton.TabIndex = 6;
            this.texturesDirButton.Text = "Открыть";
            this.texturesDirButton.UseVisualStyleBackColor = true;
            this.texturesDirButton.Click += new System.EventHandler(this.texturesDirButton_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.contentPanel.SetColumnSpan(this.tableLayoutPanel4, 2);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.threadCountInput, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.threadsCountLabel, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 254);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(704, 26);
            this.tableLayoutPanel4.TabIndex = 16;
            // 
            // threadCountInput
            // 
            this.threadCountInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.threadCountInput.Location = new System.Drawing.Point(3, 3);
            this.threadCountInput.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.threadCountInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.threadCountInput.Name = "threadCountInput";
            this.threadCountInput.Size = new System.Drawing.Size(53, 20);
            this.threadCountInput.TabIndex = 5;
            this.threadCountInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.threadCountInput.ValueChanged += new System.EventHandler(this.threadCountInput_ValueChanged);
            // 
            // threadsCountLabel
            // 
            this.threadsCountLabel.AutoSize = true;
            this.threadsCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.threadsCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.threadsCountLabel.Location = new System.Drawing.Point(62, 0);
            this.threadsCountLabel.Name = "threadsCountLabel";
            this.threadsCountLabel.Size = new System.Drawing.Size(639, 26);
            this.threadsCountLabel.TabIndex = 4;
            this.threadsCountLabel.Text = "Количество потоков для обработки";
            this.threadsCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.contentPanel.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.soundsStepInput, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.soundsRoundLabel, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 29);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(704, 26);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // soundsStepInput
            // 
            this.soundsStepInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.soundsStepInput.Location = new System.Drawing.Point(3, 3);
            this.soundsStepInput.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.soundsStepInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.soundsStepInput.Name = "soundsStepInput";
            this.soundsStepInput.Size = new System.Drawing.Size(53, 20);
            this.soundsStepInput.TabIndex = 5;
            this.soundsStepInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.soundsStepInput.ValueChanged += new System.EventHandler(this.soundStepInput_ValueChanged);
            // 
            // soundsRoundLabel
            // 
            this.soundsRoundLabel.AutoSize = true;
            this.soundsRoundLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soundsRoundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.soundsRoundLabel.Location = new System.Drawing.Point(62, 0);
            this.soundsRoundLabel.Name = "soundsRoundLabel";
            this.soundsRoundLabel.Size = new System.Drawing.Size(639, 26);
            this.soundsRoundLabel.TabIndex = 4;
            this.soundsRoundLabel.Text = "Шаг округления длительности звуковых файлов (сек.)";
            this.soundsRoundLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.contentPanel.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.soundsPathLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.soundsDirTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.soundsDirButton, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(704, 29);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // soundsPathLabel
            // 
            this.soundsPathLabel.AutoSize = true;
            this.soundsPathLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soundsPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.soundsPathLabel.Location = new System.Drawing.Point(3, 0);
            this.soundsPathLabel.Name = "soundsPathLabel";
            this.soundsPathLabel.Size = new System.Drawing.Size(138, 29);
            this.soundsPathLabel.TabIndex = 4;
            this.soundsPathLabel.Text = "Путь к папке sounds";
            this.soundsPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // soundsDirTextBox
            // 
            this.soundsDirTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.soundsDirTextBox.Location = new System.Drawing.Point(147, 3);
            this.soundsDirTextBox.Name = "soundsDirTextBox";
            this.soundsDirTextBox.Size = new System.Drawing.Size(473, 20);
            this.soundsDirTextBox.TabIndex = 5;
            this.soundsDirTextBox.TextChanged += new System.EventHandler(this.soundsDirTextBox_TextChanged);
            // 
            // soundsDirButton
            // 
            this.soundsDirButton.Location = new System.Drawing.Point(626, 3);
            this.soundsDirButton.Name = "soundsDirButton";
            this.soundsDirButton.Size = new System.Drawing.Size(75, 23);
            this.soundsDirButton.TabIndex = 6;
            this.soundsDirButton.Text = "Открыть";
            this.soundsDirButton.UseVisualStyleBackColor = true;
            this.soundsDirButton.Click += new System.EventHandler(this.soundsDirButton_Click);
            // 
            // soundsStepCheckBox
            // 
            this.soundsStepCheckBox.AutoSize = true;
            this.contentPanel.SetColumnSpan(this.soundsStepCheckBox, 2);
            this.soundsStepCheckBox.Location = new System.Drawing.Point(3, 84);
            this.soundsStepCheckBox.Name = "soundsStepCheckBox";
            this.soundsStepCheckBox.Size = new System.Drawing.Size(186, 17);
            this.soundsStepCheckBox.TabIndex = 20;
            this.soundsStepCheckBox.Text = "Заменять звуки шагов и дождя";
            this.soundsStepCheckBox.UseVisualStyleBackColor = true;
            this.soundsStepCheckBox.CheckedChanged += new System.EventHandler(this.soundsStepCheckBox_CheckedChanged);
            // 
            // epilepsyLabel
            // 
            this.epilepsyLabel.AutoSize = true;
            this.contentPanel.SetColumnSpan(this.epilepsyLabel, 2);
            this.epilepsyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.epilepsyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.epilepsyLabel.Location = new System.Drawing.Point(3, 124);
            this.epilepsyLabel.Name = "epilepsyLabel";
            this.epilepsyLabel.Size = new System.Drawing.Size(698, 32);
            this.epilepsyLabel.TabIndex = 24;
            this.epilepsyLabel.Text = "Не рекомендуется использовать перемешивание текстур, если у вас когда-либо были э" +
    "пилептические приступы";
            // 
            // SoundTextureTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SoundTextureTab";
            this.Size = new System.Drawing.Size(710, 368);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.texturesProbabilityInput)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundsProbabilityInput)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.threadCountInput)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundsStepInput)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TableLayoutPanel contentPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label soundsPathLabel;
        private System.Windows.Forms.TextBox soundsDirTextBox;
        private System.Windows.Forms.Button soundsDirButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label soundsRoundLabel;
        private System.Windows.Forms.NumericUpDown soundsStepInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.NumericUpDown threadCountInput;
        private System.Windows.Forms.Label threadsCountLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label texturesPathLabel;
        private System.Windows.Forms.TextBox texturesDirTextBox;
        private System.Windows.Forms.Button texturesDirButton;
        private System.Windows.Forms.CheckBox soundsStepCheckBox;
        private System.Windows.Forms.CheckBox texturesUICheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.NumericUpDown texturesProbabilityInput;
        private System.Windows.Forms.Label texturesProbabilityLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.NumericUpDown soundsProbabilityInput;
        private System.Windows.Forms.Label soundsProbabilityLabel;
        private System.Windows.Forms.Label epilepsyLabel;
    }
}
