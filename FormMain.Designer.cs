namespace EnigmaToolkit
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panel1 = new Panel();
            label4 = new Label();
            button4 = new Button();
            label3 = new Label();
            textBox2 = new TextBox();
            button3 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            label2 = new Label();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            label5 = new Label();
            button5 = new Button();
            progressBar1 = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Image = Properties.Resources._01313_upscayl_4x_upscayl_standard_4x;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(118, 12);
            label1.Name = "label1";
            label1.Size = new Size(301, 100);
            label1.TabIndex = 1;
            label1.Text = "Enigma Toolkit";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 118);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 320);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(768, 292);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Death end re;Quest 1 + 2";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 292);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.Location = new Point(5, 134);
            label4.Name = "label4";
            label4.Size = new Size(190, 23);
            label4.TabIndex = 7;
            label4.Text = "Extracted Folder";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            button4.Location = new Point(162, 160);
            button4.Name = "button4";
            button4.Size = new Size(33, 23);
            button4.TabIndex = 5;
            button4.Text = "...";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label3
            // 
            label3.Location = new Point(5, 57);
            label3.Name = "label3";
            label3.Size = new Size(190, 23);
            label3.TabIndex = 4;
            label3.Text = "Selected Archive";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(5, 160);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(151, 23);
            textBox2.TabIndex = 6;
            // 
            // button3
            // 
            button3.Location = new Point(162, 83);
            button3.Name = "button3";
            button3.Size = new Size(33, 23);
            button3.TabIndex = 1;
            button3.Text = "...";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(5, 83);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(151, 23);
            textBox1.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(5, 262);
            button2.Name = "button2";
            button2.Size = new Size(190, 23);
            button2.TabIndex = 2;
            button2.Text = "Repack";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(5, 233);
            button1.Name = "button1";
            button1.Size = new Size(190, 23);
            button1.TabIndex = 1;
            button1.Text = "Extract";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(-2, 0);
            label2.Name = "label2";
            label2.Size = new Size(200, 37);
            label2.TabIndex = 0;
            label2.Text = ".DAT Archives\r\nExtract/Repack\r\n";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(768, 292);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Neptunia Re;Birth 1 + 2 + 3";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(768, 292);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Mary Skelter 2 + Finale";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(643, 12);
            label5.Name = "label5";
            label5.Size = new Size(141, 23);
            label5.TabIndex = 3;
            label5.Text = "Toolset";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button5
            // 
            button5.Location = new Point(643, 38);
            button5.Name = "button5";
            button5.Size = new Size(141, 28);
            button5.TabIndex = 4;
            button5.Text = "Download";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(643, 72);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(141, 23);
            progressBar1.TabIndex = 5;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(progressBar1);
            Controls.Add(button5);
            Controls.Add(label5);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormMain";
            Text = "Enigma Toolkit";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Panel panel1;
        private Label label2;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label4;
        private Button button4;
        private Label label3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label5;
        private Button button5;
        private ProgressBar progressBar1;
    }
}
