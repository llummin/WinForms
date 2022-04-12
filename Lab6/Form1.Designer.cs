
namespace test_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonRE = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.Swap = new System.Windows.Forms.Button();
            this.Creat = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRE
            // 
            this.buttonRE.Location = new System.Drawing.Point(0, 392);
            this.buttonRE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonRE.Name = "buttonRE";
            this.buttonRE.Size = new System.Drawing.Size(292, 31);
            this.buttonRE.TabIndex = 10;
            this.buttonRE.Text = "RemoveAll";
            this.buttonRE.UseVisualStyleBackColor = true;
            this.buttonRE.Click += new System.EventHandler(this.buttonRE_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(80, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 20);
            this.label9.TabIndex = 30;
            this.label9.Text = "Переворот овала";
            // 
            // Swap
            // 
            this.Swap.Location = new System.Drawing.Point(0, 227);
            this.Swap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Swap.Name = "Swap";
            this.Swap.Size = new System.Drawing.Size(292, 31);
            this.Swap.TabIndex = 31;
            this.Swap.Text = "Поворот";
            this.Swap.UseVisualStyleBackColor = true;
            this.Swap.Click += new System.EventHandler(this.Swap_Click);
            // 
            // Creat
            // 
            this.Creat.Dock = System.Windows.Forms.DockStyle.Top;
            this.Creat.Location = new System.Drawing.Point(0, 0);
            this.Creat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Creat.Name = "Creat";
            this.Creat.Size = new System.Drawing.Size(292, 37);
            this.Creat.TabIndex = 32;
            this.Creat.Text = "Start";
            this.Creat.UseVisualStyleBackColor = true;
            this.Creat.Click += new System.EventHandler(this.Creat_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 81);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(292, 31);
            this.button1.TabIndex = 33;
            this.button1.Text = "Стирание фигур";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Круг",
            "Квадрат",
            "Линия",
            "Ромб",
            "Прямоугольник",
            "Овал"});
            this.comboBox1.Location = new System.Drawing.Point(0, 45);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(292, 28);
            this.comboBox1.TabIndex = 34;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 120);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(292, 31);
            this.button2.TabIndex = 35;
            this.button2.Text = "Показ фигур";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 159);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(292, 31);
            this.button3.TabIndex = 36;
            this.button3.Text = "Базовая точка";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 314);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(292, 31);
            this.button4.TabIndex = 37;
            this.button4.Text = "Стирание всех фигур";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(0, 353);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(292, 31);
            this.button5.TabIndex = 38;
            this.button5.Text = "Показ всех";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(0, 275);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(292, 31);
            this.button6.TabIndex = 39;
            this.button6.Text = "Перемещение всех";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.Creat);
            this.panel1.Controls.Add(this.buttonRE);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.Swap);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1103, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 892);
            this.panel1.TabIndex = 43;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1395, 892);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonRE;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Swap;
        private System.Windows.Forms.Button Creat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel1;
    }
}

