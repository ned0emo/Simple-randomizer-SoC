namespace Simple_randomizer_SoC.Forms.Dialogs
{
    partial class OrderableParameterListDialog
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
            this.fromListParamsLabel = new System.Windows.Forms.Label();
            this.intRangeParamsLabel = new System.Windows.Forms.Label();
            this.floatRangeParamsLabel = new System.Windows.Forms.Label();
            this.fromListPanel = new System.Windows.Forms.TableLayoutPanel();
            this.valueListLabel = new System.Windows.Forms.Label();
            this.fromListOrderLabel = new System.Windows.Forms.Label();
            this.intRangePanel = new System.Windows.Forms.TableLayoutPanel();
            this.intRangeMinValueLabel = new System.Windows.Forms.Label();
            this.intRangeMaxValueLabel = new System.Windows.Forms.Label();
            this.intRangeOrderLabel = new System.Windows.Forms.Label();
            this.floatRangePanel = new System.Windows.Forms.TableLayoutPanel();
            this.floatRangeMinValueLabel = new System.Windows.Forms.Label();
            this.floatRangeMaxValueLabel = new System.Windows.Forms.Label();
            this.precisionLabel = new System.Windows.Forms.Label();
            this.floatRangeOrderLabel = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.fromListPanel.SuspendLayout();
            this.intRangePanel.SuspendLayout();
            this.floatRangePanel.SuspendLayout();
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
            this.mainPanel.Size = new System.Drawing.Size(624, 281);
            this.mainPanel.TabIndex = 0;
            // 
            // addParameterButton
            // 
            this.addParameterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addParameterButton.AutoSize = true;
            this.addParameterButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addParameterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addParameterButton.Location = new System.Drawing.Point(593, 219);
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
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.fromListParamsLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.intRangeParamsLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.floatRangeParamsLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.fromListPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.intRangePanel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.floatRangePanel, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 252);
            this.tableLayoutPanel1.TabIndex = 1;
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
            this.fromListPanel.ColumnCount = 3;
            this.fromListPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.fromListPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.fromListPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.fromListPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.fromListPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.fromListPanel.Controls.Add(this.valueListLabel, 0, 0);
            this.fromListPanel.Controls.Add(this.fromListOrderLabel, 1, 0);
            this.fromListPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fromListPanel.Location = new System.Drawing.Point(3, 23);
            this.fromListPanel.Name = "fromListPanel";
            this.fromListPanel.RowCount = 1;
            this.fromListPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fromListPanel.Size = new System.Drawing.Size(618, 13);
            this.fromListPanel.TabIndex = 3;
            // 
            // valueListLabel
            // 
            this.valueListLabel.AutoSize = true;
            this.valueListLabel.Location = new System.Drawing.Point(3, 0);
            this.valueListLabel.Name = "valueListLabel";
            this.valueListLabel.Size = new System.Drawing.Size(94, 13);
            this.valueListLabel.TabIndex = 2;
            this.valueListLabel.Text = "Список значений";
            // 
            // fromListOrderLabel
            // 
            this.fromListOrderLabel.AutoSize = true;
            this.fromListOrderLabel.Location = new System.Drawing.Point(103, 0);
            this.fromListOrderLabel.Name = "fromListOrderLabel";
            this.fromListOrderLabel.Size = new System.Drawing.Size(51, 13);
            this.fromListOrderLabel.TabIndex = 3;
            this.fromListOrderLabel.Text = "Порядок";
            // 
            // intRangePanel
            // 
            this.intRangePanel.AutoSize = true;
            this.intRangePanel.ColumnCount = 4;
            this.intRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.intRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.intRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.intRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.intRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.intRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.intRangePanel.Controls.Add(this.intRangeMinValueLabel, 0, 0);
            this.intRangePanel.Controls.Add(this.intRangeMaxValueLabel, 1, 0);
            this.intRangePanel.Controls.Add(this.intRangeOrderLabel, 2, 0);
            this.intRangePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.intRangePanel.Location = new System.Drawing.Point(3, 62);
            this.intRangePanel.Name = "intRangePanel";
            this.intRangePanel.RowCount = 1;
            this.intRangePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.intRangePanel.Size = new System.Drawing.Size(618, 13);
            this.intRangePanel.TabIndex = 4;
            // 
            // intRangeMinValueLabel
            // 
            this.intRangeMinValueLabel.AutoSize = true;
            this.intRangeMinValueLabel.Location = new System.Drawing.Point(3, 0);
            this.intRangeMinValueLabel.Name = "intRangeMinValueLabel";
            this.intRangeMinValueLabel.Size = new System.Drawing.Size(81, 13);
            this.intRangeMinValueLabel.TabIndex = 2;
            this.intRangeMinValueLabel.Text = "Мин. значение";
            // 
            // intRangeMaxValueLabel
            // 
            this.intRangeMaxValueLabel.AutoSize = true;
            this.intRangeMaxValueLabel.Location = new System.Drawing.Point(90, 0);
            this.intRangeMaxValueLabel.Name = "intRangeMaxValueLabel";
            this.intRangeMaxValueLabel.Size = new System.Drawing.Size(87, 13);
            this.intRangeMaxValueLabel.TabIndex = 3;
            this.intRangeMaxValueLabel.Text = "Макс. значение";
            // 
            // intRangeOrderLabel
            // 
            this.intRangeOrderLabel.AutoSize = true;
            this.intRangeOrderLabel.Location = new System.Drawing.Point(183, 0);
            this.intRangeOrderLabel.Name = "intRangeOrderLabel";
            this.intRangeOrderLabel.Size = new System.Drawing.Size(51, 13);
            this.intRangeOrderLabel.TabIndex = 4;
            this.intRangeOrderLabel.Text = "Порядок";
            // 
            // floatRangePanel
            // 
            this.floatRangePanel.AutoSize = true;
            this.floatRangePanel.ColumnCount = 5;
            this.floatRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.floatRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.floatRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.floatRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.floatRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.floatRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.floatRangePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.floatRangePanel.Controls.Add(this.floatRangeMinValueLabel, 0, 0);
            this.floatRangePanel.Controls.Add(this.floatRangeMaxValueLabel, 1, 0);
            this.floatRangePanel.Controls.Add(this.precisionLabel, 2, 0);
            this.floatRangePanel.Controls.Add(this.floatRangeOrderLabel, 3, 0);
            this.floatRangePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.floatRangePanel.Location = new System.Drawing.Point(3, 101);
            this.floatRangePanel.Name = "floatRangePanel";
            this.floatRangePanel.RowCount = 1;
            this.floatRangePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.floatRangePanel.Size = new System.Drawing.Size(618, 13);
            this.floatRangePanel.TabIndex = 5;
            // 
            // floatRangeMinValueLabel
            // 
            this.floatRangeMinValueLabel.AutoSize = true;
            this.floatRangeMinValueLabel.Location = new System.Drawing.Point(3, 0);
            this.floatRangeMinValueLabel.Name = "floatRangeMinValueLabel";
            this.floatRangeMinValueLabel.Size = new System.Drawing.Size(81, 13);
            this.floatRangeMinValueLabel.TabIndex = 2;
            this.floatRangeMinValueLabel.Text = "Мин. значение";
            // 
            // floatRangeMaxValueLabel
            // 
            this.floatRangeMaxValueLabel.AutoSize = true;
            this.floatRangeMaxValueLabel.Location = new System.Drawing.Point(90, 0);
            this.floatRangeMaxValueLabel.Name = "floatRangeMaxValueLabel";
            this.floatRangeMaxValueLabel.Size = new System.Drawing.Size(87, 13);
            this.floatRangeMaxValueLabel.TabIndex = 3;
            this.floatRangeMaxValueLabel.Text = "Макс. значение";
            // 
            // precisionLabel
            // 
            this.precisionLabel.AutoSize = true;
            this.precisionLabel.Location = new System.Drawing.Point(183, 0);
            this.precisionLabel.Name = "precisionLabel";
            this.precisionLabel.Size = new System.Drawing.Size(54, 13);
            this.precisionLabel.TabIndex = 4;
            this.precisionLabel.Text = "Точность";
            // 
            // floatRangeOrderLabel
            // 
            this.floatRangeOrderLabel.AutoSize = true;
            this.floatRangeOrderLabel.Location = new System.Drawing.Point(243, 0);
            this.floatRangeOrderLabel.Name = "floatRangeOrderLabel";
            this.floatRangeOrderLabel.Size = new System.Drawing.Size(51, 13);
            this.floatRangeOrderLabel.TabIndex = 5;
            this.floatRangeOrderLabel.Text = "Порядок";
            // 
            // bottomPanel
            // 
            this.bottomPanel.AutoSize = true;
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Controls.Add(this.saveButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 252);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(624, 29);
            this.bottomPanel.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(465, 3);
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
            this.saveButton.Location = new System.Drawing.Point(546, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Применить";
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
            // OrderableParameterListDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 281);
            this.Controls.Add(this.mainPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 320);
            this.Name = "OrderableParameterListDialog";
            this.Text = "ParameterListDialog";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.fromListPanel.ResumeLayout(false);
            this.fromListPanel.PerformLayout();
            this.intRangePanel.ResumeLayout(false);
            this.intRangePanel.PerformLayout();
            this.floatRangePanel.ResumeLayout(false);
            this.floatRangePanel.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel intRangePanel;
        private System.Windows.Forms.Label intRangeMinValueLabel;
        private System.Windows.Forms.Label intRangeMaxValueLabel;
        private System.Windows.Forms.TableLayoutPanel floatRangePanel;
        private System.Windows.Forms.Label floatRangeMinValueLabel;
        private System.Windows.Forms.Label floatRangeMaxValueLabel;
        private System.Windows.Forms.Label precisionLabel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label fromListOrderLabel;
        private System.Windows.Forms.Label intRangeOrderLabel;
        private System.Windows.Forms.Label floatRangeOrderLabel;
        private System.Windows.Forms.Label valueListLabel;
    }
}