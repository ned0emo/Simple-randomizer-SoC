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
            this.label6 = new System.Windows.Forms.Label();
            this.ammoProbabilityInput = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.weaponProbabilityInput = new System.Windows.Forms.NumericUpDown();
            this.editAmmoParametersButton = new System.Windows.Forms.Button();
            this.editAmmoSectionsButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.editWeaponParametersButton = new System.Windows.Forms.Button();
            this.editWeaponSectionsButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ammoProbabilityInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponProbabilityInput)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.ammoProbabilityInput);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.weaponProbabilityInput);
            this.panel2.Controls.Add(this.editAmmoParametersButton);
            this.panel2.Controls.Add(this.editAmmoSectionsButton);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.editWeaponParametersButton);
            this.panel2.Controls.Add(this.editWeaponSectionsButton);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(499, 292);
            this.panel2.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(282, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "Вероятность генерации каждого параметра патронов";
            // 
            // ammoProbabilityInput
            // 
            this.ammoProbabilityInput.Location = new System.Drawing.Point(6, 133);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Вероятность генерации каждого параметра оружия";
            // 
            // weaponProbabilityInput
            // 
            this.weaponProbabilityInput.Location = new System.Drawing.Point(6, 107);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 16);
            this.label4.TabIndex = 41;
            this.label4.Text = "Генерируемые параметры патронов";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(303, 16);
            this.label5.TabIndex = 40;
            this.label5.Text = "Секции для генерации параметров патронов";
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
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(3, 29);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(231, 16);
            this.label19.TabIndex = 30;
            this.label19.Text = "Генерируемые параметры оружия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Секции для генерации параметров оружия";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 26);
            this.panel1.TabIndex = 4;
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
            this.label1.Size = new System.Drawing.Size(423, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Настройка генерации параметров оружия и патронов";
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
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button editWeaponParametersButton;
        private System.Windows.Forms.Button editAmmoParametersButton;
        private System.Windows.Forms.Button editAmmoSectionsButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown weaponProbabilityInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown ammoProbabilityInput;
    }
}
