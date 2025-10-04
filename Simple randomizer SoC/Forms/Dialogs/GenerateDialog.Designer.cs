namespace Simple_randomizer_SoC.Forms.Dialogs
{
    partial class GenerateDialog
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dialogsCheckBox = new System.Windows.Forms.CheckBox();
            this.texturesCheckBox = new System.Windows.Forms.CheckBox();
            this.randomProbabilityCheckBox = new System.Windows.Forms.CheckBox();
            this.selectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.stashesCheckBox = new System.Windows.Forms.CheckBox();
            this.artefactsCheckBox = new System.Windows.Forms.CheckBox();
            this.weaponsCheckBox = new System.Windows.Forms.CheckBox();
            this.armorCheckBox = new System.Windows.Forms.CheckBox();
            this.weatherCheckBox = new System.Windows.Forms.CheckBox();
            this.deathItemsCheckBox = new System.Windows.Forms.CheckBox();
            this.traderItemsCheckBox = new System.Windows.Forms.CheckBox();
            this.consumablesCheckBox = new System.Windows.Forms.CheckBox();
            this.npcCheckBox = new System.Windows.Forms.CheckBox();
            this.additionalParamsCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.saveInLabel = new System.Windows.Forms.Label();
            this.outputPathTextBox = new System.Windows.Forms.TextBox();
            this.selectPathButton = new System.Windows.Forms.Button();
            this.soundsCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dialogsCheckBox, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.texturesCheckBox, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.randomProbabilityCheckBox, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.selectAllCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.stashesCheckBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.artefactsCheckBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.weaponsCheckBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.armorCheckBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.weatherCheckBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.deathItemsCheckBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.traderItemsCheckBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.consumablesCheckBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.npcCheckBox, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.additionalParamsCheckBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.soundsCheckBox, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(464, 321);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dialogsCheckBox
            // 
            this.dialogsCheckBox.AutoSize = true;
            this.dialogsCheckBox.Location = new System.Drawing.Point(6, 167);
            this.dialogsCheckBox.Name = "dialogsCheckBox";
            this.dialogsCheckBox.Size = new System.Drawing.Size(70, 17);
            this.dialogsCheckBox.TabIndex = 16;
            this.dialogsCheckBox.Text = "Диалоги";
            this.dialogsCheckBox.UseVisualStyleBackColor = true;
            this.dialogsCheckBox.CheckedChanged += new System.EventHandler(this.dialogsCheckBox_CheckedChanged);
            // 
            // texturesCheckBox
            // 
            this.texturesCheckBox.AutoSize = true;
            this.texturesCheckBox.Location = new System.Drawing.Point(6, 144);
            this.texturesCheckBox.Name = "texturesCheckBox";
            this.texturesCheckBox.Size = new System.Drawing.Size(75, 17);
            this.texturesCheckBox.TabIndex = 14;
            this.texturesCheckBox.Text = "Текстуры";
            this.texturesCheckBox.UseVisualStyleBackColor = true;
            this.texturesCheckBox.CheckedChanged += new System.EventHandler(this.texturesCheckBox_CheckedChanged);
            // 
            // randomProbabilityCheckBox
            // 
            this.randomProbabilityCheckBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.randomProbabilityCheckBox, 2);
            this.randomProbabilityCheckBox.Location = new System.Drawing.Point(6, 210);
            this.randomProbabilityCheckBox.Name = "randomProbabilityCheckBox";
            this.randomProbabilityCheckBox.Size = new System.Drawing.Size(243, 17);
            this.randomProbabilityCheckBox.TabIndex = 13;
            this.randomProbabilityCheckBox.Text = "Случайная вероятность каждой генерации";
            this.randomProbabilityCheckBox.UseVisualStyleBackColor = true;
            this.randomProbabilityCheckBox.CheckedChanged += new System.EventHandler(this.randomProbabilityCheckBox_CheckedChanged);
            // 
            // selectAllCheckBox
            // 
            this.selectAllCheckBox.AutoSize = true;
            this.selectAllCheckBox.Location = new System.Drawing.Point(6, 6);
            this.selectAllCheckBox.Name = "selectAllCheckBox";
            this.selectAllCheckBox.Size = new System.Drawing.Size(91, 17);
            this.selectAllCheckBox.TabIndex = 0;
            this.selectAllCheckBox.Text = "Выбрать все";
            this.selectAllCheckBox.UseVisualStyleBackColor = true;
            this.selectAllCheckBox.CheckedChanged += new System.EventHandler(this.selectAllCheckBox_CheckedChanged);
            // 
            // stashesCheckBox
            // 
            this.stashesCheckBox.AutoSize = true;
            this.stashesCheckBox.Location = new System.Drawing.Point(6, 29);
            this.stashesCheckBox.Name = "stashesCheckBox";
            this.stashesCheckBox.Size = new System.Drawing.Size(69, 17);
            this.stashesCheckBox.TabIndex = 1;
            this.stashesCheckBox.Text = "Тайники";
            this.stashesCheckBox.UseVisualStyleBackColor = true;
            this.stashesCheckBox.CheckedChanged += new System.EventHandler(this.stashesCheckBox_CheckedChanged);
            // 
            // artefactsCheckBox
            // 
            this.artefactsCheckBox.AutoSize = true;
            this.artefactsCheckBox.Location = new System.Drawing.Point(235, 29);
            this.artefactsCheckBox.Name = "artefactsCheckBox";
            this.artefactsCheckBox.Size = new System.Drawing.Size(83, 17);
            this.artefactsCheckBox.TabIndex = 2;
            this.artefactsCheckBox.Text = "Артефакты";
            this.artefactsCheckBox.UseVisualStyleBackColor = true;
            this.artefactsCheckBox.CheckedChanged += new System.EventHandler(this.artefactsCheckBox_CheckedChanged);
            // 
            // weaponsCheckBox
            // 
            this.weaponsCheckBox.AutoSize = true;
            this.weaponsCheckBox.Location = new System.Drawing.Point(6, 52);
            this.weaponsCheckBox.Name = "weaponsCheckBox";
            this.weaponsCheckBox.Size = new System.Drawing.Size(65, 17);
            this.weaponsCheckBox.TabIndex = 3;
            this.weaponsCheckBox.Text = "Оружие";
            this.weaponsCheckBox.UseVisualStyleBackColor = true;
            this.weaponsCheckBox.CheckedChanged += new System.EventHandler(this.weaponsCheckBox_CheckedChanged);
            // 
            // armorCheckBox
            // 
            this.armorCheckBox.AutoSize = true;
            this.armorCheckBox.Location = new System.Drawing.Point(235, 52);
            this.armorCheckBox.Name = "armorCheckBox";
            this.armorCheckBox.Size = new System.Drawing.Size(57, 17);
            this.armorCheckBox.TabIndex = 4;
            this.armorCheckBox.Text = "Броня";
            this.armorCheckBox.UseVisualStyleBackColor = true;
            this.armorCheckBox.CheckedChanged += new System.EventHandler(this.armorCheckBox_CheckedChanged);
            // 
            // weatherCheckBox
            // 
            this.weatherCheckBox.AutoSize = true;
            this.weatherCheckBox.Location = new System.Drawing.Point(6, 75);
            this.weatherCheckBox.Name = "weatherCheckBox";
            this.weatherCheckBox.Size = new System.Drawing.Size(63, 17);
            this.weatherCheckBox.TabIndex = 5;
            this.weatherCheckBox.Text = "Погода";
            this.weatherCheckBox.UseVisualStyleBackColor = true;
            this.weatherCheckBox.CheckedChanged += new System.EventHandler(this.weatherCheckBox_CheckedChanged);
            // 
            // deathItemsCheckBox
            // 
            this.deathItemsCheckBox.AutoSize = true;
            this.deathItemsCheckBox.Location = new System.Drawing.Point(235, 75);
            this.deathItemsCheckBox.Name = "deathItemsCheckBox";
            this.deathItemsCheckBox.Size = new System.Drawing.Size(118, 17);
            this.deathItemsCheckBox.TabIndex = 6;
            this.deathItemsCheckBox.Text = "Вещи убитых НПС";
            this.deathItemsCheckBox.UseVisualStyleBackColor = true;
            this.deathItemsCheckBox.CheckedChanged += new System.EventHandler(this.deathItemsCheckBox_CheckedChanged);
            // 
            // traderItemsCheckBox
            // 
            this.traderItemsCheckBox.AutoSize = true;
            this.traderItemsCheckBox.Location = new System.Drawing.Point(6, 98);
            this.traderItemsCheckBox.Name = "traderItemsCheckBox";
            this.traderItemsCheckBox.Size = new System.Drawing.Size(148, 17);
            this.traderItemsCheckBox.TabIndex = 7;
            this.traderItemsCheckBox.Text = "Ассортимент торговцев";
            this.traderItemsCheckBox.UseVisualStyleBackColor = true;
            this.traderItemsCheckBox.CheckedChanged += new System.EventHandler(this.traderItemsCheckBox_CheckedChanged);
            // 
            // consumablesCheckBox
            // 
            this.consumablesCheckBox.AutoSize = true;
            this.consumablesCheckBox.Location = new System.Drawing.Point(235, 98);
            this.consumablesCheckBox.Name = "consumablesCheckBox";
            this.consumablesCheckBox.Size = new System.Drawing.Size(86, 17);
            this.consumablesCheckBox.TabIndex = 8;
            this.consumablesCheckBox.Text = "Расходники";
            this.consumablesCheckBox.UseVisualStyleBackColor = true;
            this.consumablesCheckBox.CheckedChanged += new System.EventHandler(this.consumablesCheckBox_CheckedChanged);
            // 
            // npcCheckBox
            // 
            this.npcCheckBox.AutoSize = true;
            this.npcCheckBox.Location = new System.Drawing.Point(6, 121);
            this.npcCheckBox.Name = "npcCheckBox";
            this.npcCheckBox.Size = new System.Drawing.Size(49, 17);
            this.npcCheckBox.TabIndex = 9;
            this.npcCheckBox.Text = "НПС";
            this.npcCheckBox.UseVisualStyleBackColor = true;
            this.npcCheckBox.CheckedChanged += new System.EventHandler(this.npcCheckBox_CheckedChanged);
            // 
            // additionalParamsCheckBox
            // 
            this.additionalParamsCheckBox.AutoSize = true;
            this.additionalParamsCheckBox.Location = new System.Drawing.Point(235, 121);
            this.additionalParamsCheckBox.Name = "additionalParamsCheckBox";
            this.additionalParamsCheckBox.Size = new System.Drawing.Size(174, 17);
            this.additionalParamsCheckBox.TabIndex = 10;
            this.additionalParamsCheckBox.Text = "Дополнительные параметры";
            this.additionalParamsCheckBox.UseVisualStyleBackColor = true;
            this.additionalParamsCheckBox.CheckedChanged += new System.EventHandler(this.additionalParamsCheckBox_CheckedChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.cancelButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.startButton, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 289);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(458, 29);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(263, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // startButton
            // 
            this.startButton.AutoSize = true;
            this.startButton.Location = new System.Drawing.Point(344, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(111, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Начать генерацию";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.saveInLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.outputPathTextBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.selectPathButton, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 230);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(458, 29);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // saveInLabel
            // 
            this.saveInLabel.AutoSize = true;
            this.saveInLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveInLabel.Location = new System.Drawing.Point(3, 0);
            this.saveInLabel.Name = "saveInLabel";
            this.saveInLabel.Size = new System.Drawing.Size(122, 29);
            this.saveInLabel.TabIndex = 0;
            this.saveInLabel.Text = "Сохранить gamedata в:";
            this.saveInLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // outputPathTextBox
            // 
            this.outputPathTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.outputPathTextBox.Location = new System.Drawing.Point(131, 3);
            this.outputPathTextBox.Name = "outputPathTextBox";
            this.outputPathTextBox.Size = new System.Drawing.Size(243, 20);
            this.outputPathTextBox.TabIndex = 1;
            this.outputPathTextBox.TextChanged += new System.EventHandler(this.outputPathTextBox_TextChanged);
            // 
            // selectPathButton
            // 
            this.selectPathButton.Location = new System.Drawing.Point(380, 3);
            this.selectPathButton.Name = "selectPathButton";
            this.selectPathButton.Size = new System.Drawing.Size(75, 23);
            this.selectPathButton.TabIndex = 2;
            this.selectPathButton.Text = "Выбрать";
            this.selectPathButton.UseVisualStyleBackColor = true;
            this.selectPathButton.Click += new System.EventHandler(this.selectPathButton_Click);
            // 
            // soundsCheckBox
            // 
            this.soundsCheckBox.AutoSize = true;
            this.soundsCheckBox.Location = new System.Drawing.Point(235, 144);
            this.soundsCheckBox.Name = "soundsCheckBox";
            this.soundsCheckBox.Size = new System.Drawing.Size(56, 17);
            this.soundsCheckBox.TabIndex = 15;
            this.soundsCheckBox.Text = "Звуки";
            this.soundsCheckBox.UseVisualStyleBackColor = true;
            this.soundsCheckBox.CheckedChanged += new System.EventHandler(this.soundsCheckBox_CheckedChanged);
            // 
            // GenerateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 321);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 360);
            this.Name = "GenerateDialog";
            this.Text = "GenerateDialog";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox selectAllCheckBox;
        private System.Windows.Forms.CheckBox stashesCheckBox;
        private System.Windows.Forms.CheckBox artefactsCheckBox;
        private System.Windows.Forms.CheckBox weaponsCheckBox;
        private System.Windows.Forms.CheckBox armorCheckBox;
        private System.Windows.Forms.CheckBox weatherCheckBox;
        private System.Windows.Forms.CheckBox deathItemsCheckBox;
        private System.Windows.Forms.CheckBox traderItemsCheckBox;
        private System.Windows.Forms.CheckBox consumablesCheckBox;
        private System.Windows.Forms.CheckBox npcCheckBox;
        private System.Windows.Forms.CheckBox additionalParamsCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label saveInLabel;
        private System.Windows.Forms.TextBox outputPathTextBox;
        private System.Windows.Forms.Button selectPathButton;
        private System.Windows.Forms.CheckBox randomProbabilityCheckBox;
        private System.Windows.Forms.CheckBox texturesCheckBox;
        private System.Windows.Forms.CheckBox soundsCheckBox;
        private System.Windows.Forms.CheckBox dialogsCheckBox;
    }
}