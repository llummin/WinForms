
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
            this.Creat = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRE
            // 
            this.buttonRE.Location = new System.Drawing.Point(3, 634);
            this.buttonRE.Name = "buttonRE";
            this.buttonRE.Size = new System.Drawing.Size(127, 23);
            this.buttonRE.TabIndex = 10;
            this.buttonRE.Text = "RemoveAll";
            this.buttonRE.UseVisualStyleBackColor = true;
            this.buttonRE.Click += new System.EventHandler(this.buttonRE_Click);
            // 
            // Creat
            // 
            this.Creat.Location = new System.Drawing.Point(1088, 41);
            this.Creat.Name = "Creat";
            this.Creat.Size = new System.Drawing.Size(121, 28);
            this.Creat.TabIndex = 32;
            this.Creat.Text = "Создать";
            this.Creat.UseVisualStyleBackColor = true;
            this.Creat.Click += new System.EventHandler(this.Creat_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 605);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(127, 23);
            this.button4.TabIndex = 37;
            this.button4.Text = "Стирание всех фигур";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 576);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(127, 23);
            this.button5.TabIndex = 38;
            this.button5.Text = "Показ всех";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Массив Пустой",
            "Массив Заполненый",
            "Список Пустой",
            "Список Заполненый"});
            this.comboBox1.Location = new System.Drawing.Point(1088, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 34;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 547);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 39;
            this.button1.Text = "Добавить фигуру";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1221, 669);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Creat);
            this.Controls.Add(this.buttonRE);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Создать";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonRE;
        private System.Windows.Forms.Button Creat;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
    }
}

