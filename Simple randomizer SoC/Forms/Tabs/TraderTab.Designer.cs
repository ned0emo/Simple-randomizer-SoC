namespace Simple_randomizer_SoC.Forms.Tabs
{
    partial class TraderTab
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.parametersPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.probabilityInput = new System.Windows.Forms.NumericUpDown();
            this.probabilityLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.buyButton = new System.Windows.Forms.Button();
            this.sellButton = new System.Windows.Forms.Button();
            this.countProbabilitySectionsLabel = new System.Windows.Forms.Label();
            this.sellMultiplierSectionsLabel = new System.Windows.Forms.Label();
            this.buyMultiplierSectionsLabel = new System.Windows.Forms.Label();
            this.countProbabilityButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityInput)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.titleLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(459, 330);
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
            this.titleLabel.Size = new System.Drawing.Size(459, 26);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Настройки генерации ассортимента торговцев";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.parametersPanel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 29);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(453, 298);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // parametersPanel
            // 
            this.parametersPanel.AutoSize = true;
            this.parametersPanel.ColumnCount = 1;
            this.parametersPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.parametersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parametersPanel.Location = new System.Drawing.Point(0, 0);
            this.parametersPanel.Margin = new System.Windows.Forms.Padding(0);
            this.parametersPanel.Name = "parametersPanel";
            this.parametersPanel.RowCount = 2;
            this.parametersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.parametersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.parametersPanel.Size = new System.Drawing.Size(453, 1);
            this.parametersPanel.TabIndex = 8;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.probabilityInput, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.probabilityLabel, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 87);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(453, 26);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // probabilityInput
            // 
            this.probabilityInput.Location = new System.Drawing.Point(3, 3);
            this.probabilityInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.probabilityInput.Name = "probabilityInput";
            this.probabilityInput.Size = new System.Drawing.Size(53, 20);
            this.probabilityInput.TabIndex = 0;
            this.probabilityInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.probabilityInput.ValueChanged += new System.EventHandler(this.probabilityInput_ValueChanged_1);
            // 
            // probabilityLabel
            // 
            this.probabilityLabel.AutoSize = true;
            this.probabilityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.probabilityLabel.Location = new System.Drawing.Point(62, 0);
            this.probabilityLabel.Name = "probabilityLabel";
            this.probabilityLabel.Size = new System.Drawing.Size(388, 26);
            this.probabilityLabel.TabIndex = 1;
            this.probabilityLabel.Text = "Вероятность генерации наличия каждого предмета";
            this.probabilityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.buyButton, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.sellButton, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.countProbabilitySectionsLabel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.sellMultiplierSectionsLabel, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.buyMultiplierSectionsLabel, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.countProbabilityButton, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(453, 87);
            this.tableLayoutPanel4.TabIndex = 10;
            // 
            // buyButton
            // 
            this.buyButton.AutoSize = true;
            this.buyButton.Location = new System.Drawing.Point(315, 61);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(133, 23);
            this.buyButton.TabIndex = 5;
            this.buyButton.Text = "Редактировать список";
            this.buyButton.UseVisualStyleBackColor = true;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // sellButton
            // 
            this.sellButton.AutoSize = true;
            this.sellButton.Location = new System.Drawing.Point(315, 32);
            this.sellButton.Name = "sellButton";
            this.sellButton.Size = new System.Drawing.Size(133, 23);
            this.sellButton.TabIndex = 4;
            this.sellButton.Text = "Редактировать список";
            this.sellButton.UseVisualStyleBackColor = true;
            this.sellButton.Click += new System.EventHandler(this.sellButton_Click);
            // 
            // countProbabilitySectionsLabel
            // 
            this.countProbabilitySectionsLabel.AutoSize = true;
            this.countProbabilitySectionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.countProbabilitySectionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countProbabilitySectionsLabel.Location = new System.Drawing.Point(3, 0);
            this.countProbabilitySectionsLabel.Name = "countProbabilitySectionsLabel";
            this.countProbabilitySectionsLabel.Size = new System.Drawing.Size(306, 29);
            this.countProbabilitySectionsLabel.TabIndex = 0;
            this.countProbabilitySectionsLabel.Text = "Секции количества и вероятности появления";
            this.countProbabilitySectionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sellMultiplierSectionsLabel
            // 
            this.sellMultiplierSectionsLabel.AutoSize = true;
            this.sellMultiplierSectionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sellMultiplierSectionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sellMultiplierSectionsLabel.Location = new System.Drawing.Point(3, 29);
            this.sellMultiplierSectionsLabel.Name = "sellMultiplierSectionsLabel";
            this.sellMultiplierSectionsLabel.Size = new System.Drawing.Size(306, 29);
            this.sellMultiplierSectionsLabel.TabIndex = 1;
            this.sellMultiplierSectionsLabel.Text = "Секции множителей цен продажи игроку";
            this.sellMultiplierSectionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buyMultiplierSectionsLabel
            // 
            this.buyMultiplierSectionsLabel.AutoSize = true;
            this.buyMultiplierSectionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buyMultiplierSectionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buyMultiplierSectionsLabel.Location = new System.Drawing.Point(3, 58);
            this.buyMultiplierSectionsLabel.Name = "buyMultiplierSectionsLabel";
            this.buyMultiplierSectionsLabel.Size = new System.Drawing.Size(306, 29);
            this.buyMultiplierSectionsLabel.TabIndex = 2;
            this.buyMultiplierSectionsLabel.Text = "Секции множителей цен покупки у игрока";
            this.buyMultiplierSectionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // countProbabilityButton
            // 
            this.countProbabilityButton.AutoSize = true;
            this.countProbabilityButton.Location = new System.Drawing.Point(315, 3);
            this.countProbabilityButton.Name = "countProbabilityButton";
            this.countProbabilityButton.Size = new System.Drawing.Size(133, 23);
            this.countProbabilityButton.TabIndex = 3;
            this.countProbabilityButton.Text = "Редактировать список";
            this.countProbabilityButton.UseVisualStyleBackColor = true;
            this.countProbabilityButton.Click += new System.EventHandler(this.countProbabilityButton_Click);
            // 
            // TraderTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TraderTab";
            this.Size = new System.Drawing.Size(459, 330);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityInput)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel parametersPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.NumericUpDown probabilityInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label countProbabilitySectionsLabel;
        private System.Windows.Forms.Label sellMultiplierSectionsLabel;
        private System.Windows.Forms.Label buyMultiplierSectionsLabel;
        private System.Windows.Forms.Button buyButton;
        private System.Windows.Forms.Button sellButton;
        private System.Windows.Forms.Button countProbabilityButton;
        private System.Windows.Forms.Label probabilityLabel;
    }
}
