namespace A_Better_Voyager
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.FC = new System.Windows.Forms.TextBox();
            this.SC = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rssdsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.Ants = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.Iter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Seed = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button8 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1229, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1231, 33);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(12, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1066, 617);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.Gridpnt);
            this.panel2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Panel2_MouseDoubleClick);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel2_MouseMove);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gray;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(1103, 548);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(197, 58);
            this.button2.TabIndex = 3;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(1099, 631);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 37);
            this.label1.TabIndex = 4;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gray;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft YaHei", 15F);
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.Location = new System.Drawing.Point(1103, 466);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(197, 58);
            this.button3.TabIndex = 5;
            this.button3.Text = "Random";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Random);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox1.Location = new System.Drawing.Point(1151, 437);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 6;
            this.textBox1.Tag = "dont";
            this.textBox1.Text = "15";
            // 
            // FC
            // 
            this.FC.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.FC.Location = new System.Drawing.Point(1104, 265);
            this.FC.Name = "FC";
            this.FC.Size = new System.Drawing.Size(38, 26);
            this.FC.TabIndex = 10;
            this.FC.Tag = "dont";
            this.FC.Text = "15";
            // 
            // SC
            // 
            this.SC.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.SC.Location = new System.Drawing.Point(1262, 265);
            this.SC.Name = "SC";
            this.SC.Size = new System.Drawing.Size(38, 26);
            this.SC.TabIndex = 11;
            this.SC.Tag = "dont";
            this.SC.Text = "15";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Gray;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft YaHei", 15F);
            this.button6.Location = new System.Drawing.Point(1103, 297);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(197, 58);
            this.button6.TabIndex = 12;
            this.button6.Text = "Distance";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.ContextMenuStrip = this.contextMenuStrip1;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(1099, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 55);
            this.label2.TabIndex = 13;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rssdsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.Size = new System.Drawing.Size(126, 36);
            // 
            // rssdsToolStripMenuItem
            // 
            this.rssdsToolStripMenuItem.Name = "rssdsToolStripMenuItem";
            this.rssdsToolStripMenuItem.Size = new System.Drawing.Size(125, 32);
            this.rssdsToolStripMenuItem.Text = "rssds";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(1137, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 23);
            this.label3.TabIndex = 14;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Gray;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(12, 683);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(197, 58);
            this.button7.TabIndex = 15;
            this.button7.Text = "Solve .txt";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // Ants
            // 
            this.Ants.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Ants.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Ants.Location = new System.Drawing.Point(1101, 150);
            this.Ants.Name = "Ants";
            this.Ants.Size = new System.Drawing.Size(65, 35);
            this.Ants.TabIndex = 18;
            this.Ants.Tag = "dont";
            this.Ants.Text = "75";
            this.Ants.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Gray;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft YaHei", 15F);
            this.button4.Location = new System.Drawing.Point(1104, 373);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(197, 58);
            this.button4.TabIndex = 7;
            this.button4.Text = "Solve";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Button5_Click);
            // 
            // Iter
            // 
            this.Iter.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Iter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Iter.Location = new System.Drawing.Point(1101, 109);
            this.Iter.Name = "Iter";
            this.Iter.Size = new System.Drawing.Size(65, 35);
            this.Iter.TabIndex = 19;
            this.Iter.Tag = "dont";
            this.Iter.Text = "60";
            this.Iter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(1172, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 35);
            this.label4.TabIndex = 20;
            this.label4.Text = "Итерации";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Gray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(1172, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 35);
            this.label5.TabIndex = 21;
            this.label5.Text = "Муравьи";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.Label5_Click);
            // 
            // Seed
            // 
            this.Seed.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Seed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Seed.Location = new System.Drawing.Point(1103, 68);
            this.Seed.Name = "Seed";
            this.Seed.Size = new System.Drawing.Size(187, 35);
            this.Seed.TabIndex = 22;
            this.Seed.Tag = "dont";
            this.Seed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(1161, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 29);
            this.label6.TabIndex = 23;
            this.label6.Text = "Seed";
            this.label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Gray;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft YaHei", 15F);
            this.button8.Location = new System.Drawing.Point(259, 683);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(197, 58);
            this.button8.TabIndex = 25;
            this.button8.Text = "Colour";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Gray;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft YaHei", 15F);
            this.button5.Location = new System.Drawing.Point(516, 683);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(197, 58);
            this.button5.TabIndex = 26;
            this.button5.Text = "Help";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Button5_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1302, 771);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Seed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Iter);
            this.Controls.Add(this.Ants);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.SC);
            this.Controls.Add(this.FC);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox FC;
        private System.Windows.Forms.TextBox SC;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rssdsToolStripMenuItem;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox Ants;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox Iter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Seed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button5;
    }
}

