namespace RectangleMethod
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.startButton = new System.Windows.Forms.Button();
            this.funcButton1 = new System.Windows.Forms.RadioButton();
            this.funcButton2 = new System.Windows.Forms.RadioButton();
            this.funcButton3 = new System.Windows.Forms.RadioButton();
            this.funcButton4 = new System.Windows.Forms.RadioButton();
            this.formulaButton1 = new System.Windows.Forms.RadioButton();
            this.formulaButton2 = new System.Windows.Forms.RadioButton();
            this.formulaButton3 = new System.Windows.Forms.RadioButton();
            this.aUpDown = new System.Windows.Forms.NumericUpDown();
            this.bUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.precisionUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.aUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.precisionUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(133, 292);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(183, 66);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Вычислить";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_click);
            // 
            // funcButton1
            // 
            this.funcButton1.AutoSize = true;
            this.funcButton1.Checked = true;
            this.funcButton1.Location = new System.Drawing.Point(6, 21);
            this.funcButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.funcButton1.Name = "funcButton1";
            this.funcButton1.Size = new System.Drawing.Size(68, 25);
            this.funcButton1.TabIndex = 1;
            this.funcButton1.TabStop = true;
            this.funcButton1.Text = "y = x²";
            this.funcButton1.UseVisualStyleBackColor = true;
            // 
            // funcButton2
            // 
            this.funcButton2.AutoSize = true;
            this.funcButton2.Location = new System.Drawing.Point(6, 54);
            this.funcButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.funcButton2.Name = "funcButton2";
            this.funcButton2.Size = new System.Drawing.Size(70, 25);
            this.funcButton2.TabIndex = 2;
            this.funcButton2.Text = "y = √x";
            this.funcButton2.UseVisualStyleBackColor = true;
            // 
            // funcButton3
            // 
            this.funcButton3.AutoSize = true;
            this.funcButton3.Location = new System.Drawing.Point(6, 90);
            this.funcButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.funcButton3.Name = "funcButton3";
            this.funcButton3.Size = new System.Drawing.Size(85, 25);
            this.funcButton3.TabIndex = 3;
            this.funcButton3.Text = "y = ln(x)";
            this.funcButton3.UseVisualStyleBackColor = true;
            // 
            // funcButton4
            // 
            this.funcButton4.AutoSize = true;
            this.funcButton4.Location = new System.Drawing.Point(6, 125);
            this.funcButton4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.funcButton4.Name = "funcButton4";
            this.funcButton4.Size = new System.Drawing.Size(92, 25);
            this.funcButton4.TabIndex = 4;
            this.funcButton4.Text = "y = sin(x)";
            this.funcButton4.UseVisualStyleBackColor = true;
            // 
            // formulaButton1
            // 
            this.formulaButton1.AutoSize = true;
            this.formulaButton1.Location = new System.Drawing.Point(10, 150);
            this.formulaButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.formulaButton1.Name = "formulaButton1";
            this.formulaButton1.Size = new System.Drawing.Size(73, 25);
            this.formulaButton1.TabIndex = 5;
            this.formulaButton1.Text = "Левая";
            this.formulaButton1.UseVisualStyleBackColor = true;
            // 
            // formulaButton2
            // 
            this.formulaButton2.AutoSize = true;
            this.formulaButton2.Checked = true;
            this.formulaButton2.Location = new System.Drawing.Point(10, 183);
            this.formulaButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.formulaButton2.Name = "formulaButton2";
            this.formulaButton2.Size = new System.Drawing.Size(91, 25);
            this.formulaButton2.TabIndex = 6;
            this.formulaButton2.TabStop = true;
            this.formulaButton2.Text = "Средняя";
            this.toolTip1.SetToolTip(this.formulaButton2, "Наиболее быстрая, точная и отказоустойчивая формула.\r\nРекомандуется к использован" +
        "ию.\r\n");
            this.formulaButton2.UseVisualStyleBackColor = true;
            // 
            // formulaButton3
            // 
            this.formulaButton3.AutoSize = true;
            this.formulaButton3.Location = new System.Drawing.Point(10, 216);
            this.formulaButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.formulaButton3.Name = "formulaButton3";
            this.formulaButton3.Size = new System.Drawing.Size(83, 25);
            this.formulaButton3.TabIndex = 7;
            this.formulaButton3.Text = "Правая";
            this.formulaButton3.UseVisualStyleBackColor = true;
            // 
            // aUpDown
            // 
            this.aUpDown.DecimalPlaces = 3;
            this.aUpDown.Location = new System.Drawing.Point(53, 27);
            this.aUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.aUpDown.Name = "aUpDown";
            this.aUpDown.Size = new System.Drawing.Size(141, 28);
            this.aUpDown.TabIndex = 8;
            // 
            // bUpDown
            // 
            this.bUpDown.DecimalPlaces = 3;
            this.bUpDown.Location = new System.Drawing.Point(53, 61);
            this.bUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.bUpDown.Name = "bUpDown";
            this.bUpDown.Size = new System.Drawing.Size(141, 28);
            this.bUpDown.TabIndex = 9;
            this.bUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "От";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "До";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.funcButton4);
            this.groupBox1.Controls.Add(this.funcButton1);
            this.groupBox1.Controls.Add(this.funcButton2);
            this.groupBox1.Controls.Add(this.funcButton3);
            this.groupBox1.Location = new System.Drawing.Point(16, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 158);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Функция";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.aUpDown);
            this.groupBox2.Controls.Add(this.bUpDown);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(16, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Область";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.precisionUpDown);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.formulaButton1);
            this.groupBox3.Controls.Add(this.formulaButton2);
            this.groupBox3.Controls.Add(this.formulaButton3);
            this.groupBox3.Location = new System.Drawing.Point(234, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 268);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Параметры";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 21);
            this.label4.TabIndex = 17;
            this.label4.Text = "Точность до разряда";
            // 
            // precisionUpDown
            // 
            this.precisionUpDown.Location = new System.Drawing.Point(10, 68);
            this.precisionUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.precisionUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.precisionUpDown.Name = "precisionUpDown";
            this.precisionUpDown.Size = new System.Drawing.Size(99, 28);
            this.precisionUpDown.TabIndex = 12;
            this.precisionUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 21);
            this.label3.TabIndex = 16;
            this.label3.Text = "Формула";
            // 
            // outputBox
            // 
            this.outputBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.outputBox.Location = new System.Drawing.Point(13, 373);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(421, 84);
            this.outputBox.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 469);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.startButton);
            this.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Метод прямоугольников";
            ((System.ComponentModel.ISupportInitialize)(this.aUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.precisionUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.RadioButton funcButton1;
        private System.Windows.Forms.RadioButton funcButton2;
        private System.Windows.Forms.RadioButton funcButton3;
        private System.Windows.Forms.RadioButton funcButton4;
        private System.Windows.Forms.RadioButton formulaButton1;
        private System.Windows.Forms.RadioButton formulaButton2;
        private System.Windows.Forms.RadioButton formulaButton3;
        private System.Windows.Forms.NumericUpDown aUpDown;
        private System.Windows.Forms.NumericUpDown bUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown precisionUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

