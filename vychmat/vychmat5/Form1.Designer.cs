namespace vychmat5
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
			this.ybUpDown = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.yaUpDown = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.bUpDown = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.aUpDown = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.precisionUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ybUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.yaUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.aUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.precisionUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// plotView1
			// 
			this.plotView1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.plotView1.Location = new System.Drawing.Point(19, 116);
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
			this.funcButton1.Size = new System.Drawing.Size(129, 21);
			this.funcButton1.TabIndex = 2;
			this.funcButton1.TabStop = true;
			this.funcButton1.Text = "y\'\' = 2y + 8x(9-x)";
			this.funcButton1.UseVisualStyleBackColor = true;
			// 
			// funcButton2
			// 
			this.funcButton2.AutoSize = true;
			this.funcButton2.Location = new System.Drawing.Point(6, 48);
			this.funcButton2.Name = "funcButton2";
			this.funcButton2.Size = new System.Drawing.Size(92, 21);
			this.funcButton2.TabIndex = 3;
			this.funcButton2.Text = "y\'\' = 2x + y";
			this.funcButton2.UseVisualStyleBackColor = true;
			// 
			// funcButton3
			// 
			this.funcButton3.AutoSize = true;
			this.funcButton3.Location = new System.Drawing.Point(6, 75);
			this.funcButton3.Name = "funcButton3";
			this.funcButton3.Size = new System.Drawing.Size(95, 21);
			this.funcButton3.TabIndex = 4;
			this.funcButton3.Text = "y\'\' = y\' + 3x";
			this.funcButton3.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(650, 38);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(162, 39);
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
			this.groupBox1.Size = new System.Drawing.Size(158, 102);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Задача";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ybUpDown);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.yaUpDown);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.bUpDown);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.aUpDown);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(177, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(333, 102);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Граничные условия";
			// 
			// ybUpDown
			// 
			this.ybUpDown.DecimalPlaces = 2;
			this.ybUpDown.Location = new System.Drawing.Point(216, 58);
			this.ybUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.ybUpDown.Name = "ybUpDown";
			this.ybUpDown.Size = new System.Drawing.Size(94, 22);
			this.ybUpDown.TabIndex = 7;
			this.ybUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(175, 60);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(37, 17);
			this.label7.TabIndex = 6;
			this.label7.Text = "y(b):";
			// 
			// yaUpDown
			// 
			this.yaUpDown.DecimalPlaces = 2;
			this.yaUpDown.Location = new System.Drawing.Point(216, 19);
			this.yaUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.yaUpDown.Name = "yaUpDown";
			this.yaUpDown.Size = new System.Drawing.Size(94, 22);
			this.yaUpDown.TabIndex = 5;
			this.yaUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.yaUpDown.ValueChanged += new System.EventHandler(this.leftBoundaryChange);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(174, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "y(a):";
			// 
			// bUpDown
			// 
			this.bUpDown.DecimalPlaces = 2;
			this.bUpDown.Location = new System.Drawing.Point(48, 61);
			this.bUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.bUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.bUpDown.Name = "bUpDown";
			this.bUpDown.Size = new System.Drawing.Size(94, 22);
			this.bUpDown.TabIndex = 3;
			this.bUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(20, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "b:";
			// 
			// aUpDown
			// 
			this.aUpDown.DecimalPlaces = 2;
			this.aUpDown.Location = new System.Drawing.Point(48, 21);
			this.aUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.aUpDown.Name = "aUpDown";
			this.aUpDown.Size = new System.Drawing.Size(94, 22);
			this.aUpDown.TabIndex = 1;
			this.aUpDown.ValueChanged += new System.EventHandler(this.leftBoundaryChange);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(20, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "a:";
			// 
			// precisionUpDown1
			// 
			this.precisionUpDown1.DecimalPlaces = 2;
			this.precisionUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
			this.precisionUpDown1.Location = new System.Drawing.Point(529, 55);
			this.precisionUpDown1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.precisionUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
			this.precisionUpDown1.Name = "precisionUpDown1";
			this.precisionUpDown1.Size = new System.Drawing.Size(94, 22);
			this.precisionUpDown1.TabIndex = 8;
			this.precisionUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(526, 34);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 17);
			this.label4.TabIndex = 8;
			this.label4.Text = "Точность";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(818, 566);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.precisionUpDown1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.plotView1);
			this.Name = "Form1";
			this.Text = "Метод пристрелки";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ybUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.yaUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.aUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.precisionUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private OxyPlot.WindowsForms.PlotView plotView1;
		private System.Windows.Forms.RadioButton funcButton1;
		private System.Windows.Forms.RadioButton funcButton2;
		private System.Windows.Forms.RadioButton funcButton3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NumericUpDown yaUpDown;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown bUpDown;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown aUpDown;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown ybUpDown;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown precisionUpDown1;
		private System.Windows.Forms.Label label4;
	}
}

