namespace Simple_randomizer_SoC.Forms.Tabs
{
    partial class WeatherTab
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
            this.weatherSectionsButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.weatherParametersButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.bottomPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.weatherProbabilityInput = new System.Windows.Forms.NumericUpDown();
            this.thunderProbabilityInput = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.rainProbabilityInput = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.rootContentPanel.SuspendLayout();
            this.mainContentPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weatherProbabilityInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thunderProbabilityInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rainProbabilityInput)).BeginInit();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(513, 381);
            this.tableLayoutPanel1.TabIndex = 1;
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
            this.label1.Size = new System.Drawing.Size(513, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Настройка генерации параметров погоды";
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
            this.topPanel.ColumnCount = 2;
            this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topPanel.Controls.Add(this.label11, 0, 1);
            this.topPanel.Controls.Add(this.weatherSectionsButton, 1, 0);
            this.topPanel.Controls.Add(this.label2, 0, 0);
            this.topPanel.Controls.Add(this.weatherParametersButton, 1, 1);
            this.topPanel.Controls.Add(this.tableLayoutPanel4, 1, 2);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(0);
            this.topPanel.Name = "topPanel";
            this.topPanel.RowCount = 2;
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
            this.topPanel.Size = new System.Drawing.Size(507, 58);
            this.topPanel.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(3, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(237, 29);
            this.label11.TabIndex = 38;
            this.label11.Text = "Генерируемые параметры";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // weatherSectionsButton
            // 
            this.weatherSectionsButton.Location = new System.Drawing.Point(246, 3);
            this.weatherSectionsButton.Name = "weatherSectionsButton";
            this.weatherSectionsButton.Size = new System.Drawing.Size(154, 23);
            this.weatherSectionsButton.TabIndex = 32;
            this.weatherSectionsButton.Text = "Редактировать список";
            this.weatherSectionsButton.UseVisualStyleBackColor = true;
            this.weatherSectionsButton.Click += new System.EventHandler(this.weatherSectionsButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Секции для генерации параметров";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // weatherParametersButton
            // 
            this.weatherParametersButton.Location = new System.Drawing.Point(246, 32);
            this.weatherParametersButton.Name = "weatherParametersButton";
            this.weatherParametersButton.Size = new System.Drawing.Size(154, 23);
            this.weatherParametersButton.TabIndex = 33;
            this.weatherParametersButton.Text = "Редактировать список";
            this.weatherParametersButton.UseVisualStyleBackColor = true;
            this.weatherParametersButton.Click += new System.EventHandler(this.weatherParametersButton_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(243, 58);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(264, 1);
            this.tableLayoutPanel4.TabIndex = 41;
            // 
            // bottomPanel
            // 
            this.bottomPanel.AutoSize = true;
            this.bottomPanel.ColumnCount = 2;
            this.bottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.bottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bottomPanel.Controls.Add(this.label9, 1, 2);
            this.bottomPanel.Controls.Add(this.label3, 1, 1);
            this.bottomPanel.Controls.Add(this.weatherProbabilityInput, 0, 2);
            this.bottomPanel.Controls.Add(this.thunderProbabilityInput, 0, 1);
            this.bottomPanel.Controls.Add(this.label8, 1, 0);
            this.bottomPanel.Controls.Add(this.rainProbabilityInput, 0, 0);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottomPanel.Location = new System.Drawing.Point(0, 58);
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.RowCount = 1;
            this.bottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.bottomPanel.Size = new System.Drawing.Size(507, 78);
            this.bottomPanel.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(62, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(442, 26);
            this.label9.TabIndex = 51;
            this.label9.Text = "Вероятность генерации каждого параметра погоды";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(62, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(442, 26);
            this.label3.TabIndex = 50;
            this.label3.Text = "Вероятность грозы для каждой секции погоды";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // weatherProbabilityInput
            // 
            this.weatherProbabilityInput.Location = new System.Drawing.Point(3, 55);
            this.weatherProbabilityInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.weatherProbabilityInput.Name = "weatherProbabilityInput";
            this.weatherProbabilityInput.Size = new System.Drawing.Size(53, 20);
            this.weatherProbabilityInput.TabIndex = 49;
            this.weatherProbabilityInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.weatherProbabilityInput.ValueChanged += new System.EventHandler(this.weatherProbabilityInput_ValueChanged);
            // 
            // thunderProbabilityInput
            // 
            this.thunderProbabilityInput.Location = new System.Drawing.Point(3, 29);
            this.thunderProbabilityInput.Name = "thunderProbabilityInput";
            this.thunderProbabilityInput.Size = new System.Drawing.Size(53, 20);
            this.thunderProbabilityInput.TabIndex = 47;
            this.thunderProbabilityInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thunderProbabilityInput.ValueChanged += new System.EventHandler(this.thunderProbabilityInput_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(62, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(442, 26);
            this.label8.TabIndex = 46;
            this.label8.Text = "Вероятность дождя для каждой секции погоды";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rainProbabilityInput
            // 
            this.rainProbabilityInput.Location = new System.Drawing.Point(3, 3);
            this.rainProbabilityInput.Name = "rainProbabilityInput";
            this.rainProbabilityInput.Size = new System.Drawing.Size(53, 20);
            this.rainProbabilityInput.TabIndex = 0;
            this.rainProbabilityInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rainProbabilityInput.ValueChanged += new System.EventHandler(this.rainProbabilityInput_ValueChanged);
            // 
            // WeatherTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "WeatherTab";
            this.Size = new System.Drawing.Size(513, 381);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.rootContentPanel.ResumeLayout(false);
            this.rootContentPanel.PerformLayout();
            this.mainContentPanel.ResumeLayout(false);
            this.mainContentPanel.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weatherProbabilityInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thunderProbabilityInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rainProbabilityInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel rootContentPanel;
        private System.Windows.Forms.TableLayoutPanel mainContentPanel;
        private System.Windows.Forms.TableLayoutPanel topPanel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button weatherSectionsButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button weatherParametersButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel bottomPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown rainProbabilityInput;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown weatherProbabilityInput;
        private System.Windows.Forms.NumericUpDown thunderProbabilityInput;
    }
}
