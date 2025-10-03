using Simple_randomizer_SoC.Forms.Tabs;

namespace RandomizerSoC
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.stashTab = new System.Windows.Forms.TabPage();
            this.weaponTab = new System.Windows.Forms.TabPage();
            this.itemTab = new System.Windows.Forms.TabPage();
            this.npcTab = new System.Windows.Forms.TabPage();
            this.weatherTab = new System.Windows.Forms.TabPage();
            this.soundTextureTab = new System.Windows.Forms.TabPage();
            this.traderTab = new System.Windows.Forms.TabPage();
            this.deathTab = new System.Windows.Forms.TabPage();
            this.dialogTab = new System.Windows.Forms.TabPage();
            this.additionalTab = new System.Windows.Forms.TabPage();
            this.aboutTab = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.generateButton = new System.Windows.Forms.Button();
            this.langComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl.SuspendLayout();
            this.aboutTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.stashTab);
            this.tabControl.Controls.Add(this.weaponTab);
            this.tabControl.Controls.Add(this.itemTab);
            this.tabControl.Controls.Add(this.npcTab);
            this.tabControl.Controls.Add(this.weatherTab);
            this.tabControl.Controls.Add(this.soundTextureTab);
            this.tabControl.Controls.Add(this.traderTab);
            this.tabControl.Controls.Add(this.deathTab);
            this.tabControl.Controls.Add(this.dialogTab);
            this.tabControl.Controls.Add(this.additionalTab);
            this.tabControl.Controls.Add(this.aboutTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(692, 394);
            this.tabControl.TabIndex = 6;
            // 
            // stashTab
            // 
            this.stashTab.Location = new System.Drawing.Point(4, 40);
            this.stashTab.Name = "stashTab";
            this.stashTab.Padding = new System.Windows.Forms.Padding(3);
            this.stashTab.Size = new System.Drawing.Size(684, 356);
            this.stashTab.TabIndex = 15;
            this.stashTab.Text = "Тайники";
            this.stashTab.UseVisualStyleBackColor = true;
            // 
            // weaponTab
            // 
            this.weaponTab.Location = new System.Drawing.Point(4, 40);
            this.weaponTab.Name = "weaponTab";
            this.weaponTab.Padding = new System.Windows.Forms.Padding(3);
            this.weaponTab.Size = new System.Drawing.Size(684, 356);
            this.weaponTab.TabIndex = 16;
            this.weaponTab.Text = "Оружие";
            this.weaponTab.UseVisualStyleBackColor = true;
            // 
            // itemTab
            // 
            this.itemTab.Location = new System.Drawing.Point(4, 40);
            this.itemTab.Name = "itemTab";
            this.itemTab.Padding = new System.Windows.Forms.Padding(3);
            this.itemTab.Size = new System.Drawing.Size(684, 356);
            this.itemTab.TabIndex = 17;
            this.itemTab.Text = "Предметы";
            this.itemTab.UseVisualStyleBackColor = true;
            // 
            // npcTab
            // 
            this.npcTab.Location = new System.Drawing.Point(4, 40);
            this.npcTab.Name = "npcTab";
            this.npcTab.Padding = new System.Windows.Forms.Padding(3);
            this.npcTab.Size = new System.Drawing.Size(684, 356);
            this.npcTab.TabIndex = 19;
            this.npcTab.Text = "НПС";
            this.npcTab.UseVisualStyleBackColor = true;
            // 
            // weatherTab
            // 
            this.weatherTab.Location = new System.Drawing.Point(4, 40);
            this.weatherTab.Name = "weatherTab";
            this.weatherTab.Padding = new System.Windows.Forms.Padding(3);
            this.weatherTab.Size = new System.Drawing.Size(684, 356);
            this.weatherTab.TabIndex = 18;
            this.weatherTab.Text = "Погода";
            this.weatherTab.UseVisualStyleBackColor = true;
            // 
            // soundTextureTab
            // 
            this.soundTextureTab.Location = new System.Drawing.Point(4, 40);
            this.soundTextureTab.Name = "soundTextureTab";
            this.soundTextureTab.Padding = new System.Windows.Forms.Padding(3);
            this.soundTextureTab.Size = new System.Drawing.Size(684, 356);
            this.soundTextureTab.TabIndex = 20;
            this.soundTextureTab.Text = "Звуки/текстуры";
            this.soundTextureTab.UseVisualStyleBackColor = true;
            // 
            // traderTab
            // 
            this.traderTab.Location = new System.Drawing.Point(4, 40);
            this.traderTab.Name = "traderTab";
            this.traderTab.Padding = new System.Windows.Forms.Padding(3);
            this.traderTab.Size = new System.Drawing.Size(684, 356);
            this.traderTab.TabIndex = 22;
            this.traderTab.Text = "Ассортимент торговцев";
            this.traderTab.UseVisualStyleBackColor = true;
            // 
            // deathTab
            // 
            this.deathTab.Location = new System.Drawing.Point(4, 40);
            this.deathTab.Name = "deathTab";
            this.deathTab.Padding = new System.Windows.Forms.Padding(3);
            this.deathTab.Size = new System.Drawing.Size(684, 356);
            this.deathTab.TabIndex = 23;
            this.deathTab.Text = "Вещи убитых НПС";
            this.deathTab.UseVisualStyleBackColor = true;
            // 
            // dialogTab
            // 
            this.dialogTab.Location = new System.Drawing.Point(4, 40);
            this.dialogTab.Name = "dialogTab";
            this.dialogTab.Padding = new System.Windows.Forms.Padding(3);
            this.dialogTab.Size = new System.Drawing.Size(684, 356);
            this.dialogTab.TabIndex = 21;
            this.dialogTab.Text = "Диалоги";
            this.dialogTab.UseVisualStyleBackColor = true;
            // 
            // additionalTab
            // 
            this.additionalTab.Location = new System.Drawing.Point(4, 40);
            this.additionalTab.Name = "additionalTab";
            this.additionalTab.Padding = new System.Windows.Forms.Padding(3);
            this.additionalTab.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.additionalTab.Size = new System.Drawing.Size(684, 356);
            this.additionalTab.TabIndex = 9;
            this.additionalTab.Text = "Дополнительно";
            this.additionalTab.UseVisualStyleBackColor = true;
            // 
            // aboutTab
            // 
            this.aboutTab.Controls.Add(this.tableLayoutPanel3);
            this.aboutTab.Location = new System.Drawing.Point(4, 40);
            this.aboutTab.Name = "aboutTab";
            this.aboutTab.Padding = new System.Windows.Forms.Padding(3);
            this.aboutTab.Size = new System.Drawing.Size(684, 350);
            this.aboutTab.TabIndex = 24;
            this.aboutTab.Text = "О программе";
            this.aboutTab.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 75);
            this.label8.TabIndex = 22;
            this.label8.Text = "©ned0emo, ver 2.0\r\n\r\nUsed libraries:\r\nNVorbis by Andrew Ward\r\nPrettyBin by Andrey" +
    " Ershov";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(2, 97);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(314, 20);
            this.textBox1.TabIndex = 21;
            this.textBox1.Text = "https://github.com/ned0emo/Simple-randomizer-SoC";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(698, 435);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.generateButton, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.langComboBox, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 403);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(692, 29);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // generateButton
            // 
            this.generateButton.AutoSize = true;
            this.generateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateButton.Location = new System.Drawing.Point(582, 3);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(107, 23);
            this.generateButton.TabIndex = 0;
            this.generateButton.Text = "Сгенерировать";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // langComboBox
            // 
            this.langComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.langComboBox.FormattingEnabled = true;
            this.langComboBox.Items.AddRange(new object[] {
            "Русский/Russian",
            "Английский/English"});
            this.langComboBox.Location = new System.Drawing.Point(455, 3);
            this.langComboBox.Name = "langComboBox";
            this.langComboBox.Size = new System.Drawing.Size(121, 21);
            this.langComboBox.TabIndex = 1;
            this.langComboBox.SelectedIndexChanged += new System.EventHandler(this.langComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(358, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Язык/Language:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.statusLabel);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 29);
            this.panel1.TabIndex = 3;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.statusLabel.Location = new System.Drawing.Point(8, 8);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 13);
            this.statusLabel.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(355, 29);
            this.progressBar.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.textBox1, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(678, 344);
            this.tableLayoutPanel3.TabIndex = 23;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(720, 480);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Рандомайзер Тень Чернобыля";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.aboutTab.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage additionalTab;
        private System.Windows.Forms.TabPage stashTab;
        private System.Windows.Forms.TabPage weaponTab;
        private System.Windows.Forms.TabPage itemTab;
        private System.Windows.Forms.TabPage weatherTab;
        private System.Windows.Forms.TabPage npcTab;
        private System.Windows.Forms.TabPage soundTextureTab;
        private System.Windows.Forms.TabPage dialogTab;
        private System.Windows.Forms.TabPage traderTab;
        private System.Windows.Forms.TabPage deathTab;
        private System.Windows.Forms.TabPage aboutTab;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.ComboBox langComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}

