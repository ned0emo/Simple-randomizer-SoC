namespace Simple_randomizer_SoC.Forms.Dialogs
{
    partial class ParameterListDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.addParameterButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.customListPanel = new System.Windows.Forms.TableLayoutPanel();
            this.orderListParamNameLabel = new System.Windows.Forms.Label();
            this.copyParamsLabel = new System.Windows.Forms.Label();
            this.orderListParamsLabel = new System.Windows.Forms.Label();
            this.fromListParamsLabel = new System.Windows.Forms.Label();
            this.intRangeParamsLabel = new System.Windows.Forms.Label();
            this.floatRangeParamsLabel = new System.Windows.Forms.Label();
            this.fromListPanel = new System.Windows.Forms.TableLayoutPanel();
            this.fromListParamNameLabel = new System.Windows.Forms.Label();
            this.fromListValueCountLabel = new System.Windows.Forms.Label();
            this.valueListLabel = new System.Windows.Forms.Label();
            this.intRangePanel = new System.Windows.Forms.TableLayoutPanel();
            this.intRangeParamNameLabel = new System.Windows.Forms.Label();
            this.intRangeValueCountLabel = new System.Windows.Forms.Label();
            this.intRangeMinValueLabel = new System.Windows.Forms.Label();
            this.intRangeMaxValueLabel = new System.Windows.Forms.Label();
            this.floatRangePanel = new System.Windows.Forms.TableLayoutPanel();
            this.floatRangeParamNameLabel = new System.Windows.Forms.Label();
            this.floatRangeValueCountLabel = new System.Windows.Forms.Label();
            this.floatRangeMinValueLabel = new System.Windows.Forms.Label();
            this.floatRangeMaxValueLabel = new System.Windows.Forms.Label();
            this.precisionLabel = new System.Windows.Forms.Label();
            this.shuffleParamsLabel = new System.Windows.Forms.Label();
            this.copyPanel = new System.Windows.Forms.TableLayoutPanel();
            this.copyFromParamNameLabel = new System.Windows.Forms.Label();
            this.copyParamNameLabel = new System.Windows.Forms.Label();
            this.shufflePanel = new System.Windows.Forms.TableLayoutPanel();
            this.shuffleParamNameLabel = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.customListPanel.SuspendLayout();
            this.fromListPanel.SuspendLayout();
            this.intRangePanel.SuspendLayout();
            this.floatRangePanel.SuspendLayout();
            this.copyPanel.SuspendLayout();
            this.shufflePanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.addParameterButton);
            this.mainPanel.Controls.Add(this.tableLayoutPanel1);
            this.mainPanel.Controls.Add(this.bottomPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(704, 441);
            this.mainPanel.TabIndex = 0;
            // 
            // addParameterButton
            // 
            this.addParameterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addParameterButton.AutoSize = true;
            this.addParameterButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addParameterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addParameterButton.Location = new System.Drawing.Point(673, 379);
            this.addParameterButton.Name = "addParameterButton";
            this.addParameterButton.Size = new System.Drawing.Size(28, 30);
            this.addParameterButton.TabIndex = 2;
            this.addParameterButton.Text = "+";
            this.addParameterButton.UseVisualStyleBackColor = true;
            this.addParameterButton.Click += new System.EventHandler(this.AddParameterButtonClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.customListPanel, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.copyParamsLabel, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.orderListParamsLabel, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.fromListParamsLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.intRangeParamsLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.floatRangeParamsLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.fromListPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.intRangePanel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.floatRangePanel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.shuffleParamsLabel, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.copyPanel, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.shufflePanel, 0, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(704, 412);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // customListPanel
            // 
            this.customListPanel.AutoSize = true;
            this.customListPanel.ColumnCount = 3;
            this.customListPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.customListPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.customListPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.customListPanel.Controls.Add(this.orderListParamNameLabel, 0, 0);
            this.customListPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.customListPanel.Location = new System.Drawing.Point(3, 140);
            this.customListPanel.Name = "customListPanel";
            this.customListPanel.RowCount = 1;
            this.customListPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.customListPanel.Size = new System.Drawing.Size(698, 13);
            this.customListPanel.TabIndex = 15;
            // 
            // orderListParamNameLabel
            // 
            this.orderListParamNameLabel.AutoSize = true;
            this.orderListParamNameLabel.Location = new System.Drawing.Point(3, 0);
            this.orderListParamNameLabel.Name = "orderListParamNameLabel";
            this.orderListParamNameLabel.Size = new System.Drawing.Size(57, 13);
            this.orderListParamNameLabel.TabIndex = 0;
            this.orderListParamNameLabel.Text = "Название";
            // 
            // copyParamsLabel
            // 
            this.copyParamsLabel.AutoSize = true;
            this.copyParamsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.copyParamsLabel.Location = new System.Drawing.Point(3, 195);
            this.copyParamsLabel.Name = "copyParamsLabel";
            this.copyParamsLabel.Size = new System.Drawing.Size(311, 16);
            this.copyParamsLabel.TabIndex = 11;
            this.copyParamsLabel.Text = "Параметры, которые будут скопированы";
            // 
            // orderListParamsLabel
            // 
            this.orderListParamsLabel.AutoSize = true;
            this.orderListParamsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.orderListParamsLabel.Location = new System.Drawing.Point(3, 117);
            this.orderListParamsLabel.Name = "orderListParamsLabel";
            this.orderListParamsLabel.Size = new System.Drawing.Size(406, 16);
            this.orderListParamsLabel.TabIndex = 8;
            this.orderListParamsLabel.Text = "Параметры с несколькими разными типами значений";
            // 
            // fromListParamsLabel
            // 
            this.fromListParamsLabel.AutoSize = true;
            this.fromListParamsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fromListParamsLabel.Location = new System.Drawing.Point(3, 0);
            this.fromListParamsLabel.Name = "fromListParamsLabel";
            this.fromListParamsLabel.Size = new System.Drawing.Size(269, 16);
            this.fromListParamsLabel.TabIndex = 0;
            this.fromListParamsLabel.Text = "Параметры, выбираемые из списка";
            // 
            // intRangeParamsLabel
            // 
            this.intRangeParamsLabel.AutoSize = true;
            this.intRangeParamsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.intRangeParamsLabel.Location = new System.Drawing.Point(3, 39);
            this.intRangeParamsLabel.Name = "intRangeParamsLabel";
            this.intRangeParamsLabel.Size = new System.Drawing.Size(211, 16);
            this.intRangeParamsLabel.TabIndex = 1;
            this.intRangeParamsLabel.Text = "Целочисленные параметры";
            // 
            // floatRangeParamsLabel
            // 
            this.floatRangeParamsLabel.AutoSize = true;
            this.floatRangeParamsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.floatRangeParamsLabel.Location = new System.Drawing.Point(3, 78);
            this.floatRangeParamsLabel.Name = "floatRangeParamsLabel";
            this.floatRangeParamsLabel.Size = new System.Drawing.Size(247, 16);
            this.floatRangeParamsLabel.TabIndex = 2;
            this.floatRangeParamsLabel.Text = "Параметры с плавающей точкой";
            // 
            // fromListPanel
            // 
            this.fromListPanel.AutoSize = true;
            this.fromListPanel.ColumnCount = 4;
            this.fromListPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fromListPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.fromListPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.fromListPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.fromListPanel.Controls.Add(this.fromListParamNameLabel, 0, 0);
            this.fromListPanel.Controls.Add(this.fromListValueCountLabel, 1, 0);
            this.fromListPanel.Controls.Add(this.valueListLabel, 2, 0);
            this.fromListPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fromListPanel.Location = new System.Drawing.Point(3, 23);
            this.fromListPanel.Name = "fromListPanel";
            this.fromListPanel.RowCount = 1;
            this.fromListPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fromListPanel.Size = new System.Drawing.Size(698, 13);
            this.fromListPanel.TabIndex = 3;
            // 
            // fromListParamNameLabel
            // 
            this.fromListParamNameLabel.AutoSize = true;
            this.fromListParamNameLabel.Location = new System.Drawing.Point(3, 0);
            this.fromListParamNameLabel.Name = "fromListParamNameLabel";
            this.fromListParamNameLabel.Size = new System.Drawing.Size(57, 13);
            this.fromListParamNameLabel.TabIndex = 0;
            this.fromListParamNameLabel.Text = "Название";
            // 
            // fromListValueCountLabel
            // 
            this.fromListValueCountLabel.AutoSize = true;
            this.fromListValueCountLabel.Location = new System.Drawing.Point(479, 0);
            this.fromListValueCountLabel.Name = "fromListValueCountLabel";
            this.fromListValueCountLabel.Size = new System.Drawing.Size(116, 13);
            this.fromListValueCountLabel.TabIndex = 1;
            this.fromListValueCountLabel.Text = "Количество значений";
            // 
            // valueListLabel
            // 
            this.valueListLabel.AutoSize = true;
            this.valueListLabel.Location = new System.Drawing.Point(601, 0);
            this.valueListLabel.Name = "valueListLabel";
            this.valueListLabel.Size = new System.Drawing.Size(94, 13);
            this.valueListLabel.TabIndex = 2;
            this.valueListLabel.Text = "Список значений";
            // 
            // intRangePanel
            // 
            this.intRangePanel.AutoSize = true;
            this.intRangePanel.ColumnCount = 5;
            this.intRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.intRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.intRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.intRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.intRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.intRangePanel.Controls.Add(this.intRangeParamNameLabel, 0, 0);
            this.intRangePanel.Controls.Add(this.intRangeValueCountLabel, 1, 0);
            this.intRangePanel.Controls.Add(this.intRangeMinValueLabel, 2, 0);
            this.intRangePanel.Controls.Add(this.intRangeMaxValueLabel, 3, 0);
            this.intRangePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.intRangePanel.Location = new System.Drawing.Point(3, 62);
            this.intRangePanel.Name = "intRangePanel";
            this.intRangePanel.RowCount = 1;
            this.intRangePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.intRangePanel.Size = new System.Drawing.Size(698, 13);
            this.intRangePanel.TabIndex = 4;
            // 
            // intRangeParamNameLabel
            // 
            this.intRangeParamNameLabel.AutoSize = true;
            this.intRangeParamNameLabel.Location = new System.Drawing.Point(3, 0);
            this.intRangeParamNameLabel.Name = "intRangeParamNameLabel";
            this.intRangeParamNameLabel.Size = new System.Drawing.Size(57, 13);
            this.intRangeParamNameLabel.TabIndex = 0;
            this.intRangeParamNameLabel.Text = "Название";
            // 
            // intRangeValueCountLabel
            // 
            this.intRangeValueCountLabel.AutoSize = true;
            this.intRangeValueCountLabel.Location = new System.Drawing.Point(399, 0);
            this.intRangeValueCountLabel.Name = "intRangeValueCountLabel";
            this.intRangeValueCountLabel.Size = new System.Drawing.Size(116, 13);
            this.intRangeValueCountLabel.TabIndex = 1;
            this.intRangeValueCountLabel.Text = "Количество значений";
            // 
            // intRangeMinValueLabel
            // 
            this.intRangeMinValueLabel.AutoSize = true;
            this.intRangeMinValueLabel.Location = new System.Drawing.Point(521, 0);
            this.intRangeMinValueLabel.Name = "intRangeMinValueLabel";
            this.intRangeMinValueLabel.Size = new System.Drawing.Size(81, 13);
            this.intRangeMinValueLabel.TabIndex = 2;
            this.intRangeMinValueLabel.Text = "Мин. значение";
            // 
            // intRangeMaxValueLabel
            // 
            this.intRangeMaxValueLabel.AutoSize = true;
            this.intRangeMaxValueLabel.Location = new System.Drawing.Point(608, 0);
            this.intRangeMaxValueLabel.Name = "intRangeMaxValueLabel";
            this.intRangeMaxValueLabel.Size = new System.Drawing.Size(87, 13);
            this.intRangeMaxValueLabel.TabIndex = 3;
            this.intRangeMaxValueLabel.Text = "Макс. значение";
            // 
            // floatRangePanel
            // 
            this.floatRangePanel.AutoSize = true;
            this.floatRangePanel.ColumnCount = 6;
            this.floatRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.floatRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.floatRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.floatRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.floatRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.floatRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.floatRangePanel.Controls.Add(this.floatRangeParamNameLabel, 0, 0);
            this.floatRangePanel.Controls.Add(this.floatRangeValueCountLabel, 1, 0);
            this.floatRangePanel.Controls.Add(this.floatRangeMinValueLabel, 2, 0);
            this.floatRangePanel.Controls.Add(this.floatRangeMaxValueLabel, 3, 0);
            this.floatRangePanel.Controls.Add(this.precisionLabel, 4, 0);
            this.floatRangePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.floatRangePanel.Location = new System.Drawing.Point(3, 101);
            this.floatRangePanel.Name = "floatRangePanel";
            this.floatRangePanel.RowCount = 1;
            this.floatRangePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.floatRangePanel.Size = new System.Drawing.Size(698, 13);
            this.floatRangePanel.TabIndex = 5;
            // 
            // floatRangeParamNameLabel
            // 
            this.floatRangeParamNameLabel.AutoSize = true;
            this.floatRangeParamNameLabel.Location = new System.Drawing.Point(3, 0);
            this.floatRangeParamNameLabel.Name = "floatRangeParamNameLabel";
            this.floatRangeParamNameLabel.Size = new System.Drawing.Size(57, 13);
            this.floatRangeParamNameLabel.TabIndex = 0;
            this.floatRangeParamNameLabel.Text = "Название";
            // 
            // floatRangeValueCountLabel
            // 
            this.floatRangeValueCountLabel.AutoSize = true;
            this.floatRangeValueCountLabel.Location = new System.Drawing.Point(339, 0);
            this.floatRangeValueCountLabel.Name = "floatRangeValueCountLabel";
            this.floatRangeValueCountLabel.Size = new System.Drawing.Size(116, 13);
            this.floatRangeValueCountLabel.TabIndex = 1;
            this.floatRangeValueCountLabel.Text = "Количество значений";
            // 
            // floatRangeMinValueLabel
            // 
            this.floatRangeMinValueLabel.AutoSize = true;
            this.floatRangeMinValueLabel.Location = new System.Drawing.Point(461, 0);
            this.floatRangeMinValueLabel.Name = "floatRangeMinValueLabel";
            this.floatRangeMinValueLabel.Size = new System.Drawing.Size(81, 13);
            this.floatRangeMinValueLabel.TabIndex = 2;
            this.floatRangeMinValueLabel.Text = "Мин. значение";
            // 
            // floatRangeMaxValueLabel
            // 
            this.floatRangeMaxValueLabel.AutoSize = true;
            this.floatRangeMaxValueLabel.Location = new System.Drawing.Point(548, 0);
            this.floatRangeMaxValueLabel.Name = "floatRangeMaxValueLabel";
            this.floatRangeMaxValueLabel.Size = new System.Drawing.Size(87, 13);
            this.floatRangeMaxValueLabel.TabIndex = 3;
            this.floatRangeMaxValueLabel.Text = "Макс. значение";
            // 
            // precisionLabel
            // 
            this.precisionLabel.AutoSize = true;
            this.precisionLabel.Location = new System.Drawing.Point(641, 0);
            this.precisionLabel.Name = "precisionLabel";
            this.precisionLabel.Size = new System.Drawing.Size(54, 13);
            this.precisionLabel.TabIndex = 4;
            this.precisionLabel.Text = "Точность";
            // 
            // shuffleParamsLabel
            // 
            this.shuffleParamsLabel.AutoSize = true;
            this.shuffleParamsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shuffleParamsLabel.Location = new System.Drawing.Point(3, 156);
            this.shuffleParamsLabel.Name = "shuffleParamsLabel";
            this.shuffleParamsLabel.Size = new System.Drawing.Size(431, 16);
            this.shuffleParamsLabel.TabIndex = 9;
            this.shuffleParamsLabel.Text = "Параметры, которые будут перемешаны между секциями";
            // 
            // copyPanel
            // 
            this.copyPanel.AutoSize = true;
            this.copyPanel.ColumnCount = 3;
            this.copyPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.copyPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.copyPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.copyPanel.Controls.Add(this.copyFromParamNameLabel, 1, 0);
            this.copyPanel.Controls.Add(this.copyParamNameLabel, 0, 0);
            this.copyPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.copyPanel.Location = new System.Drawing.Point(3, 218);
            this.copyPanel.Name = "copyPanel";
            this.copyPanel.RowCount = 1;
            this.copyPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.copyPanel.Size = new System.Drawing.Size(698, 13);
            this.copyPanel.TabIndex = 14;
            // 
            // copyFromParamNameLabel
            // 
            this.copyFromParamNameLabel.AutoSize = true;
            this.copyFromParamNameLabel.Location = new System.Drawing.Point(435, 0);
            this.copyFromParamNameLabel.Name = "copyFromParamNameLabel";
            this.copyFromParamNameLabel.Size = new System.Drawing.Size(260, 13);
            this.copyFromParamNameLabel.TabIndex = 2;
            this.copyFromParamNameLabel.Text = "Параметр, значение которого будет скопировано";
            // 
            // copyParamNameLabel
            // 
            this.copyParamNameLabel.AutoSize = true;
            this.copyParamNameLabel.Location = new System.Drawing.Point(3, 0);
            this.copyParamNameLabel.Name = "copyParamNameLabel";
            this.copyParamNameLabel.Size = new System.Drawing.Size(57, 13);
            this.copyParamNameLabel.TabIndex = 0;
            this.copyParamNameLabel.Text = "Название";
            // 
            // shufflePanel
            // 
            this.shufflePanel.AutoSize = true;
            this.shufflePanel.ColumnCount = 2;
            this.shufflePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.shufflePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.shufflePanel.Controls.Add(this.shuffleParamNameLabel, 0, 0);
            this.shufflePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.shufflePanel.Location = new System.Drawing.Point(3, 179);
            this.shufflePanel.Name = "shufflePanel";
            this.shufflePanel.RowCount = 1;
            this.shufflePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.shufflePanel.Size = new System.Drawing.Size(698, 13);
            this.shufflePanel.TabIndex = 7;
            // 
            // shuffleParamNameLabel
            // 
            this.shuffleParamNameLabel.AutoSize = true;
            this.shuffleParamNameLabel.Location = new System.Drawing.Point(3, 0);
            this.shuffleParamNameLabel.Name = "shuffleParamNameLabel";
            this.shuffleParamNameLabel.Size = new System.Drawing.Size(57, 13);
            this.shuffleParamNameLabel.TabIndex = 0;
            this.shuffleParamNameLabel.Text = "Название";
            // 
            // bottomPanel
            // 
            this.bottomPanel.AutoSize = true;
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Controls.Add(this.saveButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 412);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(704, 29);
            this.bottomPanel.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(545, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(626, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(3, 117);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(216, 16);
            this.label16.TabIndex = 6;
            this.label16.Text = "Параметры для перемешивания";
            // 
            // ParameterListDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.mainPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(720, 320);
            this.Name = "ParameterListDialog";
            this.Text = "ParameterListDialog";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.customListPanel.ResumeLayout(false);
            this.customListPanel.PerformLayout();
            this.fromListPanel.ResumeLayout(false);
            this.fromListPanel.PerformLayout();
            this.intRangePanel.ResumeLayout(false);
            this.intRangePanel.PerformLayout();
            this.floatRangePanel.ResumeLayout(false);
            this.floatRangePanel.PerformLayout();
            this.copyPanel.ResumeLayout(false);
            this.copyPanel.PerformLayout();
            this.shufflePanel.ResumeLayout(false);
            this.shufflePanel.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label fromListParamsLabel;
        private System.Windows.Forms.Label intRangeParamsLabel;
        private System.Windows.Forms.Label floatRangeParamsLabel;
        private System.Windows.Forms.Button addParameterButton;
        private System.Windows.Forms.TableLayoutPanel fromListPanel;
        private System.Windows.Forms.Label fromListParamNameLabel;
        private System.Windows.Forms.Label fromListValueCountLabel;
        private System.Windows.Forms.Label valueListLabel;
        private System.Windows.Forms.TableLayoutPanel intRangePanel;
        private System.Windows.Forms.Label intRangeParamNameLabel;
        private System.Windows.Forms.Label intRangeValueCountLabel;
        private System.Windows.Forms.Label intRangeMinValueLabel;
        private System.Windows.Forms.Label intRangeMaxValueLabel;
        private System.Windows.Forms.TableLayoutPanel floatRangePanel;
        private System.Windows.Forms.Label floatRangeParamNameLabel;
        private System.Windows.Forms.Label floatRangeValueCountLabel;
        private System.Windows.Forms.Label floatRangeMinValueLabel;
        private System.Windows.Forms.Label floatRangeMaxValueLabel;
        private System.Windows.Forms.Label precisionLabel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TableLayoutPanel shufflePanel;
        private System.Windows.Forms.Label shuffleParamNameLabel;
        private System.Windows.Forms.Label orderListParamsLabel;
        private System.Windows.Forms.Label shuffleParamsLabel;
        private System.Windows.Forms.Label copyParamsLabel;
        private System.Windows.Forms.TableLayoutPanel customListPanel;
        private System.Windows.Forms.Label orderListParamNameLabel;
        private System.Windows.Forms.TableLayoutPanel copyPanel;
        private System.Windows.Forms.Label copyFromParamNameLabel;
        private System.Windows.Forms.Label copyParamNameLabel;
    }
}