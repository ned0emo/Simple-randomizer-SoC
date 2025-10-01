namespace Simple_randomizer_SoC.Forms.Templates
{
    partial class DeathItemsControl
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
            this.communityProbabilityButton = new System.Windows.Forms.Button();
            this.levelCountButton = new System.Windows.Forms.Button();
            this.difficultyCountButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.itemsLabel = new System.Windows.Forms.Label();
            this.editListButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.communityProbabilityButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.levelCountButton, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.difficultyCountButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.titleLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.itemsLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.editListButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(709, 268);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // communityProbabilityButton
            // 
            this.communityProbabilityButton.AutoSize = true;
            this.communityProbabilityButton.Location = new System.Drawing.Point(335, 106);
            this.communityProbabilityButton.Name = "communityProbabilityButton";
            this.communityProbabilityButton.Size = new System.Drawing.Size(133, 23);
            this.communityProbabilityButton.TabIndex = 13;
            this.communityProbabilityButton.Text = "Редактировать список";
            this.communityProbabilityButton.UseVisualStyleBackColor = true;
            this.communityProbabilityButton.Click += new System.EventHandler(this.communityProbabilityButton_Click);
            // 
            // levelCountButton
            // 
            this.levelCountButton.AutoSize = true;
            this.levelCountButton.Location = new System.Drawing.Point(335, 77);
            this.levelCountButton.Name = "levelCountButton";
            this.levelCountButton.Size = new System.Drawing.Size(133, 23);
            this.levelCountButton.TabIndex = 12;
            this.levelCountButton.Text = "Редактировать список";
            this.levelCountButton.UseVisualStyleBackColor = true;
            this.levelCountButton.Click += new System.EventHandler(this.levelCountButton_Click);
            // 
            // difficultyCountButton
            // 
            this.difficultyCountButton.AutoSize = true;
            this.difficultyCountButton.Location = new System.Drawing.Point(335, 48);
            this.difficultyCountButton.Name = "difficultyCountButton";
            this.difficultyCountButton.Size = new System.Drawing.Size(133, 23);
            this.difficultyCountButton.TabIndex = 11;
            this.difficultyCountButton.Text = "Редактировать список";
            this.difficultyCountButton.UseVisualStyleBackColor = true;
            this.difficultyCountButton.Click += new System.EventHandler(this.difficultyCountButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Количество в зависимости от уровня сложности";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.titleLabel, 2);
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleLabel.Location = new System.Drawing.Point(3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(703, 16);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // itemsLabel
            // 
            this.itemsLabel.AutoSize = true;
            this.itemsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.itemsLabel.Location = new System.Drawing.Point(3, 16);
            this.itemsLabel.Name = "itemsLabel";
            this.itemsLabel.Size = new System.Drawing.Size(326, 29);
            this.itemsLabel.TabIndex = 1;
            this.itemsLabel.Text = "Список предметов";
            this.itemsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // editListButton
            // 
            this.editListButton.AutoSize = true;
            this.editListButton.Location = new System.Drawing.Point(335, 19);
            this.editListButton.Name = "editListButton";
            this.editListButton.Size = new System.Drawing.Size(133, 23);
            this.editListButton.TabIndex = 2;
            this.editListButton.Text = "Редактировать список";
            this.editListButton.UseVisualStyleBackColor = true;
            this.editListButton.Click += new System.EventHandler(this.editListButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(326, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Множитель в зависимости от локации";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(326, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Вероятность в зависимости от группировки";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DeathItemsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DeathItemsControl";
            this.Size = new System.Drawing.Size(709, 268);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label itemsLabel;
        private System.Windows.Forms.Button editListButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button communityProbabilityButton;
        private System.Windows.Forms.Button levelCountButton;
        private System.Windows.Forms.Button difficultyCountButton;
    }
}
