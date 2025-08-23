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
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
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
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(768, 292);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Death end re;Quest 1 + 2";
            tabPage1.UseVisualStyleBackColor = true;
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
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
    }
}
