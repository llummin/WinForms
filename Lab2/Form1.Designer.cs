
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
            this.size1 = new System.Windows.Forms.Button();
            this.size2 = new System.Windows.Forms.Button();
            this.size3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SizeR = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRemSolo = new System.Windows.Forms.Button();
            this.buttonRE = new System.Windows.Forms.Button();
            this.buttonRS = new System.Windows.Forms.Button();
            this.buttonRL = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // size1
            // 
            this.size1.Location = new System.Drawing.Point(954, 88);
            this.size1.Name = "size1";
            this.size1.Size = new System.Drawing.Size(82, 23);
            this.size1.TabIndex = 0;
            this.size1.Text = "CreateEllipse";
            this.size1.UseVisualStyleBackColor = true;
            this.size1.Click += new System.EventHandler(this.size1_Click);
            // 
            // size2
            // 
            this.size2.Location = new System.Drawing.Point(954, 178);
            this.size2.Name = "size2";
            this.size2.Size = new System.Drawing.Size(82, 23);
            this.size2.TabIndex = 1;
            this.size2.Text = "CreateSquar";
            this.size2.UseVisualStyleBackColor = true;
            this.size2.Click += new System.EventHandler(this.size2_Click);
            // 
            // size3
            // 
            this.size3.Location = new System.Drawing.Point(954, 286);
            this.size3.Name = "size3";
            this.size3.Size = new System.Drawing.Size(82, 23);
            this.size3.TabIndex = 2;
            this.size3.Text = "CreateLine";
            this.size3.UseVisualStyleBackColor = true;
            this.size3.Click += new System.EventHandler(this.size3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(954, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(82, 23);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "sizeEllips";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(954, 149);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(82, 23);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "sizeSquar";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(954, 257);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(82, 23);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "sizeLine";
            // 
            // SizeR
            // 
            this.SizeR.Location = new System.Drawing.Point(961, 537);
            this.SizeR.Name = "SizeR";
            this.SizeR.Size = new System.Drawing.Size(75, 23);
            this.SizeR.TabIndex = 6;
            this.SizeR.Text = "plusSize";
            this.SizeR.UseVisualStyleBackColor = true;
            this.SizeR.Click += new System.EventHandler(this.SizeR_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(961, 508);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(75, 23);
            this.textBox4.TabIndex = 7;
            this.textBox4.Text = "Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(954, 481);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "увеличение R";
            // 
            // buttonRemSolo
            // 
            this.buttonRemSolo.Location = new System.Drawing.Point(839, 537);
            this.buttonRemSolo.Name = "buttonRemSolo";
            this.buttonRemSolo.Size = new System.Drawing.Size(75, 23);
            this.buttonRemSolo.TabIndex = 9;
            this.buttonRemSolo.Text = "Remove";
            this.buttonRemSolo.UseVisualStyleBackColor = true;
            this.buttonRemSolo.Click += new System.EventHandler(this.buttonRemSolo_Click);
            // 
            // buttonRE
            // 
            this.buttonRE.Location = new System.Drawing.Point(452, 538);
            this.buttonRE.Name = "buttonRE";
            this.buttonRE.Size = new System.Drawing.Size(75, 23);
            this.buttonRE.TabIndex = 10;
            this.buttonRE.Text = "RemoveEllipse";
            this.buttonRE.UseVisualStyleBackColor = true;
            this.buttonRE.Click += new System.EventHandler(this.buttonRE_Click);
            // 
            // buttonRS
            // 
            this.buttonRS.Location = new System.Drawing.Point(533, 537);
            this.buttonRS.Name = "buttonRS";
            this.buttonRS.Size = new System.Drawing.Size(75, 23);
            this.buttonRS.TabIndex = 11;
            this.buttonRS.Text = "RemoveSq";
            this.buttonRS.UseVisualStyleBackColor = true;
            this.buttonRS.Click += new System.EventHandler(this.buttonRS_Click);
            // 
            // buttonRL
            // 
            this.buttonRL.Location = new System.Drawing.Point(614, 537);
            this.buttonRL.Name = "buttonRL";
            this.buttonRL.Size = new System.Drawing.Size(75, 23);
            this.buttonRL.TabIndex = 12;
            this.buttonRL.Text = "RemoveLine";
            this.buttonRL.UseVisualStyleBackColor = true;
            this.buttonRL.Click += new System.EventHandler(this.buttonRL_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(961, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Size Ellipse";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(961, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Size Squar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(961, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Size Line";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(839, 59);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 23);
            this.textBox5.TabIndex = 16;
            this.textBox5.Text = "x";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(839, 88);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 23);
            this.textBox6.TabIndex = 17;
            this.textBox6.Text = "y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(848, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Cord\'s Create ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 573);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRL);
            this.Controls.Add(this.buttonRS);
            this.Controls.Add(this.buttonRE);
            this.Controls.Add(this.buttonRemSolo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.SizeR);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.size3);
            this.Controls.Add(this.size2);
            this.Controls.Add(this.size1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button size1;
        private System.Windows.Forms.Button size2;
        private System.Windows.Forms.Button size3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button SizeR;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRemSolo;
        private System.Windows.Forms.Button buttonRE;
        private System.Windows.Forms.Button buttonRS;
        private System.Windows.Forms.Button buttonRL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label5;
    }
}

