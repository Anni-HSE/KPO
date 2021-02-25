namespace LabControls
{
    partial class ColorPicker
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.decRadioButton = new System.Windows.Forms.RadioButton();
            this.hexRadioButton = new System.Windows.Forms.RadioButton();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.blueColorTextBox = new LabControls.ColorTextBox(this.components);
            this.greenColorTextBox = new LabControls.ColorTextBox(this.components);
            this.redColorTextBox = new LabControls.ColorTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Красный";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Зеленый";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Синий";
            // 
            // decRadioButton
            // 
            this.decRadioButton.AutoSize = true;
            this.decRadioButton.Checked = true;
            this.decRadioButton.Enabled = false;
            this.decRadioButton.Location = new System.Drawing.Point(3, 81);
            this.decRadioButton.Name = "decRadioButton";
            this.decRadioButton.Size = new System.Drawing.Size(45, 17);
            this.decRadioButton.TabIndex = 6;
            this.decRadioButton.TabStop = true;
            this.decRadioButton.Text = "Dec";
            this.decRadioButton.UseVisualStyleBackColor = true;
            this.decRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // hexRadioButton
            // 
            this.hexRadioButton.AutoSize = true;
            this.hexRadioButton.Location = new System.Drawing.Point(54, 81);
            this.hexRadioButton.Name = "hexRadioButton";
            this.hexRadioButton.Size = new System.Drawing.Size(44, 17);
            this.hexRadioButton.TabIndex = 7;
            this.hexRadioButton.TabStop = true;
            this.hexRadioButton.Text = "Hex";
            this.hexRadioButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Black;
            this.pictureBox.Location = new System.Drawing.Point(117, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(100, 100);
            this.pictureBox.TabIndex = 8;
            this.pictureBox.TabStop = false;
            // 
            // blueColorTextBox
            // 
            this.blueColorTextBox.Location = new System.Drawing.Point(61, 55);
            this.blueColorTextBox.Name = "blueColorTextBox";
            this.blueColorTextBox.Size = new System.Drawing.Size(50, 20);
            this.blueColorTextBox.TabIndex = 11;
            this.blueColorTextBox.Text = "0";
            this.blueColorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.blueColorTextBox.TextChanged += new System.EventHandler(this.сolorTextBox_TextChanged);
            // 
            // greenColorTextBox
            // 
            this.greenColorTextBox.Location = new System.Drawing.Point(61, 29);
            this.greenColorTextBox.Name = "greenColorTextBox";
            this.greenColorTextBox.Size = new System.Drawing.Size(50, 20);
            this.greenColorTextBox.TabIndex = 10;
            this.greenColorTextBox.Text = "0";
            this.greenColorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.greenColorTextBox.TextChanged += new System.EventHandler(this.сolorTextBox_TextChanged);
            // 
            // redColorTextBox
            // 
            this.redColorTextBox.Location = new System.Drawing.Point(61, 3);
            this.redColorTextBox.Name = "redColorTextBox";
            this.redColorTextBox.Size = new System.Drawing.Size(50, 20);
            this.redColorTextBox.TabIndex = 9;
            this.redColorTextBox.Text = "0";
            this.redColorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.redColorTextBox.TextChanged += new System.EventHandler(this.сolorTextBox_TextChanged);
            // 
            // ColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.blueColorTextBox);
            this.Controls.Add(this.greenColorTextBox);
            this.Controls.Add(this.redColorTextBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.hexRadioButton);
            this.Controls.Add(this.decRadioButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ColorPicker";
            this.Size = new System.Drawing.Size(221, 108);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton decRadioButton;
        private System.Windows.Forms.RadioButton hexRadioButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private ColorTextBox redColorTextBox;
        private ColorTextBox greenColorTextBox;
        private ColorTextBox blueColorTextBox;
    }
}
