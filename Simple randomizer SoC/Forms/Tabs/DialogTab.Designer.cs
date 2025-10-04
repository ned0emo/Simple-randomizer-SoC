namespace Simple_randomizer_SoC.Forms.Tabs
{
    partial class DialogTab
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
            this.preconditionExceptionaLabel = new System.Windows.Forms.Label();
            this.preconditionExceptionsButton = new System.Windows.Forms.Button();
            this.infoExceptionsLabel = new System.Windows.Forms.Label();
            this.actionExceptionsLabel = new System.Windows.Forms.Label();
            this.infoExceptionsButton = new System.Windows.Forms.Button();
            this.actionExceptionsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.probabilityInput = new System.Windows.Forms.NumericUpDown();
            this.probabilityLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityInput)).BeginInit();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(489, 342);
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
            this.titleLabel.Size = new System.Drawing.Size(489, 26);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Настройки генерации диалогов";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.preconditionExceptionaLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.preconditionExceptionsButton, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.infoExceptionsLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.actionExceptionsLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.infoExceptionsButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.actionExceptionsButton, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 29);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(483, 310);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // preconditionExceptionaLabel
            // 
            this.preconditionExceptionaLabel.AutoSize = true;
            this.preconditionExceptionaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preconditionExceptionaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.preconditionExceptionaLabel.Location = new System.Drawing.Point(3, 58);
            this.preconditionExceptionaLabel.Name = "preconditionExceptionaLabel";
            this.preconditionExceptionaLabel.Size = new System.Drawing.Size(162, 29);
            this.preconditionExceptionaLabel.TabIndex = 6;
            this.preconditionExceptionaLabel.Text = "Исключенные условия";
            this.preconditionExceptionaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // preconditionExceptionsButton
            // 
            this.preconditionExceptionsButton.AutoSize = true;
            this.preconditionExceptionsButton.Location = new System.Drawing.Point(171, 61);
            this.preconditionExceptionsButton.Name = "preconditionExceptionsButton";
            this.preconditionExceptionsButton.Size = new System.Drawing.Size(133, 23);
            this.preconditionExceptionsButton.TabIndex = 5;
            this.preconditionExceptionsButton.Text = "Редактировать список";
            this.preconditionExceptionsButton.UseVisualStyleBackColor = true;
            this.preconditionExceptionsButton.Click += new System.EventHandler(this.preconditionExceptionsButton_Click);
            // 
            // infoExceptionsLabel
            // 
            this.infoExceptionsLabel.AutoSize = true;
            this.infoExceptionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoExceptionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoExceptionsLabel.Location = new System.Drawing.Point(3, 0);
            this.infoExceptionsLabel.Name = "infoExceptionsLabel";
            this.infoExceptionsLabel.Size = new System.Drawing.Size(162, 29);
            this.infoExceptionsLabel.TabIndex = 0;
            this.infoExceptionsLabel.Text = "Исключенные события";
            this.infoExceptionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // actionExceptionsLabel
            // 
            this.actionExceptionsLabel.AutoSize = true;
            this.actionExceptionsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionExceptionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.actionExceptionsLabel.Location = new System.Drawing.Point(3, 29);
            this.actionExceptionsLabel.Name = "actionExceptionsLabel";
            this.actionExceptionsLabel.Size = new System.Drawing.Size(162, 29);
            this.actionExceptionsLabel.TabIndex = 1;
            this.actionExceptionsLabel.Text = "Исключенные действия";
            this.actionExceptionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // infoExceptionsButton
            // 
            this.infoExceptionsButton.AutoSize = true;
            this.infoExceptionsButton.Location = new System.Drawing.Point(171, 3);
            this.infoExceptionsButton.Name = "infoExceptionsButton";
            this.infoExceptionsButton.Size = new System.Drawing.Size(133, 23);
            this.infoExceptionsButton.TabIndex = 3;
            this.infoExceptionsButton.Text = "Редактировать список";
            this.infoExceptionsButton.UseVisualStyleBackColor = true;
            this.infoExceptionsButton.Click += new System.EventHandler(this.infoExceptionsButton_Click);
            // 
            // actionExceptionsButton
            // 
            this.actionExceptionsButton.AutoSize = true;
            this.actionExceptionsButton.Location = new System.Drawing.Point(171, 32);
            this.actionExceptionsButton.Name = "actionExceptionsButton";
            this.actionExceptionsButton.Size = new System.Drawing.Size(133, 23);
            this.actionExceptionsButton.TabIndex = 4;
            this.actionExceptionsButton.Text = "Редактировать список";
            this.actionExceptionsButton.UseVisualStyleBackColor = true;
            this.actionExceptionsButton.Click += new System.EventHandler(this.actionExceptionsButton_Click);
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(483, 26);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // probabilityInput
            // 
            this.probabilityInput.Location = new System.Drawing.Point(3, 3);
            this.probabilityInput.Name = "probabilityInput";
            this.probabilityInput.Size = new System.Drawing.Size(53, 20);
            this.probabilityInput.TabIndex = 0;
            this.probabilityInput.ValueChanged += new System.EventHandler(this.probabilityInput_ValueChanged);
            // 
            // probabilityLabel
            // 
            this.probabilityLabel.AutoSize = true;
            this.probabilityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.probabilityLabel.Location = new System.Drawing.Point(62, 0);
            this.probabilityLabel.Name = "probabilityLabel";
            this.probabilityLabel.Size = new System.Drawing.Size(418, 26);
            this.probabilityLabel.TabIndex = 1;
            this.probabilityLabel.Text = "Вероятность генерации каждого диалога";
            this.probabilityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DialogTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DialogTab";
            this.Size = new System.Drawing.Size(489, 342);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label infoExceptionsLabel;
        private System.Windows.Forms.Label actionExceptionsLabel;
        private System.Windows.Forms.Button infoExceptionsButton;
        private System.Windows.Forms.Button actionExceptionsButton;
        private System.Windows.Forms.Label preconditionExceptionaLabel;
        private System.Windows.Forms.Button preconditionExceptionsButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.NumericUpDown probabilityInput;
        private System.Windows.Forms.Label probabilityLabel;
    }
}
