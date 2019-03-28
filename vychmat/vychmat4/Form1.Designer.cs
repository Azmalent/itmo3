namespace vychmat4
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
			this.plotView1 = new OxyPlot.WindowsForms.PlotView();
			this.funcButton1 = new System.Windows.Forms.RadioButton();
			this.funcButton2 = new System.Windows.Forms.RadioButton();
			this.funcButton3 = new System.Windows.Forms.RadioButton();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.precisionUpDown = new System.Windows.Forms.NumericUpDown();
			this.xnUpDown = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.yUpDown = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.xUpDown = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.precisionUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xnUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.yUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// plotView1
			// 
			this.plotView1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.plotView1.Location = new System.Drawing.Point(12, 116);
			this.plotView1.Name = "plotView1";
			this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
			this.plotView1.Size = new System.Drawing.Size(793, 437);
			this.plotView1.TabIndex = 0;
			this.plotView1.Text = "plotView1";
			this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
			this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
			this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
			// 
			// funcButton1
			// 
			this.funcButton1.AutoSize = true;
			this.funcButton1.Checked = true;
			this.funcButton1.Location = new System.Drawing.Point(6, 21);
			this.funcButton1.Name = "funcButton1";
			this.funcButton1.Size = new System.Drawing.Size(91, 21);
			this.funcButton1.TabIndex = 2;
			this.funcButton1.TabStop = true;
			this.funcButton1.Text = "y\' = x² - 2y";
			this.funcButton1.UseVisualStyleBackColor = true;
			// 
			// funcButton2
			// 
			this.funcButton2.AutoSize = true;
			this.funcButton2.Location = new System.Drawing.Point(6, 48);
			this.funcButton2.Name = "funcButton2";
			this.funcButton2.Size = new System.Drawing.Size(126, 21);
			this.funcButton2.TabIndex = 3;
			this.funcButton2.Text = "y\' = y * sin(x) / 6";
			this.funcButton2.UseVisualStyleBackColor = true;
			// 
			// funcButton3
			// 
			this.funcButton3.AutoSize = true;
			this.funcButton3.Location = new System.Drawing.Point(6, 75);
			this.funcButton3.Name = "funcButton3";
			this.funcButton3.Size = new System.Drawing.Size(108, 21);
			this.funcButton3.TabIndex = 4;
			this.funcButton3.Text = "y\' = y * e^(-x)";
			this.funcButton3.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(569, 42);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(194, 48);
			this.button1.TabIndex = 5;
			this.button1.Text = "Решение";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.funcButton1);
			this.groupBox1.Controls.Add(this.funcButton2);
			this.groupBox1.Controls.Add(this.funcButton3);
			this.groupBox1.Location = new System.Drawing.Point(13, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(194, 102);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Уравнение";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.precisionUpDown);
			this.groupBox2.Controls.Add(this.xnUpDown);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.yUpDown);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.xUpDown);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(223, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(283, 102);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Условия";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(176, 26);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 17);
			this.label4.TabIndex = 7;
			this.label4.Text = "Точность";
			// 
			// precisionUpDown
			// 
			this.precisionUpDown.DecimalPlaces = 2;
			this.precisionUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
			this.precisionUpDown.Location = new System.Drawing.Point(179, 47);
			this.precisionUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.precisionUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
			this.precisionUpDown.Name = "precisionUpDown";
			this.precisionUpDown.Size = new System.Drawing.Size(94, 22);
			this.precisionUpDown.TabIndex = 6;
			this.precisionUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			// 
			// xnUpDown
			// 
			this.xnUpDown.DecimalPlaces = 2;
			this.xnUpDown.Location = new System.Drawing.Point(48, 72);
			this.xnUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.xnUpDown.Name = "xnUpDown";
			this.xnUpDown.Size = new System.Drawing.Size(94, 22);
			this.xnUpDown.TabIndex = 5;
			this.xnUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.xnUpDown.ValueChanged += new System.EventHandler(this.xnValidation);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 74);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(26, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "xn:";
			// 
			// yUpDown
			// 
			this.yUpDown.DecimalPlaces = 2;
			this.yUpDown.Location = new System.Drawing.Point(48, 47);
			this.yUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.yUpDown.Name = "yUpDown";
			this.yUpDown.Size = new System.Drawing.Size(94, 22);
			this.yUpDown.TabIndex = 3;
			this.yUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(27, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "y0:";
			// 
			// xUpDown
			// 
			this.xUpDown.DecimalPlaces = 2;
			this.xUpDown.Location = new System.Drawing.Point(48, 21);
			this.xUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.xUpDown.Name = "xUpDown";
			this.xUpDown.Size = new System.Drawing.Size(94, 22);
			this.xUpDown.TabIndex = 1;
			this.xUpDown.ValueChanged += new System.EventHandler(this.xnValidation);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "x0:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(818, 564);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.plotView1);
			this.Name = "Form1";
			this.Text = "Решение ОДУ усовершенствованным методом Эйлера";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.precisionUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xnUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.yUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private OxyPlot.WindowsForms.PlotView plotView1;
		private System.Windows.Forms.RadioButton funcButton1;
		private System.Windows.Forms.RadioButton funcButton2;
		private System.Windows.Forms.RadioButton funcButton3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NumericUpDown xnUpDown;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown yUpDown;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown xUpDown;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown precisionUpDown;
		private System.Windows.Forms.Label label4;
	}
}

