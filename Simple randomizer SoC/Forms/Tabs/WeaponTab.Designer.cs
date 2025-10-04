namespace Simple_randomizer_SoC.Forms.Tabs
{
    partial class WeaponTab
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.ammoProbabilityLabel = new System.Windows.Forms.Label();
            this.ammoProbabilityInput = new System.Windows.Forms.NumericUpDown();
            this.weaponsProbabilityLabel = new System.Windows.Forms.Label();
            this.weaponProbabilityInput = new System.Windows.Forms.NumericUpDown();
            this.editAmmoParametersButton = new System.Windows.Forms.Button();
            this.editAmmoSectionsButton = new System.Windows.Forms.Button();
            this.ammoParamsLabel = new System.Windows.Forms.Label();
            this.ammoSectionsLabel = new System.Windows.Forms.Label();
            this.editWeaponParametersButton = new System.Windows.Forms.Button();
            this.editWeaponSectionsButton = new System.Windows.Forms.Button();
            this.weaponsParamsLabel = new System.Windows.Forms.Label();
            this.weaponsSectionLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ammoProbabilityInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponProbabilityInput)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.ammoProbabilityLabel);
            this.panel2.Controls.Add(this.ammoProbabilityInput);
            this.panel2.Controls.Add(this.weaponsProbabilityLabel);
            this.panel2.Controls.Add(this.weaponProbabilityInput);
            this.panel2.Controls.Add(this.editAmmoParametersButton);
            this.panel2.Controls.Add(this.editAmmoSectionsButton);
            this.panel2.Controls.Add(this.ammoParamsLabel);
            this.panel2.Controls.Add(this.ammoSectionsLabel);
            this.panel2.Controls.Add(this.editWeaponParametersButton);
            this.panel2.Controls.Add(this.editWeaponSectionsButton);
            this.panel2.Controls.Add(this.weaponsParamsLabel);
            this.panel2.Controls.Add(this.weaponsSectionLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(499, 292);
            this.panel2.TabIndex = 5;
            // 
            // ammoProbabilityLabel
            // 
            this.ammoProbabilityLabel.AutoSize = true;
            this.ammoProbabilityLabel.Location = new System.Drawing.Point(65, 137);
            this.ammoProbabilityLabel.Name = "ammoProbabilityLabel";
            this.ammoProbabilityLabel.Size = new System.Drawing.Size(282, 13);
            this.ammoProbabilityLabel.TabIndex = 47;
            this.ammoProbabilityLabel.Text = "Вероятность генерации каждого параметра патронов";
            // 
            // ammoProbabilityInput
            // 
            this.ammoProbabilityInput.Location = new System.Drawing.Point(6, 135);
            this.ammoProbabilityInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ammoProbabilityInput.Name = "ammoProbabilityInput";
            this.ammoProbabilityInput.Size = new System.Drawing.Size(53, 20);
            this.ammoProbabilityInput.TabIndex = 46;
            this.ammoProbabilityInput.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ammoProbabilityInput.ValueChanged += new System.EventHandler(this.ammoProbabilityInput_ValueChanged);
            // 
            // weaponsProbabilityLabel
            // 
            this.weaponsProbabilityLabel.AutoSize = true;
            this.weaponsProbabilityLabel.Location = new System.Drawing.Point(65, 111);
            this.weaponsProbabilityLabel.Name = "weaponsProbabilityLabel";
            this.weaponsProbabilityLabel.Size = new System.Drawing.Size(272, 13);
            this.weaponsProbabilityLabel.TabIndex = 45;
            this.weaponsProbabilityLabel.Text = "Вероятность генерации каждого параметра оружия";
            // 
            // weaponProbabilityInput
            // 
            this.weaponProbabilityInput.Location = new System.Drawing.Point(6, 109);
            this.weaponProbabilityInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.weaponProbabilityInput.Name = "weaponProbabilityInput";
            this.weaponProbabilityInput.Size = new System.Drawing.Size(53, 20);
            this.weaponProbabilityInput.TabIndex = 44;
            this.weaponProbabilityInput.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.weaponProbabilityInput.ValueChanged += new System.EventHandler(this.probabilityInput_ValueChanged);
            // 
            // editAmmoParametersButton
            // 
            this.editAmmoParametersButton.Location = new System.Drawing.Point(320, 78);
            this.editAmmoParametersButton.Name = "editAmmoParametersButton";
            this.editAmmoParametersButton.Size = new System.Drawing.Size(154, 23);
            this.editAmmoParametersButton.TabIndex = 43;
            this.editAmmoParametersButton.Text = "Редактировать список";
            this.editAmmoParametersButton.UseVisualStyleBackColor = true;
            this.editAmmoParametersButton.Click += new System.EventHandler(this.editAmmoParametersButton_Click);
            // 
            // editAmmoSectionsButton
            // 
            this.editAmmoSectionsButton.Location = new System.Drawing.Point(320, 52);
            this.editAmmoSectionsButton.Name = "editAmmoSectionsButton";
            this.editAmmoSectionsButton.Size = new System.Drawing.Size(154, 23);
            this.editAmmoSectionsButton.TabIndex = 42;
            this.editAmmoSectionsButton.Text = "Редактировать список";
            this.editAmmoSectionsButton.UseVisualStyleBackColor = true;
            this.editAmmoSectionsButton.Click += new System.EventHandler(this.editAmmoSectionsButton_Click);
            // 
            // ammoParamsLabel
            // 
            this.ammoParamsLabel.AutoSize = true;
            this.ammoParamsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ammoParamsLabel.Location = new System.Drawing.Point(3, 81);
            this.ammoParamsLabel.Name = "ammoParamsLabel";
            this.ammoParamsLabel.Size = new System.Drawing.Size(246, 16);
            this.ammoParamsLabel.TabIndex = 41;
            this.ammoParamsLabel.Text = "Генерируемые параметры патронов";
            // 
            // ammoSectionsLabel
            // 
            this.ammoSectionsLabel.AutoSize = true;
            this.ammoSectionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ammoSectionsLabel.Location = new System.Drawing.Point(3, 55);
            this.ammoSectionsLabel.Name = "ammoSectionsLabel";
            this.ammoSectionsLabel.Size = new System.Drawing.Size(303, 16);
            this.ammoSectionsLabel.TabIndex = 40;
            this.ammoSectionsLabel.Text = "Секции для генерации параметров патронов";
            // 
            // editWeaponParametersButton
            // 
            this.editWeaponParametersButton.Location = new System.Drawing.Point(320, 26);
            this.editWeaponParametersButton.Name = "editWeaponParametersButton";
            this.editWeaponParametersButton.Size = new System.Drawing.Size(154, 23);
            this.editWeaponParametersButton.TabIndex = 39;
            this.editWeaponParametersButton.Text = "Редактировать список";
            this.editWeaponParametersButton.UseVisualStyleBackColor = true;
            this.editWeaponParametersButton.Click += new System.EventHandler(this.editWeaponParametersButton_Click);
            // 
            // editWeaponSectionsButton
            // 
            this.editWeaponSectionsButton.Location = new System.Drawing.Point(320, 0);
            this.editWeaponSectionsButton.Name = "editWeaponSectionsButton";
            this.editWeaponSectionsButton.Size = new System.Drawing.Size(154, 23);
            this.editWeaponSectionsButton.TabIndex = 31;
            this.editWeaponSectionsButton.Text = "Редактировать список";
            this.editWeaponSectionsButton.UseVisualStyleBackColor = true;
            this.editWeaponSectionsButton.Click += new System.EventHandler(this.editWeaponSectionsButton_Click);
            // 
            // weaponsParamsLabel
            // 
            this.weaponsParamsLabel.AutoSize = true;
            this.weaponsParamsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.weaponsParamsLabel.Location = new System.Drawing.Point(3, 29);
            this.weaponsParamsLabel.Name = "weaponsParamsLabel";
            this.weaponsParamsLabel.Size = new System.Drawing.Size(231, 16);
            this.weaponsParamsLabel.TabIndex = 30;
            this.weaponsParamsLabel.Text = "Генерируемые параметры оружия";
            // 
            // weaponsSectionLabel
            // 
            this.weaponsSectionLabel.AutoSize = true;
            this.weaponsSectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.weaponsSectionLabel.Location = new System.Drawing.Point(3, 3);
            this.weaponsSectionLabel.Name = "weaponsSectionLabel";
            this.weaponsSectionLabel.Size = new System.Drawing.Size(288, 16);
            this.weaponsSectionLabel.TabIndex = 0;
            this.weaponsSectionLabel.Text = "Секции для генерации параметров оружия";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.titleLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 26);
            this.panel1.TabIndex = 4;
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
            this.titleLabel.Size = new System.Drawing.Size(423, 26);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Настройка генерации параметров оружия и патронов";
            // 
            // WeaponTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "WeaponTab";
            this.Size = new System.Drawing.Size(499, 318);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ammoProbabilityInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponProbabilityInput)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button editWeaponSectionsButton;
        private System.Windows.Forms.Label weaponsParamsLabel;
        private System.Windows.Forms.Label weaponsSectionLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button editWeaponParametersButton;
        private System.Windows.Forms.Button editAmmoParametersButton;
        private System.Windows.Forms.Button editAmmoSectionsButton;
        private System.Windows.Forms.Label ammoParamsLabel;
        private System.Windows.Forms.Label ammoSectionsLabel;
        private System.Windows.Forms.Label weaponsProbabilityLabel;
        private System.Windows.Forms.NumericUpDown weaponProbabilityInput;
        private System.Windows.Forms.Label ammoProbabilityLabel;
        private System.Windows.Forms.NumericUpDown ammoProbabilityInput;
    }
}
