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
            this.titleLabel = new System.Windows.Forms.Label();
            this.rootContentPanel = new System.Windows.Forms.Panel();
            this.mainContentPanel = new System.Windows.Forms.TableLayoutPanel();
            this.topPanel = new System.Windows.Forms.TableLayoutPanel();
            this.weatherParamsLabel = new System.Windows.Forms.Label();
            this.weatherSectionsButton = new System.Windows.Forms.Button();
            this.weatherSectionsLabel = new System.Windows.Forms.Label();
            this.weatherParametersButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.bottomPanel = new System.Windows.Forms.TableLayoutPanel();
            this.weatherProbabilityLabel = new System.Windows.Forms.Label();
            this.thunderProbabilityLabel = new System.Windows.Forms.Label();
            this.weatherProbabilityInput = new System.Windows.Forms.NumericUpDown();
            this.thunderProbabilityInput = new System.Windows.Forms.NumericUpDown();
            this.rainProbabilityLabel = new System.Windows.Forms.Label();
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
            this.titleLabel.Text = "Настройка генерации параметров погоды";
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
            this.topPanel.Controls.Add(this.weatherParamsLabel, 0, 1);
            this.topPanel.Controls.Add(this.weatherSectionsButton, 1, 0);
            this.topPanel.Controls.Add(this.weatherSectionsLabel, 0, 0);
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
            // weatherParamsLAbel
            // 
            this.weatherParamsLabel.AutoSize = true;
            this.weatherParamsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weatherParamsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.weatherParamsLabel.Location = new System.Drawing.Point(3, 29);
            this.weatherParamsLabel.Name = "weatherParamsLAbel";
            this.weatherParamsLabel.Size = new System.Drawing.Size(237, 29);
            this.weatherParamsLabel.TabIndex = 38;
            this.weatherParamsLabel.Text = "Генерируемые параметры";
            this.weatherParamsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // weatherSectionsLabel
            // 
            this.weatherSectionsLabel.AutoSize = true;
            this.weatherSectionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weatherSectionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.weatherSectionsLabel.Location = new System.Drawing.Point(3, 0);
            this.weatherSectionsLabel.Name = "weatherSectionsLabel";
            this.weatherSectionsLabel.Size = new System.Drawing.Size(237, 29);
            this.weatherSectionsLabel.TabIndex = 1;
            this.weatherSectionsLabel.Text = "Секции для генерации параметров";
            this.weatherSectionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.bottomPanel.Controls.Add(this.weatherProbabilityLabel, 1, 2);
            this.bottomPanel.Controls.Add(this.thunderProbabilityLabel, 1, 1);
            this.bottomPanel.Controls.Add(this.weatherProbabilityInput, 0, 2);
            this.bottomPanel.Controls.Add(this.thunderProbabilityInput, 0, 1);
            this.bottomPanel.Controls.Add(this.rainProbabilityLabel, 1, 0);
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
            // weatherProbabilityLabel
            // 
            this.weatherProbabilityLabel.AutoSize = true;
            this.weatherProbabilityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weatherProbabilityLabel.Location = new System.Drawing.Point(62, 52);
            this.weatherProbabilityLabel.Name = "weatherProbabilityLabel";
            this.weatherProbabilityLabel.Size = new System.Drawing.Size(442, 26);
            this.weatherProbabilityLabel.TabIndex = 51;
            this.weatherProbabilityLabel.Text = "Вероятность генерации каждого параметра погоды";
            this.weatherProbabilityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // thunderProbabilityLabel
            // 
            this.thunderProbabilityLabel.AutoSize = true;
            this.thunderProbabilityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thunderProbabilityLabel.Location = new System.Drawing.Point(62, 26);
            this.thunderProbabilityLabel.Name = "thunderProbabilityLabel";
            this.thunderProbabilityLabel.Size = new System.Drawing.Size(442, 26);
            this.thunderProbabilityLabel.TabIndex = 50;
            this.thunderProbabilityLabel.Text = "Вероятность грозы для каждой секции погоды";
            this.thunderProbabilityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // rainProbabilityLabel
            // 
            this.rainProbabilityLabel.AutoSize = true;
            this.rainProbabilityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rainProbabilityLabel.Location = new System.Drawing.Point(62, 0);
            this.rainProbabilityLabel.Name = "rainProbabilityLabel";
            this.rainProbabilityLabel.Size = new System.Drawing.Size(442, 26);
            this.rainProbabilityLabel.TabIndex = 46;
            this.rainProbabilityLabel.Text = "Вероятность дождя для каждой секции погоды";
            this.rainProbabilityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel rootContentPanel;
        private System.Windows.Forms.TableLayoutPanel mainContentPanel;
        private System.Windows.Forms.TableLayoutPanel topPanel;
        private System.Windows.Forms.Label weatherParamsLabel;
        private System.Windows.Forms.Button weatherSectionsButton;
        private System.Windows.Forms.Label weatherSectionsLabel;
        private System.Windows.Forms.Button weatherParametersButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel bottomPanel;
        private System.Windows.Forms.Label rainProbabilityLabel;
        private System.Windows.Forms.NumericUpDown rainProbabilityInput;
        private System.Windows.Forms.Label weatherProbabilityLabel;
        private System.Windows.Forms.Label thunderProbabilityLabel;
        private System.Windows.Forms.NumericUpDown weatherProbabilityInput;
        private System.Windows.Forms.NumericUpDown thunderProbabilityInput;
    }
}
