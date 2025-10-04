namespace Simple_randomizer_SoC.Forms.Templates
{
    partial class FormClosingControl
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
            this.forceCloseButton = new System.Windows.Forms.Button();
            this.mainLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.forceCloseButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.mainLabel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(338, 240);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // forceCloseButton
            // 
            this.forceCloseButton.AutoSize = true;
            this.forceCloseButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.forceCloseButton.Enabled = false;
            this.forceCloseButton.Location = new System.Drawing.Point(99, 123);
            this.forceCloseButton.Name = "forceCloseButton";
            this.forceCloseButton.Size = new System.Drawing.Size(140, 23);
            this.forceCloseButton.TabIndex = 1;
            this.forceCloseButton.Text = "Закрыть принудительно";
            this.forceCloseButton.UseVisualStyleBackColor = true;
            this.forceCloseButton.Click += new System.EventHandler(this.forceCloseButton_Click);
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mainLabel.Location = new System.Drawing.Point(99, 107);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(140, 13);
            this.mainLabel.TabIndex = 0;
            this.mainLabel.Text = "Завершение работы...";
            this.mainLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // FormClosingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormClosingControl";
            this.Size = new System.Drawing.Size(338, 240);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button forceCloseButton;
        private System.Windows.Forms.Label mainLabel;
    }
}
